using System;
using System.Threading.Tasks;

namespace SMSGATEWAY.DOMAIN.Interfaces
{
    public interface IUnitOfWork : IAsyncDisposable
    {
        Task<bool> CommitAsync();
    }
}