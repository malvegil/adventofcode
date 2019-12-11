<Query Kind="Program">
  <Namespace>System.Security.Cryptography</Namespace>
</Query>

static void Main(string[] args)
{
	string key = "abbhdwsy";

	MD5 md5Hash = MD5.Create();
	long counter = 0;
	string currentString = key + counter;

	var i = 0;
	bool startZero = false;
	var password = string.Empty;

	while (!startZero && i < 8)
	{
		counter++;
		currentString = key + counter;
		var hash = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(currentString));
		startZero = checkHash(hash);
		if (startZero)
		{
			var good_hash = ByteArrayToString(hash);
			i++;
			startZero = false;
			password = password + good_hash[5];
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