using System;
using System.Runtime.Serialization;

namespace WooCommerceNET.WooCommerce.v2
{
    [DataContract]
    public class ProductCategory
    {
        public static string Endpoint { get { return "products/categories"; } }

        /// <summary>
        /// Unique identifier for the resource. 
        /// read-only
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public int? id { get; set; }

        /// <summary>
        /// Category name. 
        /// mandatory
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string name { get; set; }

        /// <summary>
        /// An alphanumeric identifier for the resource unique to its type.
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string slug { get; set; }

        /// <summary>
        /// The ID for the parent of the resource.
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public int? parent { get; set; }

        /// <summary>
        /// HTML description of the resource.
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string description { get; set; }

        /// <summary>
        /// Category archive display type. Options: default, products, subcategories and both. Default is default.
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string display { get; set; }

        /// <summary>
        /// Image data. See Product category - Image properties
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public ProductCategoryImage image { get; set; }

        /// <summary>
        /// Menu order, used to custom sort the resource.
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public int? menu_order { get; set; }

        /// <summary>
        /// Number of published products for the resource. 
        /// read-only
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public int? count { get; set; }
    }

    [DataContract]
    public class ProductCategoryImage
    {
        /// <summary>
        /// Image ID.
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public int? id { get; set; }

        /// <summary>
        /// The date the image was created, in the site’s timezone. 
        /// read-only
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public DateTime? date_created { get; set; }

        /// <summary>
        /// The date the image was created, as GMT 
        /// read-only
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public DateTime? date_created_gmt { get; set; }

        /// <summary>
        /// The date the image was last modified, in the site’s timezone. 
        /// read-only
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public DateTime? date_modified { get; set; }

        /// <summary>
        /// The date the image was last modified, as GMT. 
        /// read-only
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public DateTime? date_modified_gmt { get; set; }

        /// <summary>
        /// Image URL.
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string src { get; set; }

        /// <summary>
        /// Image name.
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string name { get; set; }

        /// <summary>
        /// Image alternative text.
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string alt { get; set; }

    }
}
