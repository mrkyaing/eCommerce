using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.API.Domain
{
    public class MemberPointModel
    {
        public string MemberCode { get; set; }
        public string CouponCode { get; set; }
        public string ReceiptNumber { get; set; }
        public List<OrderItemModel> OrderItems { get; set; }
    }
}
