<Query Kind="Program" />

void Main()
{
	var input = File.ReadLines(@"H:\Documents\LINQPad Queries\AdventofCode\AdventofCode\AdventofCode2018\day19a.txt").ToArray();
	var reg_pointer = Int32.Parse(input[0][4].ToString());
	var regInst = new Regex(@"(?<w>[a-z]+) (?<x>\d+) (?<y>\d+) (?<z>\d+)");

	var instructions = (from i in input
						let m = regInst.Match(i)
						where m.Success
						select new
						{
							instr = m.Groups["w"].Value,
							A = Int32.Parse(m.Groups["x"].Value),
							B = Int32.Parse(m.Groups["y"].Value),
							C = Int32.Parse(m.Groups["z"].Value),
						}).ToArray();

	var reg = new[] { 1, 0, 0, 0, 0, 0 };

	var current_instruction = 0;

	while (current_instruction >= 0 && current_instruction < instructions.Count())
	{
		reg[reg_pointer] = current_instruction;
		var instr = instructions[current_instruction];
		switch (instr.instr)
		{
			case "gtir":
				reg[instr.C] = great(instr.A, reg[instr.B]);
				break;
			case "mulr":
				reg[instr.C] = multup(reg[instr.A], reg[instr.B]);
				break;
			case "seti":
				reg[instr.C] = instr.A;
				break;
			case "gtrr":
				reg[instr.C] = great(reg[instr.A], reg[instr.B]);
				break;
			case "bori":
				reg[instr.C] = bitor(reg[instr.A], instr.B);
				break;
			case "borr":
				reg[instr.C] = bitor(reg[instr.A], reg[instr.B]);
				break;
			case "banr":
				reg[instr.C] = bitand(reg[instr.A], reg[instr.B]);
				break;
			case "eqri":
				reg[instr.C] = equal(reg[instr.A], instr.B);
				break;
			case "bani":
				reg[instr.C] = bitand(reg[instr.A], instr.B);
				break;
			case "addr":
				reg[instr.C] = addup(reg[instr.A], reg[instr.B]);
				break;
			case "addi":
				reg[instr.C] = addup(reg[instr.A], instr.B);
				break;
			case "eqrr":
				reg[instr.C] = equal(reg[instr.A], reg[instr.B]);
				break;
			case "gtri":
				reg[instr.C] = great(reg[instr.A], instr.B);
				break;
			case "eqir":
				reg[instr.C] = equal(instr.A, reg[instr.B]);
				break;
			case "setr":
				reg[instr.C] = reg[instr.A];
				break;
			case "muli":
				reg[instr.C] = multup(reg[instr.A], instr.B);
				break;
		}

		current_instruction = reg[reg_pointer];
		current_instruction++;
	}

	reg[0].Dump("Day 16 Part B");
}

// Define other methods and classes here
public static Func<int, int, int> addup = (a, b) => a + b;
public static Func<int, int, int> multup = (a, b) => a * b;
public static Func<int, int, int> bitand = (a, b) => a & b;
public static Func<int, int, int> bitor = (a, b) => a | b;
public static Func<int, int, int> great = (a, b) => a > b ? 1 : 0;
public static Func<int, int, int> equal = (a, b) => a == b ? 1 : 0;

public class PartB
{
	public int Code;
	public int Instr;
}
