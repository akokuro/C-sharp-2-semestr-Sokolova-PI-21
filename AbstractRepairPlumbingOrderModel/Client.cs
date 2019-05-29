using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractRepairOrderModel
{
    /// <summary>
    /// Клиент ремонта
    /// </summary>
    public class Client
    {
        public int Id { get; set; }
        [Required]
        public string ClientFIO { get; set; }

        public string Mail { get; set; }

        [ForeignKey("ClientId")]
        public virtual List<Order> Orders { get; set; }

        [ForeignKey("ClientId")]
        public virtual List<MessageInfo> MessageInfos { get; set; }
    }
}
