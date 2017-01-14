using System;
using DevExpress.XtraBars.Navigation;
using DevExpress.XtraEditors;
using DevExpress.Utils;
using System.Linq;
using System.ComponentModel;
using System.Drawing;

namespace SmartClient.Core.Controls.Bars
{
    public partial class AppBar : TileBar
    {
        public ImageCollection imageCollection1;
        private IContainer components;
        public TileBarItem mainItem;
        public FlyoutPanel flyoutPanel1;
        public FlyoutPanelControl flyoutPanelControl1;
        public AppBarPanel appBarPanel1;
        public TileBarGroup mainGroup;
        private readonly BindingList<AppBarItem> _items = new BindingList<AppBarItem>();

        public AppBar()
        {
            InitializeComponent();
        }

        public event EventHandler<AppBarItemClickEventArgs> AppBarItemClick;

        public FlyoutPanel FlyoutPanel => flyoutPanel1;

        internal BindingList<AppBarItem> Items => _items;

        private void AppBarItemClickCore(AppBarItem item)
        {
            AppBarItemClick?.Invoke(this, new AppBarItemClickEventArgs(item));
        }

        private void InitializeComponent()
        {
            DevExpress.XtraEditors.TileItemElement tileItemElement1 = new DevExpress.XtraEditors.TileItemElement();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AppBar));
            this.mainGroup = new DevExpress.XtraBars.Navigation.TileBarGroup();
            this.mainItem = new DevExpress.XtraBars.Navigation.TileBarItem();
            this.imageCollection1 = new DevExpress.Utils.ImageCollection();
            this.flyoutPanel1 = new DevExpress.Utils.FlyoutPanel();
            this.flyoutPanelControl1 = new DevExpress.Utils.FlyoutPanelControl();
            this.appBarPanel1 = new AppBarPanel();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.flyoutPanel1)).BeginInit();
            this.flyoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.flyoutPanelControl1)).BeginInit();
            this.flyoutPanelControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainGroup
            // 
            this.mainGroup.Items.Add(this.mainItem);
            this.mainGroup.Name = "mainGroup";
            // 
            // mainItem
            // 
            this.mainItem.DropDownOptions.BeakColor = System.Drawing.Color.Empty;
            tileItemElement1.ImageAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleCenter;
            tileItemElement1.ImageIndex = 0;
            tileItemElement1.Text = "";
            this.mainItem.Elements.Add(tileItemElement1);
            this.mainItem.Id = 0;
            this.mainItem.ItemSize = DevExpress.XtraBars.Navigation.TileBarItemSize.Medium;
            this.mainItem.Name = "mainItem";
            // 
            // imageCollection1
            // 
            this.imageCollection1.ImageSize = new System.Drawing.Size(24, 24);
            this.imageCollection1.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imageCollection1.ImageStream")));
            this.imageCollection1.Images.SetKeyName(0, "menu.png");
            // 
            // flyoutPanel1
            // 
            this.flyoutPanel1.Controls.Add(this.flyoutPanelControl1);
            this.flyoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flyoutPanel1.Name = "flyoutPanel1";
            this.flyoutPanel1.Options.AnchorType = DevExpress.Utils.Win.PopupToolWindowAnchor.TopLeft;
            this.flyoutPanel1.Options.CloseOnOuterClick = true;
            this.flyoutPanel1.Size = new System.Drawing.Size(700, 600);
            this.flyoutPanel1.TabIndex = 0;
            // 
            // flyoutPanelControl1
            // 
            this.flyoutPanelControl1.Controls.Add(this.appBarPanel1);
            this.flyoutPanelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flyoutPanelControl1.FlyoutPanel = this.flyoutPanel1;
            this.flyoutPanelControl1.Location = new System.Drawing.Point(0, 0);
            this.flyoutPanelControl1.Name = "flyoutPanelControl1";
            this.flyoutPanelControl1.Size = new System.Drawing.Size(700, 600);
            this.flyoutPanelControl1.TabIndex = 0;
            // 
            // appBarPanel1
            // 
            this.appBarPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.appBarPanel1.Location = new System.Drawing.Point(2, 2);
            this.appBarPanel1.Name = "appBarPanel1";
            this.appBarPanel1.Size = new System.Drawing.Size(696, 596);
            this.appBarPanel1.TabIndex = 0;
            this.appBarPanel1.ItemClick += new System.EventHandler(this.appBarPanel1_ItemClick);
            // 
            // AppBar
            // 
            this.AllowSelectedItem = true;
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Dock = System.Windows.Forms.DockStyle.Left;
            this.DropDownOptions.BeakColor = System.Drawing.Color.Empty;
            this.Groups.Add(this.mainGroup);
            this.GroupTextToItemsIndent = 0;
            this.HorizontalContentAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.Images = this.imageCollection1;
            this.IndentBetweenGroups = 0;
            this.IndentBetweenItems = 0;
            this.ItemImageAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleCenter;
            this.ItemPadding = new System.Windows.Forms.Padding(0);
            this.ItemSize = 32;
            this.ItemTextShowMode = DevExpress.XtraEditors.TileItemContentShowMode.Always;
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.Padding = new System.Windows.Forms.Padding(0);
            this.SelectionColorMode = DevExpress.XtraBars.Navigation.SelectionColorMode.UseItemBackColor;
            this.ShowGroupText = false;
            this.Size = new System.Drawing.Size(33, 482);
            this.VerticalContentAlignment = DevExpress.Utils.VertAlignment.Top;
            this.ItemClick += new DevExpress.XtraEditors.TileItemClickEventHandler(this.AppBar_ItemClick);
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.flyoutPanel1)).EndInit();
            this.flyoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.flyoutPanelControl1)).EndInit();
            this.flyoutPanelControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        private void MainItem_ItemClick()
        {
            if (appBarPanel1.GetAppBar() == null)
                appBarPanel1.SetAppBar(this);

            flyoutPanel1.ShowPopup();
        }

        public AppBar AddItem(AppBarItem item)
        {
            if (item == null) throw new ArgumentNullException(nameof(item));
            if (_items.Any(x => x.Name == item.Name)) throw new ArgumentException(nameof(item));
            _items.Add(item);

            if (item.Image == null)
                item.Image = Properties.Resources.tile;

            if (AppBarSettings.IsPinned(item.Name))
                AddOrGetItem(item.Name);

            return this;
        }

        private TileBarItem AddOrGetItem(string name)
        {
            var tileItem = mainGroup.Items[name];
            if (tileItem != null) return (TileBarItem)tileItem;

            var item = _items.SingleOrDefault(x => x.Name == name);
            if (item == null) throw new NullReferenceException(nameof(item));

            var barItem = new TileBarItem();
            mainGroup.Items.Add(barItem);
            barItem.DropDownOptions.BeakColor = System.Drawing.Color.Empty;
            var element = new TileItemElement();
            element.ImageAlignment = TileItemContentAlignment.MiddleCenter;
            element.Image = item.Image;
            element.ImageSize = new System.Drawing.Size(25, 25);
            element.ImageScaleMode = TileItemImageScaleMode.Squeeze;
            element.Text = "";
            barItem.Elements.Add(element);

            barItem.Id = 0;
            barItem.ItemSize = TileBarItemSize.Medium;
            barItem.Name = name;
            barItem.Tag = item;
            barItem.SuperTip = new SuperToolTip();
            barItem.SuperTip.Items.Add(new ToolTipTitleItem() { Text = item.Caption });

            barItem.AppearanceItem.Selected.BackColor = Color.FromArgb(107, 105, 214);

            return barItem;
        }

        public void ActivateItem(string name)
        {
            var barItem = AddOrGetItem(name);

            if (barItem.Elements.Count < 2)
            {
                var active = new TileItemElement();
                active.ImageAlignment = TileItemContentAlignment.MiddleLeft;
                active.Image = Properties.Resources.activetile;
                active.ImageSize = new System.Drawing.Size(32, 32);
                active.ImageScaleMode = TileItemImageScaleMode.Squeeze;
                active.Text = "";
                barItem.Elements.Add(active);
            }
            AppBarSettings.SetLast(name);
            this.SelectedItem = barItem;
        }

        private void appBarPanel1_ItemClick(object sender, EventArgs e)
        {
            flyoutPanel1.HidePopup();
            var item = appBarPanel1.ActiveItem;
            if (item == null) throw new NullReferenceException(nameof(item));
            ActivateItem(item.Name);
            AppBarItemClickCore(item);
        }

        public void SwithPinItem(string name)
        {
            var barItem = AddOrGetItem(name);
            AppBarItem item = (AppBarItem)barItem.Tag;
            if (item.Pinned == false
                && barItem.Elements.Count < 2)
                mainGroup.Items.Remove(barItem);
        }

        private void AppBar_ItemClick(object sender, TileItemEventArgs e)
        {
            if (e.Item == mainItem)
                MainItem_ItemClick();
            else
            {
                var data = e.Item.Tag as AppBarItem;
                if (data != null)
                {
                    ActivateItem(data.Name);
                    AppBarItemClickCore(data);
                }
            }
        }
    }
}
