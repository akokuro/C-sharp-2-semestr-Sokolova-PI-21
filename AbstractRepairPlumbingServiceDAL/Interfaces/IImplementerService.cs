using AbdtractFoodOrderServiceDAL.BindingModel;
using AbdtractFoodOrderServiceDAL.ViewModel;
using System.Collections.Generic;

namespace AbdtractRepairOrderServiceDAL.Interfaces
{
    public interface IImplementerService
    {
        List<ImplementerViewModel> GetList();
        ImplementerViewModel GetElement(int id);
        void AddElement(ImplementerBindingModel model);
        void UpdElement(ImplementerBindingModel model);
        void DelElement(int id);
        ImplementerViewModel GetFreeWorker();
    }
}
