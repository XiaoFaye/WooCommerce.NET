using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace WooCommerce.NET.WordPress.v2
{
    [DataContract]
    public class Users
    {
        public static string Endpoint { get { return "users"; } }

        /// <summary>
        /// Unique identifier for the user.
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public ulong? id { get; set; }

        /// <summary>
        /// Login name for the user.
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string username { get; set; }

        /// <summary>
        /// Display name for the user.
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string name { get; set; }

        /// <summary>
        /// First name for the user.
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string first_name { get; set; }

        /// <summary>
        /// Last name for the user.
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string last_name { get; set; }

        /// <summary>
        /// The email address for the user.
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string email { get; set; }

        /// <summary>
        /// URL of the user.
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string url { get; set; }

        /// <summary>
        /// Description of the user.
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string description { get; set; }

        /// <summary>
        /// Author URL of the user.
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string link { get; set; }

        /// <summary>
        /// Locale for the user.
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string locale { get; set; }

        /// <summary>
        /// The nickname for the user.
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string nickname { get; set; }

        /// <summary>
        /// An alphanumeric identifier for the user.
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string slug { get; set; }

        /// <summary>
        /// Registration date for the user.
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string registered_date { get; set; }

        /// <summary>
        /// Roles assigned to the user.
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public List<object> roles { get; set; }

        /// <summary>
        /// Password for the user (never included).
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string password { get; set; }

        /// <summary>
        /// All capabilities assigned to the user.
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public object capabilities { get; set; }

        /// <summary>
        /// Any extra capabilities assigned to the user.
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public object extra_capabilities { get; set; }

        /// <summary>
        /// Avatar URLs for the user.
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public object avatar_urls { get; set; }

        /// <summary>
        /// Meta fields.
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public List<object> meta { get; set; }
    }
}
