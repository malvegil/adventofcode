<Query Kind="Program" />

void Main()
{
	Tree = File.ReadAllLines(@"H:\Documents\LINQPad Queries\AdventofCode\AdventofCode\AdventofCode2018\day08a.txt")
		.First().Split(' ').Select(i =>
			new Node { children = Int32.Parse(i), value = 0, child_ids = new List<int>(), }).ToArray();

	WalkTree(0);
	SumMeta.Dump("Day 08 Part A");

	Tree[0].value.Dump("Day 08 Part B");
}

// Define other methods and classes here
public int SumMeta = 0;
public class Node
{
	public int children;
	public int value;
	public List<int> child_ids;
}
public Node[] Tree;

public int WalkTree(int idx)
{
	var num_children = Tree[idx].children;
	var num_metadata = Tree[idx + 1].children;
	var index = idx + 2;
	while (num_children > 0)
	{
		Tree[idx].child_ids.Add(index);
		index = WalkTree(index);
		num_children--;
	}

	for (var i = index; i < index + num_metadata; i++)
	{
		SumMeta += Tree[i].children;

		if (Tree[idx].children == 0)
			Tree[idx].value += Tree[i].children;

		try
		{
			var id = Tree[idx].child_ids[Tree[i].children - 1];
			Tree[idx].value += Tree[id].value;
		}
		catch (Exception ex)
		{ }

	}

	return index + num_metadata;
}