<Query Kind="Statements" />

var input = File.ReadAllLines(@"H:\Documents\LINQPad Queries\AdventofCode\AdventofCode\AdventofCode2018\day02a.txt");

var two_count = 
	input
	.Select(x => x.ToCharArray())
	.Select(x => x.GroupBy(y => (int)y))
	.Where(x => x.Any(y => y.Count() == 2))
	.Count()
.Dump("Day 02 A 2x");

var three_count =
	input
	.Select(x => x.ToCharArray())
	.Select(x => x.GroupBy(y => (int)y))
	.Where(x => x.Any(y => y.Count() == 3))
	.Count()
.Dump("Day 02 A 3x");

(two_count * three_count).Dump("Day 02 A CheckSum");


for (var i = 0; i < input.Count(); i++)
	for (var j = i + 1; j < input.Count(); j++)
	{
		var l = input[i];
		var r = input[j];
		var idx = 0;
		var invalids = 0;
		var new_string = new char[26];
		while (idx < 26 && invalids <= 1)
		{
			if (l[idx] != r[idx])
				invalids++;
			else
				new_string[idx] = l[idx];
			idx++;
		}
		if (invalids <= 1)
		{ 
			l.Dump("Day 02 B 1st");
			r.Dump("Day 02 B 2nd");
			Console.Write(new_string);
		}
	}