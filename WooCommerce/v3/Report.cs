using System.Collections.Generic;
using System.Runtime.Serialization;

namespace WooCommerceNET.WooCommerce.v3
{
    [DataContract]
    public class Report : v2.Report { }

    [DataContract]
    public class SalesReport : v2.SalesReport { }

    [DataContract]
    public class TopSellersReport : v2.TopSellersReport { }

    [DataContract]
    public class CouponsTotals
    {
        /// <summary>
        /// An alphanumeric identifier for the resource.
        /// read-only
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string slug { get; set; }

        /// <summary>
        /// Coupon type name.
        /// read-only
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string name { get; set; }

        /// <summary>
        /// Amount of coupons.
        /// read-only
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string total { get; set; }
    }

    [DataContract]
    public class CustomersTotals
    {
        /// <summary>
        /// An alphanumeric identifier for the resource.
        /// read-only
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string slug { get; set; }

        /// <summary>
        /// Customer type name.
        /// read-only
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string name { get; set; }

        /// <summary>
        /// Amount of customers.
        /// read-only
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string total { get; set; }
    }

    [DataContract]
    public class OrdersTotals
    {
        /// <summary>
        /// An alphanumeric identifier for the resource.
        /// read-only
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string slug { get; set; }

        /// <summary>
        /// Orders type name.
        /// read-only
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string name { get; set; }

        /// <summary>
        /// Amount of orders.
        /// read-only
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string total { get; set; }
    }

    [DataContract]
    public class ProductsTotals
    {
        /// <summary>
        /// An alphanumeric identifier for the resource.
        /// read-only
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string slug { get; set; }

        /// <summary>
        /// Product type name.
        /// read-only
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string name { get; set; }

        /// <summary>
        /// Amount of products.
        /// read-only
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string total { get; set; }
    }

    [DataContract]
    public class ReviewsTotals
    {
        /// <summary>
        /// An alphanumeric identifier for the resource.
        /// read-only
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string slug { get; set; }

        /// <summary>
        /// Review type name.
        /// read-only
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string name { get; set; }

        /// <summary>
        /// Amount of reviews.
        /// read-only
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string total { get; set; }
    }
}
