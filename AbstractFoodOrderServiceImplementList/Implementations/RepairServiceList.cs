using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AbstractRepairOrderModel;
using AbdtractRepairOrderServiceDAL;
using AbdtractRepairOrderServiceDAL.Interfaces;
using AbdtractRepairOrderServiceDAL.BindingModel;
using AbstractRepairOrderServiceDAL.ViewModel;

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
            List<RepairViewModel> result = new List<RepairViewModel>();
            for (int i = 0; i < source.Repairs.Count; ++i)
            {
                // требуется дополнительно получить список компонентов для изделия и их количество
                List<RepairPlumbingViewModel> repairPlumbings = new List<RepairPlumbingViewModel>();
                for (int j = 0; j < source.RepairPlumbings.Count; ++j)
                {
                    if (source.RepairPlumbings[j].RepairId == source.Repairs[i].Id)
                    {
                        string PlumbingName = string.Empty;
                        for (int k = 0; k < source.Plumbings.Count; ++k)
                        {
                            if (source.RepairPlumbings[j].PlumbingId ==
                           source.Plumbings[k].Id)
                            {
                                PlumbingName = source.Plumbings[k].PlumbingName;
                                break;
                            }
                        }
                        repairPlumbings.Add(new RepairPlumbingViewModel
                        {
                            Id = source.RepairPlumbings[j].Id,
                            RepairId = source.RepairPlumbings[j].RepairId,
                            PlumbingId = source.RepairPlumbings[j].PlumbingId,
                            PlumbingName = PlumbingName,
                            Count = source.RepairPlumbings[j].Count
                        });
                    }
                }
                result.Add(new RepairViewModel
                {
                    Id = source.Repairs[i].Id,
                    RepairName = source.Repairs[i].RepairName,
                    Price = source.Repairs[i].Price,
                    RepairPlumbings = repairPlumbings
                });
            }
            return result;
        }
        public RepairViewModel GetElement(int id)
        {
            for (int i = 0; i < source.Repairs.Count; ++i)
            {
                // требуется дополнительно получить список компонентов для изделия и их sколичество
                List<RepairPlumbingViewModel> repairPlumbings = new List<RepairPlumbingViewModel>();
                for (int j = 0; j < source.RepairPlumbings.Count; ++j)
                {
                    if (source.RepairPlumbings[j].RepairId == source.Repairs[i].Id)
                    {
                        string PlumbingName = string.Empty;
                        for (int k = 0; k < source.Plumbings.Count; ++k)
                        {
                            if (source.RepairPlumbings[j].PlumbingId ==
                           source.Plumbings[k].Id)
                            {
                                PlumbingName = source.Plumbings[k].PlumbingName;
                                break;
                            }
                        }
                        repairPlumbings.Add(new RepairPlumbingViewModel
                        {
                            Id = source.RepairPlumbings[j].Id,
                            RepairId = source.RepairPlumbings[j].RepairId,
                            PlumbingId = source.RepairPlumbings[j].PlumbingId,
                            PlumbingName = PlumbingName,
                            Count = source.RepairPlumbings[j].Count
                        });
                    }
                }
                if (source.Repairs[i].Id == id)
                {
                    return new RepairViewModel
                    {
                        Id = source.Repairs[i].Id,
                        RepairName = source.Repairs[i].RepairName,
                        Price = source.Repairs[i].Price,
                        RepairPlumbings = repairPlumbings
                    };
                }
            }
            throw new Exception("Элемент не найден");
        }

        public void AddElement(RepairBindingModel model)
        {
            int maxId = 0;
            for (int i = 0; i < source.Repairs.Count; ++i)
            {
                if (source.Repairs[i].Id > maxId)
                {
                    maxId = source.Repairs[i].Id;
                }
                if (source.Repairs[i].RepairName == model.RepairName)
                {
                    throw new Exception("Уже есть изделие с таким названием");
                }
            }
            source.Repairs.Add(new Repair
            {
                Id = maxId + 1,
                RepairName = model.RepairName,
                Price = model.Price
            });
            // компоненты для изделия
            int maxPCId = 0;
            for (int i = 0; i < source.RepairPlumbings.Count; ++i)
            {
                if (source.RepairPlumbings[i].Id > maxPCId)
                {
                    maxPCId = source.RepairPlumbings[i].Id;
                }
            }
            // убираем дубли по компонентам
            for (int i = 0; i < model.RepairPlumbings.Count; ++i)
            {
                for (int j = 1; j < model.RepairPlumbings.Count; ++j)
                {
                    if (model.RepairPlumbings[i].PlumbingId ==
                    model.RepairPlumbings[j].PlumbingId)
                    {
                        model.RepairPlumbings[i].Count +=
                        model.RepairPlumbings[j].Count;
                        model.RepairPlumbings.RemoveAt(j--);
                    }
                }
            }
            // добавляем компоненты
            for (int i = 0; i < model.RepairPlumbings.Count; ++i)
            {
                source.RepairPlumbings.Add(new RepairPlumbing
                {
                    Id = ++maxPCId,
                    RepairId = maxId + 1,
                    PlumbingId = model.RepairPlumbings[i].PlumbingId,
                    Count = model.RepairPlumbings[i].Count
                });
            }
        }

        public void UpdElement(RepairBindingModel model)
        {
            int index = -1;
            for (int i = 0; i < source.Repairs.Count; ++i)
            {
                if (source.Repairs[i].Id == model.Id)
                {
                    index = i;
                }
                if (source.Repairs[i].RepairName == model.RepairName &&
                source.Repairs[i].Id != model.Id)
                {
                    throw new Exception("Уже есть еда с таким названием");
                }
            }
            if (index == -1)
            {
                throw new Exception("Элемент не найден");
            }
            source.Repairs[index].RepairName = model.RepairName;
        }

        public void DelElement(int id)
        {
            for (int i = 0; i < source.Repairs.Count; ++i)
            {
                if (source.Repairs[i].Id == id)
                {
                    source.Repairs.RemoveAt(i);
                    return;
                }
            }
            throw new Exception("Элемент не найден");
        }
    }
}
