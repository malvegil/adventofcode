<Query Kind="Statements" />

var input = File.ReadAllLines(@"H:\Documents\LINQPad Queries\AdventofCode\AdventofCode\AdventofCode2017\day5.txt").Select(x => Int32.Parse(x)).ToArray();
var currentInstruction = 0;
var steps = 0;

while (currentInstruction >= 0 && currentInstruction < input.Count())
{
	// read instruction
	var value = input[currentInstruction];
	// increment instruction
	input[currentInstruction]++;
	// jump
	currentInstruction += value;
	//increment steps
	steps++;
}
steps.Dump("Day 5 A");

input = File.ReadAllLines(@"H:\Documents\LINQPad Queries\AdventofCode\AdventofCode\AdventofCode2017\day5.txt").Select(x => Int32.Parse(x)).ToArray();
currentInstruction = 0;
steps = 0;

while (currentInstruction >= 0 && currentInstruction < input.Count())
{
	// read instruction
	var value = input[currentInstruction];
	// increment instruction
	if (value >= 3)
		input[currentInstruction]--;
	else
		input[currentInstruction]++;
	// jump
	currentInstruction += value;
	//increment steps
	steps++;
}
steps.Dump("Day 5 B");
