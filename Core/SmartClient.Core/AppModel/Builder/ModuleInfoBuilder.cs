using SmartClient.Core.AppModel.Info;
using System;

namespace SmartClient.Core.AppModel.Builder
{
    public class ModuleInfoBuilder
    {
        private CommandInfo _command;

        private CommandOwner _commandOwner = CommandOwner.Module;

        private ContainerInfo _container;

        private ModuleInfo _module;

        private ViewInfo _view;

        private ViewOwner _viewOwner = ViewOwner.Module;

        public ModuleInfo Module
        {
            get { return GetModule(); }
        }

        public ModuleInfoBuilder New(string name, Action<ModuleInfo> configure)
        {
            if (_module != null) throw new InvalidOperationException("Модуль уже создан");

            _module = new ModuleInfo(name);
            configure?.Invoke(_module);

            return this;
        }

        public ModuleInfoBuilder AddCommand(string name, Action<CommandInfo> configure)
        {
            ISupportCommands owner;
            if (_commandOwner == CommandOwner.Module)
                owner = GetModule();
            else if (_commandOwner == CommandOwner.View)
                owner = GetView();
            else throw new NotSupportedException("Добавление команды не поддержиавется");

            _command = new CommandInfo((BaseInfo)owner, name);
            owner.AddCommand(_command);
            configure?.Invoke(_command);

            return this;
        }

        public ModuleInfoBuilder AddContainer(string name, Action<ContainerInfo> configure)
        {
            var module = GetModule();

            _container = new ContainerInfo(module, name);
            _module = module.AddContainer(_container);
            configure?.Invoke(_container);
            _viewOwner = ViewOwner.Container;

            return this;
        }

        public ModuleInfoBuilder AddView(string name, Action<ViewInfo> configure)
        {
            ISupportViews owner;
            if (_viewOwner == ViewOwner.Module)
                owner = GetModule();
            else if (_viewOwner == ViewOwner.Container)
                owner = GetContainer();
            else throw new NotSupportedException("Добавление представления не поддержиавется");

            _view = new ViewInfo((BaseInfo)owner, name);
            owner.AddView(_view);
            configure?.Invoke(_view);
            _commandOwner = CommandOwner.View;

            return this;
        }

        public ModuleInfoBuilder AddQuickButton(Func<QuickButtonViewInfo[]> quickButton)
        {
            var module = GetModule();
            module.AddQuickButton(quickButton());
            return this;
        }

        private ViewInfo GetView()
        {
            if (_view == null)
                throw new NullReferenceException("Представление еще не создано");

            return _view;
        }

        private ContainerInfo GetContainer()
        {
            if (_container == null)
                throw new NullReferenceException("Контейнер еще не создан");

            return _container;
        }

        private ModuleInfo GetModule()
        {
            if (_module == null)
                throw new NullReferenceException("Модуль еще не создан");

            return _module;
        }

        private enum CommandOwner
        {
            Module,
            View
        }

        private enum ViewOwner
        {
            Module,
            Container
        }
    }
}