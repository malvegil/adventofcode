<Query Kind="Program">
  <Output>DataGrids</Output>
  <Namespace>System.Security.Cryptography</Namespace>
</Query>

public static bool checkHash(byte[] hash)
{
	for (int i = 0; i < 3; i++)
		if (hash[i] != 0)
		{
			return false;
		}

	return true;
}

static void Main(string[] args)
{
	string key = "ckczppom";

	MD5 md5Hash = MD5.Create();
	long counter = 0;
	string currentString = key + counter;
	bool startZero = false;

	while (!startZero)
	{
		counter++;
		currentString = key + counter;

		startZero = checkHash(md5Hash.ComputeHash(Encoding.UTF8.GetBytes(currentString)));
	}

	Console.WriteLine("6 zeros: {0}", counter);
}
