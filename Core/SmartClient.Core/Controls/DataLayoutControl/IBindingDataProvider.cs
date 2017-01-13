using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartClient.Core.Interfaces
{
    public interface IBindingDataProvider
    {
        IList GetData(Type type);
    }
}
