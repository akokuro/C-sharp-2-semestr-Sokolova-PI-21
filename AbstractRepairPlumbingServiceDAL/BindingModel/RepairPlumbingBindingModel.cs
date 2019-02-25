using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractRepairOrderServiceDAL.BindingModel
{
    /// <summary>
    /// Сколько ингредиентов, требуется при изготовлении еды
    /// </summary>
    public class RepairPlumbingBindingModel
    {
        public int Id { get; set; }
        public int RepairId { get; set; }
        public int PlumbingId { get; set; }
        public int Count { get; set; }
    }
}
