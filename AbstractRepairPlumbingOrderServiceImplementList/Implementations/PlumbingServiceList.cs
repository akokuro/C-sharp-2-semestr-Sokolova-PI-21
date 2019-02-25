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
            List<PlumbingViewModel> result = source.Plumbings.Select(rec => new PlumbingViewModel
            {
                Id = rec.Id,
                PlumbingName = rec.PlumbingName
            }).ToList();
            return result;
        }
        public PlumbingViewModel GetElement(int id)
        {
            Plumbing element = source.Plumbings.FirstOrDefault(rec => rec.Id == id);
            if (element != null)
            {
                return new PlumbingViewModel
                {
                    Id = element.Id,
                    PlumbingName = element.PlumbingName
                };
            }
            throw new Exception("Элемент не найден");
        }

        public void AddElement(PlumbingBindingModel model)
        {
            Plumbing element = source.Plumbings.FirstOrDefault(rec => rec.PlumbingName == model.PlumbingName);
            if (element != null)
            {
                throw new Exception("Уже есть клиент с таким ФИО");
            }
            int maxId = source.Plumbings.Count > 0 ? source.Plumbings.Max(rec => rec.Id) : 0;
            source.Plumbings.Add(new Plumbing
            {
                Id = maxId + 1,
                PlumbingName = model.PlumbingName
            });
        }

        public void UpdElement(PlumbingBindingModel model)
        {
            Plumbing element = source.Plumbings.FirstOrDefault(rec => rec.PlumbingName == model.PlumbingName && rec.Id != model.Id);
            if (element != null)
            {
                throw new Exception("Уже есть сантехника с таким названием");
            }
            element = source.Plumbings.FirstOrDefault(rec => rec.Id == model.Id);
            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            element.PlumbingName = model.PlumbingName;
        }

        public void DelElement(int id)
        {
            Plumbing element = source.Plumbings.FirstOrDefault(rec => rec.Id == id);
            if (element != null)
            {
                source.Plumbings.Remove(element);
            }
            else
            {
                throw new Exception("Элемент не найден");
            }
        }
    }
}
