﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AbdtractFoodOrderServiceDAL.ViewModel
{
    [DataContract]
    public class ClientOrdersModel
    {
        [DataMember]
        public string ClientName { get; set; }
        [DataMember]
        public string DateCreate { get; set; }
        [DataMember]
        public string RepairName { get; set; }
        [DataMember]
        public int Count { get; set; }
        [DataMember]
        public decimal Sum { get; set; }
        [DataMember]
        public string Status { get; set; }
    }
}
