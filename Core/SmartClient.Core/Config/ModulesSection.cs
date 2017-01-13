using System.Configuration;

namespace SmartClient.Core.Config
{
    public class ModulesSection : ConfigurationSection
    {
        [ConfigurationProperty("", IsDefaultCollection = true)]
        public ModuleElementCollection Modules
        {
            get { return (ModuleElementCollection)base[""]; }
        }
    }
}