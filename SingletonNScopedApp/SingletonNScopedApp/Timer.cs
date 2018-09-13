using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SingletonNScopedApp
{
    public class Timer : ITimer
    {
        public Timer()
        {
            Time = System.DateTime.Now.ToString("hh:mm:ss");
        }
        public string Time { get; }
    }

    public class TimeService
    {
        private ITimer _timer;

        public TimeService(ITimer timer)
        {
            _timer = timer;
        }

        public string GetTime()
        {
            return _timer.Time;
        }
    }
}
