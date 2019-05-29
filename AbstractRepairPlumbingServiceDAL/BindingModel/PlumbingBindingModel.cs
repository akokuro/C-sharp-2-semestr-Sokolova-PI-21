using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractRepairOrderServiceDAL.BindingModel
{
    /// <summary>
    /// Ингредиент, требуемый для изготовления изделия
    public class PlumbingBindingModel
    {
        public int Id { get; set; }
        public string PlumbingName { get; set; }

    }
}
