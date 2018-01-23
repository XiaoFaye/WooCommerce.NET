using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using WooCommerceNET.Base;

namespace WooCommerceNET.WooCommerce.v1
{
    [KnownType(typeof(CouponBatch))]
    public class CouponBatch : BatchObject<Coupon> { }
    
    public class Coupon : JsonObject
    {
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
        [DataMember(EmitDefaultValue = false, IsRequired = true)]
        public string code { get; set; }

        /// <summary>
        /// The date the coupon was created, in the site’s timezone. 
        /// read-only
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public DateTime? date_created { get; set; }

        /// <summary>
        /// The date the coupon was last modified, in the site’s timezone. 
        /// read-only
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public DateTime? date_modified { get; set; }

        /// <summary>
        /// Coupon description.
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string description { get; set; }

        /// <summary>
        /// Determines the type of discount that will be applied. Options: fixed_cart, percent, fixed_product and percent_product. Default: fixed_cart.
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string discount_type { get; set; }

        /// <summary>
        /// The amount of discount.
        /// </summary>
        [DataMember(EmitDefaultValue = false, Name = "amount")]
        protected object amountValue { get; set; }

        public decimal? amount { get; set; }

        /// <summary>
        /// UTC DateTime when the coupon expires.
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public DateTime? expiry_date { get; set; }

        /// <summary>
        /// Number of times the coupon has been used already. 
        /// read-only
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public int? usage_count { get; set; }

        /// <summary>
        /// Whether coupon can only be used individually.
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public bool? individual_use { get; set; }

        /// <summary>
        /// List of product ID’s the coupon can be used on.
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public List<int> product_ids { get; set; }

        /// <summary>
        /// List of product ID’s the coupon cannot be used on.
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public List<int> exclude_product_ids { get; set; }

        /// <summary>
        /// How many times the coupon can be used.
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
        /// Define if can be applied for free shipping.
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public bool? free_shipping { get; set; }

        /// <summary>
        /// List of category ID’s the coupon applies to.
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public List<int> product_categories { get; set; }

        /// <summary>
        /// List of category ID’s the coupon does not apply to.
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public List<int> excluded_product_categories { get; set; }

        /// <summary>
        /// Define if should not apply when have sale items.
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public bool? exclude_sale_items { get; set; }

        [DataMember(EmitDefaultValue = false, Name = "minimum_amount")]
        protected object minimum_amountValue { get; set; }
        /// <summary>
        /// Minimum order amount that needs to be in the cart before coupon applies.
        /// </summary>
        public decimal? minimum_amount { get; set; }

        [DataMember(EmitDefaultValue = false, Name = "maximum_amount")]
        protected object maximum_amountValue { get; set; }
        /// <summary>
        /// Maximum order amount allowed when using the coupon.
        /// </summary>
        public decimal? maximum_amount { get; set; }

        /// <summary>
        /// List of email addresses that can use this coupon.
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public List<string> email_restrictions { get; set; }

        /// <summary>
        /// List of user IDs who have used the coupon. 
        /// read-only
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public List<string> used_by { get; set; }
    }
}
