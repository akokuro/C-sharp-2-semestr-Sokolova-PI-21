using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AbstractRepairPlumbingServiceDAL.ViewModel
{
    /// <summary>
    /// Сантехника, требуемая для проведения ремонта
    [DataContract]
    public class PlumbingViewModel
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string PlumbingName { get; set; }

    }
}
