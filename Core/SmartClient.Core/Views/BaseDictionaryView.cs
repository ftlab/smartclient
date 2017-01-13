using System;
using System.Collections.Generic;
using SmartClient.Core.ViewModels;
using DevExpress.XtraBars.Docking2010.Views.WindowsUI;
using SmartClient.Core.Container;

namespace SmartClient.Core.Views
{
    public abstract partial class BaseDictionaryView : FlatView, IDictionaryView
    {
        public BaseDictionaryView()
        {
            InitializeComponent();
        }

        public virtual void ExecuteCommand(DictionaryCommand command)
        {
            if (command == null) throw new ArgumentNullException(nameof(command));

            if (command == DictionaryCommand.Refresh) RefreshData();
            else if (command == DictionaryCommand.Add) Add();
            else if (command == DictionaryCommand.Edit) Edit();
            else if (command == DictionaryCommand.Delete) AskDelete();
            else if (command == DictionaryCommand.ShowDeleted) ShowDeleted();
            else if (command == DictionaryCommand.Restore) Restore();
            else ExecuteCustomCommand(command);

            command.SwapCaption();
        }


        public virtual IEnumerable<DictionaryCommand> GetCommands()
        {
            yield return DictionaryCommand.Add;
            yield return DictionaryCommand.Edit;
            yield return DictionaryCommand.Delete;
            yield return DictionaryCommand.Refresh;
        }

        public override void OnNavigatedFrom(INavigationArgs args)
        {
            ClearData();
        }

        public override void OnNavigatedTo(INavigationArgs args)
        {
            RefreshData();
        }

        public virtual void ExecuteCustomCommand(DictionaryCommand command)
        {
        }

        public virtual void RefreshData()
        {
        }


        /// <summary>
        ///  
        /// </summary>
        public virtual void ClearData()
        {
        }

        public virtual void Edit()
        {
        }

        public virtual void Add()
        {
        }

        public virtual bool CanDelete()
        {
            return true;
        }
        public virtual void Delete()
        {

        }

        public virtual void Restore()
        {
        }

        public virtual void ShowDeleted()
        {
        }

        protected virtual void AskDelete()
        {
            if (ServiceContainer.Default.DialogService.Ask("Удалить запись?", "Подтвердите действие") == true)
            {
                Delete();
            }
        }
    }
}
