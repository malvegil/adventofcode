<Query Kind="Statements" />

var input = @"33
14
18
20
45
35
16
35
1
13
18
13
50
44
48
6
24
41
30
42";

var containers = input.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries)
	.Select(x => Int32.Parse(x)).ToList();

var sums = Enumerable
	.Range(1, (1 << containers.Count) - 1)
	.Select(i => containers.Where((c, ind) => ((1 << ind) & i) != 0).ToList()); //powerset ftw!!

var exact_fill = sums.Where(c => c.Sum() == 150).ToList();
exact_fill.Count().Dump();

var minimum = exact_fill.Select(x => x.Count).Min();
var min = exact_fill.Count(x => x.Count == minimum);

minimum.Dump();
min.Dump();