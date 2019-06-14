using AbstractRepairOrderModel;
using AbstractRepairOrderServiceDAL.BindingModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractRepairOrderServiceDAL.BindingModel
{
    public class RepairBindingModel
    {
        public int Id { get; set; }
        public string RepairName { get; set; }
        public decimal Price { get; set; }
        public List<RepairPlumbingBindingModel> RepairPlumbings { get; set; }
    }
}
