namespace CEBet365Placer.Json;

public class LiveMatchScore
{
	public string home { get; set; }

	public string away { get; set; }

	public string score { get; set; }

	public GAMETIME gameTime { get; set; } = GAMETIME.END;

}
