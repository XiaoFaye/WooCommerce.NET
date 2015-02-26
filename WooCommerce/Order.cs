using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WooCommerceNET.WooCommerce
{
    public class Order
    {
        public int id { get; set; }

        public string order_number { get; set; }

        public DateTime created_at { get; set; }

        public DateTime updated_at { get; set; }

        public DateTime completed_at { get; set; }

        public string status { get; set; }

        public string currency { get; set; }

        public decimal total { get; set; }

        public decimal subtotal { get; set; }

        public int total_line_items_quantity { get; set; }

        public decimal total_tax { get; set; }

        public decimal total_shipping { get; set; }

        public decimal cart_tax { get; set; }

        public decimal shipping_tax { get; set; }

        public decimal total_discount { get; set; }

        public decimal cart_discount { get; set; }

        public string shipping_methods { get; set; }

        public PaymentDetail payment_details { get; set; }

        public Address billing_address { get; set; }

        public Address shipping_address { get; set; }

        public string note { get; set; }

        public string customer_ip { get; set; }

        public string customer_user_agent { get; set; }

        public int customer_id { get; set; }

        public string view_order_url { get; set; }

        public List<OrderItemLine> line_items { get; set; }

        public List<OrderShippingLine> shipping_lines { get; set; }

        public object tax_lines { get; set; }

        public List<OrderFeeLine> fee_lines { get; set; }

        public object coupon_lines { get; set; }

        public Customer customer { get; set; }
    }

    public class PaymentDetail
    {
        public string method_id { get; set; }

        public string method_title { get; set; }

        public bool paid { get; set; }
    }

    public class OrderItemLine
    {
        public int id { get; set; }

        public decimal subtotal { get; set; }

        public decimal subtotal_tax { get; set; }

        public decimal total { get; set; }

        public decimal total_tax { get; set; }

        public decimal price { get; set; }

        public int quantity { get; set; }

        public string tax_class { get; set; }

        public string name { get; set; }

        public int product_id { get; set; }

        public string sku { get; set; }

        public object meta { get; set; }
    }

    public class OrderShippingLine
    {
        public int id { get; set; }

        public string method_id { get; set; }

        public string method_title { get; set; }

        public decimal total { get; set; }
    }

    public class OrderTaxLine
    {

    }

    public class OrderFeeLine
    {
        public int id { get; set; }

        public string title { get; set; }

        public string tax_class { get; set; }

        public decimal total { get; set; }

        public decimal total_tax { get; set; }
    }

    public class OrderCouponLine
    {

    }

    public class OrderNote
    {
        public int id { get; set; }

        public DateTime created_at { get; set; }

        public string note { get; set;}

        public bool customer_note { get; set; }
    }

    public class OrderRefund
    {
        public int id { get; set; }

        public DateTime date { get; set; }

        public decimal amount { get; set; }

        public string reason { get; set; }

        public object line_items { get; set; }
    }
}
