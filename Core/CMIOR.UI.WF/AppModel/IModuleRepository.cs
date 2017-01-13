using CMIOR.UI.WF.Config;
using System.Collections.Generic;
using CMIOR.CommonContracts.DataModel.Param;

namespace CMIOR.UI.WF.AppModel
{
    public interface IModuleRepository
    {
        IEnumerable<IModule> GetModules();

        IList<IArmModule> GetConfig();
    }
}