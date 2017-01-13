using System;
using System.Collections.Generic;
using System.Windows.Forms;
using CMIOR.UI.WF.Views;

namespace CMIOR.UI.WF.AppModel.Info
{
    public sealed class ViewInfo : BaseInfo, ISupportCommands
    {
        private readonly List<CommandInfo> _commands = new List<CommandInfo>();

        public ViewInfo(BaseInfo owner, string name)
            : base(owner, name)
        {
            Size = TileSize.Wide;
        }

        public ViewType Type { get; set; }

        public string Title { get; set; }

        public string ParentView { get; set; }

        public bool AllowParentView { get; set; } = true;

        public Func<Control> ViewFactory { get; set; }

        public ContainerInfo Container => Owner as ContainerInfo;

        public IEnumerable<CommandInfo> Commands => _commands.AsReadOnly();

        public void AddCommand(CommandInfo command)
        {
            if (command == null)
                throw new ArgumentNullException(nameof(command));
            if (command.Owner != this)
                throw new ArgumentException("Владелец уже назначен");

            _commands.Add(command);
        }
    }
}