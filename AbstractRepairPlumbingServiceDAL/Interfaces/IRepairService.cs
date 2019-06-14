using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AbstractRepairOrderServiceDAL.BindingModel;
using AbstractRepairOrderServiceDAL.ViewModel;

namespace AbstractRepairOrderServiceDAL.Interfaces
{
    public interface IRepairService
    {
        List<RepairViewModel> GetList();
        RepairViewModel GetElement(int id);
        void AddElement(RepairBindingModel model);
        void UpdElement(RepairBindingModel model);
        void DelElement(int id);
    }
}
