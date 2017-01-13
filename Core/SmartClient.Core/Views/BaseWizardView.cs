using SmartClient.Core.Container;
using SmartClient.Core.Messages;
using SmartClient.Core.ViewModels;
using DevExpress.XtraBars.Docking2010.Views;
using DevExpress.XtraBars.Docking2010.Views.WindowsUI;
using DevExpress.XtraEditors;

namespace SmartClient.Core.Views
{
    /// <summary>
    ///  Базовый компонент основного контейнера визарда
    /// </summary>
    public partial class BaseWizardView : FlatView
    {
        /// <summary>
        ///  Общее представление данных визарда
        /// </summary>
        protected BaseWizardViewModel ViewModel;

        public BaseWizardView()
        {
            InitializeComponent();

            windowsUIView1.DocumentActivated += WindowsUIView1_DocumentActivated;
            windowsUIView1.QueryDocumentActions += WindowsUIView1_QueryDocumentActions;
            windowsUIView1.NavigatedTo += WindowsUIView1_NavigatedTo;
        }


        /// <summary>
        ///  Проброс представления данных визарда в дочернюю форму
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void WindowsUIView1_NavigatedTo(
            object sender,
            NavigationEventArgs e)
        {
            e.Parameter = ViewModel;
        }


        /// <summary>
        ///  Обработчик перехода по страницам визарда
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void WindowsUIView1_DocumentActivated(object sender, DocumentEventArgs e)
        {
            pageGroup1.Caption = e.Document.Caption;
        }

        private void windowsUIView1_NavigationBarsShowing(object sender, NavigationBarsCancelEventArgs e)
        {
            e.Cancel = true;
        }


        /// <summary>
        ///  Отрисовка кнопок навигации визарда
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void WindowsUIView1_QueryDocumentActions(object sender, QueryDocumentActionsEventArgs e)
        {
            if (e.Source == pageGroup1)
            {
                e.DocumentActions.Add(new DocumentAction(x => ViewModel.CanPrev(), x => Prev())
                {
                    Caption = CaptionForPrev,
                    Image = imageCollection1.Images[0],
                });
                e.DocumentActions.Add(new DocumentAction(x => ViewModel.CanNext(), x => Next())
                {
                    Caption = CaptionForNext,
                    Image = imageCollection1.Images[1],
                });
                e.DocumentActions.Add(new DocumentAction(x => ViewModel.CanSave(), x => Save())
                {
                    Caption = CaptionForSave,
                    Image = imageCollection1.Images[2],
                });
                e.DocumentActions.Add(new DocumentAction(x => ViewModel.CanCancel(), x => Cancel())
                {
                    Caption = CaptionForCancel,
                    Image = imageCollection1.Images[3],
                });
            }
        }


        public virtual string CaptionForSave => "Сохранить";
        public virtual string CaptionForNext => "Далее";
        public virtual string CaptionForPrev => "Назад";
        public virtual string CaptionForCancel => "Отмена";


        /// <summary>
        ///  Переход на страницу визарда
        /// </summary>
        /// <param name="index"></param>
        public void NavigateTo(int index)
        {
            ViewModel.Index = index;
            ActivatePage(ViewModel.Index);
        }



        public virtual void Cancel() => Close();

        public virtual void Save() => Close();

        /// <summary>
        ///  Переход на форму приложения, открытую до визарда
        /// </summary>
        public void Close() => ServiceContainer.Default.NotificationService.Notify(new GoBackEvent());


        /// <summary>
        ///  Переход на следующую дочернюю страницу
        /// </summary>
        public virtual void Next()
        {
            if (!ViewModel.CurrentPage.Completed)
                return;
            ViewModel.Index = ViewModel.Index + 1;
            ActivatePage(ViewModel.Index);
        }


        /// <summary>
        ///  Переход на предыдущую дочернюю страницу
        /// </summary>
        public virtual void Prev()
        {
            ViewModel.Index = ViewModel.Index - 1;
            ActivatePage(ViewModel.Index);
        }


        /// <summary>
        ///  Активация страницы визарда
        /// </summary>
        /// <param name="index"></param>
        protected void ActivatePage(int index)
        {
            var pageGroup = (PageGroup)windowsUIView1.ContentContainers[nameof(pageGroup1)];
            windowsUIView1.ActivateDocument(pageGroup.Items[index]);
        }
    }
}
