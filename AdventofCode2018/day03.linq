<Query Kind="Program" />

void Main()
{
	var input = File.ReadLines(@"H:\Documents\LINQPad Queries\AdventofCode\AdventofCode\AdventofCode2018\day03a.txt");

	Square[,] uncut_fabric = new Square[1000, 1000];
	var used_more = 0;
	var cuts = new List<CustInstruction>();

	var regex = new Regex(@"#(?<index>\d+) @ (?<left>\d+),(?<top>\d+): (?<width>\d+)x(?<height>\d+)");

	foreach (var line in input)
	{
		var match = regex.Match(line);
		var ci = new CustInstruction()
		{
			Index = Int32.Parse(match.Groups["index"].Value),
			Left = Int32.Parse(match.Groups["left"].Value),
			Top = Int32.Parse(match.Groups["top"].Value),
			Width = Int32.Parse(match.Groups["width"].Value),
			Height = Int32.Parse(match.Groups["height"].Value),
			overlapped = false,
		};

		for (var l = ci.Left; l < ci.Left + ci.Width; l++)
		{
			for (var t = ci.Top; t < ci.Top + ci.Height; t++)
			{
				// create new square if we haven't before
				if (uncut_fabric[l, t] == null) uncut_fabric[l, t] = new Square() { TimesUsed = 0, LastIndex = 0, };
				// set number of uses for that square
				uncut_fabric[l, t].TimesUsed++;
				// if the square gets to the second use then increment for Part A
				if (uncut_fabric[l, t].TimesUsed == 2) used_more++;
				
				// Part B, if there is a last index then we need to make sure that cut is marked as overlapped
				if (uncut_fabric[l, t].LastIndex != 0)
				{
					cuts.Single(x => x.Index == uncut_fabric[l, t].LastIndex).overlapped = true;
				}
				// Then set the last index for this square to the current one
				// (could save some time and instructions by setting the last index to 0 if we already know this instruction is an overlap)
				uncut_fabric[l, t].LastIndex = ci.Index;
				// If THIS cut hasn't already been marked as overlapped, do so if it has been used already 
				ci.overlapped = ci.overlapped || uncut_fabric[l, t].TimesUsed > 1;
			}
		}
		cuts.Add(ci);
	}

	used_more.Dump("Day 03 A");
	cuts.Where(c => !c.overlapped).Select(c => c.Index).Dump("Day 03 B");
}

// Define other methods and classes here
public class CustInstruction
{
	public int Index { get; set; }
	public int Left { get; set; }
	public int Top { get; set; }
	public int Width { get; set; }
	public int Height { get; set; }
	public bool overlapped { get; set; }
};

public class Square
{
	public int TimesUsed { get; set; }
	public int LastIndex { get; set; }
}