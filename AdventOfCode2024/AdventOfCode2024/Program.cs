// See https://aka.ms/new-console-template for more information

using Helpers;

var input = await File.ReadAllLinesAsync("Inputs/day2");

var solution = Day2.PuzzleB(input);

Console.WriteLine($"Solution: {solution}");
