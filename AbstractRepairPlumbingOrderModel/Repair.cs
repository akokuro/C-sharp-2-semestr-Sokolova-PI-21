﻿using System;
using System.Collections.Generic;
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
    }
}
