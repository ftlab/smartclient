using DevExpress.XtraSplashScreen;
using DevExpress.XtraWaitForm;
using System;
using System.Windows.Forms;

namespace SmartClient.Core.Services.Impl
{
    public sealed class DefaultWaitService : IWaitService
    {
        private sealed class WaitForm : IWaitForm
        {
            public void Dispose()
            {
                SplashScreenManager.CloseForm(false);
            }
            public void SetDescription(string description)
            {
                SplashScreenManager.Default.SetWaitFormDescription(description);
            }
        }

        public IWaitForm Show(string caption, Form parentFom)
        {
            SplashScreenManager.ShowForm(parentFom, typeof(DemoWaitForm), true, true, false);
            SplashScreenManager.Default.SetWaitFormCaption(caption);
            return new WaitForm();
        }
    }
}
