using Newtonsoft.Json;
using RestSharp.Portable;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WooCommerceNET;
using WooCommerceNET.WooCommerce;

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
            json = json.Substring(json.IndexOf(':') + 1, json.Length - json.IndexOf(':') - 2);
            return await Task.Factory.StartNew(() => JsonConvert.DeserializeObject<Store>(json));
        }

        #region "customers..."

        public async Task<ObservableCollection<Customer>> GetCustomers(List<Parameter> parms = null)
        {
            string json = await API.GetRestful("customers", parms).ConfigureAwait(false);
            json = json.Substring(json.IndexOf(':') + 1, json.Length - json.IndexOf(':') - 2);
            return await Task.Factory.StartNew(() => JsonConvert.DeserializeObject<ObservableCollection<Customer>>(json));
        }

        public async Task<int> GetCustomerCount(List<Parameter> parms = null)
        {
            string json = await API.GetRestful("customers/count", parms);
            return int.Parse(json.Substring(json.IndexOf(':') + 1, json.IndexOf('}') - json.IndexOf(':') - 1));
        }

        public async Task<Customer> GetCustomer(int id, List<Parameter> parms = null)
        {
            string json = await API.GetRestful("customers/" + id.ToString(), parms);
            json = json.Substring(json.IndexOf(':') + 1, json.Length - json.IndexOf(':') - 2);
            return JsonConvert.DeserializeObject<Customer>(json);
        }

        public async Task<Customer> GetCustomerEmail(string email, List<Parameter> parms = null)
        {
            string json = await API.GetRestful("customers/email/" + email, parms);
            json = json.Substring(json.IndexOf(':') + 1, json.Length - json.IndexOf(':') - 2);
            return JsonConvert.DeserializeObject<Customer>(json);
        }

        public async Task<ObservableCollection<Order>> GetCustomerOrders(int id, List<Parameter> parms = null)
        {
            string json = await API.GetRestful("customers/" + id.ToString() + "/orders", parms);
            json = json.Substring(json.IndexOf(':') + 1, json.Length - json.IndexOf(':') - 2);
            return JsonConvert.DeserializeObject<ObservableCollection<Order>>(json);
        }

        public async Task<ObservableCollection<Download>> GetCustomerDownloads(int id, List<Parameter> parms = null)
        {
            string json = await API.GetRestful("customers/" + id.ToString() + "/downloads", parms);
            json = json.Substring(json.IndexOf(':') + 1, json.Length - json.IndexOf(':') - 2);
            return JsonConvert.DeserializeObject<ObservableCollection<Download>>(json);
        }

        #endregion

        #region "orders..."

        public async Task<ObservableCollection<Order>> GetOrders(List<Parameter> parms = null)
        {
            string json = await API.GetRestful("orders", parms);
            json = json.Substring(json.IndexOf(':') + 1, json.Length - json.IndexOf(':') - 2);
            return JsonConvert.DeserializeObject<ObservableCollection<Order>>(json);
        }

        public async Task<int> GetOrderCount(List<Parameter> parms = null)
        {
            string json = await API.GetRestful("orders/count", parms);
            return int.Parse(json.Substring(json.IndexOf(':') + 1, json.IndexOf('}') - json.IndexOf(':') - 1));
        }

        public async Task<ObservableCollection<KeyValuePair<string, string>>> GetOrderStatuses(List<Parameter> parms = null)
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

        public async Task<Order> GetOrder(int id, List<Parameter> parms = null)
        {
            string json = await API.GetRestful("orders/" + id.ToString(), parms);
            json = json.Substring(json.IndexOf(':') + 1, json.Length - json.IndexOf(':') - 2);
            return JsonConvert.DeserializeObject<Order>(json);
        }

        public async Task<ObservableCollection<OrderNote>> GetOrderNotes(int id, List<Parameter> parms = null)
        {
            string json = await API.GetRestful("orders/" + id.ToString() + "/notes", parms);
            json = json.Substring(json.IndexOf(':') + 1, json.Length - json.IndexOf(':') - 2);
            return JsonConvert.DeserializeObject<ObservableCollection<OrderNote>>(json);
        }

        public async Task<OrderNote> GetOrderNote(int orderid, int noteid, List<Parameter> parms = null)
        {
            string json = await API.GetRestful("orders/" + orderid.ToString() + "/notes/" + noteid.ToString(), parms);
            json = json.Substring(json.IndexOf(':') + 1, json.Length - json.IndexOf(':') - 2);
            return JsonConvert.DeserializeObject<OrderNote>(json);
        }

        public async Task<ObservableCollection<OrderRefund>> GetOrderRefunds(int id, List<Parameter> parms = null)
        {
            string json = await API.GetRestful("orders/" + id.ToString() + "/refunds", parms);
            json = json.Substring(json.IndexOf(':') + 1, json.Length - json.IndexOf(':') - 2);
            return JsonConvert.DeserializeObject<ObservableCollection<OrderRefund>>(json);
        }

        public async Task<OrderRefund> GetOrderRefund(int orderid, int refundid, List<Parameter> parms = null)
        {
            string json = await API.GetRestful("orders/" + orderid.ToString() + "/refunds/" + refundid.ToString(), parms);
            json = json.Substring(json.IndexOf(':') + 1, json.Length - json.IndexOf(':') - 2);
            return JsonConvert.DeserializeObject<OrderRefund>(json);
        }


        #endregion

        #region "products..."

        public async Task<ObservableCollection<Product>> GetProducts(List<Parameter> parms = null)
        {
            string json = await API.GetRestful("products", parms).ConfigureAwait(false);
            json = json.Substring(json.IndexOf(':') + 1, json.Length - json.IndexOf(':') - 2);
            return await Task.Factory.StartNew(() => JsonConvert.DeserializeObject<ObservableCollection<Product>>(json));
        }

        public async Task<int> GetProductCount(List<Parameter> parms = null)
        {
            string json = await API.GetRestful("products/count", parms);
            return int.Parse(json.Substring(json.IndexOf(':') + 1, json.IndexOf('}') - json.IndexOf(':') - 1));
        }

        public async Task<Product> GetProduct(int id, List<Parameter> parms = null)
        {
            string json = await API.GetRestful("products/" + id.ToString(), parms);
            json = json.Substring(json.IndexOf(':') + 1, json.Length - json.IndexOf(':') - 2);
            return JsonConvert.DeserializeObject<Product>(json);
        }

        public async Task<ObservableCollection<ProductReview>> GetProductReviews(int id, List<Parameter> parms = null)
        {
            string json = await API.GetRestful("products/" + id.ToString() + "/reviews", parms);
            json = json.Substring(json.IndexOf(':') + 1, json.Length - json.IndexOf(':') - 2);
            return JsonConvert.DeserializeObject<ObservableCollection<ProductReview>>(json);
        }

        public async Task<ObservableCollection<ProductCategory>> GetProductCategories(List<Parameter> parms = null)
        {
            string json = await API.GetRestful("products/categories", parms).ConfigureAwait(false);
            json = json.Substring(json.IndexOf(':') + 1, json.Length - json.IndexOf(':') - 2);
            return await Task.Factory.StartNew(() => JsonConvert.DeserializeObject<ObservableCollection<ProductCategory>>(json));
        }

        public async Task<ProductCategory> GetProductCategory(int id, List<Parameter> parms = null)
        {
            string json = await API.GetRestful("products/categories/" + id.ToString(), parms);
            json = json.Substring(json.IndexOf(':') + 1, json.Length - json.IndexOf(':') - 2);
            return JsonConvert.DeserializeObject<ProductCategory>(json);
        }

        #endregion

        #region "coupons..."

        public async Task<ObservableCollection<Coupon>> GetCoupons(List<Parameter> parms = null)
        {
            string json = await API.GetRestful("coupons", parms).ConfigureAwait(false);
            json = json.Substring(json.IndexOf(':') + 1, json.Length - json.IndexOf(':') - 2);
            return await Task.Factory.StartNew(() => JsonConvert.DeserializeObject<ObservableCollection<Coupon>>(json));
        }

        public async Task<int> GetCouponCount(List<Parameter> parms = null)
        {
            string json = await API.GetRestful("coupons/count", parms);
            return int.Parse(json.Substring(json.IndexOf(':') + 1, json.IndexOf('}') - json.IndexOf(':') - 1));
        }

        public async Task<Coupon> GetCoupon(int id, List<Parameter> parms = null)
        {
            string json = await API.GetRestful("coupons/" + id.ToString(), parms);
            json = json.Substring(json.IndexOf(':') + 1, json.Length - json.IndexOf(':') - 2);
            return JsonConvert.DeserializeObject<Coupon>(json);
        }

        public async Task<Coupon> GetCoupon(string code, List<Parameter> parms = null)
        {
            string json = await API.GetRestful("coupons/code/" + code, parms);
            json = json.Substring(json.IndexOf(':') + 1, json.Length - json.IndexOf(':') - 2);
            return JsonConvert.DeserializeObject<Coupon>(json);
        }

        #endregion

        #region "reports..."

        public async Task<ObservableCollection<string>> GetReports(List<Parameter> parms = null)
        {
            string json = await API.GetRestful("reports", parms).ConfigureAwait(false);
            json = json.Substring(json.IndexOf(':') + 1, json.Length - json.IndexOf(':') - 2);
            return await Task.Factory.StartNew(() => JsonConvert.DeserializeObject<ObservableCollection<string>>(json));
        }

        public async Task<SalesReport> GetSalesReport(List<Parameter> parms = null)
        {
            string json = await API.GetRestful("reports/sales", parms).ConfigureAwait(false);
            json = json.Substring(json.IndexOf(':') + 1, json.Length - json.IndexOf(':') - 2);
            return await Task.Factory.StartNew(() => JsonConvert.DeserializeObject<SalesReport>(json));
        }

        public async Task<ObservableCollection<string>> GetTopSellerReport(List<Parameter> parms = null)
        {
            string json = await API.GetRestful("reports/sales/top_sellers", parms).ConfigureAwait(false);
            json = json.Substring(json.IndexOf(':') + 1, json.Length - json.IndexOf(':') - 2);
            return await Task.Factory.StartNew(() => JsonConvert.DeserializeObject<ObservableCollection<string>>(json));
        }

        #endregion

        #region "webhooks..."

        public async Task<string> GetWebhooks(List<Parameter> parms = null)
        {
            string json = await API.GetRestful("webhooks", parms).ConfigureAwait(false);
            json = json.Substring(json.IndexOf('['), json.Length - json.IndexOf('[') - 1);
            return json;
            //return await Task.Factory.StartNew(() => JsonConvert.DeserializeObject<ObservableCollection<string>>(json));
        }

        public async Task<int> GetWebhookCount(List<Parameter> parms = null)
        {
            string json = await API.GetRestful("webhooks/count", parms);
            return int.Parse(json.Substring(json.IndexOf(':') + 1, json.IndexOf('}') - json.IndexOf(':') - 1));
        }

        public async Task<string> GetWebhook(int id, List<Parameter> parms = null)
        {
            string json = await API.GetRestful("webhooks/" + id.ToString(), parms);
            json = json.Substring(json.IndexOf(":{") + 1, json.Length - json.IndexOf(":{") - 2);
            return json;
            //return JsonConvert.DeserializeObject<Coupon>(json);
        }

        public async Task<string> GetWebhookDeliveries(int id, List<Parameter> parms = null)
        {
            string json = await API.GetRestful("webhooks/" + id.ToString() + "/deliveries", parms);
            json = json.Substring(json.IndexOf('['), json.Length - json.IndexOf('[') - 1);
            return json;
            //return JsonConvert.DeserializeObject<Coupon>(json);
        }

        public async Task<string> GetWebhookDelivery(int webhookid, int deliveryid, List<Parameter> parms = null)
        {
            string json = await API.GetRestful("webhooks/" + webhookid.ToString() + "/deliveries/" + deliveryid.ToString(), parms);
            json = json.Substring(json.IndexOf(":{") + 1, json.Length - json.IndexOf(":{") - 2);
            return json;
            //return JsonConvert.DeserializeObject<Coupon>(json);
        }

        #endregion
    }
}
