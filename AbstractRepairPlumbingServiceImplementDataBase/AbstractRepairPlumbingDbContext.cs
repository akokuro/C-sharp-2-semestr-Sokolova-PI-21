using AbstractRepairOrderModel;
using System.Data.Entity;

namespace AbstractRepairPlumbingServiceImplementDataBase
{
    public class AbstractRepairPlumbingDbContext : DbContext
    {
        public AbstractRepairPlumbingDbContext() : base("1")
        {
            //настройки конфигурации для entity
            Configuration.ProxyCreationEnabled = false;
            Configuration.LazyLoadingEnabled = false;
            var ensureDLLIsCopied =
           System.Data.Entity.SqlServer.SqlProviderServices.Instance;
        }
        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<Plumbing> Plumbings { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Repair> Repairs { get; set; }
        public virtual DbSet<RepairPlumbing> RepairPlumbings { get; set; }
        public virtual DbSet<Storage> Storages { get; set; }
        public virtual DbSet<StoragePlumbing> StoragePlumbings { get; set; }
    }
}
