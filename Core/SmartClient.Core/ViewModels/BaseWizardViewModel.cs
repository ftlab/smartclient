using System.ComponentModel;

namespace SmartClient.Core.ViewModels
{
    /// <summary>
    ///  Базовый класс общего представления данных формы-визарда
    /// </summary>
    public class BaseWizardViewModel : BaseViewModel
    {
        public BindingList<BaseWizardPageViewModel> PageViewModels { get; set; }

        public virtual int PageCount => PageViewModels.Count;

        public int Index { get; set; }

        public virtual BaseWizardPageViewModel CurrentPage => PageViewModels[Index];

        public virtual bool CanSave() => (PageCount - 1 == Index && CurrentPage.Completed)
            || CurrentPage.CanSave;

        public virtual bool CanNext() => ((Index < PageCount - 1) && CurrentPage.Completed)
            || CurrentPage.CanNext;


        public virtual bool CanPrev() => Index > 0
            && CurrentPage.CanPrev;


        public virtual bool CanCancel() => CurrentPage.CanCancel;


    }
}
