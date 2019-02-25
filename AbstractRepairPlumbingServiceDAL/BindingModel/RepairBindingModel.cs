using AbstractRepairOrderServiceDAL.BindingModel;
using System.Collections.Generic;

namespace AbdtractRepairOrderServiceDAL.BindingModel
{
    public class RepairBindingModel
    {
        public int Id { get; set; }
        public string RepairName { get; set; }
        public decimal Price { get; set; }
        public List<RepairPlumbingBindingModel> RepairPlumbings { get; set; }
    }
}
