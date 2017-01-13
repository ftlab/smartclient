using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartClient.Core.Services
{
    public interface IUserSettingsService
    {
        bool Contains(string name);

        object Get(string name);

        void Set(string name, object value);

        T Get<T>(string name);

        void Set<T>(string name, T value);

        IEnumerable<string> GetKeys();
    }
}
