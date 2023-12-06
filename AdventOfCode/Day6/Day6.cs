using System.Text.RegularExpressions;

namespace AdventOfCode.Day6;

public class Day6
{
    private static List<int> ValuesPartOne = new List<int>();

    public static void Solve()
    {
        Console.WriteLine("=========================== DAY 6 ===========================");
        PartOne();
        Console.WriteLine();
        PartTwo();
        Console.WriteLine("=========================== END OF DAY 6 ===========================");
    }
    
    private static void PartOne()
    {
        Console.WriteLine("PART ONE");
        var inputFile = File.ReadAllLines("C:\\Users\\playv\\RiderProjects\\AdventOfCode\\AdventOfCode\\Day6\\input.txt");
        var times = new List<int>();
        var bestDistances = new List<int>();
            

        foreach (var line in inputFile)
        {
            var data= line.Split(":");
            
            var intList = new List<int>(data[1].Split(" ")
                .Where(x => !string.IsNullOrWhiteSpace(x))
                .Select(int.Parse));
            
            switch (data[0])
            {
                case "Time":
                    times = intList;
                    break;
                
                case "Distance":
                    bestDistances = intList;
                    break;
                
                default:
                    throw new Exception("unreachable");
            }
        }

        for (var i = 0; i < times.Count; i++)
        {
            var numberOfWins = 0;
            var time = times[i];
            var distance = bestDistances[i];

            for (var j = 0; j <= time; j++)
            {
                if (j == 0 || j == time)
                {
                    continue;
                }

                var timeLeft = time - j;
                if (timeLeft * j > distance)
                {
                    numberOfWins++;
                }
            }

            if (numberOfWins != 0)
            {
                ValuesPartOne.Add(numberOfWins);
            }
        }
        
        Console.WriteLine("Answer: {0}", ValuesPartOne.Aggregate((a, b) => a * b));
        Console.WriteLine("END OF PART ONE");
    }

    private static void PartTwo()
    {
        Console.WriteLine("PART TWO");
        var inputFile = File.ReadAllLines("C:\\Users\\playv\\RiderProjects\\AdventOfCode\\AdventOfCode\\Day6\\input.txt");
        long time = 0;
        long bestDistance = 0;

        foreach (var line in inputFile)
        {
            var data= line.Split(":");
            
            var intVal = long.Parse(data[1].Replace(" ", ""));
            switch (data[0])
            {
                case "Time":
                    time = intVal;
                    break;
                
                case "Distance":
                    bestDistance = intVal;
                    break;
                
                default:
                    throw new Exception("unreachable");
            }
        }
        
        long numberOfWins = 0;
        for (var j = 0; j <= time; j++)
        {
            if (j == 0 || j == time)
            {
                continue;
            }

            var timeLeft = time - j;
            if (timeLeft * j > bestDistance)
            {
                numberOfWins++;
            }
        }
        
        Console.WriteLine("Answer: {0}", numberOfWins);
        Console.WriteLine("END OF PART TWO");
    }
}