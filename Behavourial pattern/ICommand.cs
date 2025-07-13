using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CsharpAdvanced_plantingSim
{
    public interface ICommand
    {
        void Execute();
    }

    public class NextDayCommand : ICommand
    {
        private readonly Stats _stats;
        private readonly Grow _grow;

        public NextDayCommand(Stats stats, Grow grow)
        {
            _stats = stats;
            _grow = grow;   
        }

        public void Execute()
        {
            _stats.DayCounter();
            _grow.PlantGrowth();
        }
    }
}
