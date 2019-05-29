using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AbstractRepairPlumbingServiceDAL.Attributies;
using AbstractRepairOrderServiceDAL.BindingModel;
using AbstractRepairOrderServiceDAL.ViewModel;

namespace AbstractRepairPlumbingOrderServiceDAL.Interfaces
{
    [CustomInterface("Интерфейс для работы с хранилищами")]
    public interface IStorageService
    {
        [CustomMethod("Метод получения списка хранилищ")]
        List<StorageViewModel> GetList();
        [CustomMethod("Метод получения хранилища по id")]
        StorageViewModel GetElement(int id);
        [CustomMethod("Метод добавления хранилища")]
        void AddElement(StorageBindingModel model);
        [CustomMethod("Метод обнавления информации по хранилищу")]
        void UpdElement(StorageBindingModel model);
        [CustomMethod("Метод удаления хранилища")]
        void DelElement(int id);
    }
}
