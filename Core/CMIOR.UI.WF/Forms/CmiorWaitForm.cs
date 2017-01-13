using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraWaitForm;
using DevExpress.Skins;
using DevExpress.LookAndFeel;
using CMIOR.UI.WF.Properties;

namespace CMIOR.UI.WF.Forms
{
    public partial class CmiorWaitForm : WaitForm
    {
        public CmiorWaitForm()
        {
            ShowOnTopMode = ShowFormOnTopMode.AboveAll;            
            ChangeLoadingPicture();

            InitializeComponent();
            this.progressPanel1.AutoHeight = true;           
        }


        private void ChangeLoadingPicture()
        {
            Skin commonSkin = CommonSkins.GetSkin(UserLookAndFeel.Default.ActiveLookAndFeel);
            SkinElement loadingBig = commonSkin["LoadingBig"];
            loadingBig.Image.SetImage(Resources.w8loader, Color.Empty);
        }

        #region Overrides

        public override void SetCaption(string caption)
        {
            base.SetCaption(caption);
            this.progressPanel1.Caption = caption;
        }
        public override void SetDescription(string description)
        {
            base.SetDescription(description);
            this.progressPanel1.Description = description;
        }
        public override void ProcessCommand(Enum cmd, object arg)
        {
            base.ProcessCommand(cmd, arg);
        }

        #endregion

        public enum WaitFormCommand
        {
        }
    }
}