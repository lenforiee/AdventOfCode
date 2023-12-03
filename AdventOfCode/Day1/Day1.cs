namespace AdventOfCode.Day1;

public class Day1
{
    
    private static List<int> ValuesPartOne = new List<int>();
    private static List<int> ValuesPartTwo = new List<int>();
    private static readonly Dictionary<string, int> NumberLookupTable = new Dictionary<string, int>()
    {
        {"one", 1}, {"two", 2}, {"three", 3}, {"four", 4}, 
        {"five", 5}, {"six", 6}, {"seven", 7}, {"eight", 8}, {"nine", 9}
    };

    private static readonly List<string> CharLookupTable = new List<string>()
    {
        "one", "two", "three", "four", "five", "six", "seven", "eight", 
        "nine", "1", "2", "3", "4", "5", "6", "7", "8", "9"
    };

    public static void Solve()
    {
        Console.WriteLine("=========================== DAY 1 ===========================");
        PartOne();
        Console.WriteLine();
        PartTwo();
        Console.WriteLine("=========================== END OF DAY 1 ===========================");
    }
    
    private static void PartOne()
    {
        Console.WriteLine("PART ONE");
        var inputFile = File.ReadAllLines("C:\\Users\\playv\\RiderProjects\\AdventOfCode\\AdventOfCode\\Day1\\input.txt");
        foreach (var line in inputFile)
        {
            var intList = new List<char>(line.Where(char.IsDigit));

            var expectedInt = int.Parse(intList.First().ToString() + intList.Last().ToString());
            ValuesPartOne.Add(expectedInt);
        }
        
        Console.WriteLine("Answer: {0}", ValuesPartOne.Sum());
        Console.WriteLine("END OF PART ONE");
    }
    
    private static void PartTwo()
    {
        Console.WriteLine("PART TWO");
        var inputFile = File.ReadAllLines("C:\\Users\\playv\\RiderProjects\\AdventOfCode\\AdventOfCode\\Day1\\input.txt");

        foreach (var line in inputFile)
        {
            var lowestIdx = line.Length;
            var firstNum = 0;
            var highestIdx = 0;
            var lastNum = 0;
            
            for (var i = 0; i < CharLookupTable.Count; i++)
            {
                var testChar = CharLookupTable[i];

                var leftPosition = line.IndexOf(testChar, StringComparison.Ordinal);
                var rightPosition = line.LastIndexOf(testChar, StringComparison.Ordinal);
                
                if (leftPosition != -1 && leftPosition <= lowestIdx)
                {
                    lowestIdx = leftPosition;
                    if (!int.TryParse(testChar, out firstNum))
                    {
                        firstNum = NumberLookupTable[testChar];
                    }
                }

                if (rightPosition != -1 && rightPosition >= highestIdx)
                {
                    highestIdx = rightPosition;
                    if (!int.TryParse(testChar, out lastNum))
                    {
                        lastNum = NumberLookupTable[testChar];
                    }
                }
            }
            
            ValuesPartTwo.Add(firstNum * 10 + lastNum);
        }
        
        Console.WriteLine("Answer: {0}", ValuesPartTwo.Sum());
        Console.WriteLine("END OF PART TWO");
    }
}