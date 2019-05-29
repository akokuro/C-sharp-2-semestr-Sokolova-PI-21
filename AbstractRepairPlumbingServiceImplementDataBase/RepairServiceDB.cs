using AbstractRepairPlumbingOrderServiceDAL.BindingModel;
using AbstractRepairPlumbingOrderServiceDAL.Interfaces;
using AbstractRepairOrderModel;
using AbstractRepairOrderServiceDAL.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractRepairPlumbingServiceImplementDataBase
{
    public class RepairServiceDB : IRepairService
    {
        private AbstractRepairPlumbingDbContext context;
        public RepairServiceDB(AbstractRepairPlumbingDbContext context)
        {
            this.context = context;
        }
        public List<RepairViewModel> GetList()
        {
            List<RepairViewModel> result = context.Repairs.Select(rec => new
           RepairViewModel
            {
                Id = rec.Id,
                RepairName = rec.RepairName,
                Price = rec.Price,
                RepairPlumbings = context.RepairPlumbings
            .Where(recPC => recPC.RepairId == rec.Id)
           .Select(recPC => new RepairPlumbingViewModel
           {
               Id = recPC.Id,
               RepairId = recPC.RepairId,
               PlumbingId = recPC.PlumbingId,
               PlumbingName = recPC.Plumbing.PlumbingName,
               Count = recPC.Count
           })
           .ToList()
            })
            .ToList();
            return result;
        }
        public RepairViewModel GetElement(int id)
        {
            Repair element = context.Repairs.FirstOrDefault(rec => rec.Id == id);
            if (element != null)
            {
                return new RepairViewModel
                {
                    Id = element.Id,
                    RepairName = element.RepairName,
                    Price = element.Price,
                    RepairPlumbings = context.RepairPlumbings
 .Where(recPC => recPC.RepairId == element.Id)
 .Select(recPC => new RepairPlumbingViewModel
 {
     Id = recPC.Id,
     RepairId = recPC.RepairId,
     PlumbingId = recPC.PlumbingId,
     PlumbingName = recPC.Plumbing.PlumbingName,
     Count = recPC.Count
 })
 .ToList()
                };
            }
            throw new Exception("Элемент не найден");
        }
        public void AddElement(RepairBindingModel model)
        {
            using (var transaction = context.Database.BeginTransaction())
            {
                try
                {
                    Repair element = context.Repairs.FirstOrDefault(rec =>
                   rec.RepairName == model.RepairName);
                    if (element != null)
                    {
                        throw new Exception("Уже есть изделие с таким названием");
                    }
                    element = new Repair
                    {
                        RepairName = model.RepairName,
                        Price = model.Price
                    };
                    context.Repairs.Add(element);
                    context.SaveChanges();
                    // убираем дубли по компонентам
                    var groupPlumbings = model.RepairPlumbings
                     .GroupBy(rec => rec.PlumbingId)
                    .Select(rec => new
                    {
                        PlumbingId = rec.Key,
                        Count = rec.Sum(r => r.Count)
                    });
                    // добавляем компоненты
                    foreach (var groupPlumbing in groupPlumbings)
                    {
                        context.RepairPlumbings.Add(new RepairPlumbing
                        {
                            RepairId = element.Id,
                            PlumbingId = groupPlumbing.PlumbingId,
                            Count = groupPlumbing.Count
                        });
                        context.SaveChanges();
                    }
                    transaction.Commit();
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }
        public void UpdElement(RepairBindingModel model)
        {
            using (var transaction = context.Database.BeginTransaction())
            {
                try
                {
                    Repair element = context.Repairs.FirstOrDefault(rec =>
                   rec.RepairName == model.RepairName && rec.Id != model.Id);
                    if (element != null)
                    {
                        throw new Exception("Уже есть изделие с таким названием");
                    }
                    element = context.Repairs.FirstOrDefault(rec => rec.Id == model.Id);
                    if (element == null)
                    {
                        throw new Exception("Элемент не найден");
                    }
                    element.RepairName = model.RepairName;
                    element.Price = model.Price;
                    context.SaveChanges();
                    // обновляем существуюущие компоненты
                    var compIds = model.RepairPlumbings.Select(rec =>
                   rec.PlumbingId).Distinct();
                    var updatePlumbings = context.RepairPlumbings.Where(rec =>
                   rec.RepairId == model.Id && compIds.Contains(rec.PlumbingId));
                    foreach (var updatePlumbing in updatePlumbings)
                    {
                        updatePlumbing.Count =
                       model.RepairPlumbings.FirstOrDefault(rec => rec.Id == updatePlumbing.Id).Count;
                    }
                    context.SaveChanges();
                    context.RepairPlumbings.RemoveRange(context.RepairPlumbings.Where(rec =>
                    rec.RepairId == model.Id && !compIds.Contains(rec.PlumbingId)));
                    context.SaveChanges();
                    // новые записи
                    var groupPlumbings = model.RepairPlumbings
                    .Where(rec => rec.Id == 0)
                   .GroupBy(rec => rec.PlumbingId)
                   .Select(rec => new
                   {
                       PlumbingId = rec.Key,
                       Count = rec.Sum(r => r.Count)
                   });
                    foreach (var groupPlumbing in groupPlumbings)
                    {
                        RepairPlumbing elementPC =
                       context.RepairPlumbings.FirstOrDefault(rec => rec.RepairId == model.Id &&
                       rec.PlumbingId == groupPlumbing.PlumbingId);
                        if (elementPC != null)
                        {
                            elementPC.Count += groupPlumbing.Count;
                            context.SaveChanges();
                        }
                        else
                        {
                            context.RepairPlumbings.Add(new RepairPlumbing
                            {
                                RepairId = model.Id,
                                PlumbingId = groupPlumbing.PlumbingId,
                                Count = groupPlumbing.Count
                            });
                            context.SaveChanges();
                        }
                    }
                    transaction.Commit();
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }
        public void DelElement(int id)
        {
            using (var transaction = context.Database.BeginTransaction())
            {
                try
                {
                    Repair element = context.Repairs.FirstOrDefault(rec => rec.Id ==
                   id);
                    if (element != null)
                    {
                        // удаяем записи по компонентам при удалении изделия
                        context.RepairPlumbings.RemoveRange(context.RepairPlumbings.Where(rec =>
                        rec.RepairId == id));
                        context.Repairs.Remove(element);
                        context.SaveChanges();
                    }
                    else
                    {
                        throw new Exception("Элемент не найден");
                    }
                    transaction.Commit();
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }
    }
}
