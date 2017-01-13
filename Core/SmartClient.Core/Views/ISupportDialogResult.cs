using System;
using System.Windows.Forms;

namespace SmartClient.Core.Views
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
