<Query Kind="Statements">
  <Output>DataGrids</Output>
</Query>

ulong row = 1;
ulong column = 1;
ulong startCode = 20151125;
ulong code = startCode;

while (true)
{
	row -= 1;
	column += 1;

	if (row == 0)
	{
		row = column;
		column = 1;
	}

	code = ((code * 252533) % 33554393);
	if (row == 3010 && column == 3019)
	{
		code.Dump();
		break;
	}
}