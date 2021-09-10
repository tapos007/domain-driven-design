using System;
using SMSGATEWAY.Domain.Core.Commands;

namespace SMSGATEWAY.DOMAIN.Commands.VendorInfo
{
    public abstract class VendorInfoCommand : Command
    {
        public Guid Id { get; protected set; }

        public string Name { get; protected set; }
        public string ShortName { get; protected set; }
        public string Details { get; protected set; }
        public string AdminUrl { get; protected set; }
        public string UserName { get; protected set; }
        public string Password { get; protected set; }
    }
}