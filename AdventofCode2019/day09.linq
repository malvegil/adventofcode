<Query Kind="Program" />

void Main()
{
	var program = new long[10000];

	var data = File.ReadAllLines(@"H:\Documents\LINQPad Queries\AdventofCode\AdventofCode\AdventofCode2019\day09a.txt").First().Split(',').Select(x => long.Parse(x)).ToArray();
	//data = "109,1,204,-1,1001,100,1,100,1008,100,16,101,1006,101,0,99".Split(',').Select(x => long.Parse(x)).ToArray();

	for (var i = 0; i < data.Length; i++)
	{
		program[i] = data[i];
	}

	var _outA = Computer(program, 1);

	_outA.Dump("Day 09 A");
	
	var _outB = Computer(program, 2);
	
	_outB.Dump("Day 09 B");
}

// Define other methods and classes here
public List<long> Computer(long[] input, int _in)
{
	var _out1 = new List<long>();
	long _base = 0;

	long pos = 0;
	while (input[pos] != 99)
	{
		var i = input[pos];
		var opcode = input[pos] % 10;
		var C1 = input[pos] / 100 % 10;
		var B2 = input[pos] / 1000 % 10;
		var A3 = input[pos] / 10000 % 10;

		long param1 = 0;
		long param2 = 0;
		long param3 = 0;

		if (new long[] { 1, 2, 4, 5, 6, 7, 8, 9 }.Contains(opcode))
			switch (C1)
			{
				case 0:
					param1 = input[input[pos + 1]]; //position mode
					break;
				case 1:
					param1 = input[pos + 1]; //immediate mode
					break;
				case 2:
					param1 = input[input[pos + 1] + _base]; // relative mode
					break;
			}

		if (new long[] { 1, 2, 5, 6, 7, 8 }.Contains(opcode))
			switch (B2)
			{
				case 0:
					param2 = input[input[pos + 2]]; //position mode
					break;
				case 1:
					param2 = input[pos + 2]; //immediate mode
					break;
				case 2:
					param2 = input[input[pos + 2] + _base]; // relative mode
					break;
			}

		if (new long[] { 1, 2, 7, 8 }.Contains(opcode))
			switch (A3)
			{
				case 0:
					param3 = input[pos + 3]; //position mode
					break;
				case 1:
					param3 = pos + 3; //immediate mode
					break;
				case 2:
					param3 = input[pos + 3] + _base; // relative mode
					break;
			}
			
		switch (opcode)
		{
			case 1:
				input[param3] = param1 + param2;
				pos += 4;
				break;
			case 2:
				input[param3] = param1 * param2;
				pos += 4;
				break;
			case 3:
				if (C1 == 2)
					input[input[pos + 1] + _base] = _in;
				else
					input[input[pos + 1]] = _in;
				pos += 2;
				break;
			case 4:
				_out1.Add(param1);
				pos += 2;
				break;
			case 5:
				pos = param1 != 0 ? param2 : pos + 3; // jump if true
				break;
			case 6:
				pos = param1 == 0 ? param2 : pos + 3; // jump if false
				break;
			case 7:
				input[param3] = (param1 < param2) ? 1 : 0;
				pos += 4;
				break;
			case 8:
				input[param3] = (param1 == param2) ? 1 : 0;
				pos += 4;
				break;
			case 9:
				_base += param1;
				pos += 2;
				break;
		}
	}

	return _out1;
}