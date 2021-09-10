using SMSGATEWAY.DOMAIN.Interfaces.EFREPO;
using SMSGATEWAY.DOMAIN.Models;
using SMSGATEWAY.Infra.Data.Context;

namespace SMSGATEWAY.Infra.Data.Repository
{
    public class VendorInfoRepository : Repository<VendorInfo>,IVendorInfoRepository
    {
        public VendorInfoRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}