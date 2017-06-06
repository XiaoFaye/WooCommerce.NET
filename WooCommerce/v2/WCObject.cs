using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using WooCommerceNET.Base;

namespace WooCommerceNET.WooCommerce.v2
{
    public class WCObject
    {
        [DataContract]
        public class MetaData
        {
            /// <summary>
            /// Meta ID. 
            /// read-only
            /// </summary>
            [DataMember(EmitDefaultValue = false)]
            public int? id { get; set; }

            /// <summary>
            /// Meta key.
            /// </summary>
            [DataMember(EmitDefaultValue = false)]
            public string key { get; set; }

            /// <summary>
            /// Meta value.
            /// </summary>
            private object preValue;
            [DataMember(EmitDefaultValue = false)]
            public object value
            {
                get
                {
                    return preValue;
                }
                set
                {
                    if (MetaValueProcessor != null)
                        preValue = MetaValueProcessor.Invoke(GetType().Name, value);
                    else
                        preValue = value;
                }
            }
        }

        protected RestAPI API { get; set; }
        public static Func<string, object, object> MetaValueProcessor { get; set; }
        public WCObject(RestAPI api)
        {
            if (api.Version != APIVersion.Version2)
                throw new Exception("Please use WooCommerce Restful API Version 2 url for this WCObject. e.g.: http://www.yourstore.co.nz/wp-json/wc/v2/");

            API = api;

            Coupon = new WCItem<v2.Coupon>(api);
            Customer = new WCItem<v2.Customer>(api);
            Product = new WCProductItem(api);
            Order = new WCOrderItem(api);
            Attribute = new WCAttributeItem(api);
            Category = new WCItem<v2.ProductCategory>(api);
            ShippingClass = new WCItem<v2.ShippingClass>(api);
            Tag = new WCItem<v2.ProductTag>(api);
            Report = new WCItem<v2.Report>(api);
            TaxRate = new WCItem<v2.TaxRate>(api);
            TaxClass = new WCItem<v2.TaxClass>(api);
            Webhook = new WCItem<v2.Webhook>(api);
            PaymentGateway = new WCItem<v2.PaymentGateway>(api);
            ShippingZone = new WCShippingZoneItem(api);
            ShippingMethod = new WCItem<v2.ShippingMethod>(api);
            SystemStatus = new WCItem<v2.SystemStatus>(api);
            SystemStatusTool = new WCItem<v2.SystemStatusTool>(api);
            Setting = new WCItem<v2.Setting>(api);
        }

        public WCItem<Coupon> Coupon { get; protected set; }

        public WCItem<Customer> Customer { get; protected set; }

        public WCOrderItem Order { get; protected set; }

        public WCProductItem Product { get; protected set; }

        public WCAttributeItem Attribute { get; protected set; }

        public WCItem<ProductCategory> Category { get; protected set; }

        public WCItem<ShippingClass> ShippingClass { get; protected set; }

        public WCItem<ProductTag> Tag { get; protected set; }

        public WCItem<Report> Report { get; protected set; }

        public WCItem<TaxRate> TaxRate { get; protected set; }

        public WCItem<TaxClass> TaxClass { get; protected set; }

        public WCItem<Webhook> Webhook { get; protected set; }

        public WCItem<PaymentGateway> PaymentGateway { get; protected set; }

        public WCShippingZoneItem ShippingZone { get; protected set; }

        public WCItem<ShippingMethod> ShippingMethod { get; protected set; }

        public WCItem<SystemStatus> SystemStatus { get; protected set; }

        public WCItem<SystemStatusTool> SystemStatusTool { get; protected set; }

        public WCItem<Setting> Setting { get; protected set; }
    }

    public class WCOrderItem : WCItem<Order>
    {
        public WCOrderItem(RestAPI api) : base(api)
        {
            API = api;

            Notes = new WCSubItem<OrderNote>(api, APIEndpoint);
            Refunds = new WCSubItem<OrderRefund>(api, APIEndpoint);
        }

        public WCSubItem<OrderNote> Notes { get; set; }

        public WCSubItem<OrderRefund> Refunds { get; set; }
    }

    public class WCProductItem : WCItem<Product>
    {
        public WCProductItem(RestAPI api) : base(api)
        {
            API = api;
            
            Reviews = new WCSubItem<ProductReview>(api, APIEndpoint);
            Variations = new WCSubItem<Variation>(api, APIEndpoint);
        }

        public WCSubItem<ProductReview> Reviews { get; set; }

        public WCSubItem<Variation> Variations { get; set; }
    }

    public class WCAttributeItem :WCItem<ProductAttribute>
    {
        public WCAttributeItem(RestAPI api) : base(api)
        {
            API = api;

            Terms = new WCSubItem<ProductAttributeTerm>(api, APIEndpoint);
        }

        public WCSubItem<ProductAttributeTerm> Terms { get; set; }
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

namespace WooCommerceNET.WooCommerce.v2.Extension
{
    public static class WCExtension
    {
        public static async Task<List<CustomerDownloads>> GetCustomerDownloads(this WCItem<Customer> item, int id, Dictionary<string, string> parms = null)
        {
            return item.API.DeserializeJSon<List<CustomerDownloads>>(await item.API.GetRestful(item.APIEndpoint + "/" + id.ToString() + "/downloads", parms).ConfigureAwait(false));
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
    }
}