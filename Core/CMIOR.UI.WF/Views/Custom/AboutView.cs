using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace CMIOR.UI.WF.Views.Custom
{
    public partial class AboutView : XtraUserControl, ISupportDialogResult
    {
        public AboutView()
        {
            InitializeComponent();
        }

        public event EventHandler<SupportDialogResultEventArgs> SupportDialogResult;

        private void windowsUIButtonPanel1_Click(object sender, EventArgs e)
        {
            SupportDialogResult?.Invoke(this, new SupportDialogResultEventArgs(DialogResult.OK));
        }
    }
}
