WooCommerce.NET
======================

A Brief Intro
-------------------

WooCommerce.NET(Rx) is a .NET library for calling WooCommerce REST API v2 in Windows 8.1 APP or Windows Phone 8.1 APP (NOT included Desktop APP).

[Visit WooCommerce](http://www.woothemes.com/woocommerce/)
[Visit WooCommerce REST API](http://woothemes.github.io/woocommerce-rest-api-docs/)

If you have any question or would like to contribute code, please email to xiaofaye@msn.com.

Usage
-------------------

'''
RestAPI rest = new RestAPI("http://www.yourstore.co.nz/wc-api/v2/", "<WooCommerce Key>", "<WooCommerce Secret");
WCObject wc = new WCObject(rest);
var products = await wc.GetProducts();
'''

Version History
-------------------
* v0.1 First working version
  1. Implement only GET method for most REST API calls.
  2. Supports WooCommerce REST API version 2.