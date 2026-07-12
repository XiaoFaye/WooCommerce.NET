using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
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
        // HttpClient is intended to be instantiated once and reused for the lifetime of the
        // application, rather than created per-request like HttpWebRequest was. Creating a new
        // HttpClient per call can exhaust available sockets under load ("socket exhaustion").
        private static readonly HttpClient httpClient = new HttpClient();

        protected string wc_url = string.Empty;
        protected string wc_key = "";
        protected string wc_secret = "";
        //private bool wc_Proxy = false;

        protected bool AuthorizedHeader { get; set; }

        protected Func<string, string> jsonSeFilter;
        protected Func<string, string> jsonDeseFilter;
        protected Action<HttpRequestMessage> webRequestFilter;
        protected Action<HttpResponseMessage> webResponseFilter;

        /// <summary>
        /// For Wordpress REST API with OAuth 1.0 ONLY
        /// </summary>
        public string oauth_token { get; set; }

        /// <summary>
        /// For Wordpress REST API with OAuth 1.0 ONLY
        /// </summary>
        public string oauth_token_secret { get; set; }

        public WP_JWT_Object JWT_Object { get; set; }

        /// <summary>
        /// Authenticate Woocommerce API with JWT when set to True
        /// </summary>
        public bool WCAuthWithJWT { get; set; }

        /// <summary>
        /// Provide a function to modify the json string before deserilizing, this is for JWT Token ONLY!
        /// </summary>
        public Func<string, string> JWTDeserializeFilter { get; set; }

        /// <summary>
        /// Provide a function to modify the HttpRequestMessage object, this is for JWT Token ONLY!
        /// </summary>
        public Action<HttpRequestMessage> JWTRequestFilter { get; set; }

        /// <summary>
        /// If running in Debug mode, default is False.
        /// NOTE: Beware when setting Debug to True, as exceptions might contain sensetive information.
        /// </summary>
        public bool Debug { get; set; }

        /// <summary>
        /// Initialize the RestAPI object
        /// </summary>
        /// <param name="url">
        /// WooCommerce REST API URL, e.g.: http://yourstore/wp-json/wc/v1/ 
        /// WordPress REST API URL, e.g.: http://yourstore/wp-json/
        /// </param>
        /// <param name="key">WooCommerce REST API Key Or WordPress consumerKey</param>
        /// <param name="secret">WooCommerce REST API Secret Or WordPress consumerSecret</param>
        /// <param name="authorizedHeader">WHEN using HTTPS, do you prefer to send the Credentials in HTTP HEADER?</param>
        /// <param name="jsonSerializeFilter">Provide a function to modify the json string after serilizing.</param>
        /// <param name="jsonDeserializeFilter">Provide a function to modify the json string before deserilizing.</param>
        /// <param name="requestFilter">Provide a function to modify the HttpRequestMessage object.</param>
        /// <param name="responseFilter">Provide a function to grab information from the HttpResponseMessage object.</param>
        public RestAPI(string url, string key, string secret, bool authorizedHeader = true,
                            Func<string, string> jsonSerializeFilter = null,
                            Func<string, string> jsonDeserializeFilter = null,
                            Action<HttpRequestMessage> requestFilter = null,
                            Action<HttpResponseMessage> responseFilter = null)//, bool useProxy = false)
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
            else if (urlLower.EndsWith("wp-json/wc/v3"))
                Version = APIVersion.Version3;
            else if (urlLower.Contains("wp-json/wc-"))
                Version = APIVersion.ThirdPartyPlugins;
            else if (urlLower.EndsWith("wp-json/wp/v2") || urlLower.EndsWith("wp-json"))
                Version = APIVersion.WordPressAPI;
            else if (urlLower.EndsWith("jwt-auth/v1/token"))
            {
                Version = APIVersion.WordPressAPIJWT;
                url = urlLower.Replace("jwt-auth/v1/token", "wp/v2");
            }
            else
            {
                Version = APIVersion.Unknown;
                throw new Exception("Unknown WooCommerce Restful API version.");
            }

            wc_url = url + (url.EndsWith("/") ? "" : "/");
            wc_key = key;
            AuthorizedHeader = authorizedHeader;

            //Why extra '&'? look here: https://wordpress.org/support/topic/woocommerce-rest-api-v3-problem-woocommerce_api_authentication_error/
            if ((url.ToLower().Contains("wc-api/v3") || !IsLegacy) && !wc_url.StartsWith("https", StringComparison.OrdinalIgnoreCase) && !(Version == APIVersion.WordPressAPI || Version == APIVersion.WordPressAPIJWT))
                wc_secret = secret + "&";
            else
                wc_secret = secret;

            jsonSeFilter = jsonSerializeFilter;
            jsonDeseFilter = jsonDeserializeFilter;
            webRequestFilter = requestFilter;
            webResponseFilter = responseFilter;

            //wc_Proxy = useProxy;
        }

        public bool IsLegacy
        {
            get => Version == APIVersion.Legacy;
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
        public virtual async Task<string> SendHttpClientRequest<T>(string endpoint, RequestMethod method, T requestBody, Dictionary<string, string> parms = null)
        {
            HttpRequestMessage httpRequestMessage = null;
            try
            {
                if (Version == APIVersion.WordPressAPI)
                {
                    if ((string.IsNullOrEmpty(oauth_token) || string.IsNullOrEmpty(oauth_token_secret)) && (string.IsNullOrEmpty(wc_key) || string.IsNullOrEmpty(wc_secret)))
                        throw new Exception($"oauth_token and oauth_token_secret parameters are required when using WordPress REST API.");
                }

                if ((Version == APIVersion.WordPressAPIJWT || WCAuthWithJWT) && JWT_Object == null)
                {
                    string tokenUrl = wc_url.Replace("wp/v2", "jwt-auth/v1/token")
                                             .Replace("wc/v1", "jwt-auth/v1/token")
                                             .Replace("wc/v2", "jwt-auth/v1/token")
                                             .Replace("wc/v3", "jwt-auth/v1/token");

                    using (HttpRequestMessage tokenRequest = new HttpRequestMessage(HttpMethod.Post, tokenUrl))
                    {
                        string formBody = $"username={wc_key}&password={WebUtility.UrlEncode(wc_secret)}";
                        tokenRequest.Content = new StringContent(formBody, Encoding.UTF8);
                        tokenRequest.Content.Headers.ContentType = new MediaTypeHeaderValue("application/x-www-form-urlencoded");

                        if (JWTRequestFilter != null)
                            JWTRequestFilter.Invoke(tokenRequest);

                        using (HttpResponseMessage tokenResponse = await httpClient.SendAsync(tokenRequest).ConfigureAwait(false))
                        {
                            string result = await GetResponseContent(tokenResponse).ConfigureAwait(false);

                            if (JWTDeserializeFilter != null)
                                result = JWTDeserializeFilter.Invoke(result);

                            JWT_Object = DeserializeJSon<WP_JWT_Object>(result);
                        }
                    }
                }

                string requestUri;

                if (wc_url.StartsWith("https", StringComparison.OrdinalIgnoreCase) && Version != APIVersion.WordPressAPI && Version != APIVersion.WordPressAPIJWT)
                {
                    if (AuthorizedHeader == false)
                    {
                        if (parms == null)
                            parms = new Dictionary<string, string>();

                        if (!parms.ContainsKey("consumer_key"))
                            parms.Add("consumer_key", wc_key);
                        if (!parms.ContainsKey("consumer_secret"))
                            parms.Add("consumer_secret", wc_secret);
                    }

                    //Allow accessing WordPress plugin REST API with WooCommerce secret and key.
                    //Url should be passed to RestAPI as WooCommerce Rest API url, e.g.: https://mystore.com/wp-json/wc/v3
                    //Endpoint should be starting with wp-json
                    if (endpoint.StartsWith("wp-json"))
                        requestUri = new Uri(new Uri($"https://{new Uri(wc_url).Host}"), GetOAuthEndPoint(method.ToString(), endpoint, parms)).ToString();
                    else
                        requestUri = wc_url + GetOAuthEndPoint(method.ToString(), endpoint, parms);

                    httpRequestMessage = new HttpRequestMessage(new HttpMethod(method.ToString()), requestUri);

                    if (AuthorizedHeader == true)
                    {
                        if (WCAuthWithJWT && JWT_Object != null)
                            httpRequestMessage.Headers.Authorization = new AuthenticationHeaderValue("Bearer", JWT_Object.token);
                        else
                            httpRequestMessage.Headers.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(Encoding.GetEncoding("ISO-8859-1").GetBytes(wc_key + ":" + wc_secret)));
                    }
                }
                else
                {
                    requestUri = wc_url + GetOAuthEndPoint(method.ToString(), endpoint, parms);
                    httpRequestMessage = new HttpRequestMessage(new HttpMethod(method.ToString()), requestUri);

                    if (Version == APIVersion.WordPressAPIJWT)
                        httpRequestMessage.Headers.Authorization = new AuthenticationHeaderValue("Bearer", JWT_Object.token);
                    else if (wc_url.StartsWith("https", StringComparison.OrdinalIgnoreCase) && Version == APIVersion.WordPressAPI)
                        httpRequestMessage.Headers.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(Encoding.GetEncoding("ISO-8859-1").GetBytes(wc_key + ":" + wc_secret)));
                }

                if (webRequestFilter != null)
                    webRequestFilter.Invoke(httpRequestMessage);

                //if (wc_Proxy)
                //    httpWebRequest.Proxy.Credentials = CredentialCache.DefaultCredentials;
                //else
                //    httpWebRequest.Proxy = null;

                if (requestBody != null && requestBody.GetType() != typeof(string))
                {
                    string json = SerializeJSon(requestBody);
                    httpRequestMessage.Content = new StringContent(json, Encoding.UTF8);
                    httpRequestMessage.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                }
                else
                {
                    if (requestBody != null && requestBody.ToString() != string.Empty)
                    {
                        if (requestBody.ToString() == "fileupload")
                        {
                            FileStream fileStream = new FileStream(parms["path"], FileMode.Open, FileAccess.Read);
                            StreamContent streamContent = new StreamContent(fileStream);
                            streamContent.Headers.ContentType = new MediaTypeHeaderValue("application/x-www-form-urlencoded");
                            streamContent.Headers.ContentDisposition = new ContentDispositionHeaderValue("form-data")
                            {
                                FileName = parms["name"]
                            };

                            httpRequestMessage.Content = streamContent;
                        }
                        else
                        {
                            httpRequestMessage.Content = new StringContent(requestBody.ToString(), Encoding.UTF8);
                            httpRequestMessage.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                        }
                    }
                }

                // asynchronously get a response, reading headers first so large bodies aren't buffered up-front
                using (HttpResponseMessage httpResponseMessage = await httpClient.SendAsync(httpRequestMessage, HttpCompletionOption.ResponseHeadersRead).ConfigureAwait(false))
                {
                    if (webResponseFilter != null)
                        webResponseFilter.Invoke(httpResponseMessage);

                    string content = await GetResponseContent(httpResponseMessage).ConfigureAwait(false);

                    // HttpClient does not throw automatically on non-2xx status codes the way
                    // HttpWebRequest/WebException did, so replicate that behavior explicitly,
                    // surfacing the response body (often a JSON error payload) as the message.
                    if (!httpResponseMessage.IsSuccessStatusCode)
                        throw new HttpRequestException(content);

                    return content;
                }
            }
            catch (HttpRequestException)
            {
                throw;
            }
            catch (Exception e)
            {
                return e.Message;
            }
            finally
            {
                if (httpRequestMessage != null)
                    httpRequestMessage.Dispose();
            }
        }

        public async Task<string> GetRestful(string endpoint, Dictionary<string, string> parms = null)
        => await SendHttpClientRequest(endpoint.ToLower(), RequestMethod.GET, string.Empty, parms).ConfigureAwait(false);
        
        public async Task<string> PostRestful(string endpoint, object jsonObject, Dictionary<string, string> parms = null)
        => await SendHttpClientRequest(endpoint.ToLower(), RequestMethod.POST, jsonObject, parms).ConfigureAwait(false);
        
        public async Task<string> PutRestful(string endpoint, object jsonObject, Dictionary<string, string> parms = null)
        => await SendHttpClientRequest(endpoint.ToLower(), RequestMethod.PUT, jsonObject, parms).ConfigureAwait(false);
        
        public async Task<string> DeleteRestful(string endpoint, Dictionary<string, string> parms = null)
        => await SendHttpClientRequest(endpoint.ToLower(), RequestMethod.DELETE, string.Empty, parms).ConfigureAwait(false);
        
        public async Task<string> DeleteRestful(string endpoint, object jsonObject, Dictionary<string, string> parms = null)
        => await SendHttpClientRequest(endpoint.ToLower(), RequestMethod.DELETE, jsonObject, parms).ConfigureAwait(false);
        
        protected string GetOAuthEndPoint(string method, string endpoint, Dictionary<string, string> parms = null)
        {
            if (Version == APIVersion.WordPressAPIJWT ||
                (wc_url.StartsWith("https", StringComparison.OrdinalIgnoreCase) && Version != APIVersion.WordPressAPI) ||
                (wc_url.StartsWith("https", StringComparison.OrdinalIgnoreCase) && Version == APIVersion.WordPressAPI && !string.IsNullOrEmpty(wc_key) && !string.IsNullOrEmpty(wc_secret)))
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

            if (Version == APIVersion.WordPressAPI)
                dic.Add("oauth_token", oauth_token);

            dic.Add("oauth_nonce", Guid.NewGuid().ToString("N"));
            dic.Add("oauth_signature_method", "HMAC-SHA256");
            dic.Add("oauth_timestamp", Common.GetUnixTime(false));
            dic.Add("oauth_version", "1.0");

            if (parms != null)
                foreach (var p in parms)
                    dic.Add(p.Key, p.Value);

            string base_request_uri = method.ToUpper() + "&" + Uri.EscapeDataString(wc_url + endpoint) + "&";
            string stringToSign = string.Empty;

            foreach (var parm in dic.OrderBy(x => x.Key))
                stringToSign += Uri.EscapeDataString(parm.Key) + "=" + Uri.EscapeDataString(parm.Value) + "&";

            base_request_uri = base_request_uri + Uri.EscapeDataString(stringToSign.TrimEnd('&'));

            if (Version == APIVersion.WordPressAPI)
                dic.Add("oauth_signature", Common.GetSHA256(wc_secret + "&" + oauth_token_secret, base_request_uri));
            else
                dic.Add("oauth_signature", Common.GetSHA256(wc_secret, base_request_uri));

            string parmstr = string.Empty;
            foreach (var parm in dic)
                parmstr += parm.Key + "=" + Uri.EscapeDataString(parm.Value) + "&";

            return endpoint + "?" + parmstr.TrimEnd('&');
        }

        /// <summary>
        /// Reads the body of an HttpResponseMessage as a string, honoring the charset
        /// declared in the response's Content-Type header (defaulting to UTF-8).
        /// Replaces the old stream-chunking GetStreamContent() usage for HTTP responses.
        /// </summary>
        protected async Task<string> GetResponseContent(HttpResponseMessage response)
        {
            var charset = "UTF-8";
            MediaTypeHeaderValue contentType = response.Content.Headers.ContentType;
            if (contentType != null && !string.IsNullOrEmpty(contentType.CharSet))
                charset = contentType.CharSet;

            var data = await response.Content.ReadAsByteArrayAsync().ConfigureAwait(false);
            return Encoding.GetEncoding(charset).GetString(data);
        }

        /// <summary>
        /// Retained for backwards compatibility with any derived classes that call it directly.
        /// No longer used internally now that responses are read via GetResponseContent().
        /// </summary>
        protected async Task<string> GetStreamContent(Stream s, string charset)
        {
            StringBuilder sb = new StringBuilder();
            byte[] Buffer = new byte[512];
            int count = 0;
            count = await s.ReadAsync(Buffer, 0, Buffer.Length).ConfigureAwait(false);
            while (count > 0)
            {
                sb.Append(Encoding.GetEncoding(charset).GetString(Buffer, 0, count));
                count = await s.ReadAsync(Buffer, 0, Buffer.Length).ConfigureAwait(false);
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

            if (t.GetType().GetMethod("FormatJsonS") != null)
            {
                jsonString = t.GetType().GetMethod("FormatJsonS").Invoke(null, new object[] { jsonString }).ToString();
            }

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

            try
            {
                if (dT.Name.EndsWith("List"))
                    dT = dT.GetTypeInfo().DeclaredProperties.First().PropertyType.GenericTypeArguments[0];

                if (dT.FullName.StartsWith("System.Collections.Generic.List"))
                {
                    dT = dT.GetProperty("Item").PropertyType;
                }

                if (dT.GetMethod("FormatJsonD") != null)
                {
                    jsonString = dT.GetMethod("FormatJsonD").Invoke(null, new object[] { jsonString }).ToString();
                }

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
            catch (Exception ex)
            {
                if (Debug)
                    throw new Exception(ex.Message + Environment.NewLine + Environment.NewLine + jsonString);
                else
                    throw ex;
            }
        }

        public string DateTimeFormat
        {
            get => IsLegacy ? "yyyy-MM-ddTHH:mm:ssZ" : "yyyy-MM-ddTHH:mm:ssK";
        }
    }

    public class WP_JWT_Object
    {
        public string token { get; set; }

        public string user_email { get; set; }

        public string user_nicename { get; set; }

        public string user_display_name { get; set; }
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
        Version2 = 3,
        Version3 = 4,
        WordPressAPI = 90,
        WordPressAPIJWT = 91,
        ThirdPartyPlugins = 99
    }
}