using System;
using System.Collections.Generic;
using System.Text;

namespace NEventStore.FastReadModelRebuild.Standard20
{
    public class GlobalTimer
    {
        private static GlobalTimer _timer = null;
        private DateTime _startTime;


        private GlobalTimer()
        {

        }

        public DateTime Start()
        {
            _startTime = DateTime.Now;
            return _startTime;
        }

        public TimeSpan Stop()
        {
            var span = DateTime.Now.Subtract(_startTime);
            return span;
        }

        public static GlobalTimer Timer
        {
            get
            {
                if (_timer == null)
                {
                    _timer = new GlobalTimer();
                }

                return _timer;
            }
        }
    }
}
