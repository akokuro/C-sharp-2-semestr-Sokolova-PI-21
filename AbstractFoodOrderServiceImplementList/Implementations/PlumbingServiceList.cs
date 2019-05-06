using AbdtractRepairOrderServiceDAL.Interfaces;
using AbstractRepairOrderModel;
using AbstractRepairOrderServiceDAL.BindingModel;
using AbstractRepairOrderServiceDAL.ViewModel;
using AbstractRepairOrderServiceImplementList.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractRepairOrderServiceImplementList.Implementations
{
    public class PlumbingServiceList : IPlumbingService
    {
        private DataListSingleton source;
        public PlumbingServiceList()
        {
            source = DataListSingleton.GetInstance();
        }
        public List<PlumbingViewModel> GetList()
        {
            Console.WriteLine("get list");
            List<PlumbingViewModel> result = new List<PlumbingViewModel>();
            for (int i = 0; i < source.Plumbings.Count; ++i)
            {
                // требуется дополнительно получить список компонентов для изделия и их количество
                List<RepairPlumbingViewModel> repairPlumbings = new List<RepairPlumbingViewModel>();
                for (int j = 0; j < source.RepairPlumbings.Count; ++j)
                {
                    if (source.RepairPlumbings[j].PlumbingId == source.Plumbings[i].Id)
                    {
                        string PlumbingName = string.Empty;
                        for (int k = 0; k < source.Plumbings.Count; ++k)
                        {
                            if (source.RepairPlumbings[j].PlumbingId == source.Plumbings[k].Id)
                            {
                                PlumbingName = source.Plumbings[k].PlumbingName;
                                break;
                            }
                        }
                        repairPlumbings.Add(new RepairPlumbingViewModel
                        {
                            Id = source.RepairPlumbings[j].Id,
                            PlumbingId = source.RepairPlumbings[j].PlumbingId,
                            RepairId = source.RepairPlumbings[j].RepairId,
                            PlumbingName = PlumbingName,
                            Count = source.RepairPlumbings[j].Count
                        });
                    }
                }
                result.Add(new PlumbingViewModel
                {
                    Id = source.Plumbings[i].Id,
                    PlumbingName = source.Plumbings[i].PlumbingName
                });
            }
            return result;
        }
        public PlumbingViewModel GetElement(int id)
        {
            for (int i = 0; i < source.Plumbings.Count; ++i)
            {
                // требуется дополнительно получить список компонентов для изделия и их количество
                List<RepairPlumbingViewModel> repairPlumbings = new List<RepairPlumbingViewModel>();
                for (int j = 0; j < source.RepairPlumbings.Count; ++j)
                {
                    if (source.RepairPlumbings[j].PlumbingId == source.Plumbings[i].Id)
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
                            PlumbingId = source.RepairPlumbings[j].PlumbingId,
                            RepairId = source.RepairPlumbings[j].RepairId,
                            PlumbingName = PlumbingName,
                            Count = source.RepairPlumbings[j].Count
                        });
                    }
                }
                if (source.Plumbings[i].Id == id)
                {
                    return new PlumbingViewModel
                    {
                        Id = source.Plumbings[i].Id,
                        PlumbingName = source.Plumbings[i].PlumbingName
                    };
                }
            }
            throw new Exception("Элемент не найден");
        }

        public void AddElement(PlumbingBindingModel model)
        {
            int maxId = 0;
            for (int i = 0; i < source.Plumbings.Count; ++i)
            {
                if (source.Plumbings[i].Id > maxId)
                {
                    maxId = source.Plumbings[i].Id;
                }
                if (source.Plumbings[i].PlumbingName == model.PlumbingName)
                {
                    throw new Exception("Уже есть клиент с таким ФИО");
                }
            }
            source.Plumbings.Add(new Plumbing
            {
                Id = maxId + 1,
                PlumbingName = model.PlumbingName
            });
        }

        public void UpdElement(PlumbingBindingModel model)
        {
            int index = -1;
            for (int i = 0; i < source.Plumbings.Count; ++i)
            {
                if (source.Plumbings[i].Id == model.Id)
                {
                    index = i;
                }
                if (source.Plumbings[i].PlumbingName == model.PlumbingName &&
                source.Plumbings[i].Id != model.Id)
                {
                    throw new Exception("Уже есть клиент с таким ФИО");
                }
            }
            if (index == -1)
            {
                throw new Exception("Элемент не найден");
            }
            source.Plumbings[index].PlumbingName = model.PlumbingName;
        }

        public void DelElement(int id)
        {
            for (int i = 0; i < source.Plumbings.Count; ++i)
            {
                if (source.Plumbings[i].Id == id)
                {
                    source.Plumbings.RemoveAt(i);
                    return;
                }
            }
            throw new Exception("Элемент не найден");
        }
    }
}
