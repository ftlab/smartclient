using System;
using System.Windows.Forms;
using CMIOR.UI.WF.Container;

namespace CMIOR.UI.WF.Views
{
    public partial class BaseEditView : FlatView, ISupportDialogResult
    {
        public BaseEditView()
        {
            InitializeComponent();
        }

        public event EventHandler<SupportDialogResultEventArgs> SupportDialogResult;

        protected virtual void _okButton_Click(object sender, EventArgs e)
        {
            string message;
            if (ValidateData(out message) == false)
            {
                ServiceContainer.Default.MessageService.ShowWarning(message);

                var form = FindForm();
                if (form != null)
                    form.DialogResult = DialogResult.None;
                return;
            }

            SupportDialogResult?.Invoke(this, new SupportDialogResultEventArgs(DialogResult.OK));
        }

        protected virtual void _cancelButton_Click(object sender, EventArgs e)
        {
            SupportDialogResult?.Invoke(this, new SupportDialogResultEventArgs(DialogResult.Cancel));
        }

        public virtual bool ValidateData(out string message)
        {
            message = null;
            return true;
        }
    }
}
