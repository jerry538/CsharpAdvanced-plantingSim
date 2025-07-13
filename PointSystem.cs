using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharpAdvanced_plantingSim
{
    public class PointSystem
    {
        // Fields/Properties
        public int Points {  get; set; }
        
        // Constructors
        public PointSystem()
        { 
            Points = 0;
        }

        public void PrintPoints()
        {
            Console.WriteLine($"Points {Points}");
        }
    }
}
