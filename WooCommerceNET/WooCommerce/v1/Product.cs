using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using WooCommerceNET.Base;

namespace WooCommerceNET.WooCommerce.v1
{
    [KnownType(typeof(ProductBatch))]
    public class ProductBatch : BatchObject<Product> { }

    [DataContract]
    public class Product : JsonObject
    {
        /// <summary>
        /// Unique identifier for the resource. 
        /// read-only
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public int? id { get; set; }

        /// <summary>
        /// Product name.
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string name { get; set; }

        /// <summary>
        /// Product slug.
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string slug { get; set; }

        /// <summary>
        /// Product URL. 
        /// read-only
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string permalink { get; set; }

        /// <summary>
        /// The date the product was created, in the site’s timezone. 
        /// read-only
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public DateTime? date_created { get; set; }

        /// <summary>
        /// The date the product was last modified, in the site’s timezone. 
        /// read-only
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public DateTime? date_modified { get; set; }

        /// <summary>
        /// Product type. Default is simple. Options (plugins may add new options): simple, grouped, external, variable.
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string type { get; set; }

        /// <summary>
        /// Product status (post status). Default is publish. Options (plugins may add new options): draft, pending, private and publish.
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string status { get; set; }

        /// <summary>
        /// Featured product. Default is false.
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public bool? featured { get; set; }

        /// <summary>
        /// Catalog visibility. Default is visible. Options: visible (Catalog and search), catalog (Only in catalog), search (Only in search) and hidden (Hidden from all).
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string catalog_visibility { get; set; }

        /// <summary>
        /// Product description.
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string description { get; set; }

        /// <summary>
        /// Product short description.
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string short_description { get; set; }

        /// <summary>
        /// Unique identifier.
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string sku { get; set; }

        /// <summary>
        /// Current product price. This is setted from regular_price and sale_price. 
        /// read-only
        /// </summary>
        [DataMember(EmitDefaultValue = false, Name = "price")]
        protected object priceValue { get; set; }

        public decimal? price { get; set; }

        /// <summary>
        /// Product regular price.
        /// </summary>
        [DataMember(EmitDefaultValue = false, Name = "regular_price")]
        protected object regular_priceValue { get; set; }

        public decimal? regular_price { get; set; }

        /// <summary>
        /// Product sale price.
        /// </summary>
        [DataMember(EmitDefaultValue = false, Name = "sale_price")]
        protected object sale_priceValue { get; set; }

        public decimal? sale_price { get; set; }

        /// <summary>
        /// Start date of sale price. Date in the YYYY-MM-DD format.
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string date_on_sale_from { get; set; }

        /// <summary>
        /// Sets the sale end date. Date in the YYYY-MM-DD format.
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string date_on_sale_to { get; set; }

        /// <summary>
        /// Price formatted in HTML, e.g. delspan class=\"woocommerce-Price-amount amount\"span class=\"woocommerce-Price-currencySymbol\"#36;nbsp;3.00/span/span/del insspan class=\"woocommerce-Price-amount amount\"span class=\"woocommerce-Price-currencySymbol\"#36;nbsp;2.00/span/span/ins 
        /// read-only
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string price_html { get; set; }

        /// <summary>
        /// Shows if the product is on sale. 
        /// read-only
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public bool? on_sale { get; set; }

        /// <summary>
        /// Shows if the product can be bought. 
        /// read-only
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public bool? purchasable { get; set; }

        /// <summary>
        /// Amount of sales. 
        /// read-only
        /// </summary>
        [DataMember(EmitDefaultValue = false, Name = "total_sales")]
        protected object total_salesValue { get; set; }

        public decimal? total_sales { get; set; }

        /// <summary>
        /// If the product is virtual. Virtual products are intangible and aren’t shipped. Default is false.
        /// </summary>
        [DataMember(Name = "virtual", EmitDefaultValue = false)]
        public bool? _virtual { get; set; }

        /// <summary>
        /// If the product is downloadable. Downloadable products give access to a file upon purchase. Default is false.
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public bool? downloadable { get; set; }

        /// <summary>
        /// List of downloadable files. See Downloads properties.
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public List<Download> downloads { get; set; }

        /// <summary>
        /// Amount of times the product can be downloaded, the -1 values means unlimited re-downloads. Default is -1.
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public int? download_limit { get; set; }

        /// <summary>
        /// Number of days that the customer has up to be able to download the product, the -1 means that downloads never expires. Default is -1.
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public int? download_expiry { get; set; }

        /// <summary>
        /// Download type, this controls the schema on the front-end. Default is standard. Options: 'standard' (Standard Product), application (Application/Software) and music (Music).
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string download_type { get; set; }

        /// <summary>
        /// Product external URL. Only for external products.
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string external_url { get; set; }

        /// <summary>
        /// Product external button text. Only for external products.
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string button_text { get; set; }

        /// <summary>
        /// Tax status. Default is taxable. Options: taxable, shipping (Shipping only) and none.
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string tax_status { get; set; }

        /// <summary>
        /// Tax class.
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string tax_class { get; set; }

        /// <summary>
        /// Stock management at product level. Default is false.
        /// When Manage stock is checked, string value "parent" will be given, otherwise, it will be bool value false.
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public object manage_stock { get; set; }

        /// <summary>
        /// Stock quantity. If is a variable product this value will be used to control stock for all variations, unless you define stock at variation level.
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public int? stock_quantity { get; set; }

        /// <summary>
        /// Controls whether or not the product is listed as “in stock” or “out of stock” on the frontend. Default is true.
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public bool? in_stock { get; set; }

        /// <summary>
        /// If managing stock, this controls if backorders are allowed. If enabled, stock quantity can go below 0. Default is no. Options are: no (Do not allow), notify (Allow, but notify customer), and yes (Allow).
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string backorders { get; set; }

        /// <summary>
        /// Shows if backorders are allowed. 
        /// read-only
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public bool? backorders_allowed { get; set; }

        /// <summary>
        /// Shows if a product is on backorder (if the product have the stock_quantity negative). 
        /// read-only
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public bool? backordered { get; set; }

        /// <summary>
        /// Allow one item to be bought in a single order. Default is false.
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public bool? sold_individually { get; set; }

        /// <summary>
        /// Product weight in decimal format.
        /// </summary>
        [DataMember(EmitDefaultValue = false, Name = "weight")]
        protected object weightValue { get; set; }

        public decimal? weight { get; set; }

        /// <summary>
        /// Product dimensions. See Dimensions properties.
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public Dimension dimensions { get; set; }

        /// <summary>
        /// Shows if the product need to be shipped. 
        /// read-only
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public bool? shipping_required { get; set; }

        /// <summary>
        /// Shows whether or not the product shipping is taxable. 
        /// read-only
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public bool? shipping_taxable { get; set; }

        /// <summary>
        /// Shipping class slug. Shipping classes are used by certain shipping methods to group similar products.
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string shipping_class { get; set; }

        /// <summary>
        /// Shipping class ID. 
        /// read-only
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public int? shipping_class_id { get; set; }

        /// <summary>
        /// Allow reviews. Default is true.
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public bool? reviews_allowed { get; set; }

        /// <summary>
        /// Reviews average rating. 
        /// read-only
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string average_rating { get; set; }

        /// <summary>
        /// Amount of reviews that the product have. 
        /// read-only
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public int? rating_count { get; set; }

        /// <summary>
        /// List of related products IDs (integer). 
        /// read-only
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public List<int> related_ids { get; set; }

        /// <summary>
        /// List of up-sell products IDs (integer). Up-sells are products which you recommend instead of the currently viewed product, for example, products that are more profitable or better quality or more expensive.
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public List<int> upsell_ids { get; set; }

        /// <summary>
        /// List of cross-sell products IDs. Cross-sells are products which you promote in the cart, based on the current product.
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public List<int> cross_sell_ids { get; set; }

        /// <summary>
        /// Product parent ID (post_parent).
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public int? parent_id { get; set; }

        /// <summary>
        /// Optional note to send the customer after purchase.
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string purchase_note { get; set; }

        /// <summary>
        /// List of categories. See Categories properties.
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public List<Category> categories { get; set; }

        /// <summary>
        /// List of tags. See Tags properties.
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public List<Tag> tags { get; set; }

        /// <summary>
        /// List of images. See Images properties
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public List<Image> images { get; set; }

        /// <summary>
        /// List of attributes. See Attributes properties.
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public List<Attribute> attributes { get; set; }

        /// <summary>
        /// Defaults variation attributes, used only for variations and pre-selecte attributes on the frontend. See Default Attributes properties.
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public List<DefaultAttribute> default_attributes { get; set; }

        /// <summary>
        /// List of variations. See Variations properties
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public List<Variation> variations { get; set; }

        /// <summary>
        /// List of grouped products ID, only for group type products. 
        /// read-only
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public List<int> grouped_products { get; set; }

        /// <summary>
        /// Menu order, used to custom sort products.
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public int? menu_order { get; set; }
    }

    [DataContract]
    public class Dimension
    {
        /// <summary>
        /// Product length in decimal format.
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string length { get; set; }

        /// <summary>
        /// Product width in decimal format.
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string width { get; set; }

        /// <summary>
        /// Product height in decimal format.
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string height { get; set; }
    }

    [KnownType(typeof(CategoryBatch))]
    public class CategoryBatch : BatchObject<Category> { }

    [DataContract]
    public class Category
    {
        /// <summary>
        /// Category ID.
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public int? id { get; set; }

        /// <summary>
        /// Category name. 
        /// read-only
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string name { get; set; }

        /// <summary>
        /// Category slug. 
        /// read-only
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string slug { get; set; }
    }

    [DataContract]
    public class Tag
    {
        /// <summary>
        /// Tag ID.
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public int? id { get; set; }

        /// <summary>
        /// Tag name. 
        /// read-only
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string name { get; set; }

        /// <summary>
        /// Tag slug. 
        /// read-only
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string slug { get; set; }
    }

    [DataContract]
    public class Image
    {
        /// <summary>
        /// Image ID (attachment ID). In write-mode used to attach pre-existing images.
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
        /// The date the image was last modified, in the site’s timezone. 
        /// read-only
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public DateTime? date_modified { get; set; }

        /// <summary>
        /// Image URL. In write-mode used to upload new images.
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

        /// <summary>
        /// Image position. 0 means that the image is featured.
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public int? position { get; set; }
    }

    [KnownType(typeof(AttributeBatch))]
    public class AttributeBatch : BatchObject<Attribute> { }

    [DataContract]
    public class Attribute
    {
        /// <summary>
        /// Attribute ID (required if is a global attribute).
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public int? id { get; set; }

        /// <summary>
        /// Attribute name (required if is a non-global attribute).
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string name { get; set; }

        /// <summary>
        /// Attribute position.
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public int? position { get; set; }

        /// <summary>
        /// Define if the attribute is visible on the “Additional Information” tab in the product’s page. Default is false.
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public bool? visible { get; set; }

        /// <summary>
        /// Define if the attribute can be used as variation. Default is false.
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public bool? variation { get; set; }

        /// <summary>
        /// List of available term names of the attribute.
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public List<string> options { get; set; }
    }

    [DataContract]
    public class DefaultAttribute
    {
        /// <summary>
        /// Attribute ID (required if is a global attribute).
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public int? id { get; set; }

        /// <summary>
        /// Attribute name (required if is a non-global attribute).
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string name { get; set; }

        /// <summary>
        /// Selected attribute term name.
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string option { get; set; }

    }

    [DataContract]
    public class Download
    {
        /// <summary>
        /// File MD5 hash. 
        /// read-only
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string id { get; set; }

        /// <summary>
        /// File name.
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string name { get; set; }

        /// <summary>
        /// File URL. In write-mode you can use this property to send new files.
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string file { get; set; }
    }

    [DataContract]
    public class Variation : JsonObject
    {
        /// <summary>
        /// Variation ID. 
        /// read-only
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public int? id { get; set; }

        /// <summary>
        /// The date the variation was created, in the site’s timezone. 
        /// read-only
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public DateTime? date_created { get; set; }

        /// <summary>
        /// The date the variation was last modified, in the site’s timezone. 
        /// read-only
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public DateTime? date_modified { get; set; }

        /// <summary>
        /// Variation URL. 
        /// read-only
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string permalink { get; set; }

        /// <summary>
        /// Unique identifier.
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string sku { get; set; }

        /// <summary>
        /// Current variation price. This is setted from regular_price and sale_price. 
        /// read-only
        /// </summary>
        [DataMember(EmitDefaultValue = false, Name = "price")]
        protected object priceValue { get; set; }
        public decimal? price { get; set; }

        /// <summary>
        /// Variation regular price.
        /// </summary>
        [DataMember(EmitDefaultValue = false, Name = "regular_price")]
        protected object regular_priceValue { get; set; }
        public decimal? regular_price { get; set; }

        /// <summary>
        /// Variation sale price.
        /// </summary>
        [DataMember(EmitDefaultValue = false, Name = "sale_price")]
        protected object sale_priceValue { get; set; }
        public decimal? sale_price { get; set; }

        /// <summary>
        /// Start date of sale price. Date in the YYYY-MM-DD format.
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string date_on_sale_from { get; set; }

        /// <summary>
        /// Start date of sale price. Date in the YYYY-MM-DD format.
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string date_on_sale_to { get; set; }

        /// <summary>
        /// Shows if the variation is on sale. 
        /// read-only
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public bool? on_sale { get; set; }

        /// <summary>
        /// Shows if the variation can be bought. 
        /// read-only
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public bool? purchasable { get; set; }

        /// <summary>
        /// If the variation is virtual. Virtual variations are intangible and aren’t shipped. Default is false.
        /// </summary>
        [DataMember(Name ="virtual", EmitDefaultValue = false)]
        public bool? _virtual { get; set; }

        /// <summary>
        /// If the variation is downloadable. Downloadable variations give access to a file upon purchase. Default is false.
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public bool? downloadable { get; set; }

        /// <summary>
        /// List of downloadable files. See Downloads properties.
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public List<Download> downloads { get; set; }

        /// <summary>
        /// Amount of times the variation can be downloaded, the -1 values means unlimited re-downloads. Default is -1.
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public int? download_limit { get; set; }

        /// <summary>
        /// Number of days that the customer has up to be able to download the variation, the -1 means that downloads never expires. Default is -1.
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public int? download_expiry { get; set; }

        /// <summary>
        /// Tax status. Default is taxable. Options: taxable, shipping (Shipping only) and none.
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string tax_status { get; set; }

        /// <summary>
        /// Tax class.
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string tax_class { get; set; }

        /// <summary>
        /// Stock management at variation level. Default is false.
        /// When Manage stock is checked, string value "parent" will be given, otherwise, it will be bool value false.
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public object manage_stock { get; set; }

        /// <summary>
        /// Stock quantity. If is a variable variation this value will be used to control stock for all variations, unless you define stock at variation level.
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public int? stock_quantity { get; set; }

        /// <summary>
        /// Controls whether or not the variation is listed as “in stock” or “out of stock” on the frontend. Default is true.
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public bool in_stock { get; set; }

        /// <summary>
        /// If managing stock, this controls if backorders are allowed. If enabled, stock quantity can go below 0. Default is no. Options are: no (Do not allow), notify (Allow, but notify customer), and yes (Allow).
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string backorders { get; set; }

        /// <summary>
        /// Shows if backorders are allowed.“ 
        /// read-only
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public bool? backorders_allowed { get; set; }

        /// <summary>
        /// Shows if a variation is on backorder (if the variation have the stock_quantity negative). 
        /// read-only
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public bool? backordered { get; set; }

        /// <summary>
        /// Shows if the variation can be bought 
        /// read-only
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public bool? purchaseable { get; set; }

        /// <summary>
        /// Variation weight in decimal format.
        /// </summary>
        [DataMember(EmitDefaultValue = false, Name = "weight")]
        protected object weightValue { get; set; }
        public decimal? weight { get; set; }

        /// <summary>
        /// Variation dimensions. See Dimensions properties.
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public List<Dimension> dimensions { get; set; }

        /// <summary>
        /// Shipping class slug. Shipping classes are used by certain shipping methods to group similar products.
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string shipping_class { get; set; }

        /// <summary>
        /// Shipping class ID. 
        /// read-only
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public int? shipping_class_id { get; set; }

        /// <summary>
        /// Variation featured image. Only position 0 will be used. See Images properties.
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public List<Image> image { get; set; }

        /// <summary>
        /// List of variation attributes. See Variation Attributes properties
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public List<VariationAttribute> attributes { get; set; }
    }

    [DataContract]
    public class VariationAttribute
    {
        /// <summary>
        /// Attribute ID (required if is a global attribute).
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public int? id { get; set; }

        /// <summary>
        /// Attribute name (required if is a non-global attribute).
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string name { get; set; }

        /// <summary>
        /// Selected attribute term name.
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string option { get; set; }
    }

    [DataContract]
    public class ProductAttribute
    {
        /// <summary>
        /// Unique identifier for the resource. 
        /// read-only
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public int? id { get; set; }

        /// <summary>
        /// Attribute name. 
        /// required
        /// </summary>
        [DataMember(EmitDefaultValue = false, IsRequired = true)]
        public string name { get; set; }

        /// <summary>
        /// An alphanumeric identifier for the resource unique to its type.
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string slug { get; set; }

        /// <summary>
        /// Type of attribute. Default is select. Options: select and text (some plugins can include new types)
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string type { get; set; }

        /// <summary>
        /// Default sort order. Default is menu_order. Options: menu_order, name, name_num and id.
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string order_by { get; set; }

        /// <summary>
        /// Enable/Disable attribute archives. Default is false.
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public bool? has_archives { get; set; }
    }

    [DataContract]
    public class ProductAttributeTerm
    {
        /// <summary>
        /// Unique identifier for the resource. 
        /// read-only
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public int? id { get; set; }

        /// <summary>
        /// Term name. 
        /// required
        /// </summary>
        [DataMember(EmitDefaultValue = false, IsRequired = true)]
        public string name { get; set; }

        /// <summary>
        /// An alphanumeric identifier for the resource unique to its type.
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string slug { get; set; }

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
    public class ProductCategory : Category
    {
        /// <summary>
        /// The id for the parent of the resource.
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public int? parent { get; set; }

        /// <summary>
        /// HTML description of the resource.
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string description { get; set; }

        /// <summary>
        /// Category archive display type. Default is default. Options: default, products, subcategories and both
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string display { get; set; }

        /// <summary>
        /// Image data. See Category Image properties
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
        /// Image ID (attachment ID). In write-mode used to attach pre-existing images.
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
        /// The date the image was last modified, in the site’s timezone. 
        /// read-only
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public DateTime? date_modified { get; set; }

        /// <summary>
        /// Image URL. In write-mode used to upload new images.
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

    [KnownType(typeof(ShippingClassBatch))]
    public class ShippingClassBatch : BatchObject<ShippingClass> { }

    [DataContract]
    public class ShippingClass
    {
        /// <summary>
        /// Unique identifier for the resource. 
        /// read-only
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public int? id { get; set; }

        /// <summary>
        /// Shipping class name. 
        /// required
        /// </summary>
        [DataMember(EmitDefaultValue = false, IsRequired = true)]
        public string name { get; set; }

        /// <summary>
        /// An alphanumeric identifier for the resource unique to its type.
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string slug { get; set; }

        /// <summary>
        /// HTML description of the resource.
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string description { get; set; }

        /// <summary>
        /// Number of published products for the resource. 
        /// read-only
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public int? count { get; set; }
    }

    [KnownType(typeof(ProductTagBatch))]
    public class ProductTagBatch : BatchObject<ProductTag> { }

    [DataContract]
    public class ProductTag
    {
        /// <summary>
        /// Unique identifier for the resource. 
        /// read-only
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public int? id { get; set; }

        /// <summary>
        /// Tag name. 
        /// required
        /// </summary>
        [DataMember(EmitDefaultValue = false, IsRequired = true)]
        public string name { get; set; }

        /// <summary>
        /// An alphanumeric identifier for the resource unique to its type.
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string slug { get; set; }

        /// <summary>
        /// HTML description of the resource.
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string description { get; set; }

        /// <summary>
        /// Number of published products for the resource. 
        /// read-only
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public int? count { get; set; }
    }

    [DataContract]
    public class ProductReview
    {
        /// <summary>
        /// Unique identifier for the resource. 
        /// read-only
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public int? id { get; set; }

        /// <summary>
        /// The date the review was created, in the site’s timezone. 
        /// read-only
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public DateTime? date_created { get; set; }

        /// <summary>
        /// Review rating (0 to 5). 
        /// read-only
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public int? rating { get; set; }

        /// <summary>
        /// Reviewer name. 
        /// read-only
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string name { get; set; }

        /// <summary>
        /// Reviewer email. 
        /// read-only
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string email { get; set; }

        /// <summary>
        /// Shows if the reviewer bought the product or not. 
        /// read-only
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public bool? verified { get; set; }
    }
}
