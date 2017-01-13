using DevExpress.XtraBars.Docking2010.Views.WindowsUI;
using System.Collections.Generic;
using SmartClient.Core.ViewModels;

namespace SmartClient.Core.Views
{
    public interface IDictionaryView : ISupportNavigation
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
