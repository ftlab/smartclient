using DevExpress.Utils.Drawing;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraBars.Ribbon.ViewInfo;
using System.Drawing;

namespace SmartClient.Core.Forms
{
    internal sealed class QuickRibbonControl : RibbonControl
    {
        private sealed class QuickRibbonViewInfo : RibbonViewInfo
        {
            private sealed class QuickRibbonCaptionViewInfo : RibbonCaptionViewInfo
            {
                public QuickRibbonCaptionViewInfo(RibbonViewInfo viewInfo) : base(viewInfo)
                {
                }

                protected override Rectangle CalcTextBounds()
                {
                    Rectangle rc = base.CalcTextBounds();
                    if (ViewInfo.Toolbar.ContentBounds.Left != 0)
                        rc = new Rectangle(ViewInfo.Bounds.Left + ViewInfo.ApplicationButtonSize.Width + rc.Height, rc.Y + 3, rc.Width, rc.Height - 3);
                    return rc;
                }
            }

            private sealed class QuickRibbonQuickAccessToolbarViewInfo : RibbonQuickAccessToolbarViewInfo
            {
                public QuickRibbonQuickAccessToolbarViewInfo(RibbonQuickAccessToolbar toolbar) : base(toolbar)
                {
                }

                protected override Rectangle CalcContentBounds()
                {
                    Rectangle rect = base.CalcContentBounds();
                    return new Rectangle(Bounds.Width - base.CalcBestSize().Width, rect.Y, base.CalcBestSize().Width, rect.Height);
                }
            }

            public QuickRibbonViewInfo(RibbonControl ribbon) : base(ribbon)
            {
            }

            protected override RibbonCaptionViewInfo CreateCaptionInfo()
            {
                return new QuickRibbonCaptionViewInfo(this);
            }
            protected override RibbonQuickAccessToolbarViewInfo CreateToolbarInfo()
            {
                return new QuickRibbonQuickAccessToolbarViewInfo(Ribbon.Toolbar);
            }
        }

        private sealed class ZRibbonQuickAccessToolbar : RibbonQuickAccessToolbar
        {
            private sealed class ZRibbonQuickAccessToolbarPainter : RibbonQuickAccessToolbarPainter
            {
                protected override void DrawItems(ObjectInfoArgs e, RibbonQuickAccessToolbarViewInfo vi)
                {
                    RibbonHitInfo hitInfo = vi.ViewInfo.CalcHitInfo(vi.ViewInfo.MousePosition);
                    if (hitInfo.Item != null && hitInfo.Item.PaintStyle == BarItemPaintStyle.CaptionGlyph)
                    {
                        Rectangle rc = vi.Items[0].Bounds;
                        e.PaintArgs.Graphics.FillRectangle(SystemBrushes.InactiveCaption, rc);
                        e.PaintArgs.Graphics.DrawRectangle(SystemPens.ControlDark, rc);
                    }
                    base.DrawItems(e, vi);
                }
            }

            public ZRibbonQuickAccessToolbar(RibbonControl ribbon) : base(ribbon)
            {
            }

            protected override RibbonQuickAccessToolbarPainter CreatePainter()
            {
                return new ZRibbonQuickAccessToolbarPainter();
            }
        }
        protected override RibbonQuickAccessToolbar CreateToolbar()
        {
            return new ZRibbonQuickAccessToolbar(this);
        }
        protected override RibbonViewInfo CreateViewInfo()
        {
            return new QuickRibbonViewInfo(this);
        }
    }
}
