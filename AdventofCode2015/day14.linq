<Query Kind="Program">
  <Output>DataGrids</Output>
</Query>

void Main()
{
	var input = @"Dancer can fly 27 km/s for 5 seconds, but then must rest for 132 seconds.
Cupid can fly 22 km/s for 2 seconds, but then must rest for 41 seconds.
Rudolph can fly 11 km/s for 5 seconds, but then must rest for 48 seconds.
Donner can fly 28 km/s for 5 seconds, but then must rest for 134 seconds.
Dasher can fly 4 km/s for 16 seconds, but then must rest for 55 seconds.
Blitzen can fly 14 km/s for 3 seconds, but then must rest for 38 seconds.
Prancer can fly 3 km/s for 21 seconds, but then must rest for 40 seconds.
Comet can fly 18 km/s for 6 seconds, but then must rest for 103 seconds.
Vixen can fly 18 km/s for 5 seconds, but then must rest for 84 seconds.";

	var reindeer = new List<Reindeer>();

	foreach (var rd in input.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries))
	{
		var s = rd.Split();
		var new_deer = new Reindeer()
		{
			Name = s[0],
			Speed = Int32.Parse(s[3]),
			RunTime = Int32.Parse(s[6]),
			RestTime = Int32.Parse(s[13]),
			
			DistanceTraveled = 0,
			TimeTraveled = 0,
			TimeRested = 0,
			Traveling = true,
		};

		reindeer.Add(new_deer);
	}


	var furthest_distance = 0;
	
	for (var t = 0; t < 2503; t++)
	{
		foreach (var rd in reindeer)
		{
			if (rd.DistanceTraveled == furthest_distance && furthest_distance > 0)
				rd.PointsEarned++;
			
			if (rd.Traveling)
			{
				rd.DistanceTraveled = rd.DistanceTraveled + rd.Speed;
				rd.TimeTraveled++;
				
				if (rd.TimeTraveled == rd.RunTime)
				{
					rd.Traveling = false;
					rd.TimeRested = 0;
				}
			}
			else
			{
				rd.TimeRested++;

				if (rd.TimeRested == rd.RestTime)
				{
					rd.Traveling = true;
					rd.TimeTraveled = 0;
				}
			}
		}
		
		furthest_distance = reindeer.Max(x => x.DistanceTraveled);
	}
	
	reindeer.OrderByDescending(x => x.PointsEarned).Dump();
}

// Define other methods and classes here
public class Reindeer
{
	public string Name { get; set; }
	public int Speed { get; set; }
	public int RunTime { get; set; }
	public int RestTime { get; set; }

	public int DistanceTraveled { get; set; }
	public int TimeTraveled { get; set;}
	public int TimeRested { get; set; }
	public bool Traveling { get; set; }
	public int PointsEarned { get; set;}
}