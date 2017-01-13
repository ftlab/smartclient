using System.ComponentModel.DataAnnotations;

namespace SmartClient.Core.Views.Custom.Model
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
