<Query Kind="Program">
  <Output>DataGrids</Output>
</Query>

void Main()
{
	var lights = new bool[102, 102];

	var input = File.ReadAllLines(@"C:\Users\chris.esau\Desktop\input18.txt");

	for (var y = 1; y < 101; y++)
	{
		var l = input[y - 1];
		for (var x = 1; x < 101; x++)
		{
			lights[x, y] = l[x - 1] == '#';
		}
	}

	//part 2 corner lights
	lights[1, 1] = true;
	lights[1, 100] = true;
	lights[100, 1] = true;
	lights[100, 100] = true;

	for (var iterations = 1; iterations <= 100; iterations++)
	{
		var new_lights = new bool[102, 102];

		for (var x = 1; x < 101; x++)
		{
			for (var y = 1; y < 101; y++)
			{
				var surrounding_on = new[]
				{
					lights[x - 1, y - 1],
					lights[x - 1, y],
					lights[x - 1, y + 1],
					lights[x, y - 1],
					lights[x, y + 1],
					lights[x + 1, y - 1],
					lights[x + 1, y],
					lights[x + 1, y + 1]
				}.Count(n => n);

				new_lights[x, y] = lights[x, y] ? surrounding_on == 2 || surrounding_on == 3 : surrounding_on == 3;
			}
		}

		//part 2 corner lights
		new_lights[1, 1] = true;
		new_lights[1, 100] = true;
		new_lights[100, 1] = true;
		new_lights[100, 100] = true;

		lights = new_lights;
	}

	var lights_on = 0;
	for (var y = 1; y < 101; y++)
	{
		for (var x = 1; x < 101; x++)
		{
			lights_on += lights[x, y] ? 1 : 0;
		}
	}

	lights_on.Dump();
}

// Define other methods and classes here
