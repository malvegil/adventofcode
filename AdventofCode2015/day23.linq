<Query Kind="Program">
  <Output>DataGrids</Output>
</Query>

void Main()
{
	var input = @"jio a, +19
inc a
tpl a
inc a
tpl a
inc a
tpl a
tpl a
inc a
inc a
tpl a
tpl a
inc a
inc a
tpl a
inc a
inc a
tpl a
jmp +23
tpl a
tpl a
inc a
inc a
tpl a
inc a
inc a
tpl a
inc a
tpl a
inc a
tpl a
inc a
tpl a
inc a
inc a
tpl a
inc a
inc a
tpl a
tpl a
inc a
jio a, +8
inc b
jie a, +4
tpl a
inc a
jmp +2
hlf a
jmp -7";

	var c = new Computer();
	c.StartComputer();
	c.InsertInstructions(input);
	c.RunInstructions();

	c.regA.Dump();
	c.regB.Dump();
}

// Define other methods and classes here
public class Computer
{
	public uint regA { get; set; }
	public uint regB { get; set; }

	private List<Instruction> instructions { get; set; }

	private class Instruction
	{
		public string inst { get; set; }
		public char reg { get; set; }
		public int j { get; set; }
	}

	public void StartComputer()
	{
		regA = 1;
		regB = 0;
		instructions = new List<UserQuery.Computer.Instruction>();
	}

	public void InsertInstructions(string input)
	{
		var regex = new Regex(@"((\w+) (a|b|[-+\d]+)(, ([-+\d]+))?)");
		foreach (var i in input.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries)
					.Select(s => regex.Match(s))
					.ToList())
		{
			var inst = new Instruction();
			inst.inst = i.Groups[2].Value;

			switch (i.Length)
			{
				case 5:
					inst.reg = (i.Groups[3].Value)[0];
					break;
				case 6:
				case 7:
					inst.j = Int32.Parse(i.Groups[3].Value);
					break;
				default:
					inst.reg = (i.Groups[3].Value)[0];
					inst.j = Int32.Parse(i.Groups[5].Value);
					break;
			}

			instructions.Add(inst);
		}
	}

	public void RunInstructions()
	{
		for (var i = 0; i < instructions.Count; i++)
		{
			switch (instructions[i].inst)
			{
				case "hlf":
					regA = instructions[i].reg == 'a' ? regA / 2 : regA;
					regB = instructions[i].reg == 'b' ? regB / 2 : regB;
					break;
				case "tpl":
					regA = instructions[i].reg == 'a' ? regA * 3 : regA;
					regB = instructions[i].reg == 'b' ? regB * 3 : regB;
					break;
				case "inc":
					regA = instructions[i].reg == 'a' ? regA + 1 : regA;
					regB = instructions[i].reg == 'b' ? regB + 1 : regB;
					break;
				case "jmp":
					i += instructions[i].j - 1;
					break;
				case "jie":
					if ((instructions[i].reg == 'a' && regA % 2 == 0) ||
						(instructions[i].reg == 'b' && regB % 2 == 0))
					{
						i += instructions[i].j - 1;
					}
					break;
				case "jio":
					if ((instructions[i].reg == 'a' && regA == 1) ||
						(instructions[i].reg == 'b' && regB == 1))
					{
						i += instructions[i].j - 1;
					}
					break;
				default:
					throw new InvalidOperationException("Bad Instruction");
			}
		}
	}
}