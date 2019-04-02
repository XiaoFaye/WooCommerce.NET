using System;
using System.Runtime.Serialization;
using WooCommerceNET.Base;

namespace WooCommerceNET.WooCommerce.v3
{
    public class ProductCategoryBatch : BatchObject<ProductCategory> { }

    [DataContract]
    public class ProductCategory : v2.ProductCategory { }

    [DataContract]
    public class ProductCategoryImage : v2.ProductCategoryImage { }
}
