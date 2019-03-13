using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractRepairOrderServiceDAL.ViewModel
{
    /// <summary>
    /// Сколько сантехники требуется для проведения ремонта
    /// </summary>
    public class RepairPlumbingViewModel
    {
        public int Id { get; set; }
        public int RepairId { get; set; }
        public int PlumbingId { get; set; }
        public String PlumbingName { get; set; }
        public int Count { get; set; }
    }
}
