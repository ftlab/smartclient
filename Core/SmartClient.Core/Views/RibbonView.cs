using DevExpress.XtraBars.Ribbon;

namespace SmartClient.Core.Views
{
    public partial class RibbonView : FlatView
    {
        public RibbonView()
        {
            InitializeComponent();
        }

        public RibbonControl Ribbon
        {
            get
            {
                return ribbonControl1;
            }
        }
    }
}
