using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using WooCommerceNET.WooCommerce.v2;

namespace WooCommerceNET.WooCommerce.v3
{
    [DataContract]
    public class OrderRefund : v2.OrderRefund
    {
        /// <summary>
        /// If the payment was refunded via the API.
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public bool? refunded_payment { get; set; }

        /// <summary>
        /// Tax lines data. See Order refund - Tax lines properties
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public List<OrderRefundTaxLine> tax_lines { get; set; }

        /// <summary>
        /// Shipping lines data. See Order refund - Shipping lines properties
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public List<OrderRefundShippingLine> shipping_lines { get; set; }

        /// <summary>
        /// Fee lines data. See Order refund - Fee lines properties
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public List<OrderRefundFeeLine> fee_lines { get; set; }

        /// <summary>
        /// When true, the selected line items are restocked Default is true.
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public bool? api_restock { get; set; }

        /// <summary>
        /// When true, the server computes per-line refund amounts from quantities and validates the request against the order's refund history. Available since WooCommerce 11.1. See Server-computed refunds. Default is false.
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public bool? compute_totals { get; set; }

    }

    [DataContract]
    public class OrderRefundTaxLine
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
    public class OrderRefundShippingLine
    {
        /// <summary>
        /// Item ID. 
        /// read-only
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public ulong? id { get; set; }

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
    public class OrderRefundFeeLine
    {
        /// <summary>
        /// Item ID. 
        /// read-only
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public ulong? id { get; set; }

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
}
