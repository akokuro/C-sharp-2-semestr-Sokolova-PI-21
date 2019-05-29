using System.Collections.Generic;
using AbstractRepairPlumbingServiceDAL.Attributies;
using AbstractRepairPlumbingServiceDAL.BindingModel;
using AbstractRepairPlumbingServiceDAL.ViewModel;

namespace AbstractRepairPlumbingServiceDAL.Interfaces
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
