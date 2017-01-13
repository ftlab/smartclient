namespace SmartClient.Core.Views
{
    partial class WorkSpaceView
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
            this.documentManager1 = new DevExpress.XtraBars.Docking2010.DocumentManager();
            this.windowsUIView1 = new DevExpress.XtraBars.Docking2010.Views.WindowsUI.WindowsUIView();
            this.mainTileContainer = new DevExpress.XtraBars.Docking2010.Views.WindowsUI.TileContainer();
            ((System.ComponentModel.ISupportInitialize)(this.documentManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.windowsUIView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mainTileContainer)).BeginInit();
            this.SuspendLayout();
            // 
            // documentManager1
            // 
            this.documentManager1.ContainerControl = this;
            this.documentManager1.ShowThumbnailsInTaskBar = DevExpress.Utils.DefaultBoolean.False;
            this.documentManager1.View = this.windowsUIView1;
            this.documentManager1.ViewCollection.AddRange(new DevExpress.XtraBars.Docking2010.Views.BaseView[] {
            this.windowsUIView1});
            // 
            // windowsUIView1
            // 
            this.windowsUIView1.AddTileWhenCreatingDocument = DevExpress.Utils.DefaultBoolean.False;
            this.windowsUIView1.BackgroundImageLayoutMode = DevExpress.Utils.Drawing.ImageLayoutMode.TopLeft;
            this.windowsUIView1.Caption = "";
            this.windowsUIView1.ContentContainers.AddRange(new DevExpress.XtraBars.Docking2010.Views.WindowsUI.IContentContainer[] {
            this.mainTileContainer});
            this.windowsUIView1.PageGroupProperties.HeaderOffset = -50;
            this.windowsUIView1.PageProperties.HeaderOffset = -20;
            this.windowsUIView1.PageProperties.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.windowsUIView1.SearchPanelProperties.Caption = "Поиск";
            this.windowsUIView1.SearchPanelProperties.Enabled = false;
            this.windowsUIView1.SearchPanelProperties.NullValuePrompt = "Введите текст для поиска...";
            this.windowsUIView1.SlideGroupProperties.HeaderOffset = -20;
            this.windowsUIView1.SplitGroupProperties.HeaderOffset = -20;
            this.windowsUIView1.TabbedGroupProperties.HeaderOffset = -20;
            this.windowsUIView1.UseLoadingIndicator = DevExpress.Utils.DefaultBoolean.False;
            this.windowsUIView1.UseSplashScreen = DevExpress.Utils.DefaultBoolean.False;
            // 
            // mainTileContainer
            // 
            this.mainTileContainer.AppearanceItem.Hovered.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(138)))), ((int)(((byte)(9)))));
            this.mainTileContainer.AppearanceItem.Hovered.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(138)))), ((int)(((byte)(9)))));
            this.mainTileContainer.AppearanceItem.Hovered.Options.UseBackColor = true;
            this.mainTileContainer.AppearanceItem.Hovered.Options.UseBorderColor = true;
            this.mainTileContainer.AppearanceItem.Normal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(133)))), ((int)(((byte)(120)))), ((int)(((byte)(181)))));
            this.mainTileContainer.AppearanceItem.Normal.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(133)))), ((int)(((byte)(120)))), ((int)(((byte)(181)))));
            this.mainTileContainer.AppearanceItem.Normal.Options.UseBackColor = true;
            this.mainTileContainer.AppearanceItem.Normal.Options.UseBorderColor = true;
            this.mainTileContainer.Caption = "SMART CLIENT";
            this.mainTileContainer.Image = global::SmartClient.Core.Properties.Resources.hight_32x32;
            this.mainTileContainer.Name = "mainTileContainer";
            this.mainTileContainer.Properties.AllowItemHover = DevExpress.Utils.DefaultBoolean.True;
            this.mainTileContainer.Properties.ItemCheckMode = DevExpress.XtraEditors.TileItemCheckMode.None;
            this.mainTileContainer.Properties.RowCount = 3;

            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1090, 423);
            ((System.ComponentModel.ISupportInitialize)(this.documentManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.windowsUIView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mainTileContainer)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public DevExpress.XtraBars.Docking2010.DocumentManager documentManager1;
        public DevExpress.XtraBars.Docking2010.Views.WindowsUI.WindowsUIView windowsUIView1;
        public DevExpress.XtraBars.Docking2010.Views.WindowsUI.TileContainer mainTileContainer;
    }
}
