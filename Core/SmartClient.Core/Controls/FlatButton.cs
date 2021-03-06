﻿using System.ComponentModel;
using System.Drawing;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Drawing;

namespace SmartClient.Core.Controls
{
    [ToolboxItem(true)]
    public class FlatButton : SimpleButton
    {
        public FlatButton()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            SuspendLayout();
            // 
            // FlatButton
            // 
            Size = new Size(117, 33);
            ButtonStyle = BorderStyles.HotFlat;
            ShowFocusRectangle = DefaultBoolean.False;

            ResumeLayout(false);
        }

        protected override BaseControlPainter CreatePainter()
        {
            return new FtFlatButtonPainter();
        }

        private class FtFlatButtonPainter : BaseButtonPainter
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
