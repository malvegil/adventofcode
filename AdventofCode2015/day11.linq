<Query Kind="Program">
  <Output>DataGrids</Output>
</Query>

void Main()
{
	var input = IteratePassword("cqjxxyzz");

	while (!DoesPasswordMatch(input))
	{
		input = IteratePassword(input);
	}

	input.Dump();
}

// Define other methods and classes here
public static bool DoesPasswordMatch(string input)
{
	if (input.Contains('i') || input.Contains('o') || input.Contains('l'))
		return false;

	if (!HasRepeatLetter(input))
		return false;
		
	if (!HasSequence(input))
		return false;
	
	return true;
}

public static string IteratePassword(string input)
{
	StringBuilder sb = new StringBuilder(input);

	for (var c = 7; c >= 0; c--)
	{
		var new_c = input[c];
		new_c = IterateChar(new_c);

		sb.Replace(input[c], new_c, c, 1);

		if (new_c != 'a')
			c = -1;
	}

	return sb.ToString();
}

public static char IterateChar(char c)
{
	if (c == 'z')
		return 'a';
	else
		return ((char)((int)c + 1));
}

public static bool HasRepeatLetter(string str)
{
	var hasFirstRepeatLetter = false;
	var firstRepeatLetter = ' ';
	var hasSecondRepeatLetter = false;

	for (int i = 0; i < str.Length; i++)
	{
		if (!hasFirstRepeatLetter &&
			i > 1 &&
			str[i] == str[i - 1])
		{
			firstRepeatLetter = str[i];
			hasFirstRepeatLetter = true;
		}
	}

	if (hasFirstRepeatLetter)
	{
		for (int i = 0; i < str.Length; i++)
		{
			if (!hasSecondRepeatLetter &&
				i > 1 &&
				str[i] == str[i - 1] &&
				str[i] != firstRepeatLetter)
			{
				hasSecondRepeatLetter = true;
			}
		}
	}

	return hasSecondRepeatLetter;
}

public static bool HasSequence(string str)
{
	var hasSequence = false;

	for (int i = 0; i < str.Length; i++)
	{
		if (!hasSequence &&
			i > 2 &&
			(int)str[i] == ((int)str[i - 1] + 1) &&
			(int)str[i] == ((int)str[i - 2] + 2))
		{
			hasSequence = true;
		}
	}
	
	return hasSequence;
}