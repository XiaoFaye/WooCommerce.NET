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
        /// read-only
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public bool? refunded_payment { get; set; }

        /// <summary>
        /// Tax lines data. See Order refund - Tax lines properties
        /// read-only
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
        /// write-only
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public bool? api_restock { get; set; }

        /// <summary>
        /// When true, the server computes per-line refund amounts from quantities and validates the request against the order's refund history. Available since WooCommerce 11.1. See Server-computed refunds. Default is false.
        /// write-only
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public bool? compute_totals { get; set; }

    }

    [DataContract]
    public class OrderRefundTaxLine : OrderTaxLine { }

    [DataContract]
    public class OrderRefundShippingLine : OrderShippingLine { }

    [DataContract]
    public class OrderRefundFeeLine : OrderFeeLine { }
}
