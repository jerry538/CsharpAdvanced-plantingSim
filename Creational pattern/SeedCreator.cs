using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharpAdvanced_plantingSim
{
    public abstract class SeedCreator
    {
        public abstract ISeed FactoryMethod();

        public int PrintSeedResult()
        {
            var seedType = FactoryMethod();
            int result = seedType.GetMaxSize();

            return result;
        }
    }
}
