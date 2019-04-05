using AbdtractRepairOrderServiceDAL.BindingModel;
using AbdtractRepairOrderServiceDAL.Interfaces;
using AbdtractRepairOrderServiceDAL.ViewModel;
using AbstractRepairOrderModel;
using AbstractRepairOrderServiceDAL.BindingModel;
using System;
using System.Collections.Generic;
using System.Data.Entity.SqlServer;
using System.Linq;
using System.Data.Entity;

namespace AbstractRepairPlumbingServiceImplementDataBase
{
    public class MainServiceDB : IMainService
    {
        private AbstractRepairPlumbingDbContext context;
        public MainServiceDB(AbstractRepairPlumbingDbContext context)
        {
            this.context = context;
        }
        public List<OrderViewModel> GetList()
        {
            List<OrderViewModel> result = context.Orders.Select(rec => new OrderViewModel
            {
                Id = rec.Id,
                ClientId = rec.ClientId,
                RepairId = rec.RepairId,
                DateCreate = SqlFunctions.DateName("dd", rec.DateCreate) + " " +
            SqlFunctions.DateName("mm", rec.DateCreate) + " " +
            SqlFunctions.DateName("yyyy", rec.DateCreate),
                DateImplement = rec.DateImplement == null ? "" :
            SqlFunctions.DateName("dd",
           rec.DateImplement.Value) + " " +
            SqlFunctions.DateName("mm",
           rec.DateImplement.Value) + " " +
            SqlFunctions.DateName("yyyy",
           rec.DateImplement.Value),
                Status = rec.Status.ToString(),
                Count = rec.Count,
                Sum = rec.Sum,
                ClientFIO = rec.Client.ClientFIO,
                RepairName = rec.Repair.RepairName
            })
            .ToList();
            return result;
        }
        public void CreateOrder(OrderBindingModel model)
        {
            context.Orders.Add(new Order
            {
                ClientId = model.ClientId,
                RepairId = model.RepairId,
                DateCreate = DateTime.Now,
                Count = model.Count,
                Sum = model.Sum,
                Status = OrderStatus.Принят
            });
            context.SaveChanges();
        }
        public void TakeOrderInWork(OrderBindingModel model)
        {
            using (var transaction = context.Database.BeginTransaction())
            {
                try
                {
                    Order element = context.Orders.FirstOrDefault(rec => rec.Id ==
                   model.Id);
                    if (element == null)
                    {
                        throw new Exception("Элемент не найден");
                    }
                    if (element.Status != OrderStatus.Принят)
                    {
                        throw new Exception("Заказ не в статусе \"Принят\"");
                    }
                    var productPlumbings = context.RepairPlumbings.Include(rec => rec.Plumbing).Where(rec => rec.RepairId == element.RepairId);
                    // списываем
                    foreach (var productPlumbing in productPlumbings)
                    {
                        int countOnStorages = productPlumbing.Count * element.Count;
                        var storagePlumbings = context.StoragePlumbings.Where(rec =>
                        rec.ComponentId == productPlumbing.PlumbingId);
                        foreach (var storagePlumbing in storagePlumbings)
                        {
                            // компонентов на одном слкаде может не хватать
                            if (storagePlumbing.Count >= countOnStorages)
                            {
                                storagePlumbing.Count -= countOnStorages;
                                countOnStorages = 0;
                                context.SaveChanges();
                                break;
                            }
                            else
                            {
                                countOnStorages -= storagePlumbing.Count;
                                storagePlumbing.Count = 0;
                                context.SaveChanges();
                            }
                        }
                        if (countOnStorages > 0)
                        {
                            throw new Exception("Не достаточно компонента " + productPlumbing.Plumbing.PlumbingName + " требуется " + productPlumbing.Count + ", нехватает " + countOnStorages);
                        }
                    }
                    element.DateImplement = DateTime.Now;
                    element.Status = OrderStatus.Выполняется;
                    context.SaveChanges();
                    transaction.Commit();
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }
        public void FinishOrder(OrderBindingModel model)
        {
            Order element = context.Orders.FirstOrDefault(rec => rec.Id == model.Id);
            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            if (element.Status != OrderStatus.Выполняется)
            {
                throw new Exception("Заказ не в статусе \"Выполняется\"");
            }
            element.Status = OrderStatus.Готов;
            context.SaveChanges();
        }
        public void PayOrder(OrderBindingModel model)
        {
            Order element = context.Orders.FirstOrDefault(rec => rec.Id == model.Id);
            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            if (element.Status != OrderStatus.Готов)
            {
                throw new Exception("Заказ не в статусе \"Готов\"");
            }
            element.Status = OrderStatus.Оплачен;
            context.SaveChanges();
        }
        public void PutComponentOnStorage(StoragePlumbingBindingModel model)
        {
            StoragePlumbing element = context.StoragePlumbings.FirstOrDefault(rec =>
           rec.StorageId == model.StorageId && rec.ComponentId == model.ComponentId);
            if (element != null)
            {
                element.Count += model.Count;
            }
            else
            {
                context.StoragePlumbings.Add(new StoragePlumbing
                {
                    StorageId = model.StorageId,
                    ComponentId = model.ComponentId,
                    Count = model.Count
                });
            }
            context.SaveChanges();
        }
    }
}
