using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CMIOR.UI.WF.Services
{
    public interface IHotkeyService : IService
    {
        IHotkeyService Register(Control control, Keys key, Action handler);

        IHotkeyService UnRegister(Control control);

        IHotkeyService UnRegister(Control control, Keys key);
    }
}
