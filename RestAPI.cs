using Newtonsoft.Json;
using RestSharp.Portable;
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
            wc_secret = secret;
        }

        public async Task<string> GetRestful(string endpoint, List<Parameter> parms = null)
        {
            var client = new RestClient(wc_url);

            client.IgnoreResponseStatusCode = true; //VERY IMPORTANT!!!!!!!!!!

            var request = new RestRequest(endpoint, HttpMethod.Get);

            BuildParameters(ref request, parms);

            var response = await client.Execute(request).ConfigureAwait(false);
            var json = Encoding.UTF8.GetString(response.RawBytes, 0, response.RawBytes.Length);

            int count = 0;
            while (response.StatusCode != HttpStatusCode.OK)
            {
                //retry 5 times and then give up.
                if (count >= 5) break;

                await Task.Delay(200);
                count++;

                BuildParameters(ref request, parms);
                response = await client.Execute(request).ConfigureAwait(false);
                json = Encoding.UTF8.GetString(response.RawBytes, 0, response.RawBytes.Length);
            }

            if (response.StatusCode != HttpStatusCode.OK)
            {
                //json = json.Substring(11, json.Length - 13);
                //WooError we = JsonConvert.DeserializeObject<WooError>(json);
                //throw new WCException { WE = we, Message = "" };
                throw new Exception("Network is unavaliable now, please try again later.");
            }

            return json;
        }

        private void BuildParameters(ref RestRequest request, List<Parameter> parms)
        {
            request.Parameters.Clear();

            if (parms != null)
                foreach (var p in parms)
                    request.AddParameter(p);

            request.AddParameter("oauth_consumer_key", wc_key);
            request.AddParameter("oauth_nonce", Common.GetSHA1(Common.GetUnixTime(true)));
            request.AddParameter("oauth_signature_method", "HMAC-SHA256");
            request.AddParameter("oauth_timestamp", Common.GetUnixTime(false));

            if (parms != null)
            {
                List<Parameter> sortedList = request.Parameters.OrderBy(p => p.Name).ToList();
                request.Parameters.Clear();

                foreach (var p in sortedList)
                    request.Parameters.Add(p);
            }

            string base_request_uri = WebUtility.UrlEncode(wc_url + request.Resource).Replace("%2f", "%2F").Replace("%3a", "%3A");

            string parmstr = string.Empty;
            foreach (var parm in request.Parameters)
                parmstr += parm.Name + "%3D" + parm.Value + "%26";

            base_request_uri = "GET&" + base_request_uri + "&" + parmstr.Substring(0, parmstr.Length - 3);

            base_request_uri = base_request_uri.Replace(",", "%252C").Replace("[", "%255B").Replace("]", "%255D");

            Common.DebugInfo.Append(base_request_uri);

            request.AddParameter("oauth_signature", Common.GetSHA256(wc_secret, base_request_uri));
        }
    }
}
