<Query Kind="Statements" />

var input = File.ReadAllLines(@"H:\Documents\LINQPad Queries\AdventofCode\AdventofCode\AdventofCode2019\day08a.txt").First().ToCharArray().Select(x => Int32.Parse(x.ToString())).ToArray();
var index = 0;
var layers = new List<Tuple<int, int, int>>();
while (index < input.Count())
{
	var zeros = 0;
	var ones = 0;
	var twos = 0;
	foreach (var p in Enumerable.Range(1, 25 * 6))
	{
		switch (input[index])
		{
			case 0:
				zeros++;
				break;
			case 1:
				ones++;
				break;
			case 2:
				twos++;
				break;
		}
		index++;
	}
	var new_layer = Tuple.Create(zeros, ones, twos);
	layers.Add(new_layer);
}

layers.OrderBy(x => x.Item1).Select(x => x.Item2 * x.Item3).First().Dump("Day 08 A");

//Part B
index = 0;
var image = new char[6, 25]; //y,x 
foreach (var y in Enumerable.Range(0, 6))
	foreach (var x in Enumerable.Range(0, 25))
	{
		//set transparency first
		image[y, x] = 'I';
	}
while (index < input.Count())
{
	foreach (var y in Enumerable.Range(0, 6))
		foreach (var x in Enumerable.Range(0, 25))
		{
			switch (input[index])
			{
				case 2:
					break;
				case 1:
					if (image[y, x] == 'I')
						image[y, x] = 'X';
						break;
				case 0:
					if (image[y, x] == 'I')
						image[y, x] = ' ';
					break;
			}
			index++;
		}
}

image.Dump();
