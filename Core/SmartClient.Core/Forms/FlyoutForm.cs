using SmartClient.Core.AppModel;
using SmartClient.Core.Views;
using SmartClient.Core.Views.Custom;
using DevExpress.XtraBars.Docking2010.Customization;
using DevExpress.XtraBars.Docking2010.Views.WindowsUI;
using System.Windows.Forms;

namespace SmartClient.Core.Forms
{
    public class FlyoutForm : FlyoutDialog
    {
        private static readonly Form _defaultForm;

        static FlyoutForm()
        {
            _defaultForm = App.Instance.MainForm.Instance;
        }

        public FlyoutForm(Form owner, FlyoutAction action, Control control, FlyoutProperties properties)
            : base(owner, action, control, properties)
        {
            var closeSupport = FlyoutControl as ISupportDialogResult;
            if (closeSupport != null)
                closeSupport.SupportDialogResult += CloseSupport_SupportDialogResult;
        }

        private void CloseSupport_SupportDialogResult(object sender, SupportDialogResultEventArgs e)
        {
            DialogResult = e.Result;
            if (DialogResult == DialogResult.None)
                return;
            Close();

            var closeSupport = FlyoutControl as ISupportDialogResult;
            if (closeSupport != null)
                closeSupport.SupportDialogResult -= CloseSupport_SupportDialogResult;
        }

        public static DialogResult ShowFlyout(Form owner, FlyoutAction action, Control control,
            FlyoutProperties properties)
        {
            using (var frm = new FlyoutForm(owner, action, control, properties))
            {
                return frm.ShowDialog();
            }
        }

        public static DialogResult ShowFlyout(FlyoutAction action, Control control, FlyoutProperties properties)
        {
            return ShowFlyout(_defaultForm, action, control, properties);
        }

        public static DialogResult ShowPopup(Form owner, FlyoutAction action, Control control)
        {
            var properties = new FlyoutProperties();
            properties.Style = FlyoutStyle.Popup;

            return ShowFlyout(owner, action, control, properties);
        }

        public static DialogResult ShowPopup(FlyoutAction action, Control control)
        {
            return ShowPopup(_defaultForm, action, control);
        }

        public static DialogResult ShowBox(Form owner, FlyoutAction action, Control control)
        {
            var properties = new FlyoutProperties();
            properties.Style = FlyoutStyle.MessageBox;

            return ShowFlyout(owner, action, control, properties);
        }

        public static DialogResult ShowBox(FlyoutAction action, Control control)
        {
            return ShowBox(_defaultForm, action, control);
        }

        public static DialogResult ShowEditBox(string caption, ref string input, int? maxLength = null)
        {
            var action = new FlyoutAction();
            action.Caption = caption;
            using (var view = new EditBoxView())
            {
                if (!string.IsNullOrEmpty(input))
                    view.InputText = input;
                if (maxLength.HasValue)
                    view.MaxLength = maxLength.Value;

                var result = ShowPopup(action, view);
                input = view.InputText;
                return result;
            }
        }
    }
}
