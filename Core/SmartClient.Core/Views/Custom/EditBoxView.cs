using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using SmartClient.Core.Container;
using DevExpress.XtraEditors;

namespace SmartClient.Core.Views.Custom
{
    public partial class EditBoxView : FlatView, ISupportDialogResult
    {
        public EditBoxView()
        {
            InitializeComponent();
        }

        public string InputText
        {
            get
            {
                return memoEdit1.Text;
            }
            set { memoEdit1.Text = value; }
        }
        public int MaxLength
        {
            get
            {
                return memoEdit1.Properties.MaxLength;
            }
            set { memoEdit1.Properties.MaxLength = value; }
        }

        public event EventHandler<SupportDialogResultEventArgs> SupportDialogResult;

        private void _okButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(InputText))
            {
                ServiceContainer.Default.MessageService.ShowWarning("Заполните поле");
                return;
            }
            SupportDialogResult?.Invoke(this, new SupportDialogResultEventArgs(DialogResult.OK));
        }

        private void _cancelButton_Click(object sender, EventArgs e)
        {
            SupportDialogResult?.Invoke(this, new SupportDialogResultEventArgs(DialogResult.Cancel));
        }
    }
}
