using CMIOR.UI.WF.AppModel;
using DevExpress.XtraBars.Docking2010.Customization;
using DevExpress.XtraBars.Docking2010.Views.WindowsUI;
using DevExpress.XtraEditors;
using System;
using System.Windows.Forms;

namespace CMIOR.UI.WF.Services.Impl
{
    public sealed class DefaultDialogService : IDialogService
    {
        private bool _useFlyout;

        public DefaultDialogService(bool useFlyout)
        {
            _useFlyout = useFlyout;
        }

        public bool? Ask(string text, string caption = "Вопрос", bool cancelable = false)
        {
            DialogResult result;
            Form frm = null;
            if(_useFlyout)
                frm = Form.ActiveForm ?? App.Instance?.MainForm?.Instance;

            if (frm == null)
            {
                result = XtraMessageBox.Show(text, caption, cancelable ? MessageBoxButtons.YesNoCancel : MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            }
            else
            {
                var action = new FlyoutAction()
                {
                    Caption = caption,
                    Description = text,
                    //Image = 
                };
                action.Commands.Add(new FlyoutCommand() { Text = "Да", Result = DialogResult.Yes });
                action.Commands.Add(new FlyoutCommand() { Text = "Нет", Result = DialogResult.No });
                if (cancelable)
                    action.Commands.Add(new FlyoutCommand() { Text = "Отмена", Result = DialogResult.Cancel });

                result = FlyoutDialog.Show(frm, action, new FlyoutProperties() { });
            }
            switch (result)
            {
                case DialogResult.Yes:
                    return true;
                case DialogResult.No:
                    return false;
                default:
                    return null;
            }
        }        

        public string FolderBrowser(string defaultPath)
        {
            using (var dialog = new FolderBrowserDialog())
            {
                dialog.Description = "ЦМИОР";
                dialog.ShowNewFolderButton = false;
                dialog.SelectedPath = defaultPath;
                return dialog.ShowDialog() == DialogResult.OK ? dialog.SelectedPath : null;
            }
        }
        public string OpenFile(string defaultPath, string filter = null)
        {
            using (var dialog = new OpenFileDialog())
            {
                dialog.Title = "ЦМИОР";
                dialog.CheckFileExists = true;
                dialog.Multiselect = false;
                dialog.Filter = filter;
                dialog.InitialDirectory = defaultPath;
                return dialog.ShowDialog() == DialogResult.OK ? dialog.FileName : null;
            }
        }
        public string SaveFile(string defaultPath, string filter = null)
        {
            using (var dialog = new SaveFileDialog())
            {
                dialog.Title = "ЦМИОР";
                dialog.CheckPathExists = true;
                dialog.Filter = filter;
                dialog.InitialDirectory = defaultPath;
                return dialog.ShowDialog() == DialogResult.OK ? dialog.FileName : null;
            }
        }
    }
}
