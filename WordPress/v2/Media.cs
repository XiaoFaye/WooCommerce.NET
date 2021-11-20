using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace WooCommerce.NET.WordPress.v2
{
    [DataContract]
    public class Media
    {
        public static string Endpoint { get { return "media"; } }

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
        /// The globally unique identifier for the object.
        /// </summary>
        [DataMember(EmitDefaultValue = false, Name = "guid")]
        protected ContentObject guidValue { get; set; }

        [IgnoreDataMember]
        public string guid
        {
            get
            {
                return guidValue.rendered;
            }
            set
            {
                if (guidValue == null)
                    guidValue = new ContentObject();

                guidValue.rendered = value;
            }
        }

        /// <summary>
        /// Unique identifier for the object.
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public ulong? id  { get; set; }

        /// <summary>
        /// URL to the object.
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string link { get; set; }

        /// <summary>
        /// The date the object was last modified, in the site's timezone.
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string modified { get; set; }

        /// <summary>
        /// The date the object was last modified, as GMT.
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string modified_gmt { get; set; }

        /// <summary>
        /// An alphanumeric identifier for the object unique to its type.
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string slug { get; set; }

        /// <summary>
        /// A named status for the object.
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string status { get; set; }

        /// <summary>
        /// Type of Post for the object.
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string type { get; set; }

        /// <summary>
        /// The title for the object.
        /// </summary>
        [DataMember(EmitDefaultValue = false, Name = "title")]
        protected ContentObject titleValue { get; set; }

        [IgnoreDataMember]
        public string title
        {
            get
            {
                return titleValue.rendered;
            }
            set
            {
                if (titleValue == null)
                    titleValue = new ContentObject();

                titleValue.rendered = value;
            }
        }

        /// <summary>
        /// The ID for the author of the object.
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public ulong? author  { get; set; }

        /// <summary>
        /// Whether or not comments are open on the object.
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string comment_status { get; set; }

        /// <summary>
        /// Whether or not the object can be pinged.
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string ping_status { get; set; }

        /// <summary>
        /// Meta fields.
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public List<object> meta  { get; set; }

        /// <summary>
        /// The theme file to use to display the object.
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string template { get; set; }

        /// <summary>
        /// Alternative text to display when attachment is not displayed.
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string alt_text { get; set; }

        /// <summary>
        /// The attachment caption.
        /// </summary>
        [DataMember(EmitDefaultValue = false, Name = "caption")]
        protected ContentObject captionValue { get; set; }

        [IgnoreDataMember]
        public string caption
        {
            get
            {
                return captionValue.rendered;
            }
            set
            {
                if (captionValue == null)
                    captionValue = new ContentObject();

                captionValue.rendered = value;
            }
        }

        /// <summary>
        /// The attachment description.
        /// </summary>
        [DataMember(EmitDefaultValue = false, Name = "description")]
        protected ContentObject descriptionValue { get; set; }

        [IgnoreDataMember]
        public string description
        {
            get
            {
                return descriptionValue.rendered;
            }
            set
            {
                if (descriptionValue == null)
                    descriptionValue = new ContentObject();

                descriptionValue.rendered = value;
            }
        }

        /// <summary>
        /// Attachment type.
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string media_type { get; set; }

        /// <summary>
        /// The attachment MIME type.
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string mime_type { get; set; }

        /// <summary>
        /// Details about the media file, specific to its type.
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public object media_details { get; set; }

        /// <summary>
        /// The ID for the associated post of the attachment.
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public ulong? post  { get; set; }

        /// <summary>
        /// URL to the original attachment file.
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string source_url { get; set; }

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
