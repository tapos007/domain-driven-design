using MediatR;
using Microsoft.Extensions.DependencyInjection;
using SMSGATEWAY.APPLICATION.Interfaces;
using SMSGATEWAY.APPLICATION.Services;
using SMSGATEWAY.DOMAIN.CommandHandlers.VendorInfo;
using SMSGATEWAY.DOMAIN.Commands.VendorInfo;
using SMSGATEWAY.Domain.Core.Bus;
using SMSGATEWAY.Domain.Core.Events;
using SMSGATEWAY.Domain.Core.Notifications;
using SMSGATEWAY.DOMAIN.EventHandlers.VendorInfEventHandler;
using SMSGATEWAY.DOMAIN.Events.VendorInfo;
using SMSGATEWAY.DOMAIN.Interfaces;
using SMSGATEWAY.DOMAIN.Interfaces.EFREPO;
using SMSGATEWAY.Infra.Bus;
using SMSGATEWAY.Infra.Data.EventSourcing;
using SMSGATEWAY.Infra.Data.Repository;
using SMSGATEWAY.Infra.Data.Repository.EventSourcing;
using SMSGATEWAY.Infra.Data.UoW;
using SMSGATEWAY.Infra.Identity.Models;

namespace SMSGATEWAY.Infra.IoC
{
    public class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            // ASP.NET HttpContext dependency
            services.AddHttpContextAccessor();
            
            // Domain Bus (Mediator)
            services.AddScoped<IMediatorHandler, InMemoryBus>();
            
            
            // Application
            services.AddScoped<IVendorInfoService, VendorInfoService>();
            
            // Domain - Events
            services.AddScoped<INotificationHandler<DomainNotification>, DomainNotificationHandler>();
            services.AddScoped<INotificationHandler<AddVendorEvent>, VendorInfoEventHandler>();
            
            // Domain - Commands 
            
            services.AddScoped<IRequestHandler<NewVendorInfoCommand, bool>, VendorInfoCommandHandler>();
            
            
            // Infra - Data
            services.AddScoped<IVendorInfoRepository, VendorInfoRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            
            // Infra - Data EventSourcing
            services.AddScoped<IEventStoreRepository, EventStoreSqlRepository>();
            services.AddScoped<IEventStore, SqlEventStore>();
            
            
            // Infra - Identity
            services.AddScoped<IUser, AspNetUser>();
           
        }
    }
}