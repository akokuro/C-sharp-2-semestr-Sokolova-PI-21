using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractRepairOrderModel
{
    /// <summary>
    /// Ремонт, доступый для заказа
    /// </summary>
    public class Repair
    {
        public int Id { get; set; }
        public string RepairName { get; set; }
        public decimal Price { get; set; }
        [ForeignKey("RepairId")]
        public virtual List<Order> Orders { get; set; }
        [ForeignKey("RepairId")]
        public virtual List<RepairPlumbing> RepairPlumbings { get; set; }
    }
}
