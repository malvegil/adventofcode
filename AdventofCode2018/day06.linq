<Query Kind="Program" />

void Main()
{
	var input = File.ReadLines(@"H:\Documents\LINQPad Queries\AdventofCode\AdventofCode\AdventofCode2018\day06a.txt").ToArray();
	var input_reg = new Regex(@"(?<x>\d+), (?<y>\d+)");
	var coordinates = (from idx in Enumerable.Range(0, input.Count())
					   let i = input[idx]
					   let r = input_reg.Match(i)
					   select new Coordinate
					   {
						   x = Int32.Parse(r.Groups["x"].Value),
						   y = Int32.Parse(r.Groups["y"].Value),
						   index = idx,
					   });

	// calculate a hundred manhatten points from each location and store into a group
	// plot on a grid that contains all the points and which one was closest
	// grid is 1 item bigger than the farthest points
	// get which item has the biggest area in the grid that also isn't touching the outside edge

	var min_x = coordinates.Min(x => x.x);
	var min_y = coordinates.Min(x => x.y);
	var max_x = coordinates.Max(x => x.x);
	var max_y = coordinates.Max(x => x.y);

	var m100 = coordinates.Select(c => Manhattan100(c, max_x, max_y)).SelectMany(c => c).ToList();

	var space = (from m in m100
				 //where m.x == 12 && m.y == 106 || m.x == 219 && m.y == 124
				 group m by new { m.dist, m.x, m.y } into closest
				 where closest.Count() == 1
				 orderby closest.Key.dist
				 select closest.First())
				 .GroupBy(
				 	x => new { x.x, x.y },
					(x, _) => new 
					{
						x = x.x,
						y = x.y,
						index = _.First().index,
						dist = _.First().dist,
					});
	//m100.Where(m => m.x == 12 && m.y == 106).Dump();
	space.GroupBy(s => s.index).Where(s => !s.Any(a => a.x == 0 || a.y == 0 || a.x == max_x || a.y == max_y)).OrderByDescending(o => o.Count()).Select(s => new {idx = s.Key, count = s.Count()}).Dump("Day 06 A");
}

// Define other methods and classes here
public class Coordinate
{
	public int x;
	public int y;
	public int? index;
	public int dist;
}

public List<Coordinate> Manhattan100(Coordinate c, int max_x, int max_y)
{
	return (from x in Enumerable.Range(0, max_x)
			from y in Enumerable.Range(0, max_y)
			let d = (Math.Abs(c.x - x) + Math.Abs(c.y - y))
			where d <= 1000
			select new Coordinate
			{
				x = x,
				y = y,
				index = c.index,
				dist = d,
			}).ToList();
}