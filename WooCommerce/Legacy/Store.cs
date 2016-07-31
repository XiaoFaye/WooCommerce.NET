using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace WooCommerceNET.WooCommerce.Legacy
{
    [DataContract]
    public class Store
    {
        public List<WCRoute> GetRoutes(string json)
        {
            json = json.Replace(" ", string.Empty).Replace("\n", string.Empty);

            int startIndex = json.IndexOf("routes");
            int endIndex = json.LastIndexOf("meta");
            string result = json.Substring(startIndex + 8, endIndex - startIndex - 11);

            string[] res = result.Split(new string[] { "\"\\" }, StringSplitOptions.RemoveEmptyEntries);
            
            List<WCRoute> routes = new List<WCRoute>();
            foreach (var r in res)
            {
                if (r.Contains(":{"))
                {
                    string temp = r.TrimEnd(',');
                    WCRoute sr = new WCRoute();
                    sr.Resoure = temp.Substring(0, temp.IndexOf("\":{"));
                    sr.AcceptData = temp.Contains("accepts_data");
                    sr.Method = temp.Substring(temp.IndexOf("supports") + 11, temp.IndexOf("]") - temp.IndexOf("supports") - 12 + 1).Replace("\"", string.Empty).Split(',');
                    if (!sr.Resoure.Contains("<"))
                        sr.Self = temp.Substring(temp.IndexOf("self\":") + 7, temp.IndexOf("\"}", temp.IndexOf("self\":")) - temp.IndexOf("self\":") - 7);
                    routes.Add(sr);
                }
            }

            return routes;
        }

        [DataMember]
        public string name { get; set; }

        [DataMember]
        public string description { get; set; }

        [DataMember]
        public string URL { get; set; }

        [DataMember]
        public string wc_version { get; set; }

        public List<WCRoute> WCRoutes { get; set; }

        [DataMember]
        public StoreMeta meta { get; set; }
    }

    public class WCRoute
    {
        public string Resoure { get; set; }
        public string[] Method { get; set; }
        public bool AcceptData { get; set; }
        public string Self { get; set; }
    }

    public class StoreMeta
    {
        public string timezone { get; set; }

        public string currency { get; set; }

        public string currency_format { get; set; }

        public bool tax_included { get; set; }

        public string weight_unit { get; set; }

        public string dimension_unit { get; set; }

        public bool ssl_enabled { get; set; }

        public bool permalinks_enabled { get; set; }

        public object links { get; set; }
    }
}
