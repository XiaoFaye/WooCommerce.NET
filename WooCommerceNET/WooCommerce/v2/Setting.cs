using System.Collections.Generic;
using System.Runtime.Serialization;
using WooCommerceNET.Base;

namespace WooCommerceNET.WooCommerce.v2
{
    [DataContract]
    public class Setting
    {
        public static string Endpoint { get { return "settings"; } }

        /// <summary>
        /// A unique identifier that can be used to link settings together. 
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
        /// ID of parent grouping. 
        /// read-only
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string parent_id { get; set; }

        /// <summary>
        /// IDs for settings sub groups. 
        /// read-only
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public List<string> sub_groups { get; set; }

    }

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

    }
}
