using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointSystem.API.DomainModels
{
    public class MemberPointModel
    {
        public string MemberCode { get; set; }
        public string CouponCode { get; set; }
        public string ReceiptNumber { get; set; }
        public List<OrderItemModel> OrderItems { get; set; }
    }

    public class OrderItemModel
    {
        public OrderModel Order { get; set; }
    }
    public class OrderModel
    {
        public Product Product { get; set; }
        public int  Qty { get; set; }
        public double TotalPrice { get; set; }
    }
    public class Product
    {
        public Category Category { get; set; }
        public double Price { get; set; }
    }
    public class Category
    {
        public string Name { get; set; }
    }
}
