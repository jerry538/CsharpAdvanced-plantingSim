namespace CsharpAdvanced_plantingSim
{
    public class Grow
    {
        // Fields/properties
        public int Day { get; set; }
        public List<Plot> WateredPlots { get; set; } = new List<Plot>(); 
        public SeedCreator wheatSeed = new WheatSeedCreator();
        public SeedCreator carrotSeed = new CarrotSeedCreator();
        private readonly DayChangeComparer _dayChangeComparer;
        private readonly PlotManager _plotManager;


        public Grow(DayChangeComparer dayChangeComparer, PlotManager plotManager)
        {
            _dayChangeComparer = dayChangeComparer;
            _plotManager = plotManager;
        }
 
        // Contructors

        // Methods
        public void PlantGrowth()
        {
            var wateredPlots = new List<Plot>();

            foreach (Plot plot in _plotManager.Plots)   // Put watered plots in a list
            {
                if (plot.IsWatered)
                {
                    wateredPlots.Add(plot);
                }
            }

            foreach (var plot in wateredPlots)          // Check if watered plot has seeds and grow it
            {
                if (plot.CurrentSeed != null)
                {
                    _dayChangeComparer.DayChanged(plot, plot.CurrentSeed); 
                    Console.WriteLine($"Processed: {plot.TempTitle} grew to size {plot.PlantSize}");
                }
            }
        }
    }
}
