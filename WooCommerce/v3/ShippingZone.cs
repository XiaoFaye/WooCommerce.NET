using System.Collections.Generic;
using System.Runtime.Serialization;

namespace WooCommerceNET.WooCommerce.v3
{
    [DataContract]
    public class ShippingZone : v2.ShippingZone { }

    [DataContract]
    public class ShippingZoneLocation : v2.ShippingZoneLocation { }
    
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
    }

    [DataContract]
    public class ShippingZoneMethodSetting : v2.ShippingZoneMethodSetting { }
}
