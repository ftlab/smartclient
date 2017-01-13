using System;
using System.Linq;
using SmartClient.Core.ViewModels;
using DevExpress.Utils;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Ribbon;

namespace SmartClient.Core.Controls
{
    public static class ViewCommandCustomizer
    {
        public static BarItem AddToRibbon(RibbonControl control, ViewCommand command, RibbonPageGroup group = null)
        {
            var page = control.Pages["ribbonPage1"];
            if (group == null)
            {
                group = page.Groups["ribbonPageGroup1"];
            }
            BarItem btn = null;
            group.Visible = true;
            var findbbi = group.ItemLinks.OfType<BarItemLink>().FirstOrDefault(i => i.Caption == command.Caption);
            if (findbbi != null) return findbbi.Item;

            if (command is CheckViewCommand)
                btn = new BarCheckItem();
            else if (command is ViewCommand)
                btn = new BarButtonItem();
            else
                throw new NotSupportedException($"Тип {command.GetType()} не поддерживается");

            btn.Tag = command;
            btn.Caption = command.Caption;
            btn.Glyph = command.Image;
            btn.RibbonStyle = RibbonItemStyles.Large;

            if (string.IsNullOrEmpty(command.ToolTip) == false)
            {
                var superTip = new SuperToolTip();
                superTip.Items.Add(new ToolTipTitleItem() {Text = command.ToolTip});
                btn.SuperTip = superTip;
            }
            group.ItemLinks.Add(btn);

            return btn;
        }

        public static BarItem AddToRibbon(RibbonControl control, ViewCommand command, string groupCaption)
        {
            if (string.IsNullOrEmpty(groupCaption))
                return AddToRibbon(control, command);

            var page = control.Pages["ribbonPage1"];
            var group = page.Groups.GetGroupByText(groupCaption);
            if (group == null)
            {
                group = new RibbonPageGroup(groupCaption);
                page.Groups.Add(group);
            }
            return AddToRibbon(control, command, group);
        }
    }
}
