using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace WooCommerce.NET.WordPress.v2
{
    [DataContract]
    public class Comments
    {
        public static string Endpoint { get { return "comments"; } }
        /// <summary>
        /// Unique identifier for the object.
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public ulong? id  { get; set; }

        /// <summary>
        /// The ID of the user object, if author was a user.
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public ulong? author { get; set; }

        /// <summary>
        /// Email address for the object author.
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string author_email { get; set; }

        /// <summary>
        /// IP address for the object author.
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string author_ip { get; set; }

        /// <summary>
        /// Display name for the object author.
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string author_name { get; set; }

        /// <summary>
        /// URL for the object author.
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string author_url { get; set; }

        /// <summary>
        /// User agent for the object author.
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string author_user_agent { get; set; }

        /// <summary>
        /// The content for the object.
        /// </summary>
        [DataMember(EmitDefaultValue = false, Name = "content")]
        protected ContentObject contentValue { get; set; }

        [IgnoreDataMember]
        public string content
        {
            get
            {
                return contentValue.rendered;
            }
            set
            {
                if (contentValue == null)
                    contentValue = new ContentObject();

                contentValue.rendered = value;
            }
        }

        /// <summary>
        /// The date the object was published, in the site's timezone.
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string date { get; set; }

        /// <summary>
        /// The date the object was published, as GMT.
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string date_gmt { get; set; }

        /// <summary>
        /// URL to the object.
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string link { get; set; }

        /// <summary>
        /// The ID for the parent of the object.
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public ulong? parent { get; set; }

        /// <summary>
        /// The ID of the associated post object.
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public ulong? post { get; set; }

        /// <summary>
        /// State of the object.
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string status { get; set; }

        /// <summary>
        /// Type of Comment for the object.
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string type { get; set; }

        /// <summary>
        /// Avatar URLs for the object author.
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public object author_avatar_urls { get; set; }

        /// <summary>
        /// Meta fields.
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public object meta { get; set; }

        /// <summary>
        /// Format json string on Serialize
        /// </summary>
        /// <param name="json"></param>
        /// <returns></returns>
        public static string FormatJsonS(string json)
        {
            int startIndex = json.IndexOf("{\"rendered\":");
            int endIndex = 0;
            string oldPart = string.Empty;
            string newPart = string.Empty;

            while (startIndex > 0)
            {
                endIndex = json.IndexOf("\"}", startIndex);

                oldPart = json.Substring(startIndex, endIndex - startIndex + 2);
                newPart = oldPart.Substring(12).TrimEnd('}');

                json = json.Replace(oldPart, newPart);

                startIndex = json.IndexOf("{\"rendered\":");
            }

            return json;
        }
    }
}
