<Query Kind="Program" />

void Main()
{
	var output = new List<int>();

	var N = 9;
	for (var a = 5; a <= N; ++a)
		for (var b = 5; b <= N; ++b)
			if (b != a)
				for (var c = 5; c <= N; ++c)
					if (c != a && c != b)
						for (var d = 5; d <= N; ++d)
							if (d != a && d != b && d != c)
								for (var e = 5; e <= N; ++e)
									if (e != a && e != b && e != c && e != d)
									{
										Computer A = new Computer(a, "A");
										Computer B = new Computer(b, "B");
										Computer C = new Computer(c, "C");
										Computer D = new Computer(d, "D");
										Computer E = new Computer(e, "E");

										while (!E._stop)
										{
											A.RunComputer(E.output);
											B.RunComputer(A.output);
											C.RunComputer(B.output);
											D.RunComputer(C.output);
											E.RunComputer(D.output);
										}
										output.Add(E.output);
									}
	output.Max().Dump("Day 07 B");
}

// Define other methods and classes here
public class Computer
{
	int _pos = 0;
	int[] _mem = File.ReadAllLines(@"H:\Documents\LINQPad Queries\AdventofCode\AdventofCode\AdventofCode2019\day07a.txt").First().Split(',').Select(x => Int32.Parse(x)).ToArray();
	bool _firstrun = true;

	public int phase { get; set; }
	public int input { get; set; }
	public int output { get; set; }
	public string name { get; set; }
	public bool _stop { get; set; }

	public Computer(int ph, string n)
	{
		phase = ph;
		_stop = false;
		output = 0;
		name = n;
	}

	public void RunComputer(int newInput)
	{
		input = newInput;
		var opcode = _mem[_pos] % 10;
		var C1 = _mem[_pos] / 100 % 10;
		var B2 = _mem[_pos] / 1000 % 10;

		if (_mem[_pos] == 99)
			_stop = true;
		else if (opcode == 4)
		{
			output = (C1 == 1 ? _mem[_pos + 1] : _mem[_mem[_pos + 1]]);
			_pos += 2;
		}
		else
		{
			switch (opcode)
			{
				case 1:
					_mem[_mem[_pos + 3]] = //writing to A3 is always parameter mode
						(C1 == 1 ? _mem[_pos + 1] : _mem[_mem[_pos + 1]]) + //if C1 = 1 then we are in immediate mode
						(B2 == 1 ? _mem[_pos + 2] : _mem[_mem[_pos + 2]]);  //if B2 = 1 then we are in immediate mode
					_pos += 4;
					break;
				case 2:
					_mem[_mem[_pos + 3]] = //writing to A3 is always parameter mode
						(C1 == 1 ? _mem[_pos + 1] : _mem[_mem[_pos + 1]]) * //if C1 = 1 then we are in immediate mode
						(B2 == 1 ? _mem[_pos + 2] : _mem[_mem[_pos + 2]]);  //if B2 = 1 then we are in immediate mode
					_pos += 4;
					break;
				case 3:
					_mem[_mem[_pos + 1]] = _firstrun ? phase : input;
					_firstrun = false;
					_pos += 2;
					break;
				case 5:
					_pos = (C1 == 1 ? _mem[_pos + 1] : _mem[_mem[_pos + 1]]) != 0 ? // jump if true
						(B2 == 1 ? _mem[_pos + 2] : _mem[_mem[_pos + 2]]) :
						_pos + 3;
					break;
				case 6:
					_pos = (C1 == 1 ? _mem[_pos + 1] : _mem[_mem[_pos + 1]]) == 0 ? // jump if false
						(B2 == 1 ? _mem[_pos + 2] : _mem[_mem[_pos + 2]]) :
						_pos + 3;
					break;
				case 7:
					_mem[_mem[_pos + 3]] = //writing to A3 is always parameter mode
						((C1 == 1 ? _mem[_pos + 1] : _mem[_mem[_pos + 1]]) < //if C1 = 1 then we are in immediate mode
						(B2 == 1 ? _mem[_pos + 2] : _mem[_mem[_pos + 2]])) ?
						1 : 0;  //if B2 = 1 then we are in immediate mode
					_pos += 4;
					break;
				case 8:
					_mem[_mem[_pos + 3]] = //writing to A3 is always parameter mode
						((C1 == 1 ? _mem[_pos + 1] : _mem[_mem[_pos + 1]]) == //if C1 = 1 then we are in immediate mode
						(B2 == 1 ? _mem[_pos + 2] : _mem[_mem[_pos + 2]])) ?
						1 : 0;  //if B2 = 1 then we are in immediate mode			
					_pos += 4;
					break;
			}
			RunComputer(input);
		}
	}
}