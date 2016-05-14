using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace WooCommerceNET.WooCommerce
{
    [CollectionDataContract]
    public class WebhookList : List<Webhook>
    {
        [DataMember]
        public List<Webhook> webhooks { get; set; }
    }

    [DataContract]
    public class Webhook
    {
        /// <summary>
        /// Webhook ID (post ID) 
        /// read-only
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public int? id { get; set; }


        /// <summary>
        /// A friendly name for the webhook, defaults to “Webhook created on <date>”
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string name { get; set; }

        /// <summary>
        /// Webhook status, options are active (delivers payload), paused (does not deliver), or disabled (does not deliver due delivery failures). Default is active
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string status { get; set; }

        /// <summary>
        /// Webhook topic, e.g. coupon.updated. See the complete list (http://woothemes.github.io/woocommerce-rest-api-docs/#webhooks)
        /// The topic is a combination resource (e.g. order) and event (e.g. created) and maps to one or more hook names (e.g. woocommerce_checkout_order_processed). Webhooks can be created using the topic name and the appropriate hooks are automatically added.
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string topic { get; set; }

        /// <summary>
        /// Webhook resource, e.g. coupon
        /// read-only
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string resource { get; set; }

        /// <summary>
        /// Webhook event, e.g. updated
        /// read-only
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string @event { get; set; }


        /// <summary>
        /// WooCommerce action names associated with the webhook
        /// read-only
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public List<string> hooks { get; set; }

        /// <summary>
        /// The URL where the webhook payload is delivered       
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string delivery_url { get; set; }

        /// <summary>
        /// Secret key used to generate a hash of the delivered webhook and provided in the request headers. This will default to the current API user’s consumer secret if not provided
        /// write-only
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string secret { get; set; }


        /// <summary>
        /// UTC DateTime when the webhook was created
        /// read-only
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string created_at { get; set; }

        /// <summary>
        /// UTC DateTime when the webhook was last updated
        /// read-only
        /// </summary>
        [DataMember(EmitDefaultValue = false)]

        public string updated_at { get; set; }
                

    }
}
