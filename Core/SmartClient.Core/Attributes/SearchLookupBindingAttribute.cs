using System;

namespace SmartClient.Core.Attributes
{
    public class SearchLookUpBindingAttribute : Attribute
    {
        public string ValueMember { get; set; }
        public string DisplayMember { get; set; }
        public Type DataSourceType { get; set; }
    }
}
