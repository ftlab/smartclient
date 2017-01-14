using System;
using System.Collections.Generic;
using System.Linq;
using SmartClient.Core.AppModel.Builder;
using SmartClient.Core.AppModel.Info;
using SmartClient.Core.Forms;
using SmartClient.Core.Messages;
using SmartClient.Core.Properties;
using SmartClient.Core.Views.Custom;
using DevExpress.XtraBars.Docking2010;
using DevExpress.XtraBars.Docking2010.Views.WindowsUI;
using SmartClient.Core.Container;
using Microsoft.Practices.Unity;
using DevExpress.XtraBars;
using SmartClient.Core.Controls.Bars;

namespace SmartClient.Core.AppModel
{
    public class EnvModule : BaseModule, IEnvModule
    {
        private readonly List<ModuleInfo> _registeredModules = new List<ModuleInfo>();

        private DocumentManager _documentManager;

        private TileContainer _mainContainer;

        private WindowsUIView _view;

        private AppBar _appBar;

        private readonly List<LinkedList<IContentContainer>> _nav = new List<LinkedList<IContentContainer>>();

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
            _appBar = form.AppBar;
            _appBar.AppBarItemClick += _appBar_AppBarItemClick;
            _view.ContentContainerActivated += _view_ContentContainerActivated;
        }

        private void _view_ContentContainerActivated(object sender, ContentContainerEventArgs e)
        {
            var curr = e.ContentContainer;
            var list = new LinkedList<IContentContainer>();
            while (curr != null && curr != _mainContainer)
            {
                list.AddFirst(curr);
                curr = curr.Parent;
            }
            if (list.Count > 0)
            {
                var node = _nav.FirstOrDefault(x => x.First.Value == list.First.Value);
                if (node != null)
                    _nav.Remove(node);
                _nav.Add(list);
            }
        }

        private void _appBar_AppBarItemClick(object sender, AppBarItemClickEventArgs e)
        {
            if (e.Item != null)
            {
                var container = e.Item.Data as BaseContentContainer;
                if (container != null)
                {
                    var node = _nav.FirstOrDefault(x => x.First.Value == container);
                    if (node != null)
                        _view.ActivateContainer(node.Last.Value);
                    else
                        _view.ActivateContainer(container);
                }
            }
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
        }

        private string GetUserCaption()
        {
            return Environment.UserName;
        }

        #region event handlers

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