using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AbstractRepairPlumbingServiceDAL.Attributies;
using AbstractRepairPlumbingOrderServiceDAL.BindingModel;
using AbstractRepairOrderServiceDAL.ViewModel;

namespace AbstractRepairPlumbingOrderServiceDAL.Interfaces
{
    [CustomInterface("Интерфейс для работы с письмами")]
    public interface IRepairService
    {
        [CustomMethod("Метод получения списка ремонтов сантехники")]
        List<RepairViewModel> GetList();
        [CustomMethod("Метод получения ремонта сантехники по id")]
        RepairViewModel GetElement(int id);
        [CustomMethod("Метод добавления ремонта сантехники")]
        void AddElement(RepairBindingModel model);
        [CustomMethod("Метод обновления информации по ремонту сантехники")]
        void UpdElement(RepairBindingModel model);
        [CustomMethod("Метод удаления ремонта сантехники")]
        void DelElement(int id);
    }
}
