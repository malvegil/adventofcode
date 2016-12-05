<Query Kind="Program">
  <Output>DataGrids</Output>
</Query>

void Main()
{
	string[] allLines = File.ReadAllLines(@"C:\users\chris.esau\desktop\input1.txt");
	map = new int[8, 8];
	AddToMap(allLines);

	var distances = FindDistance(-1, 0, new List<int> { 0, 1, 2, 3, 4, 5, 6, 7 });

	distances.Min(x => x).Dump();
	distances.Max(x => x).Dump();
}

// Define other methods and classes here
public int[,] map;

public void AddToMap(string[] lines)
{
	var x = 0;
	var y = 1;

	foreach (var l in lines)
	{
		var d = l.Split('=');
		map[x, y] = Int32.Parse(d[1]);
		map[y, x] = map[x, y];
		y++;

		if (y == 8)
		{
			x++;
			y = x + 1;
		}
	}
}

public List<int> FindDistance(int starting_point, int distance, List<int> further_locations)
{
	var distances = new List<int>();

	if (further_locations.Count == 1)
	{
		distances.Add(distance + map[starting_point, further_locations[0]]);
	}
	else
	{
		
		foreach (var l in further_locations)
		{
			var new_locations = further_locations.Where(x => x != l);
			
			var dist_total = (starting_point < 0) ? 0 : (map[starting_point, l] + distance);
			
			distances.AddRange(
				FindDistance(
					l, 
					dist_total, 
					new_locations.ToList()));
		}
	}

	return distances;
}