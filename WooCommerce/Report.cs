using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WooCommerceNET.WooCommerce
{
    public class SalesReport
    {
        public decimal total_sales { get; set; }

        public decimal average_sales { get; set; }

        public int total_orders { get; set; }

        public int total_items { get; set; }

        public decimal total_tax { get; set; }

        public decimal total_shipping { get; set; }

        public decimal total_discount { get; set; }

        public string totals_grouped_by { get; set; }

        public object totals { get; set; }

        public int total_customers { get; set; }
    }
}
