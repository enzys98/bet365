namespace CEBet365Placer.Json;

public class TelegramTip
{
	public string dbId = string.Empty;

	public string sport { get; set; } = string.Empty;


	public string country { get; set; } = string.Empty;


	public string league { get; set; } = string.Empty;


	public string dateTime { get; set; } = string.Empty;


	public string match { get; set; } = string.Empty;


	public string score { get; set; }

	public string EW { get; set; } = "0";


	public string marketName { get; set; } = string.Empty;


	public string selection { get; set; } = string.Empty;


	public double odds { get; set; }

	public double handicap { get; set; }

	public double minHandicap { get; set; }

	public string period { get; set; } = string.Empty;


	public string fract_odds { get; set; } = string.Empty;


	public string selectionId { get; set; } = string.Empty;


	public string matchId { get; set; } = string.Empty;


	public double stake { get; set; } = 1.0;


	public string link { get; set; } = "bet365.com";


	public double arbPercent { get; set; }

	public string tipster { get; set; } = string.Empty;


	public string output { get; set; } = string.Empty;


	public bool bFinished { get; set; }

	public string channel { get; set; }

	public TIPSOURCE tipSource { get; set; }
}
