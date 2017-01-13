using DevExpress.XtraBars.Ribbon;

namespace CMIOR.UI.WF.Views
{
    public partial class RibbonView : FlatView
    {
        public RibbonView()
        {
            InitializeComponent();

            //this.ribbonControl1.Manager.UseAltKeyForMenu = false;
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
