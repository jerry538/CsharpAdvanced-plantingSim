using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharpAdvanced_plantingSim
{
    public sealed class Stats
    {
        // Singleton instance
        private static readonly Stats instance = new Stats();

        // Singleton accessor
        public static Stats Instance
        {
            get
            {
                return instance;
            }
        }

        // Explicit static constructor to tell C# compiler
        // not to mark type as beforefieldinit, meaning Stats get initialised when it's being used.
        static Stats()
        {
        }

        // Fields/properties
        public int Day { get; set; }

        //private readonly WheatSeed _seed;
        //private readonly Plot _plot;

        private Stats()
        {
            Day = 0; // Explicit initiation for daycounter.
        }

        // Methods
        private readonly object _lockObj = new object();
        public static bool IsTestMode { get; set; } = false;

        public void DayCounter()
        {
            lock (_lockObj)
            {
                Day++; // Keeps track how many days have passed
                if (!IsTestMode)
                    Console.Clear();
            }
        }
    }
}
