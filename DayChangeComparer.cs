using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharpAdvanced_plantingSim
{

    public class DayChangeComparer
    {
        // Methods
        public void DayChanged(Plot currentPlot, ISeed seedCreator)
        {
            //if (currentPlot.PlantSize != _seed.MaxSize)
            if (currentPlot.PlantSize != seedCreator.GetMaxSize())
            {
                currentPlot.PlantSize++;
            }
            currentPlot.IsWatered = false;
        }
    }
}
