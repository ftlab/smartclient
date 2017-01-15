using System;
using System.Drawing;

namespace SmartClient.Core.AppModel.Info
{
    public abstract class BaseInfo
    {
        protected BaseInfo(BaseInfo owner, string name)
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentNullException(nameof(name));

            Owner = owner;
            Name = name;
            ShowInTileContainer = true;
        }

        public string GroupName { get; set; }

        public string Name { get; }

        public string Caption { get; set; }

        public string Description { get; set; }

        public Bitmap Image { get; set; }

        public TileSize Size { get; set; }

        public BaseInfo Owner { get; }

        public bool ShowInTileContainer { get; set; }

        public bool ShowInAppBar { get; set; } = true;

        public ModuleInfo Module
        {
            get
            {
                var owner = Owner;
                while (owner != null && owner is ModuleInfo == false)
                {
                    owner = owner.Owner;
                }

                return (ModuleInfo)owner;
            }
        }
    }
}