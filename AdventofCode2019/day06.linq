<Query Kind="Statements" />

var input = File.ReadAllLines(@"H:\Documents\LINQPad Queries\AdventofCode\AdventofCode\AdventofCode2019\day06a.txt");

var objects = new List<string>();
var orbits = new List<Tuple<string, string>>();
var total_orbits = 0;

foreach (var i in input)
{
	var a = i.Split(')');
	if (!objects.Contains(a[0]))
		objects.Add(a[0]);
	if (!objects.Contains(a[1]))
		objects.Add(a[1]);

	orbits.Add(Tuple.Create(a[1], a[0]));
}

//Part A - Distance between all objects to center
foreach (var o in objects)
{
	var next = o;
	while (next != "COM")
	{
		total_orbits++;
		next = orbits.Single(x => x.Item1 == next).Item2;
	}
}

total_orbits.Dump("Day 06 A");

//Part B - distance between YOU and SAN
var nextY = "YOU";
var stepsY = new List<Tuple<string, int>>();
var distY = 0;
while (nextY != "COM")
{
	nextY = orbits.Single(x => x.Item1 == nextY).Item2;
	stepsY.Add(Tuple.Create(nextY, distY));
	distY++;
}
var nextS = "SAN";
var stepsS = new List<Tuple<string, int>>();
var distS = 0;
while (nextS != "COM")
{
	nextS = orbits.Single(x => x.Item1 == nextS).Item2;
	stepsS.Add(Tuple.Create(nextS, distS));
	distS++;
}

distS = stepsS.Where(s => stepsY.Select(y => y.Item1).Contains(s.Item1)).Min(x => x.Item2);
distY = stepsY.Where(y => stepsS.Select(s => s.Item1).Contains(y.Item1)).Min(x => x.Item2);


(distS + distY).Dump("Day 06 B");
