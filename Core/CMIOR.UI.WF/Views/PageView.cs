using DevExpress.XtraEditors;

namespace CMIOR.UI.WF.Views
{
    public partial class PageView : FlatView
    {
        public PageView()
        {
            InitializeComponent();
        }

        protected void SetСancelButtonCaption(string cancelButtonCaption)
        {
            windowsUIButtonPanel1.Buttons[1].Properties.Caption = cancelButtonCaption;
        }

        protected void SetSaveButtonCaption(string saveButtonCaption)
        {
            windowsUIButtonPanel1.Buttons[0].Properties.Caption = saveButtonCaption;
        }

        protected void HideСancelButton()
        {
            windowsUIButtonPanel1.Buttons[1].Properties.Visible = false;
        }

        private void windowsUIButtonPanel1_ButtonClick(object sender, DevExpress.XtraBars.Docking2010.ButtonEventArgs e)
        {
            int index = windowsUIButtonPanel1.Buttons.IndexOf(e.Button);
            if (index == 0)
                OnSaveClick();
            else if (index == 1)
                OnCancelClick();
        }

        protected virtual void OnSaveClick() { }

        protected virtual void OnCancelClick() { }
    }
}
