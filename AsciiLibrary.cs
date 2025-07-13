using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharpAdvanced_plantingSim
{
    public class AsciiLibrary
    {
        public string AsciiTitle { get; set; }
        public string AsciiStats { get; set; }
        public string AsciiDay { get; set; }
        public string AsciiPoints { get; set; }

        private readonly Stats _stats;      // Composition to use stats
        private readonly CommandLine _commandLine;      // Composition to use stats
        private readonly PointSystem _pointSystem; 
        public AsciiLibrary(Stats stats, CommandLine commandLine, PointSystem pointSystem)    //Composition, use daycounter inside AsciiLibrary class
        {
            _stats = stats;
            _commandLine = commandLine;
            _pointSystem = pointSystem;
        }

        public void PrintIntro()
        {
            Console.Title = "PlantingSim";
            AsciiTitle = @"
+-----------------------------------+
|                                   |
|         x              x          |
|          x       x    xx      xx  |
|          x     xxx    x       x   |
|     x          x  x   x      x    |
|     x        x    x   x    xx     |
|      x      x      x      x       |
|      xx   x             x         |
|       xxx          x   x          |
|        xx           x x           |
|            ,        xx            |
|                                   |
|  Welcome to my                    |
|  CsharpAdvanced project!          |
|                                   |
|  Press any button                 |
|  Made by Jerry Qian               |                 
+-----------------------------------+
";
            Console.WriteLine(AsciiTitle);
            Console.ReadKey();
            Console.Clear();
        }
        public void PrintStats()
        { 
            Console.Title   = "PlantingSim";
            AsciiDay        = $"Day {_stats.Day}";
            AsciiPoints     = $"Points: {_pointSystem.Points}";
            AsciiStats      = $@"
Type 'help' to see available commands. 
+-----------+
|   Stats   | 
+-----------+
{Console.Title} | {AsciiDay} | {AsciiPoints}

";
            Console.WriteLine("Type 'next' to advance to next day");
            Console.WriteLine(AsciiStats);
            
            // ConsoleReadline in main loop for testability
            string input = Console.ReadLine() ?? "";
            _commandLine.EnterCommand(input);
        }
    }
}
