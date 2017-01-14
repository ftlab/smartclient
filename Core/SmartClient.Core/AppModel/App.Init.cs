using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using SmartClient.Core.AppModel.Info;
using SmartClient.Core.Controls;
using SmartClient.Core.Forms;
using SmartClient.Core.Views.Custom;
using DevExpress.XtraBars.Docking2010.Views;
using DevExpress.XtraBars.Docking2010.Views.WindowsUI;
using Microsoft.Practices.Unity;
using ViewType = SmartClient.Core.AppModel.Info.ViewType;
using SmartClient.Core.Container;
using DevExpress.XtraBars;
using System.Collections.Generic;
using Common.Logging;
using SmartClient.Core.Controls.Bars;

namespace SmartClient.Core.AppModel
{
    public partial class App
    {
        private InitializationContext _context;

        public List<IModule> Modules { get; } = new List<IModule>();

        partial void Init()
        {
            var form = this.Resolve<IMainForm>();
            form.WindowsUiView.QueryControl += WindowsUiView_QueryControl;
            form.WindowsUiView.NavigatedFrom += WindowsUiView_NavigatedFrom;
            form.WindowsUiView.NavigatedTo += WindowsUiView_NavigatedTo;

            var repository = this.Resolve<IModuleRepository>();
            var mainModule = this.Resolve<IEnvModule>();
            var modules = repository.GetModules();

            mainModule.CustomizeForm(form);

            _context = new InitializationContext();
            _context.MainModule = mainModule;

            foreach (var module in new[] { mainModule }.Union(modules))
            {
                try
                {
                    _context.CurrentModuleInfo = module.GetInfo();
                    _context.CurrentModule = module;
                    Log.WriteInfo($"Init module: {module} start");

                    module.OnBeforeInit();
                    InitModule(module);
                    module.OnAfterInit();
                    Modules.Add(module);

                    Log.WriteInfo($"Init module: {module} end");
                }
                catch (Exception exception)
                {
                    Log.WriteError(exception);
                    ServiceContainer.Default.MessageService
                        .ShowError($"Ошибка при инициализации модуля {module.GetType().Name}. Подробности в журнале событий.");
                }
            }

            _context = null;
        }

        private void WindowsUiView_NavigatedTo(object sender, NavigationEventArgs e)
        {
            var page = e.Target as Page;
            if (page != null && page.Document != null && page.Document.Control != null)
                page.Document.Control.Enabled = true;
        }

        private void WindowsUiView_NavigatedFrom(object sender, NavigationEventArgs e)
        {
            var page = e.Source as Page;
            if (page != null && page.Document != null && page.Document.Control != null)
                page.Document.Control.Enabled = false;
        }

        private void WindowsUiView_QueryControl(object sender, QueryControlEventArgs e)
        {
            var view = e.Document.Tag as ViewInfo;
            if (view != null)
            {
                try
                {
                    e.Control = view.ViewFactory?.Invoke() ?? new ViewNotFoundView();
                }
                catch (Exception exception)
                {
                    ServiceContainer.Default.MessageService.ShowError(exception.ToString(), "Ошибка");
                    e.Control = new ViewNotFoundView();
                }

                return;
            }

            e.Control = new ViewNotFoundView();
        }

        private void InitModule(IModule module)
        {
            var info = _context.CurrentModuleInfo;
            if (info == null) throw new NullReferenceException(nameof(info));
            _context.MainModule.RegisterModule(info);

            foreach (var view in info.Views)
            {
                module.OnBeforeInitModuleView(view);
                InitModuleView(view);
                module.OnAfterInitModuleView(view);
            }
            foreach (var container in info.Containers)
            {
                module.OnBeforeInitContainer(container);
                InitContainer(container);
                module.OnAfterInitContainer(container);
            }
            foreach (var command in info.Commands)
            {
                module.OnBeforeInitModuleCommand(command);
                InitModuleCommand(command);
                module.OnAfterInitModuleCommand(command);
            }
            foreach (var quickButton in info.QuickButtons)
            {
                InitQuickButton(quickButton);
            }
        }

        private void InitModuleView(ViewInfo view)
        {
            var form = this.Resolve<IMainForm>();
            var ui = form.WindowsUiView;

            var document = new Document();
            document.Tag = view;
            var tile = new Tile();
            if (string.IsNullOrEmpty(view.GroupName) == false)
                tile.Group = view.GroupName;

            ui.Documents.Add(document);
            ui.Tiles.Add(tile);
            form.MainContainer.Items.Add(tile);

            tile.Visible = view.ShowInTileContainer;
            tile.Document = document;
            document.Caption = view.Title ?? view.Caption;

            if (view.Size == TileSize.Small)
                TileCustomizer.CustomiseSmallTile(tile, view.Caption, view.Image ?? Properties.Resources.view);
            else if (view.Size == TileSize.Medium)
                TileCustomizer.CustomizeMediumTile(tile, view.Caption, view.Image ?? Properties.Resources.view);
            else if (view.Size == TileSize.Wide)
                TileCustomizer.CustomizeWideTile(tile, view.Caption, view.Image ?? Properties.Resources.view);
            else throw new NotSupportedException("Размер не поддерживается");

            tile.Appearances.Normal.BackColor = Color.FromArgb(91, 122, 172);
            tile.Appearances.Normal.BorderColor = Color.FromArgb(91, 122, 172);
            tile.Appearances.Hovered.BackColor = Color.FromArgb(247, 138, 9);
            tile.Appearances.Hovered.BorderColor = Color.FromArgb(247, 138, 9);

            BaseContentContainer container;
            if (view.Type == ViewType.Flyout)
            {
                var flyout = new Flyout();
                container = flyout;
                flyout.Tag = view;
                flyout.Caption = view.Title ?? view.Caption;
                ui.ContentContainers.Add(flyout);

                flyout.Document = document;
                flyout.FlyoutButtons = MessageBoxButtons.OK;
                flyout.Parent = form.MainContainer;

                tile.ActivationTarget = flyout;

                _context.CurrentModule.CustomizeModuleFlyoutView(view, tile, flyout);
            }
            else if (view.Type == ViewType.Page)
            {
                var page = new Page();
                container = page;
                page.Tag = view;
                page.Caption = view.Title ?? view.Caption;
                ui.ContentContainers.Add(page);

                page.Document = document;
                if (view.AllowParentView)
                    page.Parent = form.MainContainer;

                tile.ActivationTarget = page;

                _context.CurrentModule.CustomizeModulePageView(view, tile, page);
            }
            else throw new NotSupportedException("Тип представления не поддержиавется");

            if (string.IsNullOrEmpty(view.ParentView) == false)
            {
                var parentContainer = ui.ContentContainers
                    .Where(x =>
                    {
                        var cview = x.Tag as ViewInfo;
                        if (cview == null)
                            return false;
                        return cview.Module.Name == view.Module.Name && cview.Name == view.ParentView;
                    })
                    .FirstOrDefault();

                if (parentContainer != null)
                {
                    container.Parent = parentContainer;
                }
            }

            var barItem = new AppBarItem();
            barItem.Name = view.Name;
            barItem.Caption = view.Caption;
            barItem.Decription = view.Caption;
            barItem.Image = view.Image;
            barItem.Data = document;

            form.AppBar.AddItem(barItem);
        }

        private void InitContainer(ContainerInfo container)
        {
            var form = this.Resolve<IMainForm>();

            DocumentGroup group;
            if (container.Type == ContainerType.PageGroup)
                group = new PageGroup();
            else if (container.Type == ContainerType.SlideGroup)
                group = new SlideGroup();
            else if (container.Type == ContainerType.SplitGroup)
                group = new SplitGroup();
            else if (container.Type == ContainerType.TabbedGroup)
            {
                var tabGroup = new TabbedGroup();
                tabGroup.Properties.HeaderStyle = HeaderStyle.Tile;
                group = tabGroup;
            }
            else throw new NotSupportedException("Тип контейнера не поддерживается");

            form.WindowsUiView.ContentContainers.Add(group);
            group.Parent = form.MainContainer;
            group.Name = container.Name;
            group.Caption = container.Caption;

            foreach (var viewInfo in container.Views)
            {
                var document = new Document();
                form.WindowsUiView.Documents.Add(document);
                document.Caption = viewInfo.Caption;
                document.Tag = viewInfo;

                group.Items.Add(document);
            }

            var tile = new Tile();
            tile.ActivationTarget = group;
            if (container.Size == TileSize.Small)
                TileCustomizer.CustomiseSmallTile(tile, container.Caption, container.Image ?? Properties.Resources.container);
            else if (container.Size == TileSize.Medium)
                TileCustomizer.CustomizeMediumTile(tile, container.Caption, container.Image ?? Properties.Resources.container);
            else if (container.Size == TileSize.Wide)
                TileCustomizer.CustomizeWideTile(tile, container.Caption, container.Image ?? Properties.Resources.container);
            else throw new NotSupportedException("Размер не поддерживается");

            tile.Appearances.Normal.BackColor = Color.FromArgb(133, 120, 181);
            tile.Appearances.Normal.BorderColor = Color.FromArgb(133, 120, 181);
            tile.Appearances.Hovered.BackColor = Color.FromArgb(247, 138, 9);
            tile.Appearances.Hovered.BorderColor = Color.FromArgb(247, 138, 9);

            form.MainContainer.Items.Add(tile);
            form.WindowsUiView.Tiles.Add(tile);

            _context.CurrentModule.CustomizeContainer(container, tile, group);
        }

        private void InitModuleCommand(CommandInfo command)
        {
            var form = this.Resolve<IMainForm>();
            var tile = new Tile();
            if (string.IsNullOrEmpty(command.GroupName) == false)
                tile.Group = command.GroupName;

            if (command.Size == TileSize.Small)
                TileCustomizer.CustomiseSmallTile(tile, command.Caption, command.Image ?? Properties.Resources.command);
            else if (command.Size == TileSize.Medium)
                TileCustomizer.CustomizeMediumTile(tile, command.Caption, command.Image ?? Properties.Resources.command);
            else if (command.Size == TileSize.Wide)
                TileCustomizer.CustomizeWideTile(tile, command.Caption, command.Image ?? Properties.Resources.command);
            else throw new NotSupportedException("Размер не поддерживается");

            tile.Appearances.Normal.BackColor = Color.FromArgb(75, 164, 159);
            tile.Appearances.Normal.BorderColor = Color.FromArgb(75, 164, 159);
            tile.Appearances.Hovered.BackColor = Color.FromArgb(247, 138, 9);
            tile.Appearances.Hovered.BorderColor = Color.FromArgb(247, 138, 9);

            tile.Click += (sender, arg) => { command.Execute(); };
            form.MainContainer.Items.Add(tile);
            form.WindowsUiView.Tiles.Add(tile);

            _context.CurrentModule.CustomizeModuleCommand(command, tile);
        }

        private void InitQuickButton(QuickButtonViewInfo viewInfo)
        {
            var ribbon = this.Resolve<IMainForm>().RibbonControl;

            BarItemPaintStyle paintStyle = viewInfo.Click == null ? BarItemPaintStyle.Caption : BarItemPaintStyle.CaptionGlyph;
            var barItem = new BarStaticItem()
            {
                Caption = viewInfo.Caption,
                Glyph = viewInfo.Image,
                PaintStyle = paintStyle,
                Tag = viewInfo
            };
            ribbon.Toolbar.ItemLinks.Add(barItem);
        }

        partial void DeInit()
        {
            foreach (var module in Modules)
            {
                try
                {
                    module.OnDeInit();
                }
                catch (Exception exception)
                {
                    Log.WriteWarning(exception.ToString());
                }
            }

            Modules.Clear();
        }

        partial void Start()
        {
            var repository = this.Resolve<IModuleRepository>();

            var moduleSettings = repository.GetConfig();

            foreach (var module in Modules)
            {
                var info = moduleSettings.FirstOrDefault(x => x.AssemblyName == module.GetType().Assembly.GetName().Name);
                Log.WriteInfo($"autostart module {module} begin");
                if (info != null && info.AutoStart)
                    module.OnAutoStart();
                Log.WriteInfo($"autostart module {module} end");
            }
        }

        private class InitializationContext
        {
            public IModule CurrentModule;

            public ModuleInfo CurrentModuleInfo;

            public IEnvModule MainModule;
        }
    }
}