namespace SmartClient.Core.Forms
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.ribbonControl = new SmartClient.Core.Forms.QuickRibbonControl();
            this.dockManager1 = new DevExpress.XtraBars.Docking.DockManager(this.components);
            this.workSpaceView1 = new SmartClient.Core.Views.WorkSpaceView();
            this.appBar1 = new SmartClient.Core.Controls.Bars.AppBar();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dockManager1)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbonControl
            // 
            this.ribbonControl.AllowMinimizeRibbon = false;
            this.ribbonControl.ExpandCollapseItem.Id = 0;
            this.ribbonControl.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbonControl.ExpandCollapseItem});
            this.ribbonControl.Location = new System.Drawing.Point(0, 0);
            this.ribbonControl.MaxItemId = 7;
            this.ribbonControl.Name = "ribbonControl";
            this.ribbonControl.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonControlStyle.Office2013;
            this.ribbonControl.ShowApplicationButton = DevExpress.Utils.DefaultBoolean.False;
            this.ribbonControl.ShowDisplayOptionsMenuButton = DevExpress.Utils.DefaultBoolean.False;
            this.ribbonControl.ShowExpandCollapseButton = DevExpress.Utils.DefaultBoolean.False;
            this.ribbonControl.ShowPageHeadersMode = DevExpress.XtraBars.Ribbon.ShowPageHeadersMode.Hide;
            this.ribbonControl.ShowQatLocationSelector = false;
            this.ribbonControl.ShowToolbarCustomizeItem = false;
            this.ribbonControl.Size = new System.Drawing.Size(1090, 27);
            this.ribbonControl.Toolbar.ShowCustomizeItem = false;
            this.ribbonControl.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.ribbonControl_ItemClick);
            this.ribbonControl.ShowCustomizationMenu += new DevExpress.XtraBars.Ribbon.RibbonCustomizationMenuEventHandler(this.ribbonControl_ShowCustomizationMenu);
            // 
            // dockManager1
            // 
            this.dockManager1.Form = this;
            this.dockManager1.TopZIndexControls.AddRange(new string[] {
            "DevExpress.XtraBars.BarDockControl",
            "DevExpress.XtraBars.StandaloneBarDockControl",
            "System.Windows.Forms.StatusBar",
            "System.Windows.Forms.MenuStrip",
            "System.Windows.Forms.StatusStrip",
            "DevExpress.XtraBars.Ribbon.RibbonStatusBar",
            "DevExpress.XtraBars.Ribbon.RibbonControl",
            "DevExpress.XtraBars.Navigation.OfficeNavigationBar",
            "DevExpress.XtraBars.Navigation.TileNavPane"});
            // 
            // workSpaceView1
            // 
            this.workSpaceView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.workSpaceView1.Location = new System.Drawing.Point(33, 27);
            this.workSpaceView1.Name = "workSpaceView1";
            this.workSpaceView1.Size = new System.Drawing.Size(1057, 396);
            this.workSpaceView1.TabIndex = 1;
            // 
            // appBar1
            // 
            this.appBar1.AllowDrag = false;
            this.appBar1.AllowSelectedItem = true;
            this.appBar1.Cursor = System.Windows.Forms.Cursors.Default;
            this.appBar1.Dock = System.Windows.Forms.DockStyle.Left;
            this.appBar1.DropDownOptions.BeakColor = System.Drawing.Color.Empty;
            this.appBar1.GroupTextToItemsIndent = 0;
            this.appBar1.HorizontalContentAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.appBar1.IndentBetweenGroups = 0;
            this.appBar1.IndentBetweenItems = 0;
            this.appBar1.ItemImageAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleCenter;
            this.appBar1.ItemPadding = new System.Windows.Forms.Padding(0);
            this.appBar1.ItemSize = 32;
            this.appBar1.ItemTextShowMode = DevExpress.XtraEditors.TileItemContentShowMode.Always;
            this.appBar1.Location = new System.Drawing.Point(0, 27);
            this.appBar1.Margin = new System.Windows.Forms.Padding(0);
            this.appBar1.Name = "appBar1";
            this.appBar1.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.appBar1.Padding = new System.Windows.Forms.Padding(0);
            this.appBar1.ScrollMode = DevExpress.XtraEditors.TileControlScrollMode.ScrollButtons;
            this.appBar1.SelectionColorMode = DevExpress.XtraBars.Navigation.SelectionColorMode.UseItemBackColor;
            this.appBar1.ShowGroupText = false;
            this.appBar1.Size = new System.Drawing.Size(33, 396);
            this.appBar1.TabIndex = 3;
            this.appBar1.Text = "appBar1";
            this.appBar1.VerticalContentAlignment = DevExpress.Utils.VertAlignment.Top;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1090, 423);
            this.Controls.Add(this.workSpaceView1);
            this.Controls.Add(this.appBar1);
            this.Controls.Add(this.ribbonControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Ribbon = this.ribbonControl;
            this.Text = "\tSMART CLIENT";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dockManager1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private QuickRibbonControl ribbonControl;
        private DevExpress.XtraBars.Docking.DockManager dockManager1;
        private Views.WorkSpaceView workSpaceView1;
        private Controls.Bars.AppBar appBar1;
    }
}