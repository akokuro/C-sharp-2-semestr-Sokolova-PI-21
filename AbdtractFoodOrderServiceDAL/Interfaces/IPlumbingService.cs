using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AbstractRepairOrderServiceDAL.BindingModel;
using AbstractRepairOrderServiceDAL.ViewModel;

namespace AbdtractRepairOrderServiceDAL.Interfaces
{
    public interface IPlumbingService
    {
        List<PlumbingViewModel> GetList();
        PlumbingViewModel GetElement(int id);
        void AddElement(PlumbingBindingModel model);
        void UpdElement(PlumbingBindingModel model);
        void DelElement(int id);
    }
}
