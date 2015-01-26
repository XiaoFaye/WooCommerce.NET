using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WooCommerceNET.WooCommerce
{
    public class Store
    {
        public string name { get; set; }

        public string description { get; set; }

        public string URL { get; set; }

        public string wc_version { get; set; }

        public object routes { get; set; }

        public StoreMeta meta { get; set; }
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
