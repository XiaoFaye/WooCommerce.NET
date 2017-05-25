using System.Runtime.Serialization;

namespace WooCommerceNET.WooCommerce.v2
{
    [DataContract]
    public class TaxRate
    {
        public static string Endpoint { get { return "taxes"; } }

        /// <summary>
        /// Unique identifier for the resource. 
        /// read-only
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public int? id { get; set; }

        /// <summary>
        /// Country ISO 3166 code. See ISO 3166 Codes (Countries) for more details
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string country { get; set; }

        /// <summary>
        /// State code.
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string state { get; set; }

        /// <summary>
        /// Postcode/ZIP.
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string postcode { get; set; }

        /// <summary>
        /// City name.
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string city { get; set; }

        /// <summary>
        /// Tax rate.
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string rate { get; set; }

        /// <summary>
        /// Tax rate name.
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string name { get; set; }

        /// <summary>
        /// Tax priority. Only 1 matching rate per priority will be used. To define multiple tax rates for a single area you need to specify a different priority per rate. Default is 1.
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public int? priority { get; set; }

        /// <summary>
        /// Whether or not this is a compound rate. Compound tax rates are applied on top of other tax rates. Default is false.
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public bool? compound { get; set; }

        /// <summary>
        /// Whether or not this tax rate also gets applied to shipping. Default is true.
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public bool? shipping { get; set; }

        /// <summary>
        /// Indicates the order that will appear in queries.
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public int? order { get; set; }

        /// <summary>
        /// Tax class. Default is standard.
        /// </summary>
        [DataMember(EmitDefaultValue = false, Name = "class")]
        public string _class { get; set; }
    }
}
