<Query Kind="Statements" />

var input = File.ReadAllLines(@"H:\Documents\LINQPad Queries\AdventofCode\AdventofCode\AdventofCode2018\day01a.txt");

var result = input.Sum(x => Int32.Parse(x)).Dump("Day 01 A");

var frequencies = new List<int>() { 0 };
result = 0;
var repeat = true;

while (repeat)
{
	foreach (var x in input)
	{
		result += Int32.Parse(x);
		if (frequencies.Contains(result))
		{
			result.Dump("Day 01 B");
			repeat = false;
			break;
		}
		frequencies.Add(result);
	};
}