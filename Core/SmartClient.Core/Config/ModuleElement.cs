using SmartClient.Core.AppModel;
using System.Configuration;

namespace SmartClient.Core.Config
{
    public class ModuleElement : ConfigurationElement, IModuleConfig
    {
        [ConfigurationProperty("assemblyName", IsRequired = true, IsKey = true)]
        public string AssemblyName => (string)base["assemblyName"];

        [ConfigurationProperty("autoStart", DefaultValue = false)]
        public bool AutoStart => (bool)base["autoStart"];

        [ConfigurationProperty("ignoreLoadException", DefaultValue = false)]
        public bool IgnoreLoadException => (bool)base["ignoreLoadException"];
    }
}