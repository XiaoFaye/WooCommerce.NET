using System.Collections.Generic;
using System.Runtime.Serialization;

namespace WooCommerceNET.WooCommerce.v2
{
    [DataContract]
    public class ShippingZone
    {
        public static string Endpoint { get { return "shipping/zones"; } }

        /// <summary>
        /// Unique identifier for the resource. 
        /// read-only
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public int? id { get; set; }

        /// <summary>
        /// Shipping zone name. 
        /// mandatory
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string name { get; set; }

        /// <summary>
        /// Shipping zone order.
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public int? order { get; set; }

    }

    [DataContract]
    public class ShippingZoneLocation
    {
        public static string Endpoint { get { return "locations"; } }

        /// <summary>
        /// Shipping zone location code.
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string code { get; set; }

        /// <summary>
        /// Shipping zone location type. Options: postcode, state, country and continent. Default is country.
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string type { get; set; }

    }
    
    [DataContract]
    public class ShippingZoneMethod
    {
        public static string Endpoint { get { return "methods"; } }

        /// <summary>
        /// Shipping method instance ID. 
        /// read-only
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public int? instance_id { get; set; }

        /// <summary>
        /// Shipping method customer facing title. 
        /// read-only
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string title { get; set; }

        /// <summary>
        /// Shipping method sort order.
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public int? order { get; set; }

        /// <summary>
        /// Shipping method enabled status.
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public bool? enabled { get; set; }

        /// <summary>
        /// Shipping method ID. read-only 
        /// read-only</i> <i class="label label-info">mandatory
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string method_id { get; set; }

        /// <summary>
        /// Shipping method title. 
        /// read-only
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string method_title { get; set; }

        /// <summary>
        /// Shipping method description. 
        /// read-only
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string method_description { get; set; }

        /// <summary>
        /// Shipping method settings. See Shipping method - Settings properties
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public Dictionary<string, ShippingZoneMethodSetting> settings { get; set; }

        /// <summary>
        /// Method ID. 
        /// read-only
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string id { get; set; }

        /// <summary>
        /// Shipping method title. 
        /// read-only
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string title2 { get; set; }

        /// <summary>
        /// Shipping method description. 
        /// read-only
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string description { get; set; }

    }
    
    [DataContract]
    public class ShippingZoneMethodSetting
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
