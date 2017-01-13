using SmartClient.Core.AppModel.Info;
using System.Windows.Forms;

namespace SmartClient.Core.Views
{
    public interface IView
    {
        Control Control { get; }

        void SetViewInfo(ViewInfo viewInfo);
    }
}