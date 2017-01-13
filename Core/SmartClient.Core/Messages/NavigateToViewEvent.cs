using System.Collections.Generic;

namespace SmartClient.Core.Messages
{
    public class NavigateToViewEvent
    {
        public string ModuleName { get; set; }

        public string ViewName { get; set; }

        public string NewCaption { get; set; }

        public Dictionary<string, object> Args { get; set; }
    }
}