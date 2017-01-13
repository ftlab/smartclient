using System.Windows.Forms;
using DevExpress.XtraBars.Docking2010;
using DevExpress.XtraBars.Docking2010.Views.WindowsUI;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraBars.Docking;

namespace SmartClient.Core.Forms
{
    public interface IMainForm
    {
        Form Instance { get; }

        DocumentManager DocumentManager { get; }

        TileContainer MainContainer { get; }

        WindowsUIView WindowsUiView { get; }

        RibbonControl RibbonControl { get; }

        DockManager DockManager { get; }
    }
}