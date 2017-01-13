using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using SmartClient.Core.Views;

namespace SmartClient.Core.ViewModels
{
    public class ViewCommand
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public ViewCommand(string caption, Image image = null, string toolTip = null, string group = null)
        {
            Caption = caption;
            Image = image;
            ToolTip = toolTip;
            Group = group;
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
        private Image _image;
        public Image Image
        {
            get
            {
                return _image;
            }
            set
            {
                _image = value;
                OnPropertyChanged(nameof(Image));
            }
        }

        public string ToolTip { get; set; }

        public string Group { get; private set; }

        #region Singles
        public static readonly ViewCommand Refresh = new ViewCommand("Обновить", Properties.Resources.reset_32x32);
        public static readonly ViewCommand Add = new ViewCommand("Добавить", Properties.Resources.add_32x32);
        public static readonly ViewCommand Edit = new ViewCommand("Редактировать", Properties.Resources.editcontact_32x32);
        public static readonly ViewCommand Delete = new ViewCommand("Удалить", Properties.Resources.delete_32x32);
        #endregion
    }

    public class CheckViewCommand : ViewCommand
    {
        public CheckViewCommand(string caption, Image image = null, string toolTip = null, string group = null, CheckState state = CheckState.Unchecked)
            :base(caption,image,toolTip,group)
        {
            Caption = caption;
            Image = image;
            ToolTip = toolTip;
            State = state;
        }

        public CheckState State { get; set; }
    }
}
