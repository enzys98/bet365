using System;
using System.Collections.Generic;

namespace CEBet365Placer.Json;

[Serializable]
public class BetItem
{
	public string dbId { get; set; }

	public string bs { get; set; }

	public string runnerId { get; set; }

	public string handicap { get; set; }

	public double oddsDistance { get; set; }

	public double stake { get; set; }

	public string Leader { get; set; }

	public string tipster { get; set; }

	public string pick { get; set; }

	public double odds { get; set; }

	public bool isLive { get; set; }

	public bool isEW { get; set; }

	public bool isDouble { get; set; }

	public string match { get; set; }

	public double eventDistance { get; set; }

	public bool isValuebet { get; set; }

	public List<Account> userList { get; set; }

	public List<string> userTerms { get; set; }

	public int botCount { get; set; }

	public int selectionCount { get; set; }

	public int botIndex { get; set; }

	public DateTime timestamp { get; internal set; }

	public int retryCount { get; internal set; }

	public string ms { get; internal set; }
}
