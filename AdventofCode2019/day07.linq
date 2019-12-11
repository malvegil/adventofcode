<Query Kind="Program" />

void Main()
{
	var program = File.ReadAllLines(@"H:\Documents\LINQPad Queries\AdventofCode\AdventofCode\AdventofCode2019\day07a.txt").First().Split(',').Select(x => Int32.Parse(x)).ToArray();

	var output = new List<Tuple<string, int>>();

	var N = 4;
	for (var a = 0; a <= N; ++a)
		for (var b = 0; b <= N; ++b)
			if (b != a)
				for (var c = 0; c <= N; ++c)
					if (c != a && c != b)
						for (var d = 0; d <= N; ++d)
							if (d != a && d != b && d != c)
								for (var e = 0; e <= N; ++e)
									if (e != a && e != b && e != c && e != d)
									{
										var _out = Computer(program, 0, a);
										_out = Computer(program, _out, b);
										_out = Computer(program, _out, c);
										_out = Computer(program, _out, d);
										_out = Computer(program, _out, e);

										output.Add(Tuple.Create(string.Concat(a, b, c, d, e), _out));
									}

	output.Max(s => s.Item2).Dump("Day 07 A");
}

// Define other methods and classes here
public int Computer(int[] input, int _in, int phase)
{
	var _out1 = new List<int>();

	var pos = 0;
	while (input[pos] != 99)
	{
		var opcode = input[pos] % 10;
		var C1 = input[pos] / 100 % 10;
		var B2 = input[pos] / 1000 % 10;
		var A3 = input[pos] / 10000 % 10;

		switch (opcode)
		{
			case 1:
				input[input[pos + 3]] = //writing to A3 is always parameter mode
					(C1 == 1 ? input[pos + 1] : input[input[pos + 1]]) + //if C1 = 1 then we are in immediate mode
					(B2 == 1 ? input[pos + 2] : input[input[pos + 2]]);  //if B2 = 1 then we are in immediate mode
				pos += 4;
				break;
			case 2:
				input[input[pos + 3]] = //writing to A3 is always parameter mode
					(C1 == 1 ? input[pos + 1] : input[input[pos + 1]]) * //if C1 = 1 then we are in immediate mode
					(B2 == 1 ? input[pos + 2] : input[input[pos + 2]]);  //if B2 = 1 then we are in immediate mode
				pos += 4;
				break;
			case 3:
				input[input[pos + 1]] = phase;
				phase = _in;
				pos += 2;
				break;
			case 4:
				_out1.Add((C1 == 1 ? input[pos + 1] : input[input[pos + 1]]));
				pos += 2;
				break;
			case 5:
				pos = (C1 == 1 ? input[pos + 1] : input[input[pos + 1]]) != 0 ? // jump if true
					(B2 == 1 ? input[pos + 2] : input[input[pos + 2]]) :
					pos + 3;
				break;
			case 6:
				pos = (C1 == 1 ? input[pos + 1] : input[input[pos + 1]]) == 0 ? // jump if false
					(B2 == 1 ? input[pos + 2] : input[input[pos + 2]]) :
					pos + 3;
				break;
			case 7:
				input[input[pos + 3]] = //writing to A3 is always parameter mode
					((C1 == 1 ? input[pos + 1] : input[input[pos + 1]]) < //if C1 = 1 then we are in immediate mode
					(B2 == 1 ? input[pos + 2] : input[input[pos + 2]])) ?
					1 : 0;  //if B2 = 1 then we are in immediate mode
				pos += 4;
				break;
			case 8:
				input[input[pos + 3]] = //writing to A3 is always parameter mode
					((C1 == 1 ? input[pos + 1] : input[input[pos + 1]]) == //if C1 = 1 then we are in immediate mode
					(B2 == 1 ? input[pos + 2] : input[input[pos + 2]])) ?
					1 : 0;  //if B2 = 1 then we are in immediate mode			
				pos += 4;
				break;
		}
	}

	return _out1.First();
}