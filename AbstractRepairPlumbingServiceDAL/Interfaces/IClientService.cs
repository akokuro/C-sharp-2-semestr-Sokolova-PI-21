using AbstractRepairPlumbingServiceDAL.Attributies;
using AbstractRepairOrderServiceDAL.BindingModel;
using AbstractRepairOrderServiceDAL.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractRepairPlumbingOrderServiceDAL.Interfaces
{
    [CustomInterface("Интерфейс для работы с клиентами")]
    public interface IClientService
    {
        [CustomMethod("Метод получения списка клиентов")]
        List<ClientViewModel> GetList();
        [CustomMethod("Метод получения клиента по id")]
        ClientViewModel GetElement(int id);
        [CustomMethod("Метод добавления клиента")]
        void AddElement(ClientBindingModel model);
        [CustomMethod("Метод изменения данных по клиенту")]
        void UpdElement(ClientBindingModel model);
        [CustomMethod("Метод удаления клиента")]
        void DelElement(int id);
    }
}
