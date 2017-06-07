using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using WooCommerceNET.Base;

namespace WooCommerceNET.WooCommerce.v2
{
    public class CouponBatch : BatchObject<Coupon> { }

    [DataContract]
    public class Coupon : JsonObject
    {
        public static string Endpoint { get { return "coupons"; } }

        /// <summary>
        /// Unique identifier for the object. 
        /// read-only
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public int? id { get; set; }

        /// <summary>
        /// Coupon code. 
        /// mandatory
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string code { get; set; }

        [DataMember(EmitDefaultValue = false, Name = "amount")]
        protected object amountValue { get; set; }
        /// <summary>
        /// The amount of discount. Should always be numeric, even if setting a percentage.
        /// </summary>
        public decimal? amount { get; set; }

        /// <summary>
        /// The date the coupon was created, in the site’s timezone. 
        /// read-only
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public DateTime? date_created { get; set; }

        /// <summary>
        /// The date the coupon was created, as GMT. 
        /// read-only
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public DateTime? date_created_gmt { get; set; }

        /// <summary>
        /// The date the coupon was last modified, in the site’s timezone. 
        /// read-only
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public DateTime? date_modified { get; set; }

        /// <summary>
        /// The date the coupon was last modified, as GMT. 
        /// read-only
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public DateTime? date_modified_gmt { get; set; }

        /// <summary>
        /// Determines the type of discount that will be applied. Options: percent, fixed_cart and fixed_product. Default is fixed_cart.
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string discount_type { get; set; }

        /// <summary>
        /// Coupon description.
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string description { get; set; }

        /// <summary>
        /// The date the coupon expires, in the site’s timezone.
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public DateTime? date_expires { get; set; }

        /// <summary>
        /// The date the coupon expires, as GMT.
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public DateTime? date_expires_gmt { get; set; }

        /// <summary>
        /// Number of times the coupon has been used already. 
        /// read-only
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public int? usage_count { get; set; }

        /// <summary>
        /// If true, the coupon can only be used individually. Other applied coupons will be removed from the cart. Default is false.
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public bool? individual_use { get; set; }

        /// <summary>
        /// List of product IDs the coupon can be used on.
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public List<int> product_ids { get; set; }

        /// <summary>
        /// List of product IDs the coupon cannot be used on.
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public List<int> excluded_product_ids { get; set; }

        /// <summary>
        /// How many times the coupon can be used in total.
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public int? usage_limit { get; set; }

        /// <summary>
        /// How many times the coupon can be used per customer.
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public int? usage_limit_per_user { get; set; }

        /// <summary>
        /// Max number of items in the cart the coupon can be applied to.
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public int? limit_usage_to_x_items { get; set; }

        /// <summary>
        /// If true and if the free shipping method requires a coupon, this coupon will enable free shipping. Default is false.
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public bool? free_shipping { get; set; }

        /// <summary>
        /// List of category IDs the coupon applies to.
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public List<int> product_categories { get; set; }

        /// <summary>
        /// List of category IDs the coupon does not apply to.
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public List<int> excluded_product_categories { get; set; }

        /// <summary>
        /// If true, this coupon will not be applied to items that have sale prices. Default is false.
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public bool? exclude_sale_items { get; set; }

        /// <summary>
        /// Minimum order amount that needs to be in the cart before coupon applies.
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string minimum_amount { get; set; }

        /// <summary>
        /// Maximum order amount allowed when using the coupon.
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string maximum_amount { get; set; }

        /// <summary>
        /// List of email addresses that can use this coupon.
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public List<string> email_restrictions { get; set; }

        /// <summary>
        /// List of user IDs (or guest email addresses) that have used the coupon. 
        /// read-only
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public List<object> used_by { get; set; }

        /// <summary>
        /// Meta data. See Coupon - Meta data properties
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public List<CouponMeta> meta_data { get; set; }
    }

    [DataContract]
    public class CouponMeta : WCObject.MetaData
    {

    }
}
