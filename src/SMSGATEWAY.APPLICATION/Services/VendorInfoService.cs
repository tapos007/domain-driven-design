using System;
using System.Collections.Generic;
using SMSGATEWAY.APPLICATION.Interfaces;
using SMSGATEWAY.APPLICATION.ViewModels;
using SMSGATEWAY.DOMAIN.Commands.VendorInfo;
using SMSGATEWAY.Domain.Core.Bus;

namespace SMSGATEWAY.APPLICATION.Services
{
    public class VendorInfoService : IVendorInfoService
    {
        private readonly IMediatorHandler _bus;

        public VendorInfoService(IMediatorHandler bus)
        {
            _bus = bus;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public void Register(VendorInfoViewModel customerViewModel)
        {
            _bus.SendCommand(new NewVendorInfoCommand(customerViewModel.Name, customerViewModel.ShortName,
                customerViewModel.Details, customerViewModel.AdminUrl,
                customerViewModel.UserName, customerViewModel.Password));
        }

        public IEnumerable<VendorInfoViewModel> GetAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<VendorInfoViewModel> GetAll(int skip, int take)
        {
            throw new NotImplementedException();
        }

        public VendorInfoViewModel GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Update(VendorInfoViewModel customerViewModel)
        {
            throw new NotImplementedException();
        }

        public void Remove(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}