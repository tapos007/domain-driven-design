using System;
using SMSGATEWAY.Domain.Core.Events;

namespace SMSGATEWAY.DOMAIN.Events.VendorInfo
{
    public class AddVendorEvent : Event
    {
        public AddVendorEvent(Guid id,string name, string shortName, string details, string adminUrl, string userName, string password)
        {
            Id = id;
            Name = name;
            ShortName = shortName;
            Details = details;
            AdminUrl = adminUrl;
            UserName = userName;
            Password = password;
            AggregateId = id;
        }

        
        public Guid Id { get; set; }
        public string Name { get; private set; }
        public string ShortName { get; private set; }
        public string Details { get; private set; }
        public string AdminUrl { get; private set; }
        public string UserName { get; private set; }
        public string Password { get; private set; }
    }
}