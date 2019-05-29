using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AbstractRepairOrderModel;
using AbstractRepairPlumbingServiceDAL;
using AbstractRepairPlumbingServiceDAL.Interfaces;
using AbstractRepairPlumbingServiceDAL.BindingModel;
using AbstractRepairPlumbingServiceDAL.ViewModel;

namespace AbstractRepairOrderServiceImplementList.Implementations
{
    public class RepairServiceList : IRepairService
    {
        private DataListSingleton source;
        public RepairServiceList()
        {
            source = DataListSingleton.GetInstance();
        }
        public List<RepairViewModel> GetList()
        {
            List<RepairViewModel> result = source.Repairs.Select(rec => new RepairViewModel
            {
                Id = rec.Id,
                RepairName = rec.RepairName,
                Price = rec.Price,
                RepairPlumbings = source.RepairPlumbings.Where(recPC => recPC.RepairId == rec.Id).Select(recPC => new RepairPlumbingViewModel
                {
                    Id = recPC.Id,
                    RepairId = recPC.RepairId,
                    PlumbingId = recPC.PlumbingId,
                    PlumbingName = source.Plumbings.FirstOrDefault(recC =>
                    recC.Id == recPC.PlumbingId)?.PlumbingName,
                    Count = recPC.Count
                }).ToList()
            }).ToList();
            return result;
        }
        public RepairViewModel GetElement(int id)
        {
            Repair element = source.Repairs.FirstOrDefault(rec => rec.Id == id);
            if (element != null)
            {
                return new RepairViewModel
                {
                    Id = element.Id,
                    RepairName = element.RepairName,
                    Price = element.Price,
                    RepairPlumbings = source.RepairPlumbings.Where(recPC => recPC.RepairId == element.Id).Select(recPC => new RepairPlumbingViewModel
                    {
                        Id = recPC.Id,
                        RepairId = recPC.RepairId,
                        PlumbingId = recPC.PlumbingId,
                        PlumbingName = source.Plumbings.FirstOrDefault(recC => recC.Id == recPC.PlumbingId)?.PlumbingName,
                        Count = recPC.Count
                    }).ToList()
                };
            }
            throw new Exception("Элемент не найден");
        }

        public void AddElement(RepairBindingModel model)
        {
            Repair element = source.Repairs.FirstOrDefault(rec => rec.RepairName == model.RepairName);
            if (element != null)
            {
                throw new Exception("Уже есть изделие с таким названием");
            }
            int maxId = source.Repairs.Count > 0 ? source.Repairs.Max(rec => rec.Id) :
           0;
            source.Repairs.Add(new Repair
            {
                Id = maxId + 1,
                RepairName = model.RepairName,
                Price = model.Price
            });
            // компоненты для изделия
            int maxPCId = source.RepairPlumbings.Count > 0 ?
           source.RepairPlumbings.Max(rec => rec.Id) : 0;
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
                source.RepairPlumbings.Add(new RepairPlumbing
                {
                    Id = ++maxPCId,
                    RepairId = maxId + 1,
                    PlumbingId = groupPlumbing.PlumbingId,
                    Count = groupPlumbing.Count
                });
            }
        }
        public void UpdElement(RepairBindingModel model)
        {
            Repair element = source.Repairs.FirstOrDefault(rec => rec.RepairName == model.RepairName && rec.Id != model.Id);
            if (element != null)
            {
                throw new Exception("Уже есть изделие с таким названием");
            }
            element = source.Repairs.FirstOrDefault(rec => rec.Id == model.Id);
            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            element.RepairName = model.RepairName;
            element.Price = model.Price;
            int maxPCId = source.RepairPlumbings.Count > 0 ?
           source.RepairPlumbings.Max(rec => rec.Id) : 0;
            // обновляем существуюущие компоненты
            var compIds = model.RepairPlumbings.Select(rec =>
           rec.PlumbingId).Distinct();
            var updatePlumbings = source.RepairPlumbings.Where(rec => rec.RepairId ==
            model.Id && compIds.Contains(rec.PlumbingId));
            foreach (var updatePlumbing in updatePlumbings)
            {
                updatePlumbing.Count = model.RepairPlumbings.FirstOrDefault(rec => rec.Id == updatePlumbing.Id).Count;
            }
            source.RepairPlumbings.RemoveAll(rec => rec.RepairId == model.Id && !compIds.Contains(rec.PlumbingId));
            // новые записи
            var groupPlumbings = model.RepairPlumbings.Where(rec => rec.Id == 0).GroupBy(rec => rec.PlumbingId)
                .Select(rec => new
                {
                    PlumbingId = rec.Key,
                    Count = rec.Sum(r => r.Count)
                });
            foreach (var groupPlumbing in groupPlumbings)
            {
                RepairPlumbing elementPC = source.RepairPlumbings.FirstOrDefault(rec
                    => rec.RepairId == model.Id && rec.PlumbingId == groupPlumbing.PlumbingId);
                if (elementPC != null)
                {
                    elementPC.Count += groupPlumbing.Count;
                }
                else
                {
                    source.RepairPlumbings.Add(new RepairPlumbing
                    {
                        Id = ++maxPCId,
                        RepairId = model.Id,
                        PlumbingId = groupPlumbing.PlumbingId,
                        Count = groupPlumbing.Count
                    });
                }
            }
        }

        public void DelElement(int id)
        {
            Repair element = source.Repairs.FirstOrDefault(rec => rec.Id == id);
            if (element != null)
            {
                // удаяем записи по компонентам при удалении изделия
                source.RepairPlumbings.RemoveAll(rec => rec.RepairId == id);
                source.Repairs.Remove(element);
            }
            else
            {
                throw new Exception("Элемент не найден");
            }
        }
    }
}
