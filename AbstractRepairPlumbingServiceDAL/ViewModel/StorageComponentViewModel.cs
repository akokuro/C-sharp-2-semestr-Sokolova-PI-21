using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractRepairOrderServiceDAL.ViewModel
{
        public class StorageComponentViewModel
    {
        public int Id { get; set; }
        public int StorageId { get; set; }
        public int ComponentId { get; set; }
        [DisplayName("Название компонента")]
        public string ComponentName { get; set; }
        [DisplayName("Количество")]
        public int Count { get; set; }
    }
}
