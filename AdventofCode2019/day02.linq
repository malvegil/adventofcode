<Query Kind="Statements" />

var input = File.ReadAllLines(@"H:\Documents\LINQPad Queries\AdventofCode\AdventofCode\AdventofCode2019\day02a.txt").First().Split(',').Select(x => Int32.Parse(x)).ToArray();

//A
//Computer op codes.

input[1] = 12;
input[2] = 2;

var pos = 0;
while (input[pos] != 99)
{
	switch (input[pos])
	{
		case 1:
			input[input[pos + 3]] = input[input[pos + 1]] + input[input[pos + 2]];
			break;
		case 2:
			input[input[pos + 3]] = input[input[pos + 1]] * input[input[pos + 2]];
			break;
	}
	pos += 4;
}

input[0].Dump("Day 02 A");


//B //ran through a couple times of each x/y to see the pattern, then calculated the values because each x/y increase is the same amount in the final result
var test = 19690720;

for (int y = 0; y < 100; y++)
{
	for (int x = 0; x < 100; x++)
	{
		var _in = File.ReadAllLines(@"H:\Documents\LINQPad Queries\AdventofCode\AdventofCode\AdventofCode2019\day02a.txt").First().Split(',').Select(i => Int32.Parse(i)).ToArray();;
		_in[1] = x;
		_in[2] = y;

		pos = 0;
		try
		{
			while (_in[pos] != 99)
			{
				switch (_in[pos])
				{
					case 1:
						_in[_in[pos + 3]] = _in[_in[pos + 1]] + _in[_in[pos + 2]];
						break;
					case 2:
						_in[_in[pos + 3]] = _in[_in[pos + 1]] * _in[_in[pos + 2]];
						break;
				}
				pos += 4;
			}

			if (_in[0] == test)
			{
				_in[0].Dump("Day 02 B");
				x.Dump("Day 02 B X");
				y.Dump("Day 02 B Y");
				return;
			}
		}
		catch
		{
			//ignore the out of bounds issues
		}
	}
}
