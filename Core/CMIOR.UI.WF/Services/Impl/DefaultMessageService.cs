using CMIOR.UI.WF.AppModel;
using CMIOR.Extensions.Exceptions;
using CMIOR.Unity;
using DevExpress.XtraBars.Docking2010.Customization;
using DevExpress.XtraBars.Docking2010.Views.WindowsUI;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CMIOR.UI.WF.Services.Impl
{
    public class DefaultMessageService : IMessageService
    {
        private bool _useFlyout;

        public DefaultMessageService(bool useFlyout)
        {
            _useFlyout = useFlyout;
        }

        private void ShowFlyout(Form frm, string text, string caption, Image image)
        {
            var action = new FlyoutAction(new[] { DialogResult.OK })
            {
                Caption = caption,
                Description = text,
                Image = image,
            };

            FlyoutDialog.Show(frm, action);
        }

        private Form GetForm()
        {
            if(_useFlyout)
                return Form.ActiveForm ?? App.Instance?.MainForm?.Instance;

            return null;
        }
        
        public void ShowError(string text, string caption)
        {
            var frm = GetForm();

            if (frm == null)
                XtraMessageBox.Show(text, caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
                ShowFlyout(frm, text, caption, Properties.Resources.error);
        }

        public void ShowInfo(string text, string caption)
        {
            var frm = GetForm();

            if (frm == null)
                XtraMessageBox.Show(text, caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                ShowFlyout(frm, text, caption, Properties.Resources.info);
        }

        public void ShowWarning(string text, string caption)
        {
            var frm = GetForm();

            if (frm == null)
                XtraMessageBox.Show(text, caption, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
                ShowFlyout(frm, text, caption, Properties.Resources.warn);
        }

        public void ShowInfo(string text)
        {
            ShowInfo(text, "Информация");
        }

        public void ShowError(string text)
        {
            ShowError(text, "Ошибка");
        }

        public void ShowWarning(string text)
        {
            ShowWarning(text, "Внимание");
        }

        public void ShowError(Exception exception)
        {
            Log.WriteError(exception);

            if (exception is UserFriendlyException)
            {
                XtraMessageBox.Show(exception.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
#if DEBUG
                var text = string.Format("Возникла ошибка!\r\nПодробности:\r\n{0}", exception.ToString());
                XtraMessageBox.Show(text, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
#else

                var text = string.Format("Возникла ошибка! За подробностями обратитесь к администратору системы.");
                XtraMessageBox.Show(text, "Ошибка", MessageBoxButtons.YesNo, MessageBoxIcon.Error);                
#endif
                
            }
        }
    }
}
