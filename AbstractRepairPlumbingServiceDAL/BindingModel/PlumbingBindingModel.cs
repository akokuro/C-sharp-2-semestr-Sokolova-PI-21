﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractRepairOrderServiceDAL.BindingModel
{
    /// <summary>
    /// Сантехника, требуемая для ремонта
    public class PlumbingBindingModel
    {
        public int Id { get; set; }
        public string PlumbingName { get; set; }

    }
}
