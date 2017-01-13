namespace CMIOR.UI.WF.Views.Custom
{
    partial class UserSettingsView
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
            this.components = new System.ComponentModel.Container();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.indicatorNumerator1 = new CMIOR.UI.WF.Components.IndicatorNumerator(this.components);
            this._delBtn = new DevExpress.XtraBars.BarButtonItem();
            this._btnRefresh = new DevExpress.XtraBars.BarButtonItem();
            this.userSettingsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.colKey = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colValue = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.userSettingsBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbonControl1
            // 
            this.ribbonControl1.ExpandCollapseItem.Id = 0;
            this.ribbonControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this._delBtn,
            this._btnRefresh});
            this.ribbonControl1.MaxItemId = 5;
            this.ribbonControl1.Size = new System.Drawing.Size(667, 62);
            this.ribbonControl1.Toolbar.ShowCustomizeItem = false;
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.ItemLinks.Add(this._btnRefresh);
            this.ribbonPageGroup1.ItemLinks.Add(this._delBtn);
            // 
            // gridControl1
            // 
            this.gridControl1.DataSource = this.userSettingsBindingSource;
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 62);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.MenuManager = this.ribbonControl1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(667, 461);
            this.gridControl1.TabIndex = 1;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colKey,
            this.colValue});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.IndicatorWidth = 16;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // indicatorNumerator1
            // 
            this.indicatorNumerator1.GridView = this.gridView1;
            // 
            // _delBtn
            // 
            this._delBtn.Caption = "Удалить";
            this._delBtn.Glyph = global::CMIOR.UI.WF.Properties.Resources.delete_32x32;
            this._delBtn.Id = 3;
            this._delBtn.Name = "_delBtn";
            this._delBtn.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this._delBtn_ItemClick);
            // 
            // _btnRefresh
            // 
            this._btnRefresh.Caption = "Обновить";
            this._btnRefresh.Glyph = global::CMIOR.UI.WF.Properties.Resources.reset_32x32;
            this._btnRefresh.Id = 4;
            this._btnRefresh.Name = "_btnRefresh";
            this._btnRefresh.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this._btnRefresh_ItemClick);
            // 
            // userSettingsBindingSource
            // 
            this.userSettingsBindingSource.DataSource = typeof(CMIOR.UI.WF.Views.Custom.Model.UserSettings);
            // 
            // colKey
            // 
            this.colKey.FieldName = "Key";
            this.colKey.Name = "colKey";
            this.colKey.OptionsColumn.AllowEdit = false;
            this.colKey.Visible = true;
            this.colKey.VisibleIndex = 0;
            this.colKey.Width = 248;
            // 
            // colValue
            // 
            this.colValue.FieldName = "Value";
            this.colValue.Name = "colValue";
            this.colValue.OptionsColumn.AllowEdit = false;
            this.colValue.Visible = true;
            this.colValue.VisibleIndex = 1;
            this.colValue.Width = 401;
            // 
            // UserSettingsView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gridControl1);
            this.Name = "UserSettingsView";
            this.Size = new System.Drawing.Size(667, 523);
            this.Controls.SetChildIndex(this.ribbonControl1, 0);
            this.Controls.SetChildIndex(this.gridControl1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.userSettingsBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private Components.IndicatorNumerator indicatorNumerator1;
        private DevExpress.XtraBars.BarButtonItem _delBtn;
        private DevExpress.XtraBars.BarButtonItem _btnRefresh;
        private System.Windows.Forms.BindingSource userSettingsBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colKey;
        private DevExpress.XtraGrid.Columns.GridColumn colValue;
    }
}
