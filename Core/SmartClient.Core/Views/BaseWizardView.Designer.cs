using SmartClient.Core.ViewModels;

namespace SmartClient.Core.Views
{
	partial class BaseWizardView
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BaseWizardView));
			this.documentManager1 = new DevExpress.XtraBars.Docking2010.DocumentManager(this.components);
			this.windowsUIView1 = new DevExpress.XtraBars.Docking2010.Views.WindowsUI.WindowsUIView(this.components);
			this.pageGroup1 = new DevExpress.XtraBars.Docking2010.Views.WindowsUI.PageGroup(this.components);
			this.imageCollection1 = new DevExpress.Utils.ImageCollection(this.components);
			this.bindingSource = new System.Windows.Forms.BindingSource(this.components);
			((System.ComponentModel.ISupportInitialize)(this.documentManager1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.windowsUIView1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pageGroup1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.imageCollection1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
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
			this.windowsUIView1.AllowCaptionDragMove = DevExpress.Utils.DefaultBoolean.False;
			this.windowsUIView1.ContentContainers.AddRange(new DevExpress.XtraBars.Docking2010.Views.WindowsUI.IContentContainer[] {
            this.pageGroup1});
			this.windowsUIView1.PageGroupProperties.HeaderOffset = -35;
			this.windowsUIView1.PageGroupProperties.ShowPageHeaders = false;
            this.windowsUIView1.SearchPanelProperties.Enabled = false;
            this.windowsUIView1.UseLoadingIndicator = DevExpress.Utils.DefaultBoolean.False;
			this.windowsUIView1.UseSplashScreen = DevExpress.Utils.DefaultBoolean.False;
			this.windowsUIView1.NavigationBarsShowing += new DevExpress.XtraBars.Docking2010.Views.WindowsUI.NavigationBarsCancelEventHandler(this.windowsUIView1_NavigationBarsShowing);
			// 
			// pageGroup1
			// 
			this.pageGroup1.Name = "pageGroup1";
			// 
			// imageCollection1
			// 
			this.imageCollection1.ImageSize = new System.Drawing.Size(32, 32);
			this.imageCollection1.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imageCollection1.ImageStream")));
			this.imageCollection1.Images.SetKeyName(0, "prev.png");
			this.imageCollection1.Images.SetKeyName(1, "next.png");
			this.imageCollection1.Images.SetKeyName(2, "save.png");
			this.imageCollection1.InsertGalleryImage("cancel_32x32.png", "office2013/actions/cancel_32x32.png", DevExpress.Images.ImageResourceCache.Default.GetImage("office2013/actions/cancel_32x32.png"), 3);
			this.imageCollection1.Images.SetKeyName(3, "cancel_32x32.png");
			// 
			// bindingSource
			// 
			this.bindingSource.DataSource = typeof(BaseWizardViewModel);
			// 
			// BaseWizardView
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Name = "BaseWizardView";
			this.Size = new System.Drawing.Size(846, 636);
			((System.ComponentModel.ISupportInitialize)(this.documentManager1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.windowsUIView1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pageGroup1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.imageCollection1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private DevExpress.XtraBars.Docking2010.DocumentManager documentManager1;
		protected DevExpress.XtraBars.Docking2010.Views.WindowsUI.WindowsUIView windowsUIView1;
		protected DevExpress.XtraBars.Docking2010.Views.WindowsUI.PageGroup pageGroup1;
		private DevExpress.Utils.ImageCollection imageCollection1;
		protected System.Windows.Forms.BindingSource bindingSource;
	}
}
