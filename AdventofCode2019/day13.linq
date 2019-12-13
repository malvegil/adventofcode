<Query Kind="Program" />

void Main()
{
	//Part A what is on the screen?
	var program = new long[10000];
	var data = File.ReadAllLines(@"H:\Documents\LINQPad Queries\AdventofCode\AdventofCode\AdventofCode2019\day13a.txt").First().Split(',').Select(x => long.Parse(x)).ToArray();

	for (var i = 0; i < data.Length; i++)
	{
		program[i] = data[i];
	}

	var Screen = new Dictionary<Point, long>();
	var C = new Computer(program);
	while (C.HaltType != 99)
	{
		var output = C.RunComputer();
		Screen.Add(new Point() { x = output.x, y = output.y }, output.id);
	}

	Screen.Where(o => o.Value == 2).Count().Dump("Day 09 A");


	//Part B play the game
	program = new long[10000];
	data = File.ReadAllLines(@"H:\Documents\LINQPad Queries\AdventofCode\AdventofCode\AdventofCode2019\day13a.txt").First().Split(',').Select(x => long.Parse(x)).ToArray();

	for (var i = 0; i < data.Length; i++)
	{
		program[i] = data[i];
	}

	var Screen2 = new List<Tile>();
	program[0] = 2; //insert quarters
	long score = 0;

	var C2 = new Computer(program);
	while (C2.HaltType != 99)
	{
		var output = C2.RunComputer();

		if (output.x == -1 && output.y == 0) //score time!
			score = output.id;

		var p = new Point() { x = output.x, y = output.y };

		if (Screen.ContainsKey(p) == false) //add new point to our screen
			Screen.Add(p, output.id);
		else
			Screen[p] = output.id; //update the block type

		if (output.id == 3) //update the paddle location
			C2.PaddleCoordinates = p;
		else if (output.id == 4) //update the ball location
			C2.BallCoordinates = p;

		if (C2.BallCoordinates != null && C2.PaddleCoordinates != null) //going to be null while we are still building the screen
			C2.Input = (C2.BallCoordinates.x < C2.PaddleCoordinates.x) ? -1 : //move the paddle to win!
					  (C2.BallCoordinates.x > C2.PaddleCoordinates.x) ? 1 :
					  0;
	}

	score.Dump("Day 09 B");
}

// Define other methods and classes here
public class Point
{
	public long x { get; set; }
	public long y { get; set; }
}

public class Tile
{
	public long x { get; set; }
	public long y { get; set; }
	public long id { get; set; }
};

public class Computer
{
	long _pos = 0;
	long _base = 0;

	public long[] Memory { get; set; }
	public int Input { get; set; }
	public long HaltType { get; set; } //still figuring out what types

	public Point BallCoordinates { get; set; }
	public Point PaddleCoordinates { get; set; }

	public Computer(long[] program)
	{
		Memory = program;
	}

	public Tile RunComputer()
	{
		var which_out = 0;
		var _tempTile = new Tile();

		while (which_out != 3)
		{
			var i = Memory[_pos];
			HaltType = i;
			if (HaltType == 99) return _tempTile;

			var opcode = Memory[_pos] % 10;
			var C1 = Memory[_pos] / 100 % 10;
			var B2 = Memory[_pos] / 1000 % 10;
			var A3 = Memory[_pos] / 10000 % 10;

			long param1 = 0;
			long param2 = 0;
			long param3 = 0;

			if (new long[] { 1, 2, 4, 5, 6, 7, 8, 9 }.Contains(opcode))
				switch (C1)
				{
					case 0:
						param1 = Memory[Memory[_pos + 1]]; //_position mode
						break;
					case 1:
						param1 = Memory[_pos + 1]; //immediate mode
						break;
					case 2:
						param1 = Memory[Memory[_pos + 1] + _base]; // relative mode
						break;
				}

			if (new long[] { 1, 2, 5, 6, 7, 8 }.Contains(opcode))
				switch (B2)
				{
					case 0:
						param2 = Memory[Memory[_pos + 2]]; //_position mode
						break;
					case 1:
						param2 = Memory[_pos + 2]; //immediate mode
						break;
					case 2:
						param2 = Memory[Memory[_pos + 2] + _base]; // relative mode
						break;
				}

			if (new long[] { 1, 2, 7, 8 }.Contains(opcode))
				switch (A3)
				{
					case 0:
						param3 = Memory[_pos + 3]; //_position mode
						break;
					case 1:
						param3 = _pos + 3; //immediate mode
						break;
					case 2:
						param3 = Memory[_pos + 3] + _base; // relative mode
						break;
				}

			switch (opcode)
			{
				case 1:
					Memory[param3] = param1 + param2;
					_pos += 4;
					break;
				case 2:
					Memory[param3] = param1 * param2;
					_pos += 4;
					break;
				case 3:
					if (C1 == 2)
						Memory[Memory[_pos + 1] + _base] = Input;
					else
						Memory[Memory[_pos + 1]] = Input;
					_pos += 2;
					break;
				case 4:
					switch (which_out)
					{
						case 0:
							_tempTile.x = param1;
							which_out++;
							break;
						case 1:
							_tempTile.y = param1;
							which_out++;
							break;
						case 2:
							_tempTile.id = param1;
							which_out++;
							break;
					}
					_pos += 2;
					break;
				case 5:
					_pos = param1 != 0 ? param2 : _pos + 3; // jump if true
					break;
				case 6:
					_pos = param1 == 0 ? param2 : _pos + 3; // jump if false
					break;
				case 7:
					Memory[param3] = (param1 < param2) ? 1 : 0;
					_pos += 4;
					break;
				case 8:
					Memory[param3] = (param1 == param2) ? 1 : 0;
					_pos += 4;
					break;
				case 9:
					_base += param1;
					_pos += 2;
					break;
			}
		}

		return _tempTile;
	}
}
