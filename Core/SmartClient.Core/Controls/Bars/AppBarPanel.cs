using System;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.Utils;

namespace SmartClient.Core.Controls.Bars
{
    public partial class AppBarPanel : XtraUserControl
    {
        private AppBar _appBar;

        public event EventHandler ItemClick;

        public AppBarPanel()
        {
            InitializeComponent();
        }

        public AppBarItem ActiveItem => appBarItemBindingSource.Current as AppBarItem;

        public AppBar GetAppBar() => _appBar;

        public void SetAppBar(AppBar appBar)
        {
            if (appBar == null) throw new ArgumentNullException(nameof(appBar));
            if (_appBar != null) throw new ArgumentException(nameof(_appBar));
            _appBar = appBar;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            if (AppearanceObject.DefaultFont.SizeInPoints < 11)
                tileView1.OptionsTiles.ColumnCount = 4;
            else if (AppearanceObject.DefaultFont.SizeInPoints >= 10)
                tileView1.OptionsTiles.ColumnCount = 3;
            else if (AppearanceObject.DefaultFont.SizeInPoints >= 14)
                tileView1.OptionsTiles.ColumnCount = 3;

            if (_appBar != null)
            {
                appBarItemBindingSource.DataSource = _appBar.Items;
            }
        }

        private void gridControl1_MouseClick(object sender, MouseEventArgs e)
        {
            var hint = winExplorerView1.CalcHitInfo(e.Location);
            {
                if (hint != null && hint.InItem)
                {
                    if (e.Button == MouseButtons.Left) InvokeItemClick();
                    else if (e.Button == MouseButtons.Right) InvokeItemMenu();
                }
            }
        }

        private void gridControl2_MouseClick(object sender, MouseEventArgs e)
        {
            var hint = tileView1.CalcHitInfo(e.Location);
            if (hint != null && hint.InItem)
            {
                if (e.Button == MouseButtons.Left) InvokeItemClick();
                else if (e.Button == MouseButtons.Right) InvokeItemMenu();
            }
        }

        private void InvokeItemClick() => ItemClick?.Invoke(this, EventArgs.Empty);

        private void InvokeItemMenu()
        {
            if (ActiveItem != null)
            {
                if (ActiveItem.Pinned)
                    btnPin.Caption = "Открепить";
                else
                    btnPin.Caption = "Закрепить";

                popupMenu1.ShowPopup(Control.MousePosition);
            }
        }

        private void btnPin_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (ActiveItem != null)
            {
                AppBarSettings.SwitchPin(ActiveItem.Name);
                if (_appBar != null) _appBar.SwithPinItem(ActiveItem.Name);
            }
        }
    }
}
