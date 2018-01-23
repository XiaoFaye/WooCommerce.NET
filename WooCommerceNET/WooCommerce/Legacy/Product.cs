using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using WooCommerceNET.Base;

namespace WooCommerceNET.WooCommerce.Legacy
{
    [CollectionDataContract]
    public class ProductList : List<Product>
    {
        [DataMember]
        public List<Product> products { get; set; }
    }


    [DataContract]
    public class Product : JsonObject
    {
        /// <summary>
        /// Product name
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string title { get; set; }

        /// <summary>
        /// Product ID (post ID) 
        /// read-only
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public int? id { get; set; }

        /// <summary>
        /// Product slug 
        /// edit-only
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string name { get; set; }

        /// <summary>
        /// UTC DateTime when the product was created 
        /// read-only
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public DateTime? created_at { get; set; }

        /// <summary>
        /// UTC DateTime when the product was last updated 
        /// read-only
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public DateTime? updated_at { get; set; }

        /// <summary>
        /// Product type. By default in WooCommerce the following types are available: simple, grouped, external, variable. Default is simple
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string type { get; set; }

        /// <summary>
        /// Product status (post status). Default is publish
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string status { get; set; }

        /// <summary>
        /// If the product is downloadable or not. Downloadable products give access to a file upon purchase
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public bool? downloadable { get; set; }

        /// <summary>
        /// If the product is virtual or not. Virtual products are intangible and aren’t shipped
        /// </summary>
        [DataMember(EmitDefaultValue = false, Name = "virtual")]
        public bool? isvirtual { get; set; }

        /// <summary>
        /// Product URL (post permalink) 
        /// read-only
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string permalink { get; set; }

        /// <summary>
        /// SKU refers to a Stock-keeping unit, a unique identifier for each distinct product and service that can be purchased
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string sku { get; set; }

        /// <summary>
        /// Current product price. This is setted from regular_price and sale_price 
        /// read-only
        /// </summary>
        [DataMember(EmitDefaultValue = false, Name = "price")]
        private object priceValue { get; set; }

        public decimal? price { get; set; }

        /// <summary>
        /// Product regular price
        /// </summary>
        [DataMember(EmitDefaultValue = false, Name = "regular_price")]
        private object regular_priceValue { get; set; }

        public decimal? regular_price { get; set; }

        /// <summary>
        /// Product sale price
        /// </summary>
        [DataMember(EmitDefaultValue = false, Name = "sale_price")]
        private object sale_priceValue { get; set; }

        public decimal? sale_price { get; set; }

        /// <summary>
        /// Sets the sale start date. Date in the YYYY-MM-DD format 
        /// write-only
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public decimal? sale_price_dates_from { get; set; }

        /// <summary>
        /// Sets the sale end date. Date in the YYYY-MM-DD format 
        /// write-only
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public decimal? sale_price_dates_to { get; set; }

        /// <summary>
        /// Price formatted in HTML, e.g. delspan class=\"amount\"#36;nbsp;3.00/span/del insspan class=\"amount\"#36;nbsp;2.00/span/ins 
        /// read-only
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string price_html { get; set; }

        /// <summary>
        /// Show if the product is taxable or not 
        /// read-only
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public bool? taxable { get; set; }

        /// <summary>
        /// Tax status. The options are: taxable, shipping (Shipping only) and none
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string tax_status { get; set; }

        /// <summary>
        /// Tax class
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string tax_class { get; set; }

        /// <summary>
        /// Enable stock management at product level
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public bool? managing_stock { get; set; }

        /// <summary>
        /// Stock quantity. If is a variable product this value will be used to control stock for all variations, unless you define stock at variation level.
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public int? stock_quantity { get; set; }

        /// <summary>
        /// Controls whether or not the product is listed as “in stock” or “out of stock” on the frontend.
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public bool? in_stock { get; set; }

        /// <summary>
        /// Shows if backorders are allowed 
        /// read-only
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public bool? backorders_allowed { get; set; }

        /// <summary>
        /// Shows if a product is on backorder (if the product have the stock_quantity negative) 
        /// read-only
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public bool? backordered { get; set; }

        /// <summary>
        /// If managing stock, this controls whether or not backorders are allowed. If enabled, stock quantity can go below 0. The options are: false (Do not allow), notify (Allow, but notify customer), and true (Allow) 
        /// write-only
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public object backorders { get; set; }

        /// <summary>
        /// When true this only allow one item to be bought in a single order
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public bool? sold_individually { get; set; }

        /// <summary>
        /// Shows if the product can be bought 
        /// read-only
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public bool? purchaseable { get; set; }

        /// <summary>
        /// Featured Product
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public bool? featured { get; set; }

        /// <summary>
        /// Shows whether or not the product is visible in the catalog 
        /// read-only
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public bool? visible { get; set; }

        /// <summary>
        /// Catalog visibility. The following options are available: visible (Catalog and search), catalog (Only in catalog), search (Only in search) and hidden (Hidden from all). Default is visible
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string catalog_visibility { get; set; }

        /// <summary>
        /// Shows if the product is on sale or not 
        /// read-only
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public bool? on_sale { get; set; }

        /// <summary>
        /// Product weight in decimal format
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string weight { get; set; }

        /// <summary>
        /// List of the product dimensions. See Dimensions Properties
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public DimensionList dimensions { get; set; }

        /// <summary>
        /// Shows if the product need to be shipped or not 
        /// read-only
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public bool? shipping_required { get; set; }

        /// <summary>
        /// Shows whether or not the product shipping is taxable 
        /// read-only
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public bool? shipping_taxable { get; set; }

        /// <summary>
        /// Shipping class slug. Shipping classes are used by certain shipping methods to group similar products
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string shipping_class { get; set; }

        /// <summary>
        /// Shipping class ID 
        /// read-only
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public int? shipping_class_id { get; set; }

        /// <summary>
        /// Product description
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string description { get; set; }

        /// <summary>
        /// Enable HTML for product description 
        /// write-only
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public bool? enable_html_description { get; set; }

        /// <summary>
        /// Product short description
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string short_description { get; set; }

        /// <summary>
        /// Enable HTML for product short description 
        /// write-only
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string enable_html_short_description { get; set; }

        /// <summary>
        /// Shows/define if reviews are allowed
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public bool? reviews_allowed { get; set; }

        /// <summary>
        /// Reviews average rating 
        /// read-only
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string average_rating { get; set; }

        /// <summary>
        /// Amount of reviews that the product have 
        /// read-only
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public int? rating_count { get; set; }

        /// <summary>
        /// List of related products IDs (integer) 
        /// read-only
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public List<int> related_ids { get; set; }

        /// <summary>
        /// List of up-sell products IDs (integer). Up-sells are products which you recommend instead of the currently viewed product, for example, products that are more profitable or better quality or more expensive
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public List<int> upsell_ids { get; set; }

        /// <summary>
        /// List of cross-sell products IDs. Cross-sells are products which you promote in the cart, based on the current product
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public List<int> cross_sell_ids { get; set; }

        /// <summary>
        /// Product parent ID (post_parent)
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public int? parent_id { get; set; }

        /// <summary>
        /// List of product categories names (string). In write-mode need to pass a array of categories IDs (integer) (uses wp_set_object_terms())
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public List<object> categories { get; set; }

        /// <summary>
        /// List of product tags names (string). In write-mode need to pass a array of tags IDs (integer) (uses wp_set_object_terms())
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public List<object> tags { get; set; }

        /// <summary>
        /// List of products images. See Images Properties
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public ImageList images { get; set; }

        /// <summary>
        /// Featured image URL 
        /// read-only
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string featured_src { get; set; }

        /// <summary>
        /// List of product attributes. See Attributes Properties. Note: the attribute must be registered in WooCommerce before.
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public AttributeList attributes { get; set; }

        /// <summary>
        /// Defaults variation attributes. These are the attributes that will be pre-selected on the frontend. See Default Attributes Properties 
        /// write-only
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public DefaultAttributeList default_attributes { get; set; }

        /// <summary>
        /// List of downloadable files. See Downloads Properties
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public DownloadList downloads { get; set; }

        /// <summary>
        /// Amount of times the product can be downloaded. In write-mode you can sent a blank string for unlimited re-downloads. e.g ''
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public int? download_limit { get; set; }

        /// <summary>
        /// Number of days that the customer has up to be able to download the product. In write-mode you can sent a blank string for never expiry. e.g ''
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public int? download_expiry { get; set; }

        /// <summary>
        /// Download type, this controls the schema. The available options are: '' (Standard Product), application (Application/Software) and music (Music)
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string download_type { get; set; }

        /// <summary>
        /// Optional note to send the customer after purchase.
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string purchase_note { get; set; }

        /// <summary>
        /// Amount of sales 
        /// read-only
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public int? total_sales { get; set; }

        /// <summary>
        /// List of products variations. See Variations Properties
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public VariationList variations { get; set; }

        /// <summary>
        /// List the product parent data when query for a variation 
        /// read-only
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public List<object> parent { get; set; }

        /// <summary>
        /// Product external URL. Only for external products 
        /// write-only
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string product_url { get; set; }

        /// <summary>
        /// Product external button text. Only for external products 
        /// write-only
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string button_text { get; set; }

        /// <summary>
        /// Menu order, used to custom sort products
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public int? menu_order { get; set; }
    }


    [CollectionDataContract]
    public class DimensionList : List<Dimension>
    {
        [DataMember]
        public List<Dimension> dimensions { get; set; }
    }

    [DataContract]
    public class Dimension
    {
        /// <summary>
        /// Product length in decimal format
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string length { get; set; }

        /// <summary>
        /// Product width in decimal format
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string width { get; set; }

        /// <summary>
        /// Product height in decimal format
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string height { get; set; }

        /// <summary>
        /// Product name 
        /// read-only
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string unit { get; set; }

    }


    [CollectionDataContract]
    public class ImageList : List<Image>
    {
        [DataMember]
        public List<Image> images { get; set; }
    }

    [DataContract]
    public class Image
    {
        /// <summary>
        /// Image ID (attachment ID)
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public int? id { get; set; }

        /// <summary>
        /// UTC DateTime when the image was created 
        /// read-only
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public DateTime? created_at { get; set; }

        /// <summary>
        /// UTC DateTime when the image was last updated 
        /// read-only
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public DateTime? updated_at { get; set; }

        /// <summary>
        /// Image URL. In write-mode you can use to send new images
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string src { get; set; }

        /// <summary>
        /// Image title (attachment title)
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string title { get; set; }

        /// <summary>
        /// Image alt text (attachment image alt text)
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string alt { get; set; }

        /// <summary>
        /// Image position. 0 means that the image is featured
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public int? position { get; set; }
    }


    [CollectionDataContract]
    public class AttributeList : List<Attribute>
    {
        [DataMember]
        public List<Attribute> attributes { get; set; }
    }

    [DataContract]
    public class Attribute
    {
        /// <summary>
        /// Attribute name 
        /// required
        /// </summary>
        [DataMember(EmitDefaultValue = false, IsRequired = true)]
        public string name { get; set; }

        /// <summary>
        /// Attribute slug
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string slug { get; set; }

        /// <summary>
        /// Attribute position
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public int? position { get; set; }

        /// <summary>
        /// Shows/define if the attribute is visible on the “Additional Information” tab in the product’s page
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public bool visible { get; set; }

        /// <summary>
        /// Shows/define if the attribute can be used as variation
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public bool variation { get; set; }

        /// <summary>
        /// List of available term names of the attribute
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public List<string> options { get; set; }
    }


    [CollectionDataContract]
    public class DefaultAttributeList : List<DefaultAttribute>
    {
        [DataMember]
        public List<DefaultAttribute> default_attributes { get; set; }
    }

    [DataContract]
    public class DefaultAttribute
    {
        /// <summary>
        /// Attribute name
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string name { get; set; }

        /// <summary>
        /// Attribute slug
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string slug { get; set; }

        /// <summary>
        /// Selected term name of the attribute
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string option { get; set; }

    }


    [CollectionDataContract]
    public class DownloadList : List<Download>
    {
        [DataMember]
        public List<Download> downloads { get; set; }
    }

    [DataContract]
    public class Download
    {
        /// <summary>
        /// File ID (file md5 hash) 
        /// read-only
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string id { get; set; }

        /// <summary>
        /// File name
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string name { get; set; }

        /// <summary>
        /// File URL. In write-mode you can use this property to send new files
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string file { get; set; }
    }


    [CollectionDataContract]
    public class VariationList : List<Variation>
    {
        [DataMember]
        public List<Variation> variations { get; set; }
    }

    [DataContract]
    public class Variation
    {
        /// <summary>
        /// Variation ID (post ID) 
        /// read-only
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public int? id { get; set; }

        /// <summary>
        /// UTC DateTime when the variation was created 
        /// read-only
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public DateTime? created_at { get; set; }

        /// <summary>
        /// UTC DateTime when the variation was last updated 
        /// read-only
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public DateTime? updated_at { get; set; }

        /// <summary>
        /// If the variation is downloadable or not. Downloadable variations give access to a file upon purchase
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public bool? downloadable { get; set; }

        /// <summary>
        /// If the variation is virtual or not. Virtual variations are intangible and aren’t shipped
        /// </summary>
        [DataMember(EmitDefaultValue = false, Name = "virtual")]
        public bool? isvirtual { get; set; }

        /// <summary>
        /// Variation URL (post permalink) 
        /// read-only
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string permalink { get; set; }

        /// <summary>
        /// SKU refers to a Stock-keeping unit, a unique identifier for each distinct product and service that can be purchased
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string sku { get; set; }

        /// <summary>
        /// Current variation price. This is setted from regular_price and sale_price 
        /// read-only
        /// </summary>
        [DataMember(EmitDefaultValue = false, Name = "price")]
        private object priceValue { get; set; }
        public decimal? price { get; set; }

        /// <summary>
        /// Variation regular price
        /// </summary>
        [DataMember(EmitDefaultValue = false, Name = "regular_price")]
        private object regular_priceValue { get; set; }
        public decimal? regular_price { get; set; }

        /// <summary>
        /// Variation sale price
        /// </summary>
        [DataMember(EmitDefaultValue = false, Name = "sale_price")]
        private object sale_priceValue { get; set; }
        public decimal? sale_price { get; set; }

        /// <summary>
        /// Sets the sale start date. Date in the YYYY-MM-DD format 
        /// write-only
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string sale_price_dates_from { get; set; }

        /// <summary>
        /// Sets the sale end date. Date in the YYYY-MM-DD format 
        /// write-only
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string sale_price_dates_to { get; set; }

        /// <summary>
        /// Show if the variation is taxable or not 
        /// read-only
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public bool? taxable { get; set; }

        /// <summary>
        /// Tax status. The options are: taxable, shipping (Shipping only) and none
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string tax_status { get; set; }

        /// <summary>
        /// Tax class
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string tax_class { get; set; }

        /// <summary>
        /// Enable stock management at variation level
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public bool? managing_stock { get; set; }

        /// <summary>
        /// Stock quantity. If is a variable variation this value will be used to control stock for all variations, unless you define stock at variation level.
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public int? stock_quantity { get; set; }

        /// <summary>
        /// Controls whether or not the variation is listed as “in stock” or “out of stock” on the frontend.
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public bool? in_stock { get; set; }

        /// <summary>
        /// Shows if a variation is on backorder (if the variation have the stock_quantity negative) 
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
        /// Shows whether or not the product parent is visible in the catalog 
        /// read-only
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public bool? visible { get; set; }

        /// <summary>
        /// Shows if the variation is on sale or not 
        /// read-only
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public bool? on_sale { get; set; }

        /// <summary>
        /// Variation weight in decimal format
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string weight { get; set; }

        /// <summary>
        /// List of the variation dimensions. See Dimensions Properties
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public DimensionList dimensions { get; set; }

        /// <summary>
        /// Shipping class slug. Shipping classes are used by certain shipping methods to group similar products
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string shipping_class { get; set; }

        /// <summary>
        /// Shipping class ID 
        /// read-only
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public int? shipping_class_id { get; set; }

        /// <summary>
        /// Variation featured image. Only position 0 will be used. See Images Properties
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public ImageList image { get; set; }

        /// <summary>
        /// List of variation attributes. Similar to a simple or variable product, but for variation indicate the attributes used to form the variation. See Attributes Properties
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public AttributeList attributes { get; set; }

        /// <summary>
        /// List of downloadable files. See Downloads Properties
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public DownloadList downloads { get; set; }

        /// <summary>
        /// Amount of times the variation can be downloaded. In write-mode you can sent a blank string for unlimited re-downloads. e.g ''
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public int? download_limit { get; set; }

        /// <summary>
        /// Number of days that the customer has up to be able to download the varition. In write-mode you can sent a blank string for never expiry. e.g ''
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public int? download_expiry { get; set; }
    }

    [DataContract]
    public class ProductAttribute
    {
        /// <summary>
        /// Attribute ID 
        /// read-only
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public int? id { get; set; }

        /// <summary>
        /// Attribute name
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string name { get; set; }

        /// <summary>
        /// Attribute slug
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string slug { get; set; }

        /// <summary>
        /// Attribute type, the types available include by default are: select and text (some plugins can include new types)
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string type { get; set; }

        /// <summary>
        /// Default sort order. Available: menu_order, name, name_num and id
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string order_by { get; set; }

        /// <summary>
        /// Enable/Disable attribute archives
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public bool? has_archives { get; set; }


    }

    [DataContract]
    public class ProductAttributeTerm
    {
        /// <summary>
        /// Term ID (term ID) 
        /// read-only
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public int? id { get; set; }

        /// <summary>
        /// Term name 
        /// required
        /// </summary>
        [DataMember(EmitDefaultValue = false, IsRequired = true)]
        public string name { get; set; }

        /// <summary>
        /// Term slug
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string slug { get; set; }

        /// <summary>
        /// Shows the quantity of products in this term 
        /// read-only
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public int? count { get; set; }
    }


    [CollectionDataContract]
    public class ProductCategoryList : List<Product_Category>
    {
        [DataMember]
        public List<Product_Category> product_categories { get; set; }
    }

    [DataContract]
    public class Product_Category
    {
        /// <summary>
        /// Category ID (term ID) 
        /// read-only
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public int? id { get; set; }

        /// <summary>
        /// Category name 
        /// required
        /// </summary>
        [DataMember(EmitDefaultValue = false, IsRequired = true)]
        public string name { get; set; }

        /// <summary>
        /// Category slug
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string slug { get; set; }

        /// <summary>
        /// Category parent
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public int? parent { get; set; }

        /// <summary>
        /// Category description
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string description { get; set; }

        /// <summary>
        /// Category archive display type, the types available include: default, products, subcategories and both
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string display { get; set; }

        /// <summary>
        /// Category image URL
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string image { get; set; }

        /// <summary>
        /// Shows the quantity of products in this category 
        /// read-only
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public int? count { get; set; }
    }

    [DataContract]
    public class ShippingClass
    {
        /// <summary>
        /// Shipping Class ID (term ID) 
        /// read-only
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public int? id { get; set; }

        /// <summary>
        /// Shipping Class name 
        /// required
        /// </summary>
        [DataMember(EmitDefaultValue = false, IsRequired = true)]
        public string name { get; set; }

        /// <summary>
        /// Shipping Class slug
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string slug { get; set; }

        /// <summary>
        /// Shipping Class parent
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public int? parent { get; set; }

        /// <summary>
        /// Shipping Class description
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string description { get; set; }

        /// <summary>
        /// Shows the quantity of products in this shipping class 
        /// read-only
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public int? count { get; set; }
    }

    [DataContract]
    public class ProductTag
    {
        /// <summary>
        /// Tag ID (term ID) 
        /// read-only
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public int? id { get; set; }

        /// <summary>
        /// Tag name 
        /// required
        /// </summary>
        [DataMember(EmitDefaultValue = false, IsRequired = true)]
        public string name { get; set; }

        /// <summary>
        /// Tag slug
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string slug { get; set; }

        /// <summary>
        /// Tag description
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string description { get; set; }

        /// <summary>
        /// Shows the quantity of products in this tag 
        /// read-only
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public int? count { get; set; }
    }


    [CollectionDataContract]
    public class ProductReviewList : List<ProductReview>
    {
        [DataMember]
        public List<ProductReview> product_reviews { get; set; }
    }

    [DataContract]
    public class ProductReview
    {
        /// <summary>
        /// Review ID (comment ID) 
        /// read-only
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public int? id { get; set; }

        /// <summary>
        /// UTC DateTime when the review was created 
        /// read-only
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public DateTime? created_at { get; set; }

        /// <summary>
        /// Review rating (0 to 5) 
        /// read-only
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string rating { get; set; }

        /// <summary>
        /// Reviewer name 
        /// read-only
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string reviewer_name { get; set; }

        /// <summary>
        /// Reviewer email 
        /// read-only
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string reviewer_email { get; set; }

        /// <summary>
        /// Shows if the reviewer bought the product or not 
        /// read-only
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public bool? verified { get; set; }
    }
}
