using System;
using System.Collections;

namespace SmartClient.Core.Interfaces
{
    public interface IBindingDataProvider
    {
        IList GetData(Type type);
    }
}
