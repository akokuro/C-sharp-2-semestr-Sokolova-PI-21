﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractRepairOrderServiceDAL.ViewModel
{
    public class OrderViewModel
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public string ClientFIO { get; set; }
        public int RepairId { get; set; }
        public string RepairName { get; set; }
        public int Count { get; set; }
        public decimal Sum { get; set; }
        public string Status { get; set; }
        public string DateCreate { get; set; }
        public string DateImplement { get; set; }
    }
}
