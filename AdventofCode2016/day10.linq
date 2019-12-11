<Query Kind="Statements" />

var input = File.ReadLines(@"H:\Documents\LINQPad Queries\AdventofCode\AdventofCode\AdventofCode2016\day10.txt");
var bots = new Dictionary<int, Action<int>>();
int[] outputs = new int[21];

var regex = new Regex(@"value (?<value>\d+) goes to bot (?<bot>\d+)|bot (?<source>\d+) gives low to (?<low>(bot|output)) (?<lowval>\d+) and high to (?<high>(bot|output)) (?<highval>\d+)");

foreach (var line in input.OrderBy(x => x))
{
	var match = regex.Match(line);
	if (match.Groups["value"].Success)
	{
		bots[int.Parse(match.Groups["bot"].Value)](int.Parse(match.Groups["value"].Value));
	}
	if (match.Groups["source"].Success)
	{
		List<int> vals = new List<int>();
		var botnum = int.Parse(match.Groups["source"].Value);
		bots[botnum] = (int n) =>
		{
			vals.Add(n);
			if (vals.Count == 2)
			{
				if (vals.Min() == 17 && vals.Max() == 61) botnum.Dump("Day 10 A");
				if (match.Groups["low"].Value == "bot")
				{
					bots[int.Parse(match.Groups["lowval"].Value)](vals.Min());
				}
				else
				{
					outputs[int.Parse(match.Groups["lowval"].Value)] = vals.Min();
				}
				if (match.Groups["high"].Value == "bot")
				{
					bots[int.Parse(match.Groups["highval"].Value)](vals.Max());
				}
				else
				{
					outputs[int.Parse(match.Groups["highval"].Value)] = vals.Max();
				}
			}
		};
	}
}

(outputs[0] * outputs[1] * outputs[2]).Dump("Day 10 B");
outputs.Dump("Day 10 B All Outputs");