using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace WooCommerceNET.WooCommerce.v2
{
    [DataContract]
    public class OrderRefund
    {
        public static string Endpoint { get { return "refunds"; } }

        /// <summary>
        /// Unique identifier for the resource. 
        /// read-only
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public int? id { get; set; }

        /// <summary>
        /// The date the order refund was created, in the site’s timezone. 
        /// read-only
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public DateTime? date_created { get; set; }

        /// <summary>
        /// The date the order refund was created, as GMT. 
        /// read-only
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public DateTime? date_created_gmt { get; set; }

        /// <summary>
        /// Refund amount.
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public decimal? amount { get; set; }

        /// <summary>
        /// Reason for refund.
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string reason { get; set; }

        /// <summary>
        /// User ID of user who created the refund.
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public int refunded_by { get; set; }

        /// <summary>
        /// Meta data. See Order refund - Meta data properties
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public List<OrderRefundMeta> meta_data { get; set; }

        /// <summary>
        /// Line items data. See Order refund - Line items properties
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public List<OrderRefundItem> line_items { get; set; }

        /// <summary>
        /// When true, the payment gateway API is used to generate the refund. Default is true. 
        /// write-only
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public bool? api_refund { get; set; }

    }

    [DataContract]
    public class OrderRefundMeta : WCObject.MetaData
    {

    }

    [DataContract]
    public class OrderRefundItem
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
        public int tax_class { get; set; }

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

        /// <summary>
        /// Line total (after discounts).
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public decimal? total { get; set; }

        /// <summary>
        /// Line total tax (after discounts). 
        /// read-only
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public decimal? total_tax { get; set; }

        /// <summary>
        /// Line taxes. See Order refund - Taxes properties 
        /// read-only
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public List<object> taxes { get; set; }

        /// <summary>
        /// Meta data. See Order refund - Meta data properties
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public List<OrderRefundMeta> meta_data { get; set; }

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
}
