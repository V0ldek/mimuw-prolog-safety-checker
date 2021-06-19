using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

Console.WriteLine("Select mode: 1. normal, 2. next-move mode");
var n = Console.ReadLine();

var moves = ParseMoves();

switch (int.Parse(n))
{
    case 1:
        PrintNormal(moves);
        break;
    case 2:
        PrintDelayed(moves);
        break;
    default:
        Console.WriteLine("Unknown mode.");
        return 1;
}

return 0;

void PrintNormal(IEnumerable<(int, int)> moves)
{
    var result = new StringBuilder();
    result.Append("[");

    foreach (var (n1, n2) in moves)
    {
        result.Append($"({n1}, {n2}), ");
    }

    result.Length -= 2;
    result.Append("]");

    Console.WriteLine(result);
}

void PrintDelayed(IEnumerable<(int, int)> moves)
{
    var result = new StringBuilder();
    result.Append("[");
    var moveMap = new Dictionary<int, int>();

    foreach (var (pid, nextMove) in moves)
    {
        if (moveMap.TryGetValue(pid, out var move))
        {
            result.Append($"({pid}, {move + 1}), ");
        }

        moveMap[pid] = nextMove;
    }

    result.Length -= 2;
    result.Append("]");

    Console.WriteLine(result);
}

List<(int, int)> ParseMoves()
{    
    var regex = new Regex("([0-9]+)[^0-9]*([0-9]+)");
    var moves = new List<(int, int)>();

    while (true)
    {
        var read = Console.ReadLine();

        if (read is null) { break; }

        var match = regex.Match(read);

        if (match.Success)
        {
            var n1 = match.Groups[1].ToString();
            var n2 = match.Groups[2].ToString();

            moves.Add((int.Parse(n1), int.Parse(n2)));
        }
    }

    return moves;
}