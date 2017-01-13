using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMIOR.UI.WF.Interfaces
{
    public interface ITreeListViewModel
    {
        ITreeItemViewModel ActiveRow { get; set; }
        bool ShowDeleted { get; set; }
        void Refresh();
        void DeleteActive();
        void RestoreActive();
    }
}
