using System.Collections.Generic;

namespace SmartClient.Core.AppModel.Info
{
    public interface ISupportCommands
    {
        IEnumerable<CommandInfo> Commands { get; }

        void AddCommand(CommandInfo command);
    }
}