using System.Drawing;
using System.ComponentModel;
using SmartClient.Core.Views;

namespace SmartClient.Core.ViewModels
{
    public class DictionaryCommand : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public DictionaryCommand(string caption, Image image = null, string toolTip = null)
        {
            Caption = caption;
            ToggledCaption = string.Empty;
            Image = image;
            ToolTip = toolTip;
            Enabled = true;

        }
        public DictionaryCommand(string caption, string toggledCaption, Image image = null, string toolTip = null)
        {
            Caption = DefaultCaption = caption;
            ToggledCaption = toggledCaption;
            Image = image;
            ToolTip = toolTip;
            Enabled = true;
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;

            handler?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        private string _caption;
        public string Caption
        {
            get
            {
                return _caption;
            }
            set
            {
                _caption = value;
                OnPropertyChanged(nameof(Caption));
            }
        }

        private bool _enabled;
        public bool Enabled
        {
            get
            {
                return _enabled;
            }
            set
            {
                _enabled = value;
                OnPropertyChanged(nameof(Enabled));
            }
        }


        public string DefaultCaption { get; set; }
        public string ToggledCaption { get; set; }


        public void SwapCaption()
        {
            if (string.IsNullOrEmpty(ToggledCaption))
                return;
            var tmp = Caption;
            Caption = ToggledCaption;
            ToggledCaption = tmp;
        }



        public Image Image { get; set; }

        public string ToolTip { get; set; }

        public void Execute(IDictionaryView dictionaryView)
        {
            dictionaryView.ExecuteCommand(this);
        }

        #region Standard commands

        public static readonly DictionaryCommand Refresh = new DictionaryCommand("Обновить", Properties.Resources.reset_32x32);

        public static readonly DictionaryCommand Add = new DictionaryCommand("Добавить", Properties.Resources.add_32x32);

        public static readonly DictionaryCommand Edit = new DictionaryCommand("Редактировать", Properties.Resources.editcontact_32x32);

        public static readonly DictionaryCommand Delete = new DictionaryCommand("Удалить", Properties.Resources.delete_32x32);

        public static readonly DictionaryCommand ShowDeleted = new DictionaryCommand("Показать удаленные", "Скрыть удаленные", Properties.Resources.resetchanges_32x32);

        public static readonly DictionaryCommand Restore = new DictionaryCommand("Восстановить", Properties.Resources.resetchanges_32x32);


        //Не добавлять новые. Кастомные добавляются в своем View

        #endregion
    }


}
