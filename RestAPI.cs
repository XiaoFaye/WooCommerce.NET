using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using WooCommerceNET.Base;

namespace WooCommerceNET
{
    public class RestAPI
    {
        private string wc_url = string.Empty;
        private string wc_key = "";
        private string wc_secret = "";
        //private bool wc_Proxy = false;

        private bool AuthorizedHeader { get; set; }

        private Func<string, string> jsonSeFilter;
        private Func<string, string> jsonDeseFilter;
        private Action<HttpWebRequest> webRequestFilter;

        /// <summary>
        /// Initialize the RestAPI object
        /// </summary>
        /// <param name="url">WooCommerce REST API URL, e.g.: http://yourstore/wp-json/wc/v1/ </param>
        /// <param name="key">WooCommerce REST API Key</param>
        /// <param name="secret">WooCommerce REST API Secret</param>
        /// <param name="authorizedHeader">WHEN using HTTPS, do you prefer to send the Credentials in HTTP HEADER?</param>
        /// <param name="jsonSerializeFilter">Provide a function to modify the json string after serilizing.</param>
        /// <param name="jsonDeserializeFilter">Provide a function to modify the json string before deserilizing.</param>
        /// <param name="requestFilter">Provide a function to modify the HttpWebRequest object.</param>
        public RestAPI(string url, string key, string secret, bool authorizedHeader = true, 
                            Func<string, string> jsonSerializeFilter = null, 
                            Func<string, string> jsonDeserializeFilter = null, 
                            Action<HttpWebRequest> requestFilter = null)//, bool useProxy = false)
        {
            if (string.IsNullOrEmpty(url))
                throw new Exception("Please use a valid WooCommerce Restful API url.");

            string urlLower = url.Trim().ToLower().TrimEnd('/');
            if (urlLower.EndsWith("wc-api/v1") || urlLower.EndsWith("wc-api/v2") || urlLower.EndsWith("wc-api/v3"))
                Version = APIVersion.Legacy;
            else if (urlLower.EndsWith("wp-json/wc/v1"))
                Version = APIVersion.Version1;
            else if (urlLower.EndsWith("wp-json/wc/v2"))
                Version = APIVersion.Version2;
            else
            {
                Version = APIVersion.Unknown;
                throw new Exception("Unknow WooCommerce Restful API version.");
            }
            
            wc_url = url + (url.EndsWith("/") ? "" : "/");
            wc_key = key;
            AuthorizedHeader = authorizedHeader;

            //Why extra '&'? look here: https://wordpress.org/support/topic/woocommerce-rest-api-v3-problem-woocommerce_api_authentication_error/
            if ((url.ToLower().Contains("wc-api/v3") || !IsLegacy) && !wc_url.StartsWith("https", StringComparison.OrdinalIgnoreCase))
                wc_secret = secret + "&";
            else
                wc_secret = secret;

            jsonSeFilter = jsonSerializeFilter;
            jsonDeseFilter = jsonDeserializeFilter;
            webRequestFilter = requestFilter;

            //wc_Proxy = useProxy;
        }

        

        public bool IsLegacy
        {
            get
            {
                return Version == APIVersion.Legacy;
            }
        }

        public APIVersion Version { get; private set; }

        public string Url { get { return wc_url; } }

        /// <summary>
        /// Make Restful calls
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="endpoint"></param>
        /// <param name="method">HEAD, GET, POST, PUT, PATCH, DELETE</param>
        /// <param name="requestBody">If your call doesn't have a body, please pass string.Empty, not null.</param>
        /// <param name="parms"></param>
        /// <returns>json string</returns>
        public async Task<string> SendHttpClientRequest<T>(string endpoint, RequestMethod method, T requestBody, Dictionary<string, string> parms = null)
        {
            HttpWebRequest httpWebRequest = null;
            try
            {
                if (wc_url.StartsWith("https", StringComparison.OrdinalIgnoreCase) && AuthorizedHeader)
                {
                    httpWebRequest = (HttpWebRequest)WebRequest.Create(wc_url + GetOAuthEndPoint(method.ToString(), endpoint, parms));
                    httpWebRequest.Headers["Authorization"] = "Basic " + Convert.ToBase64String(Encoding.GetEncoding("ISO-8859-1").GetBytes(wc_key + ":" + wc_secret));
                }
                else
                {
                    if (parms == null)
                        parms = new Dictionary<string, string>();

                    if (!parms.ContainsKey("consumer_key"))
                        parms.Add("consumer_key", wc_key);
                    if (!parms.ContainsKey("consumer_secret"))
                        parms.Add("consumer_secret", wc_secret);

                    httpWebRequest = (HttpWebRequest)WebRequest.Create(wc_url + GetOAuthEndPoint(method.ToString(), endpoint, parms));
                }

                // start the stream immediately
                httpWebRequest.Method = method.ToString();
                httpWebRequest.AllowReadStreamBuffering = false;

                if (webRequestFilter != null)
                    webRequestFilter.Invoke(httpWebRequest);

                //if (wc_Proxy)
                //    httpWebRequest.Proxy.Credentials = CredentialCache.DefaultCredentials;
                //else
                //    httpWebRequest.Proxy = null;

                if (requestBody.GetType() != typeof(string))
                {
                    httpWebRequest.ContentType = "application/json";
                    var buffer = Encoding.UTF8.GetBytes(SerializeJSon(requestBody));
                    Stream dataStream = await httpWebRequest.GetRequestStreamAsync();
                    dataStream.Write(buffer, 0, buffer.Length);
                }
                
                // asynchronously get a response
                WebResponse wr = await httpWebRequest.GetResponseAsync();
                return await GetStreamContent(wr.GetResponseStream(), wr.ContentType.Contains("=") ? wr.ContentType.Split('=')[1] : "UTF-8");
            }
            catch (WebException we)
            {
                if (httpWebRequest != null && httpWebRequest.HaveResponse)
                    if (we.Response != null)
                        throw new Exception(await GetStreamContent(we.Response.GetResponseStream(), we.Response.ContentType.Contains("=") ? we.Response.ContentType.Split('=')[1] : "UTF-8"));
                    else
                        throw we;
                else
                    throw we;
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        public async Task<string> GetRestful(string endpoint, Dictionary<string, string> parms = null)
        {
            return await SendHttpClientRequest(endpoint, RequestMethod.GET, string.Empty, parms);
        }

        public async Task<string> PostRestful(string endpoint, object jsonObject, Dictionary<string, string> parms = null)
        {
            return await SendHttpClientRequest(endpoint, RequestMethod.POST, jsonObject, parms);
        }

        public async Task<string> PutRestful(string endpoint, object jsonObject, Dictionary<string, string> parms = null)
        {
            return await SendHttpClientRequest(endpoint, RequestMethod.PUT, jsonObject, parms);
        }

        public async Task<string> DeleteRestful(string endpoint, Dictionary<string, string> parms = null)
        {
            return await SendHttpClientRequest(endpoint, RequestMethod.DELETE, string.Empty, parms);
        }

        private string GetOAuthEndPoint(string method, string endpoint, Dictionary<string, string> parms = null)
        {
            if (wc_url.StartsWith("https", StringComparison.OrdinalIgnoreCase))
            {
                if (parms == null)
                    return endpoint;
                else
                {
                    string requestParms = string.Empty;
                    foreach (var parm in parms)
                        requestParms += parm.Key + "=" + parm.Value + "&";

                    return endpoint + "?" + requestParms.TrimEnd('&');
                }
            }

            Dictionary<string, string> dic = new Dictionary<string, string>();
            dic.Add("oauth_consumer_key", wc_key);
            dic.Add("oauth_nonce", Guid.NewGuid().ToString("N"));
            dic.Add("oauth_signature_method", "HMAC-SHA256");
            dic.Add("oauth_timestamp", Common.GetUnixTime(false));

            if (parms != null)
                foreach (var p in parms)
                    dic.Add(p.Key, p.Value);

            string base_request_uri = Uri.EscapeDataString(wc_url + endpoint).Replace("%2f", "%2F").Replace("%3a", "%3A");
            string stringToSign = string.Empty;

            foreach (var parm in dic.OrderBy(x => x.Key))
                stringToSign += Uri.EscapeDataString(parm.Key) + "%3D" + Uri.EscapeDataString(Uri.EscapeDataString(parm.Value)) + "%26";

            base_request_uri = method.ToUpper() + "&" + base_request_uri + "&" + stringToSign.Substring(0, stringToSign.Length - 3);
            
            Common.DebugInfo.Append(base_request_uri);

            stringToSign += "oauth_signature%3D" + Common.GetSHA256(wc_secret, base_request_uri);

            dic.Add("oauth_signature", Common.GetSHA256(wc_secret, base_request_uri));

            string parmstr = string.Empty;
            foreach (var parm in dic)
                parmstr += parm.Key + "=" + Uri.EscapeDataString(parm.Value) + "&";

            return endpoint + "?" + parmstr.TrimEnd('&');
        }
        
        private async Task<string> GetStreamContent(Stream s, string charset)
        {
            StringBuilder sb = new StringBuilder();
            byte[] Buffer = new byte[512];
            int count = 0;
            count = await s.ReadAsync(Buffer, 0, Buffer.Length);
            while (count > 0)
            {
                sb.Append(Encoding.GetEncoding(charset).GetString(Buffer, 0, count));
                count = await s.ReadAsync(Buffer, 0, Buffer.Length);
            }

            return sb.ToString();
        }

        public virtual string SerializeJSon<T>(T t)
        {
            DataContractJsonSerializerSettings settings = new DataContractJsonSerializerSettings()
            {
                DateTimeFormat = new DateTimeFormat(DateTimeFormat),
                UseSimpleDictionaryFormat = true
            };

            MemoryStream stream = new MemoryStream();
            DataContractJsonSerializer ds = new DataContractJsonSerializer(t.GetType(), settings);
            ds.WriteObject(stream, t);
            byte[] data = stream.ToArray();
            string jsonString = Encoding.UTF8.GetString(data, 0, data.Length);

            if (IsLegacy)
                if (typeof(T).IsArray)
                    jsonString = "{\"" + typeof(T).Name.ToLower().Replace("[]", "s") + "\":" + jsonString + "}";
                else
                    jsonString = "{\"" + typeof(T).Name.ToLower() + "\":" + jsonString + "}";

            stream.Dispose();

            if (jsonSeFilter != null)
                jsonString = jsonSeFilter.Invoke(jsonString);

            return jsonString;
        }

        public virtual T DeserializeJSon<T>(string jsonString)
        {
            if (jsonDeseFilter != null)
                jsonString = jsonDeseFilter.Invoke(jsonString);

            Type dT = typeof(T);
            
            if (dT.Name.EndsWith("List"))
                dT = dT.GetTypeInfo().DeclaredProperties.First().PropertyType.GenericTypeArguments[0];

            DataContractJsonSerializerSettings settings = new DataContractJsonSerializerSettings()
            {
                DateTimeFormat = new DateTimeFormat(DateTimeFormat),
                UseSimpleDictionaryFormat = true
            };

            DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(T), settings);
            MemoryStream stream = new MemoryStream(Encoding.UTF8.GetBytes(jsonString));
            T obj = (T)ser.ReadObject(stream);
            stream.Dispose();

            return obj;
        }

        public string DateTimeFormat
        {
            get
            {
                return IsLegacy ? "yyyy-MM-ddTHH:mm:ssZ" : "yyyy-MM-ddTHH:mm:ss";
            }
        }
    }

    public enum RequestMethod
    {
        HEAD = 1,
        GET = 2,
        POST = 3,
        PUT = 4,
        PATCH = 5,
        DELETE = 6
    }

    public enum APIVersion
    {
        Unknown = 0,
        Legacy = 1,
        Version1 = 2,
        Version2 = 3
    }
}
