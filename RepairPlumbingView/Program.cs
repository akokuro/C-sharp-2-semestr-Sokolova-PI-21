using AbdtractFoodOrderServiceDAL.Interfaces;
using AbdtractRepairOrderServiceDAL.Interfaces;
using AbstractRepairOrderServiceDAL.Interfaces;
using AbstractRepairOrderServiceImplementList.Implementations;
using AbstractRepairPlumbingServiceImplementDataBase;
using System;
using System.Data.Entity;
using System.Windows.Forms;
using Unity;
using Unity.Lifetime;

namespace RepairOrderView
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            var container = BuildUnityContainer();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(container.Resolve<FormMain>());
        }
        public static IUnityContainer BuildUnityContainer()
        {
            var currentContainer = new UnityContainer();
            currentContainer.RegisterType<DbContext, AbstractRepairPlumbingDbContext>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<IReportService, ReportServiceDB>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<IClientService, ClientServiceDB>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<IPlumbingService, PlumbingServiceDB>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<IRepairService, RepairServiceDB>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<IMainService, MainServiceDB>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<IStorageService, StorageServiceDB>(new HierarchicalLifetimeManager());
            return currentContainer;
        }
    }
}
