using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartClient.Core.Attributes
{
    public class CustomFilterAttribute:Attribute
    {
        public string FilterString { get; set; }
        public string Parameters { get; set; }
    }
}
