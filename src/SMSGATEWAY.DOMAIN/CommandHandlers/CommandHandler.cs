using System.Threading.Tasks;
using MediatR;
using SMSGATEWAY.Domain.Core.Bus;
using SMSGATEWAY.Domain.Core.Commands;
using SMSGATEWAY.Domain.Core.Notifications;
using SMSGATEWAY.DOMAIN.Interfaces;

namespace SMSGATEWAY.DOMAIN.CommandHandlers
{
    public class CommandHandler
    {
        private readonly IUnitOfWork _uow;
        private readonly IMediatorHandler _bus;
        private readonly DomainNotificationHandler _notifications;

        public CommandHandler(IUnitOfWork uow, IMediatorHandler bus, INotificationHandler<DomainNotification> notifications)
        {
            _uow = uow;
            _notifications = (DomainNotificationHandler)notifications;
            _bus = bus;
        }

        protected void NotifyValidationErrors(Command message)
        {
            foreach (var error in message.ValidationResult.Errors)
            {
                _bus.RaiseEvent(new DomainNotification(message.MessageType, error.ErrorMessage));
            }
        }

        public bool CommitAsync()
        {
            if (_notifications.HasNotifications()) return false;
            if (   _uow. Commit()) return true;

            _bus.RaiseEvent(new DomainNotification("Commit", "We had a problem during saving your data."));
            return false;
        }
    }
}