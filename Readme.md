WooCommerce.NET
======================

A Brief Intro
-------------------

WooCommerce.NET is a .NET library for calling WooCommerce/WordPress REST API with OAuth/JWT in .NET applications.

* [Visit WooCommerce](http://www.woothemes.com/woocommerce/)
* [Visit WooCommerce REST API DOCS](https://woocommerce.github.io/woocommerce-rest-api-docs/)
* [Visit WordPress REST API DOCS](https://developer.wordpress.org/rest-api/)

[![NuGet](https://buildstats.info/nuget/WooCommerceNET)](http://www.nuget.org/packages/WooCommerceNET)

If this project has been helpful for you and you want to support it, please consider [Buying me a coffee](https://www.buymeacoffee.com/YU0SqVyrR):coffee:

**For priority paid support/consulting service, customized REST API development and plugins REST API development, please email to [James (me:sunglasses:)](mailto:xiaofaye@msn.com), thank you!**

Usage (WooCommerce REST API)
-------------------
* [How to use JSON.NET in WooCommerce.NET](https://github.com/XiaoFaye/WooCommerce.NET/wiki/How-to-use-JSON.NET-in-WooCommerce.NET)
* [Specifiy user agent when making requests to WooCommerce](https://github.com/XiaoFaye/WooCommerce.NET/wiki/Specifiy-user-agent-when-making-requests-to-WooCommerce)
* [How to use webRequestFilter and webResponseFilter in WooCommerce.NET](https://github.com/XiaoFaye/WooCommerce.NET/wiki/How-to-use-webRequestFilter-and-webResponseFilter-in-WooCommerce.NET)
* [Use X HTTP MethodOverride header for DELETE PUT](https://github.com/XiaoFaye/WooCommerce.NET/wiki/Use-X-HTTP-MethodOverride-header-for-DELETE-PUT)
* [Handle different types of Meta Value in WC Restful API V2](https://github.com/XiaoFaye/WooCommerce.NET/wiki/Handle-different-types-of-Meta-Value-in-WC-Restful-API-V2)

<details open>
  <summary>Click to expand/collapse details...</summary>
  
```cs
using WooCommerceNET.WooCommerce.v3;
using WooCommerceNET.WooCommerce.v3.Extension;

RestAPI rest = new RestAPI("http://www.yourstore.co.nz/wp-json/wc/v3/", "<WooCommerce Key>", "<WooCommerce Secret");
WCObject wc = new WCObject(rest);

//Use below code for WCObject only if you would like to have different CultureInfo
WCObject wc = new WCObject(rest, CultureInfo.GetCultureInfo("de-DE"));

//Get all products
var products = await wc.Product.GetAll();

//Add new product
Product p = new Product()
            {
                name = "test product 8",
                title = "test product 8",
                description = "test product 8",
                price = 8.0M
            };
await wc.Product.Add(p);

//Update products with new values
await wc.Product.Update(128, new Product { name = "test 9" });

//Update products with Null values
await wc.Product.UpdateWithNull(128, new { name = "test 9", weight = "", date_on_sale_from = "", date_on_sale_to = "" });

//Delete product
await wc.Product.Delete(128);

//Use parameters
var p = await wc.Product.GetAll(new Dictionary<string, string>() {
                { "include", "10, 11, 12, 13, 14, 15" },
                { "per_page", "15" } });


//Batch add/update/delete
CustomerBatch cb = new CustomerBatch();

List<Customer> create = new List<Customer>();
create.Add(new Customer()
{
    first_name = "first",
    last_name = "last",
    email = "first@lastsss.com",
    username = "firstnlast",
    password = "12345"
});

List<Customer> update = new List<Customer>();
update.Add(new Customer()
{
    id = 4,
    last_name = "xu2"
});

List<int> delete = new List<int>() { 8 };
cb.create = create;
cb.update = update;
cb.delete = delete;

var c = await wc.Customer.UpdateRange(cb);

```
</details>


Usage (WordPress REST API - JWT/OAuth Authentication)
-------------------
* [How to setup Restful API via JWT Authentication in WordPress](https://github.com/XiaoFaye/WooCommerce.NET/wiki/How-to-setup-Restful-API-via-JWT-Authentication-in-WordPress)
* [How to setup Restful API via OAuth 1.0a in WordPress](https://github.com/XiaoFaye/WooCommerce.NET/wiki/How-to-setup-Restful-API-via-OAuth-1.0a-in-WordPress)

<details>
  <summary>Click to expand/collapse details...</summary>

```cs

//using JWT
RestAPI rest = new RestAPI("http://www.yourstore.co.nz/wp-json/jwt-auth/v1/token", "<UserName>", "<Password>");

//using OAuth
RestAPI rest = new RestAPI("http://www.yourstore.co.nz/wp-json/wp/v2/", "<Client_Key>", "<Client_Secret>");
rest.oauth_token = "<OAuth_Token>";
rest.oauth_token_secret = "<OAuth_Token_Secret>";

WPObject wp = new WPObject(rest);

//Get all posts
var posts = await wp.Post.GetAll();

//Add a post
var p = new Posts()
{
    title = "abc",
    content = "<h1>abc</h1>"
};

await wp.Post.Add(p);

//Update post with new values
await wp.Post.Update(123, new { title = "new post" });

//Delete a post
await wp.Post.Delete(123);

//Upload an image
await wp.Media.Add("imagename.jpg", @"C:\path\to\image\file.jpg");

//Create a new user
await wp.Users.Add(new Users()
{
    first_name = "test",
    last_name = "test",
    name = "test",
    username = "test123",
    email = "test123@gmail.com",
    password = "test@12345"
});

```
</details>