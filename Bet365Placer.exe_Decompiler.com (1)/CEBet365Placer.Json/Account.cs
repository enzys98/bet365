using System;

namespace CEBet365Placer.Json;

[Serializable]
public class Account
{
	public string _id { get; set; }

	public double stakePercent { get; set; }

	public string b365Username { get; set; }

	public string b365Password { get; set; }

	public string b365Email { get; set; }

	public string domain { get; set; }

	public string proxy { get; set; }

	public string unitStake { get; set; }

	public bool isFlatStake { get; set; }

	public bool isLimited { get; set; }

	public bool isBlocked { get; set; }

	public string keyword { get; set; }

	public double balance { get; set; }

	public string avaliable { get; set; } = "N/A";


	public string Running { get; set; } = "N/A";


	public Account()
	{
		b365Username = string.Empty;
		b365Password = string.Empty;
		proxy = string.Empty;
		isLimited = false;
		keyword = "BET365";
	}

	public Account(string _username, string _password)
	{
		b365Username = _username;
		b365Password = _password;
		isLimited = false;
	}
}
