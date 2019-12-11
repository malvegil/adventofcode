<Query Kind="Program" />

void Main()
{
	var regex1 = new Regex(@"(?<command>[\d\w]+) (?<arg1>[\d\w]+) (?<arg2>[-\d\w]+)");
	var regex2 = new Regex(@"(?<command>[\d\w]+) (?<arg1>[\d\w]+)");
	var input = File.ReadLines(@"H:\Documents\LINQPad Queries\AdventofCode\AdventofCode\AdventofCode2016\day12.txt").Select(x => regex1.IsMatch(x) ? regex1.Match(x) : regex2.Match(x)).ToArray();

	var registers = new int[4] { 0, 0, 0, 0 };
	var cur_instr = 0;
	while (cur_instr < input.Count())
	{
		switch (input[cur_instr].Groups["command"].Value)
		{
			case "cpy":
				int valueToCopy;
				if (!Int32.TryParse(input[cur_instr].Groups["arg1"].Value, out valueToCopy))
					valueToCopy = registers[ReturnRegisterIndex(input[cur_instr].Groups["arg1"].Value.First())];

				registers[ReturnRegisterIndex(input[cur_instr].Groups["arg2"].Value.First())] = valueToCopy;
				cur_instr++;
				break;
			case "inc":
				registers[ReturnRegisterIndex(input[cur_instr].Groups["arg1"].Value.First())]++;
				cur_instr++;
				break;
			case "dec":
				registers[ReturnRegisterIndex(input[cur_instr].Groups["arg1"].Value.First())]--;
				cur_instr++;
				break;
			case "jnz":
				int reg1;
				if (!Int32.TryParse(input[cur_instr].Groups["arg1"].Value, out reg1))
					reg1 = registers[ReturnRegisterIndex(input[cur_instr].Groups["arg1"].Value.First())];
				if (reg1 != 0)
					cur_instr += Int32.Parse(input[cur_instr].Groups["arg2"].Value);
				else 
					cur_instr++;
				break;
			default:
				Console.Write("Error Command");
				break;
		}
	}

	registers[0].Dump("Day 12 A");

	registers = new int[4] { 0, 0, 1, 0 };
	cur_instr = 0;
	while (cur_instr < input.Count())
	{
		switch (input[cur_instr].Groups["command"].Value)
		{
			case "cpy":
				int valueToCopy;
				if (!Int32.TryParse(input[cur_instr].Groups["arg1"].Value, out valueToCopy))
					valueToCopy = registers[ReturnRegisterIndex(input[cur_instr].Groups["arg1"].Value.First())];

				registers[ReturnRegisterIndex(input[cur_instr].Groups["arg2"].Value.First())] = valueToCopy;
				cur_instr++;
				break;
			case "inc":
				registers[ReturnRegisterIndex(input[cur_instr].Groups["arg1"].Value.First())]++;
				cur_instr++;
				break;
			case "dec":
				registers[ReturnRegisterIndex(input[cur_instr].Groups["arg1"].Value.First())]--;
				cur_instr++;
				break;
			case "jnz":
				int reg1;
				if (!Int32.TryParse(input[cur_instr].Groups["arg1"].Value, out reg1))
					reg1 = registers[ReturnRegisterIndex(input[cur_instr].Groups["arg1"].Value.First())];
				if (reg1 != 0)
					cur_instr += Int32.Parse(input[cur_instr].Groups["arg2"].Value);
				else
					cur_instr++;
				break;
			default:
				Console.Write("Error Command");
				break;
		}
	}

	registers[0].Dump("Day 12 B");
}

// Define other methods and classes here
public int ReturnRegisterIndex(char r)
{
	switch (r)
	{
		case 'A':
		case 'a':
			return 0;
		case 'B':
		case 'b':
			return 1;
		case 'C':
		case 'c':
			return 2;
		case 'D':
		case 'd':
			return 3;
		default:
			Console.Write("Error Register");
			return 99;
	}
}