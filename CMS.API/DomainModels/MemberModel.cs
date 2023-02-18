using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.API.DomainModels
{
    public class MemberModel
    {
        public string Name { get; set; }
        public string MobileNumber { get; set; }
        public int TotalPoints { get; set; }
        public double TotalPurchasedAmount { get; set; }
    }
}
