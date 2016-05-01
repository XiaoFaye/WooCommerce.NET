WooCommerce.NET
======================

A Brief Intro
-------------------

WooCommerce.NET is a .NET library for calling WooCommerce REST API v2 & v3 in Windows 10 APP, Windows Phone APP, Windows Desktop APP and ASP.NET Web application.

[Visit WooCommerce](http://www.woothemes.com/woocommerce/)
[Visit WooCommerce REST API DOCS](http://woothemes.github.io/woocommerce-rest-api-docs/)

It's in Nuget now!!! 
[Visit Nuget](https://www.nuget.org/packages/WooCommerceNET)


If you have any question or would like to contribute to the code, please email to xiaofaye@msn.com.

Usage
-------------------

```cs
RestAPI rest = new RestAPI("http://www.yourstore.co.nz/wc-api/v3/", "<WooCommerce Key>", "<WooCommerce Secret");
WCObject wc = new WCObject(rest);
//Get all products
var products = await wc.GetProducts();

//Add new product
Product p = new Product()
            {
                name = "test product 8",
                title = "test product 8",
                description = "test product 8",
                price = 8.0M
            };
await wc.PostProduct(p);

//Update products
await wc.UpdateProducts(new Product[] { new Product { id = 128, name = "test 99" } });
await wc.UpdateProduct(128, new Product { name = "test 9" });

//Delete product
await wc.DeleteProduct(128);

//Use filters
var p = await wc.GetProducts(new Dictionary<string, string>() {
                { "fields", "id,title,description,sale_price,price,in_stock,short_description,average_rating,images" },
                { "filter[limit]", "15" } });


```

Version History
-------------------
* v0.4.2 Minor update
  1. Fix issue when creating product category.
* v0.4.1 Minor update
  1. Add https support.
* v0.4.0 Major update
  1. Remove all dependencies. NOTE: Anonymous type will not be allowed for POST or UPDATE calls anymore.
  2. Get all avaliable API routes using WCObject.GetStoreInfo(), all routes are in the WCRoutes property.
  3. Add support for ASP.NET Core 5.0, Xamarin.Android and Xamarin.iOS projects.
  4. Properties of all objects now compliant with WooCommerce REST API DOCS.
  5. Provide built-in RestAPI.SendHttpClientRequest function for your own RESTful calls.
* v0.3.1 Major update
  1. Supports WooCommerce REST API version 3.
  2. Implement POST, PUT, DELETE for most resources.
* v0.2.0 Minor update
  1. Add support for Windows Desktop application and Web application..
* v0.1.1 Minor update
  1. Use the same way to trim json string.
  2. Implement Customer Download call.
  3. Implement Order Refund call.
* v0.1 First working version
  1. Implement only GET method for most REST API calls.
  2. Supports WooCommerce REST API version 2.