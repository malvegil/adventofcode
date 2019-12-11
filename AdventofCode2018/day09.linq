<Query Kind="Statements" />

var ending_marble = 7091800;
var players = new long[464];

var circle = new List<long>();

var score = 0;
circle.Add(0);
var current_player_index = 0;
var current_marble = 0;
var current_marble_index = 0;

while (current_marble != ending_marble)
{
	current_marble++;
	score = 0;
	if (current_marble % 23 == 0)
	{
		score += current_marble;
		players[current_player_index] += current_marble;
		if (current_marble_index < 7)
			current_marble_index += circle.Count - 7;
		else current_marble_index -= 7;

		players[current_player_index] += circle[current_marble_index];
		circle.RemoveAt(current_marble_index);
	}
	else
	{
		if (current_marble_index == circle.Count - 1)
			current_marble_index = 1;
		else if (current_marble_index == circle.Count - 2)
			current_marble_index = circle.Count;
		else
			current_marble_index += 2;
			
		circle.Insert(current_marble_index, current_marble);
	}

	if (current_player_index < players.Count() - 1)
		current_player_index++;
	else
		current_player_index = 0;
}

players.Max(p => p).Dump("Day 09 Part A");