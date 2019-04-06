using AbdtractFoodOrderServiceDAL.BindingModel;
using AbdtractFoodOrderServiceDAL.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbdtractFoodOrderServiceDAL.Interfaces
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
