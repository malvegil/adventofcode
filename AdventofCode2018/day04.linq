<Query Kind="Program" />

void Main()
{
	var input = File.ReadLines(@"H:\Documents\LINQPad Queries\AdventofCode\AdventofCode\AdventofCode2018\day04a.txt");
	var guard_regex = new Regex(@"(?<guard>#[\d]+) ");
	var records = new List<GuardRecord>();
	records = (from i in input
			   let a = i.Substring(19, 1)
			   let g = guard_regex.Match(i).Groups["guard"].Value.Trim('#')
			   select new GuardRecord()
			   {
				   ActionTime = DateTime.Parse(i.Substring(1, 16)),
				   Action = a.StartsWith("G") ? "Begin" :
							a.StartsWith("w") ? "Wake" :
							a.StartsWith("f") ? "Sleep" : "",
				   GuardID = !string.IsNullOrEmpty(g) ? Int32.Parse(g) : 0,
			   })
			   .OrderBy(i => i.ActionTime).ToList();

	var prev_id = 0;
	var sleep_time = 0;
	var GuardMinutes = new List<GuardSleepMinutes>();
	foreach (var r in records)
	{
		if (r.GuardID != 0) prev_id = r.GuardID;
		else r.GuardID = prev_id;
		switch (r.Action)
		{
			case "Sleep":
				sleep_time = r.ActionTime.Minute;
				break;
			case "Wake":
				r.SleepTime = r.ActionTime.Minute - sleep_time;
				GuardMinutes.AddRange(
					Enumerable.Range(0, r.ActionTime.Minute - sleep_time)
						.Select(x => new GuardSleepMinutes()
						{
							SleepMinute = sleep_time + x,
							Date = r.ActionTime.DayOfYear,
							GuardID = r.GuardID,
						}));
				break;
			case "Begin":
			default:
				sleep_time = 0;
				break;
		}
	}

	var sleepy_guard = records.GroupBy(r => r.GuardID).Select(r => new { GuardID = r.Key, SleepTime = r.Sum(g => g.SleepTime) }).OrderByDescending(r => r.SleepTime).First();
	var best_minute = GuardMinutes.Where(g => g.GuardID == sleepy_guard.GuardID).GroupBy(g => g.SleepMinute).Select(g => new { Minute = g.Key, Total = g.Count() }).OrderByDescending(g => g.Total).First();
	(best_minute.Minute * sleepy_guard.GuardID).Dump("Day 04 A");


	var sleepy_minute = GuardMinutes.GroupBy(r => new { GuardID = r.GuardID, Minute = r.SleepMinute }).Select(r => new { Item = r.Key, Count = r.Count() }).OrderByDescending(r => r.Count).First();
	(sleepy_minute.Item.GuardID * sleepy_minute.Item.Minute).Dump("Day 04 B");
}


public class GuardRecord
{
	public DateTime ActionTime;
	public string Action;
	public int GuardID;
	public int SleepTime;
}

public class GuardSleepMinutes
{
	public int SleepMinute;
	public int Date;
	public int GuardID;
}

