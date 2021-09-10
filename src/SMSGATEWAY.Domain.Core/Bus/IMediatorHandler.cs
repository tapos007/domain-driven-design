using System.Threading.Tasks;
using SMSGATEWAY.Domain.Core.Commands;
using SMSGATEWAY.Domain.Core.Events;

namespace SMSGATEWAY.Domain.Core.Bus
{
    public interface IMediatorHandler
    {
        Task SendCommand<T>(T command) where T : Command;
        Task RaiseEvent<T>(T @event) where T : Event;
    }
}