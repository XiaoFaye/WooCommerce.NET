using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using WooCommerceNET.Base;

namespace WooCommerceNET.WooCommerce.Legacy
{
    [CollectionDataContract]
    public class CouponList : List<Coupon>
    {
        [DataMember]
        public List<Coupon> coupons { get; set; }
    }

    [DataContract]
    public class Coupon : JsonObject
    {
        /// <summary>
        /// Coupon ID (post ID) 
        /// read-only
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public int? id { get; set; }

        /// <summary>
        /// Coupon code, always lowercase 
        /// mandatory when creating a new coupon.
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string code { get; set; }

        /// <summary>
        /// Coupon type, valid core types are: fixed_cart, percent, fixed_product and percent_product. Default is fixed_cart
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string type { get; set; }

        /// <summary>
        /// UTC DateTime when the coupon was created 
        /// read-only
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public DateTime? created_at { get; set; }

        /// <summary>
        /// UTC DateTime when the coupon was last updated 
        /// read-only
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public DateTime? updated_at { get; set; }

        /// <summary>
        /// The amount of discount
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public decimal? amount { get; set; }

        /// <summary>
        /// Whether coupon can only be used individually
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public bool? individual_use { get; set; }

        /// <summary>
        /// Array of product ID’s the coupon can be used on
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public List<int> product_ids { get; set; }

        /// <summary>
        /// Array of product ID’s the coupon cannot be used on
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public List<int> exclude_product_ids { get; set; }

        /// <summary>
        /// How many times the coupon can be used
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public int? usage_limit { get; set; }

        /// <summary>
        /// How many times the coupon can be user per customer
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public int? usage_limit_per_user { get; set; }

        /// <summary>
        /// Max number of items in the cart the coupon can be applied to
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public int? limit_usage_to_x_items { get; set; }

        /// <summary>
        /// Number of times the coupon has been used already 
        /// read-only
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public int? usage_count { get; set; }

        /// <summary>
        /// UTC DateTime`when the coupon expires
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public DateTime? expiry_date { get; set; }

        /// <summary>
        /// Is the coupon for free shipping
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public bool? enable_free_shipping { get; set; }

        /// <summary>
        /// Array of category ID’s the coupon applies to
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public List<int> product_category_ids { get; set; }

        /// <summary>
        /// Array of category ID’s the coupon does not apply to
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public List<int> exclude_product_category_ids { get; set; }

        /// <summary>
        /// Exclude sale items from the coupon
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public bool? exclude_sale_items { get; set; }

        /// <summary>
        /// Minimum order amount that needs to be in the cart before coupon applies
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public decimal? minimum_amount { get; set; }

        /// <summary>
        /// Maximum order amount allowed when using the coupon
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public decimal? maximum_amount { get; set; }

        /// <summary>
        /// Array of email addresses that can use this coupon
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public List<string> customer_emails { get; set; }

        /// <summary>
        /// Coupon description
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string description { get; set; }
    }
}
