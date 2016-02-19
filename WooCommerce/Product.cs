using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WooCommerceNET.WooCommerce
{
    public class ProductData
    {
        public Product product { get; set; }
    }

    public class Product
    {
        public int id { get; set; }

        public string title { get; set; }

        public string description { get; set; }

        public List<string> categories { get; set; }

        public double? sale_price { get; set; }

        public double? price { get; set; }

        public bool in_stock { get; set; }

        public string short_description { get; set; }

        public double average_rating { get; set; }

        public List<ProductImage> images { get; set; }

        public string cover { get; set; }
    }

    public class ProductReview
    {
        public int id { get; set; }

        public DateTime created_at { get; set; }

        public string review { get; set; }

        public int rating { get; set; }

        public string reviewer_name { get; set; }

        public string reviewer_email { get; set; }

        public bool verified { get; set; }
    }

    public class ProductCategory
    {
        public int id { get; set; }

        public string name { get; set; }

        public string slug { get; set; }

        public int parent { get; set; }

        public string description { get; set; }

        public int count { get; set; }
    }
}
