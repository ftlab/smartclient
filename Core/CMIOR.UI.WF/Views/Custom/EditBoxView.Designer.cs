namespace CMIOR.UI.WF.Views.Custom
{
    partial class EditBoxView
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
            this._okButton = new CMIOR.UI.WF.Controls.FillButton();
            this._cancelButton = new CMIOR.UI.WF.Controls.FillButton();
            this.memoEdit1 = new DevExpress.XtraEditors.MemoEdit();
            ((System.ComponentModel.ISupportInitialize)(this.memoEdit1.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // _okButton
            // 
            this._okButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._okButton.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(126)))), ((int)(((byte)(143)))));
            this._okButton.Appearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(122)))), ((int)(((byte)(172)))));
            this._okButton.Appearance.ForeColor = System.Drawing.Color.White;
            this._okButton.Appearance.Options.UseBackColor = true;
            this._okButton.Appearance.Options.UseBorderColor = true;
            this._okButton.Appearance.Options.UseForeColor = true;
            this._okButton.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this._okButton.Location = new System.Drawing.Point(153, 143);
            this._okButton.Name = "_okButton";
            this._okButton.ShowFocusRectangle = DevExpress.Utils.DefaultBoolean.False;
            this._okButton.Size = new System.Drawing.Size(117, 33);
            this._okButton.TabIndex = 0;
            this._okButton.Text = "ОК";
            this._okButton.Click += new System.EventHandler(this._okButton_Click);
            // 
            // _cancelButton
            // 
            this._cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._cancelButton.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(126)))), ((int)(((byte)(143)))));
            this._cancelButton.Appearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(122)))), ((int)(((byte)(172)))));
            this._cancelButton.Appearance.ForeColor = System.Drawing.Color.White;
            this._cancelButton.Appearance.Options.UseBackColor = true;
            this._cancelButton.Appearance.Options.UseBorderColor = true;
            this._cancelButton.Appearance.Options.UseForeColor = true;
            this._cancelButton.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this._cancelButton.Location = new System.Drawing.Point(276, 143);
            this._cancelButton.Name = "_cancelButton";
            this._cancelButton.ShowFocusRectangle = DevExpress.Utils.DefaultBoolean.False;
            this._cancelButton.Size = new System.Drawing.Size(117, 33);
            this._cancelButton.TabIndex = 1;
            this._cancelButton.Text = "Отмена";
            this._cancelButton.Click += new System.EventHandler(this._cancelButton_Click);
            // 
            // memoEdit1
            // 
            this.memoEdit1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.memoEdit1.Location = new System.Drawing.Point(4, 4);
            this.memoEdit1.Name = "memoEdit1";
            this.memoEdit1.Size = new System.Drawing.Size(389, 133);
            this.memoEdit1.TabIndex = 2;
            // 
            // EditBoxView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.memoEdit1);
            this.Controls.Add(this._cancelButton);
            this.Controls.Add(this._okButton);
            this.Name = "EditBoxView";
            this.Size = new System.Drawing.Size(396, 179);
            ((System.ComponentModel.ISupportInitialize)(this.memoEdit1.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.FillButton _okButton;
        private Controls.FillButton _cancelButton;
        private DevExpress.XtraEditors.MemoEdit memoEdit1;
    }
}
