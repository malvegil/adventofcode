<Query Kind="Program" />

void Main()
{
	var input = "0	5	10	0	11	14	13	4	11	8	8	7	1	4	12	11".Split(new string[] { "\t" }, StringSplitOptions.RemoveEmptyEntries)
		.Select(x => Int32.Parse(x)).ToArray();

	List<int[]> sorts = new List<int[]>();
	while (!sorts.Any(x => x.SequenceEqual(input)))
	{
		sorts.Add(input.ToArray());
		MoveBlocks(input);
	}

	sorts.Count.Dump("Day 6 A");

	sorts = new List<int[]>();
	while (!sorts.Any(x => x.SequenceEqual(input)))
	{
		sorts.Add((int[])input.Clone());
		MoveBlocks(input);
	}

	var seenIndex = sorts.IndexOf(sorts.First(x => x.SequenceEqual(input;)));
	var steps = sorts.Count() - seenIndex;
	
	steps.Dump("Day 6 B");
}

// Define other methods and classes here
private static void MoveBlocks(int[] input)
{
	var idx = input.ToList().IndexOf(input.Max());
	var blocks = input[idx];

	input[idx++] = 0;

	while (blocks > 0)
	{
		if (idx >= input.Length)
		{
			idx = 0;
		}

		input[idx++]++;
		blocks--;
	}
}

public static string PartTwo(string input)
{
	var words = input.Split(new string[] { "\t" }, StringSplitOptions.RemoveEmptyEntries);
	var banks = words.Select(x => int.Parse(x)).ToArray();
	var configs = new List<int[]>();

	while (!configs.Any(x => x.SequenceEqual(banks)))
	{
		configs.Add((int[])banks.Clone());
		MoveBlocks(banks);
	}

	var seenIndex = configs.IndexOf(configs.First(x => x.SequenceEqual(banks)));
	var steps = configs.Count() - seenIndex;

	return steps.ToString();
}