using System;
using System.Runtime.Serialization;

namespace WooCommerceNET.WooCommerce.v2
{
    [DataContract]
    public class OrderNote
    {
        public static string Endpoint { get { return "notes"; } }

        /// <summary>
        /// Unique identifier for the resource. 
        /// read-only
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public int? id { get; set; }

        /// <summary>
        /// The date the order note was created, in the site’s timezone. 
        /// read-only
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public DateTime? date_created { get; set; }

        /// <summary>
        /// The date the order note was created, as GMT. 
        /// read-only
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public DateTime? date_created_gmt { get; set; }

        /// <summary>
        /// Order note content. 
        /// mandatory
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string note { get; set; }

        /// <summary>
        /// If true, the note will be shown to customers and they will be notified. If false, the note will be for admin reference only. Default is false.
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public bool? customer_note { get; set; }
    }
}
