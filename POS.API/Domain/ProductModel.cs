using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.API.Domain
{
    public class ProductModel
    {
        public string Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public double UnitPrice { get; set; }
        public string CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public virtual CategoryModel Category { get; set; }
        public string BarCodeNumber { get; set; }
    }
}
