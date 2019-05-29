using AbstractRepairPlumbingServiceDAL.Interfaces;
using AbstractRepairOrderModel;
using AbstractRepairPlumbingServiceDAL.BindingModel;
using AbstractRepairPlumbingServiceDAL.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractRepairPlumbingServiceImplementDataBase
{
    public class StorageServiceDB : IStorageService
    {
        private AbstractRepairPlumbingDbContext context;
        public StorageServiceDB(AbstractRepairPlumbingDbContext context)
        {
            this.context = context;
        }
        public List<StorageViewModel> GetList()
        {
            List<StorageViewModel> result = context.Storages.Select(rec => new StorageViewModel
            {
                Id = rec.Id,
                StorageName = rec.StorageName
            }).ToList();
            return result;
        }

        public StorageViewModel GetElement(int id)
        {
            Storage element = context.Storages.FirstOrDefault(rec => rec.Id == id);
            if (element != null)
            {
                return new StorageViewModel
                {
                    Id = element.Id,
                    StorageName = element.StorageName,
                    StoragePlumbings = context.StoragePlumbings.Where(recPC => recPC.StorageId == element.Id).Select(recPC => new StorageComponentViewModel
                    {
                        Id = recPC.Id,
                        StorageId = recPC.StorageId,
                        ComponentId = recPC.ComponentId,
                        ComponentName = recPC.Plumbing.PlumbingName,
                        Count = recPC.Count
                    }).ToList()
                };
            }
            throw new Exception("Хранилище не найдено");
        }

        public void AddElement(StorageBindingModel model)
        {
            Storage element = context.Storages.FirstOrDefault(rec => rec.StorageName == model.StorageName);
            if (element != null)
            {
                throw new Exception("Уже есть хранилище с таким названием");
            }
            context.Storages.Add(new Storage
            {
                StorageName = model.StorageName
            });
            context.SaveChanges();
        }

        public void UpdElement(StorageBindingModel model)
        {
            Storage element = context.Storages.FirstOrDefault(rec => rec.StorageName == model.StorageName && rec.Id != model.Id);
            if (element != null)
            {
                throw new Exception("Уже есть хранилище с таким названием");
            }
            element = context.Storages.FirstOrDefault(rec => rec.Id == model.Id);
            if (element == null)
            {
                throw new Exception("Хранилище не найдено");
            }
            element.StorageName = model.StorageName;
            context.SaveChanges();
        }

        public void DelElement(int id)
        {
            Storage element = context.Storages.FirstOrDefault(rec => rec.Id == id);
            if (element != null)
            {
                context.Storages.Remove(element);
                context.SaveChanges();
            }
            else
            {
                throw new Exception("Хранилище не найдено");
            }
        }
    }
}