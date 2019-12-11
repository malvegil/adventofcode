<Query Kind="Program" />

void Main()
{
	var input = File.ReadAllLines(@"H:\Documents\LINQPad Queries\AdventofCode\AdventofCode\AdventofCode2017\day4a.txt");

	input.Sum(x => x.Split(' ').Count() == x.Split(' ').Distinct().Count() ? 1 : 0).Dump("Day 4 A");

	var badPassPhrases = 0;

	foreach (var pass in input.Where(x => x.Split(' ').Count() == x.Split(' ').Distinct().Count()))
	{
		var words = pass.Split(' ').Select(x => x).ToArray();
		var length = words.Count();
		for (var i = 0; i < length; i++)
		{
			for (var j = length - 1; j > i; j--)
			{
				if (isAnagram(words[i], words[j]))
				{
					badPassPhrases++;
					j = 0; i = length;
				}
			}
		}
	}

(input.Where(x => x.Split(' ').Count() == x.Split(' ').Distinct().Count()).Count() - badPassPhrases).Dump("Day 4 B");

}

// Define other methods and classes here
public static bool isAnagram(string s1, string s2)
{
	int[] c1 = new int[26];
	int[] c2 = new int[26];


	foreach (var i in s1.ToCharArray())
	{
		var pos = (int)(i) - (int)('a');
		c1[pos]++;
	}

	foreach (var i in s2.ToCharArray())
	{
		var pos = (int)(i) - (int)('a');
		c2[pos]++;
	}

	var j = 0;
	var stillOK = true;

	while (j < 26 && stillOK)
	{
		if (c1[j] == c2[j])
			j++;
		else
			stillOK = false;
	}

	return stillOK;
}
