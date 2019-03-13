using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractRepairOrderModel
{
    /// <summary>
    /// Сколько компонентов хранится на складе
    /// </summary>
    public class StorageComponent
    {
        public int Id { get; set; }
        public int StorageId { get; set; }
        public int ComponentId { get; set; }
        public int Count { get; set; }
    }
}
