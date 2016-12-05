<Query Kind="Program">
  <Output>DataGrids</Output>
</Query>

void Main()
{
	ulong start_code = 20151125;
	var x = 3019;
	var y = 3010;

	var triangle_spot = x + y;
	var triangle_num = triangle_spot * (triangle_spot - 1) / 2;
	var code_spot = triangle_num - (y - 1);

	ulong code = start_code;

	for (var i = 0; i < code_spot - 1; i++)
	{
		code = ((code * 252533) % 33554393);
	}

	code.Dump();
	code_spot.Dump();
}

// Define other methods and classes here
