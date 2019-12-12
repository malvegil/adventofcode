<Query Kind="Program" />

void Main()
{
	var input = File.ReadAllLines(@"H:\Documents\LINQPad Queries\AdventofCode\AdventofCode\AdventofCode2016\day15.txt");

	//A
	//Rotating discs with dropped capsules
	//Could probably figure this out with maths...

	var time = 0;
	var discs = new List<Disc>()
	{
		new Disc(10,13,1),
		new Disc(15,17,2),
		new Disc(17,19,3),
		new Disc(1,7,4),
		new Disc(0,5,5),
		new Disc(1,3,6),
	};

	while (!CheckDiscs(discs))
	{
		foreach (var d in discs)
			d.Rotate();

		time++;
	}

	time.Dump("Day 15 A");

	//Part B 7 Discs
	time = 0;
	discs = new List<Disc>()
	{
		new Disc(10,13,1),
		new Disc(15,17,2),
		new Disc(17,19,3),
		new Disc(1,7,4),
		new Disc(0,5,5),
		new Disc(1,3,6),
		new Disc(0,11,7),
	};

	while (!CheckDiscs(discs))
	{
		foreach (var d in discs)
			d.Rotate();

		time++;
	}

	time.Dump("Day 15 B");
}

// Define other methods and classes here
public class Disc
{
	public int position { get; set; }
	public int positions { get; }
	public int number { get; }

	public Disc(int init, int pos, int num)
	{
		position = init;
		positions = pos;
		number = num;
	}

	public void Rotate()
	{
		position = (position == positions - 1) ? 0 : position + 1;
	}
}

public bool CheckDiscs(List<Disc> discs)
{
	foreach (var d in discs)
	{
		if (d.number == 1 && d.position != 12)
			return false;
		if (d.number == 2 && d.position != 15)
			return false;
		if (d.number == 3 && d.position != 16)
			return false;
		if (d.number == 4 && d.position != 3)
			return false;
		if (d.number == 5 && d.position != 0)
			return false;
		if (d.number == 6 && d.position != 0)
			return false;
		if (d.number == 7 && d.position != 4)
			return false;
	}
	return true;
}