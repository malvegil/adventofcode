<Query Kind="Statements" />

var E1 = 0;
var E2 = 1;
var scores = new List<int>();
scores.Add(3);
scores.Add(7);
var input = 380621;
var foundB = false;

while (scores.Count < input + 10)
{
	var new_score = scores[E1] + scores[E2];
	var part_1 = new_score / 10;
	var part_2 = new_score % 10;

	if (part_1 > 0) scores.Add(part_1);

	scores.Add(part_2);

	E1 += 1 + scores[E1];
	E2 += 1 + scores[E2];

	while (E1 >= scores.Count)
		E1 -= scores.Count;
	while (E2 >= scores.Count)
		E2 -= scores.Count;

	if (!foundB && scores.Count > 7 && (scores[scores.Count - 6]) * 100000 + (scores[scores.Count - 5]) * 10000 + (scores[scores.Count - 4]) * 1000 +(scores[scores.Count - 3]) * 100 + (scores[scores.Count - 2]) * 10 + (scores[scores.Count - 1]) == input)
	{
		(scores.Count - 6).Dump("Part B");
		foundB = true;
	}
}

for (var i = input; i < input + 10; i++)
{
	scores[i].Dump();
}

while (!foundB)
{
	var new_score = scores[E1] + scores[E2];
	var part_1 = new_score / 10;
	var part_2 = new_score % 10;

	if (part_1 > 0) scores.Add(part_1);

	scores.Add(part_2);

	E1 += 1 + scores[E1];
	E2 += 1 + scores[E2];

	while (E1 >= scores.Count)
		E1 -= scores.Count;
	while (E2 >= scores.Count)
		E2 -= scores.Count;

	if ((scores[scores.Count - 6]) * 100000 + (scores[scores.Count - 5]) * 10000 + (scores[scores.Count - 4]) * 1000 +
   (scores[scores.Count - 3]) * 100 + (scores[scores.Count - 2]) * 10 + (scores[scores.Count - 1]) == input)
	{
		(scores.Count - 6).Dump("Part B");
		foundB = true;
	}
}

(scores.Count - 6).Dump("Day 14 Part B");
