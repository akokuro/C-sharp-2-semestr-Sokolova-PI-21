﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbdtractFoodOrderServiceDAL.ViewModel
{
    public class ClientOrdersModel
    {
        public string ClientName { get; set; }
        public string DateCreate { get; set; }
        public string RepairName { get; set; }
        public int Count { get; set; }
        public decimal Sum { get; set; }
        public string Status { get; set; }
    }
}
