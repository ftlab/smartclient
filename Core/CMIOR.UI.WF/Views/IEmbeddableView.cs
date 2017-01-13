using System.Collections.Generic;
using CMIOR.UI.WF.ViewModels;
using System.Threading.Tasks;

namespace CMIOR.UI.WF.Views
{
    public delegate void ChangeCommandVisibility(ViewCommand command, bool visible);

    public interface IEmbeddableView
    {
        IEnumerable<ViewCommand> GetCommands();
        Task ExecuteCommand(ViewCommand command);
        void Filter(NavNode node);
        event ChangeCommandVisibility ChangeCommandVisibility;
        void ParentHiden();
        void ParentActivated();
    }
}
