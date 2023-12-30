using System.Collections.Generic;

namespace CEBet365Placer.Json;

public class BetSlipJson
{
	public string bg { get; set; }

	public int sr { get; set; }

	public string cc { get; set; }

	public string pc { get; set; }

	public bool mr { get; set; }

	public bool ir { get; set; }

	public int at { get; set; }

	public string vr { get; set; }

	public bool tx { get; set; }

	public int cs { get; set; }

	public int st { get; set; }

	public List<BetSlipItem> bt { get; set; } = new List<BetSlipItem>();


	public Dm dm { get; set; } = new Dm();


	public List<Dm> mo { get; set; } = new List<Dm>();


	public List<int> bs { get; set; } = new List<int>();

}
