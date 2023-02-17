using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.API.Domain
{
    public class OrderModel
    {
        public string Id { get; set; }
        public string Code { get; set; }
        public DateTime OrderDate { get; set; }
        public string Status { get; set; }
        public DateTime ShippingDate { get; set; }
    }
}
