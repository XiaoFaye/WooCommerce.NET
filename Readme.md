WooCommerce.NET
======================

A Brief Intro
-------------------

WooCommerce.NET is a .NET library for calling WooCommerce REST API in any .NET applications.

[Visit WooCommerce](http://www.woothemes.com/woocommerce/)
[Visit WooCommerce REST API DOCS](http://woothemes.github.io/woocommerce-rest-api-docs/)

It's in Nuget now!!! 
[Visit Nuget](https://www.nuget.org/packages/WooCommerceNET)


Usage
-------------------

```cs
//Legacy way of calling WooCommerce REST API
//RestAPI rest = new RestAPI("http://www.yourstore.co.nz/wc-api/v3/", "<WooCommerce Key>", "<WooCommerce Secret");
//WooCommerceNET.WooCommerce.Legacy.WCObject wc = new WooCommerceNET.WooCommerce.Legacy.WCObject(rest);

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
await wc.UpdateProducts(new Product[] { new Product { id = 128, name = "test 99" } });
await wc.UpdateProduct(128, new Product { name = "test 9" });

//Delete product
await wc.DeleteProduct(128);

//Use filters
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
