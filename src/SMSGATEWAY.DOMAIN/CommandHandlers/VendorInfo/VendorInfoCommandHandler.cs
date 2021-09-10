using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using SMSGATEWAY.DOMAIN.Commands.VendorInfo;
using SMSGATEWAY.Domain.Core.Bus;
using SMSGATEWAY.Domain.Core.Events;
using SMSGATEWAY.Domain.Core.Notifications;
using SMSGATEWAY.DOMAIN.Events.VendorInfo;
using SMSGATEWAY.DOMAIN.Interfaces;
using SMSGATEWAY.DOMAIN.Interfaces.EFREPO;

namespace SMSGATEWAY.DOMAIN.CommandHandlers.VendorInfo
{
    public class VendorInfoCommandHandler : CommandHandler,IRequestHandler<NewVendorInfoCommand,bool>
    {
        private readonly IVendorInfoRepository _vendorInfoRepository;
        private readonly IMediatorHandler Bus;

        public VendorInfoCommandHandler(
            IUnitOfWork uow, IMediatorHandler bus, INotificationHandler<DomainNotification> notifications,
            IVendorInfoRepository vendorInfoRepository) : base(uow, bus, notifications)
        {
            _vendorInfoRepository = vendorInfoRepository;
            Bus = bus;
        }

        public async Task<bool> Handle(NewVendorInfoCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid())
            {
                NotifyValidationErrors(request);
                return false;
            }

            var vendorInfo = new Models.VendorInfo(Guid.NewGuid(), request.Name, request.ShortName, request.Details,
                request.AdminUrl, request.UserName, request.Password);
            
            _vendorInfoRepository.Add(vendorInfo);

            if (CommitAsync())
            {
               await Bus.RaiseEvent(new AddVendorEvent(vendorInfo.Id, vendorInfo.Name, vendorInfo.ShortName,
                    vendorInfo.Details, vendorInfo.AdminUrl, vendorInfo.UserName,
                    vendorInfo.Password));
            }

            return true;

        }
    }
}