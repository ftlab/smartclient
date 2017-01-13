using System.Configuration;

namespace SmartClient.Core.Config
{
    [ConfigurationCollection(typeof(ModuleElement),
        CollectionType = ConfigurationElementCollectionType.AddRemoveClearMap)]
    public class ModuleElementCollection : ConfigurationElementCollection
    {
        protected override ConfigurationElement CreateNewElement()
        {
            return new ModuleElement();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((ModuleElement)element).AssemblyName;
        }
    }
}