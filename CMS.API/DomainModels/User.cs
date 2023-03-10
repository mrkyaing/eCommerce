using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.API.DomainModels
{
    public class User
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool IsCurrentLogin { get; set; }
        public string DeviceId { get; set; }
        public string MemberId { get; set; }

        [ForeignKey("MemberId")]
        public virtual Member Member { get; set; }
    }
}
