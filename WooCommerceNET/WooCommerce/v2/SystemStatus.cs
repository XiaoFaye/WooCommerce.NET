using System.Collections.Generic;
using System.Runtime.Serialization;

namespace WooCommerceNET.WooCommerce.v2
{
    [DataContract]
    public class SystemStatus
    {
        public static string Endpoint { get { return "system_status"; } }

        /// <summary>
        /// Environment. See System status - Environment properties 
        /// read-only
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public SystemStatusEnvironment environment { get; set; }

        /// <summary>
        /// Database. See System status - Database properties 
        /// read-only
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public SystemStatusDatabase database { get; set; }

        /// <summary>
        /// Active plugins. 
        /// read-only
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public List<object> active_plugins { get; set; }

        /// <summary>
        /// Theme. See System status - Theme properties 
        /// read-only
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public SystemStatusTheme theme { get; set; }

        /// <summary>
        /// Settings. See System status - Settings properties 
        /// read-only
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public SystemStatusSetting settings { get; set; }

        /// <summary>
        /// Security. See System status - Security properties 
        /// read-only
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public SystemStatusSecurity security { get; set; }

        /// <summary>
        /// WooCommerce pages. 
        /// read-only
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public List<object> pages { get; set; }

    }

    [DataContract]
    public class SystemStatusEnvironment
    {
        /// <summary>
        /// Home URL. 
        /// read-only
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string home_url { get; set; }

        /// <summary>
        /// Site URL. 
        /// read-only
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string site_url { get; set; }

        /// <summary>
        /// WooCommerce version. 
        /// read-only
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string wc_version { get; set; }

        /// <summary>
        /// Log directory. 
        /// read-only
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string log_directory { get; set; }

        /// <summary>
        /// Is log directory writable? 
        /// read-only
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public bool? log_directory_writable { get; set; }

        /// <summary>
        /// WordPress version. 
        /// read-only
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string wp_version { get; set; }

        /// <summary>
        /// Is WordPress multisite? 
        /// read-only
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public bool? wp_multisite { get; set; }

        /// <summary>
        /// WordPress memory limit. 
        /// read-only
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public int? wp_memory_limit { get; set; }

        /// <summary>
        /// Is WordPress debug mode active? 
        /// read-only
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public bool? wp_debug_mode { get; set; }

        /// <summary>
        /// Are WordPress cron jobs enabled? 
        /// read-only
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public bool? wp_cron { get; set; }

        /// <summary>
        /// WordPress language. 
        /// read-only
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string language { get; set; }

        /// <summary>
        /// Server info. 
        /// read-only
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string server_info { get; set; }

        /// <summary>
        /// PHP version. 
        /// read-only
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string php_version { get; set; }

        /// <summary>
        /// PHP post max size. 
        /// read-only
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public int? php_post_max_size { get; set; }

        /// <summary>
        /// PHP max execution time. 
        /// read-only
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public int? php_max_execution_time { get; set; }

        /// <summary>
        /// PHP max input vars. 
        /// read-only
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public int? php_max_input_vars { get; set; }

        /// <summary>
        /// cURL version. 
        /// read-only
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string curl_version { get; set; }

        /// <summary>
        /// Is SUHOSIN installed? 
        /// read-only
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public bool? suhosin_installed { get; set; }

        /// <summary>
        /// Max upload size. 
        /// read-only
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public int? max_upload_size { get; set; }

        /// <summary>
        /// MySQL version. 
        /// read-only
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string mysql_version { get; set; }

        /// <summary>
        /// Default timezone. 
        /// read-only
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string default_timezone { get; set; }

        /// <summary>
        /// Is fsockopen/cURL enabled? 
        /// read-only
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public bool? fsockopen_or_curl_enabled { get; set; }

        /// <summary>
        /// Is SoapClient class enabled? 
        /// read-only
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public bool? soapclient_enabled { get; set; }

        /// <summary>
        /// Is DomDocument class enabled? 
        /// read-only
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public bool? domdocument_enabled { get; set; }

        /// <summary>
        /// Is GZip enabled? 
        /// read-only
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public bool? gzip_enabled { get; set; }

        /// <summary>
        /// Is mbstring enabled? 
        /// read-only
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public bool? mbstring_enabled { get; set; }

        /// <summary>
        /// Remote POST successful? 
        /// read-only
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public bool? remote_post_successful { get; set; }

        /// <summary>
        /// Remote POST response. 
        /// read-only
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string remote_post_response { get; set; }

        /// <summary>
        /// Remote GET successful? 
        /// read-only
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public bool? remote_get_successful { get; set; }

        /// <summary>
        /// Remote GET response. 
        /// read-only
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string remote_get_response { get; set; }

    }
    
    [DataContract]
    public class SystemStatusDatabase
    {
        /// <summary>
        /// WC database version. 
        /// read-only
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string wc_database_version { get; set; }

        /// <summary>
        /// Database prefix. 
        /// read-only
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string database_prefix { get; set; }

        /// <summary>
        /// MaxMind GeoIP database. 
        /// read-only
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string maxmind_geoip_database { get; set; }

        /// <summary>
        /// Database tables. 
        /// read-only
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public List<string> database_tables { get; set; }

    }
    
    [DataContract]
    public class SystemStatusTheme
    {
        /// <summary>
        /// Theme name. 
        /// read-only
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string name { get; set; }

        /// <summary>
        /// Theme version. 
        /// read-only
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string version { get; set; }

        /// <summary>
        /// Latest version of theme. 
        /// read-only
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string version_latest { get; set; }

        /// <summary>
        /// Theme author URL. 
        /// read-only
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string author_url { get; set; }

        /// <summary>
        /// Is this theme a child theme? 
        /// read-only
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public bool? is_child_theme { get; set; }

        /// <summary>
        /// Does the theme declare WooCommerce support? 
        /// read-only
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public bool? has_woocommerce_support { get; set; }

        /// <summary>
        /// Does the theme have a woocommerce.php file? 
        /// read-only
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public bool? has_woocommerce_file { get; set; }

        /// <summary>
        /// Does this theme have outdated templates? 
        /// read-only
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public bool? has_outdated_templates { get; set; }

        /// <summary>
        /// Template overrides. 
        /// read-only
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public List<string> overrides { get; set; }

        /// <summary>
        /// Parent theme name. 
        /// read-only
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string parent_name { get; set; }

        /// <summary>
        /// Parent theme version. 
        /// read-only
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string parent_version { get; set; }

        /// <summary>
        /// Parent theme author URL. 
        /// read-only
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string parent_author_url { get; set; }

    }
    
    [DataContract]
    public class SystemStatusSetting
    {
        /// <summary>
        /// REST API enabled? 
        /// read-only
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public bool? api_enabled { get; set; }

        /// <summary>
        /// SSL forced? 
        /// read-only
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public bool? force_ssl { get; set; }

        /// <summary>
        /// Currency. 
        /// read-only
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string currency { get; set; }

        /// <summary>
        /// Currency symbol. 
        /// read-only
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string currency_symbol { get; set; }

        /// <summary>
        /// Currency position. 
        /// read-only
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string currency_position { get; set; }

        /// <summary>
        /// Thousand separator. 
        /// read-only
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string thousand_separator { get; set; }

        /// <summary>
        /// Decimal separator. 
        /// read-only
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string decimal_separator { get; set; }

        /// <summary>
        /// Number of decimals. 
        /// read-only
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public int? number_of_decimals { get; set; }

        /// <summary>
        /// Geolocation enabled? 
        /// read-only
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public bool? geolocation_enabled { get; set; }

        /// <summary>
        /// Taxonomy terms for product/order statuses. 
        /// read-only
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public List<object> taxonomies { get; set; }
    }
    
    [DataContract]
    public class SystemStatusSecurity
    {
        /// <summary>
        /// Is the connection to your store secure? 
        /// read-only
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public bool? secure_connection { get; set; }

        /// <summary>
        /// Hide errors from visitors? 
        /// read-only
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public bool? hide_errors { get; set; }

    }

    [DataContract]
    public class SystemStatusTool
    {
        public static string Endpoint { get { return "system_status/tools"; } }

        /// <summary>
        /// A unique identifier for the tool. 
        /// read-only
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string id { get; set; }

        /// <summary>
        /// Tool name. 
        /// read-only
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string name { get; set; }

        /// <summary>
        /// What running the tool will do. 
        /// read-only
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string action { get; set; }

        /// <summary>
        /// Tool description. 
        /// read-only
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string description { get; set; }

        /// <summary>
        /// Did the tool run successfully? read-only 
        /// read-only</i> <i class="label label-info">write-only
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public bool? success { get; set; }

        /// <summary>
        /// Tool return message. read-only 
        /// read-only</i> <i class="label label-info">write-only
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string message { get; set; }

        /// <summary>
        /// Confirm execution of the tool. Default is false. 
        /// write-only
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public bool? confirm { get; set; }

    }
}
