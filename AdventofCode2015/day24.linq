<Query Kind="Program">
  <Output>DataGrids</Output>
</Query>

void Main()
{
	var input = @"1
2
3
7
11
13
17
19
23
31
37
41
43
47
53
59
61
67
71
73
79
83
89
97
101
103
107
109
113".Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries).Select(s => Int32.Parse(s)).ToArray();

	int total = input.Sum();
	long minQe = Split(input, 0, total / 3, 1, 0).Item1;
	Console.WriteLine(minQe);
	minQe = Split(input, 0, total / 4, 1, 0).Item1;
	Console.WriteLine(minQe);
}

// Define other methods and classes here
private static Tuple<long, int> Split(int[] weights, int p, int remaining, long QE, int count)
{
	if (remaining == 0) return new Tuple<long, int>(QE, count);
	else if (remaining < 0 || p == weights.Length) return new Tuple<long, int>(long.MaxValue, int.MaxValue);

	var included = Split(weights, p + 1, remaining - weights[p], QE * weights[p], count + 1);
	var notIncluded = Split(weights, p + 1, remaining, QE, count);

	if (included.Item2 < notIncluded.Item2)
	{
		return included;
	}
	else if (notIncluded.Item2 < included.Item2)
	{
		return notIncluded;
	}
	else
	{
		return (included.Item1 < notIncluded.Item1) ? included : notIncluded;
	}
}