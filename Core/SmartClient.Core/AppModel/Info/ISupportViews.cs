using System.Collections.Generic;

namespace SmartClient.Core.AppModel.Info
{
    public interface ISupportViews
    {
        IEnumerable<ViewInfo> Views { get; }

        void AddView(ViewInfo view);
    }
}