using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMIOR.Dictionary.ViewModels
{
    public class DictionaryInfoAttribute: Attribute
    {
        public DictionaryInfoAttribute()
        {

        }

        public string Caption { get; set; }

        public string Category { get; set; } = "Справочники";
    }
}
