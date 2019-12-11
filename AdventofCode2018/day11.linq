<Query Kind="Statements" />

var partA = (from x in Enumerable.Range(1, 298)
			 from y in Enumerable.Range(1, 298)
			 let serial = 6548
			 let val = ((((x + 10) * y) + serial) * (x + 10) / 100 % 10)        // let x_1_y_1
			         + ((((x + 11) * y) + serial) * (x + 11) / 100 % 10)        // let x_2_y_1
			         + ((((x + 12) * y) + serial) * (x + 12) / 100 % 10)        // let x_3_y_1
			         + ((((x + 10) * (y + 1)) + serial) * (x + 10) / 100 % 10)  // let x_1_y_2
			         + ((((x + 11) * (y + 1)) + serial) * (x + 11) / 100 % 10)  // let x_2_y_2
			         + ((((x + 12) * (y + 1)) + serial) * (x + 12) / 100 % 10)  // let x_3_y_2
			         + ((((x + 10) * (y + 2)) + serial) * (x + 10) / 100 % 10)  // let x_1_y_3
			         + ((((x + 11) * (y + 2)) + serial) * (x + 11) / 100 % 10)  // let x_2_y_3
			         + ((((x + 12) * (y + 2)) + serial) * (x + 12) / 100 % 10)  // let x_3_y_3
			         - (9 * 5)
			 select new { x, y, val }).OrderByDescending(s => s.val).First().Dump("Day 10 Part A");
			 
var bx = 0;
var by = 0;
var bs = 0;
var best = 0;
int[,] sum = new int[301, 301];
for (int y = 1; y <= 300; y++)
{
	for (int x = 1; x <= 300; x++)
	{
		int id = x + 10;
		int p = id * y + 6548;
		p = (p * id) / 100 % 10 - 5;
		sum[y, x] = p + sum[y - 1, x] + sum[y, x - 1] - sum[y - 1, x - 1];
	}
}
for (int s = 1; s <= 300; s++)
{
	for (int y = s; y <= 300; y++)
	{
		for (int x = s; x <= 300; x++)
		{
			int total = sum[y, x] - sum[y - s, x] - sum[y, x - s] + sum[y - s, x - s];
			if (total > best)
			{
				best = total; bx = x; by = y; bs = s;
			}
		}
	}
}

Console.Write($"{bx - bs + 1},{by - bs + 1},{bs} Day 10 Part B");
