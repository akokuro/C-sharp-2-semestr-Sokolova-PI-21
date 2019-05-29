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
    [CustomInterface("Интерфейс для работы с заказами")]
    public interface IMainService
    {
        [CustomMethod("Метод получения списка заказов")]
        List<OrderViewModel> GetList();
        [CustomMethod("Метод получения списка не сделанных заказов")]
        List<OrderViewModel> GetFreeOrders();
        [CustomMethod("Метод получения списка исполнителей")]
        void CreateOrder(OrderBindingModel model);
        [CustomMethod("Метод отправки заказа в работу")]
        void TakeOrderInWork(OrderBindingModel model);
        [CustomMethod("Метод завершения заказа")]
        void FinishOrder(OrderBindingModel model);
        [CustomMethod("Метод оплаты заказа")]
        void PayOrder(OrderBindingModel model);
        [CustomMethod("Метод добавления сантехники в хранилище")]
        void PutComponentOnStorage(StoragePlumbingBindingModel model);
    }
}
