﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractRepairOrderModel
{
    /// <summary>
    /// Сколько сантехники требуется для проведения ремонта
    /// </summary>
    public class RepairPlumbing
    {
        public int Id { get; set; }
        public int RepairId { get; set; }
        public int PlumbingId { get; set; }
        public int Count { get; set; }
        public virtual Repair Repair { get; set; }
        public virtual Plumbing Plumbing { get; set; }
    }
}
