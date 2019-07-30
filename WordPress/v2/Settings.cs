using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace WooCommerce.NET.WordPress.v2
{
    [DataContract]
    public class Settings
    {
        public static string Endpoint { get { return "settings"; } }
        /// <summary>
        /// Site title.
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string title { get; set; }

        /// <summary>
        /// Site tagline.
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string description { get; set; }

        /// <summary>
        /// A city in the same timezone as you.
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string timezone { get; set; }

        /// <summary>
        /// A date format for all date strings.
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string date_format { get; set; }

        /// <summary>
        /// A time format for all time strings.
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string time_format { get; set; }

        /// <summary>
        /// A day number of the week that the week should start on.
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public int start_of_week { get; set; }

        /// <summary>
        /// WordPress locale code.
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string language { get; set; }

        /// <summary>
        /// Convert emoticons like :-) and :-P to graphics on display.
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public bool use_smilies { get; set; }

        /// <summary>
        /// Default post category.
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public int default_category { get; set; }

        /// <summary>
        /// Default post format.
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string default_post_format { get; set; }

        /// <summary>
        /// Blog pages show at most.
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public int posts_per_page { get; set; }

        /// <summary>
        /// Allow link notifications from other blogs (pingbacks and trackbacks) on new articles.
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string default_ping_status { get; set; }

        /// <summary>
        /// Allow people to post comments on new articles.
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string default_comment_status { get; set; }
    }
}
