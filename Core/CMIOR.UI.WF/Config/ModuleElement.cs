using System.Configuration;
using CMIOR.CommonContracts.DataModel.Dictionary;
using CMIOR.CommonContracts.DataModel.Param;

namespace CMIOR.UI.WF.Config
{
    public class ModuleElement : ConfigurationElement, IArmModule
    {
        [ConfigurationProperty("assemblyName", IsRequired = true, IsKey = true)]
        public string AssemblyName => (string) base["assemblyName"];

        [ConfigurationProperty("autoStart", DefaultValue = false)]
        public bool AutoStart => (bool)base["autoStart"];

        [ConfigurationProperty("ignoreLoadException", DefaultValue = false)]
        public bool IgnoreLoadException => (bool) base["ignoreLoadException"];
    }
}