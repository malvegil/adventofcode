<Query Kind="Program">
  <Output>DataGrids</Output>
</Query>

void Main()
{
	var ad = new BattleFrogs();
	ad.Run();
}
// Define other methods and classes here
public class BattleFrogs
{
	int bossHealth = 58;
	int bossDamage = 9;

	int costMissile = 53;
	int costDrain = 73;
	int costPoison = 173;
	int costShield = 113;
	int costRecharge = 229;

	int playerHealth = 50;
	int playerMana = 500;
	int playerArmor = 0;
	int manaCost = 0;

	int poisonCount = 0;
	int rechargeCount = 0;
	int shieldCount = 0;

	int _boss;
	int _player;
	int _mana;

	Random rand = new Random();

	public void Run()
	{
		int answer = 50000;

		for (int i = 0; i < 30000000; i++)
		{
			if (Fight())
			{
				answer = Math.Min(answer, manaCost);
			}
		}

		answer.Dump();
	}

	enum Spell { Nothing, Missile, Drain, Shield, Poison, Recharge }

	Spell ChooseSpell()
	{
		while (true)
		{
			int next = rand.Next(5);
			if (next == 0 && _mana >= costMissile) return Spell.Missile;
			else if (next == 1 && _mana >= costDrain) return Spell.Drain;
			else if (next == 2 && _mana >= costShield && shieldCount == 0) return Spell.Shield;
			else if (next == 3 && _mana >= costPoison && poisonCount == 0) return Spell.Poison;
			else if (next == 4 && _mana >= costRecharge && rechargeCount == 0) return Spell.Recharge;
			else return Spell.Nothing;
		}
	}

	bool Fight()
	{
		bool playerTurn = true;
		Spell spell = Spell.Nothing;

		_player = playerHealth;
		_boss = bossHealth;
		_mana = playerMana;
		manaCost = 0;
		poisonCount = 0;
		rechargeCount = 0;
		shieldCount = 0;

		while (true)
		{
			if (shieldCount > 0) shieldCount--;
			if (shieldCount == 0) playerArmor = 0;

			if (poisonCount > 0)
			{
				poisonCount--;
				_boss -= 3;
			}

			if (rechargeCount > 0)
			{
				rechargeCount--;
				_mana += 101;
			}

			if (_boss <= 0) return true;
			if (_player <= 0) return false;

			if (playerTurn)
			{
				// BEAST MODE
				_player--;

				if (_player <= 0) return false;

				spell = ChooseSpell();

				switch (spell)
				{
					case Spell.Missile:
						_boss -= 4;
						manaCost += costMissile;
						_mana -= costMissile;
						break;
					case Spell.Drain:
						_boss -= 2;
						_player += 2;
						manaCost += costDrain;
						_mana -= costDrain;
						break;
					case Spell.Shield:
						shieldCount = 6;
						playerArmor = 7;
						manaCost += costShield;
						_mana -= costShield;
						break;
					case Spell.Poison:
						poisonCount = 6;
						manaCost += costPoison;
						_mana -= costPoison;
						break;
					case Spell.Recharge:
						rechargeCount = 5;
						manaCost += costRecharge;
						_mana -= costRecharge;
						break;
					default:
						return false; //chose .Nothing spell because none were valid
				}
			}
			else //boss turn
			{
				_player -= Math.Max(bossDamage - playerArmor, 1);
			}

			playerTurn = !playerTurn;
		}
	}
}
