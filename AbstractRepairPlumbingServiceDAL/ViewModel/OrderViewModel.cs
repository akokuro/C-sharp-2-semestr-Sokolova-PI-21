﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AbstractRepairPlumbingServiceDAL.ViewModel
{
    [DataContract]
    public class OrderViewModel
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public int ClientId { get; set; }
        [DataMember]
        public string ClientFIO { get; set; }
        [DataMember]
        public int RepairId { get; set; }
        [DataMember]
        public string RepairName { get; set; }
        [DataMember]
        public int? ImplementerId { get; set; }
        [DataMember]
        public string ImplementerName { get; set; }
        [DataMember]
        public int Count { get; set; }
        [DataMember]
        public decimal Sum { get; set; }
        [DataMember]
        public string Status { get; set; }
        [DataMember]
        public string DateCreate { get; set; }
        [DataMember]
        public string DateImplement { get; set; }
    }
}
