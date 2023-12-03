namespace AdventOfCode.Day2;

public class Day2
{
    private static List<int> ValuesPartOne = new List<int>();
    private static List<int> ValuesPartTwo = new List<int>();

    public static void Solve()
    {
        Console.WriteLine("=========================== DAY 2 ===========================");
        PartOne();
        Console.WriteLine();
        PartTwo();
        Console.WriteLine("=========================== END OF DAY 2 ===========================");
    }
    
    private static void PartOne()
    {
        Console.WriteLine("PART ONE");
        var inputFile = File.ReadAllLines("C:\\Users\\playv\\RiderProjects\\AdventOfCode\\AdventOfCode\\Day2\\input.txt");
        foreach (var line in inputFile)
        {
            var gameId = int.Parse(line.Split("Game ")[1].Split(":")[0]);
            var gameData = line.Split(": ")[1].Split("; ");

            var isPossible = true;
            foreach (var data in gameData)
            {
                var colours = data.Split(", ");
                
                var red = 0;
                var blue = 0;
                var green = 0;
                foreach (var colourData in colours)
                {
                    var split = colourData.Split(" ");
                    
                    switch (split[1])
                    {
                        case "red": 
                            red = int.Parse(split[0]);
                            break;
                        case "blue":
                            blue = int.Parse(split[0]);
                            break;
                        case "green":
                            green = int.Parse(split[0]);
                            break;
                        default:
                            throw new Exception("unreachable");
                    }
                    
                }
                
                if (red > 12 || green > 13 || blue > 14)
                {
                    isPossible = false;
                    break;
                }
                
            }

            if (isPossible)
            {
                ValuesPartOne.Add(gameId);
            }
        }
        
        Console.WriteLine("Answer: {0}", ValuesPartOne.Sum());
        Console.WriteLine("END OF PART ONE");
    }

    private static void PartTwo()
    {
        Console.WriteLine("PART TWO");
        var inputFile = File.ReadAllLines("C:\\Users\\playv\\RiderProjects\\AdventOfCode\\AdventOfCode\\Day2\\input.txt");
        foreach (var line in inputFile)
        {
            var gameData = line.Split(": ")[1].Split("; ");

            var lowestRed = 0;
            var lowestBlue = 0;
            var lowestGreen = 0;

            foreach (var data in gameData)
            {
                var colours = data.Split(", ");
                
                var red = 0;
                var blue = 0;
                var green = 0;
                foreach (var colourData in colours)
                {
                    var split = colourData.Split(" ");
                    
                    switch (split[1])
                    {
                        case "red": 
                            red = int.Parse(split[0]);
                            break;
                        case "blue":
                            blue = int.Parse(split[0]);
                            break;
                        case "green":
                            green = int.Parse(split[0]);
                            break;
                        default:
                            throw new Exception("unreachable");
                    }
                    
                }

                if (red > lowestRed)
                {
                    lowestRed = red;
                }

                if (blue > lowestBlue)
                {
                    lowestBlue = blue;
                }

                if (green > lowestGreen)
                {
                    lowestGreen = green;
                }
            }
            
            ValuesPartTwo.Add(lowestRed*lowestBlue*lowestGreen);
        }
        
        Console.WriteLine("Answer: {0}", ValuesPartTwo.Sum());
        Console.WriteLine("END OF PART TWO");
    }
}