using System.Collections.Generic;
using System.Runtime.Serialization;

namespace WooCommerceNET.WooCommerce.v2
{
    [DataContract]
    public class PaymentGateway
    {
        public static string Endpoint { get { return "payment_gateways"; } }

        /// <summary>
        /// Payment gateway ID. 
        /// read-only
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string id { get; set; }

        /// <summary>
        /// Payment gateway title on checkout.
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string title { get; set; }

        /// <summary>
        /// Payment gateway description on checkout.
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string description { get; set; }

        /// <summary>
        /// Payment gateway sort order.
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string order { get; set; }

        /// <summary>
        /// Payment gateway enabled status.
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public bool? enabled { get; set; }

        /// <summary>
        /// Payment gateway method title. 
        /// read-only
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string method_title { get; set; }

        /// <summary>
        /// Payment gateway method description. 
        /// read-only
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string method_description { get; set; }

        /// <summary>
        /// Payment gateway settings. See Payment gateway - Settings properties
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public Dictionary<string, PaymentGatewaySetting> settings { get; set; }

    }

    [DataContract]
    public class PaymentGatewaySetting
    {
        /// <summary>
        /// A unique identifier for the setting. 
        /// read-only
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string id { get; set; }

        /// <summary>
        /// A human readable label for the setting used in interfaces. 
        /// read-only
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string label { get; set; }

        /// <summary>
        /// A human readable description for the setting used in interfaces. 
        /// read-only
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string description { get; set; }

        /// <summary>
        /// Type of setting. Options: text, email, number, color, password, textarea, select, multiselect, radio, image_width and checkbox. 
        /// read-only
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string type { get; set; }

        /// <summary>
        /// Setting value.
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string value { get; set; }

        /// <summary>
        /// Default value for the setting. 
        /// read-only
        /// </summary>
        [DataMember(EmitDefaultValue = false, Name = "default")]
        public string _default { get; set; }

        /// <summary>
        /// Additional help text shown to the user about the setting. 
        /// read-only
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string tip { get; set; }

        /// <summary>
        /// Placeholder text to be displayed in text inputs. 
        /// read-only
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string placeholder { get; set; }

    }
}
