// See https://aka.ms/new-console-template for more information

using Helpers;

var input = await File.ReadAllLinesAsync("Inputs/day1");

var solution = Day1.PuzzleB(input);

Console.WriteLine($"Solution: {solution}");
