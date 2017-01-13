using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CMIOR.UI.WF.Components
{
    public class WorkLock : IDisposable
    {
        private readonly SessionSwitchEventHandler _sseh;

        private CancellationTokenSource _source;

        public WorkLock()
        {
            _sseh = new SessionSwitchEventHandler(SysEventsCheck);
            SystemEvents.SessionSwitch += _sseh;
        }

        private async void SysEventsCheck(object sender, SessionSwitchEventArgs e)
        {
            if (e.Reason == SessionSwitchReason.SessionLock || e.Reason == SessionSwitchReason.SessionLogoff)
            {
                try
                {
                    _source = new CancellationTokenSource();
                    var setting = ConfigurationManager.AppSettings["SmartExitInactiveTimeout"];
                    TimeSpan delta = TimeSpan.FromMinutes(1);
                    if (setting != null)
                        delta = TimeSpan.Parse(setting);
                    await Task.Delay(delta, _source.Token);
                }
                catch (OperationCanceledException)
                {
                    return;
                }

                Environment.Exit(0);
            }
            else if (e.Reason == SessionSwitchReason.SessionUnlock || e.Reason == SessionSwitchReason.SessionLogon)
            {
                if (_source != null)
                {
                    _source.Cancel();
                    _source = null;
                }
            }
        }

        public void Dispose()
        {
            SystemEvents.SessionSwitch += _sseh;
        }
    }
}
