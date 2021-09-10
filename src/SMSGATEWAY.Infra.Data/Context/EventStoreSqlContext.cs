using Microsoft.EntityFrameworkCore;
using SMSGATEWAY.Domain.Core.Events;

namespace SMSGATEWAY.Infra.Data.Context
{
    public class EventStoreSqlContext : DbContext
    {
        public EventStoreSqlContext(DbContextOptions<EventStoreSqlContext> options) : base(options)
        {
        }

        public DbSet<StoredEvent> StoredEvent { get; set; }

        
    }
}