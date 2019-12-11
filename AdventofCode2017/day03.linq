<Query Kind="Program" />

void Main()
{
	var input = 277678;
	Part1(input);
	PartTwo(input);
}


static int RingSize(int x) => ((x * 2) + 1) * ((x * 2) + 1);

static int GetRadius(int y)
{
	int x = 0;
	while (RingSize(x) < y)
		x++;
	return x;
}

static void Part1(int Cell)
{
	int Radius = GetRadius(Cell);
	int Ringstart = RingSize(Radius - 1) + 1;

	int SideSize = (RingSize(Radius) - RingSize(Radius - 1)) >> 2;
	int PositionOnSide = (Cell - Ringstart) % SideSize;
	PositionOnSide -= (SideSize - 1) >> 1;

	int Steps = Radius + Math.Abs(PositionOnSide);

	Console.WriteLine("Part 1: {0}", Steps);
}

public enum Direction
{
	Right,
	Up,
	Left,
	Down
}

public static void PartTwo(int input)
{
	int maxX = 600;  // I knew from part 1 that 600x600 would be wide enough
	int maxY = 600;
	int[,] matrix = new int[maxX, maxY];

	// Zero the 2D array (my background is C++, not sure if this was necessary, ints may have been zero anyway
	{
		for (int x = 0; x < maxX; ++x)
		{
			for (int y = 0; y < maxY; ++y)
			{
				matrix[x, y] = 0;
			}
		}
	}

	{
		int currentStepAmount = 1;
		bool secondStep = false;
		int itersUntilRotate = 1;
		Direction currentDirection = Direction.Right;

		int x = 295;
		int y = 295;

		int nextValue = 1;
		matrix[x, y] = 1;

		while (nextValue < input)
		{
			if (itersUntilRotate == 0)
			{
				if (secondStep)
				{
					++currentStepAmount;
				}

				secondStep = !secondStep;

				itersUntilRotate = currentStepAmount;

				switch (currentDirection)
				{
					case Direction.Right: currentDirection = Direction.Up; break;
					case Direction.Up: currentDirection = Direction.Left; break;
					case Direction.Left: currentDirection = Direction.Down; break;
					case Direction.Down: currentDirection = Direction.Right; break;
				}
			}

			switch (currentDirection)
			{
				case Direction.Right: ++x; break;
				case Direction.Up: --y; break;
				case Direction.Left: --x; break;
				case Direction.Down: ++y; break;
			}

			--itersUntilRotate;

			Console.WriteLine("x: " + x + ", y: " + y);

			nextValue = matrix[x - 1, y - 1] + matrix[x - 1, y] + matrix[x - 1, y + 1]
					  + matrix[x, y - 1] + matrix[x, y + 1]
					  + matrix[x + 1, y - 1] + matrix[x + 1, y] + matrix[x + 1, y + 1];

			matrix[x, y] = nextValue;

			Console.WriteLine("nextValue: " + nextValue);
		}
	}
}