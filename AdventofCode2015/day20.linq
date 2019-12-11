<Query Kind="Program">
  <Output>DataGrids</Output>
</Query>

void Main()
{
	var packages = 29000000;
	int[] houses = new int[50000000];

	//part 1
	//	for (int i = 1; i < houses.Count(); i++)
	//	{
	//		for (int j = 1; j <= Math.Sqrt(i); j++)
	//		{
	//			if (i % j == 0)
	//			{
	//				houses[i] += (j * 10) + ((i / j) * 10);
	//			}
	//		}
	//
	//		if (houses[i] >= 29000000)
	//		{
	//			i.Dump();
	//			houses[i].Dump();
	//		}
	//	}

	//part 2
	for (int e = 1; e < 1000000; e++)
	{
		for (var i = e; i <= 50 * e; i += e)
		{
			houses[i] += e * 11;
		}
	}

	for (int i = 1; i < 5000000; i++)
	{
		if (houses[i] > 29000000)
		{
			i.Dump();
			break;
		}
	}
}

// Define other methods and classes here