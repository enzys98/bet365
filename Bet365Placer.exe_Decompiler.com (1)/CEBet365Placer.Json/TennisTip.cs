namespace CEBet365Placer.Json;

public class TennisTip
{
	public long date { get; set; }

	public string tournament { get; set; }

	public string level { get; set; }

	public string player1 { get; set; }

	public string player2 { get; set; }

	public string selection { get; set; }

	public double selectionOdds { get; set; }

	public double probability { get; set; }

	public double expectedYield { get; set; }

	public double minValueOdds { get; set; }

	public bool recommended { get; set; }

	public string marketId { get; set; }

	public string selectionId { get; set; }

	public string marketName { get; set; }

	public Market market { get; set; }

	public string link { get; set; }
}
