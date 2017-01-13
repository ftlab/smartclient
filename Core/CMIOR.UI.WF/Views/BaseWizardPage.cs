using CMIOR.UI.WF.ViewModels;
using DevExpress.XtraBars.Docking2010.Views.WindowsUI;
using DevExpress.XtraEditors;

namespace CMIOR.UI.WF.Views
{
    /// <summary>
    ///  Базовый компонент страницы визарда (шага)
    /// </summary>
    public partial class BaseWizardPage : FlatView, ISupportNavigation
    {
        public BaseWizardPage()
        {
            InitializeComponent();
        }

        /// <summary>
        ///  Собственное представление данных
        /// </summary>
        protected internal BaseWizardPageViewModel ViewModel { get; set; }

        /// <summary>
        ///  Общее представление данных визарда
        /// </summary>
        public BaseWizardViewModel WizardViewModel { get; set; }

        #region ISupportNavigation Members        

        public virtual void OnNavigatedTo(INavigationArgs args)
        {
            WizardViewModel = args.Parameter as BaseWizardViewModel;
            if (WizardViewModel == null)
                return;
            wizardBindingSource.DataSource = WizardViewModel;
        }

        public virtual void OnNavigatedFrom(INavigationArgs args)
        {

        }

        #endregion        


    }
}
