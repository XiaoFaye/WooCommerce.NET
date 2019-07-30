using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace WooCommerce.NET.WordPress.v2
{
    [DataContract]
    public class PostStatuses
    {
        public static string Endpoint { get { return "statuses"; } }
        /// <summary>
        /// The title for the status.
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string name { get; set; }

        /// <summary>
        /// Whether posts with this status should be private.
        /// </summary>
        [DataMember(EmitDefaultValue = false, Name = "private")]
        public bool _private  { get; set; }

        /// <summary>
        /// Whether posts with this status should be protected.
        /// </summary>
        [DataMember(EmitDefaultValue = false, Name = "protected")]
        public bool _protected  { get; set; }

        /// <summary>
        /// Whether posts of this status should be shown in the front end of the site.
        /// </summary>
        [DataMember(EmitDefaultValue = false, Name = "public")]
        public bool _public  { get; set; }

        /// <summary>
        /// Whether posts with this status should be publicly-queryable.
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public bool queryable { get; set; }

        /// <summary>
        /// Whether to include posts in the edit listing for their post type.
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public bool show_in_list { get; set; }

        /// <summary>
        /// An alphanumeric identifier for the status.
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string slug { get; set; }

        /// <summary>
        /// Format json string on Deserialize
        /// </summary>
        /// <param name="json"></param>
        /// <returns></returns>
        public static string FormatJsonD(string json)
        {
            StringBuilder newJson = new StringBuilder();
            newJson.Append('[');

            int headIndex = json.IndexOf("\":{\"name\":\"");
            int nextIndex = 0;
            int quoteIndex = 0;

            while (headIndex > 0)
            {
                nextIndex = json.IndexOf("\":{\"name\":\"", headIndex + 10);

                if (nextIndex > 0)
                {
                    quoteIndex = json.LastIndexOf("\"", nextIndex - 2);
                    newJson.Append(json.Substring(headIndex + 2, nextIndex - headIndex - (nextIndex - quoteIndex) - 3));
                    newJson.Append(',');

                    headIndex = json.IndexOf("\":{\"name\":\"", nextIndex);
                }
                else
                {
                    string temp = json.Substring(headIndex + 2);
                    newJson.Append(temp.Substring(0, temp.Length - 1));
                    newJson.Append(']');

                    break;
                }
            }

            return newJson.ToString();
        }
    }
}
