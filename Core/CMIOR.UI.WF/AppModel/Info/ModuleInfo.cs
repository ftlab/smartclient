using System;
using System.Collections.Generic;
using System.Linq;

namespace CMIOR.UI.WF.AppModel.Info
{
    public sealed class ModuleInfo : BaseInfo, ISupportCommands, ISupportViews
    {
        private readonly List<CommandInfo> _commands = new List<CommandInfo>();

        private readonly List<ContainerInfo> _containers = new List<ContainerInfo>();

        private readonly List<ViewInfo> _views = new List<ViewInfo>();

        private readonly List<QuickButtonViewInfo> _quickButtons = new List<QuickButtonViewInfo>();

        public ModuleInfo(string name)
            : base(null, name)
        {
        }

        public IEnumerable<ContainerInfo> Containers => _containers.AsReadOnly();

        public IEnumerable<BaseInfo> AllItems
        {
            get
            {
                return Views
                    .OfType<BaseInfo>()
                    .Union(Containers)
                    .Union(Commands);
            }
        }

        public IEnumerable<CommandInfo> Commands => _commands.AsReadOnly();

        public void AddCommand(CommandInfo command)
        {
            if (command == null)
                throw new ArgumentNullException(nameof(command));
            if (command.Owner != this)
                throw new ArgumentException("Владелец уже назначен");

            _commands.Add(command);
        }

        public IEnumerable<ViewInfo> Views => _views.AsReadOnly();

        public void AddView(ViewInfo view)
        {
            if (view == null)
                throw new ArgumentNullException(nameof(view));

            if (view.Owner != this)
                throw new ArgumentException("Владелец уже назначен");

            _views.Add(view);
        }

        public ModuleInfo AddContainer(ContainerInfo container)
        {
            if (container == null)
                throw new ArgumentNullException(nameof(container));

            if (container.Owner != this)
                throw new ArgumentException("Владелец уже назначен");

            _containers.Add(container);

            return this;
        }

        public IEnumerable<QuickButtonViewInfo> QuickButtons => _quickButtons;

        public void AddQuickButton(QuickButtonViewInfo[] quickButton)
        {
            _quickButtons.AddRange(quickButton);
        }
    }
}