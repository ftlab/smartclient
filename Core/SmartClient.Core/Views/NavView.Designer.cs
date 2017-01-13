namespace SmartClient.Core.Views
{
	partial class NavView
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

		#region Component Designer generated code

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.navBarControl = new DevExpress.XtraNavBar.NavBarControl();
			this.navBarGroup = new DevExpress.XtraNavBar.NavBarGroup();
			this.navBarGroupControlContainer = new DevExpress.XtraNavBar.NavBarGroupControlContainer();
			this.navigationTreeList = new DevExpress.XtraTreeList.TreeList();
			this.treeListColumn = new DevExpress.XtraTreeList.Columns.TreeListColumn();
			this.navigationSearchControl = new DevExpress.XtraEditors.SearchControl();
			this.navBindingSource = new System.Windows.Forms.BindingSource();
			this.viewContainer1 = new SmartClient.Core.Views.BaseViewContainer();
			this.ribbonPageGroup2 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
			((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.navBarControl)).BeginInit();
			this.navBarControl.SuspendLayout();
			this.navBarGroupControlContainer.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.navigationTreeList)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.navigationSearchControl.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.navBindingSource)).BeginInit();
			this.SuspendLayout();
			// 
			// ribbonControl1
			// 
			this.ribbonControl1.ExpandCollapseItem.Id = 0;
			this.ribbonControl1.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonControlStyle.Office2010;
			this.ribbonControl1.Size = new System.Drawing.Size(938, 75);
			this.ribbonControl1.Toolbar.ShowCustomizeItem = false;
			// 
			// ribbonPage1
			// 
			this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup2});
			// 
			// navBarControl
			// 
			this.navBarControl.ActiveGroup = this.navBarGroup;
			this.navBarControl.Controls.Add(this.navBarGroupControlContainer);
			this.navBarControl.Dock = System.Windows.Forms.DockStyle.Left;
			this.navBarControl.Groups.AddRange(new DevExpress.XtraNavBar.NavBarGroup[] {
            this.navBarGroup});
			this.navBarControl.Location = new System.Drawing.Point(0, 75);
			this.navBarControl.Name = "navBarControl";
			this.navBarControl.NavigationPaneMaxVisibleGroups = 0;
			this.navBarControl.NavigationPaneOverflowPanelUseSmallImages = false;
			this.navBarControl.OptionsNavPane.ExpandedWidth = 270;
			this.navBarControl.OptionsNavPane.ShowOverflowButton = false;
			this.navBarControl.OptionsNavPane.ShowOverflowPanel = false;
			this.navBarControl.OptionsNavPane.ShowSplitter = false;
			this.navBarControl.PaintStyleKind = DevExpress.XtraNavBar.NavBarViewKind.NavigationPane;
			this.navBarControl.Size = new System.Drawing.Size(270, 651);
			this.navBarControl.TabIndex = 1;
			this.navBarControl.Text = "navBarControl";
			// 
			// navBarGroup
			// 
			this.navBarGroup.Caption = "Навигатор";
			this.navBarGroup.ControlContainer = this.navBarGroupControlContainer;
			this.navBarGroup.Expanded = true;
			this.navBarGroup.GroupClientHeight = 631;
			this.navBarGroup.GroupStyle = DevExpress.XtraNavBar.NavBarGroupStyle.ControlContainer;
			this.navBarGroup.Name = "navBarGroup";
			// 
			// navBarGroupControlContainer
			// 
			this.navBarGroupControlContainer.Appearance.BackColor = System.Drawing.SystemColors.Control;
			this.navBarGroupControlContainer.Appearance.Options.UseBackColor = true;
			this.navBarGroupControlContainer.Controls.Add(this.navigationTreeList);
			this.navBarGroupControlContainer.Controls.Add(this.navigationSearchControl);
			this.navBarGroupControlContainer.Name = "navBarGroupControlContainer";
			this.navBarGroupControlContainer.Size = new System.Drawing.Size(270, 618);
			this.navBarGroupControlContainer.TabIndex = 0;
			// 
			// navigationTreeList
			// 
			this.navigationTreeList.Appearance.FocusedCell.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
			this.navigationTreeList.Appearance.FocusedCell.Options.UseForeColor = true;
			this.navigationTreeList.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.treeListColumn});
			this.navigationTreeList.Dock = System.Windows.Forms.DockStyle.Fill;
			this.navigationTreeList.Location = new System.Drawing.Point(0, 20);
			this.navigationTreeList.Name = "navigationTreeList";
			this.navigationTreeList.OptionsBehavior.Editable = false;
			this.navigationTreeList.OptionsBehavior.EnableFiltering = true;
			this.navigationTreeList.OptionsFilter.FilterMode = DevExpress.XtraTreeList.FilterMode.Extended;
			this.navigationTreeList.OptionsView.FocusRectStyle = DevExpress.XtraTreeList.DrawFocusRectStyle.None;
			this.navigationTreeList.OptionsView.ShowColumns = false;
			this.navigationTreeList.OptionsView.ShowHorzLines = false;
			this.navigationTreeList.OptionsView.ShowIndicator = false;
			this.navigationTreeList.OptionsView.ShowVertLines = false;
			this.navigationTreeList.Size = new System.Drawing.Size(270, 598);
			this.navigationTreeList.TabIndex = 1;
			this.navigationTreeList.CustomDrawNodeCell += new DevExpress.XtraTreeList.CustomDrawNodeCellEventHandler(this.navigationTreeList_CustomDrawNodeCell);
			// 
			// treeListColumn
			// 
			this.treeListColumn.Caption = "treeListColumn";
			this.treeListColumn.FieldName = "Caption";
			this.treeListColumn.Name = "treeListColumn";
			this.treeListColumn.Visible = true;
			this.treeListColumn.VisibleIndex = 0;
			// 
			// navigationSearchControl
			// 
			this.navigationSearchControl.Client = this.navigationTreeList;
			this.navigationSearchControl.Dock = System.Windows.Forms.DockStyle.Top;
			this.navigationSearchControl.Location = new System.Drawing.Point(0, 0);
			this.navigationSearchControl.MenuManager = this.ribbonControl1;
			this.navigationSearchControl.Name = "navigationSearchControl";
			this.navigationSearchControl.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Repository.ClearButton(),
            new DevExpress.XtraEditors.Repository.SearchButton()});
			this.navigationSearchControl.Properties.Client = this.navigationTreeList;
			this.navigationSearchControl.Properties.NullValuePrompt = "Введите текст для поиска...";
			this.navigationSearchControl.Size = new System.Drawing.Size(270, 20);
			this.navigationSearchControl.TabIndex = 0;
			// 
			// navBindingSource
			// 
			this.navBindingSource.DataSource = typeof(SmartClient.Core.ViewModels.BaseNavViewModel);
			// 
			// viewContainer1
			// 
			this.viewContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.viewContainer1.Location = new System.Drawing.Point(270, 75);
			this.viewContainer1.Name = "viewContainer1";
			this.viewContainer1.Size = new System.Drawing.Size(668, 651);
			this.viewContainer1.TabIndex = 2;
			this.viewContainer1.ActiveViewChanged += new System.EventHandler(this.viewContainer1_ActiveViewChanged);
			this.viewContainer1.Load += new System.EventHandler(this.viewContainer1_Load);
			// 
			// ribbonPageGroup2
			// 
			this.ribbonPageGroup2.Name = "ribbonPageGroup2";
			this.ribbonPageGroup2.Text = "ribbonPageGroup2";
			// 
			// NavView
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.viewContainer1);
			this.Controls.Add(this.navBarControl);
			this.Name = "NavView";
			this.Size = new System.Drawing.Size(938, 726);
			this.Controls.SetChildIndex(this.ribbonControl1, 0);
			this.Controls.SetChildIndex(this.navBarControl, 0);
			this.Controls.SetChildIndex(this.viewContainer1, 0);
			((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.navBarControl)).EndInit();
			this.navBarControl.ResumeLayout(false);
			this.navBarGroupControlContainer.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.navigationTreeList)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.navigationSearchControl.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.navBindingSource)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		public DevExpress.XtraNavBar.NavBarControl navBarControl;
		public DevExpress.XtraNavBar.NavBarGroup navBarGroup;
		public DevExpress.XtraNavBar.NavBarGroupControlContainer navBarGroupControlContainer;
		public DevExpress.XtraTreeList.TreeList navigationTreeList;
		private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn;
		public DevExpress.XtraEditors.SearchControl navigationSearchControl;
		public System.Windows.Forms.BindingSource navBindingSource;
		public BaseViewContainer viewContainer1;
		public DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup2;
	}
}
