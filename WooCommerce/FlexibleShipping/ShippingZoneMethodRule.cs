using System.Collections.Generic;

namespace WooCommerceNET.WooCommerce.FlexibleShipping
{
    public class ShippingZoneMethodRule
    {
        public ICollection<ShippingZoneMethodRuleCondition> conditions { get; set; }
        public string cost_per_order { get; set; }
    }

    public class ShippingZoneMethodRuleCondition
    {
        public string condition_id { get; set; }
        public string min { get; set; }
        public string max { get; set; }
    }
}
