using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace MedCitySim
{
    class RandomEvents
    {
        protected Timer eventTimer;
        private Random randomPick;

        // kan godt være det en struct
        //kommer vist an på om der skal være en constructer.

        public bool Flood()
        {
            return true;
        }

        public bool Plague()
        {
            return true;
        }

        public bool Earthquake()
        {
            return true;
        }

        public bool Fire()
        {
            return true;
        }

        public bool NiceWeather()
        {
            return true;
        }

        public bool Bard()
        {
            return true;
        }

    }
}
