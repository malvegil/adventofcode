<Query Kind="Statements" />

var input = File.ReadAllLines(@"H:\Documents\LINQPad Queries\AdventofCode\AdventofCode\AdventofCode2018\day11a.txt");
var initial = Regex.Match(input.First(), @"initial state: (?<input>[#.]*)").Groups["input"].Value;
var instruction = new Regex(@"(?<i>[#.][#.][#.][#.][#.]) => (?<o>[#.])");
var instructions = (from i in input
					let m = instruction.Match(i)
					where m.Success
					select new
					{
						now = m.Groups["i"].Value,
						after = m.Groups["o"].Value.First(),
					}).ToList();

var how_many_to_left = 0;
long score = 0, lastScore = 0;
long diff = 0, prevDiff = 0;
var gens = 20;

for (var g = 1; g <= gens; g++) // 20 generations
{
	// if the plants have grown within the last 5 or first 5 add on more dots based on the index of the first or last #
	// if the string grows at the beginning add to HMTL	
	var _f = initial.IndexOf('#');
	while (_f < 5)
	{
		initial = "." + initial;
		how_many_to_left++;
		_f++;
	}
	var _l = initial.LastIndexOf('#');
	var end = _l + 5;
	while (_l < end)
	{
		initial = initial + ".";
		_l++;
	}

	var x = initial.ToArray();

	for (var i = 2; i < initial.Count() - 2; i++)
	{
		// check the value and create a new one
		var _s = initial.Substring(i - 2, 5);
		var _inst = instructions.Where(_ => _.now == _s).FirstOrDefault();
		if (_inst != null)
			x[i] = _inst.after;
	}
	// set initial back to the current string
	initial = new string(x);

	score = 0;
	for (int pos = 0; pos < initial.Length; pos++)
	{
		score += initial[pos].ToString() == "." ? 0 : pos - how_many_to_left;
	}
	diff = score - lastScore;
	if (diff == prevDiff)
	{
		score = score + (gens - (long)g) * prevDiff;
		break;
	}
	prevDiff = diff;
	lastScore = score;
}

score.Dump("Day 11 Part B");