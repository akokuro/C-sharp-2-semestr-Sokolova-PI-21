using AbstractRepairPlumbingServiceDAL.Attributies;
using AbstractRepairPlumbingServiceDAL.BindingModel;
using AbstractRepairPlumbingServiceDAL.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractRepairPlumbingServiceDAL.Interfaces
{
    [CustomInterface("Интерфейс для работы с отчетами")]
    public interface IReportService
    {
        [CustomMethod("Метод сохранения цены ремонта сантехники")]
        void SaveRepairPrice(ReportBindingModel model);
        [CustomMethod("Метод получения списка сантехники, находящегося в хранилище")]
        List<StoragesLoadViewModel> GetStoragesLoad();
        [CustomMethod("Метод сохранения информации по хранилищам в отчет")]
        void SaveStoragesLoad(ReportBindingModel model);
        [CustomMethod("Метод получения списка заказов клиентов")]
        List<ClientOrdersModel> GetClientOrders(ReportBindingModel model);
        [CustomMethod("Метод сохранения информации по заказам клиентов в отчет")]
        void SaveClientOrders(ReportBindingModel model);
    }
}
