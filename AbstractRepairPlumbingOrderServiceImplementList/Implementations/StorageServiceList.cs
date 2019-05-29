﻿using AbstractRepairPlumbingOrderServiceDAL.Interfaces;
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
    public class StorageServiceList : IStorageService
    {
        private DataListSingleton source;

        public StorageServiceList()
        {
            source = DataListSingleton.GetInstance();
        }
        public void AddElement(StorageBindingModel model)
        {
            Storage element = source.Storages.FirstOrDefault(rec => rec.StorageName == model.StorageName);
            if (element != null)
            {
                throw new Exception("Уже есть склад с таким названием");
            }
            int maxId = source.Storages.Count > 0 ? source.Storages.Max(rec => rec.Id) : 0;
            source.Storages.Add(new Storage
            {
                Id = maxId + 1,
                StorageName = model.StorageName
            });
        }

        public void DelElement(int id)
        {
            Storage element = source.Storages.FirstOrDefault(rec => rec.Id == id);
            if (element != null)
            {
                // при удалении удаляем все записи о компонентах на удаляемом складе
                source.StoragePlumbings.RemoveAll(rec => rec.StorageId == id);
                source.Storages.Remove(element);
            }
            else
            {
                throw new Exception("Элемент не найден");
            }
        }

        public StorageViewModel GetElement(int id)
        {
            Storage element = source.Storages.FirstOrDefault(rec => rec.Id == id);
            if (element != null)
            {
                return new StorageViewModel
                {
                    Id = element.Id,
                    StorageName = element.StorageName,
                    StoragePlumbings = source.StoragePlumbings
                .Where(recPC => recPC.StorageId == element.Id)
               .Select(recPC => new StorageComponentViewModel
               {
                   Id = recPC.Id,
                   StorageId = recPC.StorageId,
                   ComponentId = recPC.ComponentId,
                   ComponentName = source.Plumbings
                .FirstOrDefault(recC => recC.Id ==
               recPC.ComponentId)?.PlumbingName,
                   Count = recPC.Count
               })
               .ToList()
                };
            }
            throw new Exception("Элемент не найден");
        }

        public List<StorageViewModel> GetList()
        {
            List<StorageViewModel> result = source.Storages.Select(rec => new StorageViewModel
            {
                Id = rec.Id,
                StorageName = rec.StorageName,
                StoragePlumbings = source.StoragePlumbings.Where(recPC => recPC.StorageId == rec.Id).Select(recPC => new StorageComponentViewModel
                {
                    Id = recPC.Id,
                    StorageId = recPC.StorageId,
                    ComponentId = recPC.ComponentId,
                    ComponentName = source.Plumbings.FirstOrDefault(recC => recC.Id == recPC.ComponentId)?.PlumbingName,
                    Count = recPC.Count
                }).ToList()
            }).ToList();
            return result;
        }

        public void UpdElement(StorageBindingModel model)
        {
            Storage element = source.Storages.FirstOrDefault(rec =>
 rec.StorageName == model.StorageName && rec.Id !=
model.Id);
            if (element != null)
            {
                throw new Exception("Уже есть склад с таким названием");
            }
            element = source.Storages.FirstOrDefault(rec => rec.Id == model.Id);
            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            element.StorageName = model.StorageName;
        }
    }
}
