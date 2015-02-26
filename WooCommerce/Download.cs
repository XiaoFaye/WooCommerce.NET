using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WooCommerceNET.WooCommerce
{
    public class Download
    {
        public string download_url { get; set; }

        public string download_id { get; set; }

        public int product_id { get; set; }

        public string download_name { get; set; }

        public int order_id { get; set; }

        public string order_key { get; set; }

        public string downloads_remaining { get; set; }

        public DownloadFile file { get; set; }
    }

    public class DownloadFile
    {
        public string name { get; set; }

        public string file { get; set; }
    }
}
