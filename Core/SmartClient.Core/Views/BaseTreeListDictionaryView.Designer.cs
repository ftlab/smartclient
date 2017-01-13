using System;
using System.Windows.Forms;
using DevExpress.XtraTreeList;

namespace SmartClient.Core.Views
{
	partial class BaseTreeListDictionaryView<L,I>
    {
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		protected System.ComponentModel.IContainer components = null;

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
            this.treeList = new DevExpress.XtraTreeList.TreeList();
            this.panelControlMain = new DevExpress.XtraEditors.PanelControl();
            this.searchControl = new DevExpress.XtraEditors.SearchControl();
            ((System.ComponentModel.ISupportInitialize)(this.treeList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControlMain)).BeginInit();
            this.panelControlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.searchControl.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // treeList
            // 
            this.treeList.Location = new System.Drawing.Point(0, 0);
            this.treeList.Name = "treeList";
            this.treeList.Size = new System.Drawing.Size(400, 200);
            this.treeList.OptionsBehavior.EnableFiltering = true;
            this.treeList.OptionsFilter.FilterMode = DevExpress.XtraTreeList.FilterMode.Extended;
            this.treeList.TabIndex = 1;
            this.treeList.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.treeList_MouseDoubleClick);
            this.treeList.FilterNode += treeList_FilterNode;
            this.treeList.NodeCellStyle += new DevExpress.XtraTreeList.GetCustomNodeCellStyleEventHandler(this.treeList_NodeCellStyle);
            this.treeList.BeforeDragNode += new DevExpress.XtraTreeList.BeforeDragNodeEventHandler(this.treeList_BeforeDragNode);
            this.treeList.FocusedNodeChanged += new DevExpress.XtraTreeList.FocusedNodeChangedEventHandler(this.treeList_FocusedNodeChanged);
            // 
            // panelControlMain
            // 
            this.panelControlMain.Controls.Add(this.searchControl);
            this.panelControlMain.Controls.Add(this.treeList);
            this.panelControlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControlMain.Location = new System.Drawing.Point(0, 0);
            this.panelControlMain.Name = "panelControlMain";
            this.panelControlMain.Size = new System.Drawing.Size(408, 211);
            this.panelControlMain.TabIndex = 0;
            // 
            // searchControl
            // 
            this.searchControl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.searchControl.Client = this.treeList;
            this.searchControl.Location = new System.Drawing.Point(5, 2);
            this.searchControl.Name = "searchControl";
            this.searchControl.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Repository.ClearButton(),
            new DevExpress.XtraEditors.Repository.SearchButton()});
            this.searchControl.Properties.Client = this.treeList;
            this.searchControl.Properties.NullValuePrompt = "Введите текст для поиска...";
            this.searchControl.Size = new System.Drawing.Size(308, 20);
            this.searchControl.TabIndex = 0;
            // 
            // BaseTreeListDictionaryView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.Controls.Add(this.panelControlMain);
            this.Name = "BaseTreeListDictionaryView";
            this.Size = new System.Drawing.Size(408, 211);
            ((System.ComponentModel.ISupportInitialize)(this.treeList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControlMain)).EndInit();
            this.panelControlMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.searchControl.Properties)).EndInit();
            this.ResumeLayout(false);

		}

        #endregion

        protected DevExpress.XtraTreeList.TreeList treeList;
        protected DevExpress.XtraEditors.PanelControl panelControlMain;
        protected DevExpress.XtraEditors.SearchControl searchControl;
    }
}
