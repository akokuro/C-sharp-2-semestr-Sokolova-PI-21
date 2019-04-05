using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractRepairOrderModel
{
    /// <summary>
    /// Сантехника, требуемая для проведения ремонта
    public class Plumbing
    {
        public int Id { get; set; }
        public string PlumbingName { get; set; }
        [ForeignKey("PlumbingId")]
        public virtual List<RepairPlumbing> RepairPlumbings { get; set; }
        [ForeignKey("ComponentId")]
        public virtual List<StoragePlumbing> StoragePlumbings { get; set; }
    }
}
