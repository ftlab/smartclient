using System;

namespace SmartClient.Core.Attributes
{
    public class CustomFilterAttribute : Attribute
    {
        public string FilterString { get; set; }
        public string Parameters { get; set; }
    }
}
