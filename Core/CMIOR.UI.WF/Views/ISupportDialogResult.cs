using System;
using System.Windows.Forms;

namespace CMIOR.UI.WF.Views
{
    public interface ISupportDialogResult
    {
        event EventHandler<SupportDialogResultEventArgs> SupportDialogResult;
    }

    public class SupportDialogResultEventArgs : EventArgs
    {
        public SupportDialogResultEventArgs(DialogResult result)
        {
            Result = result;
        }

        public DialogResult Result { get; }
    }
}
