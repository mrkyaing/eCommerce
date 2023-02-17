using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointSystem.API.DomainModels
{
    public   class Point
    {
        public string Id { get; set; }
        public string MemberCode { get; set; }
        public int TotalPoints { get; set; }
        public DateTime ExpiryPointDate { get; set; }
    }
}
