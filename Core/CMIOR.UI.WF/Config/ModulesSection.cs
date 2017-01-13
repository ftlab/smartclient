using System.Configuration;

namespace CMIOR.UI.WF.Config
{
    public class ModulesSection : ConfigurationSection
    {
        [ConfigurationProperty("", IsDefaultCollection = true)]
        public ModuleElementCollection Modules
        {
            get { return (ModuleElementCollection) base[""]; }
        }
    }
}