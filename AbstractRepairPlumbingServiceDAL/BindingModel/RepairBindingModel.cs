using AbstractRepairPlumbingServiceDAL.BindingModel;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace AbstractRepairPlumbingServiceDAL.BindingModel
{
    [DataContract]
    public class RepairBindingModel
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string RepairName { get; set; }
        [DataMember]
        public decimal Price { get; set; }
        [DataMember]
        public List<RepairPlumbingBindingModel> RepairPlumbings { get; set; }
    }
}
