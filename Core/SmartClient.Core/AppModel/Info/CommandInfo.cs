using System;

namespace SmartClient.Core.AppModel.Info
{
    public sealed class CommandInfo : BaseInfo
    {
        public CommandInfo(BaseInfo owner, string name)
            : base(owner, name)
        {
            if (owner == null)
                throw new ArgumentNullException(nameof(owner));

            Size = TileSize.Small;
        }

        public ViewInfo View => Owner as ViewInfo;

        public Action<CommandInfo> Action { get; set; }

        public Predicate<CommandInfo> CanExecute { get; set; }

        public void Execute()
        {
            if (Action == null)
                return;

            var canExecute = true;

            if (CanExecute != null)
                canExecute = CanExecute(this);

            if (canExecute)
                Action(this);
        }
    }
}