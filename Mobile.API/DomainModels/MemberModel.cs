﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mobile.API.DomainModels
{
    public class MemberModel
    {
        public string Name { get; set; }
        public string MobileNumber { get; set; }
        public OTPModel OTPModel { get; set; }
    }
}
