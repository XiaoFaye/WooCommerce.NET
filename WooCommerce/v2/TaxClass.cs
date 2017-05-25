using System.Runtime.Serialization;

namespace WooCommerceNET.WooCommerce.v2
{
    [DataContract]
    public class TaxClass
    {
        public static string Endpoint { get { return "taxes/classes"; } }

        /// <summary>
        /// Unique identifier for the resource. 
        /// read-only
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string slug { get; set; }

        /// <summary>
        /// Tax class name. 
        /// required
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string name { get; set; }

    }
}
