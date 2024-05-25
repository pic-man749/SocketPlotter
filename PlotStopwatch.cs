using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocketPlotter {
    public static class PlotStopwatch {

        private static Stopwatch stopwatch = new Stopwatch();

        public static void Start() {
            stopwatch.Start();
        }

        public static void Stop() {
            stopwatch.Stop();
        }

        public static void Clear() { 
            stopwatch = new Stopwatch();
        }

        public static long Elapsed() {
            return stopwatch.ElapsedMilliseconds;
        }

        public static double ElapsedSec() {
            return stopwatch.ElapsedMilliseconds / 1000d;
        }

    }
}
