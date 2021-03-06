using System;
using SMSGATEWAY.Domain.Core.Models;

namespace SMSGATEWAY.DOMAIN.Models
{
    public class VendorInfo : EntityAudit
    {
        public VendorInfo(Guid id,string name, string shortName, string details, string adminUrl, string userName, string password)
        {
            Id = id;
            Name = name;
            ShortName = shortName;
            Details = details;
            AdminUrl = adminUrl;
            UserName = userName;
            Password = password;
        }

        // Empty constructor for EF
        protected VendorInfo()
        {
        }

        public string Name { get; private set; }
        public string ShortName { get; private set; }
        public string Details { get; private set; }
        public string AdminUrl { get; private set; }
        public string UserName { get; private set; }
        public string Password { get; private set; }
        
    }
}