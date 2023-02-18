using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mobile.API.DomainModels
{
    public class OTPModel
    {
        public string MobileNumber { get; set; }
        public string OTP { get; set; }
        public TimeSpan ExpiryTime { get; set; }
    }
}
