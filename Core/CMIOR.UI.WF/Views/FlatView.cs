using System;
using System.Windows.Forms;
using CMIOR.UI.WF.AppModel.Info;
using DevExpress.XtraBars.Docking2010.Views.WindowsUI;
using DevExpress.XtraEditors;

namespace CMIOR.UI.WF.Views
{
    public partial class FlatView : XtraUserControl, IView, ISupportDocumentActions, ISupportNavigation, ISupportKeyProcess
    {
        public FlatView()
        {
            InitializeComponent();
        }

        protected virtual ViewInfo ViewInfo { get; private set; }

        public event KeyEventHandler KeyProcess;

        public virtual void OnQueryDocumentActions(IDocumentActionsArgs args)
        {
            if (ViewInfo != null)
            {
                foreach (var commandInfo in ViewInfo.Commands)
                {
                    ConfigureCommand(commandInfo, args);
                }
            }
        }

        public Control Control
        {
            get { return this; }
        }

        public void SetViewInfo(ViewInfo viewInfo)
        {
            ViewInfo = viewInfo;
        }

        protected virtual void ConfigureCommand(CommandInfo commandInfo, IDocumentActionsArgs args)
        {
            args.DocumentActions.Add(new DocumentAction(x => commandInfo.Execute())
            {
                Image = commandInfo.Image,
                Caption = commandInfo.Caption ?? commandInfo.Name,
                Description = commandInfo.Description
            });
        }

        public virtual void OnNavigatedTo(INavigationArgs args)
        {

        }

        public virtual void OnNavigatedFrom(INavigationArgs args)
        {

        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            KeyEventArgs arg = null;
            KeyProcess?.Invoke(this, (arg = new KeyEventArgs(keyData)));

            if (arg == null || arg.Handled == false) return base.ProcessCmdKey(ref msg, keyData);
            else return true;
        }
    }
}