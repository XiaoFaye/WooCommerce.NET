WooCommerce.NET
======================

A Brief Intro
-------------------

WooCommerce.NET is a .NET library for calling WooCommerce REST API in any .NET applications.

[Visit WooCommerce](http://www.woothemes.com/woocommerce/)
[Visit WooCommerce REST API DOCS](https://woocommerce.github.io/woocommerce-rest-api-docs/)

[![NuGet](https://buildstats.info/nuget/WooCommerceNET)](http://www.nuget.org/packages/WooCommerceNET)

* [How to use JSON.NET in WooCommerce.NET](https://github.com/XiaoFaye/WooCommerce.NET/wiki/How-to-use-JSON.NET-in-WooCommerce.NET)
* [Handle different types of Meta Value in WC Restful API V2](https://github.com/XiaoFaye/WooCommerce.NET/wiki/Handle-different-types-of-Meta-Value-in-WC-Restful-API-V2)

Usage
-------------------

```cs
using WooCommerceNET.WooCommerce.v2;
using WooCommerceNET.WooCommerce.v2.Extension;

RestAPI rest = new RestAPI("http://www.yourstore.co.nz/wp-json/wc/v2/", "<WooCommerce Key>", "<WooCommerce Secret");
WCObject wc = new WCObject(rest);

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



Usage (Legacy & V1 API)
-------------------

```cs
//Legacy way of calling WooCommerce REST API
//using WooCommerceNET.WooCommerce.Legacy;
//
//RestAPI rest = new RestAPI("http://www.yourstore.co.nz/wc-api/v3/", "<WooCommerce Key>", "<WooCommerce Secret");
//WooCommerceNET.WooCommerce.Legacy.WCObject wc = new WooCommerceNET.WooCommerce.Legacy.WCObject(rest);

using WooCommerceNET.WooCommerce.v1;

RestAPI rest = new RestAPI("http://www.yourstore.co.nz/wp-json/wc/v1/", "<WooCommerce Key>", "<WooCommerce Secret");
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
await wc.UpdateProduct(128, new Product { name = "test 9" });

//Delete product
await wc.DeleteProduct(128);

//Use parameters
var p = await wc.GetProducts(new Dictionary<string, string>() {
                { "include", "10, 11, 12, 13, 14, 15" },
                { "per_page", "15" } });


//Batch update
CustomerBatch cb = new CustomerBatch();

CustomerList create = new CustomerList();
create.Add(new Customer()
{
    first_name = "first",
    last_name = "last",
    email = "first@lastsss.com",
    username = "firstnlast",
    password = "12345"
});

CustomerList update = new CustomerList();
update.Add(new Customer()
{
    id = 4,
    last_name = "xu2"
});

List<int> delete = new List<int>() { 8 };

cb.create = create;
cb.update = update;
cb.delete = delete;

var c = await wc.UpdateCustomers(cb);

```
