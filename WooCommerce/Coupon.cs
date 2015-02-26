using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WooCommerceNET.WooCommerce
{
    public class Coupon
    {
        public int id { get; set; }

        public string code { get; set; }

        public string type { get; set; }

        public DateTime created_at { get; set; }

        public DateTime updated_at { get; set; }

        public decimal amount { get; set; }

        public bool individual_use { get; set; }

        public List<int> product_ids { get; set; }

        public List<int> exclude_product_ids { get; set; }

        public int? usage_limit { get; set; }

        public int? usage_limit_per_user { get; set; }

        public int limit_usage_to_x_items { get; set; }

        public int usage_count { get; set; }

        public DateTime? expiry_date { get; set; }

        public bool apply_before_tax { get; set; }

        public bool enable_free_shipping { get; set; }

        public List<int> product_category_ids { get; set; }

        public List<int> exclude_product_category_ids { get; set; }

        public bool exclude_sale_items { get; set; }

        public decimal minimum_amount { get; set; }

        public decimal maximum_amount { get; set; }

        public List<string> customer_emails { get; set; }

        public string description { get; set; }
    }
}
