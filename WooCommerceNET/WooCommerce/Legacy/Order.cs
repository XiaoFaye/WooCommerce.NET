using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace WooCommerceNET.WooCommerce.Legacy
{
    [CollectionDataContract]
    public class OrderList : List<Order>
    {
        [DataMember]
        public List<Order> orders { get; set; }
    }

    [DataContract]
    public class Order
    {
        /// <summary>
        /// Order ID (post ID) 
        /// read-only
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public int? id { get; set; }

        /// <summary>
        /// Order number 
        /// read-only
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public int? order_number { get; set; }

        /// <summary>
        /// UTC DateTime when the order was created 
        /// read-only
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public DateTime? created_at { get; set; }

        /// <summary>
        /// UTC DateTime when the order was last updated 
        /// read-only
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public DateTime? updated_at { get; set; }

        /// <summary>
        /// UTC DateTime when the order was last completed 
        /// read-only
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public DateTime? completed_at { get; set; }

        /// <summary>
        /// Order status. By default are available the status: pending, processing, on-hold, completed, cancelled, refunded and failed. See View List of Order Statuses
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string status { get; set; }

        /// <summary>
        /// Currency in ISO format, e.g USD
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string currency { get; set; }

        /// <summary>
        /// Order total 
        /// read-only
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public decimal? total { get; set; }

        /// <summary>
        /// Order subtotal 
        /// read-only
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public decimal? subtotal { get; set; }

        /// <summary>
        /// Total of order items 
        /// read-only
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public int? total_line_items_quantity { get; set; }

        /// <summary>
        /// Order tax total 
        /// read-only
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public decimal? total_tax { get; set; }

        /// <summary>
        /// Order shipping total 
        /// read-only
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public decimal? total_shipping { get; set; }

        /// <summary>
        /// Order cart tax 
        /// read-only
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public decimal? cart_tax { get; set; }

        /// <summary>
        /// Order shipping tax 
        /// read-only
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public decimal? shipping_tax { get; set; }

        /// <summary>
        /// Order total discount 
        /// read-only
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public decimal? total_discount { get; set; }

        /// <summary>
        /// Text list of the shipping methods used in the order 
        /// read-only
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string shipping_methods { get; set; }

        /// <summary>
        /// List of payment details. See Payment Details Properties
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public PaymentDetail payment_details { get; set; }

        /// <summary>
        /// List of customer billing address. See Customer Billing Address Properties
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public BillingAddress billing_address { get; set; }

        /// <summary>
        /// List of customer shipping address. See Customer Shipping Address Properties
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public ShippingAddress shipping_address { get; set; }

        /// <summary>
        /// Customer order notes
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string note { get; set; }

        /// <summary>
        /// Customer IP address 
        /// read-only
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string customer_ip { get; set; }

        /// <summary>
        /// Customer User-Agent 
        /// read-only
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string customer_user_agent { get; set; }

        /// <summary>
        /// Customer ID (user ID) 
        /// required when creating a new order
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public int? customer_id { get; set; }

        /// <summary>
        /// URL to view the order in frontend 
        /// read-only
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string view_order_url { get; set; }

        /// <summary>
        /// List of order line items. See Line Items Properties
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public LineItemList line_items { get; set; }

        /// <summary>
        /// List of shipping line items. See Shipping Lines Properties
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public ShippingLineList shipping_lines { get; set; }

        /// <summary>
        /// List of tax line items. See Tax Lines Properties 
        /// read-only
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public TaxLineList tax_lines { get; set; }

        /// <summary>
        /// List of fee line items. See Fee Lines Properites
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public FeeLineList fee_lines { get; set; }

        /// <summary>
        /// List of cupon line items. See Coupon Lines Properties
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public CouponLineList coupon_lines { get; set; }

        /// <summary>
        /// Customer data. See Customer Properties
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public Customer customer { get; set; }

        /// <summary>
        /// Dictionary of order metadata/custom fields. Undocumented; set parameter filter[meta] to true on GetOrders to include in response.
        /// </summary>
        [DataMember( EmitDefaultValue = false )]
        public IDictionary<string, string> order_meta { get; set; }
    }

    [CollectionDataContract]
    public class PaymentDetailList : List<PaymentDetail>
    {
        [DataMember]
        public List<PaymentDetail> payment_details { get; set; }
    }

    [DataContract]
    public class PaymentDetail
    {
        /// <summary>
        /// Payment method ID 
        /// required
        /// </summary>
        [DataMember(EmitDefaultValue = false, IsRequired = true)]
        public string method_id { get; set; }

        /// <summary>
        /// Payment method title 
        /// required
        /// </summary>
        [DataMember(EmitDefaultValue = false, IsRequired = true)]
        public string method_title { get; set; }

        /// <summary>
        /// Shows/define if the order is paid using this payment method. Use true to complate the payment.
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public bool? paid { get; set; }

        /// <summary>
        /// Transaction ID, an optional field to set the transacion ID when complate one payment (to set this you need set the paid as true too)
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string transaction_id { get; set; }
    }


    [CollectionDataContract]
    public class LineItemList : List<LineItem>
    {
        [DataMember]
        public List<LineItem> line_items { get; set; }
    }

    [DataContract]
    public class LineItem
    {
        /// <summary>
        /// Line item ID 
        /// read-only
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public int? id { get; set; }

        /// <summary>
        /// Line item subtotal
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public decimal? subtotal { get; set; }

        /// <summary>
        /// Line item tax subtotal
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public decimal? subtotal_tax { get; set; }

        /// <summary>
        /// Line item total
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public decimal? total { get; set; }

        /// <summary>
        /// Line item tax total
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public decimal? total_tax { get; set; }

        /// <summary>
        /// Product price 
        /// read-only
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public decimal? price { get; set; }

        /// <summary>
        /// Quantity
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public int? quantity { get; set; }

        /// <summary>
        /// Product tax class 
        /// read-only
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string tax_class { get; set; }

        /// <summary>
        /// Product name 
        /// read-only
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string name { get; set; }

        /// <summary>
        /// Product ID 
        /// required when creating new order
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public int? product_id { get; set; }

        /// <summary>
        /// Product SKU 
        /// read-only
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string sku { get; set; }

        /// <summary>
        /// List of product meta items. See Products Meta Items Properties
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public MetaItemList meta { get; set; }

        /// <summary>
        /// List of product variation attributes. e.g: "variation": {"pa_color": "Black", "pa_size": "XGG"} (Use pa_ prefix when is a product attribute) 
        /// write-only
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public VariationList variations { get; set; }
    }


    [CollectionDataContract]
    public class MetaItemList : List<MetaItem>
    {
        [DataMember]
        public List<MetaItem> metas { get; set; }
    }

    [DataContract]
    public class MetaItem
    {
        /// <summary>
        /// Meta item key
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string key { get; set; }

        /// <summary>
        /// Meta item label
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string label { get; set; }

        /// <summary>
        /// Meta item value
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string value { get; set; }
    }


    [CollectionDataContract]
    public class ShippingLineList : List<ShippingLine>
    {
        [DataMember]
        public List<ShippingLine> shipping_lines { get; set; }
    }

    [DataContract]
    public class ShippingLine
    {
        /// <summary>
        /// Shipping line ID 
        /// read-only
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public int? id { get; set; }

        /// <summary>
        /// Shipping method ID 
        /// required when creating a new shipping line in orders
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string method_id { get; set; }

        /// <summary>
        /// Shipping method title 
        /// required when creating a new shipping line in orders
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string method_title { get; set; }

        /// <summary>
        /// Total amount
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public decimal? total { get; set; }
    }


    [CollectionDataContract]
    public class TaxLineList : List<TaxLine>
    {
        [DataMember]
        public List<TaxLine> tax_lines { get; set; }
    }

    public class TaxLine
    {
        /// <summary>
        /// Tax rate line ID 
        /// read-only
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public int? id { get; set; }

        /// <summary>
        /// Tax rate ID 
        /// read-only
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public int? rate_id { get; set; }

        /// <summary>
        /// Tax rate code 
        /// read-only
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string code { get; set; }

        /// <summary>
        /// Tax rate title/name 
        /// read-only
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string title { get; set; }

        /// <summary>
        /// Tax rate total 
        /// read-only
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public decimal? total { get; set; }

        /// <summary>
        /// Shows if is or not a compound rate. Compound tax rates are applied on top of other tax rates. 
        /// read-only
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public bool? compound { get; set; }
    }


    [CollectionDataContract]
    public class FeeLineList : List<FeeLine>
    {
        [DataMember]
        public List<FeeLine> fee_lines { get; set; }
    }

    [DataContract]
    public class FeeLine
    {
        /// <summary>
        /// Fee line ID 
        /// read-only
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public int? id { get; set; }

        /// <summary>
        /// Shipping method title 
        /// required when creating a new fee.
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string title { get; set; }

        /// <summary>
        /// Shows/define if the fee is taxable 
        /// write-only
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public bool? taxable { get; set; }

        /// <summary>
        /// Tax class, requered in write-mode if the fee is taxable
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string tax_class { get; set; }

        /// <summary>
        /// Total amount
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public decimal? total { get; set; }

        /// <summary>
        /// Tax total
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public decimal? total_tax { get; set; }
    }


    [CollectionDataContract]
    public class CouponLineList : List<CouponLine>
    {
        [DataMember]
        public List<CouponLine> coupon_lines { get; set; }
    }

    [DataContract]
    public class CouponLine
    {
        /// <summary>
        /// Coupon line ID 
        /// read-only
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public int? id { get; set; }

        /// <summary>
        /// Coupon code 
        /// required when creating a new order.
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string code { get; set; }

        /// <summary>
        /// Total amount 
        /// required when creating a new order.
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public decimal? amount { get; set; }
    }


    [CollectionDataContract]
    public class OrderNoteList : List<Order_Note>
    {
        [DataMember]
        public List<Order_Note> order_notes { get; set; }
    }

    [DataContract]
    public class Order_Note
    {
        /// <summary>
        /// Order note ID 
        /// read-only
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public int? id { get; set; }

        /// <summary>
        /// UTC DateTime when the order note was created 
        /// read-only
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public DateTime? created_at { get; set; }

        /// <summary>
        /// Order note 
        /// required when creating a new note
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string note { get; set; }

        /// <summary>
        /// Shows/define if the note is only for reference or for the customer (the user will be notified). Default is false
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public bool? customer_note { get; set; }
    }


    [CollectionDataContract]
    public class OrderRefundList : List<Order_Refund>
    {
        [DataMember]
        public List<Order_Refund> order_refunds { get; set; }
    }

    [DataContract]
    public class Order_Refund
    {
        /// <summary>
        /// Order note ID 
        /// read-only
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public int? id { get; set; }

        /// <summary>
        /// UTC DateTime when the order refund was created 
        /// read-only
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public DateTime? created_at { get; set; }

        /// <summary>
        /// Refund amount 
        /// required when creating a new refund.
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public decimal? amount { get; set; }

        /// <summary>
        /// Reason for refund
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string reason { get; set; }

        /// <summary>
        /// List of order items to refund. See Line Items Properties
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public LineItemList line_items { get; set; }
    }
}
