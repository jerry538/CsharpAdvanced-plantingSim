using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharpAdvanced_plantingSim
{
    public interface ISeed
    {
        int GetMaxSize();
        void SeedAny(Plot plot);
    }
}
