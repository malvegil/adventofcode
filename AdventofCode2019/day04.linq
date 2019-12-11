<Query Kind="Statements" />

var passwordsA = new List<int>();
var passwordsB = new List<int>();
var start = 136760;
var end = 595730;
var regA = new Regex(@"^(?=1*2*3*4*5*6*7*8*9*$).*(\d)\1");
var regB = new Regex(@"^(?=1*2*3*4*5*6*7*8*9*$).*(\d)(?<!(?=\1)..)\1(?!\1)");

foreach (var x in Enumerable.Range(start, end - start))
{
	if (regA.Match(x.ToString()).Success)
		passwordsA.Add(x);
	if (regB.Match(x.ToString()).Success)
		passwordsB.Add(x);
}

passwordsA.Count.Dump("Day 04 A");
passwordsB.Count.Dump("Day 04 B");

