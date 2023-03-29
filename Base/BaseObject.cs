using System;
using System.Collections.Generic;
using System.Globalization;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace WooCommerceNET.Base
{
    [DataContract]
    public class JsonObject
    {
        [IgnoreDataMember]
        public static CultureInfo Culture { get; set; }

        [OnSerializing]
        void OnSerializing(StreamingContext ctx)
        {
            foreach (PropertyInfo pi in GetType().GetRuntimeProperties())
            {
                PropertyInfo objValue = GetType().GetRuntimeProperties().FindByName(pi.Name + "Value");
                if (objValue != null && pi.GetValue(this) != null)
                {
                    if (pi.PropertyType == typeof(decimal?))
                    {
                        if (GetType().FullName.StartsWith("WooCommerceNET.WooCommerce.v1") ||
                            GetType().FullName.StartsWith("WooCommerceNET.WooCommerce.v2") ||
                            GetType().FullName.StartsWith("WooCommerceNET.WooCommerce.v3") ||
                            GetType().GetTypeInfo().BaseType.FullName.StartsWith("WooCommerceNET.WooCommerce.v1") ||
                            GetType().GetTypeInfo().BaseType.FullName.StartsWith("WooCommerceNET.WooCommerce.v2") ||
                            GetType().GetTypeInfo().BaseType.FullName.StartsWith("WooCommerceNET.WooCommerce.v3"))
                            objValue.SetValue(this, (pi.GetValue(this) as decimal?).Value.ToString(Culture));
                        else
                            objValue.SetValue(this, decimal.Parse(pi.GetValue(this).ToString(), Culture));
                    }
                    else if (pi.PropertyType == typeof(int?))
                    {
                        objValue.SetValue(this, int.Parse(pi.GetValue(this).ToString(), Culture));
                    }
                    else if (pi.PropertyType == typeof(DateTime?))
                    {
                        objValue.SetValue(this, ((DateTime?)pi.GetValue(this)).Value.ToString("yyyy-MM-ddTHH:mm:ss"));
                    }
                }
            }
        }

        [OnDeserialized]
        void OnDeserialized(StreamingContext ctx)
        {
            foreach (PropertyInfo pi in GetType().GetRuntimeProperties())
            {
                PropertyInfo objValue = GetType().GetRuntimeProperties().FindByName(pi.Name + "Value");

                if (objValue != null)
                {
                    if (pi.PropertyType == typeof(decimal?))
                    {
                        object value = objValue.GetValue(this);

                        if (!(value == null || value.ToString() == string.Empty))
                            pi.SetValue(this, decimal.Parse(value.ToString(), Culture));
                    }
                    else if (pi.PropertyType == typeof(int?))
                    {
                        object value = objValue.GetValue(this);

                        if (!(value == null || value.ToString() == string.Empty))
                            pi.SetValue(this, int.Parse(value.ToString(), Culture));
                    }
                    else if (pi.PropertyType == typeof(DateTime?))
                    {
                        object value = objValue.GetValue(this);

                        if (!(value == null || value.ToString() == string.Empty))
                            pi.SetValue(this, DateTime.Parse(value.ToString()));
                    }
                }
            }
        }


        //[OnDeserializing]
        //void tset(StreamingContext ctx)
        //{
        //    if (GetType().Name.Contains("ProductMeta"))
        //        foreach (PropertyInfo pi in GetType().GetRuntimeProperties())
        //        {

        //        }
        //}
    }

    //public class MyCustomerResolver : DataContractResolver
    //{
    //    public override bool TryResolveType(Type dataContractType, Type declaredType, DataContractResolver knownTypeResolver, out XmlDictionaryString typeName, out XmlDictionaryString typeNamespace)
    //    {
    //        if (dataContractType == typeof(string))
    //        {
    //            XmlDictionary dictionary = new XmlDictionary();
    //            typeName = dictionary.Add("SomeCustomer");
    //            typeNamespace = dictionary.Add("http://tempuri.com");
    //            return true;
    //        }
    //        else
    //        {
    //            return knownTypeResolver.TryResolveType(dataContractType, declaredType, null, out typeName, out typeNamespace);
    //        }
    //    }

    //    public override Type ResolveName(string typeName, string typeNamespace, Type declaredType, DataContractResolver knownTypeResolver)
    //    {
    //        throw new NotImplementedException();
    //    }
    //}

    public class BatchObject<T>
    {
        [DataMember(EmitDefaultValue = false)]
        public List<T> create { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public List<T> update { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public List<ulong> delete { get; set; }

        [IgnoreDataMember]
        public List<T> DeletedItems { get; set; }
    }

    public class WCItem<T>
    {
        public string APIEndpoint { get; protected set; }
        public RestAPI API { get; protected set; }

        public WCItem(RestAPI api)
        {
            API = api;
            if(typeof(T).BaseType.GetRuntimeProperty("Endpoint") == null)
                APIEndpoint = typeof(T).GetRuntimeProperty("Endpoint").GetValue(null).ToString();
            else
                APIEndpoint = typeof(T).BaseType.GetRuntimeProperty("Endpoint").GetValue(null).ToString();
        }

        public virtual async Task<T> Get(ulong id, Dictionary<string, string> parms = null)
        {
            return API.DeserializeJSon<T>(await API.GetRestful(APIEndpoint + "/" + id.ToString(), parms).ConfigureAwait(false));
        }

        public virtual async Task<List<T>> GetAll(Dictionary<string, string> parms = null)
        {
            return API.DeserializeJSon<List<T>>(await API.GetRestful(APIEndpoint, parms).ConfigureAwait(false));
        }

        public virtual async Task<T> Add(T item, Dictionary<string, string> parms = null)
        {
            return API.DeserializeJSon<T>(await API.PostRestful(APIEndpoint, item, parms).ConfigureAwait(false));
        }

        [Obsolete("AddRange method is obsolete, please use UpdateRange for batch Add, Update, Delete.")]
        public async Task<BatchObject<T>> AddRange(BatchObject<T> items, Dictionary<string, string> parms = null)
        {
            return API.DeserializeJSon<BatchObject<T>>(await API.PostRestful(APIEndpoint + "/batch", items, parms).ConfigureAwait(false));
        }

        public virtual async Task<T> Update(ulong id, T item, Dictionary<string, string> parms = null)
        {
            return API.DeserializeJSon<T>(await API.PostRestful(APIEndpoint + "/" + id.ToString(), item, parms).ConfigureAwait(false));
        }

        public virtual async Task<T> UpdateWithNull(ulong id, object item, Dictionary<string, string> parms = null)
        {
            if (API.GetType().Name == "RestAPI")
            {
                StringBuilder json = new StringBuilder();
                json.Append("{");
                foreach (var prop in item.GetType().GetRuntimeProperties())
                {
                    if (prop.GetValue(item).ToString() == "")
                        json.Append($"\"{prop.Name}\": \"\", ");
                    else
                        json.Append($"\"{prop.Name}\": \"{prop.GetValue(item)}\", ");
                }

                if (json.Length > 1)
                    json.Remove(json.Length - 2, 1);

                json.Append("}");

                return API.DeserializeJSon<T>(await API.PostRestful(APIEndpoint + "/" + id.ToString(), json.ToString(), parms).ConfigureAwait(false));
            }
            else
                return API.DeserializeJSon<T>(await API.PostRestful(APIEndpoint + "/" + id.ToString(), item, parms).ConfigureAwait(false));
        }

        public virtual async Task<BatchObject<T>> UpdateRange(BatchObject<T> items, Dictionary<string, string> parms = null)
        {
            string json = await UpdateRangeRaw(items, parms);

            if (items.delete == null || items.delete.Count == 0)
                return API.DeserializeJSon<BatchObject<T>>(json);
            else
            {
                BatchObject<T> batchResult = new BatchObject<T>();

                if ((items.create == null || items.create.Count == 0) && (items.update == null || items.update.Count == 0))
                {
                    batchResult.DeletedItems = API.DeserializeJSon<List<T>>(json.Substring(json.IndexOf("[")).TrimEnd('}'));
                }
                else
                {
                    var pos = json.LastIndexOf("\"delete\":[");
                    if (pos != -1)
                    {
                        batchResult = API.DeserializeJSon<BatchObject<T>>(json.Substring(0, pos - 1) + "}");
                        batchResult.DeletedItems = API.DeserializeJSon<List<T>>(json.Substring(pos + 9).TrimEnd('}'));
                    }
                    else
                        batchResult = API.DeserializeJSon<BatchObject<T>>(json);
                }

                return batchResult;
            }
        }

        public virtual async Task<string> UpdateRangeRaw(BatchObject<T> items, Dictionary<string, string> parms = null)
        {
            return await API.PostRestful(APIEndpoint + "/batch", items, parms).ConfigureAwait(false);
        }

        public virtual async Task<T> Delete(ulong id, bool force = false, Dictionary<string, string> parms = null)
        {
            if (force)
            {
                if (parms == null)
                    parms = new Dictionary<string, string>();

                if (!parms.ContainsKey("force"))
                    parms.Add("force", "true");
            }

            return API.DeserializeJSon<T>(await API.DeleteRestful(APIEndpoint + "/" + id.ToString(), parms).ConfigureAwait(false));
        }

        [Obsolete("DeleteRange method is obsolete, please use UpdateRange for batch Add, Update, Delete.")]
        public async Task<string> DeleteRange(BatchObject<T> items, Dictionary<string, string> parms = null)
        {
            return await API.PostRestful(APIEndpoint + "/batch", items, parms).ConfigureAwait(false);
        }
    }

    public class WCSubItem<T>
    {
        public string APIEndpoint { get; protected set; }
        public string APIParentEndpoint { get; protected set; }
        public RestAPI API { get; protected set; }

        public WCSubItem(RestAPI api, string parentEndpoint)
        {
            API = api;
            if (typeof(T).BaseType.FullName.Contains("v2"))
                APIEndpoint = typeof(T).BaseType.GetRuntimeProperty("Endpoint").GetValue(null).ToString();
            else
                APIEndpoint = typeof(T).GetRuntimeProperty("Endpoint").GetValue(null).ToString();

            APIParentEndpoint = parentEndpoint;
        }

        public virtual async Task<T> Get(ulong id, ulong parentId, Dictionary<string, string> parms = null)
        {
            return API.DeserializeJSon<T>(await API.GetRestful(APIParentEndpoint + "/" + parentId.ToString() + "/" + APIEndpoint + "/" + id.ToString(), parms).ConfigureAwait(false));
        }

        public virtual async Task<List<T>> GetAll(object parentId, Dictionary<string, string> parms = null)
        {
            return API.DeserializeJSon<List<T>>(await API.GetRestful(APIParentEndpoint + "/" + parentId.ToString() + "/" + APIEndpoint, parms).ConfigureAwait(false));
        }

        public virtual async Task<T> Add(T item, ulong parentId, Dictionary<string, string> parms = null)
        {
            return API.DeserializeJSon<T>(await API.PostRestful(APIParentEndpoint + "/" + parentId.ToString() + "/" + APIEndpoint, item, parms).ConfigureAwait(false));
        }

        public virtual async Task<T> Update(ulong id, T item, ulong parentId, Dictionary<string, string> parms = null)
        {
            return API.DeserializeJSon<T>(await API.PostRestful(APIParentEndpoint + "/" + parentId.ToString() + "/" + APIEndpoint + "/" + id.ToString(), item, parms).ConfigureAwait(false));
        }

        public virtual async Task<T> UpdateWithNull(ulong id, ulong parentId, object item, Dictionary<string, string> parms = null)
        {
            if (API.GetType().Name == "RestAPI")
            {
                StringBuilder json = new StringBuilder();
                json.Append("{");
                foreach (var prop in item.GetType().GetProperties())
                {
                    if (prop.GetValue(item).ToString() == "")
                        json.Append($"\"{prop.Name}\": \"\", ");
                    else
                        json.Append($"\"{prop.Name}\": \"{prop.GetValue(item)}\", ");
                }

                if (json.Length > 1)
                    json.Remove(json.Length - 2, 1);

                json.Append("}");

                return API.DeserializeJSon<T>(await API.PostRestful(APIParentEndpoint + "/" + parentId.ToString() + "/" + APIEndpoint + "/" + id.ToString(), json.ToString(), parms).ConfigureAwait(false));
            }
            else
                return API.DeserializeJSon<T>(await API.PostRestful(APIParentEndpoint + "/" + parentId.ToString() + "/" + APIEndpoint + "/" + id.ToString(), item, parms).ConfigureAwait(false));
        }

        public virtual async Task<BatchObject<T>> UpdateRange(ulong parentId, BatchObject<T> items, Dictionary<string, string> parms = null)
        {
            string json = await UpdateRangeRaw(parentId, items, parms);

            if (items.delete == null || items.delete.Count == 0)
                return API.DeserializeJSon<BatchObject<T>>(json);
            else
            {
                BatchObject<T> batchResult = new BatchObject<T>();

                if ((items.create == null || items.create.Count == 0) && (items.update == null || items.update.Count == 0))
                {
                    batchResult.DeletedItems = API.DeserializeJSon<List<T>>(json.Substring(json.IndexOf("[")).TrimEnd('}'));
                }
                else
                {
                    var pos = json.LastIndexOf("\"delete\":[");
                    if (pos != -1)
                    {
                        batchResult = API.DeserializeJSon<BatchObject<T>>(json.Substring(0, pos - 1) + "}");
                        batchResult.DeletedItems = API.DeserializeJSon<List<T>>(json.Substring(pos + 9).TrimEnd('}'));
                    }
                    else
                        batchResult = API.DeserializeJSon<BatchObject<T>>(json);
                }

                return batchResult;
            }
        }

        public virtual async Task<string> UpdateRangeRaw(ulong parentId, BatchObject<T> items, Dictionary<string, string> parms = null)
        {
            return await API.PostRestful(APIParentEndpoint + "/" + parentId.ToString() + "/" + APIEndpoint + "/batch", items, parms).ConfigureAwait(false);
        }

        public virtual async Task<string> Delete(ulong id, ulong parentId, bool force = false, Dictionary<string, string> parms = null)
        {
            if (force)
            {
                if (parms == null)
                    parms = new Dictionary<string, string>();

                if (!parms.ContainsKey("force"))
                    parms.Add("force", "true");
            }

            return await API.DeleteRestful(APIParentEndpoint + "/" + parentId.ToString() + "/" + APIEndpoint + "/" + id.ToString(), parms).ConfigureAwait(false);
        }
    }
}
