﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractRepairOrderModel
{
    /// <summary>
    /// Заказ клиента
    /// </summary>
    public class Order
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public int RepairId { get; set; }
        public int Count { get; set; }
        public decimal Sum { get; set; }
        public OrderStatus Status { get; set; }
        public DateTime DateCreate { get; set; }
        public DateTime? DateImplement { get; set; }
        public virtual Client Client { get; set; }
        public virtual Repair Repair { get; set; }
    }
}
