using CMIOR.Dictionary.ViewModels;
using DevExpress.XtraBars.Docking2010.Views.WindowsUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CMIOR.UI.WF.ViewModels;

namespace CMIOR.Dictionary.Views
{
    public interface IDictionaryView: ISupportNavigation
    {
        IEnumerable<DictionaryCommand> GetCommands();
        void ExecuteCommand(DictionaryCommand command);

        bool CanDelete();
        void ClearData();
        void RefreshData();
        void Edit();
        void Add();
    }
}
