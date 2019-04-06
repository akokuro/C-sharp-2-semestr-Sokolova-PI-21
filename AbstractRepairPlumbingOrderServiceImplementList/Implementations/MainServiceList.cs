using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AbstractRepairOrderModel;
using AbdtractRepairOrderServiceDAL.Interfaces;
using AbdtractRepairOrderServiceDAL.BindingModel;
using AbdtractRepairOrderServiceDAL.ViewModel;
using AbstractRepairOrderServiceDAL.BindingModel;

namespace AbstractRepairOrderServiceImplementList.Implementations
{
    public class MainServiceList : IMainService
    {
        private DataListSingleton source;
        public MainServiceList()
        {
            source = DataListSingleton.GetInstance();
        }
        public List<OrderViewModel> GetList()
        {
            List<OrderViewModel> result = source.Orders.Select(rec => new OrderViewModel
            {
                Id = rec.Id,
                ClientId = rec.ClientId,
                RepairId = rec.RepairId,
                DateCreate = rec.DateCreate.ToLongDateString(),
                DateImplement = rec.DateImplement?.ToLongDateString(),
                Status = rec.Status.ToString(),
                Count = rec.Count,
                Sum = rec.Sum,
                ClientFIO = source.Clients.FirstOrDefault(recC => recC.Id == rec.ClientId)?.ClientFIO,
                RepairName = source.Repairs.FirstOrDefault(recP => recP.Id == rec.RepairId)?.RepairName,
            }).ToList();
            return result;
        }
        public void CreateOrder(OrderBindingModel model)
        {
            int maxId = source.Orders.Count > 0 ? source.Orders.Max(rec => rec.Id) : 0;
            source.Orders.Add(new Order
            {
                Id = maxId + 1,
                ClientId = model.ClientId,
                RepairId = model.RepairId,
                DateCreate = DateTime.Now,
                Count = model.Count,
                Sum = model.Sum,
                Status = OrderStatus.Принят
            });
        }
        public void TakeOrderInWork(OrderBindingModel model)
        {
            Order element = source.Orders.FirstOrDefault(rec => rec.Id == model.Id);
            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            if (element.Status != OrderStatus.Принят)
            {
                throw new Exception("Заказ не в статусе \"Принят\"");
            }
            // смотрим по количеству компонентов на складах
            var repairPlumbings = source.RepairPlumbings.Where(rec => rec.RepairId
           == element.RepairId);
            foreach (var repairComponent in repairPlumbings)
            {
                int countOnstorages = source.StoragePlumbings
                .Where(rec => rec.ComponentId ==
               repairComponent.PlumbingId)
               .Sum(rec => rec.Count);
                if (countOnstorages < repairComponent.Count * element.Count)
                {
                    var componentName = source.Plumbings.FirstOrDefault(rec => rec.Id ==
                   repairComponent.PlumbingId);
                    throw new Exception("Не достаточно компонента " +
                   componentName?.PlumbingName + " требуется " + (repairComponent.Count * element.Count) +
                   ", в наличии " + countOnstorages);
                }
            }
            // списываем
            foreach (var repairPlumbing in repairPlumbings)
            {
                int countOnstorages = repairPlumbing.Count * element.Count;
                var storageComponents = source.StoragePlumbings.Where(rec => rec.ComponentId
               == repairPlumbing.PlumbingId);
                foreach (var storageComponent in storageComponents)
                {
                    // компонентов на одном слкаде может не хватать
                    if (storageComponent.Count >= countOnstorages)
                    {
                        storageComponent.Count -= countOnstorages;
                        break;
                    }
                    else
                    {
                        countOnstorages -= storageComponent.Count;
                        storageComponent.Count = 0;
                    }
                }
            }
            element.DateImplement = DateTime.Now;
            element.Status = OrderStatus.Выполняется;
        }
        public void FinishOrder(OrderBindingModel model)
        {
            Order element = source.Orders.FirstOrDefault(rec => rec.Id == model.Id);
            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            if (element.Status != OrderStatus.Выполняется)
            {
                throw new Exception("Заказ не в статусе \"Выполняется\"");
            }
            element.Status = OrderStatus.Готов;
        }
        public void PayOrder(OrderBindingModel model)
        {
            Order element = source.Orders.FirstOrDefault(rec => rec.Id == model.Id);
            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            if (element.Status != OrderStatus.Готов)
            {
                throw new Exception("Заказ не в статусе \"Готов\"");
            }
            element.Status = OrderStatus.Оплачен;
        }

        public void PutComponentOnStorage(StoragePlumbingBindingModel model)
        {
            StoragePlumbing element = source.StoragePlumbings.FirstOrDefault(rec =>
 rec.StorageId == model.StorageId && rec.ComponentId == model.PlumbingId);
            if (element != null)
            {
                element.Count += model.Count;
            }
            else
            {
                int maxId = source.StoragePlumbings.Count > 0 ?
               source.StoragePlumbings.Max(rec => rec.Id) : 0;
                source.StoragePlumbings.Add(new StoragePlumbing
                {
                    Id = ++maxId,
                    StorageId = model.StorageId,
                    ComponentId = model.PlumbingId,
                    Count = model.Count
                });
            }
        }
    }
}
