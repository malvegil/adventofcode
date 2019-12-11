<Query Kind="Program" />

void Main()
{
	var input = File.ReadAllLines(@"H:\Documents\LINQPad Queries\AdventofCode\AdventofCode\AdventofCode2018\day18a.txt").ToArray();
	var hundred_acre_wood = new List<Acre>();
	var grid_size = 50;
	var time = 1000000000;

	for (var x = 0; x < grid_size; x++)
	{
		for (var y = 0; y < grid_size; y++)
		{
			hundred_acre_wood.Add(new Acre() { Scape = input[y][x], x = x, y = y });
		}
	}

	for (var t = 0; t < time; t++)
	{
		var new_wood = new List<Acre>();
		for (var x = 0; x < grid_size; x++)
		{
			for (var y = 0; y < grid_size; y++)
			{
				var adjacents = hundred_acre_wood.Where(h =>
					(x - 1 == h.x && y - 1 == h.y) || // top left
					(x - 0 == h.x && y - 1 == h.y) || // top middle
					(x + 1 == h.x && y - 1 == h.y) || // top right
					(x - 1 == h.x && y - 0 == h.y) || // middle left
					(x + 1 == h.x && y - 0 == h.y) || // middle right
					(x - 1 == h.x && y + 1 == h.y) || // bottom left
					(x - 0 == h.x && y + 1 == h.y) || // bottom middle
					(x + 1 == h.x && y + 1 == h.y)    // bottom right
					).ToList();
				var a = hundred_acre_wood.Single(h => h.x == x && h.y == y).Scape;
				switch (a)
				{
					case '.':
						a = adjacents.Count(h => h.Scape == '|') >= 3 ? '|' : '.';
						break;
					case '|':
						a = adjacents.Count(h => h.Scape == '#') >= 3 ? '#' : '|';
						break;
					case '#':
						a = adjacents.Any(h => h.Scape == '#') && adjacents.Any(h => h.Scape == '|') ? '#' : '.';
						break;
				}
				new_wood.Add(new Acre() { Scape = a, x = x, y = y, });
			}
		}
		hundred_acre_wood = new_wood;
	}
	hundred_acre_wood.Count(h => h.Scape == '#').Dump();
	hundred_acre_wood.Count(h => h.Scape == '|').Dump();
	(hundred_acre_wood.Count(h => h.Scape == '#') * hundred_acre_wood.Count(h => h.Scape == '|')).Dump("Day 18 Part A");
}

// Define other methods and classes here
public class Acre
{
	public char Scape;
	public int x;
	public int y;
}