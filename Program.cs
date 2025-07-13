using System;
using System.ComponentModel;
using System.Globalization;
using CsharpAdvanced_plantingSim;
using CsharpAdvanced_plantingSim.Structural_pattern;

public interface ICommandState
{
    void HandleCommand(CommandLine context, string command);
}

public class NextState : ICommandState
{
    public void HandleCommand(CommandLine context, string command)
    {
        context.CommandInvoker.SetCommand(context.NextDayCommand);
        context.CommandInvoker.Execute();                               // Keeps track how many days have passed and the plantgrowth
    }
}

public class SeedWheatState : ICommandState
{
    public void HandleCommand(CommandLine context, string command)
    {
        if (command.Length <= 2)
        {
            Console.WriteLine("Invalid command");
            return;
        }
        
        if (!int.TryParse(command.Substring(2), out int plotNumber))
        {
            Console.WriteLine("Invalid plot number");
            return;
        }

        int plotIndex = plotNumber - 1;
        var plots = context.PlotManager.Plots;

        if (plotIndex < 0 || plotIndex >= plots.Count)
        {
            Console.WriteLine("Invalid plot number");
            return;
        }

        ISeed wheatSeed = new WheatSeed();                               // CurrentSeed is WheatSeed
        wheatSeed.SeedAny(plots[plotIndex]);
        Console.WriteLine($"Planted wheatseed on plot number {plotNumber}");
        
    }
}

public class SeedCarrotState : ICommandState
{
    public void HandleCommand(CommandLine context, string command)
    {
        if (command.Length <= 2)
        {
            Console.WriteLine("Invalid command");
            return;
        }

        string plotNumberString = command.Substring(2);
        if (!int.TryParse(plotNumberString, out int plotNumber))
        {
            Console.WriteLine("Invalid plot number");
            return;
        }

        int plotIndex = plotNumber - 1;
        var plots = context.PlotManager.Plots;

        if (plotIndex < 0 || plotIndex >= plots.Count)
        {
            Console.WriteLine("Invalid plot number");
            return;
        }

        ISeed carrotSeed = new CarrotSeed();                            // CurrentSeed is CarrotSeed
        carrotSeed.SeedAny(plots[plotIndex]);
        Console.WriteLine($"Planted carrotseed on plot number {plotNumber}");
    }
}

public class WaterState : ICommandState
{
    public void HandleCommand(CommandLine context, string command)
    {
        if (command.Length <= 1)
        {
            Console.WriteLine("Invalid command");
            return;
        }

        if (!int.TryParse(command.Substring(1), out int plotNumber))    // Convert from string to int, then use the Inserted plotNumber
        {                                                               // to correct the index number
            Console.WriteLine("Invalid plot number");
            return;
        }

        int plotIndex = plotNumber - 1;
        var plots = context.PlotManager.Plots;
        if (plotIndex < 0 || plotIndex >= plots.Count)
        {
            Console.WriteLine("Invalid plot number");
            return;
        }

        Plot plot = plots[plotIndex];
        if (!plot.IsSeeded)
        {
            Console.WriteLine("Plot is empty");
            return;
        }

        Console.WriteLine($"You have watered {plot.TempTitle}");
        context.WaterPlot(plot);

        foreach (var p in plots)                           // Print all plot sizes
        {
            Console.WriteLine($"{p.TempTitle}'s PlantSize = {p.PlantSize}");
        }
    }
}

public class PluckState : ICommandState
{
    public void HandleCommand(CommandLine context, string command)
    {
        if (command.Length <= 1)
        {
            Console.WriteLine("Invalid command");
            return;
        }

        if (!int.TryParse(command.Substring(1), out int plotNumber))
        {
            Console.WriteLine("Invalid plot number");
            return;
        }

        int plotIndex = plotNumber - 1;
        var plots = context.PlotManager.Plots;

        if (plotIndex < 0 || plotIndex >= plots.Count)
        {
            Console.WriteLine("Invalid plot number");
            return;
        }

        Plot plot = plots[plotIndex];
        if (!plot.IsSeeded)
        {
            Console.WriteLine($"No crop to pluck in plot {plotNumber}");
            return;
        }

        context.PluckPlot(plot, context.PointSystem, plot.CurrentSeed);
    }
}

public class InvalidCommandState : ICommandState
{
    public void HandleCommand(CommandLine context, string command)
    {
        Console.WriteLine("Invalid command");
    }
}


public class CommandLine
{
    // Fields/properties
    //private readonly Plot _plots;
    private readonly PlotManager _plotManager;
    private readonly PointSystem _pointSystem;
    private readonly CommandInvoker _commandInvoker;
    private readonly NextDayCommand _nextDayCommand;
    private string command;
    private ICommandState _currentState;                                // Current State

    //public Plot Plots => _plots;
    public PlotManager PlotManager => _plotManager;
    public PointSystem PointSystem => _pointSystem;
    public CommandInvoker CommandInvoker => _commandInvoker;
    public NextDayCommand NextDayCommand => _nextDayCommand;

    // Constructors
    public CommandLine(Stats stats, PlotManager plotManager, Grow grow, PointSystem pointSystem)   
    {
        _plotManager = plotManager;
        _pointSystem = pointSystem;
        _commandInvoker = new CommandInvoker();
        _nextDayCommand = new NextDayCommand(stats, grow);
    }

    // Methods
    public void EnterCommand(string command)
    {
        //string command = Console.ReadLine() ?? "";

        _currentState = command.ToLower() switch        // Choose the correct state based on the command

        {
            "next" => new NextState(),
            string s when s.StartsWith("sw") && s.Length > 1 && char.IsDigit(s[2]) => new SeedWheatState(),
            string s when s.StartsWith("sc") && s.Length > 1 && char.IsDigit(s[2]) => new SeedCarrotState(),
            string s when s.StartsWith("w") && s.Length > 1 && char.IsDigit(s[1]) => new WaterState(),
            string s when s.StartsWith("p") && s.Length > 1 && char.IsDigit(s[1]) => new PluckState(),
            _ => new InvalidCommandState()
        };

        _currentState.HandleCommand(this, command);     // Assign command handling to the current state
    }

    /*
    Give points to user and reset the plot
    */
    public void PluckPlot(Plot plot, PointSystem pointSystem, ISeed seed)
    {
        int maxSize = seed.GetMaxSize();

        if (plot.PlantSize == maxSize)
        {
            if (maxSize == 3)
            {
                pointSystem.Points += 3;
                plot.IsSeeded = false;
                plot.CurrentSeed = null;
                plot.PlantSize = 0;
                Console.WriteLine("Harvested!");
            }
            else if (maxSize == 2)
            {
                pointSystem.Points += 2;
                plot.IsSeeded = false;
                plot.CurrentSeed = null;
                plot.PlantSize = 0;
                Console.WriteLine("Harvested!");
            }
        }
        else
        {
            Console.WriteLine("Plant cannot be plucked yet!");
        }
    }
    public void WaterPlot(Plot plot)
    {
        plot.IsWatered = true;
    }
}

class Program
{
    static void Main()
    {
        GameFacade game = new GameFacade();
        game.Initialize();
        game.RunMainLoop(99);
    }
}