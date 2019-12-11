<Query Kind="Statements" />

var input = File.ReadAllLines(@"H:\Documents\LINQPad Queries\AdventofCode\AdventofCode\AdventofCode2019\day01a.txt");

//A
//Fuel required to launch a given module is based on its mass. 
//Specifically, to find the fuel required for a module, take its mass, divide by three, round down, and subtract 2.

var result = input.Sum(x => (Int32.Parse(x) / 3) - 2).Dump("Day 01 A");

//B
//have to account for the weight of the fuel

long total = 0;

foreach (var x in input)
{
	int y = Int32.Parse(x);
	while (y > 0)
	{
		y = (y / 3) - 2;
		total += (y > 0) ? y : 0;
	}
}

total.Dump("Day 01 B");