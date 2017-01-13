using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMIOR.UI.WF.Interfaces
{
    public interface IHasBindingDataProvider
    {
        IBindingDataProvider BindingDataProvider { get; set; }
    }
}
