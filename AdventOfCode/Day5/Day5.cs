using System.Text.RegularExpressions;

namespace AdventOfCode.Day5;

public class Day5
{
    private static List<List<long>> SeedToSoilRanges = new List<List<long>>();
    private static List<List<long>> SoilToFertiliserRanges = new List<List<long>>();
    private static List<List<long>> FertiliserToWaterRanges = new List<List<long>>();
    private static List<List<long>> WaterToLightRanges = new List<List<long>>();
    private static List<List<long>> LightToTemperatureRanges = new List<List<long>>();
    private static List<List<long>> TemperatureToHumidityRanges = new List<List<long>>();
    private static List<List<long>> HumidityToLocationRanges = new List<List<long>>();

    public static void Solve()
    {
        Console.WriteLine("=========================== DAY 5 ===========================");
        PartOne();
        Console.WriteLine();
        //PartTwo(); THIS TOOK AN RIDICULOUS AMOUNT OF TIME.
        Console.WriteLine("=========================== END OF DAY 5 ===========================");
    }

    private static void ParseRanges(string line)
    {
        var nameOfMap = line.Split(" ")[0];
        var mappingLines = line.Split(":")[1].Split("\n").Skip(1).Where(x => !string.IsNullOrWhiteSpace(x));
        foreach (var mapLine in mappingLines)
        {
            var values = new List<long>(mapLine.Split(" ").Where(x => !string.IsNullOrEmpty(x)).Select(long.Parse));
            
            switch (nameOfMap)
            {
                case "seed-to-soil":
                    SeedToSoilRanges.Add(values);
                    break;

                case "soil-to-fertilizer":
                    SoilToFertiliserRanges.Add(values);
                    break;

                case "fertilizer-to-water":
                    FertiliserToWaterRanges.Add(values);
                    break;

                case "water-to-light":
                    WaterToLightRanges.Add(values);
                    break;

                case "light-to-temperature":
                    LightToTemperatureRanges.Add(values);
                    break;

                case "temperature-to-humidity":
                    TemperatureToHumidityRanges.Add(values);
                    break;

                case "humidity-to-location":
                    HumidityToLocationRanges.Add(values);
                    break;

                default:
                    throw new Exception("unreachable");
            }
        }
    }

    private static long FindValue(List<List<long>> mapping, long value)
    {
        foreach (var map in mapping)
        {
            var destinationRangeStart = map[0];
            var sourceRangeStart = map[1];
            var rangeLength = map[2];

            if (sourceRangeStart <= value && value <= sourceRangeStart + (rangeLength - 1))
            {
                return destinationRangeStart + (value - sourceRangeStart);
            }
        }

        return value;
    }
    
    private static void PartOne()
    {
        Console.WriteLine("PART ONE");
        var inputFile = File.ReadAllText("C:\\Users\\playv\\RiderProjects\\AdventOfCode\\AdventOfCode\\Day5\\input.txt");
        var seeds = new List<long>();
        foreach (var line in Regex.Split(inputFile.Replace("\r", ""), "\n\n"))
        {
            if (line.StartsWith("seeds:"))
            {
                seeds = new List<long>(line.Split(": ")[1].Split(" ").Select(long.Parse));
                continue;
            }

            ParseRanges(line);
        }
        
        long lowestVal = long.MaxValue;
        foreach (var seed in seeds)
        {
            var soil = FindValue(SeedToSoilRanges, seed);
            var fertiliser = FindValue(SoilToFertiliserRanges, soil);
            var water = FindValue(FertiliserToWaterRanges, fertiliser);
            var light = FindValue(WaterToLightRanges, water);
            var temperature = FindValue(LightToTemperatureRanges, light);
            var humidity = FindValue(TemperatureToHumidityRanges, temperature);
            var location = FindValue(HumidityToLocationRanges, humidity);

            if (lowestVal > location)
            {
                lowestVal = location;
            }
        }
        
        Console.WriteLine("Answer: {0}", lowestVal);
        Console.WriteLine("END OF PART ONE");
    }

    private static void PartTwo()
    {
        Console.WriteLine("PART TWO");
        var inputFile = File.ReadAllText("C:\\Users\\playv\\RiderProjects\\AdventOfCode\\AdventOfCode\\Day5\\input.txt");
        var seeds = new List<long[]>();
        foreach (var line in Regex.Split(inputFile.Replace("\r", ""), "\n\n"))
        {
            if (line.StartsWith("seeds:"))
            {
                seeds = line.Split(": ")[1].Split(" ").Select(long.Parse).Chunk(2).ToList();
                continue;
            }

            ParseRanges(line);
        }

        long lowestVal = long.MaxValue;
        foreach (var seed in seeds)
        {
            for (var i = 0; i < seed[1]; i++)
            {
                var soil = FindValue(SeedToSoilRanges, seed[0] + i);
                var fertiliser = FindValue(SoilToFertiliserRanges, soil);
                var water = FindValue(FertiliserToWaterRanges, fertiliser);
                var light = FindValue(WaterToLightRanges, water);
                var temperature = FindValue(LightToTemperatureRanges, light);
                var humidity = FindValue(TemperatureToHumidityRanges, temperature);
                var location = FindValue(HumidityToLocationRanges, humidity);
            
                if (lowestVal > location)
                {
                    lowestVal = location;
                }
            }
        }
        
        Console.WriteLine("Answer: {0}", lowestVal);
        Console.WriteLine("END OF PART TWO");
    }
}