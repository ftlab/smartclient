using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartClient.Core.Attributes
{
    public class TreeListLookUpBindingAttribute:SearchLookUpBindingAttribute
    {
        public string KeyFieldName { get; set; }
        public string ParentKeyFieldName { get; set; }
    }
}
