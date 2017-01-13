using System.Collections.Generic;

namespace CMIOR.UI.WF.AppModel.Info
{
    public interface ISupportViews
    {
        IEnumerable<ViewInfo> Views { get; }

        void AddView(ViewInfo view);
    }
}