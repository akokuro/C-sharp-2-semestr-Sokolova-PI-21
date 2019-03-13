using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractRepairOrderServiceDAL.BindingModel
{
    /// <summary>
    /// Клиент ремонта
    /// </summary>
    public class ClientBindingModel
    {
        public int Id { get; set; }
        public string ClientFIO { get; set; }
    }
}
