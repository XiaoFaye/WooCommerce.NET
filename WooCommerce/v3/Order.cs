using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using WooCommerceNET.Base;

namespace WooCommerceNET.WooCommerce.v3
{
    public class OrderBatch : BatchObject<Order> { }

    [DataContract]
    public class Order : v2.Order { }
    
}
