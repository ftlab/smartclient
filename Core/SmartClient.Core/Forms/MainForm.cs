using System;
using System.ComponentModel;
using System.Windows.Forms;
using DevExpress.XtraBars.Docking2010;
using DevExpress.XtraBars.Docking2010.Views.WindowsUI;
using System.Configuration;
using SmartClient.Core.Container;
using SmartClient.Core.AppModel.Info;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraBars.Docking;
using SmartClient.Core.Controls.Bars;

namespace SmartClient.Core.Forms
{
    public partial class MainForm : DevExpress.XtraBars.Ribbon.RibbonForm, IMainForm
    {
        public MainForm()
        {
            InitializeComponent();

            ribbonControl.Manager.UseAltKeyForMenu = false;

            var value = ConfigurationManager.AppSettings["formsizable"];
            bool sizable;
            if (value != null && bool.TryParse(value, out sizable) && sizable)
            {
                FormBorderStyle = FormBorderStyle.Sizable;
            }

            appBar1.flyoutPanel1.OwnerControl = workSpaceView1;
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Form.Load"/> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs"/> that contains the event data. </param>
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            workSpaceView1.ActivateContainer();
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);

            if (ServiceContainer.Default.DialogService
                                .Ask("Закрыть программу?", "Завершение программы") == false)
                e.Cancel = true;
            else
                e.Cancel = false;
        }

        public Form Instance => this;

        // ReSharper disable once ConvertToAutoProperty
        public DocumentManager DocumentManager => workSpaceView1.documentManager1;

        public DockManager DockManager => dockManager1;

        // ReSharper disable once ConvertToAutoProperty
        public TileContainer MainContainer => workSpaceView1.mainTileContainer;

        // ReSharper disable once ConvertToAutoProperty
        public WindowsUIView WindowsUiView => workSpaceView1.windowsUIView1;

        public RibbonControl RibbonControl => ribbonControl;

        public AppBar AppBar => appBar1;

        private void ribbonControl_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var viewInfo = e.Item.Tag as QuickButtonViewInfo;
            if (viewInfo != null && viewInfo.Click != null)
                viewInfo.Click();
        }

        private void ribbonControl_ShowCustomizationMenu(object sender, RibbonCustomizationMenuEventArgs e)
        {
            e.ShowCustomizationMenu = false;
        }
    }
}
