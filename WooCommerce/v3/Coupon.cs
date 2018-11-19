using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using WooCommerceNET.Base;

namespace WooCommerceNET.WooCommerce.v3
{
    public class CouponBatch : BatchObject<Coupon> { }

    public class Coupon : v2.Coupon { }
}
