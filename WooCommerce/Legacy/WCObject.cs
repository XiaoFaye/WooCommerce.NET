using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WooCommerceNET.Base;

namespace WooCommerceNET.WooCommerce.Legacy
{
    public class WCObject
    {
        private RestAPI API;
        public WCObject(RestAPI api)
        {
            if (!api.IsLegacy)
                throw new Exception("Please use WooCommerce Restful API Legacy version url for this WCObject. e.g.: http://www.yourstore.co.nz/wc-api/v3/");

            API = api;
        }

        public async Task<Store> GetStoreInfo()
        {
            string json = await API.SendHttpClientRequest(string.Empty, RequestMethod.GET, string.Empty).ConfigureAwait(false);
            json = json.Substring(json.IndexOf(':') + 1, json.Length - json.IndexOf(':') - 2);
            Store store = API.DeserializeJSon<Store>(json);
            store.WCRoutes = store.GetRoutes(json);
            return store;
        }

        #region "customers..."

        public async Task<CustomerList> GetCustomers(Dictionary<string,string> parms = null)
        {
            string json = await API.SendHttpClientRequest("customers", RequestMethod.GET, string.Empty, parms).ConfigureAwait(false);
            json = json.Substring(json.IndexOf(':') + 1, json.Length - json.IndexOf(':') - 2); 
            return API.DeserializeJSon<CustomerList>(json);
        }

        public async Task<int> GetCustomerCount(Dictionary<string, string> parms = null)
        {
            string json = await API.SendHttpClientRequest("customers/count", RequestMethod.GET, string.Empty, parms).ConfigureAwait(false);
            return int.Parse(json.Substring(json.IndexOf(':') + 1, json.IndexOf('}') - json.IndexOf(':') - 1).Trim('"'));
        }

        public async Task<Customer> GetCustomer(int id, Dictionary<string, string> parms = null)
        {
            string json = await API.SendHttpClientRequest("customers/" + id.ToString(), RequestMethod.GET, string.Empty, parms).ConfigureAwait(false);
            json = json.Substring(json.IndexOf(':') + 1, json.Length - json.IndexOf(':') - 2);
            return API.DeserializeJSon<Customer>(json);
        }

        public async Task<Customer> GetCustomerByEmail(string email, Dictionary<string, string> parms = null)
        {
            string json = await API.SendHttpClientRequest("customers/email/" + email, RequestMethod.GET, string.Empty, parms).ConfigureAwait(false);
            json = json.Substring(json.IndexOf(':') + 1, json.Length - json.IndexOf(':') - 2);
            return API.DeserializeJSon<Customer>(json);
        }

        public async Task<OrderList> GetCustomerOrders(int id, Dictionary<string, string> parms = null)
        {
            string json = await API.GetRestful("customers/" + id.ToString() + "/orders", parms).ConfigureAwait(false);
            json = json.Substring(json.IndexOf(':') + 1, json.Length - json.IndexOf(':') - 2);
            return API.DeserializeJSon<OrderList>(json);
        }

        public async Task<DownloadList> GetCustomerDownloads(int id, Dictionary<string, string> parms = null)
        {
            string json = await API.GetRestful("customers/" + id.ToString() + "/downloads", parms).ConfigureAwait(false);
            json = json.Substring(json.IndexOf(':') + 1, json.Length - json.IndexOf(':') - 2);
            return API.DeserializeJSon<DownloadList>(json);
        }

        //Don't forget to include a password when creating a customer, the example in REST API DOCS will not work!!!
        public async Task<string> PostCustomer(Customer c, Dictionary<string, string> parms = null)
        {
            return await API.SendHttpClientRequest("customers", RequestMethod.POST, c, parms).ConfigureAwait(false);
        }

        public async Task<string> UpdateCustomer(int id, Customer c, Dictionary<string, string> parms = null)
        {
            return await API.SendHttpClientRequest("customers/" + id.ToString(), RequestMethod.POST, c, parms).ConfigureAwait(false);
        }

        public async Task<string> UpdateCustomers(Customer[] cs, Dictionary<string, string> parms = null)
        {
            return await API.SendHttpClientRequest("customers/bulk", RequestMethod.POST, cs, parms).ConfigureAwait(false);
        }

        public async Task<string> DeleteCustomer(int id, Dictionary<string, string> parms = null)
        {
            return await API.SendHttpClientRequest("customers/" + id.ToString(), RequestMethod.DELETE, string.Empty, parms).ConfigureAwait(false);
        }

        #endregion

        #region "orders..."

        public async Task<OrderList> GetOrders(Dictionary<string,string> parms = null)
        {
            string json = await API.SendHttpClientRequest("orders", RequestMethod.GET, string.Empty, parms).ConfigureAwait(false);
            json = json.Substring(json.IndexOf(':') + 1, json.Length - json.IndexOf(':') - 2);
            return API.DeserializeJSon<OrderList>(json);
        }

        public async Task<int> GetOrderCount(Dictionary<string,string> parms = null)
        {
            string json = await API.SendHttpClientRequest("orders/count", RequestMethod.GET, string.Empty, parms).ConfigureAwait(false);
            return int.Parse(json.Substring(json.IndexOf(':') + 1, json.IndexOf('}') - json.IndexOf(':') - 1).Trim('"'));
        }

        public async Task<Order> GetOrder(int orderid, Dictionary<string, string> parms = null)
        {
            string json = await API.SendHttpClientRequest("orders/" + orderid.ToString(), RequestMethod.GET, string.Empty, parms).ConfigureAwait(false);
            json = json.Substring(json.IndexOf(':') + 1, json.Length - json.IndexOf(':') - 2);
            return API.DeserializeJSon<Order>(json);
        }

        public async Task<List<KeyValuePair<string, string>>> GetOrderStatuses(Dictionary<string,string> parms = null)
        {
            string json = await API.SendHttpClientRequest("orders/statuses", RequestMethod.GET, string.Empty, parms).ConfigureAwait(false);
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
            return await API.SendHttpClientRequest("orders", RequestMethod.POST, c, parms).ConfigureAwait(false);
        }

        public async Task<string> UpdateOrder(int id, Order c, Dictionary<string, string> parms = null)
        {
            return await API.SendHttpClientRequest("orders/" + id.ToString(), RequestMethod.PUT, c, parms).ConfigureAwait(false);
        }

        public async Task<string> UpdateOrders(Order[] cs, Dictionary<string, string> parms = null)
        {
            return await API.SendHttpClientRequest("orders/bulk", RequestMethod.PUT, cs, parms).ConfigureAwait(false);
        }

        public async Task<string> DeleteOrder(int orderid, Dictionary<string, string> parms = null)
        {
            return await API.SendHttpClientRequest("orders/" + orderid.ToString(), RequestMethod.DELETE, string.Empty, parms).ConfigureAwait(false);
        }

        public async Task<OrderNoteList> GetOrderNotes(int id, Dictionary<string,string> parms = null)
        {
            string json = await API.SendHttpClientRequest("orders/" + id.ToString() + "/notes", RequestMethod.GET, string.Empty, parms).ConfigureAwait(false);
            json = json.Substring(json.IndexOf(':') + 1, json.Length - json.IndexOf(':') - 2);
            return API.DeserializeJSon<OrderNoteList>(json);
        }

        public async Task<Order_Note> GetOrderNote(int orderid, int noteid, Dictionary<string,string> parms = null)
        {
            string json = await API.SendHttpClientRequest("orders/" + orderid.ToString() + "/notes/" + noteid.ToString(), RequestMethod.GET, string.Empty, parms).ConfigureAwait(false);
            json = json.Substring(json.IndexOf(':') + 1, json.Length - json.IndexOf(':') - 2);
            return API.DeserializeJSon<Order_Note>(json);
        }

        public async Task<string> PostOrderNote(int orderid, Order_Note n, Dictionary<string, string> parms = null)
        {
            return await API.SendHttpClientRequest("orders/" + orderid.ToString() + "/notes", RequestMethod.POST, n, parms).ConfigureAwait(false);
        }

        public async Task<string> UpdateOrderNote(int orderid, int noteid, Order_Note n, Dictionary<string, string> parms = null)
        {
            return await API.SendHttpClientRequest("orders/" + orderid.ToString() + "/notes/" + noteid.ToString(), RequestMethod.PUT, n, parms).ConfigureAwait(false);
        }

        public async Task<string> DeleteOrderNote(int orderid, int noteid, Dictionary<string, string> parms = null)
        {
            return await API.SendHttpClientRequest("orders/" + orderid.ToString() + "/notes/" + noteid.ToString(), RequestMethod.DELETE, parms).ConfigureAwait(false);
        }

        public async Task<OrderRefundList> GetOrderRefunds(int orderid, Dictionary<string,string> parms = null)
        {
            string json = await API.SendHttpClientRequest("orders/" + orderid.ToString() + "/refunds", RequestMethod.GET, string.Empty, parms).ConfigureAwait(false);
            json = json.Substring(json.IndexOf(':') + 1, json.Length - json.IndexOf(':') - 2);
            return API.DeserializeJSon<OrderRefundList>(json);
        }

        public async Task<Order_Refund> GetOrderRefund(int orderid, int refundid, Dictionary<string, string> parms = null)
        {
            string json = await API.SendHttpClientRequest("orders/" + orderid.ToString() + "/refunds/" + refundid.ToString(), RequestMethod.GET, string.Empty, parms).ConfigureAwait(false);
            json = json.Substring(json.IndexOf(':') + 1, json.Length - json.IndexOf(':') - 2);
            return API.DeserializeJSon<Order_Refund>(json);
        }

        public async Task<string> PostOrderRefund(int orderid, Order_Refund r, Dictionary<string, string> parms = null)
        {
            return await API.SendHttpClientRequest("orders/" + orderid.ToString() + "/refunds", RequestMethod.POST, r, parms).ConfigureAwait(false);
        }

        public async Task<string> UpdateOrderRefund(int orderid, int refundid, Order_Refund r, Dictionary<string, string> parms = null)
        {
            return await API.SendHttpClientRequest("orders/" + orderid.ToString() + "/refunds/" + refundid.ToString(), RequestMethod.PUT, r, parms).ConfigureAwait(false);
        }

        public async Task<string> DeleteOrderRefund(int orderid, int refundid, Dictionary<string, string> parms = null)
        {
            return await API.SendHttpClientRequest("orders/" + orderid.ToString() + "/refunds/" + refundid.ToString(), RequestMethod.DELETE, string.Empty, parms).ConfigureAwait(false);
        }


        #endregion

        #region "products..."

        public async Task<ProductList> GetProducts(Dictionary<string,string> parms = null)
        {
            string json = await API.SendHttpClientRequest("products", RequestMethod.GET, string.Empty, parms).ConfigureAwait(false);
            json = json.Substring(json.IndexOf(':') + 1, json.Length - json.IndexOf(':') - 2);
            return API.DeserializeJSon<ProductList>(json);
        }

        public async Task<int> GetProductCount(Dictionary<string,string> parms = null)
        {
            string json = await API.SendHttpClientRequest("products/count", RequestMethod.GET, string.Empty, parms).ConfigureAwait(false);
            return int.Parse(json.Substring(json.IndexOf(':') + 1, json.IndexOf('}') - json.IndexOf(':') - 1).Trim('"'));
        }

        public async Task<Product> GetProduct(int productid, Dictionary<string,string> parms = null)
        {
            string json = await API.SendHttpClientRequest("products/" + productid.ToString(), RequestMethod.GET, string.Empty, parms).ConfigureAwait(false);
            //json = json.Replace("price\":\"\"", "price\":null");
            json = json.Substring(json.IndexOf(':') + 1, json.Length - json.IndexOf(':') - 2);
            return API.DeserializeJSon<Product>(json);
        }

        public async Task<string> PostProduct(Product p, Dictionary<string, string> parms = null)
        {
            return await API.SendHttpClientRequest("products", RequestMethod.POST, p, parms).ConfigureAwait(false);
        }

        public async Task<string> UpdateProduct(int productid, Product p, Dictionary<string, string> parms = null)
        {
            return await API.SendHttpClientRequest("products/" + productid.ToString(), RequestMethod.PUT, p, parms).ConfigureAwait(false);
        }

        public async Task<string> UpdateProducts(Product[] ps, Dictionary<string, string> parms = null)
        {
            return await API.SendHttpClientRequest("products/bulk", RequestMethod.PUT, ps, parms).ConfigureAwait(false);
        }

        public async Task<string> DeleteProduct(int productid, Dictionary<string, string> parms = null)
        {
            return await API.SendHttpClientRequest("products/" + productid.ToString(), RequestMethod.DELETE, string.Empty, parms).ConfigureAwait(false);
        }

        public async Task<ProductReviewList> GetProductReviews(int productid, Dictionary<string,string> parms = null)
        {
            string json = await API.SendHttpClientRequest("products/" + productid.ToString() + "/reviews", RequestMethod.GET, string.Empty, parms).ConfigureAwait(false);
            json = json.Substring(json.IndexOf(':') + 1, json.Length - json.IndexOf(':') - 2);
            return API.DeserializeJSon<ProductReviewList>(json);
        }

        public async Task<ProductCategoryList> GetProductCategories(Dictionary<string,string> parms = null)
        {
            string json = await API.SendHttpClientRequest("products/categories", RequestMethod.GET, string.Empty, parms).ConfigureAwait(false);
            json = json.Substring(json.IndexOf(':') + 1, json.Length - json.IndexOf(':') - 2);
            return API.DeserializeJSon<ProductCategoryList>(json);
        }

        public async Task<Product_Category> GetProductCategory(int categoryid, Dictionary<string,string> parms = null)
        {
            string json = await API.SendHttpClientRequest("products/categories/" + categoryid.ToString(), RequestMethod.GET, string.Empty, parms).ConfigureAwait(false);
            json = json.Substring(json.IndexOf(':') + 1, json.Length - json.IndexOf(':') - 2);
            return API.DeserializeJSon<Product_Category>(json);
        }

        public async Task<string> PostProductCategory(Product_Category pc, Dictionary<string, string> parms = null)
        {
            return await API.SendHttpClientRequest("products/categories", RequestMethod.POST, pc, parms).ConfigureAwait(false);
        }

        public async Task<string> UpdateProductCategory(int categoryid, Product_Category pc, Dictionary<string, string> parms = null)
        {
            return await API.SendHttpClientRequest("products/categories/" + categoryid.ToString(), RequestMethod.PUT, pc, parms).ConfigureAwait(false);
        }

        public async Task<string> DeleteProductCategory(int categoryid, Dictionary<string, string> parms = null)
        {
            return await API.SendHttpClientRequest("products/categories/" + categoryid.ToString(), RequestMethod.DELETE, string.Empty, parms).ConfigureAwait(false);
        }

        #endregion

        #region "coupons..."

        public async Task<CouponList> GetCoupons(Dictionary<string,string> parms = null)
        {
            string json = await API.SendHttpClientRequest("coupons", RequestMethod.GET, string.Empty, parms).ConfigureAwait(false);
            json = json.Substring(json.IndexOf(':') + 1, json.Length - json.IndexOf(':') - 2);
            return API.DeserializeJSon<CouponList>(json);
        }

        public async Task<int> GetCouponCount(Dictionary<string,string> parms = null)
        {
            string json = await API.SendHttpClientRequest("coupons/count", RequestMethod.GET, string.Empty, parms).ConfigureAwait(false);
            return int.Parse(json.Substring(json.IndexOf(':') + 1, json.IndexOf('}') - json.IndexOf(':') - 1).Trim('"'));
        }

        public async Task<Coupon> GetCoupon(int couponid, Dictionary<string,string> parms = null)
        {
            string json = await API.SendHttpClientRequest("coupons/" + couponid.ToString(), RequestMethod.GET, string.Empty, parms).ConfigureAwait(false);
            json = json.Substring(json.IndexOf(':') + 1, json.Length - json.IndexOf(':') - 2);
            return API.DeserializeJSon<Coupon>(json);
        }

        public async Task<Coupon> GetCoupon(string code, Dictionary<string,string> parms = null)
        {
            string json = await API.SendHttpClientRequest("coupons/code/" + code, RequestMethod.GET, string.Empty, parms).ConfigureAwait(false);
            json = json.Substring(json.IndexOf(':') + 1, json.Length - json.IndexOf(':') - 2);
            return API.DeserializeJSon<Coupon>(json);
        }

        public async Task<string> PostCoupon(Coupon c, Dictionary<string,string> parms = null)
        {
            return await API.SendHttpClientRequest("coupons", RequestMethod.POST, c, parms).ConfigureAwait(false);
        }

        public async Task<string> UpdateCoupon(int couponid, Coupon c, Dictionary<string,string> parms = null)
        {
            return await API.SendHttpClientRequest("coupons/" + couponid.ToString(), RequestMethod.PUT, c, parms).ConfigureAwait(false);
        }

        public async Task<string> UpdateCoupons(Coupon[] cs, Dictionary<string,string> parms = null)
        {
            return await API.SendHttpClientRequest("coupons/bulk", RequestMethod.PUT, cs, parms).ConfigureAwait(false);
        }

        public async Task<string> DeleteCoupon(int couponid, Dictionary<string,string> parms = null)
        {
            return await API.SendHttpClientRequest("coupons/" + couponid.ToString(), RequestMethod.DELETE, string.Empty, parms).ConfigureAwait(false);
        }

        #endregion

        #region "reports..."

        public async Task<List<string>> GetReports(Dictionary<string,string> parms = null)
        {
            string json = await API.SendHttpClientRequest("reports", RequestMethod.GET, string.Empty, parms).ConfigureAwait(false);
            json = json.Substring(json.IndexOf(':') + 1, json.Length - json.IndexOf(':') - 2);
            return API.DeserializeJSon<List<string>>(json);
        }

        public async Task<string> GetSalesReport(Dictionary<string,string> parms = null)
        {
            string json = await API.SendHttpClientRequest("reports/sales", RequestMethod.GET, string.Empty, parms).ConfigureAwait(false);
            json = json.Substring(json.IndexOf(':') + 1, json.Length - json.IndexOf(':') - 2);
            return API.DeserializeJSon<string>(json);
        }

        public async Task<List<string>> GetTopSellerReport(Dictionary<string,string> parms = null)
        {
            string json = await API.SendHttpClientRequest("reports/sales/top_sellers", RequestMethod.GET, string.Empty, parms).ConfigureAwait(false);
            json = json.Substring(json.IndexOf(':') + 1, json.Length - json.IndexOf(':') - 2);
            return API.DeserializeJSon<List<string>>(json);
        }

        #endregion

        #region "webhooks..."

        public async Task<WebhookList> GetWebhooks(Dictionary<string,string> parms = null)
        {
            string json = await API.SendHttpClientRequest("webhooks", RequestMethod.GET, string.Empty, parms).ConfigureAwait(false);
            json = json.Substring(json.IndexOf(':') + 1, json.Length - json.IndexOf(':') - 2);
            return API.DeserializeJSon<WebhookList>(json);
        }

        public async Task<int> GetWebhookCount(Dictionary<string,string> parms = null)
        {
            string json = await API.SendHttpClientRequest("webhooks/count", RequestMethod.GET, string.Empty, parms).ConfigureAwait(false);
            return int.Parse(json.Substring(json.IndexOf(':') + 1, json.IndexOf('}') - json.IndexOf(':') - 1).Trim('"'));
        }

        public async Task<Webhook> GetWebhook(int id, Dictionary<string,string> parms = null)
        {
            string json = await API.SendHttpClientRequest("webhooks/" + id.ToString(), RequestMethod.GET, string.Empty, parms).ConfigureAwait(false);
            json = json.Substring(json.IndexOf(':') + 1, json.Length - json.IndexOf(':') - 2);
            return API.DeserializeJSon<Webhook>(json);
        }

        public async Task<WebhookDeliveryList> GetWebhookDeliveries(int webhookid, Dictionary<string,string> parms = null)
        {
            string json = await API.SendHttpClientRequest("webhooks/" + webhookid.ToString() + "/deliveries", RequestMethod.GET, string.Empty, parms).ConfigureAwait(false);
            json = json.Substring(json.IndexOf(':') + 1, json.Length - json.IndexOf(':') - 2);
            return API.DeserializeJSon<WebhookDeliveryList>(json);
        }

        public async Task<WebhookDelivery> GetWebhookDelivery(int webhookid, int deliveryid, Dictionary<string,string> parms = null)
        {
            string json = await API.GetRestful("webhooks/" + webhookid.ToString() + "/deliveries/" + deliveryid.ToString(), parms).ConfigureAwait(false);
            json = json.Substring(json.IndexOf(':') + 1, json.Length - json.IndexOf(':') - 2);
            return API.DeserializeJSon<WebhookDelivery>(json);
        }

        #endregion
    }
}
