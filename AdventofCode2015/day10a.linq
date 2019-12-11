<Query Kind="Program">
  <Output>DataGrids</Output>
</Query>

//Title of this code
//Rextester.Program.Main is the entry point for your code. Don't change it.
//Compiler version 4.0.30319.17929 for Microsoft (R) .NET Framework 4.5
public static void Main(string[] args)
{
	//Your code goes here
	var input = @"1113222113";

	for (var i = 0; i < 50; i++)
	{
		var last_char = ' ';
		var count = 0;
		var sb = new StringBuilder();

		foreach (var c in input.ToCharArray())
		{
			if (c != last_char)
			{
				if (count != 0)
				{
					sb.Append(count);
					sb.Append(last_char);
				}

				last_char = c;
				count = 1;
			}
			else
				count++;
		}
		
		sb.Append(count);
		sb.Append(last_char);
		input = sb.ToString();
	}

	input.Length.Dump();
}
