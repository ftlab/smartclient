using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using CMIOR.UI.WF.AppModel;
using CMIOR.UI.WF.Forms;
using CMIOR.UI.WF.Services;
using DevExpress.LookAndFeel;
using DevExpress.Skins;
using DevExpress.UserSkins;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraSplashScreen;
using CMIOR.UI.WF.Services.Impl;
using CMIOR.UI.WF.Container;
using System.Configuration;
using CMIOR.UI.WF.Controls;
using DevExpress.XtraWaitForm;
using CMIOR.Extensions.Exceptions;
using CMIOR.Unity;
using CMIOR.Logging.Writers;
using System.ServiceModel;
using System.ServiceModel.Security;
using CMIOR.Installers;
using CMIOR.Logging.Config;
using System.Linq;
using CMIOR.Logging;
using System.Collections.Generic;
using CMIOR.UI.WF.Components;

namespace CMIOR.SmartClient
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
            using (var mut = new Mutex(false, @"Global\CMIOR.SmartClient"))
            {
                if (!mut.WaitOne(1000))
                {
                    Environment.Exit(-1);
                }
                try
                {
                    Program.Manager = new SplashScreenManager(null, typeof(CmiorSplashScreen), true, true);
#if DEBUG
                    Log.Current.AddWriter(new ConsoleLogWriter());
#endif
                    Log.Current.AddWriter(new EventLogWriter());
                    Log.WriteInfo("Starting client");

                    Application.ThreadException += UiThreadException;
                    Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
                    AppDomain.CurrentDomain.UnhandledException += CurrentDomainUnhandledException;
                    Log.WriteInfo("Subscribe events");

                    Extensions.Utils.ClearTempFolder.Clear();
                    Log.WriteInfo("Clear temp folder");
                    Application.ApplicationExit += (sender, arg) => Extensions.Utils.ClearTempFolder.Clear();
                    Log.WriteInfo("Subscribe ApplicationExit");

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
                        detector.UIBlocked += () => SplashScreenManager.ShowForm(App.Instance.MainForm.Instance, typeof(CmiorWaitForm));
                        detector.UIReleased += () => SplashScreenManager.CloseForm();
                        detector.Start();
                        Log.WriteInfo("Init ended");
                    }, () =>
                    {
                        if (detector != null) detector.Stop();
                    });

                    App.Instance.Dispose();
                }
                catch (FaultException fe)
                {
                    Log.WriteError(fe);

                    string errorMessage;
                    var detail = ((FaultException<ExceptionDetail>)fe).Detail;
                    if (detail?.Type?.Contains(nameof(UserFriendlyException)) == true
                        || detail?.Type?.Contains(nameof(SecurityAccessDeniedException)) == true)
                        errorMessage = fe.Message;
                    else
                        errorMessage = fe.ToString();

                    if (Manager.IsSplashFormVisible) Manager.CloseWaitForm();
                    App.Instance.Dispose();

                    XtraMessageBox.Show(errorMessage, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            var srcSettings = (LogSourcesSection)ConfigurationManager.GetSection("logSources");
            if (srcSettings == null) throw new NullReferenceException(nameof(srcSettings));

            var installer = new EventLogInstaller(BaseLog.LogName
            , srcSettings.LogSources
             .OfType<LogSourceElement>()
             .Select(x => x.Name).ToArray());

            installer.CreateEventSources();
        }

        private static void UiThreadException(object sender, ThreadExceptionEventArgs t)
        {
            Log.WriteError(t.Exception);

            if (Manager.IsSplashFormVisible)
                Manager.CloseWaitForm();

            if (t.Exception is FaultException)
            {
                ExceptionDetail detail = null;
                if (t.Exception.GetType().IsGenericType)
                    detail = ((FaultException<ExceptionDetail>)t.Exception)?.Detail;
                if (((detail?.Type?.Contains(nameof(UserFriendlyException)) == true) || (detail?.Type?.Contains(nameof(SecurityAccessDeniedException)) == true)))
                    XtraMessageBox.Show(((FaultException<ExceptionDetail>)t.Exception)?.Detail?.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
#if DEBUG
                    XtraMessageBox.Show(t.Exception.ToString(), "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
#else
                    XtraMessageBox.Show("Возникло исключение, обратитесь к администратору", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
#endif
            }
            else if (t.Exception is UserFriendlyException || t.Exception is SecurityAccessDeniedException)
                XtraMessageBox.Show(t.Exception.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
#if !DDEBUG
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