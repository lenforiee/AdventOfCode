namespace AdventOfCode.Day4;

public class Day4
{
    private static List<int> ValuesPartOne = new List<int>();
    private static Dictionary<int, int> ValuePartTwo = new Dictionary<int, int>();

    public static void Solve()
    {
        Console.WriteLine("=========================== DAY 4 ===========================");
        PartOne();
        Console.WriteLine();
        PartTwo();
        Console.WriteLine("=========================== END OF DAY 4 ===========================");
    }

    private static List<int> CollectInts(string line)
    {
        var intList = new List<int>();
        foreach (var val in line.Split(' '))
        {
            if (!int.TryParse(val, out var parsed))
            {
                continue;
            }
            
            intList.Add(parsed);
        }

        return intList;
    }
    
    private static void PartOne()
    {
        Console.WriteLine("PART ONE");
        var inputFile = File.ReadAllLines("C:\\Users\\playv\\RiderProjects\\AdventOfCode\\AdventOfCode\\Day4\\input.txt");

        foreach (var line in inputFile)
        {
            var stringNumbers = line.Split(':')[1].Split(" | ");
            var winningInts = CollectInts(stringNumbers[0]);
            var yourNumbers = CollectInts(stringNumbers[1]);

            var val = winningInts.Intersect(yourNumbers);
            ValuesPartOne.Add(val.Count() > 0 ? (int)Math.Pow(2, val.Count() - 1) : 0);
        }
        
        Console.WriteLine("Answer: {0}", ValuesPartOne.Sum());
        Console.WriteLine("END OF PART ONE");
    }

    private static void PartTwo()
    {
        Console.WriteLine("PART TWO");
        var inputFile = File.ReadAllLines("C:\\Users\\playv\\RiderProjects\\AdventOfCode\\AdventOfCode\\Day4\\input.txt");
        
        
        for (var i = 0; i < inputFile.Length; i++)
        {
            ValuePartTwo.Add(i, 0);
        }

        for (var i = 0; i < inputFile.Length; i++)
        {
            ValuePartTwo[i] += 1;

            var line = inputFile[i];
            var stringNumbers = line.Split(':')[1].Split(" | ");
            var winningInts = CollectInts(stringNumbers[0]);
            var yourNumbers = CollectInts(stringNumbers[1]);
            
            var val = winningInts.Intersect(yourNumbers);
            for (var j = 0; j < val.Count(); j++)
            {
                ValuePartTwo[i + 1 + j] += ValuePartTwo[i];
            }
        }
        
        Console.WriteLine("Answer: {0}", ValuePartTwo.Values.Sum());
        Console.WriteLine("END OF PART TWO");
    }
}