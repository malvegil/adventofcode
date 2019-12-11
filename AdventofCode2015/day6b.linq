<Query Kind="Program">
  <Output>DataGrids</Output>
</Query>

void Main()
{
	var lights = new List<Light>();

	for (int x = 0; x < 1000; x++)
	{
		for (int y = 0; y < 1000; y++)
		{
			lights.Add(new Light(x, y));
		}
	}

	var instructions = new List<string>();

	instructions.Add("turn on 887,9 through 959,629");
	instructions.Add("turn on 454,398 through 844,448");
	instructions.Add("turn off 539,243 through 559,965");
	instructions.Add("turn off 370,819 through 676,868");
	instructions.Add("turn off 145,40 through 370,997");
	instructions.Add("turn off 301,3 through 808,453");
	instructions.Add("turn on 351,678 through 951,908");
	instructions.Add("toggle 720,196 through 897,994");
	instructions.Add("toggle 831,394 through 904,860");
	instructions.Add("toggle 753,664 through 970,926");
	instructions.Add("turn off 150,300 through 213,740");
	instructions.Add("turn on 141,242 through 932,871");
	instructions.Add("toggle 294,259 through 474,326");
	instructions.Add("toggle 678,333 through 752,957");
	instructions.Add("toggle 393,804 through 510,976");
	instructions.Add("turn off 6,964 through 411,976");
	instructions.Add("turn off 33,572 through 978,590");
	instructions.Add("turn on 579,693 through 650,978");
	instructions.Add("turn on 150,20 through 652,719");
	instructions.Add("turn off 782,143 through 808,802");
	instructions.Add("turn off 240,377 through 761,468");
	instructions.Add("turn off 899,828 through 958,967");
	instructions.Add("turn on 613,565 through 952,659");
	instructions.Add("turn on 295,36 through 964,978");
	instructions.Add("toggle 846,296 through 969,528");
	instructions.Add("turn off 211,254 through 529,491");
	instructions.Add("turn off 231,594 through 406,794");
	instructions.Add("turn off 169,791 through 758,942");
	instructions.Add("turn on 955,440 through 980,477");
	instructions.Add("toggle 944,498 through 995,928");
	instructions.Add("turn on 519,391 through 605,718");
	instructions.Add("toggle 521,303 through 617,366");
	instructions.Add("turn off 524,349 through 694,791");
	instructions.Add("toggle 391,87 through 499,792");
	instructions.Add("toggle 562,527 through 668,935");
	instructions.Add("turn off 68,358 through 857,453");
	instructions.Add("toggle 815,811 through 889,828");
	instructions.Add("turn off 666,61 through 768,87");
	instructions.Add("turn on 27,501 through 921,952");
	instructions.Add("turn on 953,102 through 983,471");
	instructions.Add("turn on 277,552 through 451,723");
	instructions.Add("turn off 64,253 through 655,960");
	instructions.Add("turn on 47,485 through 734,977");
	instructions.Add("turn off 59,119 through 699,734");
	instructions.Add("toggle 407,898 through 493,955");
	instructions.Add("toggle 912,966 through 949,991");
	instructions.Add("turn on 479,990 through 895,990");
	instructions.Add("toggle 390,589 through 869,766");
	instructions.Add("toggle 593,903 through 926,943");
	instructions.Add("toggle 358,439 through 870,528");
	instructions.Add("turn off 649,410 through 652,875");
	instructions.Add("turn on 629,834 through 712,895");
	instructions.Add("toggle 254,555 through 770,901");
	instructions.Add("toggle 641,832 through 947,850");
	instructions.Add("turn on 268,448 through 743,777");
	instructions.Add("turn off 512,123 through 625,874");
	instructions.Add("turn off 498,262 through 930,811");
	instructions.Add("turn off 835,158 through 886,242");
	instructions.Add("toggle 546,310 through 607,773");
	instructions.Add("turn on 501,505 through 896,909");
	instructions.Add("turn off 666,796 through 817,924");
	instructions.Add("toggle 987,789 through 993,809");
	instructions.Add("toggle 745,8 through 860,693");
	instructions.Add("toggle 181,983 through 731,988");
	instructions.Add("turn on 826,174 through 924,883");
	instructions.Add("turn on 239,228 through 843,993");
	instructions.Add("turn on 205,613 through 891,667");
	instructions.Add("toggle 867,873 through 984,896");
	instructions.Add("turn on 628,251 through 677,681");
	instructions.Add("toggle 276,956 through 631,964");
	instructions.Add("turn on 78,358 through 974,713");
	instructions.Add("turn on 521,360 through 773,597");
	instructions.Add("turn off 963,52 through 979,502");
	instructions.Add("turn on 117,151 through 934,622");
	instructions.Add("toggle 237,91 through 528,164");
	instructions.Add("turn on 944,269 through 975,453");
	instructions.Add("toggle 979,460 through 988,964");
	instructions.Add("turn off 440,254 through 681,507");
	instructions.Add("toggle 347,100 through 896,785");
	instructions.Add("turn off 329,592 through 369,985");
	instructions.Add("turn on 931,960 through 979,985");
	instructions.Add("toggle 703,3 through 776,36");
	instructions.Add("toggle 798,120 through 908,550");
	instructions.Add("turn off 186,605 through 914,709");
	instructions.Add("turn off 921,725 through 979,956");
	instructions.Add("toggle 167,34 through 735,249");
	instructions.Add("turn on 726,781 through 987,936");
	instructions.Add("toggle 720,336 through 847,756");
	instructions.Add("turn on 171,630 through 656,769");
	instructions.Add("turn off 417,276 through 751,500");
	instructions.Add("toggle 559,485 through 584,534");
	instructions.Add("turn on 568,629 through 690,873");
	instructions.Add("toggle 248,712 through 277,988");
	instructions.Add("toggle 345,594 through 812,723");
	instructions.Add("turn off 800,108 through 834,618");
	instructions.Add("turn off 967,439 through 986,869");
	instructions.Add("turn on 842,209 through 955,529");
	instructions.Add("turn on 132,653 through 357,696");
	instructions.Add("turn on 817,38 through 973,662");
	instructions.Add("turn off 569,816 through 721,861");
	instructions.Add("turn on 568,429 through 945,724");
	instructions.Add("turn on 77,458 through 844,685");
	instructions.Add("turn off 138,78 through 498,851");
	instructions.Add("turn on 136,21 through 252,986");
	instructions.Add("turn off 2,460 through 863,472");
	instructions.Add("turn on 172,81 through 839,332");
	instructions.Add("turn on 123,216 through 703,384");
	instructions.Add("turn off 879,644 through 944,887");
	instructions.Add("toggle 227,491 through 504,793");
	instructions.Add("toggle 580,418 through 741,479");
	instructions.Add("toggle 65,276 through 414,299");
	instructions.Add("toggle 482,486 through 838,931");
	instructions.Add("turn off 557,768 through 950,927");
	instructions.Add("turn off 615,617 through 955,864");
	instructions.Add("turn on 859,886 through 923,919");
	instructions.Add("turn on 391,330 through 499,971");
	instructions.Add("toggle 521,835 through 613,847");
	instructions.Add("turn on 822,787 through 989,847");
	instructions.Add("turn on 192,142 through 357,846");
	instructions.Add("turn off 564,945 through 985,945");
	instructions.Add("turn off 479,361 through 703,799");
	instructions.Add("toggle 56,481 through 489,978");
	instructions.Add("turn off 632,991 through 774,998");
	instructions.Add("toggle 723,526 through 945,792");
	instructions.Add("turn on 344,149 through 441,640");
	instructions.Add("toggle 568,927 through 624,952");
	instructions.Add("turn on 621,784 through 970,788");
	instructions.Add("toggle 665,783 through 795,981");
	instructions.Add("toggle 386,610 through 817,730");
	instructions.Add("toggle 440,399 through 734,417");
	instructions.Add("toggle 939,201 through 978,803");
	instructions.Add("turn off 395,883 through 554,929");
	instructions.Add("turn on 340,309 through 637,561");
	instructions.Add("turn off 875,147 through 946,481");
	instructions.Add("turn off 945,837 through 957,922");
	instructions.Add("turn off 429,982 through 691,991");
	instructions.Add("toggle 227,137 through 439,822");
	instructions.Add("toggle 4,848 through 7,932");
	instructions.Add("turn off 545,146 through 756,943");
	instructions.Add("turn on 763,863 through 937,994");
	instructions.Add("turn on 232,94 through 404,502");
	instructions.Add("turn off 742,254 through 930,512");
	instructions.Add("turn on 91,931 through 101,942");
	instructions.Add("toggle 585,106 through 651,425");
	instructions.Add("turn on 506,700 through 567,960");
	instructions.Add("turn off 548,44 through 718,352");
	instructions.Add("turn off 194,827 through 673,859");
	instructions.Add("turn off 6,645 through 509,764");
	instructions.Add("turn off 13,230 through 821,361");
	instructions.Add("turn on 734,629 through 919,631");
	instructions.Add("toggle 788,552 through 957,972");
	instructions.Add("toggle 244,747 through 849,773");
	instructions.Add("turn off 162,553 through 276,887");
	instructions.Add("turn off 569,577 through 587,604");
	instructions.Add("turn off 799,482 through 854,956");
	instructions.Add("turn on 744,535 through 909,802");
	instructions.Add("toggle 330,641 through 396,986");
	instructions.Add("turn off 927,458 through 966,564");
	instructions.Add("toggle 984,486 through 986,913");
	instructions.Add("toggle 519,682 through 632,708");
	instructions.Add("turn on 984,977 through 989,986");
	instructions.Add("toggle 766,423 through 934,495");
	instructions.Add("turn on 17,509 through 947,718");
	instructions.Add("turn on 413,783 through 631,903");
	instructions.Add("turn on 482,370 through 493,688");
	instructions.Add("turn on 433,859 through 628,938");
	instructions.Add("turn off 769,549 through 945,810");
	instructions.Add("turn on 178,853 through 539,941");
	instructions.Add("turn off 203,251 through 692,433");
	instructions.Add("turn off 525,638 through 955,794");
	instructions.Add("turn on 169,70 through 764,939");
	instructions.Add("toggle 59,352 through 896,404");
	instructions.Add("toggle 143,245 through 707,320");
	instructions.Add("turn off 103,35 through 160,949");
	instructions.Add("toggle 496,24 through 669,507");
	instructions.Add("turn off 581,847 through 847,903");
	instructions.Add("turn on 689,153 through 733,562");
	instructions.Add("turn on 821,487 through 839,699");
	instructions.Add("turn on 837,627 through 978,723");
	instructions.Add("toggle 96,748 through 973,753");
	instructions.Add("toggle 99,818 through 609,995");
	instructions.Add("turn on 731,193 through 756,509");
	instructions.Add("turn off 622,55 through 813,365");
	instructions.Add("turn on 456,490 through 576,548");
	instructions.Add("turn on 48,421 through 163,674");
	instructions.Add("turn off 853,861 through 924,964");
	instructions.Add("turn off 59,963 through 556,987");
	instructions.Add("turn on 458,710 through 688,847");
	instructions.Add("toggle 12,484 through 878,562");
	instructions.Add("turn off 241,964 through 799,983");
	instructions.Add("turn off 434,299 through 845,772");
	instructions.Add("toggle 896,725 through 956,847");
	instructions.Add("turn on 740,289 through 784,345");
	instructions.Add("turn off 395,840 through 822,845");
	instructions.Add("turn on 955,224 through 996,953");
	instructions.Add("turn off 710,186 through 957,722");
	instructions.Add("turn off 485,949 through 869,985");
	instructions.Add("turn on 848,209 through 975,376");
	instructions.Add("toggle 221,241 through 906,384");
	instructions.Add("turn on 588,49 through 927,496");
	instructions.Add("turn on 273,332 through 735,725");
	instructions.Add("turn on 505,962 through 895,962");
	instructions.Add("toggle 820,112 through 923,143");
	instructions.Add("turn on 919,792 through 978,982");
	instructions.Add("toggle 489,461 through 910,737");
	instructions.Add("turn off 202,642 through 638,940");
	instructions.Add("turn off 708,953 through 970,960");
	instructions.Add("toggle 437,291 through 546,381");
	instructions.Add("turn on 409,358 through 837,479");
	instructions.Add("turn off 756,279 through 870,943");
	instructions.Add("turn off 154,657 through 375,703");
	instructions.Add("turn off 524,622 through 995,779");
	instructions.Add("toggle 514,221 through 651,850");
	instructions.Add("toggle 808,464 through 886,646");
	instructions.Add("toggle 483,537 through 739,840");
	instructions.Add("toggle 654,769 through 831,825");
	instructions.Add("turn off 326,37 through 631,69");
	instructions.Add("turn off 590,570 through 926,656");
	instructions.Add("turn off 881,913 through 911,998");
	instructions.Add("turn on 996,102 through 998,616");
	instructions.Add("turn off 677,503 through 828,563");
	instructions.Add("turn on 860,251 through 877,441");
	instructions.Add("turn off 964,100 through 982,377");
	instructions.Add("toggle 888,403 through 961,597");
	instructions.Add("turn off 632,240 through 938,968");
	instructions.Add("toggle 731,176 through 932,413");
	instructions.Add("turn on 5,498 through 203,835");
	instructions.Add("turn on 819,352 through 929,855");
	instructions.Add("toggle 393,813 through 832,816");
	instructions.Add("toggle 725,689 through 967,888");
	instructions.Add("turn on 968,950 through 969,983");
	instructions.Add("turn off 152,628 through 582,896");
	instructions.Add("turn off 165,844 through 459,935");
	instructions.Add("turn off 882,741 through 974,786");
	instructions.Add("turn off 283,179 through 731,899");
	instructions.Add("toggle 197,366 through 682,445");
	instructions.Add("turn on 106,309 through 120,813");
	instructions.Add("toggle 950,387 through 967,782");
	instructions.Add("turn off 274,603 through 383,759");
	instructions.Add("turn off 155,665 through 284,787");
	instructions.Add("toggle 551,871 through 860,962");
	instructions.Add("turn off 30,826 through 598,892");
	instructions.Add("toggle 76,552 through 977,888");
	instructions.Add("turn on 938,180 through 994,997");
	instructions.Add("toggle 62,381 through 993,656");
	instructions.Add("toggle 625,861 through 921,941");
	instructions.Add("turn on 685,311 through 872,521");
	instructions.Add("turn on 124,934 through 530,962");
	instructions.Add("turn on 606,379 through 961,867");
	instructions.Add("turn off 792,735 through 946,783");
	instructions.Add("turn on 417,480 through 860,598");
	instructions.Add("toggle 178,91 through 481,887");
	instructions.Add("turn off 23,935 through 833,962");
	instructions.Add("toggle 317,14 through 793,425");
	instructions.Add("turn on 986,89 through 999,613");
	instructions.Add("turn off 359,201 through 560,554");
	instructions.Add("turn off 729,494 through 942,626");
	instructions.Add("turn on 204,143 through 876,610");
	instructions.Add("toggle 474,97 through 636,542");
	instructions.Add("turn off 902,924 through 976,973");
	instructions.Add("turn off 389,442 through 824,638");
	instructions.Add("turn off 622,863 through 798,863");
	instructions.Add("turn on 840,622 through 978,920");
	instructions.Add("toggle 567,374 through 925,439");
	instructions.Add("turn off 643,319 through 935,662");
	instructions.Add("toggle 185,42 through 294,810");
	instructions.Add("turn on 47,124 through 598,880");
	instructions.Add("toggle 828,303 through 979,770");
	instructions.Add("turn off 174,272 through 280,311");
	instructions.Add("turn off 540,50 through 880,212");
	instructions.Add("turn on 141,994 through 221,998");
	instructions.Add("turn on 476,695 through 483,901");
	instructions.Add("turn on 960,216 through 972,502");
	instructions.Add("toggle 752,335 through 957,733");
	instructions.Add("turn off 419,713 through 537,998");
	instructions.Add("toggle 772,846 through 994,888");
	instructions.Add("turn on 881,159 through 902,312");
	instructions.Add("turn off 537,651 through 641,816");
	instructions.Add("toggle 561,947 through 638,965");
	instructions.Add("turn on 368,458 through 437,612");
	instructions.Add("turn on 290,149 through 705,919");
	instructions.Add("turn on 711,918 through 974,945");
	instructions.Add("toggle 916,242 through 926,786");
	instructions.Add("toggle 522,272 through 773,314");
	instructions.Add("turn on 432,897 through 440,954");
	instructions.Add("turn off 132,169 through 775,380");
	instructions.Add("toggle 52,205 through 693,747");
	instructions.Add("toggle 926,309 through 976,669");
	instructions.Add("turn off 838,342 through 938,444");
	instructions.Add("turn on 144,431 through 260,951");
	instructions.Add("toggle 780,318 through 975,495");
	instructions.Add("turn off 185,412 through 796,541");
	instructions.Add("turn on 879,548 through 892,860");
	instructions.Add("turn on 294,132 through 460,338");
	instructions.Add("turn on 823,500 through 899,529");
	instructions.Add("turn off 225,603 through 483,920");
	instructions.Add("toggle 717,493 through 930,875");
	instructions.Add("toggle 534,948 through 599,968");
	instructions.Add("turn on 522,730 through 968,950");
	instructions.Add("turn off 102,229 through 674,529");

	foreach (var instruction in instructions)
	{
		var parts = instruction.Split(' ');
		if (parts[0] == "toggle")
		{
			var first = parts[1].Split(',');
			var second = parts[3].Split(',');
			lights = ToggleLights(lights,
				Int32.Parse(first[0]),
				Int32.Parse(first[1]),
				Int32.Parse(second[0]),
				Int32.Parse(second[1]));
		}
		else
		{
			var first = parts[2].Split(',');
			var second = parts[4].Split(',');
			lights = LightsOnOff(lights,
				Int32.Parse(first[0]),
				Int32.Parse(first[1]),
				Int32.Parse(second[0]),
				Int32.Parse(second[1]),
				parts[1] == "on");
		}
	}

	lights.Sum(l => l.brightness).Dump();
}

// Define other methods and classes here
public class Light
{
	public int x { get; set; }
	public int y { get; set; }
	public int brightness { get; set; }

	public Light(int x, int y)
	{
		this.x = x;
		this.y = y;
		this.brightness = 0;
	}
}

public static List<Light> ToggleLights(List<Light> lights, int startX, int startY, int endX, int endY)
{
	foreach (var l in lights.Where(l => l.x >= startX && l.x <= endX && l.y >= startY && l.y <= endY))
		l.brightness = l.brightness + 2;

	return lights;
}

public static List<Light> LightsOnOff(List<Light> lights, int startX, int startY, int endX, int endY, bool turnOn)
{
	foreach (var l in lights.Where(l => l.x >= startX && l.x <= endX && l.y >= startY && l.y <= endY))
	{
		l.brightness = l.brightness + (turnOn ? 1 : -1);
		if (l.brightness < 0)
			l.brightness = 0;
	}

	return lights;
}