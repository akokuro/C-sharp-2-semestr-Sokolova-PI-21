using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AbstractRepairPlumbingServiceDAL.ViewModel
{
    /// <summary>
    /// Ремонт, доступный для заказа
    /// </summary>
    [DataContract]
    public class RepairViewModel
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string RepairName { get; set; }
        [DataMember]
        public decimal Price { get; set; }
        [DataMember]
        public List<RepairPlumbingViewModel> RepairPlumbings { get; set; }
    }
}
