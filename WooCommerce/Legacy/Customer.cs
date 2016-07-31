using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace WooCommerceNET.WooCommerce.Legacy
{
    [CollectionDataContract]
    public class CustomerList : List<Customer>
    {
        [DataMember]
        public List<Customer> customers { get; set; }
    }

    [DataContract]
    public class Customer
    {
        /// <summary>
        /// Customer ID (user ID) 
        /// read-only
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public int? id { get; set; }

        /// <summary>
        /// UTC DateTime when the customer was created 
        /// read-only
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public DateTime? created_at { get; set; }

        /// <summary>
        /// Customer email address 
        /// mandatory when creating a new customer.
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string email { get; set; }

        /// <summary>
        /// Customer first name
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string first_name { get; set; }

        /// <summary>
        /// Customer last name
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string last_name { get; set; }

        /// <summary>
        /// Customer username, can be generated automatically from the customer’s email addrees if the option woocommerce_registration_generate_username is equal to yes 
        /// cannot be changed
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string username { get; set; }

        /// <summary>
        /// Customer password, can be generated automatically with wp_generate_password() if the “Automatically generate customer password” option is enabled, check the index meta for generate_password 
        /// write-only
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string password { get; set; }

        /// <summary>
        /// Last order ID 
        /// read-only
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public int? last_order_id { get; set; }

        /// <summary>
        /// UTC DateTime of the customer last order 
        /// read-only
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public DateTime? last_order_date { get; set; }

        /// <summary>
        /// Quantity of orders that the customer have 
        /// read-only
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public int? orders_count { get; set; }

        /// <summary>
        /// Total amount spent 
        /// read-only
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public decimal? total_spent { get; set; }

        /// <summary>
        /// Gravatar URL
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string avatar_url { get; set; }

        /// <summary>
        /// List of Billing Address fields. See Billing Address Properties
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public BillingAddress billing_address { get; set; }

        /// <summary>
        /// List of Shipping Address fields. See Shipping Address Properties
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public ShippingAddress shipping_address { get; set; }
    }

    [CollectionDataContract]
    public class BillingAddressList : List<BillingAddress>
    {
        [DataMember]
        public List<BillingAddress> billing_address { get; set; }
    }

    [DataContract]
    public class BillingAddress
    {
        /// <summary>
        /// First name
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string first_name { get; set; }

        /// <summary>
        /// Last name
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string last_name { get; set; }

        /// <summary>
        /// Company name
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
        /// City name
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string city { get; set; }

        /// <summary>
        /// ISO code or name of the state, province or district
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string state { get; set; }

        /// <summary>
        /// Postal code
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string postcode { get; set; }

        /// <summary>
        /// ISO code of the country
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string country { get; set; }

        /// <summary>
        /// Email address
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string email { get; set; }

        /// <summary>
        /// Phone
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string phone { get; set; }
    }


    [CollectionDataContract]
    public class ShippingAddressList : List<ShippingAddress>
    {
        [DataMember]
        public List<ShippingAddress> shipping_address { get; set; }
    }

    [DataContract]
    public class ShippingAddress
    {
        /// <summary>
        /// First name
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string first_name { get; set; }

        /// <summary>
        /// Last name
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string last_name { get; set; }

        /// <summary>
        /// Company name
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
        /// City name
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string city { get; set; }

        /// <summary>
        /// ISO code or name of the state, province or district
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string state { get; set; }

        /// <summary>
        /// Postal code
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string postcode { get; set; }

        /// <summary>
        /// ISO code of the country
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string country { get; set; }
    }
}
