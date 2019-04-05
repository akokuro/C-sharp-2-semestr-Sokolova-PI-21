using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractRepairOrderModel
{
    /// <summary>
    /// Сколько компонентов хранится на складе
    /// </summary>
    public class StoragePlumbing
    {
        public int Id { get; set; }
        public int StorageId { get; set; }
        public int ComponentId { get; set; }
        public int Count { get; set; }
        public virtual Plumbing Plumbing { get; set; }
        public virtual Storage Storage { get; set; }
    }
}
