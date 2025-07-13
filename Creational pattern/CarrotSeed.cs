using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharpAdvanced_plantingSim
{
    public class CarrotSeedCreator : SeedCreator
    {
        public override ISeed FactoryMethod()
        {
            return new CarrotSeed();
        }
    }
    public class CarrotSeed : ISeed
    {
        public int GetMaxSize()
        {
            return 2;
        }
        public void SeedAny(Plot plot)
        {
            plot.CurrentSeed = new CarrotSeed();
            plot.IsSeeded = true;
        }
    }
}
