<Query Kind="Program">
  <Connection>
    <ID>b9bd739a-fa2b-4350-87d2-e71685f3121a</ID>
    <Persist>true</Persist>
    <Driver>LinqToSql</Driver>
    <Server>apexsqldev02</Server>
    <CustomAssemblyPath>P:\CorpIT\.NET Libraries\Production ARI DLLs\ApexDataModel.dll</CustomAssemblyPath>
    <CustomTypeName>ApexRemington.DAL.rempscoDataContext</CustomTypeName>
    <Database>compass_dev</Database>
    <DisplayName>ARI - Dev</DisplayName>
  </Connection>
  <Output>DataGrids</Output>
</Query>

void Main()
{
	string[] allLines = File.ReadAllLines(@"C:\users\chris.esau\desktop\input1.txt");
	map = new int[9, 9];
	AddToMap(allLines);
	map.Dump();

	var distances = FindDistance(new int[9], 0, new List<int> { 0, 1, 2, 3, 4, 5, 6, 7, 8 });

	distances.Min(x => x).Dump();
	distances.Max(x => x).Dump();
}

// Define other methods and classes here
public int[,] map;

public void AddToMap(string[] lines)
{
	var x = 0;
	var y = 0;

	foreach (var l in lines)
	{
		if (x == y)
			y++;

		var d = l.Split();
		var value = Int32.Parse(d[3]);
		map[x, y] += l.Contains("gain") ? value : -value;
		map[y, x] = map[x, y];
		y++;

		if (y == 9)
		{
			x++;
			y = 0;
		}
	}
}

public List<int> FindDistance(int[] points, int distance, List<int> further_locations)
{
	var distances = new List<int>();

	if (further_locations.Count == 1)
	{
		var dist = distance + map[points[1], further_locations[0]] + map[points[8], further_locations[0]];
		distances.Add(dist);
		points[0] = further_locations[0];
		
		if (dist == 668)
		{
			points.ToList().Dump();
		}
	}
	else
	{
		foreach (var l in further_locations)
		{
			var new_locations = further_locations.Where(x => x != l);
			
			points[further_locations.Count() - 1] = l;

			var dist_total = (further_locations.Count() > 8) ? 0 : (map[points[further_locations.Count()], l] + distance);

			distances.AddRange(
				FindDistance(
					points,
					dist_total,
					new_locations.ToList()));
		}
	}

	return distances;
}