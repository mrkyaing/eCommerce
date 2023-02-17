using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.API.Domain
{
    public class OrderItemModel
    {
        public string Id { get; set; }
        public string OrderId { get; set; }
        [ForeignKey("OrderId")]
        public virtual OrderModel Order { get; set; }
        public string ProductId { get; set; }
        [ForeignKey("ProductId")]
        public virtual ProductModel Product { get; set; }
        public int Quantity { get; set; }
        public double TotalPrice { get; set; }
    }
}
