using System;
using System.Windows.Forms;

namespace SmartClient.Core.Services
{
    public interface IHotkeyService : IService
    {
        IHotkeyService Register(Control control, Keys key, Action handler);

        IHotkeyService UnRegister(Control control);

        IHotkeyService UnRegister(Control control, Keys key);
    }
}
