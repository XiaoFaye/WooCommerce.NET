using Newtonsoft.Json;
using RestSharp.Portable;
using RestSharp.Portable.HttpClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace WooCommerceNET
{
    public class RestAPI
    {
        private string wc_url = string.Empty;
        private string wc_key = "";
        private string wc_secret = "";

        public RestAPI(string url, string key, string secret)
        {
            wc_url = url;
            wc_key = key;
            if (url.ToLower().Contains("wc-api/v3"))
                wc_secret = secret + "&";
            else
                wc_secret = secret;
        }

        public async Task<string> GetRestful(string endpoint, Dictionary<string, string> parms = null)
        {
            var client = new RestClient(wc_url);
            client.IgnoreResponseStatusCode = true; //This will return the json error message instead of throw out an exception.
            var request = new RestRequest(GetOAuthEndPoint("GET", endpoint, parms), Method.GET);

            var response = await client.Execute(request).ConfigureAwait(false);
            var json = Encoding.UTF8.GetString(response.RawBytes, 0, response.RawBytes.Length);

            if (response.StatusCode != HttpStatusCode.OK)
            {
                //json = json.Substring(11, json.Length - 13);
                //WooError we = JsonConvert.DeserializeObject<WooError>(json);
                //throw new WCException { WE = we, Message = "" };
                throw new Exception("Network is unavaliable now, please try again later.");
            }

            return json;
        }

        public async Task<string> PostRestful(string endpoint, object jsonObject, Dictionary<string, string> parms = null)
        {
            var client = new RestClient(wc_url);
            client.IgnoreResponseStatusCode = true; //This will return the json error message instead of throw out an exception.
            var request = new RestRequest(GetOAuthEndPoint("POST", endpoint, parms), Method.POST);
            var result = string.Empty;

            request.AddBody(jsonObject);

            try
            {
                var response = await client.Execute(request).ConfigureAwait(false);
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    //OK
                }
                else
                {
                    result = Encoding.UTF8.GetString(response.RawBytes, 0, response.RawBytes.Length);
                    //NOK
                }
            }
            catch(Exception ex)
            {
                return ex.Message;
            }

            return result;
        }

        public async Task<string> PutRestful(string endpoint, object jsonObject, Dictionary<string, string> parms = null)
        {
            var client = new RestClient(wc_url);
            client.IgnoreResponseStatusCode = true; //This will return the json error message instead of throw out an exception.
            var request = new RestRequest(GetOAuthEndPoint("PUT", endpoint, parms), Method.PUT);
            var result = string.Empty;

            request.AddBody(jsonObject);

            try
            {
                var response = await client.Execute(request).ConfigureAwait(false);
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    //OK
                }
                else
                {
                    result = Encoding.UTF8.GetString(response.RawBytes, 0, response.RawBytes.Length);
                    //NOK
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

            return result;
        }

        public async Task<string> DeleteRestful(string endpoint, Dictionary<string, string> parms = null)
        {
            var client = new RestClient(wc_url);
            client.IgnoreResponseStatusCode = true; //This will return the json error message instead of throw out an exception.
            var request = new RestRequest(GetOAuthEndPoint("DELETE", endpoint, parms), Method.DELETE);
            var result = string.Empty;

            var response = await client.Execute(request).ConfigureAwait(false);
            result = Encoding.UTF8.GetString(response.RawBytes, 0, response.RawBytes.Length);

            return result;
        }

        private string GetOAuthEndPoint(string method, string endpoint, Dictionary<string, string> parms = null)
        {
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
    }
}
