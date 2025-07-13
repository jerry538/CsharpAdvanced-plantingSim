namespace CsharpAdvanced_plantingSim.Structural_pattern
{
    public class GameFacade
    {
        private readonly Stats _stats;
        private readonly PlotManager _plotManager;
        private readonly PointSystem _pointSystem;
        private readonly DayChangeComparer _dayChangeComparer;
        private readonly Grow _grow;
        private readonly CommandLine _commandLine;
        private readonly AsciiLibrary _asciiLibrary;

        public GameFacade()
        {
            _stats                    = Stats.Instance;    // Create instance once 
            _plotManager              = new PlotManager();
            _pointSystem              = new PointSystem();
            _dayChangeComparer        = new DayChangeComparer();
            _grow                     = new Grow(_dayChangeComparer, _plotManager);
            _commandLine              = new CommandLine(_stats, _plotManager, _grow, _pointSystem);
            _asciiLibrary             = new AsciiLibrary(_stats, _commandLine, _pointSystem);
        }

        public void Initialize()
        {
            _asciiLibrary.PrintIntro();
        }

        public void RunMainLoop(int loopNumberOfTimes)
        {
            for (int i = 0; i < loopNumberOfTimes; i++)
            {
                _asciiLibrary.PrintStats();
            }
            Console.ReadKey();
        }
    }

}
