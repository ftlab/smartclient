using System;
using System.Collections.Generic;

namespace CMIOR.UI.WF.AppModel.Info
{
    public sealed class ContainerInfo : BaseInfo, ISupportViews
    {
        private readonly List<ViewInfo> _views = new List<ViewInfo>();

        public ContainerInfo(ModuleInfo owner, string name)
            : base(owner, name)
        {
            if (owner == null)
                throw new ArgumentNullException(nameof(owner));

            Size = TileSize.Medium;
        }

        public ContainerType Type { get; set; }

        public IEnumerable<ViewInfo> Views => _views.AsReadOnly();

        public void AddView(ViewInfo view)
        {
            if (view == null)
                throw new ArgumentNullException(nameof(view));
            if (view.Owner != this)
                throw new ArgumentException("Владелец уже назначен");

            _views.Add(view);
        }
    }
}