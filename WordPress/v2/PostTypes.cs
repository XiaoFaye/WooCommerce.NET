using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace WooCommerce.NET.WordPress.v2
{
    [DataContract]
    public class PostTypes
    {
        public static string Endpoint { get { return "types"; } }
        /// <summary>
        /// All capabilities used by the post type.
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public object capabilities { get; set; }

        /// <summary>
        /// A human-readable description of the post type.
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string description { get; set; }

        /// <summary>
        /// Whether or not the post type should have children.
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public bool hierarchical { get; set; }

        /// <summary>
        /// Human-readable labels for the post type for various contexts.
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public object labels { get; set; }

        /// <summary>
        /// The title for the post type.
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string name { get; set; }

        /// <summary>
        /// An alphanumeric identifier for the post type.
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string slug { get; set; }

        /// <summary>
        /// All features, supported by the post type.
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public object supports { get; set; }

        /// <summary>
        /// Taxonomies associated with post type.
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public List<object> taxonomies { get; set; }

        /// <summary>
        /// REST base route for the post type.
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string rest_base { get; set; }

        /// <summary>
        /// Format json string on Deserialize
        /// </summary>
        /// <param name="json"></param>
        /// <returns></returns>
        public static string FormatJsonD(string json)
        {
            StringBuilder newJson = new StringBuilder();
            newJson.Append('[');

            int headIndex = json.IndexOf("\":{\"description\":\"");
            int nextIndex = 0;
            int quoteIndex = 0;

            while (headIndex > 0)
            {
                nextIndex = json.IndexOf("\":{\"description\":\"", headIndex + 10);

                if (nextIndex > 0)
                {
                    quoteIndex = json.LastIndexOf("\"", nextIndex - 2);
                    newJson.Append(json.Substring(headIndex + 2, nextIndex - headIndex - (nextIndex - quoteIndex) - 3));
                    newJson.Append(',');

                    headIndex = json.IndexOf("\":{\"description\":\"", nextIndex);
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
