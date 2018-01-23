using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace WooCommerceNET.WooCommerce.v1
{
    [DataContract]
    public class Report
    {
        /// <summary>
        /// Report slug
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string slug { get; set; }

        /// <summary>
        /// Report description
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string description { get; set; }
    }

    [DataContract]
    public class SalesReport
    {
        /// <summary>
        /// Gross sales in the period. 
        /// read-only
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public decimal? total_sales { get; set; }

        /// <summary>
        /// Net sales in the period. 
        /// read-only
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public decimal? net_sales { get; set; }

        /// <summary>
        /// Average net daily sales. 
        /// read-only
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public decimal? average_sales { get; set; }

        /// <summary>
        /// Total of orders placed. 
        /// read-only
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public int? total_orders { get; set; }

        /// <summary>
        /// Total of items purchased. 
        /// read-only
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public int? total_items { get; set; }

        /// <summary>
        /// Total charged for taxes. 
        /// read-only
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public decimal? total_tax { get; set; }

        /// <summary>
        /// Total charged for shipping. 
        /// read-only
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public decimal? total_shipping { get; set; }

        /// <summary>
        /// Total of refunded orders. 
        /// read-only
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public int? total_refunds { get; set; }

        /// <summary>
        /// Total of coupons used. 
        /// read-only
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public decimal? total_discount { get; set; }

        /// <summary>
        /// Group type. 
        /// read-only
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string totals_grouped_by { get; set; }

        /// <summary>
        /// Totals. 
        /// read-only
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public List<string> totals { get; set; }
    }

    [DataContract]
    public class TopSellersReport
    {
        /// <summary>
        /// Product title. 
        /// read-only
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string title { get; set; }

        /// <summary>
        /// Product ID. 
        /// read-only
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public int product_id { get; set; }

        /// <summary>
        /// Total number of purchases. 
        /// read-only
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public int quantity { get; set; }

    }

}
