using System;
using System.Runtime.Serialization;

namespace WooCommerceNET.WooCommerce.v3
{
    [DataContract]
    public class OrderNote : v2.OrderNote 
    {
        /// <summary>
        /// Order note author.
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string author { get; set; }

        /// <summary>
        /// If true, this note will be attributed to the current user. If false, the note will be attributed to the system. Default is false.
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public bool added_by_user { get; set; }
    }
}
