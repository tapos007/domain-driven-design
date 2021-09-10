using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using SMSGATEWAY.DOMAIN.Events.VendorInfo;

namespace SMSGATEWAY.DOMAIN.EventHandlers.VendorInfEventHandler
{
    public class VendorInfoEventHandler: INotificationHandler<AddVendorEvent>
    {
        public Task Handle(AddVendorEvent notification, CancellationToken cancellationToken)
        {
            // done multiple work for this event
            return Task.CompletedTask;
        }
    }

    
}