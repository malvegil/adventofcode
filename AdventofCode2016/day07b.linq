<Query Kind="Program">
  <Namespace>System.Security.Cryptography</Namespace>
</Query>

static void Main(string[] args)
{
	string key = "abbhdwsy";

	MD5 md5Hash = MD5.Create();
	long counter = 0;
	string currentString = key + counter;

	var stop = false;
	bool startZero = false;
	var password = new char[8] { ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', };

	while (!startZero && !stop)
	{
		counter++;
		currentString = key + counter;
		var hash = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(currentString));
		startZero = checkHash(hash);
		if (startZero)
		{
			var good_hash = ByteArrayToString(hash).ToCharArray();
			if (hash[2] <= 7)
			{
				if (password[hash[2]] == ' ')
					password[hash[2]] = good_hash[6];
					
				stop = true;
				for (var j = 0; j < 8; j++)
				{
					if (password[j] == ' ')
						stop = false;
				}
			}

			startZero = false;
		}
	}

	password.Dump();
}

// Define other methods and classes here
public static bool checkHash(byte[] hash)
{
	for (int i = 0; i < 2; i++)
		if (hash[i] != 0)
		{
			return false;
		}

	if (hash[2] > 15)
		return false;

	return true;
}

public static string ByteArrayToString(byte[] ba)
{
	string hex = BitConverter.ToString(ba);
	return hex.Replace("-", "");
}