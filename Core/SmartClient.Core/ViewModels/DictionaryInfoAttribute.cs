using System;

namespace SmartClient.Core.ViewModels
{
    public class DictionaryInfoAttribute : Attribute
    {
        public DictionaryInfoAttribute()
        {

        }

        public string Caption { get; set; }

        public string Category { get; set; } = "Справочники";
    }
}
