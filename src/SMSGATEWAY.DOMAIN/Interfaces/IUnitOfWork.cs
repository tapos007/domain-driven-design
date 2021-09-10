using System;
using System.Threading.Tasks;

namespace SMSGATEWAY.DOMAIN.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        bool Commit();
    }
}