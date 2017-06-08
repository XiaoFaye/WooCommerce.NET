using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using WooCommerceNET.Base;

namespace WooCommerceNET.WooCommerce.v2
{
    public class CustomerBatch : BatchObject<Customer> { }

    [DataContract]
    public class Customer : JsonObject
    {
        public static string Endpoint { get { return "customers"; } }

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
        /// The date the order was created, as GMT. 
        /// read-only
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public DateTime? date_created_gmt { get; set; }

        /// <summary>
        /// The date the customer was last modified, in the site’s timezone. 
        /// read-only
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public DateTime? date_modified { get; set; }

        /// <summary>
        /// The date the customer was last modified, as GMT. 
        /// read-only
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public DateTime? date_modified_gmt { get; set; }

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
        /// Customer role. 
        /// read-only
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string role { get; set; }

        /// <summary>
        /// Customer login name.
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string username { get; set; }

        /// <summary>
        /// Customer password. 
        /// write-only
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string password { get; set; }

        /// <summary>
        /// List of billing address data. See Customer - Billing properties
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public CustomerBilling billing { get; set; }

        /// <summary>
        /// List of shipping address data. See Customer - Shipping properties
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public CustomerShipping shipping { get; set; }

        /// <summary>
        /// Is the customer a paying customer? 
        /// read-only
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public bool? is_paying_customer { get; set; }

        /// <summary>
        /// Quantity of orders made by the customer. 
        /// read-only
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public int? orders_count { get; set; }

        [DataMember(EmitDefaultValue = false, Name = "total_spent")]
        protected object total_spentValue { get; set; }
        /// <summary>
        /// Total amount spent. 
        /// read-only
        /// </summary>
        public decimal? total_spent { get; set; }

        /// <summary>
        /// Avatar URL. 
        /// read-only
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string avatar_url { get; set; }

        /// <summary>
        /// Meta data. See Customer - Meta data properties
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public List<CustomerMeta> meta_data { get; set; }
    }

    [DataContract]
    public class CustomerBilling
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
        /// ISO code of the country.
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
    public class CustomerShipping
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
        /// ISO code of the country.
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string country { get; set; }

    }

    [DataContract]
    public class CustomerMeta : WCObject.MetaData
    {

    }

    [DataContract]
    public class CustomerDownloads
    {
        /// <summary>
        /// Download ID (MD5). 
        /// read-only
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string download_id { get; set; }

        /// <summary>
        /// Download file URL. 
        /// read-only
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string download_url { get; set; }

        /// <summary>
        /// Downloadable product ID. 
        /// read-only
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public int? product_id { get; set; }

        /// <summary>
        /// Product name. 
        /// read-only
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string product_name { get; set; }

        /// <summary>
        /// Downloadable file name. 
        /// read-only
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string download_name { get; set; }

        /// <summary>
        /// Order ID. 
        /// read-only
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public int? order_id { get; set; }

        /// <summary>
        /// Order key. 
        /// read-only
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string order_key { get; set; }

        /// <summary>
        /// Number of downloads remaining. 
        /// read-only
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string downloads_remaining { get; set; }

        /// <summary>
        /// The date when download access expires, in the site’s timezone. 
        /// read-only
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string access_expires { get; set; }

        /// <summary>
        /// The date when download access expires, as GMT. 
        /// read-only
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string access_expires_gmt { get; set; }

        /// <summary>
        /// File details. 
        /// read-only
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public CustomerDownloadFile file { get; set; }

    }

    [DataContract]
    public class CustomerDownloadFile
    {
        /// <summary>
        /// File name
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string name { get; set; }

        /// <summary>
        /// File URL
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string file { get; set; }
    }
}
