using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AbstractRepairOrderServiceDAL.ViewModel
{
    /// <summary>
    /// Сколько сантехники требуется для проведения ремонта
    /// </summary>
    [DataContract]
    public class RepairPlumbingViewModel
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public int RepairId { get; set; }
        [DataMember]
        public int PlumbingId { get; set; }
        [DataMember]
        public String PlumbingName { get; set; }
        [DataMember]
        public int Count { get; set; }
    }
}
