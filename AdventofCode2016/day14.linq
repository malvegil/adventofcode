<Query Kind="Statements">
  <Namespace>System.Security.Cryptography</Namespace>
</Query>

using (var md5Hash = MD5.Create())
{
	string key = "zpqevtbw";
	var Regex3 = new Regex(@"(\w|\d)\1{2}", RegexOptions.Compiled);

	var queue = new Queue<string>();
	var index = 0;
	var numKeys = 0;

	var counter = 0;
	Func<string> getNextHash = () =>
	{
		var hashSrc = key + counter;
		counter++;

		var hashText = hashSrc;
		for (int i = 0; i < 2017; i++)
		{
			var bytes = Encoding.ASCII.GetBytes(hashText);
			var hash = md5Hash.ComputeHash(bytes);
			hashText = BitConverter.ToString(hash).ToLower().Replace("-", "");
		}
		return hashText;
	};

	Action ensureQueueLength = () =>
	{
		while (queue.Count < 1000)
			queue.Enqueue(getNextHash());
	};

	ensureQueueLength();

	while (numKeys < 64)
	{
		var possibleKey = new { hash = queue.Dequeue(), index };
		index++;
		ensureQueueLength();

		var match = Regex3.Match(possibleKey.hash);
		if (!match.Success) continue;

		var fiveLetter = new string(match.Value[0], 5);

		if (queue.Any(h => h.Contains(fiveLetter)))
		{
			numKeys++;
		}
	}
	index.Dump("Day 14 B");
}