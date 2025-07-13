namespace CsharpAdvanced_plantingSim
{
    public class PlotManager
    {
        public List<Plot> Plots { get; set; }

        public PlotManager()
        {
            Plots = new List<Plot>
            {
                new Plot("Plot a"),
                new Plot("Plot b"),
                new Plot("Plot c"),
            };
        }
    }
}
