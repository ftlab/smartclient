﻿namespace SmartClient.Core.Views
{
    partial class BaseWizardPage
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
			this.wizardBindingSource = new System.Windows.Forms.BindingSource(this.components);
			((System.ComponentModel.ISupportInitialize)(this.wizardBindingSource)).BeginInit();
			this.SuspendLayout();
			// 
			// BaseWizardPage
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Name = "BaseWizardPage";
			this.Size = new System.Drawing.Size(236, 256);
			((System.ComponentModel.ISupportInitialize)(this.wizardBindingSource)).EndInit();
			this.ResumeLayout(false);

        }

		#endregion

		private System.Windows.Forms.BindingSource wizardBindingSource;
	}
}
