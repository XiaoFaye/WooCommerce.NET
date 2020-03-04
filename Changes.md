WooCommerce.NET
======================

Version History
-------------------
* v0.8.1 update
  1. Fix image upload issue while hosting with Apache.
* v0.8.0 update
  1. Fix MetaValueProcessor not working in V3 issue.
  2. Fix OrderRefund.amount wrong data type issue.
  3. Add position property to V3 ProductImage, which is missing in WooCommerce offical document.
  4. Remove WISDM Customer Specific Pricing REST API, this will be in a separate library.
* v0.7.9 update
  1. Add RequestFilter and DeserializeFilter for JWT token web request.
  2. Add enable_html_description and enable_html_short_description flags for WooCommerce Product.
  3. Add Debug mode for RestAPI. NOTE: Beware when setting Debug to True, as exceptions might contain sensetive information.
  4. Change total_sales from int (Int32) to long (Int64).
  5. Fix OrderNote can't be force deleted bug.
* v0.7.8 update
  1. Supporting Wordpress REST API with OAuth 1.0a.
  2. Supporting Wordpress REST API with JWT Authentication.
  3. Fix few minor issues.
* v0.7.7 update
  1. Supporting Wordpress REST API with OAuth 1.0a.
  2. Supporting WISDM Customer Specific Pricing REST API.
  3. Add ProductCategory Batch object.
  4. Allow to cancel a request before timeout.
  5. Fix setting all values to Null issue in UpdateWithNull.
  6. Fix decimal serialization issue in WooCommerce REST API V3.
  7. Return corresponding object in Delete function.
* v0.7.6 update
  1. Supporting WooCommerce Restful API V3.
* v0.7.5 update
  1. Avoid passing consumer secret when using http.
  2. Fixing errors when getting APIEndpoint under some cases.
  3. Allow updating with Null values in V2.
* v0.7.4 update
  1. Targeting .NET Standard 2.0.
  2. Add Batch Update for WCSubItem.
  3. Allow WCObject to use custom object in V2.
* v0.7.3 update
  1. Fix webResponseFilter not firing issue.
  2. Fix price check for inherit class issue.
  3. Return BatchObject instead of raw json string.
* v0.7.2 update
  1. Add webResponseFilter in RestAPI, which allows you to get information from the HttpWebResponse object, e.g.:X-WP-Total and X-WP-TotalPages.
  2. Fix decimal values do not be serialized as string issue.
  3. Avoid Deadlocking on the UI Thread on non-async calls.
  4. Fix Variation weight not deserialising issue.
  5. Allow calling third party Plugins restful apis.
* v0.7.1 Major update
  1. Able to override the process of SerializeJSon and DeserializeJSon.
  2. Allow to handle meta value for different return types.
  3. Handle int values when json value as empty string.
* v0.7.0 Major update
  1. Add support for WooCommerce Restful API version 2. Note: The way of making api request in v2 has been changed, please see readme file for details.
  2. Fix different decimal point parsing error.
  3. Fix manage_stock property deserializing issue.
  4. Fix issue when run in multiple parallel threads.
  5. Fix issue when reuse Dictionary parameter in request.
  6. Fix image property data type in ProductCategory.
  7. Fix issue when using filter in legacy api.
  8. Mark GetCustomerOrders as deprecated in version 1 api.
* v0.6.0 Major update
  1. Add generic WCObject which allows you to use customize object class.
  2. Use generic batch update object.
  3. Add jsonSerializeFilter and jsonDeserializeFilter parameters in RestAPI, which allows you to manipulate the json string. What we have found is that in some server, the json string from WooCommerce has a byte order mark (BOM) and can't be deserlized.
  4. Add authorizedHeader parameter in RestAPI, which allows you to choose how to pass the Credentials. What we have found is that in some server, these information can't be pass in request header.
  5. Add webRequestFilter in RestAPI, which allows you to modify the HttpWebRequest object.
  6. Add HttpWebRequestExtensions for setting restricted Headers.
  7. Only set Content Type when there is a request body.
  8. Use InvariantCulture in decimal.Parse to prevent deserlized error.
  9. Fix GetCustomerByEmail not working issue.
  10. Change data type of dimensions from List<Dimension> to Dimension in Product.cs
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
