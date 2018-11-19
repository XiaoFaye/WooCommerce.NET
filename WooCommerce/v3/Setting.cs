using System.Collections.Generic;
using System.Runtime.Serialization;
using WooCommerceNET.Base;

namespace WooCommerceNET.WooCommerce.v3
{
    [DataContract]
    public class Setting : v2.Setting { }

    public class SettingOptionBatch : BatchObject<SettingOption> { }

    [DataContract]
    public class SettingOption
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
        /// Setting value.
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public object value { get; set; }

        /// <summary>
        /// Default value for the setting. 
        /// read-only
        /// </summary>
        [DataMember(EmitDefaultValue = false, Name = "default")]
        public object _default { get; set; }

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

        /// <summary>
        /// Type of setting. Options: text, email, number, color, password, textarea, select, multiselect, radio, image_width and checkbox. 
        /// read-only
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string type { get; set; }

        /// <summary>
        /// Array of options (key value pairs) for inputs such as select, multiselect, and radio buttons. 
        /// read-only
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public Dictionary<string, string> options { get; set; }

        /// <summary>
        /// An identifier for the group this setting belongs to.
        /// read-only
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string group_id { get; set; }
    }
}
