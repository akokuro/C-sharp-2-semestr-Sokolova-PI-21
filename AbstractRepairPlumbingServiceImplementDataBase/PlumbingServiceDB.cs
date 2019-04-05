using AbdtractRepairOrderServiceDAL.Interfaces;
using AbstractRepairOrderModel;
using AbstractRepairOrderServiceDAL.BindingModel;
using AbstractRepairOrderServiceDAL.ViewModel;
using AbstractRepairPlumbingServiceImplementDataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractRepairPlumbingServiceImplementDataBase
{
    public class PlumbingServiceDB : IPlumbingService
    {
        private AbstractRepairPlumbingDbContext context; public PlumbingServiceDB(AbstractRepairPlumbingDbContext context)
        {
            this.context = context;
        }
        public List<PlumbingViewModel> GetList()
        {
            List<PlumbingViewModel> result = context.Plumbings.Select(rec => new PlumbingViewModel
            {
                Id = rec.Id,
                PlumbingName = rec.PlumbingName
            }).ToList();
            return result;
        }

        public PlumbingViewModel GetElement(int id)
        {
            Plumbing element = context.Plumbings.FirstOrDefault(rec => rec.Id == id);
            if (element != null)
            {
                return new PlumbingViewModel
                {
                    Id = element.Id,
                    PlumbingName = element.PlumbingName
                };
            }
            throw new Exception("Оборудование не найдено");
        }

        public void AddElement(PlumbingBindingModel model)
        {
            Plumbing element = context.Plumbings.FirstOrDefault(rec => rec.PlumbingName == model.PlumbingName);
            if (element != null)
            {
                throw new Exception("Уже есть оборудование с таким названием");
            }
            context.Plumbings.Add(new Plumbing
            {
                PlumbingName = model.PlumbingName
            });
            context.SaveChanges();
        }

        public void UpdElement(PlumbingBindingModel model)
        {
            Plumbing element = context.Plumbings.FirstOrDefault(rec => rec.PlumbingName == model.PlumbingName && rec.Id != model.Id);
            if (element != null)
            {
                throw new Exception("Уже есть оборудование с таким названием");
            }
            element = context.Plumbings.FirstOrDefault(rec => rec.Id == model.Id);
            if (element == null)
            {
                throw new Exception("Оборудование не найдено");
            }
            element.PlumbingName = model.PlumbingName;
            context.SaveChanges();
        }

        public void DelElement(int id)
        {
            Plumbing element = context.Plumbings.FirstOrDefault(rec => rec.Id == id);
            if (element != null)
            {
                context.Plumbings.Remove(element);
                context.SaveChanges();
            }
            else
            {
                throw new Exception("Оборудование не найдено");
            }
        }
    }
}