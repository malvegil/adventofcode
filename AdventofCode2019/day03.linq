<Query Kind="Statements" />

var input = File.ReadAllLines(@"H:\Documents\LINQPad Queries\AdventofCode\AdventofCode\AdventofCode2019\day03a.txt");
var A = input[0].Split(',').Select(a => new { d = a[0], l = Int32.Parse(a.Substring(1, a.Length - 1)), });
var B = input[1].Split(',').Select(a => new { d = a[0], l = Int32.Parse(a.Substring(1, a.Length - 1)), });

//A
//manhattan and directions.

var array = new List<Tuple<int, int, int, char>>(); //x,y,dist-start,val
var startX = 0;
var startY = 0;
var dist = 0;

foreach (var dir in A)
{
	switch (dir.d)
	{
		case 'R':
			for (var i = startX + 1; i <= dir.l + startX; i++)
			{
				dist++;
				array.Add(Tuple.Create(i, startY, dist, 'A'));
			};
			startX += dir.l;
			break;
		case 'L':
			for (var i = startX - 1; i >= startX - dir.l; i--)
			{
				dist++;
				array.Add(Tuple.Create(i, startY, dist, 'A'));
			};
			startX -= dir.l;
			break;
		case 'U':
			for (var i = startY + 1; i <= dir.l + startY; i++)
			{
				dist++;
				array.Add(Tuple.Create(startX, i, dist, 'A'));
			};
			startY += dir.l;
			break;
		case 'D':
			for (var i = startY - 1; i >= startY - dir.l; i--)
			{
				dist++;
				array.Add(Tuple.Create(startX, i, dist, 'A'));
			};
			startY -= dir.l;
			break;
	}
}

startX = 0;
startY = 0;
dist = 0;
foreach (var dir in B)
{
	switch (dir.d)
	{
		case 'R':
			for (var i = startX + 1; i <= dir.l + startX; i++)
			{
				dist++;
				array.Add(Tuple.Create(i, startY, dist, 'B'));
			};
			startX += dir.l;
			break;
		case 'L':
			for (var i = startX - 1; i >= startX - dir.l; i--)
			{
				dist++;
				array.Add(Tuple.Create(i, startY, dist, 'B'));
			};
			startX -= dir.l;
			break;
		case 'U':
			for (var i = startY + 1; i <= dir.l + startY; i++)
			{
				dist++;
				array.Add(Tuple.Create(startX, i, dist, 'B'));
			};
			startY += dir.l;
			break;
		case 'D':
			for (var i = startY - 1; i >= startY - dir.l; i--)
			{
				dist++;
				array.Add(Tuple.Create(startX, i, dist, 'B'));
			};
			startY -= dir.l;
			break;
	}
}

array
	.GroupBy(x => new { a = x.Item1, b = x.Item2 })
	.Where(y => y.Count(z => z.Item4 == 'A') > 0 && y.Count(z => z.Item4 == 'B') > 0)
	.Select(x => new { _ = x.Key, val = Math.Abs(x.Key.a) + Math.Abs(x.Key.b) })
	.Min(x => x.val)
	.Dump("Day 03 A");


//Part B
//closest intersection by signal delay

array
	.GroupBy(x => new { a = x.Item1, b = x.Item2 })
	.Where(y => y.Count(z => z.Item4 == 'A') > 0 && y.Count(z => z.Item4 == 'B') > 0)
	.Select(x => new { _ = x.Key, val = x.Where(a => a.Item4 == 'A').Min(a => a.Item3) + x.Where(a => a.Item4 == 'B').Min(a => a.Item3) })
	.Min(x => x.val)
	.Dump("Day 03 B");