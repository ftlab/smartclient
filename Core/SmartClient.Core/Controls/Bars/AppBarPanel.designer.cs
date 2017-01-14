namespace SmartClient.Core.Controls.Bars
{
    partial class AppBarPanel
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
            DevExpress.XtraGrid.Views.Tile.TileViewItemElement tileViewItemElement1 = new DevExpress.XtraGrid.Views.Tile.TileViewItemElement();
            DevExpress.XtraGrid.Views.Tile.TileViewItemElement tileViewItemElement2 = new DevExpress.XtraGrid.Views.Tile.TileViewItemElement();
            this.colImage1 = new DevExpress.XtraGrid.Columns.TileViewColumn();
            this.colCaption1 = new DevExpress.XtraGrid.Columns.TileViewColumn();
            this.colDecription1 = new DevExpress.XtraGrid.Columns.TileViewColumn();
            this.searchControl1 = new DevExpress.XtraEditors.SearchControl();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.appBarItemBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.winExplorerView1 = new DevExpress.XtraGrid.Views.WinExplorer.WinExplorerView();
            this.colName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCaption = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDecription = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colImage = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGroup = new DevExpress.XtraGrid.Columns.GridColumn();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.gridControl2 = new DevExpress.XtraGrid.GridControl();
            this.tileView1 = new DevExpress.XtraGrid.Views.Tile.TileView();
            this.colName1 = new DevExpress.XtraGrid.Columns.TileViewColumn();
            this.colGroup1 = new DevExpress.XtraGrid.Columns.TileViewColumn();
            this.popupMenu1 = new DevExpress.XtraBars.PopupMenu(this.components);
            this.btnPin = new DevExpress.XtraBars.BarButtonItem();
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            ((System.ComponentModel.ISupportInitialize)(this.searchControl1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.appBarItemBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.winExplorerView1)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tileView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            this.SuspendLayout();
            // 
            // colImage1
            // 
            this.colImage1.FieldName = "Image";
            this.colImage1.Name = "colImage1";
            this.colImage1.Visible = true;
            this.colImage1.VisibleIndex = 3;
            // 
            // colCaption1
            // 
            this.colCaption1.FieldName = "Caption";
            this.colCaption1.Name = "colCaption1";
            this.colCaption1.Visible = true;
            this.colCaption1.VisibleIndex = 1;
            // 
            // colDecription1
            // 
            this.colDecription1.FieldName = "Decription";
            this.colDecription1.Name = "colDecription1";
            this.colDecription1.Visible = true;
            this.colDecription1.VisibleIndex = 2;
            // 
            // searchControl1
            // 
            this.searchControl1.Client = this.gridControl1;
            this.tableLayoutPanel1.SetColumnSpan(this.searchControl1, 2);
            this.searchControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.searchControl1.Location = new System.Drawing.Point(3, 3);
            this.searchControl1.Name = "searchControl1";
            this.searchControl1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Repository.ClearButton(),
            new DevExpress.XtraEditors.Repository.SearchButton()});
            this.searchControl1.Properties.Client = this.gridControl1;
            this.searchControl1.Size = new System.Drawing.Size(724, 20);
            this.searchControl1.TabIndex = 0;
            // 
            // gridControl1
            // 
            this.gridControl1.DataSource = this.appBarItemBindingSource;
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(3, 28);
            this.gridControl1.MainView = this.winExplorerView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(239, 405);
            this.gridControl1.TabIndex = 1;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.winExplorerView1});
            this.gridControl1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.gridControl1_MouseClick);
            // 
            // appBarItemBindingSource
            // 
            this.appBarItemBindingSource.DataSource = typeof(AppBarItem);
            // 
            // winExplorerView1
            // 
            this.winExplorerView1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.winExplorerView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colName,
            this.colCaption,
            this.colDecription,
            this.colImage,
            this.colGroup});
            this.winExplorerView1.ColumnSet.DescriptionColumn = this.colDecription;
            this.winExplorerView1.ColumnSet.ExtraLargeImageColumn = this.colImage;
            this.winExplorerView1.ColumnSet.GroupColumn = this.colGroup;
            this.winExplorerView1.ColumnSet.LargeImageColumn = this.colImage;
            this.winExplorerView1.ColumnSet.MediumImageColumn = this.colImage;
            this.winExplorerView1.ColumnSet.SmallImageColumn = this.colImage;
            this.winExplorerView1.ColumnSet.TextColumn = this.colCaption;
            this.winExplorerView1.GridControl = this.gridControl1;
            this.winExplorerView1.GroupCount = 1;
            this.winExplorerView1.Name = "winExplorerView1";
            this.winExplorerView1.OptionsBehavior.Editable = false;
            this.winExplorerView1.OptionsView.Style = DevExpress.XtraGrid.Views.WinExplorer.WinExplorerViewStyle.Tiles;
            this.winExplorerView1.OptionsViewStyles.Tiles.CheckBoxMargins = new System.Windows.Forms.Padding(0);
            this.winExplorerView1.OptionsViewStyles.Tiles.ContentMargins = new System.Windows.Forms.Padding(0);
            this.winExplorerView1.OptionsViewStyles.Tiles.GroupCaptionButtonIndent = 0;
            this.winExplorerView1.OptionsViewStyles.Tiles.GroupCheckBoxIndent = 0;
            this.winExplorerView1.OptionsViewStyles.Tiles.HorizontalIndent = 0;
            this.winExplorerView1.OptionsViewStyles.Tiles.ImageMargins = new System.Windows.Forms.Padding(0);
            this.winExplorerView1.OptionsViewStyles.Tiles.ImageSize = new System.Drawing.Size(24, 24);
            this.winExplorerView1.OptionsViewStyles.Tiles.IndentBetweenGroupAndItem = 0;
            this.winExplorerView1.OptionsViewStyles.Tiles.IndentBetweenGroups = 0;
            this.winExplorerView1.OptionsViewStyles.Tiles.ShowDescription = DevExpress.Utils.DefaultBoolean.False;
            this.winExplorerView1.OptionsViewStyles.Tiles.VerticalIndent = 0;
            this.winExplorerView1.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colGroup, DevExpress.Data.ColumnSortOrder.Ascending)});
            this.winExplorerView1.ViewCaptionHeight = 0;
            // 
            // colName
            // 
            this.colName.FieldName = "Name";
            this.colName.Name = "colName";
            this.colName.Visible = true;
            this.colName.VisibleIndex = 0;
            // 
            // colCaption
            // 
            this.colCaption.FieldName = "Caption";
            this.colCaption.Name = "colCaption";
            this.colCaption.Visible = true;
            this.colCaption.VisibleIndex = 1;
            // 
            // colDecription
            // 
            this.colDecription.FieldName = "Decription";
            this.colDecription.Name = "colDecription";
            this.colDecription.Visible = true;
            this.colDecription.VisibleIndex = 2;
            // 
            // colImage
            // 
            this.colImage.FieldName = "Image";
            this.colImage.Name = "colImage";
            this.colImage.Visible = true;
            this.colImage.VisibleIndex = 3;
            // 
            // colGroup
            // 
            this.colGroup.FieldName = "Group";
            this.colGroup.Name = "colGroup";
            this.colGroup.Visible = true;
            this.colGroup.VisibleIndex = 4;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.56165F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 66.43835F));
            this.tableLayoutPanel1.Controls.Add(this.searchControl1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.gridControl1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.gridControl2, 1, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(730, 436);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // gridControl2
            // 
            this.gridControl2.DataSource = this.appBarItemBindingSource;
            this.gridControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl2.Location = new System.Drawing.Point(248, 28);
            this.gridControl2.MainView = this.tileView1;
            this.gridControl2.Name = "gridControl2";
            this.gridControl2.Size = new System.Drawing.Size(479, 405);
            this.gridControl2.TabIndex = 2;
            this.gridControl2.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.tileView1});
            this.gridControl2.MouseClick += new System.Windows.Forms.MouseEventHandler(this.gridControl2_MouseClick);
            // 
            // tileView1
            // 
            this.tileView1.Appearance.ItemFocused.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(164)))), ((int)(((byte)(159)))));
            this.tileView1.Appearance.ItemFocused.Options.UseBackColor = true;
            this.tileView1.Appearance.ItemHovered.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(138)))), ((int)(((byte)(9)))));
            this.tileView1.Appearance.ItemHovered.Options.UseBackColor = true;
            this.tileView1.Appearance.ItemNormal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(122)))), ((int)(((byte)(172)))));
            this.tileView1.Appearance.ItemNormal.BorderColor = System.Drawing.Color.Transparent;
            this.tileView1.Appearance.ItemNormal.Options.UseBackColor = true;
            this.tileView1.Appearance.ItemNormal.Options.UseBorderColor = true;
            this.tileView1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.tileView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colName1,
            this.colCaption1,
            this.colDecription1,
            this.colImage1,
            this.colGroup1});
            this.tileView1.GridControl = this.gridControl2;
            this.tileView1.Name = "tileView1";
            this.tileView1.OptionsBehavior.ReadOnly = true;
            this.tileView1.OptionsTiles.AllowItemHover = true;
            this.tileView1.OptionsTiles.ColumnCount = 3;
            this.tileView1.OptionsTiles.HorizontalContentAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.tileView1.OptionsTiles.IndentBetweenGroups = 5;
            this.tileView1.OptionsTiles.IndentBetweenItems = 5;
            this.tileView1.OptionsTiles.ItemPadding = new System.Windows.Forms.Padding(0);
            this.tileView1.OptionsTiles.ItemSize = new System.Drawing.Size(90, 90);
            this.tileView1.OptionsTiles.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.tileView1.OptionsTiles.RowCount = 3;
            this.tileView1.OptionsTiles.ScrollMode = DevExpress.XtraEditors.TileControlScrollMode.ScrollBar;
            this.tileView1.OptionsTiles.ShowGroupText = false;
            this.tileView1.OptionsTiles.VerticalContentAlignment = DevExpress.Utils.VertAlignment.Top;
            tileViewItemElement1.Column = this.colImage1;
            tileViewItemElement1.ImageAlignment = DevExpress.XtraEditors.TileItemContentAlignment.TopCenter;
            tileViewItemElement1.ImageLocation = new System.Drawing.Point(0, 10);
            tileViewItemElement1.ImageScaleMode = DevExpress.XtraEditors.TileItemImageScaleMode.Stretch;
            tileViewItemElement1.ImageSize = new System.Drawing.Size(50, 50);
            tileViewItemElement1.ImageToTextAlignment = DevExpress.XtraEditors.TileControlImageToTextAlignment.Top;
            tileViewItemElement1.Text = "colImage1";
            tileViewItemElement1.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.TopLeft;
            tileViewItemElement2.Column = this.colCaption1;
            tileViewItemElement2.Text = "colCaption1";
            tileViewItemElement2.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.BottomCenter;
            tileViewItemElement2.TextLocation = new System.Drawing.Point(0, -10);
            this.tileView1.TileTemplate.Add(tileViewItemElement1);
            this.tileView1.TileTemplate.Add(tileViewItemElement2);
            // 
            // colName1
            // 
            this.colName1.FieldName = "Name";
            this.colName1.Name = "colName1";
            this.colName1.Visible = true;
            this.colName1.VisibleIndex = 0;
            // 
            // colGroup1
            // 
            this.colGroup1.FieldName = "Group";
            this.colGroup1.Name = "colGroup1";
            this.colGroup1.Visible = true;
            this.colGroup1.VisibleIndex = 4;
            // 
            // popupMenu1
            // 
            this.popupMenu1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnPin, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)});
            this.popupMenu1.Manager = this.barManager1;
            this.popupMenu1.Name = "popupMenu1";
            // 
            // btnPin
            // 
            this.btnPin.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check;
            this.btnPin.Caption = "Закрепить";
            this.btnPin.Glyph = global::SmartClient.Core.Properties.Resources.push_pin;
            this.btnPin.Id = 0;
            this.btnPin.Name = "btnPin";
            this.btnPin.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnPin_ItemClick);
            // 
            // barManager1
            // 
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.btnPin});
            this.barManager1.MaxItemId = 1;
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Size = new System.Drawing.Size(730, 0);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 436);
            this.barDockControlBottom.Size = new System.Drawing.Size(730, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 0);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 436);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(730, 0);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 436);
            // 
            // AppBarPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "AppBarPanel";
            this.Size = new System.Drawing.Size(730, 436);
            ((System.ComponentModel.ISupportInitialize)(this.searchControl1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.appBarItemBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.winExplorerView1)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tileView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.SearchControl searchControl1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.WinExplorer.WinExplorerView winExplorerView1;
        private System.Windows.Forms.BindingSource appBarItemBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colName;
        private DevExpress.XtraGrid.Columns.GridColumn colCaption;
        private DevExpress.XtraGrid.Columns.GridColumn colDecription;
        private DevExpress.XtraGrid.Columns.GridColumn colImage;
        private DevExpress.XtraGrid.Columns.GridColumn colGroup;
        private DevExpress.XtraGrid.GridControl gridControl2;
        private DevExpress.XtraGrid.Views.Tile.TileView tileView1;
        private DevExpress.XtraGrid.Columns.TileViewColumn colName1;
        private DevExpress.XtraGrid.Columns.TileViewColumn colCaption1;
        private DevExpress.XtraGrid.Columns.TileViewColumn colDecription1;
        private DevExpress.XtraGrid.Columns.TileViewColumn colImage1;
        private DevExpress.XtraGrid.Columns.TileViewColumn colGroup1;
        private DevExpress.XtraBars.PopupMenu popupMenu1;
        private DevExpress.XtraBars.BarButtonItem btnPin;
        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
    }
}
