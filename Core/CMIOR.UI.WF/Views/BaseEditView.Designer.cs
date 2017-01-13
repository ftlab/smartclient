namespace CMIOR.UI.WF.Views
{
    partial class BaseEditView
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
            this._okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this._okButton.Location = new System.Drawing.Point(266, 292);
            this._okButton.Name = "_okButton";
            this._okButton.ShowFocusRectangle = DevExpress.Utils.DefaultBoolean.False;
            this._okButton.Size = new System.Drawing.Size(117, 33);
            this._okButton.TabIndex = 8;
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
            this._cancelButton.CausesValidation = false;
            this._cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this._cancelButton.Location = new System.Drawing.Point(389, 292);
            this._cancelButton.Name = "_cancelButton";
            this._cancelButton.ShowFocusRectangle = DevExpress.Utils.DefaultBoolean.False;
            this._cancelButton.Size = new System.Drawing.Size(117, 33);
            this._cancelButton.TabIndex = 9;
            this._cancelButton.Text = "Отмена";
            this._cancelButton.Click += new System.EventHandler(this._cancelButton_Click);
            // 
            // BaseEditView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this._cancelButton);
            this.Controls.Add(this._okButton);
            this.Name = "BaseEditView";
            this.Size = new System.Drawing.Size(509, 328);
            this.ResumeLayout(false);

        }

        #endregion

        protected UI.WF.Controls.FillButton _okButton;
        protected UI.WF.Controls.FillButton _cancelButton;
    }
}
