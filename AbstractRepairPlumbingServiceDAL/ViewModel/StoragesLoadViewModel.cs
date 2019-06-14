﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbdtractRepairPlumbingServiceDAL.ViewModel
{
    public class StoragesLoadViewModel
    {
        public string StorageName { get; set; }
        public int TotalCount { get; set; }
        public IEnumerable<Tuple<string, int>> Plumbings { get; set; }
    }
}
