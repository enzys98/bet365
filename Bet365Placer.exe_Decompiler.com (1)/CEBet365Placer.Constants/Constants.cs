namespace CEBet365Placer.Constants;

public static class Constants
{
	public static string googleKey = "";

	public static string[] DisabledBookies = new string[7] { "betfair", "matchbook", "sbobet", "smarkets", "pinnacle", "dafabetsports", "dafabet" };

	public static string formatString = "\"{0}\",\"{1}\",\"{2}\",\"{3}\",\"{4}\",\"{5}\",\"{6}\",\"{7}\",\"{8}\"";

	public static string headerString = "\"Time\", \"Started\",\"%\",\"ROI\",\"Bookie\",\"Sport\",\"Event\",\"Outcome\",\"Odds\"";

	public static string formatStringBet = "\"{0}\",\"{1}\",\"{2}\",\"{3}\",\"{4}\",\"{5}\",\"{6}\",\"{7}\",\"{8}\",\"{9}\",\"{10}\",\"{11}\"";

	public static string headerStringBet = "\"Time\",\"Sport\",\"Event\",\"Arb(%)\",\"Outcome\",\"Odds\",\"League\",\"Sharp Bookie\",\"Stake\",\"Event Date\",\"Bet Ref\",\"Result\"";

	public static string formatStringBestOddsBet = "\"{0}\",\"{1}\",\"{2}\",\"{3}\",\"{4}\",\"{5}\",\"{6}\",\"{7}\",\"{8}\",\"{9}\",\"{10}\",\"{11}\",\"{12}\",\"{13}\"";

	public static string headerStringBestOddsBet = "\"TXN Time\",\"Event Time\",\"Margin(%)\",\"Profit\",\"Bookie\",\"Event\",\"League\",\"Outcome\",\"Odds\",\"Stake\",\"MaxStake\",\"Source\",\"Placed\",\"Status\"";

	public static string formatStringBestLog = "\"{0}\",\"{1}\",\"{2}\",\"{3}\",\"{4}\",\"{5}\",\"{6}\"";

	public static string headerStringBestLog = "\"Time placed\",\"Time Event\",\"Event\",\"League\",\"Selection\",\"Odds Log\",\"Placed Log\"";

	public static string formatLiveArbInfoString = "\"{0}\",\"{1}\",\"{2}\",\"{3}\",\"{4}\",\"{5}\",\"{6}\",\"{7}\",\"{8}\",\"{9}\"";

	public static string headerLiveArbInfoString = "\"Time\", \"Started\",\"%\",\"ROI\",\"Bookie\",\"Sport\",\"Event\",\"Score\",\"Outcome\",\"Odds\"";

	public static string formatLiveBetString = "\"{0}\",\"{1}\",\"{2}\",\"{3}\",\"{4}\",\"{5}\",\"{6}\",\"{7}\",\"{8}\",\"{9}\",\"{10}\",\"{11}\"";

	public static string headerLiveBetString = "\"Time\",\"%\",\"Bookie\",\"Sport\",\"Event\",\"Event Time\",\"Score\",\"Outcome\",\"Margin(%)\",\"Odds\",\"Stake\",\"Success\"";

	public static string csvFile { get; set; }

	public static string csvFileBet { get; set; }

	public static string csvFileBestLog { get; set; }
}
