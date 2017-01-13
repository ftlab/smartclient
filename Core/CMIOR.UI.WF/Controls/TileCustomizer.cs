using System.Drawing;
using CMIOR.UI.WF.Properties;
using DevExpress.Utils;
using DevExpress.XtraBars.Docking2010.Views.WindowsUI;
using DevExpress.XtraEditors;

namespace CMIOR.UI.WF.Controls
{
    public static class TileCustomizer
    {
        public static void CustomiseSmallTile(Tile tile, string caption, Image image)
        {
            tile.Properties.AllowHtmlDraw = DevExpress.Utils.DefaultBoolean.True;
            tile.Properties.ItemSize = DevExpress.XtraEditors.TileItemSize.Small;

            var tileItemElement1 = new TileItemElement();

            tileItemElement1.Appearance.Normal.Font = new System.Drawing.Font("Segoe UI Light", 8F);
            tileItemElement1.Appearance.Normal.Options.UseFont = true;
            tileItemElement1.Image = image;
            tileItemElement1.ImageAlignment = DevExpress.XtraEditors.TileItemContentAlignment.TopRight;
            tileItemElement1.ImageScaleMode = DevExpress.XtraEditors.TileItemImageScaleMode.Stretch;
            tileItemElement1.ImageSize = new System.Drawing.Size(40, 40);
            tileItemElement1.ImageToTextAlignment = DevExpress.XtraEditors.TileControlImageToTextAlignment.None;
            tileItemElement1.Text = caption;
            tileItemElement1.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.BottomLeft;

            tile.Elements.Add(tileItemElement1);
        }

        public static void CustomizeMediumTile(Tile tile, string caption, Image image)
        {
            tile.Properties.AllowHtmlDraw = DevExpress.Utils.DefaultBoolean.True;
            tile.Properties.ItemSize = DevExpress.XtraEditors.TileItemSize.Medium;

            var tileItemElement1 = new TileItemElement();

            tileItemElement1.Appearance.Normal.Font = new System.Drawing.Font("Segoe UI Light", 14F);
            tileItemElement1.Appearance.Normal.Options.UseFont = true;
            tileItemElement1.Image = image;
            tileItemElement1.ImageAlignment = DevExpress.XtraEditors.TileItemContentAlignment.TopCenter;
            tileItemElement1.ImageLocation = new System.Drawing.Point(0, 15);
            tileItemElement1.ImageScaleMode = DevExpress.XtraEditors.TileItemImageScaleMode.Stretch;
            tileItemElement1.ImageSize = new System.Drawing.Size(90, 90);
            tileItemElement1.ImageToTextAlignment = DevExpress.XtraEditors.TileControlImageToTextAlignment.Top;
            tileItemElement1.Text = caption;

            tile.Elements.Add(tileItemElement1);
        }

        public static void CustomizeWideTile(Tile tile, string caption, Image image)
        {
            tile.Properties.AllowHtmlDraw = DefaultBoolean.True;
            tile.Properties.ItemSize = TileItemSize.Wide;

            var tileItemElement1 = new TileItemElement();
            var tileItemElement2 = new TileItemElement();

            tileItemElement1.Appearance.Hovered.Font = new Font("Segoe UI Light", 25.5F);
            tileItemElement1.Appearance.Hovered.Options.UseFont = true;
            tileItemElement1.Appearance.Hovered.Options.UseTextOptions = true;
            tileItemElement1.Appearance.Hovered.TextOptions.Trimming = Trimming.EllipsisCharacter;
            tileItemElement1.Appearance.Hovered.TextOptions.WordWrap = WordWrap.Wrap;
            tileItemElement1.Appearance.Normal.Font = new Font("Segoe UI Light", 25.5F);
            tileItemElement1.Appearance.Normal.Options.UseFont = true;
            tileItemElement1.Appearance.Normal.Options.UseTextOptions = true;
            tileItemElement1.Appearance.Normal.TextOptions.Trimming = Trimming.EllipsisCharacter;
            tileItemElement1.Appearance.Normal.TextOptions.WordWrap = WordWrap.Wrap;
            tileItemElement1.Appearance.Selected.Font = new Font("Segoe UI Light", 25.5F);
            tileItemElement1.Appearance.Selected.Options.UseFont = true;
            tileItemElement1.Appearance.Selected.Options.UseTextOptions = true;
            tileItemElement1.Appearance.Selected.TextOptions.Trimming = Trimming.EllipsisCharacter;
            tileItemElement1.Appearance.Selected.TextOptions.WordWrap = WordWrap.Wrap;
            tileItemElement1.ImageAlignment = TileItemContentAlignment.Manual;
            tileItemElement1.ImageLocation = new Point(6, 4);
            tileItemElement1.MaxWidth = 240;
            tileItemElement1.Text = caption;
            tileItemElement1.TextAlignment = TileItemContentAlignment.Manual;
            tileItemElement1.TextLocation = new Point(118, 4);
            tileItemElement2.Appearance.Hovered.Font = new Font("Tahoma", 12.375F);
            tileItemElement2.Appearance.Hovered.Options.UseFont = true;
            tileItemElement2.Appearance.Normal.Font = new Font("Tahoma", 12.375F);
            tileItemElement2.Appearance.Normal.Options.UseFont = true;
            tileItemElement2.Appearance.Selected.Font = new Font("Tahoma", 12.375F);
            tileItemElement2.Appearance.Selected.Options.UseFont = true;
            tileItemElement2.Image = image ?? Resources.viewDefault;
            tileItemElement2.ImageAlignment = TileItemContentAlignment.Manual;
            tileItemElement2.ImageLocation = new Point(12, 16);
            tileItemElement2.ImageScaleMode = TileItemImageScaleMode.Stretch;
            tileItemElement2.ImageSize = new Size(96, 96);
            tileItemElement2.TextLocation = new Point(6, 4);

            tile.Elements.Add(tileItemElement1);
            tile.Elements.Add(tileItemElement2);
        }
    }
}