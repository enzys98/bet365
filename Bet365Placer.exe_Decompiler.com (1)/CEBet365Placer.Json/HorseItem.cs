using System;

namespace CEBet365Placer.Json;

public class HorseItem
{
	public int no { get; set; }

	public string league { get; set; }

	public double arbPercent { get; set; }

	public string match { get; set; }

	public double odds { get; set; }

	public string bs { get; set; }

	public string runnerId { get; set; }

	public string directLink { get; set; }

	public long foundTime { get; set; }

	public string handicap { get; set; }

	public bool isEW { get; set; }

	public int retryCount { get; set; }

	public DateTime timestamp { get; set; }

	public string ms { get; set; }

	public HorseItem()
	{
		isEW = false;
		ms = string.Empty;
	}
}
