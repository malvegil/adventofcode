<Query Kind="Program" />

void Main()
{
	var input = File.ReadLines(@"H:\Documents\LINQPad Queries\AdventofCode\AdventofCode\AdventofCode2018\day16a.txt").ToArray();
	var regBefore = new Regex(@"Before: \[(?<w>\d+), (?<x>\d+), (?<y>\d+), (?<z>\d+)\]");
	var regAfter = new Regex(@"After:  \[(?<w>\d+), (?<x>\d+), (?<y>\d+), (?<z>\d+)\]");
	var regInst = new Regex(@"(?<w>\d+) (?<x>\d+) (?<y>\d+) (?<z>\d+)");

	var bh3 = 0;
	var inst_codes = new List<PartB>();

	for (var i = 0; i < input.Count(); i += 4)
	{
		var bh = 0;
		var a = regBefore.Match(input[i]).Groups;
		var b = regInst.Match(input[i + 1]).Groups;
		var c = regAfter.Match(input[i + 2]).Groups;
		var old_reg = new int[] { Int32.Parse(a["w"].Value), Int32.Parse(a["x"].Value), Int32.Parse(a["y"].Value), Int32.Parse(a["z"].Value) };
		var instr = new int[] { Int32.Parse(b["w"].Value), Int32.Parse(b["x"].Value), Int32.Parse(b["y"].Value), Int32.Parse(b["z"].Value) };
		var new_reg = new int[] { Int32.Parse(c["w"].Value), Int32.Parse(c["x"].Value), Int32.Parse(c["y"].Value), Int32.Parse(c["z"].Value) };

		// 0 addr 9
		//if (new_reg[instr[3]] == addup(old_reg[instr[1]], old_reg[instr[2]])) { bh++; inst_codes.Add(new PartB() { Instr = instr[0], Code = 0, }); }
		// 1 addi 10
		//if (new_reg[instr[3]] == addup(old_reg[instr[1]], instr[2])) { bh++; inst_codes.Add(new PartB() { Instr = instr[0], Code = 1, }); }
		// 2 mulr 1
		//if (new_reg[instr[3]] == multup(old_reg[instr[1]], old_reg[instr[2]])) { bh++; inst_codes.Add(new PartB() { Instr = instr[0], Code = 2, }); }
		// 3 muli 15
		//if (new_reg[instr[3]] == multup(old_reg[instr[1]], instr[2])) { bh++; inst_codes.Add(new PartB() { Instr = instr[0], Code = 3, }); }
		// 4 banr 6
		//if (new_reg[instr[3]] == bitand(old_reg[instr[1]], old_reg[instr[2]])) { bh++; inst_codes.Add(new PartB() { Instr = instr[0], Code = 4, }); }
		// 5 bani 8
		//if (new_reg[instr[3]] == bitand(old_reg[instr[1]], instr[2])) { bh++; inst_codes.Add(new PartB() { Instr = instr[0], Code = 5, }); }
		// 6 borr 5
		//if (new_reg[instr[3]] == bitor(old_reg[instr[1]], old_reg[instr[2]])) { bh++; inst_codes.Add(new PartB() { Instr = instr[0], Code = 6, }); }
		// 7 bori 4
		//if (new_reg[instr[3]] == bitor(old_reg[instr[1]], instr[2])) { bh++; inst_codes.Add(new PartB() { Instr = instr[0], Code = 7, }); }
		// 8 setr 14
		//if (new_reg[instr[3]] == old_reg[instr[1]]) { bh++; inst_codes.Add(new PartB() { Instr = instr[0], Code = 8, }); }
		// 9 seti 2
		//if (new_reg[instr[3]] == instr[1]) { bh++; inst_codes.Add(new PartB() { Instr = instr[0], Code = 9, }); }
		//10 gtir 0
		//if (new_reg[instr[3]] == great(instr[1], old_reg[instr[2]])) { bh++; inst_codes.Add(new PartB() { Instr = instr[0], Code = 10, }); }
		//11 gtri 12
		//if (new_reg[instr[3]] == great(old_reg[instr[1]], instr[2])) { bh++; inst_codes.Add(new PartB() { Instr = instr[0], Code = 11, }); }
		//12 gtrr 3
		//if (new_reg[instr[3]] == great(old_reg[instr[1]], old_reg[instr[2]])) { bh++; inst_codes.Add(new PartB() { Instr = instr[0], Code = 12, }); }
		//13 eqir 13
		//if (new_reg[instr[3]] == equal(instr[1], old_reg[instr[2]])) { bh++; inst_codes.Add(new PartB() { Instr = instr[0], Code = 13, }); }
		//14 eqri 7
		//if (new_reg[instr[3]] == equal(old_reg[instr[1]], instr[2])) { bh++; inst_codes.Add(new PartB() { Instr = instr[0], Code = 14, }); }
		//15 eqrr 11
		//if (new_reg[instr[3]] == equal(old_reg[instr[1]], old_reg[instr[2]])) { bh++; inst_codes.Add(new PartB() { Instr = instr[0], Code = 15, }); }

		if (bh >= 3) bh3++;
		if (bh == 1)
		{
			inst_codes.Where(x => x.Instr == instr[0]).Distinct().Dump();
			i = 10000000;
		}
	}

	bh3.Dump("Day 16 Part A");

	var input2 = File.ReadLines(@"H:\Documents\LINQPad Queries\AdventofCode\AdventofCode\AdventofCode2018\day16b.txt").ToArray();
	var reg = new[] { 0, 0, 0, 0 };

	for (var i = 0; i < input2.Count(); i++)
	{
		var b = regInst.Match(input2[i]).Groups;
		var instr = new int[] { Int32.Parse(b["w"].Value), Int32.Parse(b["x"].Value), Int32.Parse(b["y"].Value), Int32.Parse(b["z"].Value) };

		switch (instr[0])
		{
			case 0:
				reg[instr[3]] = great(instr[1], reg[instr[2]]);
				break;
			case 1:
				reg[instr[3]] = multup(reg[instr[1]], reg[instr[2]]);
				break;
			case 2:
				reg[instr[3]] = instr[1];
				break;
			case 3:
				reg[instr[3]] = great(reg[instr[1]], reg[instr[2]]);
				break;
			case 4:
				reg[instr[3]] = bitor(reg[instr[1]], instr[2]);
				break;
			case 5:
				reg[instr[3]] = bitor(reg[instr[1]], reg[instr[2]]);
				break;
			case 6:
				reg[instr[3]] = bitand(reg[instr[1]], reg[instr[2]]);
				break;
			case 7:
				reg[instr[3]] = equal(reg[instr[1]], instr[2]);
				break;
			case 8:
				reg[instr[3]] = bitand(reg[instr[1]], instr[2]);
				break;
			case 9:
				reg[instr[3]] = addup(reg[instr[1]], reg[instr[2]]);
				break;
			case 10:
				reg[instr[3]] = addup(reg[instr[1]], instr[2]);
				break;
			case 11:
				reg[instr[3]] = equal(reg[instr[1]], reg[instr[2]]);
				break;
			case 12:
				reg[instr[3]] = great(reg[instr[1]], instr[2]);
				break;
			case 13:
				reg[instr[3]] = equal(instr[1], reg[instr[2]]);
				break;
			case 14:
				reg[instr[3]] = reg[instr[1]];
				break;
			case 15:
				reg[instr[3]] = multup(reg[instr[1]], instr[2]);
				break;
		}
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
