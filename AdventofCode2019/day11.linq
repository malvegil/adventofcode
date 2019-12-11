<Query Kind="Statements" />

var panel = new char[100, 100];
for (int y = 0; y < 100; y++)
	for (int x = 0; x < 100; x++)
		panel[y, x] = '.';

var r_pos_x = 50;
var r_pos_y = 50;
var face = 0; // 0 is up, 1 is right, 2 is down, 3 is left

long _base = 0;
long _pos = 0;
long[] _mem = new long[10000];
bool _firstrun = true;
bool _firstout = true;

int input = 0;
long[] output = new long[2] { 0, 0 };

var data = File.ReadAllLines(@"H:\Documents\LINQPad Queries\AdventofCode\AdventofCode\AdventofCode2019\day11a.txt").First().Split(',').Select(x => long.Parse(x)).ToArray();
for (var i = 0; i < data.Length; i++)
{
	_mem[i] = data[i];
}
var painted_squares = new List<Tuple<int, int>>();

panel[r_pos_y, r_pos_x] = '#';

while (_mem[_pos] != 99)
{
	var i = _mem[_pos];
	var opcode = _mem[_pos] % 10;
	var C1 = _mem[_pos] / 100 % 10;
	var B2 = _mem[_pos] / 1000 % 10;
	var A3 = _mem[_pos] / 10000 % 10;

	long param1 = 0;
	long param2 = 0;
	long param3 = 0;

	if (new long[] { 1, 2, 4, 5, 6, 7, 8, 9 }.Contains(opcode))
		switch (C1)
		{
			case 0:
				param1 = _mem[_mem[_pos + 1]]; //_position mode
				break;
			case 1:
				param1 = _mem[_pos + 1]; //immediate mode
				break;
			case 2:
				param1 = _mem[_mem[_pos + 1] + _base]; // relative mode
				break;
		}

	if (new long[] { 1, 2, 5, 6, 7, 8 }.Contains(opcode))
		switch (B2)
		{
			case 0:
				param2 = _mem[_mem[_pos + 2]]; //_position mode
				break;
			case 1:
				param2 = _mem[_pos + 2]; //immediate mode
				break;
			case 2:
				param2 = _mem[_mem[_pos + 2] + _base]; // relative mode
				break;
		}

	if (new long[] { 1, 2, 7, 8 }.Contains(opcode))
		switch (A3)
		{
			case 0:
				param3 = _mem[_pos + 3]; //_position mode
				break;
			case 1:
				param3 = _pos + 3; //immediate mode
				break;
			case 2:
				param3 = _mem[_pos + 3] + _base; // relative mode
				break;
		}

	switch (opcode)
	{
		case 1:
			_mem[param3] = param1 + param2;
			_pos += 4;
			break;
		case 2:
			_mem[param3] = param1 * param2;
			_pos += 4;
			break;
		case 3:
			if (!_firstrun)
			{
				// paint the square
				panel[r_pos_y, r_pos_x] = output[0] == 0 ? '.' : '#';
				// add to list of painted coordinates
				painted_squares.Add(Tuple.Create(r_pos_y, r_pos_x));
				// update y,x coordinates
				if (output[1] == 0) // turn left
				{
					face = face == 0 ? 3 : face - 1; // 0 is up, 1 is right, 2 is down, 3 is left
													 // need to account where face needs to wrap from 3 to 0.
				}
				else // turn right
				{
					face = face == 3 ? 0 : face + 1; // need to account where face needs to wrap from 3 to 0.
				}
				//now move the robot forward one square
				switch (face)
				{
					case 0:
						r_pos_y++;
						break;
					case 1:
						r_pos_x++;
						break;
					case 2:
						r_pos_y--;
						break;
					case 3:
						r_pos_x--;
						break;
				}
			}
			_firstrun = false;
			// check the new value of painted to update input
			input = panel[r_pos_y, r_pos_x] == '.' ? 0 : 1;

			if (C1 == 2)
				_mem[_mem[_pos + 1] + _base] = input;
			else
				_mem[_mem[_pos + 1]] = input;
			_pos += 2;
			break;
		case 4:
			if (_firstout)
			{
				output[0] = param1;
				_firstout = false;
			}
			else
			{
				output[1] = param1;
				_firstout = true;
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
			_mem[param3] = (param1 < param2) ? 1 : 0;
			_pos += 4;
			break;
		case 8:
			_mem[param3] = (param1 == param2) ? 1 : 0;
			_pos += 4;
			break;
		case 9:
			_base += param1;
			_pos += 2;
			break;
	}
}


painted_squares.Dump("Day 11 A");

panel.Dump(); //Part B