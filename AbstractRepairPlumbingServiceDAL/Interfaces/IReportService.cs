using AbdtractRepairPlumbingServiceDAL.ViewModel;
using AbstractRepairPlumbingServiceDAL.BindingModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbdtractRepairPlumbingServiceDAL.Interfaces
{
    public interface IReportService
    {
        void SaveRepairPrice(ReportBindingModel model);
        List<StoragesLoadViewModel> GetStoragesLoad();
        void SaveStoragesLoad(ReportBindingModel model);
        List<ClientOrdersModel> GetClientOrders(ReportBindingModel model);
        void SaveClientOrders(ReportBindingModel model);
    }
}
