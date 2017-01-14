using System;

namespace SmartClient.Core.Controls.Bars
{
    public class AppBarItemClickEventArgs : EventArgs
    {
        public AppBarItemClickEventArgs(AppBarItem item)
        {
            Item = item;
        }

        public AppBarItem Item { get; }
    }
}
