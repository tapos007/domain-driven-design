using System;

namespace SMSGATEWAY.APPLICATION.ViewModels
{
    public class VendorInfoViewModel
    {
        public Guid Guid { get; set; }
        public string Name { get;  set; }
        public string ShortName { get;  set; }
        public string Details { get;  set; }
        public string AdminUrl { get;  set; }
        public string UserName { get;  set; }
        public string Password { get;  set; }
    }
}