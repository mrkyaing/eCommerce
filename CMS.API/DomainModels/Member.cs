using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.API.DomainModels{
    public class Member{
        public string Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string MobileNumber { get; set; }
        public int TotalPoints{ get; set; }
        public double TotalPurchasedAmount { get; set; }
    }
}
