<Query Kind="Program">
  <Output>DataGrids</Output>
</Query>

void Main()
{
	var input =
	@"Faerun to Norrath = 129
Faerun to Tristram = 58
Faerun to AlphaCentauri = 13
Faerun to Arbre = 24
Faerun to Snowdin = 60
Faerun to Tambi = 71
Faerun to Straylight = 67
Norrath to Tristram = 142
Norrath to AlphaCentauri = 15
Norrath to Arbre = 135
Norrath to Snowdin = 75
Norrath to Tambi = 82
Norrath to Straylight = 54
Tristram to AlphaCentauri = 118
Tristram to Arbre = 122
Tristram to Snowdin = 103
Tristram to Tambi = 49
Tristram to Straylight = 97
AlphaCentauri to Arbre = 116
AlphaCentauri to Snowdin = 12
AlphaCentauri to Tambi = 18
AlphaCentauri to Straylight = 91
Arbre to Snowdin = 129
Arbre to Tambi = 53
Arbre to Straylight = 40
Snowdin to Tambi = 15
Snowdin to Straylight = 99
Tambi to Straylight = 70";

	var cycle = 0;
	var other = 0;

	foreach (var s in input.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries))
	{
		other++;

		var distance = s.Split().Reverse().Take(1).Select(x => Convert.ToInt32(x)).ToList();

		graph[cycle, cycle] = 50000;
		graph[cycle, other] = distance[0];
		graph[other, cycle] = distance[0];

		if (other > 6)
		{
			other = cycle + 1;
			cycle++;
		}
	}

	int shortest = 0;

	for (var i = 0; i < 8; i++)
	{
		shortest = Math.Max(shortest, solve(i, (1 << i)));
	}
	
	graph.Dump();
	shortest.Dump();
}

// Define other methods and classes here
public static int[,] graph = new int[8, 8];


public static int solve(int i, int j)
{
	if (j == ((1 << 8) - 1))
		return 0;

	int dist = 0;
	for (var k = 0; k < 8; k++)
	{
		if ((j & (1 << i)) == 0)
		{
			dist = Math.Max(dist, solve(k, j | (1 << k)) + graph[i, k]);
		}
	}

	return dist;
}