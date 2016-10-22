using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WooCommerceNET.WooCommerce
{
    public class WCObject
    {
        private RestAPI API;
        public WCObject(RestAPI api)
        {
            if (api.IsLegacy)
                throw new Exception("You need to use the legacy WCObject on the legacy version of WooCommerce Restful API.");

            API = api;
        }

        public async Task<string> GetStoreInfo()
        {
            return await API.SendHttpClientRequest(string.Empty, RequestMethod.GET, string.Empty);
        }

        #region "customers..."

        public async Task<CustomerList> GetCustomers(Dictionary<string,string> parms = null)
        {
            string json = await API.SendHttpClientRequest("customers", RequestMethod.GET, string.Empty, parms);
            return API.DeserializeJSon<CustomerList>(json);
        }

        public async Task<Customer> GetCustomer(int id, Dictionary<string, string> parms = null)
        {
            string json = await API.SendHttpClientRequest("customers/" + id.ToString(), RequestMethod.GET, string.Empty, parms);
            return API.DeserializeJSon<Customer>(json);
        }

        public async Task<Customer> GetCustomerByEmail(string email, Dictionary<string, string> parms = null)
        {
            string json = await API.SendHttpClientRequest("customers/email/" + email, RequestMethod.GET, string.Empty, parms);
            return API.DeserializeJSon<Customer>(json);
        }

        public async Task<OrderList> GetCustomerOrders(int id, Dictionary<string, string> parms = null)
        {
            string json = await API.GetRestful("customers/" + id.ToString() + "/orders", parms);
            return API.DeserializeJSon<OrderList>(json);
        }

        public async Task<DownloadList> GetCustomerDownloads(int id, Dictionary<string, string> parms = null)
        {
            string json = await API.GetRestful("customers/" + id.ToString() + "/downloads", parms);
            return API.DeserializeJSon<DownloadList>(json);
        }

        //Don't forget to include a password when creating a customer, the example in REST API DOCS will not work!!!
        public async Task<string> PostCustomer(Customer c, Dictionary<string, string> parms = null)
        {
            return await API.SendHttpClientRequest("customers", RequestMethod.POST, c, parms);
        }

        public async Task<string> UpdateCustomer(int id, Customer c, Dictionary<string, string> parms = null)
        {
            return await API.SendHttpClientRequest("customers/" + id.ToString(), RequestMethod.POST, c, parms);
        }

        public async Task<string> UpdateCustomers(CustomerBatch cb, Dictionary<string, string> parms = null)
        {
            return await API.SendHttpClientRequest("customers/batch", RequestMethod.POST, cb, parms);
        }

        public async Task<string> DeleteCustomer(int id, Dictionary<string, string> parms = null)
        {
            return await API.SendHttpClientRequest("customers/" + id.ToString(), RequestMethod.DELETE, string.Empty, parms);
        }

        #endregion

        #region "orders..."

        public async Task<OrderList> GetOrders(Dictionary<string,string> parms = null)
        {
            string json = await API.SendHttpClientRequest("orders", RequestMethod.GET, string.Empty, parms);
            return API.DeserializeJSon<OrderList>(json);
        }

        public async Task<Order> GetOrder(int orderid, Dictionary<string, string> parms = null)
        {
            string json = await API.SendHttpClientRequest("orders/" + orderid.ToString(), RequestMethod.GET, string.Empty, parms);
            return API.DeserializeJSon<Order>(json);
        }

        public async Task<List<KeyValuePair<string, string>>> GetOrderStatuses(Dictionary<string,string> parms = null)
        {
            string json = await API.SendHttpClientRequest("orders/statuses", RequestMethod.GET, string.Empty, parms);
            json = json.Substring(20, json.Length - 22).Replace("\"", string.Empty);

            List<KeyValuePair<string, string>> statuses = new List<KeyValuePair<string, string>>();
            foreach(string status in json.Split(','))
            {
                KeyValuePair<string, string> value = new KeyValuePair<string, string>(status.Split(':')[0], status.Split(':')[1]);
                statuses.Add(value);
            }

            return statuses;
        }

        public async Task<string> PostOrder(Order c, Dictionary<string, string> parms = null)
        {
            return await API.SendHttpClientRequest("orders", RequestMethod.POST, c, parms);
        }

        public async Task<string> UpdateOrder(int id, Order c, Dictionary<string, string> parms = null)
        {
            return await API.SendHttpClientRequest("orders/" + id.ToString(), RequestMethod.PUT, c, parms);
        }

        public async Task<string> UpdateOrders(OrderBatch ob, Dictionary<string, string> parms = null)
        {
            return await API.SendHttpClientRequest("orders/batch", RequestMethod.PUT, ob, parms);
        }

        public async Task<string> DeleteOrder(int orderid, Dictionary<string, string> parms = null)
        {
            return await API.SendHttpClientRequest("orders/" + orderid.ToString(), RequestMethod.DELETE, string.Empty, parms);
        }

        #endregion

        #region "Order notes..."

        public async Task<OrderNoteList> GetOrderNotes(int id, Dictionary<string,string> parms = null)
        {
            string json = await API.SendHttpClientRequest("orders/" + id.ToString() + "/notes", RequestMethod.GET, string.Empty, parms);
            return API.DeserializeJSon<OrderNoteList>(json);
        }

        public async Task<OrderNote> GetOrderNote(int orderid, int noteid, Dictionary<string,string> parms = null)
        {
            string json = await API.SendHttpClientRequest("orders/" + orderid.ToString() + "/notes/" + noteid.ToString(), RequestMethod.GET, string.Empty, parms);
            return API.DeserializeJSon<OrderNote>(json);
        }

        public async Task<string> PostOrderNote(int orderid, OrderNote n, Dictionary<string, string> parms = null)
        {
            return await API.SendHttpClientRequest("orders/" + orderid.ToString() + "/notes", RequestMethod.POST, n, parms);
        }

        public async Task<string> UpdateOrderNote(int orderid, int noteid, OrderNote n, Dictionary<string, string> parms = null)
        {
            return await API.SendHttpClientRequest("orders/" + orderid.ToString() + "/notes/" + noteid.ToString(), RequestMethod.PUT, n, parms);
        }

        public async Task<string> DeleteOrderNote(int orderid, int noteid, Dictionary<string, string> parms = null)
        {
            return await API.SendHttpClientRequest("orders/" + orderid.ToString() + "/notes/" + noteid.ToString(), RequestMethod.DELETE, parms);
        }

        #endregion

        #region "Order refunds..."

        public async Task<OrderRefundList> GetOrderRefunds(int orderid, Dictionary<string,string> parms = null)
        {
            string json = await API.SendHttpClientRequest("orders/" + orderid.ToString() + "/refunds", RequestMethod.GET, string.Empty, parms);
            return API.DeserializeJSon<OrderRefundList>(json);
        }

        public async Task<OrderRefund> GetOrderRefund(int orderid, int refundid, Dictionary<string, string> parms = null)
        {
            string json = await API.SendHttpClientRequest("orders/" + orderid.ToString() + "/refunds/" + refundid.ToString(), RequestMethod.GET, string.Empty, parms);
            return API.DeserializeJSon<OrderRefund>(json);
        }

        public async Task<string> PostOrderRefund(int orderid, OrderRefund r, Dictionary<string, string> parms = null)
        {
            return await API.SendHttpClientRequest("orders/" + orderid.ToString() + "/refunds", RequestMethod.POST, r, parms);
        }

        public async Task<string> UpdateOrderRefund(int orderid, int refundid, OrderRefund r, Dictionary<string, string> parms = null)
        {
            return await API.SendHttpClientRequest("orders/" + orderid.ToString() + "/refunds/" + refundid.ToString(), RequestMethod.PUT, r, parms);
        }

        public async Task<string> DeleteOrderRefund(int orderid, int refundid, Dictionary<string, string> parms = null)
        {
            return await API.SendHttpClientRequest("orders/" + orderid.ToString() + "/refunds/" + refundid.ToString(), RequestMethod.DELETE, string.Empty, parms);
        }


        #endregion

        #region "products..."

        public async Task<ProductList> GetProducts(Dictionary<string,string> parms = null)
        {
            string json = await API.SendHttpClientRequest("products", RequestMethod.GET, string.Empty, parms);
            return API.DeserializeJSon<ProductList>(json);
        }

        public async Task<Product> GetProduct(int productid, Dictionary<string,string> parms = null)
        {
            string json = await API.SendHttpClientRequest("products/" + productid.ToString(), RequestMethod.GET, string.Empty, parms);
            return API.DeserializeJSon<Product>(json);
        }

        public async Task<string> PostProduct(Product p, Dictionary<string, string> parms = null)
        {
            return await API.SendHttpClientRequest("products", RequestMethod.POST, p, parms);
        }

        public async Task<string> UpdateProduct(int productid, Product p, Dictionary<string, string> parms = null)
        {
            return await API.SendHttpClientRequest("products/" + productid.ToString(), RequestMethod.PUT, p, parms);
        }

        public async Task<string> UpdateProducts(ProductBatch pb, Dictionary<string, string> parms = null)
        {
            return await API.SendHttpClientRequest("products/batch", RequestMethod.PUT, pb, parms);
        }

        public async Task<string> DeleteProduct(int productid, Dictionary<string, string> parms = null)
        {
            return await API.SendHttpClientRequest("products/" + productid.ToString(), RequestMethod.DELETE, string.Empty, parms);
        }

        #endregion

        #region "Product reviews..."

        public async Task<ProductReviewList> GetProductReviews(int productid, Dictionary<string,string> parms = null)
        {
            string json = await API.SendHttpClientRequest("products/" + productid.ToString() + "/reviews", RequestMethod.GET, string.Empty, parms);
            return API.DeserializeJSon<ProductReviewList>(json);
        }

        #endregion

        #region "Product categories..."

        public async Task<ProductCategoryList> GetProductCategories(Dictionary<string,string> parms = null)
        {
            string json = await API.SendHttpClientRequest("products/categories", RequestMethod.GET, string.Empty, parms);
            return API.DeserializeJSon<ProductCategoryList>(json);
        }

        public async Task<ProductCategory> GetProductCategory(int categoryid, Dictionary<string,string> parms = null)
        {
            string json = await API.SendHttpClientRequest("products/categories/" + categoryid.ToString(), RequestMethod.GET, string.Empty, parms);
            return API.DeserializeJSon<ProductCategory>(json);
        }

        public async Task<string> PostProductCategory(ProductCategory pc, Dictionary<string, string> parms = null)
        {
            return await API.SendHttpClientRequest("products/categories", RequestMethod.POST, pc, parms);
        }

        public async Task<string> UpdateProductCategory(int categoryid, ProductCategory pc, Dictionary<string, string> parms = null)
        {
            return await API.SendHttpClientRequest("products/categories/" + categoryid.ToString(), RequestMethod.PUT, pc, parms);
        }

        public async Task<string> UpdateProductCategories(CategoryBatch cb, Dictionary<string, string> parms = null)
        {
            return await API.SendHttpClientRequest("products/categories/batch", RequestMethod.PUT, cb, parms);
        }

        public async Task<string> DeleteProductCategory(int categoryid, Dictionary<string, string> parms = null)
        {
            return await API.SendHttpClientRequest("products/categories/" + categoryid.ToString(), RequestMethod.DELETE, string.Empty, parms);
        }

        #endregion

        #region "Product attributes..."

        public async Task<ProductAttributeList> GetProductAttributes(Dictionary<string, string> parms = null)
        {
            string json = await API.SendHttpClientRequest("products/attributes", RequestMethod.GET, string.Empty, parms);
            return API.DeserializeJSon<ProductAttributeList>(json);
        }

        public async Task<ProductAttribute> GetProductAttribute(int attributeid, Dictionary<string, string> parms = null)
        {
            string json = await API.SendHttpClientRequest("products/attributes/" + attributeid.ToString(), RequestMethod.GET, string.Empty, parms);
            return API.DeserializeJSon<ProductAttribute>(json);
        }

        public async Task<string> PostProductAttribute(ProductAttribute pa, Dictionary<string, string> parms = null)
        {
            return await API.SendHttpClientRequest("products/attributes", RequestMethod.POST, pa, parms);
        }

        public async Task<string> UpdateProductAttribute(int attributeid, ProductAttribute pa, Dictionary<string, string> parms = null)
        {
            return await API.SendHttpClientRequest("products/attributes/" + attributeid.ToString(), RequestMethod.PUT, pa, parms);
        }

        public async Task<string> UpdateProductAttributes(AttributeBatch ab, Dictionary<string, string> parms = null)
        {
            return await API.SendHttpClientRequest("products/attributes/batch", RequestMethod.PUT, ab, parms);
        }

        public async Task<string> DeleteProductAttribute(int attributeid, Dictionary<string, string> parms = null)
        {
            return await API.SendHttpClientRequest("products/attributes/" + attributeid.ToString(), RequestMethod.DELETE, string.Empty, parms);
        }

        #endregion

        #region "Product Attribute terms..."

        public async Task<ProductAttributeTermList> GetProductAttributeTerms(int attributeid, Dictionary<string, string> parms = null)
        {
            string json = await API.SendHttpClientRequest("products/attributes/" + attributeid.ToString() + "/terms", RequestMethod.GET, string.Empty, parms);
            return API.DeserializeJSon<ProductAttributeTermList>(json);
        }

        public async Task<ProductAttributeTerm> GetProductAttributeTerm(int attributeid, int termid, Dictionary<string, string> parms = null)
        {
            string json = await API.SendHttpClientRequest("products/attributes/" + attributeid.ToString() + "/terms/" + termid.ToString(), RequestMethod.GET, string.Empty, parms);
            return API.DeserializeJSon<ProductAttributeTerm>(json);
        }

        public async Task<string> PostProductAttributeTerm(int attributeid, ProductAttributeTerm t, Dictionary<string, string> parms = null)
        {
            return await API.SendHttpClientRequest("products/attributes/" + attributeid.ToString() + "/terms", RequestMethod.POST, t, parms);
        }

        public async Task<string> UpdateProductAttributeTerm(int attributeid, int termid, ProductAttributeTerm t, Dictionary<string, string> parms = null)
        {
            return await API.SendHttpClientRequest("products/attributes/" + attributeid.ToString() + "/terms/" + termid.ToString(), RequestMethod.PUT, t, parms);
        }

        public async Task<string> DeleteProductAttributeTerm(int attributeid, int termid, Dictionary<string, string> parms = null)
        {
            return await API.SendHttpClientRequest("products/attributes/" + attributeid.ToString() + "/terms/" + termid.ToString(), RequestMethod.DELETE, string.Empty, parms);
        }


        #endregion

        #region "Product Shipping class..."

        public async Task<ShippingClassList> GetProductShippingClasses(Dictionary<string, string> parms = null)
        {
            string json = await API.SendHttpClientRequest("products/shipping_classes", RequestMethod.GET, string.Empty, parms);
            return API.DeserializeJSon<ShippingClassList>(json);
        }

        public async Task<ShippingClass> GetProductShippingClass(int shippingclassid, Dictionary<string, string> parms = null)
        {
            string json = await API.SendHttpClientRequest("products/shipping_classes/" + shippingclassid.ToString(), RequestMethod.GET, string.Empty, parms);
            return API.DeserializeJSon<ShippingClass>(json);
        }

        public async Task<string> PostProductShippingClass(ShippingClass sc, Dictionary<string, string> parms = null)
        {
            return await API.SendHttpClientRequest("products/shipping_classes", RequestMethod.POST, sc, parms);
        }

        public async Task<string> UpdateProductShippingClass(int shippingclassid, ShippingClass sc, Dictionary<string, string> parms = null)
        {
            return await API.SendHttpClientRequest("products/shipping_classes/" + shippingclassid.ToString(), RequestMethod.PUT, sc, parms);
        }

        public async Task<string> UpdateProductShippingClasses(ShippingClassBatch sb, Dictionary<string, string> parms = null)
        {
            return await API.SendHttpClientRequest("products/shipping_classes/batch", RequestMethod.PUT, sb, parms);
        }

        public async Task<string> DeleteProductShippingClass(int shippingclassid, Dictionary<string, string> parms = null)
        {
            return await API.SendHttpClientRequest("products/shipping_classes/" + shippingclassid.ToString(), RequestMethod.DELETE, string.Empty, parms);
        }

        #endregion

        #region "Product tags..."

        public async Task<ProductTagList> GetProductTags(Dictionary<string, string> parms = null)
        {
            string json = await API.SendHttpClientRequest("products/tags", RequestMethod.GET, string.Empty, parms);
            return API.DeserializeJSon<ProductTagList>(json);
        }

        public async Task<ProductTag> GetProductTag(int tagid, Dictionary<string, string> parms = null)
        {
            string json = await API.SendHttpClientRequest("products/tags/" + tagid.ToString(), RequestMethod.GET, string.Empty, parms);
            return API.DeserializeJSon<ProductTag>(json);
        }

        public async Task<string> PostProductTag(ProductTag pt, Dictionary<string, string> parms = null)
        {
            return await API.SendHttpClientRequest("products/tags", RequestMethod.POST, pt, parms);
        }

        public async Task<string> UpdateProductTag(int tagid, ProductTag pt, Dictionary<string, string> parms = null)
        {
            return await API.SendHttpClientRequest("products/tags/" + tagid.ToString(), RequestMethod.PUT, pt, parms);
        }

        public async Task<string> UpdateProductTags(ProductTagBatch pb, Dictionary<string, string> parms = null)
        {
            return await API.SendHttpClientRequest("products/tags/batch", RequestMethod.PUT, pb, parms);
        }

        public async Task<string> DeleteProductTag(int tagid, Dictionary<string, string> parms = null)
        {
            return await API.SendHttpClientRequest("products/tags/" + tagid.ToString(), RequestMethod.DELETE, string.Empty, parms);
        }

        #endregion

        #region "coupons..."

        public async Task<CouponList> GetCoupons(Dictionary<string,string> parms = null)
        {
            string json = await API.SendHttpClientRequest("coupons", RequestMethod.GET, string.Empty, parms);
            return API.DeserializeJSon<CouponList>(json);
        }

        public async Task<Coupon> GetCoupon(int couponid, Dictionary<string,string> parms = null)
        {
            string json = await API.SendHttpClientRequest("coupons/" + couponid.ToString(), RequestMethod.GET, string.Empty, parms);
            return API.DeserializeJSon<Coupon>(json);
        }

        public async Task<Coupon> GetCoupon(string code, Dictionary<string,string> parms = null)
        {
            string json = await API.SendHttpClientRequest("coupons/code/" + code, RequestMethod.GET, string.Empty, parms);
            return API.DeserializeJSon<Coupon>(json);
        }

        public async Task<string> PostCoupon(Coupon c, Dictionary<string,string> parms = null)
        {
            return await API.SendHttpClientRequest("coupons", RequestMethod.POST, c, parms);
        }

        public async Task<string> UpdateCoupon(int couponid, Coupon c, Dictionary<string,string> parms = null)
        {
            return await API.SendHttpClientRequest("coupons/" + couponid.ToString(), RequestMethod.PUT, c, parms);
        }

        public async Task<string> UpdateCoupons(CouponBatch cb, Dictionary<string,string> parms = null)
        {
            return await API.SendHttpClientRequest("coupons/batch", RequestMethod.PUT, cb, parms);
        }

        public async Task<string> DeleteCoupon(int couponid, Dictionary<string,string> parms = null)
        {
            return await API.SendHttpClientRequest("coupons/" + couponid.ToString(), RequestMethod.DELETE, string.Empty, parms);
        }

        #endregion

        #region "Tax rates..."

        public async Task<TaxRateList> GetTaxRates(Dictionary<string, string> parms = null)
        {
            string json = await API.SendHttpClientRequest("taxes", RequestMethod.GET, string.Empty, parms);
            return API.DeserializeJSon<TaxRateList>(json);
        }

        public async Task<TaxRate> GetTaxRate(int taxRateid, Dictionary<string, string> parms = null)
        {
            string json = await API.SendHttpClientRequest("taxes/" + taxRateid.ToString(), RequestMethod.GET, string.Empty, parms);
            return API.DeserializeJSon<TaxRate>(json);
        }
        
        public async Task<string> PostTaxRate(TaxRate t, Dictionary<string, string> parms = null)
        {
            return await API.SendHttpClientRequest("taxes", RequestMethod.POST, t, parms);
        }

        public async Task<string> UpdateTaxRate(int taxrateid, TaxRate t, Dictionary<string, string> parms = null)
        {
            return await API.SendHttpClientRequest("taxes/" + taxrateid.ToString(), RequestMethod.PUT, t, parms);
        }

        public async Task<string> UpdateTaxRates(TaxRateBatch tb, Dictionary<string, string> parms = null)
        {
            return await API.SendHttpClientRequest("taxes/batch", RequestMethod.PUT, tb, parms);
        }

        public async Task<string> DeleteTaxRate(int taxrateid, Dictionary<string, string> parms = null)
        {
            return await API.SendHttpClientRequest("taxes/" + taxrateid.ToString(), RequestMethod.DELETE, string.Empty, parms);
        }

        #endregion

        #region "Tax classes..."

        public async Task<TaxClassList> GetTaxClasses(Dictionary<string, string> parms = null)
        {
            string json = await API.SendHttpClientRequest("taxes/classes", RequestMethod.GET, string.Empty, parms);
            return API.DeserializeJSon<TaxClassList>(json);
        }

        public async Task<string> PostTaxClass(TaxClass t, Dictionary<string, string> parms = null)
        {
            return await API.SendHttpClientRequest("taxes/classes", RequestMethod.POST, t, parms);
        }
        
        public async Task<string> DeleteTaxClass(string slug, Dictionary<string, string> parms = null)
        {
            return await API.SendHttpClientRequest("taxes/" + slug, RequestMethod.DELETE, string.Empty, parms);
        }

        #endregion

        #region "reports..."

        public async Task<ReportList> GetReports(Dictionary<string,string> parms = null)
        {
            string json = await API.SendHttpClientRequest("reports", RequestMethod.GET, string.Empty, parms);
            return API.DeserializeJSon<ReportList>(json);
        }

        public async Task<SalesReportList> GetSalesReport(Dictionary<string,string> parms = null)
        {
            string json = await API.SendHttpClientRequest("reports/sales", RequestMethod.GET, string.Empty, parms);
            return API.DeserializeJSon<SalesReportList>(json);
        }

        public async Task<TopSellersReport> GetTopSellerReport(Dictionary<string,string> parms = null)
        {
            string json = await API.SendHttpClientRequest("reports/sales/top_sellers", RequestMethod.GET, string.Empty, parms);
            return API.DeserializeJSon<TopSellersReport>(json);
        }

        #endregion

        #region "webhooks..."

        public async Task<WebhookList> GetWebhooks(Dictionary<string,string> parms = null)
        {
            string json = await API.SendHttpClientRequest("webhooks", RequestMethod.GET, string.Empty, parms);
            return API.DeserializeJSon<WebhookList>(json);
        }

        public async Task<Webhook> GetWebhook(int id, Dictionary<string,string> parms = null)
        {
            string json = await API.SendHttpClientRequest("webhooks/" + id.ToString(), RequestMethod.GET, string.Empty, parms);
            return API.DeserializeJSon<Webhook>(json);
        }

        public async Task<string> PostWebhook(Webhook obj, Dictionary<string, string> parms = null)
        {
            return await API.SendHttpClientRequest("webhooks", RequestMethod.POST, obj, parms);
        }

        public async Task<string> UpdateWebhook(int webhookid, Webhook obj, Dictionary<string, string> parms = null)
        {
            return await API.SendHttpClientRequest("webhooks/" + webhookid.ToString(), RequestMethod.PUT, obj, parms);
        }

        public async Task<string> UpdateWebhooks(WebhookBatch obj, Dictionary<string, string> parms = null)
        {
            return await API.SendHttpClientRequest("webhooks/batch", RequestMethod.PUT, obj, parms);
        }

        public async Task<string> DeleteWebhook(int webhookid, Dictionary<string, string> parms = null)
        {
            return await API.SendHttpClientRequest("webhooks/" + webhookid.ToString(), RequestMethod.DELETE, string.Empty, parms);
        }

        public async Task<WebhookDeliveryList> GetWebhookDeliveries(int webhookid, Dictionary<string,string> parms = null)
        {
            string json = await API.SendHttpClientRequest("webhooks/" + webhookid.ToString() + "/deliveries", RequestMethod.GET, string.Empty, parms);
            return API.DeserializeJSon<WebhookDeliveryList>(json);
        }

        public async Task<WebhookDelivery> GetWebhookDelivery(int webhookid, int deliveryid, Dictionary<string,string> parms = null)
        {
            string json = await API.GetRestful("webhooks/" + webhookid.ToString() + "/deliveries/" + deliveryid.ToString(), parms);
            return API.DeserializeJSon<WebhookDelivery>(json);
        }

        #endregion
    }
}
