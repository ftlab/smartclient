using System;

namespace SmartClient.Core.ViewModels
{
	/// <summary>
	///  Базовый Интерфейс представления данных страницы визарда
	/// </summary>
    public abstract class BaseWizardPageViewModel : BaseViewModel
    {
		public virtual bool CanPrev { get { return true; } } //todo:
		public virtual bool CanNext { get { return false; } } 
		public virtual bool CanSave { get { return false; } }
		public virtual bool CanCancel { get { return true; } }
		public virtual bool Completed { get { return true; } } //todo:

		public virtual BaseWizardPageViewModel PreviousPageViewModel { get; set; }


		/// <summary>
		///  Событие запроса сохранения данных
		/// </summary>
		public event Action SaveEvent;

		
		/// <summary>
		///  Обработчик кнопки сохранения
		/// </summary>
		public virtual void Save()
		{
			SaveEvent?.Invoke();
		}

		//BorderProtectionScheduleHeader Accept();
    }
}
