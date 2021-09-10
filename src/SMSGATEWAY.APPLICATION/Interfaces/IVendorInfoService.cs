using System;
using System.Collections.Generic;
using SMSGATEWAY.APPLICATION.ViewModels;

namespace SMSGATEWAY.APPLICATION.Interfaces
{
    public interface IVendorInfoService : IDisposable
    {
        void Register(VendorInfoViewModel customerViewModel);
        IEnumerable<VendorInfoViewModel> GetAll();
        IEnumerable<VendorInfoViewModel> GetAll(int skip, int take);
        VendorInfoViewModel GetById(Guid id);
        void Update(VendorInfoViewModel customerViewModel);
        void Remove(Guid id);
       // IList<CustomerHistoryData> GetAllHistory(Guid id);
    }
}