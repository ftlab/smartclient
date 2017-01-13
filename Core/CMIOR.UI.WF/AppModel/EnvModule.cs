using System;
using System.Collections.Generic;
using System.Linq;
using CMIOR.UI.WF.AppModel.Builder;
using CMIOR.UI.WF.AppModel.Info;
using CMIOR.UI.WF.Forms;
using CMIOR.UI.WF.Messages;
using CMIOR.UI.WF.Properties;
using CMIOR.UI.WF.Views.Custom;
using DevExpress.XtraBars.Docking2010;
using DevExpress.XtraBars.Docking2010.Views.WindowsUI;
using CMIOR.UI.WF.Container;
using Microsoft.Practices.Unity;
using DevExpress.XtraBars;
using CMIOR.WCF.Executors;
using CMIOR.CommonContracts.ServiceContracts;
using CMIOR.CommonContracts.DataModel;
using CMIOR.Unity;

namespace CMIOR.UI.WF.AppModel
{
    public class EnvModule : BaseModule, IEnvModule
    {
        private readonly List<ModuleInfo> _registeredModules = new List<ModuleInfo>();

        private DocumentManager _documentManager;

        private TileContainer _mainContainer;

        private WindowsUIView _view;

        public override ModuleInfo GetInfo()
        {
            var builder = new ModuleInfoBuilder();
            builder.New("Environment", x => { x.Caption = "Модуль окружения"; })
                .AddCommand("Close", x =>
                {
                    x.Caption = "Выход";
                    x.Action = (y) => { App.Instance.MainForm.Instance.Close(); };
                    x.Image = Resources.cross108;
                    x.GroupName = "System";
                })
                .AddCommand(nameof(AboutView), x =>
                {
                    x.Caption = "Инфо";
                    x.Action = (y) =>
                    {
                        using (var about = new AboutView())
                        {
                            FlyoutForm.ShowPopup(new FlyoutAction(), about);
                        }
                    };
                    x.Image = Resources.icon512;
                    x.GroupName = "System";
                })
                .AddView(nameof(UserSettingsView), x =>
                {
                    x.Caption = "Реестр";
                    x.ViewFactory = () => new UserSettingsView();
                    x.Size = TileSize.Small;
                    x.Image = Resources.settings;
                    x.GroupName = "System";
                })
                .AddView(nameof(SkinSelector), x =>
                {
                    x.Caption = "Выбрать тему";
                    x.ViewFactory = () => new SkinSelector();
                    x.Size = TileSize.Small;
                    x.Image = Resources.theme;
                    x.GroupName = "System";
                })
                .AddQuickButton(() =>
                {
                    return new QuickButtonViewInfo[]
                    {
                        new QuickButtonViewInfo("UserInfo")
                        {
                            Image = Resources.customer_32x32,
                            Caption = GetUserCaption(),
                        },
                        new QuickButtonViewInfo("DualWcf")
                        {
                            Image = Resources.green_circle,
                            Caption = null,
                        }
                    };
                });

            return builder.Module;
        }

        public void CustomizeForm(IMainForm form)
        {
            _view = form.WindowsUiView;
            _mainContainer = form.MainContainer;
            _documentManager = form.DocumentManager;
        }

        /// <summary>
        ///     Регистрация модуля
        /// </summary>
        /// <param name="module"></param>
        public void RegisterModule(ModuleInfo module)
        {
            _registeredModules.Add(module);
        }

        /// <summary>
        ///     Уведомление о начале инициализации модуля
        /// </summary>
        public override void OnBeforeInit()
        {
            base.OnBeforeInit();

            ServiceContainer.Default.NotificationService.Subscribe<GoToHomeEvent>(OnGoToHomeEvent);
            ServiceContainer.Default.NotificationService.Subscribe<GoBackEvent>(OnGoBackEvent);
            ServiceContainer.Default.NotificationService.Subscribe<NavigateToViewEvent>(OnNavigateToViewEvent);
            ServiceContainer.Default.NotificationService.Subscribe<IncomingMessageEvent>(OnIncomingMessageEvent);
            ServiceContainer.Default.NotificationService.Subscribe<DualWcfMessageEvent>(OnDualWcfMessageEvent);
        }

        private string GetUserCaption()
        {
#if DEBUG
            return Environment.UserName;
#endif
            Employee employee = null;

            try
            {
                using (var exec = new ServiceExecutor<IArmConfigService>("ArmConfigService"))
                    employee = exec.Execute(x => x.GetMyAccount());
            }
            catch (Exception e)
            {
                Log.WriteError(e);
                employee = new Employee() { FullName = "Субъект учета не найден" };
            }

            if (employee != null) return $"{Environment.UserName} [{employee.FullName}]";
            return Environment.UserName;
        }

        #region event handlers

        private void OnIncomingMessageEvent(IncomingMessageEvent notification)
        {
            var ribbon = App.Instance.Resolve<IMainForm>().RibbonControl;
            foreach (BarItemLink itemLink in ribbon.Toolbar.ItemLinks)
            {
                var info = itemLink.Item.Tag as QuickButtonViewInfo;
                if (info != null && info.Name == "IncomingMail")
                {
                    itemLink.Item.Caption = notification.Count.ToString();
                    break;
                }
            }
        }
        private void OnDualWcfMessageEvent(DualWcfMessageEvent notification)
        {
            var ribbon = App.Instance.Resolve<IMainForm>().RibbonControl;
            foreach (BarItemLink itemLink in ribbon.Toolbar.ItemLinks)
            {
                var info = itemLink.Item.Tag as QuickButtonViewInfo;
                if (info != null && info.Name == "DualWcf")
                {
                    itemLink.Item.Glyph = notification.Enabled ? Resources.green_circle : Resources.red_circle;
                    break;
                }
            }
        }


        private void OnGoToHomeEvent(GoToHomeEvent notification)
        {
            if (_view.ActiveFlyoutContainer != null)
                _view.HideFlyout();

            _view.ActivateContainer(_mainContainer);
        }


        private void OnGoBackEvent(GoBackEvent notification)
        {
            if (_view.ActiveFlyoutContainer != null)
                _view.HideFlyout();

            _view.ActivateContainer(_view.ActiveContentContainer.Parent);
        }


        private void OnNavigateToViewEvent(NavigateToViewEvent notification)
        {
            var module = _registeredModules
                .FirstOrDefault(x => x.Name == notification.ModuleName);
            if (module == null)
                throw new NullReferenceException("Модуль не найден");

            var view = module.Views.FirstOrDefault(x => x.Name == notification.ViewName);
            if (view == null)
                throw new NullReferenceException("Представление не найдено");

            var container = _view.ContentContainers.FirstOrDefault(x => x.Tag != null && x.Tag.Equals(view));
            if (container == null)
                throw new NullReferenceException("Контейнер не найден");

            var newParent = _view.ActiveContentContainer;
            if (newParent != null && view.AllowParentView)
            {
                var parentInfo = newParent.Tag as ViewInfo;
                if (parentInfo != null && parentInfo.AllowParentView)
                    container.Parent = newParent;
            }

            if (string.IsNullOrEmpty(notification.NewCaption) == false)
                container.Caption = notification.NewCaption;

            _view.ActivateContainer(container);
        }

        #endregion
    }
}