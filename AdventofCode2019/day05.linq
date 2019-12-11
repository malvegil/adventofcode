<Query Kind="Statements" />

var input = File.ReadAllLines(@"H:\Documents\LINQPad Queries\AdventofCode\AdventofCode\AdventofCode2019\day05a.txt").First().Split(',').Select(x => Int32.Parse(x)).ToArray();

//A
//Computer op codes extended.

var _in = 1;
var _out = new List<int>();

var pos = 0;
while (input[pos] != 99)
{
	var opcode = input[pos] % 10;
	var C1 = input[pos] / 100 % 10;
	var B2 = input[pos] / 1000 % 10;
	var A3 = input[pos] / 10000 % 10;

	switch (opcode)
	{
		case 1:
			input[input[pos + 3]] = //writing to A3 is always parameter mode
				(C1 == 1 ? input[pos + 1] : input[input[pos + 1]]) + //if C1 = 1 then we are in immediate mode
				(B2 == 1 ? input[pos + 2] : input[input[pos + 2]]);  //if B2 = 1 then we are in immediate mode
			pos += 4;
			break;
		case 2:
			input[input[pos + 3]] = //writing to A3 is always parameter mode
				(C1 == 1 ? input[pos + 1] : input[input[pos + 1]]) * //if C1 = 1 then we are in immediate mode
				(B2 == 1 ? input[pos + 2] : input[input[pos + 2]]);  //if B2 = 1 then we are in immediate mode
			pos += 4;
			break;
		case 3:
			input[input[pos + 1]] = _in;
			pos += 2;
			break;
		case 4:
			_out.Add((C1 == 1 ? input[pos + 1] : input[input[pos + 1]]));
			pos += 2;
			break;
	}

}

_out.Dump("Day 05 A");


//B
//Computer op codes extended again.

input = File.ReadAllLines(@"H:\Documents\LINQPad Queries\AdventofCode\AdventofCode\AdventofCode2019\day05a.txt").First().Split(',').Select(x => Int32.Parse(x)).ToArray();

_in = 5;
_out = new List<int>();

pos = 0;
while (input[pos] != 99)
{
	var opcode = input[pos] % 10;
	var C1 = input[pos] / 100 % 10;
	var B2 = input[pos] / 1000 % 10;
	var A3 = input[pos] / 10000 % 10;

	switch (opcode)
	{
		case 1:
			input[input[pos + 3]] = //writing to A3 is always parameter mode
				(C1 == 1 ? input[pos + 1] : input[input[pos + 1]]) + //if C1 = 1 then we are in immediate mode
				(B2 == 1 ? input[pos + 2] : input[input[pos + 2]]);  //if B2 = 1 then we are in immediate mode
			pos += 4;
			break;
		case 2:
			input[input[pos + 3]] = //writing to A3 is always parameter mode
				(C1 == 1 ? input[pos + 1] : input[input[pos + 1]]) * //if C1 = 1 then we are in immediate mode
				(B2 == 1 ? input[pos + 2] : input[input[pos + 2]]);  //if B2 = 1 then we are in immediate mode
			pos += 4;
			break;
		case 3:
			input[input[pos + 1]] = _in;
			pos += 2;
			break;
		case 4:
			_out.Add((C1 == 1 ? input[pos + 1] : input[input[pos + 1]]));
			pos += 2;
			break;
		case 5:
			pos = (C1 == 1 ? input[pos + 1] : input[input[pos + 1]]) != 0 ? // jump if true
				(B2 == 1 ? input[pos + 2] : input[input[pos + 2]]) : 
				pos + 3; 
			break;
		case 6:
			pos = (C1 == 1 ? input[pos + 1] : input[input[pos + 1]]) == 0 ? // jump if false
				(B2 == 1 ? input[pos + 2] : input[input[pos + 2]]) : 
				pos + 3; 
			break;
		case 7:
			input[input[pos + 3]] = //writing to A3 is always parameter mode
				((C1 == 1 ? input[pos + 1] : input[input[pos + 1]]) < //if C1 = 1 then we are in immediate mode
				(B2 == 1 ? input[pos + 2] : input[input[pos + 2]])) ?
				1 : 0;  //if B2 = 1 then we are in immediate mode
			pos += 4;
			break;
		case 8:
			input[input[pos + 3]] = //writing to A3 is always parameter mode
				((C1 == 1 ? input[pos + 1] : input[input[pos + 1]]) == //if C1 = 1 then we are in immediate mode
				(B2 == 1 ? input[pos + 2] : input[input[pos + 2]])) ?
				1 : 0;  //if B2 = 1 then we are in immediate mode			
			pos += 4;
			break;
	}

}

_out.Dump("Day 05 B");