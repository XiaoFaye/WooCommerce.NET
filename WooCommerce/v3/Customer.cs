using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using WooCommerceNET.Base;

namespace WooCommerceNET.WooCommerce.v3
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
    public class CustomerBilling : v2.CustomerBilling { }

    [DataContract]
    public class CustomerShipping : v2.CustomerShipping { }

    [DataContract]
    public class CustomerMeta : v2.WCObject.MetaData { }

    [DataContract]
    public class CustomerDownloads : v2.CustomerDownloads { }

    [DataContract]
    public class CustomerDownloadFile : v2.CustomerDownloadFile { }
}
