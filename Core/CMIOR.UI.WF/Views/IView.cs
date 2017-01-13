using System.Windows.Forms;
using CMIOR.UI.WF.AppModel.Info;

namespace CMIOR.UI.WF.Views
{
    public interface IView
    {
        Control Control { get; }

        void SetViewInfo(ViewInfo viewInfo);
    }
}