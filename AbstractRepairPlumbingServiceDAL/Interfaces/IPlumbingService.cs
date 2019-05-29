using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AbstractRepairPlumbingServiceDAL.Attributies;
using AbstractRepairPlumbingServiceDAL.BindingModel;
using AbstractRepairPlumbingServiceDAL.ViewModel;

namespace AbstractRepairPlumbingServiceDAL.Interfaces
{
    [CustomInterface("Интерфейс для работы с письмами")]
    public interface IPlumbingService
    {
        [CustomMethod("Метод получения списка сантехники")]
        List<PlumbingViewModel> GetList();
        [CustomMethod("Метод получения сантехники по id")]
        PlumbingViewModel GetElement(int id);
        [CustomMethod("Метод добавления сантехники")]
        void AddElement(PlumbingBindingModel model);
        [CustomMethod("Метод изменения информации по сантехнике")]
        void UpdElement(PlumbingBindingModel model);
        [CustomMethod("Метод удаления сантехники")]
        void DelElement(int id);
    }
}
