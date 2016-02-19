using Newtonsoft.Json;
using RestSharp.Portable;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace WooCommerceNET.WooCommerce
{
    public class WCObject
    {
        private RestAPI API;
        public WCObject(RestAPI api)
        {
            API = api;
        }

        public async Task<Store> GetStoreInfo()
        {
            string json = await API.GetRestful(string.Empty).ConfigureAwait(false);
            return (await Task.Factory.StartNew(() => JsonConvert.DeserializeObject<StoreData>(json))).store;
        }

        #region "customers..."

        public async Task<ObservableCollection<Customer>> GetCustomers(Dictionary<string,string> parms = null)
        {
            string json = await API.GetRestful("customers", parms).ConfigureAwait(false);
            json = json.Substring(json.IndexOf(':') + 1, json.Length - json.IndexOf(':') - 2);
            return await Task.Factory.StartNew(() => JsonConvert.DeserializeObject<ObservableCollection<Customer>>(json));
        }

        //Don't forget to include a password when creating a customer, the example in REST API DOCS will not work!!!
        public async Task<string> PostCustomer(Customer c, Dictionary<string, string> parms = null)
        {
            return await API.PostRestful("customers", new { customer = c }, parms);
        }

        public async Task<string> UpdateCustomer(int id, object c, Dictionary<string, string> parms = null)
        {
            return await API.PutRestful("customers/" + id.ToString(), new { customer = c }, parms);
        }

        public async Task<string> UpdateCustomer(object c, Dictionary<string, string> parms = null)
        {
            return await API.PutRestful("customers/bulk", new { customers = c }, parms);
        }

        public async Task<string> DeleteCustomer(int id, Dictionary<string, string> parms = null)
        {
            return await API.DeleteRestful("customers/" + id.ToString(), parms);
        }

        public async Task<int> GetCustomerCount(Dictionary<string,string> parms = null)
        {
            string json = await API.GetRestful("customers/count", parms);
            return int.Parse(json.Substring(json.IndexOf(':') + 1, json.IndexOf('}') - json.IndexOf(':') - 1));
        }

        public async Task<Customer> GetCustomer(int id, Dictionary<string,string> parms = null)
        {
            string json = await API.GetRestful("customers/" + id.ToString(), parms);
            json = json.Substring(json.IndexOf(':') + 1, json.Length - json.IndexOf(':') - 2);
            return JsonConvert.DeserializeObject<Customer>(json);
        }

        public async Task<Customer> GetCustomerEmail(string email, Dictionary<string,string> parms = null)
        {
            string json = await API.GetRestful("customers/email/" + email, parms);
            json = json.Substring(json.IndexOf(':') + 1, json.Length - json.IndexOf(':') - 2);
            return JsonConvert.DeserializeObject<Customer>(json);
        }

        public async Task<ObservableCollection<Order>> GetCustomerOrders(int id, Dictionary<string,string> parms = null)
        {
            string json = await API.GetRestful("customers/" + id.ToString() + "/orders", parms);
            json = json.Substring(json.IndexOf(':') + 1, json.Length - json.IndexOf(':') - 2);
            return JsonConvert.DeserializeObject<ObservableCollection<Order>>(json);
        }

        public async Task<ObservableCollection<Download>> GetCustomerDownloads(int id, Dictionary<string,string> parms = null)
        {
            string json = await API.GetRestful("customers/" + id.ToString() + "/downloads", parms);
            json = json.Substring(json.IndexOf(':') + 1, json.Length - json.IndexOf(':') - 2);
            return JsonConvert.DeserializeObject<ObservableCollection<Download>>(json);
        }

        #endregion

        #region "orders..."

        public async Task<ObservableCollection<Order>> GetOrders(Dictionary<string,string> parms = null)
        {
            string json = await API.GetRestful("orders", parms);
            json = json.Substring(json.IndexOf(':') + 1, json.Length - json.IndexOf(':') - 2);
            return JsonConvert.DeserializeObject<ObservableCollection<Order>>(json);
        }

        public async Task<int> GetOrderCount(Dictionary<string,string> parms = null)
        {
            string json = await API.GetRestful("orders/count", parms);
            return int.Parse(json.Substring(json.IndexOf(':') + 1, json.IndexOf('}') - json.IndexOf(':') - 1));
        }

        public async Task<ObservableCollection<KeyValuePair<string, string>>> GetOrderStatuses(Dictionary<string,string> parms = null)
        {
            string json = await API.GetRestful("orders/statuses", parms);
            json = json.Substring(20, json.Length - 22).Replace("\"", string.Empty);

            ObservableCollection<KeyValuePair<string, string>> statuses = new ObservableCollection<KeyValuePair<string, string>>();
            foreach(string status in json.Split(','))
            {
                KeyValuePair<string, string> value = new KeyValuePair<string, string>(status.Split(':')[0], status.Split(':')[1]);
                statuses.Add(value);
            }

            return statuses;
        }

        public async Task<string> PostOrder(Order c, Dictionary<string, string> parms = null)
        {
            return await API.PostRestful("orders", new { order = c }, parms);
        }

        public async Task<string> UpdateOrder(int id, object c, Dictionary<string, string> parms = null)
        {
            return await API.PutRestful("orders/" + id.ToString(), new { order = c }, parms);
        }

        public async Task<string> UpdateOrder(object c, Dictionary<string, string> parms = null)
        {
            return await API.PutRestful("orders/bulk", new { orders = c }, parms);
        }

        public async Task<string> DeleteOrder(int id, Dictionary<string, string> parms = null)
        {
            return await API.DeleteRestful("orders/" + id.ToString(), parms);
        }

        public async Task<Order> GetOrder(int id, Dictionary<string,string> parms = null)
        {
            string json = await API.GetRestful("orders/" + id.ToString(), parms);
            json = json.Substring(json.IndexOf(':') + 1, json.Length - json.IndexOf(':') - 2);
            return JsonConvert.DeserializeObject<Order>(json);
        }

        public async Task<ObservableCollection<OrderNote>> GetOrderNotes(int id, Dictionary<string,string> parms = null)
        {
            string json = await API.GetRestful("orders/" + id.ToString() + "/notes", parms);
            json = json.Substring(json.IndexOf(':') + 1, json.Length - json.IndexOf(':') - 2);
            return JsonConvert.DeserializeObject<ObservableCollection<OrderNote>>(json);
        }

        public async Task<OrderNote> GetOrderNote(int orderid, int noteid, Dictionary<string,string> parms = null)
        {
            string json = await API.GetRestful("orders/" + orderid.ToString() + "/notes/" + noteid.ToString(), parms);
            json = json.Substring(json.IndexOf(':') + 1, json.Length - json.IndexOf(':') - 2);
            return JsonConvert.DeserializeObject<OrderNote>(json);
        }

        public async Task<string> PostOrderNote(int orderid, OrderNote n, Dictionary<string, string> parms = null)
        {
            return await API.PostRestful("orders/" + orderid.ToString() + "/notes", new { order_note = n }, parms);
        }

        public async Task<string> UpdateOrderNote(int orderid, int noteid, OrderNote n, Dictionary<string, string> parms = null)
        {
            return await API.PutRestful("orders/" + orderid.ToString() + "/notes/" + noteid.ToString(), new { order_note = n }, parms);
        }

        public async Task<string> DeleteOrderNote(int orderid, int noteid, Dictionary<string, string> parms = null)
        {
            return await API.DeleteRestful("orders/" + orderid.ToString() + "/notes/" + noteid.ToString(), parms);
        }

        public async Task<ObservableCollection<OrderRefund>> GetOrderRefunds(int id, Dictionary<string,string> parms = null)
        {
            string json = await API.GetRestful("orders/" + id.ToString() + "/refunds", parms);
            json = json.Substring(json.IndexOf(':') + 1, json.Length - json.IndexOf(':') - 2);
            return JsonConvert.DeserializeObject<ObservableCollection<OrderRefund>>(json);
        }

        public async Task<string> PostOrderRefund(int orderid, OrderRefund r, Dictionary<string, string> parms = null)
        {
            return await API.PostRestful("orders/" + orderid.ToString() + "/refunds", new { order_refund = r }, parms);
        }

        public async Task<string> UpdateOrderRefund(int orderid, int refundid, OrderRefund r, Dictionary<string, string> parms = null)
        {
            return await API.PutRestful("orders/" + orderid.ToString() + "/refunds/" + refundid.ToString(), new { order_refund = r }, parms);
        }

        public async Task<string> DeleteOrderRefund(int orderid, int refundid, Dictionary<string, string> parms = null)
        {
            return await API.DeleteRestful("orders/" + orderid.ToString() + "/refunds/" + refundid.ToString(), parms);
        }

        public async Task<OrderRefund> GetOrderRefund(int orderid, int refundid, Dictionary<string,string> parms = null)
        {
            string json = await API.GetRestful("orders/" + orderid.ToString() + "/refunds/" + refundid.ToString(), parms);
            json = json.Substring(json.IndexOf(':') + 1, json.Length - json.IndexOf(':') - 2);
            return JsonConvert.DeserializeObject<OrderRefund>(json);
        }


        #endregion

        #region "products..."

        public async Task<ObservableCollection<Product>> GetProducts(Dictionary<string,string> parms = null)
        {
            string json = await API.GetRestful("products", parms).ConfigureAwait(false);
            json = json.Substring(json.IndexOf(':') + 1, json.Length - json.IndexOf(':') - 2);
            return await Task.Factory.StartNew(() => JsonConvert.DeserializeObject<ObservableCollection<Product>>(json));
        }

        public async Task<int> GetProductCount(Dictionary<string,string> parms = null)
        {
            string json = await API.GetRestful("products/count", parms);
            return int.Parse(json.Substring(json.IndexOf(':') + 1, json.IndexOf('}') - json.IndexOf(':') - 1));
        }

        public async Task<Product> GetProduct(int id, Dictionary<string,string> parms = null)
        {
            string json = await API.GetRestful("products/" + id.ToString(), parms);
            json = json.Substring(json.IndexOf(':') + 1, json.Length - json.IndexOf(':') - 2);
            return JsonConvert.DeserializeObject<Product>(json);
        }

        public async Task<string> PostProduct(Product p, Dictionary<string, string> parms = null)
        {
            return await API.PostRestful("products", new { product = p }, parms);
        }

        public async Task<string> UpdateProduct(int id, object p, Dictionary<string, string> parms = null)
        {
            return await API.PutRestful("products/" + id.ToString(), new { product = p }, parms);
        }

        public async Task<string> UpdateProduct(object p, Dictionary<string, string> parms = null)
        {
            return await API.PutRestful("products/bulk", new { products = p }, parms);
        }

        public async Task<string> DeleteProduct(int id, Dictionary<string, string> parms = null)
        {
            return await API.DeleteRestful("products/" + id.ToString(), parms);
        }

        public async Task<ObservableCollection<ProductReview>> GetProductReviews(int id, Dictionary<string,string> parms = null)
        {
            string json = await API.GetRestful("products/" + id.ToString() + "/reviews", parms);
            json = json.Substring(json.IndexOf(':') + 1, json.Length - json.IndexOf(':') - 2);
            return JsonConvert.DeserializeObject<ObservableCollection<ProductReview>>(json);
        }

        public async Task<ObservableCollection<ProductCategory>> GetProductCategories(Dictionary<string,string> parms = null)
        {
            string json = await API.GetRestful("products/categories", parms).ConfigureAwait(false);
            json = json.Substring(json.IndexOf(':') + 1, json.Length - json.IndexOf(':') - 2);
            return await Task.Factory.StartNew(() => JsonConvert.DeserializeObject<ObservableCollection<ProductCategory>>(json));
        }

        public async Task<ProductCategory> GetProductCategory(int id, Dictionary<string,string> parms = null)
        {
            string json = await API.GetRestful("products/categories/" + id.ToString(), parms);
            json = json.Substring(json.IndexOf(':') + 1, json.Length - json.IndexOf(':') - 2);
            return JsonConvert.DeserializeObject<ProductCategory>(json);
        }

        #endregion

        #region "coupons..."

        public async Task<ObservableCollection<Coupon>> GetCoupons(Dictionary<string,string> parms = null)
        {
            string json = await API.GetRestful("coupons", parms).ConfigureAwait(false);
            json = json.Substring(json.IndexOf(':') + 1, json.Length - json.IndexOf(':') - 2);
            return await Task.Factory.StartNew(() => JsonConvert.DeserializeObject<ObservableCollection<Coupon>>(json));
        }

        public async Task<int> GetCouponCount(Dictionary<string,string> parms = null)
        {
            string json = await API.GetRestful("coupons/count", parms);
            return int.Parse(json.Substring(json.IndexOf(':') + 1, json.IndexOf('}') - json.IndexOf(':') - 1));
        }

        public async Task<Coupon> GetCoupon(int id, Dictionary<string,string> parms = null)
        {
            string json = await API.GetRestful("coupons/" + id.ToString(), parms);
            json = json.Substring(json.IndexOf(':') + 1, json.Length - json.IndexOf(':') - 2);
            return JsonConvert.DeserializeObject<Coupon>(json);
        }

        public async Task<Coupon> GetCoupon(string code, Dictionary<string,string> parms = null)
        {
            string json = await API.GetRestful("coupons/code/" + code, parms);
            json = json.Substring(json.IndexOf(':') + 1, json.Length - json.IndexOf(':') - 2);
            return JsonConvert.DeserializeObject<Coupon>(json);
        }

        public async Task<string> PostCoupon(Coupon c, Dictionary<string,string> parms = null)
        {
            return await API.PostRestful("coupons", new { coupon = c }, parms);
        }

        public async Task<string> UpdateCoupon(int id, object c, Dictionary<string,string> parms = null)
        {
            return await API.PutRestful("coupons/" + id.ToString(), new { coupon = c }, parms);
        }

        public async Task<string> UpdateCoupon(object c, Dictionary<string,string> parms = null)
        {
            return await API.PutRestful("coupons/bulk", new { coupons = c }, parms);
        }

        public async Task<string> DeleteCoupon(int id, Dictionary<string,string> parms = null)
        {
            return await API.DeleteRestful("coupons/" + id.ToString(), parms);
        }

        #endregion

        #region "reports..."

        public async Task<ObservableCollection<string>> GetReports(Dictionary<string,string> parms = null)
        {
            string json = await API.GetRestful("reports", parms).ConfigureAwait(false);
            json = json.Substring(json.IndexOf(':') + 1, json.Length - json.IndexOf(':') - 2);
            return await Task.Factory.StartNew(() => JsonConvert.DeserializeObject<ObservableCollection<string>>(json));
        }

        public async Task<SalesReport> GetSalesReport(Dictionary<string,string> parms = null)
        {
            string json = await API.GetRestful("reports/sales", parms).ConfigureAwait(false);
            json = json.Substring(json.IndexOf(':') + 1, json.Length - json.IndexOf(':') - 2);
            return await Task.Factory.StartNew(() => JsonConvert.DeserializeObject<SalesReport>(json));
        }

        public async Task<ObservableCollection<string>> GetTopSellerReport(Dictionary<string,string> parms = null)
        {
            string json = await API.GetRestful("reports/sales/top_sellers", parms).ConfigureAwait(false);
            json = json.Substring(json.IndexOf(':') + 1, json.Length - json.IndexOf(':') - 2);
            return await Task.Factory.StartNew(() => JsonConvert.DeserializeObject<ObservableCollection<string>>(json));
        }

        #endregion

        #region "webhooks..."

        public async Task<string> GetWebhooks(Dictionary<string,string> parms = null)
        {
            string json = await API.GetRestful("webhooks", parms).ConfigureAwait(false);
            json = json.Substring(json.IndexOf('['), json.Length - json.IndexOf('[') - 1);
            return json;
            //return await Task.Factory.StartNew(() => JsonConvert.DeserializeObject<ObservableCollection<string>>(json));
        }

        public async Task<int> GetWebhookCount(Dictionary<string,string> parms = null)
        {
            string json = await API.GetRestful("webhooks/count", parms);
            return int.Parse(json.Substring(json.IndexOf(':') + 1, json.IndexOf('}') - json.IndexOf(':') - 1));
        }

        public async Task<string> GetWebhook(int id, Dictionary<string,string> parms = null)
        {
            string json = await API.GetRestful("webhooks/" + id.ToString(), parms);
            json = json.Substring(json.IndexOf(":{") + 1, json.Length - json.IndexOf(":{") - 2);
            return json;
            //return JsonConvert.DeserializeObject<Coupon>(json);
        }

        public async Task<string> GetWebhookDeliveries(int id, Dictionary<string,string> parms = null)
        {
            string json = await API.GetRestful("webhooks/" + id.ToString() + "/deliveries", parms);
            json = json.Substring(json.IndexOf('['), json.Length - json.IndexOf('[') - 1);
            return json;
            //return JsonConvert.DeserializeObject<Coupon>(json);
        }

        public async Task<string> GetWebhookDelivery(int webhookid, int deliveryid, Dictionary<string,string> parms = null)
        {
            string json = await API.GetRestful("webhooks/" + webhookid.ToString() + "/deliveries/" + deliveryid.ToString(), parms);
            json = json.Substring(json.IndexOf(":{") + 1, json.Length - json.IndexOf(":{") - 2);
            return json;
            //return JsonConvert.DeserializeObject<Coupon>(json);
        }

        #endregion
    }
}
