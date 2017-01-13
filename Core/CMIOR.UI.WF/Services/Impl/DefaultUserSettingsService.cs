using Microsoft.Win32;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMIOR.UI.WF.Services.Impl
{
    public sealed class DefaultUserSettingsService : IUserSettingsService
    {
        private const string KeyPath = @"Software\ФИНТЕХ\ЦМИОР";

        public bool Contains(string name)
        {
            using (RegistryKey key = Registry.CurrentUser.OpenSubKey(KeyPath))
                return key == null ? false : key.GetValue(name) != null;
        }

        public object Get(string name)
        {
            return Get<string>(name);
        }

        public T Get<T>(string name)
        {
            object value;
            using (RegistryKey key = Registry.CurrentUser.CreateSubKey(KeyPath))
            {
                value = key.GetValue(name);
                if (value == null)
                    return default(T);
            }

            if (typeof(T) == value.GetType())
                return (T)value;

            var json = value as string;
            if (json == null)
                throw new InvalidCastException(value.GetType().ToString() + " -> " + typeof(T).ToString());

            return JsonConvert.DeserializeObject<T>(json);
        }

        public IEnumerable<string> GetKeys()
        {
            using (RegistryKey key = Registry.CurrentUser.CreateSubKey(KeyPath))
                return key.GetValueNames();
        }

        public void Set(string name, object value)
        {
            if (value == null)
                using (RegistryKey key = Registry.CurrentUser.CreateSubKey(KeyPath))
                    key.DeleteValue(name);
            else
                Set<object>(name, value);
        }

        public void Set<T>(string name, T value)
        {
            string json;
            if (value is string)
                json = value as string;
            else
                json = JsonConvert.SerializeObject(value, Formatting.None,
                    new JsonSerializerSettings() { ReferenceLoopHandling = ReferenceLoopHandling.Ignore });

            using (RegistryKey key = Registry.CurrentUser.CreateSubKey(KeyPath))
                key.SetValue(name, json, RegistryValueKind.String);
        }
    }
}
