using System;
using System.Runtime.Serialization;
using WooCommerceNET.Base;

namespace WooCommerceNET.WooCommerce.v1
{
    [KnownType(typeof(CustomerBatch))]
    public class CustomerBatch : BatchObject<Customer> { }

    [DataContract]
    public class Customer
    {
        /// <summary>
        /// Unique identifier for the resource. 
        /// read-only
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public int? id { get; set; }

        /// <summary>
        /// The date the customer was created, in the site’s timezone. 
        /// read-only
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public DateTime? date_created { get; set; }

        /// <summary>
        /// The date the customer was last modified, in the site’s timezone. 
        /// read-only
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public DateTime? date_modified { get; set; }

        /// <summary>
        /// The email address for the customer. 
        /// mandatory
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string email { get; set; }

        /// <summary>
        /// Customer first name.
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string first_name { get; set; }

        /// <summary>
        /// Customer last name.
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string last_name { get; set; }

        /// <summary>
        /// Customer login name. Can be generated automatically from the customer’s email addrees if the option woocommerce_registration_generate_username is equal to yes cannot be changed 
        /// cannot be changed</i> <i class="label label-info">maybe mandatory
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string username { get; set; }

        /// <summary>
        /// Customer password. Can be generated automatically with wp_generate_password() if the “Automatically generate customer password” option is enabled, check the index meta for generate_password write-only 
        /// write-only</i> <i class="label label-info">maybe mandatory
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string password { get; set; }

        /// <summary>
        /// Last order data. See Customer Last Order properties. 
        /// read-only
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public LastOrder last_order { get; set; }

        /// <summary>
        /// Quantity of orders made by the customer. 
        /// read-only
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public int? orders_count { get; set; }

        /// <summary>
        /// Total amount spent. 
        /// read-only
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public decimal? total_spent { get; set; }

        /// <summary>
        /// Avatar URL.
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string avatar_url { get; set; }

        /// <summary>
        /// List of billing address data. See Billing Address properties.
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public BillingAddress billing { get; set; }

        /// <summary>
        /// List of shipping address data. See Shipping Address properties.
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public ShippingAddress shipping { get; set; }
    }

    [DataContract]
    public class LastOrder
    {
        /// <summary>
        /// Last order ID.  
        /// read-only
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public int? id { get; set; }

        /// <summary>
        /// UTC DateTime of the customer last order.
        /// read-only
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public DateTime? date { get; set; }
    }
}
