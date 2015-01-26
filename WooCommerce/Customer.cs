using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WooCommerceNET.WooCommerce
{
    public class Customer
    {
        public int id { get; set; }

        public DateTime created_at { get; set; }

        public string email { get; set; }

        public string first_name { get; set; }

        public string last_name { get; set; }

        public string username { get; set; }

        public int? last_order_id { get; set; }

        public DateTime? last_order_date { get; set; }

        public int? orders_count { get; set; }

        public decimal? total_spent { get; set; }

        public string avatar_url { get; set; }

        public Address billing_address { get; set; }

        public Address shipping_address { get; set; }
    }
}
