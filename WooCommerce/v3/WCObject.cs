using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using WooCommerceNET.Base;

namespace WooCommerceNET.WooCommerce.v3
{
    public class WCObject<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>
        where T1 : Coupon where T2 : Customer where T3 : Product where T4 : ProductReview where T5 : Variation
        where T6 : Order where T7 : OrderNote where T8 : OrderRefund where T9 : ProductAttribute
        where T10 : ProductAttributeTerm where T11 : ProductCategory where T12 : ShippingClass 
        where T13 : ProductTag where T14 : TaxRate where T15 : TaxClass where T16 : Data
    {
       
        protected RestAPI API { get; set; }
        public static Func<string, object, object> MetaValueProcessor
        {
            get
            {
                return v2.WCObject.MetaValueProcessor;
            }
            set
            {
                v2.WCObject.MetaValueProcessor = value;
            }
        }

        public WCObject(RestAPI api)
        {
            if (api.Version != APIVersion.Version3 && api.Version != APIVersion.ThirdPartyPlugins)
                throw new Exception("Please use WooCommerce Restful API Version 3 url for this WCObject. e.g.: http://www.yourstore.co.nz/wp-json/wc/v3/");

            API = api;

            Coupon = new WCItem<T1>(api);
            Customer = new WCItem<T2>(api);
            Product = new WCProductItem(api);
            ProductReview = new WCItem<T4>(api);
            Order = new WCOrderItem(api);
            Attribute = new WCAttributeItem(api);
            Category = new WCItem<T11>(api);
            ShippingClass = new WCItem<T12>(api);
            Tag = new WCItem<T13>(api);
            Report = new WCItem<Report>(api);
            TaxRate = new WCItem<T14>(api);
            TaxClass = new WCItem<T15>(api);
            Webhook = new WCItem<Webhook>(api);
            PaymentGateway = new WCItem<PaymentGateway>(api);
            ShippingZone = new WCShippingZoneItem(api);
            ShippingMethod = new WCItem<ShippingMethod>(api);
            SystemStatus = new WCItem<SystemStatus>(api);
            SystemStatusTool = new WCItem<SystemStatusTool>(api);
            Setting = new WCItem<Setting>(api);
            Data = new WCItem<Data>(api);
            Plugin = new WCItem<Plugins>(api);
        }

        public WCItem<T1> Coupon { get; protected set; }

        public WCItem<T2> Customer { get; protected set; }

        public WCProductItem Product { get; protected set; }

        public WCItem<T4> ProductReview { get; protected set; }

        public WCOrderItem Order { get; protected set; }

        public WCAttributeItem Attribute { get; protected set; }

        public WCItem<T11> Category { get; protected set; }

        public WCItem<T12> ShippingClass { get; protected set; }

        public WCItem<T13> Tag { get; protected set; }

        public WCItem<Report> Report { get; protected set; }

        public WCItem<T14> TaxRate { get; protected set; }

        public WCItem<T15> TaxClass { get; protected set; }

        public WCItem<Webhook> Webhook { get; protected set; }

        public WCItem<PaymentGateway> PaymentGateway { get; protected set; }

        public WCShippingZoneItem ShippingZone { get; protected set; }

        public WCItem<ShippingMethod> ShippingMethod { get; protected set; }

        public WCItem<SystemStatus> SystemStatus { get; protected set; }

        public WCItem<SystemStatusTool> SystemStatusTool { get; protected set; }

        public WCItem<Setting> Setting { get; protected set; }

        public WCItem<Data> Data { get; protected set; }

        public WCItem<Plugins> Plugin { get; protected set; }

        public class WCProductItem : WCItem<T3>
        {
            public WCProductItem(RestAPI api) : base(api)
            {
                API = api;

                //Reviews = new WCSubItem<T4>(api, APIEndpoint);
                Variations = new WCSubItem<T5>(api, APIEndpoint);
            }

            //public WCSubItem<T4> Reviews { get; set; }

            public WCSubItem<T5> Variations { get; set; }
        }

        public class WCOrderItem : WCItem<T6>
        {
            public WCOrderItem(RestAPI api) : base(api)
            {
                API = api;

                Notes = new WCSubItem<T7>(api, APIEndpoint);
                Refunds = new WCSubItem<T8>(api, APIEndpoint);
            }

            public WCSubItem<T7> Notes { get; set; }

            public WCSubItem<T8> Refunds { get; set; }
        }

        public class WCAttributeItem : WCItem<T9>
        {
            public WCAttributeItem(RestAPI api) : base(api)
            {
                API = api;

                Terms = new WCSubItem<T10>(api, APIEndpoint);
            }

            public WCSubItem<T10> Terms { get; set; }
        }

        public class WCShippingZoneItem : WCItem<ShippingZone>
        {
            public WCShippingZoneItem(RestAPI api) : base(api)
            {
                API = api;

                Locations = new WCSubItem<ShippingZoneLocation>(api, APIEndpoint);
                Methods = new WCSubItem<ShippingZoneMethod>(api, APIEndpoint);
            }

            public WCSubItem<ShippingZoneLocation> Locations { get; protected set; }
            public WCSubItem<ShippingZoneMethod> Methods { get; protected set; }
        }
    }

    public class WCObject: WCObject<Coupon, Customer, Product, ProductReview, Variation, Order, OrderNote, OrderRefund, ProductAttribute, ProductAttributeTerm, 
                                    ProductCategory, ShippingClass, ProductTag, TaxRate, TaxClass, Data>
    {
        public WCObject(RestAPI api) : base(api)
        {
        }
    }

    public class Plugins
    {
        public static string Endpoint { get { return "plugins"; } }
    }
}

namespace WooCommerceNET.WooCommerce.v3.Extension
{
    public static class WCExtension
    {
        public static async Task<T> WithCancellation<T>(this Task<T> task, CancellationToken cancellationToken)
        {
            var tcs = new TaskCompletionSource<bool>();
            using (cancellationToken.Register(() => tcs.TrySetResult(true)))
                if (task != await Task.WhenAny(task, tcs.Task))
                    throw new OperationCanceledException(cancellationToken);
            return await task;
        }

        public static async Task WithCancellation(this Task task, CancellationToken cancellationToken)
        {
            var tcs = new TaskCompletionSource<bool>();
            using (cancellationToken.Register(() => tcs.TrySetResult(true)))
                if (task != await Task.WhenAny(task, tcs.Task))
                    throw new OperationCanceledException(cancellationToken);
            await task;
        }

        public static async Task<List<CustomerDownloads>> GetCustomerDownloads(this WCItem<Customer> item, int id, Dictionary<string, string> parms = null)
        {
            return item.API.DeserializeJSon<List<CustomerDownloads>>(await item.API.GetRestful(item.APIEndpoint + "/" + id.ToString() + "/downloads", parms).ConfigureAwait(false));
        }

        public static async Task<SystemStatus> Get(this WCItem<SystemStatus> item)
        {
            return item.API.DeserializeJSon<SystemStatus>(await item.API.GetRestful(item.APIEndpoint, null).ConfigureAwait(false));
        }

        public static async Task<SystemStatusTool> Run(this WCItem<SystemStatusTool> item, string id, Dictionary<string, string> parms = null)
        {
            return item.API.DeserializeJSon<SystemStatusTool>(await item.API.PutRestful(item.APIEndpoint + "/" + id, parms).ConfigureAwait(false));
        }

        public static async Task<List<SalesReport>> GetSalesReport(this WCItem<Report> item, Dictionary<string, string> parms = null)
        {
            return item.API.DeserializeJSon<List<SalesReport>>(await item.API.GetRestful(item.APIEndpoint + "/sales", parms).ConfigureAwait(false));
        }

        public static async Task<List<TopSellersReport>> GetTopSellerReport(this WCItem<Report> item, Dictionary<string, string> parms = null)
        {
            return item.API.DeserializeJSon<List<TopSellersReport>>(await item.API.GetRestful(item.APIEndpoint + "/top_sellers", parms).ConfigureAwait(false));
        }

        public static async Task<List<SettingOption>> GetSettingOptions(this WCItem<Setting> item, string settingId, Dictionary<string, string> parms = null)
        {
            return item.API.DeserializeJSon<List<SettingOption>>(await item.API.GetRestful(item.APIEndpoint + "/" + settingId, parms).ConfigureAwait(false));
        }

        public static async Task<SettingOption> GetSettingOption(this WCItem<Setting> item, string settingId, string optionId, Dictionary<string, string> parms = null)
        {
            return item.API.DeserializeJSon<SettingOption>(await item.API.GetRestful(item.APIEndpoint + "/" + settingId + "/" + optionId, parms).ConfigureAwait(false));
        }

        public static async Task<SettingOption> UpdateSettingOption(this WCItem<Setting> item, string settingId, string optionId, Dictionary<string, string> parms = null)
        {
            return item.API.DeserializeJSon<SettingOption>(await item.API.PostRestful(item.APIEndpoint + "/" + settingId + "/" + optionId, parms).ConfigureAwait(false));
        }

        public static async Task<List<SettingOption>> UpdateSettingOptions(this WCItem<Setting> item, string settingId, SettingOptionBatch batch, Dictionary<string, string> parms = null)
        {
            return item.API.DeserializeJSon<List<SettingOption>>(await item.API.PostRestful(item.APIEndpoint + "/" + settingId + "/batch", parms).ConfigureAwait(false));
        }

        public static async Task<List<Continent>> GetContinents(this WCItem<Data> item)
        {
            return item.API.DeserializeJSon<List<Continent>>(await item.API.GetRestful(item.APIEndpoint + "/continents", null).ConfigureAwait(false));
        }

        public static async Task<List<Country>> GetCountries(this WCItem<Data> item)
        {
            return item.API.DeserializeJSon<List<Country>>(await item.API.GetRestful(item.APIEndpoint + "/countries", null).ConfigureAwait(false));
        }

        public static async Task<List<Currency>> GetCurrencies(this WCItem<Data> item)
        {
            return item.API.DeserializeJSon<List<Currency>>(await item.API.GetRestful(item.APIEndpoint + "/currencies", null).ConfigureAwait(false));
        }

        public static async Task<Currency> GetCurrency(this WCItem<Data> item, string currency = "current")
        {
            return item.API.DeserializeJSon<Currency>(await item.API.GetRestful(item.APIEndpoint + "/currencies/" + currency, null).ConfigureAwait(false));
        }
    }

}