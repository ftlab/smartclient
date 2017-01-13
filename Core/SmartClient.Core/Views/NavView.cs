using System;
using System.Linq;
using SmartClient.Core.Controls;
using SmartClient.Core.ViewModels;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraPrinting.Native;

namespace SmartClient.Core.Views
{
    public partial class NavView : RibbonView
    {
        public NavView()
        {
            InitializeComponent();
        }


        //public void AddButtons()
        //{
        //	var group = ribbonPageGroup1;

        //	var oldItems = group.ItemLinks.OfType<BarButtonItemLink>()
        //		.Where(x => x.Item.Tag is ViewCommand)
        //		.ToList();
        //	oldItems.ForEach(x =>
        //	{
        //		x.Item.ItemClick -= Command_ItemClick;
        //		group.ItemLinks.Remove(x);
        //	});

        //	var view = viewContainer1.ActiveView;
        //	view?.GetCommands()
        //		.ToList()
        //		.ForEach(command =>
        //		{
        //			var btn = ViewCommandCustomizer.AddToRibbon(ribbonControl1, command);
        //			btn.ItemClick += Command_ItemClick;
        //		});
        //}


        private async void Command_ItemClick(object sender, ItemClickEventArgs e)
        {
            var view = viewContainer1.ActiveView;

            if (view == null)
                throw new NullReferenceException("view is null");

            await view.ExecuteCommand(e.Item.Tag as ViewCommand);
        }


        private void viewContainer1_Load(object sender, EventArgs e)
        {

        }


        private void viewContainer1_ActiveViewChanged(object sender, EventArgs e)
        {
            var oldItems = ribbonControl1.Items.OfType<BarItem>().Where(x => x.Tag is ViewCommand).ToList();
            oldItems.ForEach(x =>
            {
                x.ItemClick -= Command_ItemClick;
                ribbonControl1.Items.Remove(x);
            });
            ribbonPage1.Groups.OfType<RibbonPageGroup>().ForEach(
                rpg => { rpg.Visible = false; }
                );
            //var group = ribbonPageGroup1;

            //var oldItems = group.ItemLinks.OfType<BarBaseButtonItemLink>()
            //    .Where(x => x.Item.Tag is ViewCommand)
            //    .ToList();
            //oldItems.ForEach(x =>
            //{
            //    x.Item.ItemClick -= Command_ItemClick;
            //    group.ItemLinks.Remove(x);
            //});

            var view = viewContainer1.ActiveView;
            view?.GetCommands()
                .ToList()
                .ForEach(command =>
                {
                    var btn = ViewCommandCustomizer.AddToRibbon(ribbonControl1, command, command.Group);
                    btn.ItemClick += Command_ItemClick;
                    command.PropertyChanged += Command_PropertyChanged;
                });

            view.ChangeCommandVisibility += ChangeCommandVisibility;
        }


        private void Command_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            ViewCommand command = sender as ViewCommand;

            var btn = ribbonControl1.Items.OfType<BarBaseButtonItem>()
                .Where(x => x.Tag is ViewCommand)
                .FirstOrDefault(x => x.Tag == command);
            if (btn == null || command == null) return;

            btn.Caption = command.Caption;
            btn.Glyph = command.Image;
        }

        private void ChangeCommandVisibility(ViewCommand command, bool visible)
        {
            var group = ribbonPageGroup1;

            var oldItems = group.ItemLinks.OfType<BarButtonItemLink>()
                .Where(x => x.Item.Tag is ViewCommand)
                .ToList();
            oldItems.ForEach(x =>
            {
                if (x.Item.Tag == command)
                    x.Visible = visible;
            });
        }


        private void navigationTreeList_CustomDrawNodeCell(object sender, DevExpress.XtraTreeList.CustomDrawNodeCellEventArgs e)
        {
            var data = (NavNode)navigationTreeList.GetDataRecordByNode(e.Node);
            e.CellText = data.Caption;
        }

    }
}
