using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using SmartClient.Core.AppModel;
using SmartClient.Core.Forms;
using DevExpress.LookAndFeel;
using DevExpress.Skins;
using DevExpress.UserSkins;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraSplashScreen;
using SmartClient.Core.Container;
using SmartClient.Core.Controls;
using SmartClient.Core.Components;
using Common.Logging;
using System.Configuration;
using Common.Exceptions;

namespace SmartClient
{
    internal static class Program
    {
        private static SplashScreenManager Manager;

        /// <summary>
        ///     The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main(string[] args)
        {
            var command = args != null && args.Length > 0 ? args[0].Trim().ToLower() : null;
            if (command == "/i")
            {
                Install(args);
                return;
            }

            using (var workLock = new WorkLock())
            using (var mut = new Mutex(false, @"Global\SmartClient"))
            {
                if (!mut.WaitOne(1000))
                {
                    Environment.Exit(-1);
                }
                try
                {
                    Program.Manager = new SplashScreenManager(null, typeof(SmartSplashScreen), true, true);

                    Log.WriteInfo("Starting client");

                    Application.ThreadException += UiThreadException;
                    Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
                    AppDomain.CurrentDomain.UnhandledException += CurrentDomainUnhandledException;
                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);
                    Log.WriteInfo("Enable visual styles");

                    ServiceContainer.Default
                        .UseDefaultDialogService()
                        .UseDefaultWaitService()
                        .UseDefaultMessageService()
                        .UseDefaultNotificationService()
                        .UseDefaultHotkeyService()
                        .UseDefaultUserSettingsService();

                    App.Instance
                        .RegistrateMainForm(new MainForm())
                        .RegistrateModuleRepository(new ModuleRepository())
                        .RegistrateEnvModule(new EnvModule());

                    Log.WriteInfo("DI register");

                    ApplySkin();

                    BlockDetector detector = null;
                    App.Instance.Run(() =>
                    {
                        if (Manager.IsSplashFormVisible) Manager.CloseWaitForm();

                        detector = new BlockDetector();
                        detector.UIBlocked += () => SplashScreenManager.ShowForm(App.Instance.MainForm.Instance, typeof(SmartWaitForm));
                        detector.UIReleased += () => SplashScreenManager.CloseForm();
                        detector.Start();
                        Log.WriteInfo("Init ended");
                    }, () =>
                    {
                        if (detector != null) detector.Stop();
                    });

                    App.Instance.Dispose();
                }
                catch (Exception exception)
                {
                    Log.WriteError(exception);
                    if (Manager.IsSplashFormVisible) Manager.CloseWaitForm();
                    App.Instance.Dispose();
                    XtraMessageBox.Show(exception.ToString(), "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private static void ApplySkin()
        {
            string fontName;
            if (ServiceContainer.Default.UserSettingsService.Contains("fontname"))
                fontName = ServiceContainer.Default.UserSettingsService.Get<string>("fontname");
            else
                fontName = ConfigurationManager.AppSettings["fontname"];
            if (string.IsNullOrEmpty(fontName))
                fontName = "Segoe UI";

            string fontSize;
            if (ServiceContainer.Default.UserSettingsService.Contains("fontsize"))
                fontSize = ServiceContainer.Default.UserSettingsService.Get<string>("fontsize");
            else
                fontSize = ConfigurationManager.AppSettings["fontsize"];
            if (string.IsNullOrEmpty(fontSize))
                fontSize = "12";
            AppearanceObject.DefaultFont = new Font(fontName, float.Parse(fontSize));
            Log.WriteInfo("Enable fonts");

            SkinManager.EnableFormSkins();
            BonusSkins.Register();

            string skin;
            if (ServiceContainer.Default.UserSettingsService.Contains("uiskin"))
                skin = ServiceContainer.Default.UserSettingsService.Get<string>("uiskin");
            else
                skin = ConfigurationManager.AppSettings["uiskin"];
            if (string.IsNullOrEmpty(skin))
                skin = "Visual Studio 2013 Blue";
            UserLookAndFeel.Default.SetSkinStyle(skin);
            Log.WriteInfo("Enable skins");
        }

        private static void Install(string[] args)
        {

        }

        private static void UiThreadException(object sender, ThreadExceptionEventArgs t)
        {
            Log.WriteError(t.Exception);

            if (Manager.IsSplashFormVisible)
                Manager.CloseWaitForm();

            if (t.Exception is UserFriendlyException)
                XtraMessageBox.Show(t.Exception.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
#if !DEBUG
                var text = string.Format("Возникла ошибка! Продолжить работу?\r\nПодробности:\r\n{0}", t.Exception.ToString());
                var result = XtraMessageBox.Show(text, "Ошибка", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
#else

                var text = string.Format("Возникла ошибка! За подробностями обратитесь к администратору системы.\r\nПродолжить работу?");
                var result = XtraMessageBox.Show(text, "Ошибка", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
#endif

                if (result == DialogResult.No)
                {
                    Application.Exit();
                    return;
                }

                try
                {
                    var uiView = App.Instance.MainForm.WindowsUiView;
                    uiView.ActivateContainer(uiView.ContentContainers[0]);
                }
                catch (Exception exception)
                {
                    Log.WriteWarning(exception.ToString());
                }
            }
        }

        private static void CurrentDomainUnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            Log.WriteError((Exception)e.ExceptionObject);

            try
            {
                if (Manager.IsSplashFormVisible)
                    Manager.CloseWaitForm();
            }
            catch (Exception ex2)
            {
                Log.WriteWarning(ex2.GetType() + " " + ex2.Message);
            }

            var ex = e.ExceptionObject as Exception;
            XtraMessageBox.Show(ex?.ToString() ?? "CurrentDomainUnhandledException caught", "Ошибка",
                MessageBoxButtons.OK, MessageBoxIcon.Error);

            Application.Exit();
        }
    }
}