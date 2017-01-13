using SmartClient.Core.Config;
using System.Collections.Generic;

namespace SmartClient.Core.AppModel
{
    public interface IModuleRepository
    {
        IEnumerable<IModule> GetModules();

        IList<IModuleConfig> GetConfig();
    }
}