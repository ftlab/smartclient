using DevExpress.XtraEditors;

namespace SmartClient.Core.Views
{
    public partial class WorkSpaceView : XtraUserControl
    {
        public WorkSpaceView()
        {
            InitializeComponent();
            windowsUIView1.NavigationBarsShowing += (s, a) => { a.Cancel = true; };
        }

        internal void ActivateContainer()
        {
            windowsUIView1.ActivateContainer(mainTileContainer);
        }
    }
}
