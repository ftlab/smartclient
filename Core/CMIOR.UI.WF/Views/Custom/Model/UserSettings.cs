using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMIOR.UI.WF.Views.Custom.Model
{
    internal class UserSettings
    {
        [Display(Name = "Наименование")]
        [Editable(false)]
        public string Key { get; set; }

        [Display(Name = "Значение")]
        [Editable(false)]
        public string Value { get; set; }
    }
}
