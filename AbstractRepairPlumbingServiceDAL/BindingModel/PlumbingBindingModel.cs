using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AbstractRepairPlumbingServiceDAL.BindingModel
{
    /// <summary>
    /// Сантехника, требуемая для ремонта
    /// </summary>
    [DataContract]
    public class PlumbingBindingModel
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string PlumbingName { get; set; }

    }
}
