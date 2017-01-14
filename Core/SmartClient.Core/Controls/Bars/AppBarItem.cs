using System.ComponentModel.DataAnnotations;
using System.Drawing;

namespace SmartClient.Core.Controls.Bars
{
    public class AppBarItem
    {
        [Display(Name = "Наименование")]
        public string Name { get; set; }

        [Display(Name = "Текст")]
        public string Caption { get; set; }

        [Display(Name = "Описание")]
        public string Decription { get; set; }

        [Display(Name = "Иконка")]
        public Image Image { get; set; }

        [Display(Name = "Группа")]
        public string Group => AppBarSettings.IsLast(Name) ? "Недавно используемые" : "Остальные";

        [Display(Name = "Прикреплен")]
        public bool Pinned => AppBarSettings.IsPinned(Name);
    }
}
