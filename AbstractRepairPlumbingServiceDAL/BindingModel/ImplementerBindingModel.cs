﻿using System.Runtime.Serialization;

namespace AbstractRepairPlumbingServiceDAL.BindingModel
{
    [DataContract]
    public class ImplementerBindingModel
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string ImplementerFIO { get; set; }
    }
}
