using System;
using System.Windows.Forms;
using AnimatorNS;
using DevExpress.XtraSplashScreen;

namespace SmartClient.Core.Forms
{
    public partial class SmartSplashScreen : SplashScreen
    {
        public SmartSplashScreen()
        {
            InitializeComponent();

            animator1.DefaultAnimation = Animation.ScaleAndHorizSlide;
            animator1.TimeStep = 0.015f;
        }

        #region Overrides

        public override void ProcessCommand(Enum cmd, object arg)
        {
            base.ProcessCommand(cmd, arg);
        }

        #endregion

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            ShowControls();
        }

        //show control(s)
        private void ShowControls()
        {
            foreach (Control control in panelControl1.Controls)
            {
                if (control.Visible == false)
                {
                    animator1.Show(control);
                }
            }

            //wait while all animations will be completed
            animator1.WaitAllAnimations();
        }
    }
}