using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharpAdvanced_plantingSim
{
    
    public class WheatSeedCreator : SeedCreator
    {
        public override ISeed FactoryMethod()
        {
            return new WheatSeed();
        }
    }
    public class WheatSeed : ISeed
    {
        public int GetMaxSize()
        {
            return 3;
        }
        public void SeedAny (Plot plot)
        {
            plot.CurrentSeed = new WheatSeed();
            plot.IsSeeded = true;
        }
    }
}
