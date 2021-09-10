using MediatR;
using Microsoft.AspNetCore.Mvc;
using SMSGATEWAY.APPLICATION.Interfaces;
using SMSGATEWAY.APPLICATION.ViewModels;
using SMSGATEWAY.Domain.Core.Bus;
using SMSGATEWAY.Domain.Core.Notifications;

namespace SMSGATEWAY.Services.API.Controllers
{
    public class VendorInfoController : ApiController
    {
        private readonly IVendorInfoService _vendorInfoService;

        public VendorInfoController(IVendorInfoService vendorInfoService,
            INotificationHandler<DomainNotification> notifications, IMediatorHandler mediator) : base(notifications, mediator)
        {
            _vendorInfoService = vendorInfoService;
        }

        [HttpPost]
        [Route("vendor-insert")]
        public IActionResult Post([FromBody]VendorInfoViewModel customerViewModel)
        {
            if (!ModelState.IsValid)
            {
                NotifyModelStateErrors();
                return Response(customerViewModel);
            }

            _vendorInfoService.Register(customerViewModel);

            return Response(customerViewModel);
        }
    }
}