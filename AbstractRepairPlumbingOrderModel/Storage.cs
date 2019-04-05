using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractRepairOrderModel
{
    /// <summary>
    /// Хранилиище компонентов в маcтерской
    /// </summary>
    public class Storage
    {
        public int Id { get; set; }
        public string StorageName { get; set; }
        [ForeignKey("StorageId")]
        public virtual List<StoragePlumbing> StoragePlumbings { get; set; }
    }
}
