<Query Kind="Statements" />

var input = File.ReadAllLines(@"H:\Documents\LINQPad Queries\AdventofCode\AdventofCode\AdventofCode2017\day2a.txt");

var sum = input.Sum(x => Math.Abs(x.Split('\t').Max(y => Int32.Parse(y)) - x.Split('\t').Min(z => Int32.Parse(z))));

sum.Dump("Day 2 A");

sum = 0;

foreach (var line in input)
{
	var values = line.Split('\t').Select(x => Int32.Parse(x)).OrderByDescending(x => x).ToArray();
	var length = values.Count();
	for (var i = 0; i < length; i++)
	{
		for (var j = length - 1; j > i; j--)
		{
			if (values[i] % values[j] == 0)
			{
				sum += values[i] / values[j];
				j = 0; i = length;
			}
		}
	}
}

sum.Dump("Day 2 B");
