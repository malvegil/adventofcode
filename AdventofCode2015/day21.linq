<Query Kind="Program">
  <Output>DataGrids</Output>
</Query>

void Main()
{
	var wins = new List<Tuple<Player, int>>();

	var weapons = new List<Item>();
	var armors = new List<Item>();
	var rings = new List<Item>();

	weapons.Add(new Item(8, 4, 0));
	weapons.Add(new Item(10, 5, 0));
	weapons.Add(new Item(25, 6, 0));
	weapons.Add(new Item(40, 7, 0));
	weapons.Add(new Item(74, 8, 0));

	armors.Add(new Item(0, 0, 0));
	armors.Add(new Item(13, 0, 1));
	armors.Add(new Item(31, 0, 2));
	armors.Add(new Item(53, 0, 3));
	armors.Add(new Item(75, 0, 4));
	armors.Add(new Item(102, 0, 5));

	rings.Add(new Item(0, 0, 0));
	rings.Add(new Item(0, 0, 0));
	rings.Add(new Item(25, 1, 0));
	rings.Add(new Item(50, 2, 0));
	rings.Add(new Item(100, 3, 0));
	rings.Add(new Item(20, 0, 1));
	rings.Add(new Item(40, 0, 2));
	rings.Add(new Item(80, 0, 3));

	foreach (var w in weapons)
	{
		foreach (var a in armors)
		{
			foreach (var r1 in rings)
			{
				var rings2 = rings.Where(x => x.Cost != r1.Cost).ToList();
				foreach (var r2 in rings2)
				{
					var boss = new Player(100, 8, 2);
					Player p = new Player(
						100,
						w.Damage + a.Damage + r1.Damage + r2.Damage,
						w.Armor + a.Armor + r1.Armor + r2.Armor);

					if (!BossWins(boss, p, true))
					{
						wins.Add(new Tuple<Player, int>(p, (w.Cost + a.Cost + r1.Cost + r2.Cost)));
					}
				}
			}
		}
	}

	wins.Min(x => x.Item2).Dump();
}

// Define other methods and classes here
public class Player
{
	public int Health { get; set; }
	public int Damage { get; set; }
	public int Armor { get; set; }

	public Player(int _health, int _damage, int _armor)
	{
		Health = _health;
		Damage = _damage;
		Armor = _armor;
	}
}

public static bool BossWins(Player boss, Player p, bool playerTurn)
{
	if (playerTurn)
	{
		boss.Health = boss.Health - (p.Damage - boss.Armor);
		if (boss.Health <= 0)
			return false;
	}
	else
	{
		p.Health = p.Health - (boss.Damage - p.Armor);
		if (p.Health <= 0)
			return true;
	}
	return BossWins(boss, p, !playerTurn);
}

public class Item
{
	public int Cost { get; set; }
	public int Damage { get; set; }
	public int Armor { get; set; }

	public Item(int _cost, int _damage, int _armor)
	{
		Cost = _cost;
		Damage = _damage;
		Armor = _armor;
	}
}
