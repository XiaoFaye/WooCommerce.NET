using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using WooCommerceNET.Base;

namespace WooCommerceNET.WooCommerce.v2
{
    public class OrderBatch : BatchObject<Order> { }
    
    [DataContract]
    public class Order : JsonObject
    {
        public static string Endpoint { get { return "orders"; } }

        /// <summary>
        /// Unique identifier for the resource. 
        /// read-only
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public int? id { get; set; }

        /// <summary>
        /// Parent order ID.
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public int? parent_id { get; set; }

        /// <summary>
        /// Order number. 
        /// read-only
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string number { get; set; }

        /// <summary>
        /// Order key. 
        /// read-only
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string order_key { get; set; }

        /// <summary>
        /// Shows where the order was created. 
        /// read-only
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string created_via { get; set; }

        /// <summary>
        /// Version of WooCommerce which last updated the order. 
        /// read-only
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string version { get; set; }

        /// <summary>
        /// Order status. Options: pending, processing, on-hold, completed, cancelled, refunded and failed. Default is pending.
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string status { get; set; }

        /// <summary>
        /// Currency the order was created with, in ISO format. Options: AED, AFN, ALL, AMD, ANG, AOA, ARS, AUD, AWG, AZN, BAM, BBD, BDT, BGN, BHD, BIF, BMD, BND, BOB, BRL, BSD, BTC, BTN, BWP, BYR, BZD, CAD, CDF, CHF, CLP, CNY, COP, CRC, CUC, CUP, CVE, CZK, DJF, DKK, DOP, DZD, EGP, ERN, ETB, EUR, FJD, FKP, GBP, GEL, GGP, GHS, GIP, GMD, GNF, GTQ, GYD, HKD, HNL, HRK, HTG, HUF, IDR, ILS, IMP, INR, IQD, IRR, IRT, ISK, JEP, JMD, JOD, JPY, KES, KGS, KHR, KMF, KPW, KRW, KWD, KYD, KZT, LAK, LBP, LKR, LRD, LSL, LYD, MAD, MDL, MGA, MKD, MMK, MNT, MOP, MRO, MUR, MVR, MWK, MXN, MYR, MZN, NAD, NGN, NIO, NOK, NPR, NZD, OMR, PAB, PEN, PGK, PHP, PKR, PLN, PRB, PYG, QAR, RON, RSD, RUB, RWF, SAR, SBD, SCR, SDG, SEK, SGD, SHP, SLL, SOS, SRD, SSP, STD, SYP, SZL, THB, TJS, TMT, TND, TOP, TRY, TTD, TWD, TZS, UAH, UGX, USD, UYU, UZS, VEF, VND, VUV, WST, XAF, XCD, XOF, XPF, YER, ZAR and ZMW. Default is USD.
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string currency { get; set; }

        /// <summary>
        /// The date the order was created, in the site’s timezone. 
        /// read-only
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public DateTime? date_created { get; set; }

        /// <summary>
        /// The date the order was created, as GMT. 
        /// read-only
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public DateTime? date_created_gmt { get; set; }

        /// <summary>
        /// The date the order was last modified, in the site’s timezone. 
        /// read-only
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public DateTime? date_modified { get; set; }

        /// <summary>
        /// The date the order was last modified, as GMT. 
        /// read-only
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public DateTime? date_modified_gmt { get; set; }

        /// <summary>
        /// Total discount amount for the order. 
        /// read-only
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public decimal? discount_total { get; set; }

        /// <summary>
        /// Total discount tax amount for the order. 
        /// read-only
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public decimal? discount_tax { get; set; }

        /// <summary>
        /// Total shipping amount for the order. 
        /// read-only
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public decimal? shipping_total { get; set; }

        /// <summary>
        /// Total shipping tax amount for the order. 
        /// read-only
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public decimal? shipping_tax { get; set; }

        /// <summary>
        /// Sum of line item taxes only. 
        /// read-only
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public decimal? cart_tax { get; set; }

        [DataMember(EmitDefaultValue = false, Name = "total")]
        protected object totalValue { get; set; }
        /// <summary>
        /// Grand total. 
        /// read-only
        /// </summary>
        public decimal? total { get; set; }

        [DataMember(EmitDefaultValue = false, Name = "total_tax")]
        protected object total_taxValue { get; set; }
        /// <summary>
        /// Sum of all taxes. 
        /// read-only
        /// </summary>
        public decimal? total_tax { get; set; }

        /// <summary>
        /// True the prices included tax during checkout. 
        /// read-only
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public bool? prices_include_tax { get; set; }

        /// <summary>
        /// User ID who owns the order. 0 for guests. Default is 0.
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public int? customer_id { get; set; }

        /// <summary>
        /// Customer’s IP address. 
        /// read-only
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string customer_ip_address { get; set; }

        /// <summary>
        /// User agent of the customer. 
        /// read-only
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string customer_user_agent { get; set; }

        /// <summary>
        /// Note left by customer during checkout.
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string customer_note { get; set; }

        /// <summary>
        /// Billing address. See Order - Billing properties
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public OrderBilling billing { get; set; }

        /// <summary>
        /// Shipping address. See Order - Shipping properties
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public OrderShipping shipping { get; set; }

        /// <summary>
        /// Payment method ID.
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string payment_method { get; set; }

        /// <summary>
        /// Payment method title.
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string payment_method_title { get; set; }

        /// <summary>
        /// Unique transaction ID.
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string transaction_id { get; set; }

        /// <summary>
        /// The date the order was paid, in the site’s timezone. 
        /// read-only
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public DateTime? date_paid { get; set; }

        /// <summary>
        /// The date the order was paid, as GMT. 
        /// read-only
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public DateTime? date_paid_gmt { get; set; }

        /// <summary>
        /// The date the order was completed, in the site’s timezone. 
        /// read-only
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public DateTime? date_completed { get; set; }

        /// <summary>
        /// The date the order was completed, as GMT. 
        /// read-only
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public DateTime? date_completed_gmt { get; set; }

        /// <summary>
        /// MD5 hash of cart items to ensure orders are not modified. 
        /// read-only
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string cart_hash { get; set; }

        /// <summary>
        /// Meta data. See Order - Meta data properties
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public List<OrderMeta> meta_data { get; set; }

        /// <summary>
        /// Line items data. See Order - Line items properties
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public List<OrderLineItem> line_items { get; set; }

        /// <summary>
        /// Tax lines data. See Order - Tax lines properties 
        /// read-only
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public List<OrderTaxLine> tax_lines { get; set; }

        /// <summary>
        /// Shipping lines data. See Order - Shipping lines properties
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public List<OrderShippingLine> shipping_lines { get; set; }

        /// <summary>
        /// Fee lines data. See Order - Fee lines properties
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public List<OrderFeeLine> fee_lines { get; set; }

        /// <summary>
        /// Coupons line data. See Order - Coupon lines properties
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public List<OrderCouponLine> coupon_lines { get; set; }

        /// <summary>
        /// List of refunds. See Order - Refunds properties 
        /// read-only
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public List<OrderRefundLine> refunds { get; set; }

        /// <summary>
        /// Define if the order is paid. It will set the status to processing and reduce stock items. Default is false. 
        /// write-only
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public bool? set_paid { get; set; }
    }

    [DataContract]
    public class OrderBilling
    {
        /// <summary>
        /// First name.
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string first_name { get; set; }

        /// <summary>
        /// Last name.
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string last_name { get; set; }

        /// <summary>
        /// Company name.
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string company { get; set; }

        /// <summary>
        /// Address line 1
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string address_1 { get; set; }

        /// <summary>
        /// Address line 2
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string address_2 { get; set; }

        /// <summary>
        /// City name.
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string city { get; set; }

        /// <summary>
        /// ISO code or name of the state, province or district.
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string state { get; set; }

        /// <summary>
        /// Postal code.
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string postcode { get; set; }

        /// <summary>
        /// Country code in ISO 3166-1 alpha-2 format.
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string country { get; set; }

        /// <summary>
        /// Email address.
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string email { get; set; }

        /// <summary>
        /// Phone number.
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string phone { get; set; }
    }
    
    [DataContract]
    public class OrderShipping
    {
        /// <summary>
        /// First name.
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string first_name { get; set; }

        /// <summary>
        /// Last name.
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string last_name { get; set; }

        /// <summary>
        /// Company name.
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string company { get; set; }

        /// <summary>
        /// Address line 1
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string address_1 { get; set; }

        /// <summary>
        /// Address line 2
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string address_2 { get; set; }

        /// <summary>
        /// City name.
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string city { get; set; }

        /// <summary>
        /// ISO code or name of the state, province or district.
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string state { get; set; }

        /// <summary>
        /// Postal code.
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string postcode { get; set; }

        /// <summary>
        /// Country code in ISO 3166-1 alpha-2 format.
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string country { get; set; }

    }
    
    [DataContract]
    public class OrderMeta : WCObject.MetaData
    {

    }
    
    [DataContract]
    public class OrderLineItem : JsonObject
    {
        /// <summary>
        /// Item ID. 
        /// read-only
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public int? id { get; set; }

        /// <summary>
        /// Product name.
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string name { get; set; }

        /// <summary>
        /// Product ID.
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public int? product_id { get; set; }

        /// <summary>
        /// Variation ID, if applicable.
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public int? variation_id { get; set; }

        /// <summary>
        /// Quantity ordered.
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public int? quantity { get; set; }

        /// <summary>
        /// Tax class of product.
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string tax_class { get; set; }

        /// <summary>
        /// Line subtotal (before discounts).
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public decimal? subtotal { get; set; }

        /// <summary>
        /// Line subtotal tax (before discounts). 
        /// read-only
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public decimal? subtotal_tax { get; set; }

        [DataMember(EmitDefaultValue = false, Name = "total")]
        protected object totalValue { get; set; }
        /// <summary>
        /// Line total (after discounts).
        /// </summary>
        public decimal? total { get; set; }

        [DataMember(EmitDefaultValue = false, Name = "total_tax")]
        protected object total_taxValue { get; set; }
        /// <summary>
        /// Line total tax (after discounts). 
        /// read-only
        /// </summary>
        public decimal? total_tax { get; set; }

        /// <summary>
        /// Line taxes. See Order - Taxes properties 
        /// read-only
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public List<TaxItem> taxes { get; set; }

        /// <summary>
        /// Meta data. See Order - Meta data properties
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public List<OrderMeta> meta_data { get; set; }

        /// <summary>
        /// Product SKU. 
        /// read-only
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string sku { get; set; }

        /// <summary>
        /// Product price. 
        /// read-only
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public decimal? price { get; set; }

    }
    
    [DataContract]
    public class OrderTaxLine
    {
        /// <summary>
        /// Item ID. 
        /// read-only
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string id { get; set; }

        /// <summary>
        /// Tax rate code. 
        /// read-only
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string rate_code { get; set; }

        /// <summary>
        /// Tax rate ID. 
        /// read-only
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string rate_id { get; set; }

        /// <summary>
        /// Tax rate label. 
        /// read-only
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string label { get; set; }

        /// <summary>
        /// Show if is a compound tax rate. 
        /// read-only
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public bool? compound { get; set; }

        /// <summary>
        /// Tax total (not including shipping taxes). 
        /// read-only
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public decimal? tax_total { get; set; }

        /// <summary>
        /// Shipping tax total. 
        /// read-only
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public decimal? shipping_tax_total { get; set; }

        /// <summary>
        /// Meta data. See Order - Meta data properties
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public List<OrderMeta> meta_data { get; set; }
    }
    
    [DataContract]
    public class TaxItem : JsonObject
    {
        /// <summary>
        /// tax item id
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public int? id { get; set; }

        /// <summary>
        /// tax item total
        /// </summary>
        [DataMember(EmitDefaultValue = false, Name = "total")]
        protected object totalValue { get; set; }
        public decimal? total { get; set; }

        /// <summary>
        /// tax item subtotal
        /// </summary>
        [DataMember(EmitDefaultValue = false, Name = "subtotal")]
        protected object subtotalValue { get; set; }
        public decimal? subtotal { get; set; }
    }

    [DataContract]
    public class OrderShippingLine : JsonObject
    {
        /// <summary>
        /// Item ID. 
        /// read-only
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public int? id { get; set; }

        /// <summary>
        /// Shipping method name.
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string method_title { get; set; }

        /// <summary>
        /// Shipping method ID.
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string method_id { get; set; }

        [DataMember(EmitDefaultValue = false, Name = "total")]
        protected object totalValue { get; set; }
        /// <summary>
        /// Line total (after discounts).
        /// </summary>
        public decimal? total { get; set; }

        [DataMember(EmitDefaultValue = false, Name = "total_tax")]
        protected object total_taxValue { get; set; }
        /// <summary>
        /// Line total tax (after discounts). 
        /// read-only
        /// </summary>
        public decimal? total_tax { get; set; }

        /// <summary>
        /// Line taxes. See Order - Taxes properties 
        /// read-only
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public List<TaxItem> taxes { get; set; }

        /// <summary>
        /// Meta data. See Order - Meta data properties
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public List<OrderMeta> meta_data { get; set; }

    }
    
    [DataContract]
    public class OrderFeeLine : JsonObject
    {
        /// <summary>
        /// Item ID. 
        /// read-only
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public int? id { get; set; }

        /// <summary>
        /// Fee name.
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string name { get; set; }

        /// <summary>
        /// Tax class of fee.
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string tax_class { get; set; }

        /// <summary>
        /// Tax status of fee. Options: taxable and none.
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string tax_status { get; set; }

        [DataMember(EmitDefaultValue = false, Name = "total")]
        protected object totalValue { get; set; }
        /// <summary>
        /// Line total (after discounts).
        /// </summary>
        public decimal? total { get; set; }

        /// <summary>
        /// Line total tax (after discounts). 
        /// read-only
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public decimal? total_tax { get; set; }

        /// <summary>
        /// Line taxes. See Order - Taxes properties 
        /// read-only
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public List<TaxItem> taxes { get; set; }

        /// <summary>
        /// Meta data. See Order - Meta data properties
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public List<OrderMeta> meta_data { get; set; }
    }
    
    [DataContract]
    public class OrderCouponLine
    {
        /// <summary>
        /// Item ID. 
        /// read-only
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public int? id { get; set; }

        /// <summary>
        /// Coupon code.
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string code { get; set; }

        /// <summary>
        /// Discount total.
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public decimal? discount { get; set; }

        /// <summary>
        /// Discount total tax. 
        /// read-only
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public decimal? discount_tax { get; set; }

        /// <summary>
        /// Meta data. See Order - Meta data properties
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public List<OrderMeta> meta_data { get; set; }

    }
    
    [DataContract]
    public class OrderRefundLine : JsonObject
    {
        /// <summary>
        /// Refund ID. 
        /// read-only
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public int? id { get; set; }

        /// <summary>
        /// Refund reason. 
        /// read-only
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string reason { get; set; }

        [DataMember(EmitDefaultValue = false, Name = "total")]
        protected object totalValue { get; set; }
        /// <summary>
        /// Refund total. 
        /// read-only
        /// </summary>
        public decimal? total { get; set; }

    }
}
