using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharpAdvanced_plantingSim
{
    public class Plot
    {
        // Fields/Properties
        public string TempTitle { get; set; }
        public bool IsSeeded { get; set; }
        public bool IsWatered { get; set; }
        public int PlantSize { get; set; }
        public ISeed CurrentSeed { get; set; }

        // Constructors
        public Plot(string tempTitle)
        {
            TempTitle = tempTitle;
            IsWatered = false;
            IsSeeded = false;
            PlantSize = 0;
        }
    }
}
