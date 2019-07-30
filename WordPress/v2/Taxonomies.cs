using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using WooCommerceNET.Base;

namespace WooCommerce.NET.WordPress.v2
{
    [DataContract]
    public class Taxonomies : JsonObject
    {
        public static string Endpoint { get { return "taxonomies"; } }
        /// <summary>
        ///  All capabilities used by the taxonomy.
        /// </summary>
        [DataMember(EmitDefaultValue = false, Name = "capabilities")]
        protected ContentObject capabilitiesValue { get; set; }


        [IgnoreDataMember]
        public string capabilities
        {
            get
            {
                return capabilitiesValue.rendered;
            }
            set
            {
                if (capabilitiesValue == null)
                    capabilitiesValue = new ContentObject();

                capabilitiesValue.rendered = value;
            }
        }

        /// <summary>
        ///  A human-readable description of the taxonomy.
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string description { get; set; }

        /// <summary>
        ///  Whether or not the taxonomy should have children.
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public bool hierarchical { get; set; }

        /// <summary>
        ///  Human-readable labels for the taxonomy for various contexts.
        /// </summary>
        [DataMember(EmitDefaultValue = false, Name = "labels")]
        protected ContentObject labelsValue { get; set; }

        [IgnoreDataMember]
        public string labels
        {
            get
            {
                return labelsValue.rendered;
            }
            set
            {
                if (labelsValue == null)
                    labelsValue = new ContentObject();

                labelsValue.rendered = value;
            }
        }

        /// <summary>
        ///  The title for the taxonomy.
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string name { get; set; }

        /// <summary>
        ///  An alphanumeric identifier for the taxonomy.
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string slug { get; set; }

        /// <summary>
        ///  Whether or not the term cloud should be displayed.
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public bool show_cloud { get; set; }

        /// <summary>
        ///  Types associated with the taxonomy.
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public List<object> types { get; set; }

        /// <summary>
        ///  REST base route for the taxonomy.
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string rest_base { get; set; }

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

                if(nextIndex > 0)
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
