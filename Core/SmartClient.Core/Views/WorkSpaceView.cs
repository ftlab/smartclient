using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
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
