using System;

namespace SmartClient.Core.AppModel.Info
{
    public sealed class QuickButtonViewInfo : BaseInfo
    {
        public QuickButtonViewInfo(string name)
            : base(null, name)
        {
        }

        public Action Click { get; set; }
    }
}
