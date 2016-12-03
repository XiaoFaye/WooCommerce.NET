WooCommerce.NET
======================

Version History
-------------------
* v0.6.0 Major update
  1. Add generic WCObject which allows you to use customize object class.
  2. Use generic batch update object.
  3. Add jsonSerializeFilter and jsonDeserializeFilter parameters in RestAPI, which allows you to manipulate the json string. What we have found is that in some server, the json string from WooCommerce has a byte order mark (BOM) and can't be deserlized.
  4. Add authorizedHeader parameter in RestAPI, which allows you to choose how to pass the username & password. What we have found is that in some server, these information can't be pass in request header.
  5. Use InvariantCulture in decimal.Parse to prevent deserlized error.
  6. Fix GetCustomerByEmail not working issue.
* v0.5.6 Minor update
  1. Fix woocommerce_rest_authentication_error issue when using parameters.
  2. Fix some desalinize errors.
* v0.5.5 Minor update
  1. Add Webhook.
  2. Fix some desalinize errors.
* v0.5.3 Minor update
  1. Fix some desalinize errors.
* v0.5.2 Minor update
  1. Fix https Authorization error.
  2. Fix some desalinize errors.
* v0.5.1 Minor update
  1. Fix the batch update issue.
* v0.5.0 Major update
  1. Supports up to Wordpress 4.5.3 and WooCommerce 2.6.2
  2. Supports latest WooCommerce Rest API and legacy (v1, v2 and v3) WooCommerce Rest API.
  3. Fix decimal, DateTime return as empty string issue.
  4. Add more API routes.
* v0.4.3 Minor update
  1. Fix total_spent type mismatch in Customer object.
  2. Add support to create/update/delete categories.
* v0.4.2 Minor update
  1. Fix issue when creating product category. NOTE: class ProductCategory has been renamed to Product_Category, please update your code accordingly.
* v0.4.1 Minor update
  1. Add https support.
* v0.4.0 Major update
  1. Remove all dependencies. NOTE: Anonymous type will not be allowed for POST or UPDATE calls anymore.
  2. Get all avaliable API routes using WCObject.GetStoreInfo(), all routes are in the WCRoutes property.
  3. Add support for ASP.NET Core 1.0, Xamarin.Android and Xamarin.iOS projects.
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
