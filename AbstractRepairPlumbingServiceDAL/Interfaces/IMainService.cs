using AbdtractRepairOrderServiceDAL.BindingModel;
using AbdtractRepairOrderServiceDAL.ViewModel;
using AbstractRepairOrderServiceDAL.BindingModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbdtractRepairOrderServiceDAL.Interfaces
{
    public interface IMainService
    {
        List<OrderViewModel> GetList();
        List<OrderViewModel> GetFreeOrders();
        void CreateOrder(OrderBindingModel model);
        void TakeOrderInWork(OrderBindingModel model);
        void FinishOrder(OrderBindingModel model);
        void PayOrder(OrderBindingModel model);
        void PutComponentOnStorage(StoragePlumbingBindingModel model);
    }
}
