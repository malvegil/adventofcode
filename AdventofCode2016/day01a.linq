<Query Kind="Program" />

void Main()
{
	var directions = "R4, R3, R5, L3, L5, R2, L2, R5, L2, R5, R5, R5, R1, R3, L2, L2, L1, R5, L3, R1, L2, R1, L3, L5, L1, R3, L4, R2, R4, L3, L1, R4, L4, R3, L5, L3, R188, R4, L1, R48, L5, R4, R71, R3, L2, R188, L3, R2, L3, R3, L5, L1, R1, L2, L4, L2, R5, L3, R3, R3, R4, L3, L4, R5, L4, L4, R3, R4, L4, R1, L3, L1, L1, R4, R1, L4, R1, L1, L3, R2, L2, R2, L1, R5, R3, R4, L5, R2, R5, L5, R1, R2, L1, L3, R3, R1, R3, L4, R4, L4, L1, R1, L2, L2, L4, R1, L3, R4, L2, R3, L1, L5, R4, R5, R2, R5, R1, R5, R1, R3, L3, L2, L2, L5, R2, L2, R5, R5, L2, R3, L5, R5, L2, R4, R2, L1, R3, L5, R3, R2, R5, L1, R3, L2, R2, R1".Split(new[] { ", " }, StringSplitOptions.None);

	var x = 0;
	var y = 0;
	char facing = 'N';
	var visitLocations = new List<>();

	foreach (var d in directions)
	{
		facing = Turn(facing, d[0]);
		switch (facing)
		{
			case 'N':
				y += Int32.Parse(d.Remove(0,1));
				break;
			case 'E':
				x += Int32.Parse(d.Remove(0, 1));
				break;
			case 'S':
				y -= Int32.Parse(d.Remove(0, 1));
				break;
			case 'W':
				x -= Int32.Parse(d.Remove(0, 1));
				break;
		}
	}
	
	x.Dump();
	y.Dump();
}

// Define other methods and classes here
public class Location
{
	int x { get; set; }
	int y { get; set; }
	bool visited { get; set;}
}
public static char Turn(char facing, char direction)
{
	switch (facing)
	{
		case 'N':
			return direction == 'R' ? 'E' : 'W';
		case 'E':
			return direction == 'R' ? 'S' : 'N';
		case 'S':
			return direction == 'R' ? 'W' : 'E';
		case 'W':
			return direction == 'R' ? 'N' : 'S';
	}
	
	return facing;
}
