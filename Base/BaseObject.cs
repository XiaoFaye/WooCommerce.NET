using System;
using System.Collections.Generic;
using System.Globalization;
using System.Reflection;
using System.Runtime.Serialization;

namespace WooCommerceNET.Base
{
    [DataContract]
    public class JsonObject
    {
        [OnSerializing]
        void OnSerializing(StreamingContext ctx)
        {
            foreach (PropertyInfo pi in GetType().GetRuntimeProperties())
            {
                PropertyInfo objValue = GetType().GetRuntimeProperties().FindByName(pi.Name + "Value");
                if (objValue != null)
                {
                    if (pi.PropertyType == typeof(decimal?))
                    {
                        if (pi.GetValue(this) != null)
                            objValue.SetValue(this, pi.GetValue(this).ToString());
                    }
                    else if (pi.PropertyType == typeof(DateTime?))
                    {
                        if (pi.GetValue(this) != null)
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
                            pi.SetValue(this, decimal.Parse(value.ToString(), CultureInfo.InvariantCulture));
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
    }

    public class BatchObject<T>
    {
        [DataMember(EmitDefaultValue = false)]
        public List<T> create { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public List<T> update { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public List<int> delete { get; set; }
    }
}
