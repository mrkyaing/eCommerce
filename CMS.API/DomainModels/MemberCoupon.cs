using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.API.DomainModels
{
    public class MemberCoupon
    {
        public string Id { get; set; }
        public string CouponId { get; set; }
        [ForeignKey("CouponId")]
        public virtual Coupon Coupon { get; set; }
        public string MemberId { get; set; }
        [ForeignKey("MemberId")]
        public virtual Member Member { get; set; }
        public string ReceiptNumber { get; set; }
        public DateTime UsedDate { get; set; }
    }
}
