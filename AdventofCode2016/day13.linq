<Query Kind="Program" />

Cube dest = new Cube { x = 31, y = 39 };
int input = 1362;

//formula
bool IsWall(int x, int y)
{
	return Convert.ToString((x * x + 3 * x + 2 * x * y + y + y * y + input), 2)
		.ToArray()
		.Sum(b => b == '1' ? 1 : 0) % 2 == 1;
}

public struct Cube
{
	public int x;
	public int y;
	public int Moves;

	public override bool Equals(object o)
	{
		return Equals((Cube)o);
	}

	public bool Equals(Cube c2)
	{
		return
			this.x == c2.x &&
			this.y == c2.y;
	}

	public override int GetHashCode()
	{
		return Tuple.Create(
			this.x,
			this.y).GetHashCode();
	}
}

HashSet<Cube> _UsedLocations = new HashSet<Cube>();
public bool HasCrossed(Cube c)
{
	if (_UsedLocations.Contains(c))
	{ return true; }
	else
	{ _UsedLocations.Add(c); return false; }
}


void Main()
{
	var start = new Cube { x = 1, y = 1, Moves = 0 };
	var path = new HashSet<Cube>();

	var queue = new Queue<Cube>();
	queue.Enqueue(start);

	while (queue.Count != 0)
	{
		var pos = queue.Dequeue();

		foreach (var c in NextMoves(pos)
			.Where(p => !IsWall(p.x, p.y))
			.Where(p => !HasCrossed(p)))
		{
			if (c.x == dest.x && c.y == dest.y)
			{
				c.Dump("Part A");
				queue.Clear();
				_UsedLocations.Clear();
				break;
			}

			queue.Enqueue(c);
		}
	}


	queue.Enqueue(start);
	var count = -1;
	while (queue.Peek().Moves <= 50)
	{
		var position = queue.Dequeue();
		count++;

		foreach (var p in NextMoves(position)
			.Where(p => !IsWall(p.x, p.y))
			.Where(p => !HasCrossed(p)))
		{
			queue.Enqueue(p);
		}
	}

	count.Dump("Part B");
}

IEnumerable<Cube> NextMoves(Cube c)
{
	if (c.x > 0) yield return new Cube { x = c.x - 1, y = c.y, Moves = c.Moves + 1 };
	if (c.y > 0) yield return new Cube { x = c.x, y = c.y - 1, Moves = c.Moves + 1 };
	yield return new Cube { x = c.x + 1, y = c.y, Moves = c.Moves + 1 };
	yield return new Cube { x = c.x, y = c.y + 1, Moves = c.Moves + 1 };
}