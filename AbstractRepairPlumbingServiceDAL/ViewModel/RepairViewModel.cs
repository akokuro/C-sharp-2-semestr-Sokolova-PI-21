using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractRepairOrderServiceDAL.ViewModel
{
    /// <summary>
    /// Ремонт, доступный для заказа
    /// </summary>
    public class RepairViewModel
    {
        public int Id { get; set; }
        public string RepairName { get; set; }
        public decimal Price { get; set; }
        public List<RepairPlumbingViewModel> RepairPlumbings { get; set; }
    }
}
