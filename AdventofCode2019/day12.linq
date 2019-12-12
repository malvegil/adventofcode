<Query Kind="Program" />

void Main()
{
	var data = File.ReadAllLines(@"H:\Documents\LINQPad Queries\AdventofCode\AdventofCode\AdventofCode2019\day12a.txt");
	var moons = new List<Moon>() {
		new Moon("Io", -5, 6, -11),
		new Moon("Europa",-8, -4, -2),
		new Moon("Ganymede", 1, 16, 4),
		new Moon("Callisto", 11, 11, -4)
		};

	//	moons = new List<Moon>() {
	//		new Moon("Io", -1,0,2),
	//		new Moon("Europa",2,-10,-7),
	//		new Moon("Ganymede",4,-8,8),
	//		new Moon("Callisto", 3,5,-1)
	//		};
	//
	//	moons = new List<Moon>() {
	//		new Moon("Io", -8,-10,0),
	//		new Moon("Europa",5,5,10),
	//		new Moon("Ganymede",2,-7,3),
	//		new Moon("Callisto",9,-8,-3)
	//		};

	var num_steps = 1000;
	for (var s = 0; s < num_steps; s++)
	{
		foreach (var m in moons)
		{
			var others = moons.Where(a => a.name != m.name);
			m.velX += others.Where(a => a.posX > m.posX).Count();
			m.velX -= others.Where(a => a.posX < m.posX).Count();
			m.velY += others.Where(a => a.posY > m.posY).Count();
			m.velY -= others.Where(a => a.posY < m.posY).Count();
			m.velZ += others.Where(a => a.posZ > m.posZ).Count();
			m.velZ -= others.Where(a => a.posZ < m.posZ).Count();
		}

		foreach (var m in moons)
		{
			m.posX += m.velX;
			m.posY += m.velY;
			m.posZ += m.velZ;
		}
	}

	moons.Sum(m => m.TotalEnergy).Dump("Day 12 A");


	//Part B - GCD/LCM alignment
	moons = new List<Moon>() {
		new Moon("Io", -5, 6, -11),
		new Moon("Europa",-8, -4, -2),
		new Moon("Ganymede", 1, 16, 4),
		new Moon("Callisto", 11, 11, -4)
		};

	var x_cycle = 0;
	while (moons.Count(i => i.initX == i.posX) < 4 || x_cycle == 0)
	{
		foreach (var m in moons)
		{
			var others = moons.Where(a => a.name != m.name);
			m.velX += others.Where(a => a.posX > m.posX).Count();
			m.velX -= others.Where(a => a.posX < m.posX).Count();
			m.velY += others.Where(a => a.posY > m.posY).Count();
			m.velY -= others.Where(a => a.posY < m.posY).Count();
			m.velZ += others.Where(a => a.posZ > m.posZ).Count();
			m.velZ -= others.Where(a => a.posZ < m.posZ).Count();
		}

		foreach (var m in moons)
		{
			m.posX += m.velX;
			m.posY += m.velY;
			m.posZ += m.velZ;
		}
		x_cycle++;
	}

	moons = new List<Moon>() {
		new Moon("Io", -5, 6, -11),
		new Moon("Europa",-8, -4, -2),
		new Moon("Ganymede", 1, 16, 4),
		new Moon("Callisto", 11, 11, -4)
		};

	var y_cycle = 0;
	while (moons.Count(i => i.initY == i.posY) < 4 || y_cycle == 0)
	{
		foreach (var m in moons)
		{
			var others = moons.Where(a => a.name != m.name);
			m.velX += others.Where(a => a.posX > m.posX).Count();
			m.velX -= others.Where(a => a.posX < m.posX).Count();
			m.velY += others.Where(a => a.posY > m.posY).Count();
			m.velY -= others.Where(a => a.posY < m.posY).Count();
			m.velZ += others.Where(a => a.posZ > m.posZ).Count();
			m.velZ -= others.Where(a => a.posZ < m.posZ).Count();
		}

		foreach (var m in moons)
		{
			m.posX += m.velX;
			m.posY += m.velY;
			m.posZ += m.velZ;
		}
		y_cycle++;
	}

	moons = new List<Moon>() {
		new Moon("Io", -5, 6, -11),
		new Moon("Europa",-8, -4, -2),
		new Moon("Ganymede", 1, 16, 4),
		new Moon("Callisto", 11, 11, -4)
		};

	var z_cycle = 0;
	while (moons.Count(i => i.initZ == i.posZ) < 4 || z_cycle == 0)
	{
		foreach (var m in moons)
		{
			var others = moons.Where(a => a.name != m.name);
			m.velX += others.Where(a => a.posX > m.posX).Count();
			m.velX -= others.Where(a => a.posX < m.posX).Count();
			m.velY += others.Where(a => a.posY > m.posY).Count();
			m.velY -= others.Where(a => a.posY < m.posY).Count();
			m.velZ += others.Where(a => a.posZ > m.posZ).Count();
			m.velZ -= others.Where(a => a.posZ < m.posZ).Count();
		}

		foreach (var m in moons)
		{
			m.posX += m.velX;
			m.posY += m.velY;
			m.posZ += m.velZ;
		}
		z_cycle++;
	}

	LCM(new long[] { x_cycle + 1, y_cycle + 1, z_cycle + 1 }).Dump("Day 12 B");
}

// Define other methods and classes here
class Moon
{
	public string name { get; set; }
	public int posX { get; set; }
	public int posY { get; set; }
	public int posZ { get; set; }

	public int velX { get; set; }
	public int velY { get; set; }
	public int velZ { get; set; }

	public int initX { get; }
	public int initY { get; }
	public int initZ { get; }

	public Moon(string n, int x, int y, int z)
	{
		name = n;
		posX = x; posY = y; posZ = z;
		velX = velY = velZ = 0;
		initX = x;
		initY = y;
		initZ = z;
	}

	public int TotalEnergy
	{
		get
		{
			return KineticE * PotentialE;
		}
	}

	public int KineticE
	{
		get
		{
			return Math.Abs(velX) + Math.Abs(velY) + Math.Abs(velZ);
		}
	}

	public int PotentialE
	{
		get
		{
			return Math.Abs(posX) + Math.Abs(posY) + Math.Abs(posZ);
		}
	}
}

static long LCM(long[] numbers)
{
	return numbers.Aggregate(lcm);
}
static long lcm(long a, long b)
{
	return Math.Abs(a * b) / GCD(a, b);
}
static long GCD(long a, long b)
{
	return b == 0 ? a : GCD(b, a % b);
}