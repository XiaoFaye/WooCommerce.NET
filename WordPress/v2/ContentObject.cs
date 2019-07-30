using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using WooCommerceNET.Base;

namespace WooCommerce.NET.WordPress.v2
{
    [DataContract]
    public class ContentObject
    {
        [DataMember(EmitDefaultValue = false)]
        public string rendered { get; set; }

        [DataMember(EmitDefaultValue = false, Name = "protected")]
        public bool _protected { get; set; }
    }
}
