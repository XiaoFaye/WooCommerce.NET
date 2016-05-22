using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace WooCommerceNET
{
    public class RestAPI
    {
        private string wc_url = string.Empty;
        private string wc_key = "";
        private string wc_secret = "";
        //private bool wc_Proxy = false;

        public RestAPI(string url, string key, string secret)//, bool useProxy = false)
        {
            wc_url = url;
            wc_key = key;
            if (url.ToLower().Contains("wc-api/v3") && !wc_url.StartsWith("https", StringComparison.OrdinalIgnoreCase))
                wc_secret = secret + "&";
            else
                wc_secret = secret;

            //wc_Proxy = useProxy;
        }

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
                httpWebRequest = (HttpWebRequest)HttpWebRequest.Create(wc_url + GetOAuthEndPoint(method.ToString(), endpoint, parms));
                if (wc_url.StartsWith("https", StringComparison.OrdinalIgnoreCase))
                {
                    httpWebRequest.Credentials = new NetworkCredential(wc_key, wc_secret);
                }

                // start the stream immediately
                httpWebRequest.Method = method.ToString();
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.AllowReadStreamBuffering = false;
                //if (wc_Proxy)
                //    httpWebRequest.Proxy.Credentials = CredentialCache.DefaultCredentials;
                //else
                //    httpWebRequest.Proxy = null;
                
                if (requestBody.GetType() != typeof(string))
                {
                    var buffer = UTF8Encoding.UTF8.GetBytes(SerializeJSon(requestBody));
                    Stream dataStream = await httpWebRequest.GetRequestStreamAsync();
                    dataStream.Write(buffer, 0, buffer.Length);
                }

                // asynchronously get a response
                WebResponse wr = await httpWebRequest.GetResponseAsync();
                return await GetStreamContent(wr.GetResponseStream(), wr.ContentType.Split('=')[1]);
            }
            catch (WebException we)
            {
                if (httpWebRequest != null && httpWebRequest.HaveResponse)
                    if (we.Response != null)
                        throw new Exception(await GetStreamContent(we.Response.GetResponseStream(), we.Response.ContentType.Split('=')[1]));
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
            dic.Add("oauth_nonce", Common.GetSHA1(Common.GetUnixTime(true)));
            dic.Add("oauth_signature_method", "HMAC-SHA256");
            dic.Add("oauth_timestamp", Common.GetUnixTime(false));

            if (parms != null)
                foreach (var p in parms)
                    dic.Add(p.Key, p.Value);

            string base_request_uri = System.Uri.EscapeDataString(wc_url + endpoint).Replace("%2f", "%2F").Replace("%3a", "%3A");
            string stringToSign = string.Empty;

            foreach (var parm in dic.OrderBy(x => x.Key))
                stringToSign += parm.Key + "%3D" + parm.Value + "%26";

            base_request_uri = method.ToUpper() + "&" + base_request_uri + "&" + stringToSign.Substring(0, stringToSign.Length - 3);

            base_request_uri = base_request_uri.Replace(",", "%252C").Replace("[", "%255B").Replace("]", "%255D");

            Common.DebugInfo.Append(base_request_uri);

            stringToSign += "oauth_signature%3D" + Common.GetSHA256(wc_secret, base_request_uri).Replace(",", "%252C").Replace("[", "%255B").Replace("]", "%255D").Replace("=", "%3D");

            dic.Add("oauth_signature", Common.GetSHA256(wc_secret, base_request_uri).Replace(",", "%252C").Replace("[", "%255B").Replace("]", "%255D").Replace("=", "%3D"));

            string parmstr = string.Empty;
            foreach (var parm in dic)
                parmstr += parm.Key + "=" + System.Uri.EscapeDataString(parm.Value) + "&";


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

        public static string SerializeJSon<T>(T t)
        {
            DataContractJsonSerializerSettings settings = new DataContractJsonSerializerSettings()
            {
                DateTimeFormat = new DateTimeFormat("yyyy-MM-ddTHH:mm:ssZ"),
                UseSimpleDictionaryFormat = true
            };
            MemoryStream stream = new MemoryStream();
            DataContractJsonSerializer ds = new DataContractJsonSerializer(typeof(T), settings);
            ds.WriteObject(stream, t);
            byte[] data = stream.ToArray();
            string jsonString = Encoding.UTF8.GetString(data, 0, data.Length);
            if (typeof(T).IsArray)
                jsonString = "{\"" + typeof(T).Name.ToLower().Replace("[]", "s") + "\":" + jsonString + "}";
            else
                jsonString = "{\"" + typeof(T).Name.ToLower() + "\":" + jsonString + "}";

            stream.Dispose();

            return jsonString;
        }

        public static T DeserializeJSon<T>(string jsonString)
        {
            DataContractJsonSerializerSettings settings = new DataContractJsonSerializerSettings()
            {
                DateTimeFormat = new DateTimeFormat("yyyy-MM-ddTHH:mm:ssZ"),
                UseSimpleDictionaryFormat = true
            };
            DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(T), settings);
            MemoryStream stream = new MemoryStream(Encoding.UTF8.GetBytes(jsonString));
            T obj = (T)ser.ReadObject(stream);
            stream.Dispose();

            return obj;
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

    public static class HttpWebRequestExtensions
    {
        public static Task<Stream> GetRequestStreamAsync(this HttpWebRequest request)
        {
            var tcs = new TaskCompletionSource<Stream>();

            try
            {
                request.BeginGetRequestStream(iar =>
               {
                   try
                   {
                       var response = request.EndGetRequestStream(iar);
                       tcs.SetResult(response);
                   }
                   catch (Exception exc)
                   {
                       tcs.SetException(exc);
                   }
               }, null);
            }
            catch (Exception exc)
            {
                tcs.SetException(exc);
            }

            return tcs.Task;
        }

        public static Task<HttpWebResponse> GetResponseAsync(this HttpWebRequest request)
        {
            var tcs = new TaskCompletionSource<HttpWebResponse>();

            try
            {
                request.BeginGetResponse(iar =>
                {
                    try
                    {
                        var response = (HttpWebResponse)request.EndGetResponse(iar);
                        tcs.SetResult(response);
                    }
                    catch (Exception exc)
                    {
                        tcs.SetException(exc);
                    }
                }, null);
            }
            catch (Exception exc)
            {
                tcs.SetException(exc);
            }

            return tcs.Task;
        }
    }
}
