using AbstractRepairPlumbingServiceDAL.Attributies;
using AbstractRepairPlumbingServiceDAL.BindingModel;
using AbstractRepairPlumbingServiceDAL.ViewModel;
using System.Collections.Generic;

namespace AbstractRepairPlumbingServiceDAL.Interfaces
{
    [CustomInterface("Интерфейс для работы с исполнителями")]
    public interface IImplementerService
    {
        [CustomMethod("Метод получения списка исполнителей")]
        List<ImplementerViewModel> GetList();
        [CustomMethod("Метод получения исполнителя по id")]
        ImplementerViewModel GetElement(int id);
        [CustomMethod("Метод добавления исполнителя")]
        void AddElement(ImplementerBindingModel model);
        [CustomMethod("Метод изменения данных по исполнителю")]
        void UpdElement(ImplementerBindingModel model);
        [CustomMethod("Метод удаления исполнителя")]
        void DelElement(int id);
        [CustomMethod("Метод получения не занятых исполнителей")]
        ImplementerViewModel GetFreeWorker();
    }
}
