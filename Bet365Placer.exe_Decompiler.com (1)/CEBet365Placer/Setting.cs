using System;
using System.Collections.Generic;
using System.IO;
using CEBet365Placer.Constants;
using CEBet365Placer.Json;
using Microsoft.Win32;

namespace CEBet365Placer;

public class Setting
{
	private static Setting _instance;

	public List<TelegramTip> successInfos = new List<TelegramTip>();

	public static Setting instance
	{
		get
		{
			if (_instance == null)
			{
				_instance = new Setting();
			}
			return _instance;
		}
	}

	public bool isOnline { get; set; }

	public dynamic BotSetting { get; set; }

	public string betUsername { get; set; }

	public string betPassword { get; set; }

	public string bet365Domain { get; set; }

	public string bigStakUsername { get; set; }

	public string bigStakePass { get; set; }

	public string massId { get; set; }

	public string rossId { get; set; }

	public string channel { get; set; }

	public int RemoteDebuggingPort { get; set; }

	public string serverAddr { get; set; }

	public string ProxyUrl { get; set; }

	public string proxyServer { get; set; }

	public string proxyUser { get; set; }

	public string proxyPass { get; set; }

	public string license { get; set; }

	public bool bUseOxylab { get; set; }

	public bool bBetburger { get; set; }

	public bool bBash { get; set; }

	public bool bAusDog { get; set; }

	public bool bUkDog { get; set; }

	public bool bAusHorse { get; set; }

	public bool bAusHarness { get; set; }

	public bool bH2hDog { get; set; }

	public bool bH2hHorse { get; set; }

	public string profileId { get; set; } = "9222";


	public string sessionUrl => "https://www." + instance.bet365Domain + "/sessionactivityapi/setlastactiontime";

	public bool isLeader { get; set; }

	public bool isKeepSessionAlive { get; set; }

	public bool isBlockedUser
	{
		get
		{
			if (account == null)
			{
				return false;
			}
			return account.isBlocked;
		}
	}

	public string version { get; set; }

	public int ProxyPort { get; internal set; }

	public int botIndex { get; internal set; }

	public Account account { get; internal set; } = new Account();


	public List<Account> accounts { get; set; } = new List<Account>();


	public double stake { get; set; }

	public double fStake { get; set; } = 1.0;


	public double minOdds { get; set; }

	public double maxOdds { get; set; }

	public List<TelegramTip> failedResults { get; set; } = new List<TelegramTip>();


	public List<TelegramTip> totalTennisTips { get; set; } = new List<TelegramTip>();


	public List<TelegramTip> failedTips { get; set; } = new List<TelegramTip>();


	public decimal numAgentPort { get; set; }

	public decimal innerHeight { get; set; }

	public decimal innerWidth { get; set; }

	public double heightDiff { get; set; }

	public int browserType { get; set; }

	public string key { get; set; }

	public string salt { get; set; }

	public StakeMethod stakeMethod { get; set; }

	public TIPSOURCE tipsterSource { get; set; }

	public RUNMODE RunMode { get; set; }

	public bool UseHorseRacing { get; set; }

	public bool UseDombetting { get; set; }

	public bool UseCopybetting { get; set; }

	public bool UseTelegram { get; set; }

	public bool UseHandball { get; set; }

	public bool UseLivebet { get; set; }

	public double kellySize { get; set; }

	public bool UseWOdds { get; set; }

	public bool AcceptChangeOdds { get; set; }

	public int maxbetCnt { get; set; } = 1;


	public bool bFirstHalf { get; set; }

	public bool bFullTime { get; set; }

	public double stake05 { get; set; }

	public double odds05 { get; set; }

	public double stake15 { get; set; }

	public double odds15 { get; set; }

	public double stake25 { get; set; }

	public double odds25 { get; set; }

	public double stake35 { get; set; }

	public double odds35 { get; set; }

	public double stake45 { get; set; }

	public double odds45 { get; set; }

	public double stake55 { get; set; }

	public double odds55 { get; set; }

	public double stake65 { get; set; }

	public double odds65 { get; set; }

	public double stake75 { get; set; }

	public double odds75 { get; set; }

	public double stake05HT { get; set; }

	public double odds05HT { get; set; }

	public double stake15HT { get; set; }

	public double odds15HT { get; set; }

	public double stake25HT { get; set; }

	public double odds25HT { get; set; }

	public double stake10m { get; set; }

	public double odds10m { get; set; }

	public double stake20m { get; set; }

	public double odds20m { get; set; }

	public double stake30m { get; set; }

	public double odds30m { get; set; }

	public double stake40m { get; set; }

	public double odds40m { get; set; }

	public double stake50m { get; set; }

	public double odds50m { get; set; }

	public double stake60m { get; set; }

	public double odds60m { get; set; }

	public double stake70m { get; set; }

	public double odds70m { get; set; }

	public double stake80m { get; set; }

	public double odds80m { get; set; }

	public double stakeU25 { get; set; }

	public double oddsU25 { get; set; }

	public double stakeU35 { get; set; }

	public double oddsU35 { get; set; }

	public double stakeU45 { get; set; }

	public double oddsU45 { get; set; }

	public double stakehGoal { get; set; }

	public double oddshGoal { get; set; }

	public double stakeAGoal { get; set; }

	public double oddsAGoal { get; set; }

	public double stakeGGoal { get; set; }

	public double oddsGGoal { get; set; }

	public bool UsingMass1 { get; set; }

	public bool UsingMass2 { get; set; }

	public bool UsingMass3 { get; set; }

	public bool UsingMass4 { get; set; }

	public bool UsingRos1 { get; set; }

	public bool UsingRos2 { get; set; }

	public bool UsingRos3 { get; set; }

	public bool UsingRos4 { get; set; }

	public int tableIndex { get; set; }

	public Setting()
	{
		serverAddr = "http://37.187.91.64:5002";
		proxyServer = string.Empty;
		RemoteDebuggingPort = 25000;
		stake = 0.0;
		minOdds = 1.4;
		maxOdds = 50.0;
		ProxyUrl = "";
		proxyUser = "";
		proxyPass = "";
		numAgentPort = 8880m;
	}

	public string Between(string STR, string FirstString, string LastString)
	{
		if (!STR.Contains(FirstString))
		{
			return string.Empty;
		}
		int startIndex = STR.IndexOf(FirstString) + FirstString.Length;
		if (LastString != null)
		{
			STR = STR.Substring(startIndex);
			int num = STR.IndexOf(LastString);
			if (num > 0)
			{
				return STR.Substring(0, num);
			}
			return STR;
		}
		return STR.Substring(startIndex);
	}

	public string ReplaceStr(string STR, string ReplaceSTR, string FirstString, string LastString)
	{
		int num = STR.IndexOf(FirstString) + FirstString.Length;
		if (LastString != null)
		{
			string text = STR.Substring(0, num);
			int startIndex = STR.IndexOf(LastString, num);
			return text + ReplaceSTR + STR.Substring(startIndex);
		}
		return STR.Substring(0, num) + ReplaceSTR;
	}

	public string ReadRegistry(string KeyName)
	{
		_ = instance.betUsername;
		return Registry.CurrentUser.CreateSubKey("SoftWare").CreateSubKey("Bet365-Rep").GetValue(KeyName, "")
			.ToString();
	}

	public void WriteRegistry(string KeyName, string KeyValue)
	{
		try
		{
			_ = instance.betUsername;
			Registry.CurrentUser.CreateSubKey("SoftWare").CreateSubKey("Bet365-Rep").SetValue(KeyName, KeyValue);
		}
		catch
		{
		}
	}

	public string ReadAccountInfo()
	{
		try
		{
			return File.ReadAllText("account.txt");
		}
		catch (Exception)
		{
		}
		return ":";
	}

	public void WriteAccountInfo(string KeyName)
	{
		File.WriteAllText("account.txt", KeyName);
	}

	public void saveSettingInfo()
	{
		WriteAccountInfo(instance.betUsername + ":" + instance.betPassword);
		WriteRegistry("channel", instance.channel);
		WriteRegistry("serverAddr", instance.serverAddr);
		WriteRegistry("BrowserType", instance.browserType.ToString());
		WriteRegistry("RunMode", instance.RunMode.ToString());
		WriteRegistry("bet365Username", instance.betUsername);
		WriteRegistry("bet365Password", instance.betPassword);
		WriteRegistry("bet365Domain", instance.bet365Domain);
		WriteRegistry("stakemethod", instance.stakeMethod.ToString());
		WriteRegistry("bigStakeUsername", instance.bigStakUsername.ToString());
		WriteRegistry("bigStakePassword", instance.bigStakePass.ToString());
		WriteRegistry("bigStakeId", instance.massId);
		WriteRegistry("RossId", instance.rossId);
		WriteRegistry("stake05", instance.stake05.ToString());
		WriteRegistry("odds05", instance.odds05.ToString());
		WriteRegistry("stake15", instance.stake15.ToString());
		WriteRegistry("odds15", instance.odds15.ToString());
		WriteRegistry("stake25", instance.stake25.ToString());
		WriteRegistry("odds25", instance.odds25.ToString());
		WriteRegistry("stake35", instance.stake35.ToString());
		WriteRegistry("odds35", instance.odds35.ToString());
		WriteRegistry("stake45", instance.stake45.ToString());
		WriteRegistry("odds45", instance.odds45.ToString());
		WriteRegistry("stake55", instance.stake55.ToString());
		WriteRegistry("odds55", instance.odds55.ToString());
		WriteRegistry("stake65", instance.stake65.ToString());
		WriteRegistry("odds65", instance.odds65.ToString());
		WriteRegistry("stake75", instance.stake75.ToString());
		WriteRegistry("odds75", instance.odds75.ToString());
		WriteRegistry("stake10m", instance.stake10m.ToString());
		WriteRegistry("odds10m", instance.odds10m.ToString());
		WriteRegistry("stake20m", instance.stake20m.ToString());
		WriteRegistry("odds20m", instance.odds20m.ToString());
		WriteRegistry("stake30m", instance.stake30m.ToString());
		WriteRegistry("odds30m", instance.odds30m.ToString());
		WriteRegistry("stake40m", instance.stake40m.ToString());
		WriteRegistry("odds40m", instance.odds40m.ToString());
		WriteRegistry("stake50m", instance.stake50m.ToString());
		WriteRegistry("odds50m", instance.odds50m.ToString());
		WriteRegistry("stake60m", instance.stake60m.ToString());
		WriteRegistry("odds60m", instance.odds60m.ToString());
		WriteRegistry("stake70m", instance.stake70m.ToString());
		WriteRegistry("odds70m", instance.odds70m.ToString());
		WriteRegistry("stake80m", instance.stake80m.ToString());
		WriteRegistry("odds80m", instance.odds80m.ToString());
		WriteRegistry("stake05HT", instance.stake05HT.ToString());
		WriteRegistry("odds05HT", instance.odds05HT.ToString());
		WriteRegistry("stake15HT", instance.stake15HT.ToString());
		WriteRegistry("odds15HT", instance.odds15HT.ToString());
		WriteRegistry("stake25HT", instance.stake25HT.ToString());
		WriteRegistry("odds25HT", instance.odds25HT.ToString());
		WriteRegistry("stakeU25", instance.stakeU25.ToString());
		WriteRegistry("oddsU25", instance.oddsU25.ToString());
		WriteRegistry("stakeU35", instance.stakeU35.ToString());
		WriteRegistry("oddsU35", instance.oddsU35.ToString());
		WriteRegistry("stakeU45", instance.stakeU45.ToString());
		WriteRegistry("oddsU45", instance.oddsU45.ToString());
		WriteRegistry("stakehGoal", instance.stakehGoal.ToString());
		WriteRegistry("oddshGoal", instance.oddshGoal.ToString());
		WriteRegistry("stakeAGoal", instance.stakeAGoal.ToString());
		WriteRegistry("oddsAGoal", instance.oddsAGoal.ToString());
		WriteRegistry("stakeGGoal", instance.stakeGGoal.ToString());
		WriteRegistry("oddsGGoal", instance.oddsGGoal.ToString());
	}

	public void loadSettingInfo()
	{
		_ = ReadAccountInfo().Split(new char[1] { ':' }).Length;
		_ = 2;
		instance.channel = ReadRegistry("channel");
		instance.serverAddr = ReadRegistry("serverAddr");
		instance.betUsername = ReadRegistry("bet365Username");
		instance.betPassword = ReadRegistry("bet365Password");
		instance.bet365Domain = ReadRegistry("bet365Domain");
		instance.stakeMethod = ((!(ReadRegistry("stakemethod") == "Fixed")) ? ((ReadRegistry("stakemethod") == "Masaniello") ? StakeMethod.Masaniello : StakeMethod.Roserpina) : StakeMethod.Fixed);
		instance.RunMode = ((ReadRegistry("RunMode") == "SCRIPT") ? RUNMODE.SCRIPT : RUNMODE.UI);
		instance.bigStakUsername = ReadRegistry("bigStakeUsername");
		instance.bigStakePass = ReadRegistry("bigStakePassword");
		instance.massId = ReadRegistry("bigStakeId");
		instance.rossId = ReadRegistry("RossId");
		instance.stake05 = Utils.ParseToDouble(ReadRegistry("stake05"));
		instance.odds05 = Utils.ParseToDouble(ReadRegistry("odds05"));
		instance.stake15 = Utils.ParseToDouble(ReadRegistry("stake15"));
		instance.odds15 = Utils.ParseToDouble(ReadRegistry("odds15"));
		instance.stake25 = Utils.ParseToDouble(ReadRegistry("stake25"));
		instance.odds25 = Utils.ParseToDouble(ReadRegistry("odds25"));
		instance.stake35 = Utils.ParseToDouble(ReadRegistry("stake35"));
		instance.odds35 = Utils.ParseToDouble(ReadRegistry("odds35"));
		instance.stake45 = Utils.ParseToDouble(ReadRegistry("stake45"));
		instance.odds45 = Utils.ParseToDouble(ReadRegistry("odds45"));
		instance.stake55 = Utils.ParseToDouble(ReadRegistry("stake55"));
		instance.odds55 = Utils.ParseToDouble(ReadRegistry("odds55"));
		instance.stake65 = Utils.ParseToDouble(ReadRegistry("stake65"));
		instance.odds65 = Utils.ParseToDouble(ReadRegistry("odds65"));
		instance.stake75 = Utils.ParseToDouble(ReadRegistry("stake75"));
		instance.odds75 = Utils.ParseToDouble(ReadRegistry("odds75"));
		instance.stake10m = Utils.ParseToDouble(ReadRegistry("stake10m"));
		instance.odds10m = Utils.ParseToDouble(ReadRegistry("odds10m"));
		instance.stake20m = Utils.ParseToDouble(ReadRegistry("stake20m"));
		instance.odds20m = Utils.ParseToDouble(ReadRegistry("odds20m"));
		instance.stake30m = Utils.ParseToDouble(ReadRegistry("stake30m"));
		instance.odds30m = Utils.ParseToDouble(ReadRegistry("odds30m"));
		instance.stake40m = Utils.ParseToDouble(ReadRegistry("stake40m"));
		instance.odds40m = Utils.ParseToDouble(ReadRegistry("odds40m"));
		instance.stake50m = Utils.ParseToDouble(ReadRegistry("stake50m"));
		instance.odds50m = Utils.ParseToDouble(ReadRegistry("odds50m"));
		instance.stake60m = Utils.ParseToDouble(ReadRegistry("stake60m"));
		instance.odds60m = Utils.ParseToDouble(ReadRegistry("odds60m"));
		instance.stake70m = Utils.ParseToDouble(ReadRegistry("stake70m"));
		instance.odds70m = Utils.ParseToDouble(ReadRegistry("odds70m"));
		instance.stake80m = Utils.ParseToDouble(ReadRegistry("stake80m"));
		instance.odds80m = Utils.ParseToDouble(ReadRegistry("odds80m"));
		instance.stake05HT = Utils.ParseToDouble(ReadRegistry("stake05HT"));
		instance.odds05HT = Utils.ParseToDouble(ReadRegistry("odds05HT"));
		instance.stake15HT = Utils.ParseToDouble(ReadRegistry("stake15HT"));
		instance.odds15HT = Utils.ParseToDouble(ReadRegistry("odds15HT"));
		instance.stake25HT = Utils.ParseToDouble(ReadRegistry("stake25HT"));
		instance.odds25HT = Utils.ParseToDouble(ReadRegistry("odds25HT"));
		instance.stakeU25 = Utils.ParseToDouble(ReadRegistry("stakeU25"));
		instance.oddsU25 = Utils.ParseToDouble(ReadRegistry("oddsU25"));
		instance.stakeU35 = Utils.ParseToDouble(ReadRegistry("stakeU35"));
		instance.oddsU35 = Utils.ParseToDouble(ReadRegistry("oddsU35"));
		instance.stakeU45 = Utils.ParseToDouble(ReadRegistry("stakeU45"));
		instance.oddsU45 = Utils.ParseToDouble(ReadRegistry("oddsU45"));
		instance.stakehGoal = Utils.ParseToDouble(ReadRegistry("stakehGoal"));
		instance.oddshGoal = Utils.ParseToDouble(ReadRegistry("oddshGoal"));
		instance.stakeAGoal = Utils.ParseToDouble(ReadRegistry("stakeAGoal"));
		instance.oddsAGoal = Utils.ParseToDouble(ReadRegistry("oddsAGoal"));
		instance.stakeGGoal = Utils.ParseToDouble(ReadRegistry("stakeGGoal"));
		instance.oddsGGoal = Utils.ParseToDouble(ReadRegistry("oddsGGoal"));
	}

	private bool readBoolKey(string keyname, bool def = false)
	{
		try
		{
			string text = ReadRegistry(keyname);
			if (string.IsNullOrEmpty(text))
			{
				return def;
			}
			return text == "true";
		}
		catch
		{
			return def;
		}
	}

	private double readDoubleKey(string keyname, double def = 0.0)
	{
		try
		{
			string text = ReadRegistry(keyname);
			if (string.IsNullOrEmpty(text))
			{
				return def;
			}
			return Utils.ParseToDouble(text);
		}
		catch
		{
			return def;
		}
	}
}
