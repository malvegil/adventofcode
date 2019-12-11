<Query Kind="Program">
  <Connection>
    <ID>b914a3a0-c218-4e8f-be33-aa4f7c7df299</ID>
    <Driver>LinqToSql</Driver>
    <Server>prd-ari-sql-01.apx.apexdistribution.com</Server>
    <CustomAssemblyPath>P:\CorpIT\.NET Libraries\Production ARI DLLs\ApexDataModel.dll</CustomAssemblyPath>
    <CustomTypeName>ApexRemington.DAL.rempscoDataContext</CustomTypeName>
    <Database>compass</Database>
    <DisplayName>TP ARI Prod (rw)</DisplayName>
    <IsProduction>true</IsProduction>
    <SqlSecurity>true</SqlSecurity>
    <UserName>cesau-a</UserName>
    <Password>AQAAANCMnd8BFdERjHoAwE/Cl+sBAAAAwalhq/crP0+qFyQbb5jsvAAAAAACAAAAAAADZgAAwAAAABAAAADSS39WpEZFbNzq/6by7uWpAAAAAASAAACgAAAAEAAAALz1smKEM/yw6prnDWoz9/8gAAAAXMmic9cMoPBxUlm2nFOW3ZbGm9KIxDmydFyHujCUvXcUAAAAKvsXBJ3K6cBjUJ854Of7+we5vQ4=</Password>
  </Connection>
</Query>

void Main()
{
	var input = File.ReadLines(@"H:\Documents\LINQPad Queries\AdventofCode\AdventofCode\AdventofCode2018\day07a.txt").ToArray();
	var input_reg = new Regex(@"Step (?<A>[A-Z]) must be finished before step (?<B>[A-Z]) can begin.");
	
	
// PART A
	var orders = input.Select(i => new Order { Limit = input_reg.Match(i).Groups["A"].Value.First(), Result = input_reg.Match(i).Groups["B"].Value.First() }).ToList();
	var available = (from l in Enumerable.Range('A', 26)
					 select new Instruction
					 {
						 Letter = (char)l,
						 Available = false,
						 Order = 0,
					 }).ToList();

	var order = 1;

	while (available.Any(a => a.Order == 0))
	{
		orders = orders.Where(o => !available.Where(a => a.Available && a.Order != 0).Select(a => a.Letter).Contains(o.Limit)).ToList();

		foreach (var a in available)
		{
			if (!orders.Select(o => o.Result).Contains(a.Letter))
				a.Available = true;
		}

		foreach (var a in available.OrderBy(a => a.Letter))
		{
			if (a.Available && a.Order == 0)
			{
				a.Order = order;
				order++;
				break;
			}
		}
	}

	new string(available.OrderBy(a => a.Order).Select(a => a.Letter).ToArray()).Dump("Day 07 Part A");

// PART B
	order = 1;
	var timer = 0;
	var workers = 5;
	orders = input.Select(i => new Order { Limit = input_reg.Match(i).Groups["A"].Value.First(), Result = input_reg.Match(i).Groups["B"].Value.First() }).ToList();
	available = (from l in Enumerable.Range('A', 26)
				 select new Instruction
				 {
					 Letter = (char)l,
					 Available = false,
					 Order = 0,
					 TimeLeft = l - 'A' + 61,
				 }).ToList();


	while (available.Any(a => a.Order == 0))
	{
		orders = orders.Where(o => !available.Where(a => a.Available && a.Order != 0).Select(a => a.Letter).Contains(o.Limit)).ToList();

		foreach (var a in available)
		{
			if (!orders.Select(o => o.Result).Contains(a.Letter))
				a.Available = true;
		}

		foreach (var a in available.Where(a => a.Available && a.Order == 0).OrderBy(a => a.Letter))
		{
			if (a.Worker)
				a.TimeLeft--;

			if (a.TimeLeft == 0)
			{
				a.Order = order;
				order++;
				a.Worker = false;
				workers++;
			}
			else if (workers > 0 && !a.Worker)
			{
				a.Worker = true;
				workers--;
				a.TimeLeft--;
			}
		}
		timer++;
	}

	timer.Dump("Day 07 Part B Time");
	new string(available.OrderBy(a => a.Order).Select(a => a.Letter).ToArray()).Dump("Day 07 Part B Order");
}

// Define other methods and classes here
public class Instruction
{
	public char Letter;
	public bool Available;
	public int Order;
	public int TimeLeft;
	public bool Worker;
}

public class Order
{
	public char Limit;
	public char Result;
}