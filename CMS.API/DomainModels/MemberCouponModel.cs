using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.API.DomainModels
{
    public class MemberCouponModel
    {
        public string CouponCode { get; set; }
        public string CouponName { get; set; }
        public string MemberCode { get; set; }
        public string ReceiptNumber { get; set; }
        public DateTime UsedDate { get; set; }
    }
}
