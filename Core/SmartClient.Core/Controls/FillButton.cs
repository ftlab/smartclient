using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Drawing;
using System.ComponentModel;
using System.Drawing;

namespace SmartClient.Core.Controls
{
    [ToolboxItem(true)]
    public class FillButton: SimpleButton
    {
        public FillButton()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            SuspendLayout();
            // 
            // FillButton
            //
            Appearance.BackColor = Color.FromArgb(90, 126, 143);
            Appearance.BorderColor = Color.FromArgb(90, 126, 143);
            Appearance.ForeColor = Color.White;
            Appearance.Options.UseBackColor = true;
            Appearance.Options.UseBorderColor = true;

            Size = new Size(117, 33);
            ButtonStyle = BorderStyles.HotFlat;
            ShowFocusRectangle = DefaultBoolean.False;
            
            ResumeLayout(false);
        }

        protected override BaseControlPainter CreatePainter()
        {
            return new FillButtonPainter();
        }

        private class FillButtonPainter : DevExpress.XtraEditors.Drawing.BaseButtonPainter
        {
            protected override void DrawBorder(ControlGraphicsInfoArgs info)
            {
                info.ViewInfo.Appearance.BorderColor = Color.FromArgb(91, 122, 172);

                base.DrawBorder(info);

                info.Cache.DrawRectangle(new Pen(new SolidBrush(Color.FromArgb(90, 126, 143)), 6), info.Bounds);
            }
        }
    }
}
