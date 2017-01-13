using System.Collections.Generic;

namespace CMIOR.UI.WF.AppModel.Info
{
    public interface ISupportCommands
    {
        IEnumerable<CommandInfo> Commands { get; }

        void AddCommand(CommandInfo command);
    }
}