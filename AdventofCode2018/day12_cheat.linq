<Query Kind="Program" />

static void Main(string[] args)
    {
        HashSet<int> currentPlants = new HashSet<int>();
        Dictionary<int, bool> plantRules = new Dictionary<int, bool>();
        StreamReader file = new StreamReader(@"H:\Documents\LINQPad Queries\AdventofCode\AdventofCode\AdventofCode2018\day11a.txt");

        string line = file.ReadLine();
        line.Skip(15).Select((x, i) => new { x, i }).Where(c => c.x == '#').Select(c => c.i).ToList().ForEach(x => currentPlants.Add(x));
        line = file.ReadLine();
        while (!file.EndOfStream)
        {
            line = file.ReadLine();
            int binary = line.Take(5).Select((x, i) => new { x, i }).Where(c => c.x == '#').Sum(c => (int)Math.Pow(2, c.i));
            plantRules.Add(binary, line[9] == '#' ? true : false);
        }

        long iterations = 50000000000;
        long totalSum = 0;
        HashSet<int> newPlants = new HashSet<int>();

        for (int iter = 1; iter <= iterations; iter++)
        {
            newPlants = new HashSet<int>();
            int min = currentPlants.Min() - 3;
            int max = currentPlants.Max() + 3;

            for (int pot = min; pot <= max; pot++)
            {
                int sum = 0;
                for (int i = 0; i < 5; i++)
			{
				if (currentPlants.Contains(pot + i - 2)) sum += (int)Math.Pow(2, i);
			}
			if (plantRules[sum]) newPlants.Add(pot);
		}
		// the simulation converged to a stable point
		if (currentPlants.Select(x => x + 1).Except(newPlants).Count() == 0)
		{
			currentPlants = newPlants;
			totalSum = currentPlants.Sum();
			totalSum += currentPlants.Count() * (iterations - iter);
			break;
		}

		currentPlants = newPlants;
	}

	Console.WriteLine(totalSum);
	Console.ReadLine();
}
