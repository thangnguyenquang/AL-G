using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AL_G
{
    class Timming
    {
        Stopwatch st = new Stopwatch();
        public void Stop()
        {
            st.Stop();
        }
        public void Start()
        {
            st.Reset();
            st.Start(); 
        }

        public long Time()
        {
            long timeelapsed = st.ElapsedMilliseconds;
            return timeelapsed;
        }
    }
}
