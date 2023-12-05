using System.Text.RegularExpressions;

namespace AdventOfCode.Day3;

public class Day3
{
    private static List<int> ValuesPartOne = new List<int>();
    private static List<int> ValuesPartTwo = new List<int>();
    public static void Solve()
    {
        Console.WriteLine("=========================== DAY 3 ===========================");
        PartOne();
        Console.WriteLine();
        PartTwo();
        Console.WriteLine("=========================== END OF DAY 3 ===========================");
    }

    private static List<int> FindUnknownCharIndexes(string line)
    {
        var indexList = new List<int>();

        for (var i = 0; i < line.Length; i++)
        {
            if (line[i] != '.' && !char.IsDigit(line[i]))
            {
                indexList.Add(i);
            }
        }

        return indexList;
    }
    
    private static List<int> FindGearIndexes(string line)
    {
        var indexList = new List<int>();

        for (var i = 0; i < line.Length; i++)
        {
            if (line[i] == '*')
            {
                indexList.Add(i);
            }
        }

        return indexList;
    }
    
    private static Dictionary<int, int> FindNumbers(string line)
    {
        var indexDictionary = new Dictionary<int, int>();
        
        var numbers = Regex.Split(line, @"\D+");
        var offset = 0;
        foreach (var num in numbers) 
        {
            if (!int.TryParse(num, out var parsed))
            {
                continue;
            }
            
            var numIndex = line.IndexOf(num, offset, StringComparison.Ordinal);
            offset = numIndex + num.Length;

            for (var i = 0; i < num.Length; i++)
            {
                indexDictionary.Add(numIndex + i, parsed);
            }
        }

        return indexDictionary;
    }

    private static void PartOne()
    {
        Console.WriteLine("PART ONE");
        var inputFile = File.ReadAllLines("C:\\Users\\playv\\RiderProjects\\AdventOfCode\\AdventOfCode\\Day3\\input.txt");
        for (var i = 0; i < inputFile.Length; i++)
        {
            var line = inputFile[i];
            var curIndexes = FindUnknownCharIndexes(line);

            var previousLine = i - 1 >= 0 ? inputFile[i - 1] : String.Empty;
            var nextLine = i + 1 < inputFile.Length ? inputFile[i + 1] : String.Empty;
            var prevIndexes = FindUnknownCharIndexes(previousLine);
            var nextIndexes = FindUnknownCharIndexes(nextLine);

            var numbers = Regex.Split(line, @"\D+");
            var offset = 0;
            foreach (var num in numbers)
            {
                if (!int.TryParse(num, out _))
                {
                    continue;
                }
                
                var numIndex = line.IndexOf(num, offset, StringComparison.Ordinal);
                offset = numIndex + num.Length;
                
                // Side check.
                if (curIndexes.Contains(numIndex - 1) || curIndexes.Contains(numIndex + num.Length))
                {
                    ValuesPartOne.Add(int.Parse(num));
                }

                // diagonal top
                if (prevIndexes.Contains(numIndex - 1) || prevIndexes.Contains(numIndex + num.Length))
                {
                    ValuesPartOne.Add(int.Parse(num));
                }

                // diagonal bottom
                if (nextIndexes.Contains(numIndex - 1) || nextIndexes.Contains(numIndex + num.Length))
                {
                    ValuesPartOne.Add(int.Parse(num));
                }


                for (var j = 0; j < num.Length; j++)
                {
                    // Top check.
                    if (prevIndexes.Contains(numIndex + j))
                    {
                        ValuesPartOne.Add(int.Parse(num));
                    }

                    // Bottom check.
                    if (nextIndexes.Contains(numIndex + j))
                    {
                        ValuesPartOne.Add(int.Parse(num));
                    }
                }
            }
        }

        Console.WriteLine("Answer: {0}", ValuesPartOne.Sum());
        Console.WriteLine("END OF PART ONE");
    }

    private static void PartTwo()
    {
        Console.WriteLine("PART TWO");
        var inputFile = File.ReadAllLines("C:\\Users\\playv\\RiderProjects\\AdventOfCode\\AdventOfCode\\Day3\\input.txt");
        for (var i = 0; i < inputFile.Length; i++)
        {
            var line = inputFile[i];
            var curGears = FindGearIndexes(line);
            var curNumbers = FindNumbers(line);
            
            
            var previousLine = i - 1 >= 0 ? inputFile[i - 1] : String.Empty;
            var nextLine = i + 1 < inputFile.Length ? inputFile[i + 1] : String.Empty;
            var prevNumbers = FindNumbers(previousLine);
            var nextNumbers = FindNumbers(nextLine);

            foreach (var gearIdx in curGears)
            {
                var numList = new List<int>();
                
                // Side check.
                if (curNumbers.Keys.Contains(gearIdx - 1))
                {
                    numList.Add(curNumbers[gearIdx - 1]);
                }

                if (curNumbers.Keys.Contains(gearIdx + 1))
                {
                    numList.Add(curNumbers[gearIdx + 1]);
                }
                
                // top + bottom
                var aboveGear = false;
                var underGear = false;
                if (prevNumbers.Keys.Contains(gearIdx))
                {
                    aboveGear = true;
                    numList.Add(prevNumbers[gearIdx]);
                }

                if (nextNumbers.Keys.Contains(gearIdx))
                {
                    underGear = true;
                    numList.Add(nextNumbers[gearIdx]);
                }

                // diagonal top
                if (!aboveGear && prevNumbers.Keys.Contains(gearIdx - 1))
                {
                    numList.Add(prevNumbers[gearIdx - 1]);
                }

                if (!aboveGear && prevNumbers.Keys.Contains(gearIdx + 1))
                {
                    numList.Add(prevNumbers[gearIdx + 1]);
                }

                // diagonal bottom
                if (!underGear && nextNumbers.Keys.Contains(gearIdx - 1))
                {
                    numList.Add(nextNumbers[gearIdx - 1]);
                }

                if (!underGear && nextNumbers.Keys.Contains(gearIdx + 1))
                {
                    numList.Add(nextNumbers[gearIdx + 1]);
                }

                if (numList.Count == 2)
                {
                    ValuesPartTwo.Add(numList[0] * numList[1]);
                }
                
            }
            
        }

        Console.WriteLine("Answer: {0}", ValuesPartTwo.Sum());
        Console.WriteLine("END OF PART TWO");
    }
}