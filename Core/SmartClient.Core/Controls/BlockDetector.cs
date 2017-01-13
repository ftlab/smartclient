using System;
using System.Threading;
using ForegroundTimer = System.Windows.Forms.Timer;
using BackgroundTimer = System.Threading.Timer;
using Common.Logging;

namespace SmartClient.Core.Controls
{
    public class BlockDetector
    {
        private bool _isBusy;

        private const int FreezeTimeLimit = 2000;

        private readonly ForegroundTimer _foregroundTimer;

        private readonly BackgroundTimer _backgroundTimer;

        private DateTime _lastForegroundTimerTickTime;

        public event Action UIBlocked;

        public event Action UIReleased;

        public BlockDetector()
        {
            _foregroundTimer = new ForegroundTimer { Interval = FreezeTimeLimit / 2 };
            _foregroundTimer.Tick += ForegroundTimerTick;
            _backgroundTimer = new BackgroundTimer(BackgroundTimerTick, null, FreezeTimeLimit, Timeout.Infinite);
        }

        private void BackgroundTimerTick(object someObject)
        {
            var totalMilliseconds = (DateTime.Now - _lastForegroundTimerTickTime).TotalMilliseconds;
            if (totalMilliseconds > FreezeTimeLimit && _isBusy == false)
            {
                _isBusy = true;
                UIBlocked();
            }
            else
            {
                if (totalMilliseconds < FreezeTimeLimit && _isBusy)
                {
                    _isBusy = false;
                    UIReleased();
                }
            }
            _backgroundTimer.Change(FreezeTimeLimit, Timeout.Infinite);
        }

        private void ForegroundTimerTick(object sender, EventArgs e)
        {
            _lastForegroundTimerTickTime = DateTime.Now;
        }

        public void Start()
        {
            _foregroundTimer.Start();
        }

        public void Stop()
        {
            try
            {
                _foregroundTimer.Stop();
                _backgroundTimer.Dispose();
            }
            catch (Exception exception)
            {
                Log.WriteError(exception);
            }
        }
    }
}
