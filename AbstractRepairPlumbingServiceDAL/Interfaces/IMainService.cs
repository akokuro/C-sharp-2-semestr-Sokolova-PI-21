﻿using AbstractRepairOrderServiceDAL.BindingModel;
using AbstractRepairOrderServiceDAL.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractRepairOrderServiceDAL.Interfaces
{
    public interface IMainService
    {
        List<OrderViewModel> GetList();
        void CreateOrder(OrderBindingModel model);
        void TakeOrderInWork(OrderBindingModel model);
        void FinishOrder(OrderBindingModel model);
        void PayOrder(OrderBindingModel model);
        void PutComponentOnStorage(StorageComponentBindingModel model);
    }
}
