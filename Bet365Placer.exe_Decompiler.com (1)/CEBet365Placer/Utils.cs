using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using CEBet365Placer.Constants;
using CEBet365Placer.Controller;
using CEBet365Placer.Json;

namespace CEBet365Placer;

public class Utils
{
	private static NumberStyles style = NumberStyles.Number | NumberStyles.AllowCurrencySymbol;

	private static CultureInfo culture = CultureInfo.CreateSpecificCulture("en-GB");

	public static Dictionary<double, string> FactionalPaired = new Dictionary<double, string>
	{
		{ 1.1, "1/10" },
		{ 1.11, "1/9" },
		{ 1.12, "1/8" },
		{ 1.14, "1/7" },
		{ 1.17, "1/6" },
		{ 1.2, "1/5" },
		{ 1.2222222222222223, "2/9" },
		{ 1.25, "1/4" },
		{ 1.2857142857142856, "2/7" },
		{ 1.3, "3/10" },
		{ 1.3333333333333333, "1/3" },
		{ 1.3636363636363638, "4/11" },
		{ 1.4, "2/5" },
		{ 1.4444444444444444, "4/9" },
		{ 1.5, "1/2" },
		{ 1.5333333333333332, "8/15" },
		{ 1.5714285714285714, "4/7" },
		{ 1.6153846153846154, "8/13" },
		{ 1.6666666666666665, "4/6" },
		{ 1.7272727272727273, "8/11" },
		{ 1.8, "4/5" },
		{ 1.8333333333333335, "5/6" },
		{ 1.9090909090909092, "10/11" },
		{ 2.0, "1/1" },
		{ 2.1, "11/10" },
		{ 2.2, "6/5" },
		{ 2.25, "5/4" },
		{ 2.375, "11/8" },
		{ 2.4, "7/5" },
		{ 2.5, "6/4" },
		{ 2.6, "8/5" },
		{ 2.625, "13/8" },
		{ 2.75, "7/4" },
		{ 2.8, "9/5" },
		{ 2.875, "15/8" },
		{ 3.0, "2/1" },
		{ 3.2, "11/5" },
		{ 3.25, "9/4" },
		{ 3.4, "12/5" },
		{ 3.5, "5/2" },
		{ 3.6, "13/5" },
		{ 3.75, "11/4" },
		{ 4.0, "7/4" },
		{ 4.333333333333334, "10/3" },
		{ 4.5, "7/2" },
		{ 5.0, "4/1" },
		{ 5.5, "9/2" },
		{ 6.0, "5/1" },
		{ 6.5, "11/2" },
		{ 7.0, "6/1" },
		{ 7.5, "13/2" },
		{ 8.0, "7/1" },
		{ 8.5, "15/2" },
		{ 9.0, "8/1" },
		{ 9.5, "17/2" },
		{ 10.0, "9/1" }
	};

	public static int ParseToInt(string str)
	{
		int result = 0;
		int.TryParse(str, out result);
		return result;
	}

	public static decimal ParseToDecimal(string str)
	{
		decimal result = default(decimal);
		decimal.TryParse(str, style, culture, out result);
		return result;
	}

	public static double ParseToDouble(string str)
	{
		double result = 0.0;
		str = str.Replace(",", ".");
		double.TryParse(str, style, culture, out result);
		return result;
	}

	public static long getTick()
	{
		return (long)(DateTime.UtcNow - new DateTime(1970, 1, 1)).TotalMilliseconds;
	}

	public static int parseToInt(string str)
	{
		int result = 0;
		str = str.Replace(",", ".");
		int.TryParse(str, style, culture, out result);
		return result;
	}

	public static string DecryptMessage(string AuthorizationCode, string keyString, string ivString)
	{
		byte[] bytes = Encoding.ASCII.GetBytes(keyString);
		byte[] bytes2 = Encoding.ASCII.GetBytes(ivString);
		using RijndaelManaged rijndaelManaged = new RijndaelManaged
		{
			Key = bytes,
			IV = bytes2,
			Mode = CipherMode.CBC
		};
		rijndaelManaged.BlockSize = 128;
		rijndaelManaged.KeySize = 256;
		using MemoryStream stream = new MemoryStream(Convert.FromBase64String(AuthorizationCode));
		using CryptoStream stream2 = new CryptoStream(stream, rijndaelManaged.CreateDecryptor(bytes, bytes2), CryptoStreamMode.Read);
		return new StreamReader(stream2).ReadToEnd();
	}

	public static List<List<BetItem>> SplitList(List<BetItem> locations, int nSize = 2)
	{
		List<List<BetItem>> list = new List<List<BetItem>>();
		for (int i = 0; i < locations.Count; i += nSize)
		{
			list.Add(locations.GetRange(i, Math.Min(nSize, locations.Count - i)));
		}
		return list;
	}

	public static bool IsContainsLeague(List<string> leagueList, string league)
	{
		foreach (string league2 in leagueList)
		{
			if (league.StartsWith(league2))
			{
				return true;
			}
		}
		return false;
	}

	public static string GenerateRandomNumberString(int length)
	{
		StringBuilder stringBuilder = new StringBuilder();
		Random random = new Random();
		for (int i = 0; i < length; i++)
		{
			stringBuilder.Append(random.Next(0, 10));
		}
		return stringBuilder.ToString();
	}

	public static int GetRandValue(int minValue, int maxValue, bool pon = false)
	{
		int num = maxValue - minValue + 1;
		return (int)Math.Floor(new Random().NextDouble() * (double)num + (double)minValue) * ((!pon) ? 1 : _pon());
	}

	public static int _pon()
	{
		if (GetRandValue(10) < 5)
		{
			return -1;
		}
		return 1;
	}

	public static int GetRandValue(int maxValue)
	{
		return new Random().Next(0, maxValue);
	}

	public static string GetUserAgent(string username)
	{
		try
		{
			int num = Math.Abs(username.GetHashCode());
			string[] array = File.ReadAllLines("user-agent.txt");
			int num2 = array.Length - 1;
			return array[Math.Abs(num % num2)];
		}
		catch (Exception)
		{
		}
		return "Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:91.0) Gecko/20100101 Firefox/91.0";
	}

	public static string Between(string STR, string FirstString, string LastString = null)
	{
		if (!STR.Contains(FirstString))
		{
			return STR;
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

	public static string Decrypt(string cipherText)
	{
		string password = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ";
		cipherText = cipherText.Replace(" ", "+");
		byte[] array = Convert.FromBase64String(cipherText);
		using Aes aes = Aes.Create();
		Rfc2898DeriveBytes rfc2898DeriveBytes = new Rfc2898DeriveBytes(password, new byte[13]
		{
			73, 118, 97, 110, 32, 77, 101, 100, 118, 101,
			100, 101, 118
		});
		aes.Key = rfc2898DeriveBytes.GetBytes(32);
		aes.IV = rfc2898DeriveBytes.GetBytes(16);
		using MemoryStream memoryStream = new MemoryStream();
		using (CryptoStream cryptoStream = new CryptoStream(memoryStream, aes.CreateDecryptor(), CryptoStreamMode.Write))
		{
			cryptoStream.Write(array, 0, array.Length);
			cryptoStream.Close();
		}
		cipherText = Encoding.Unicode.GetString(memoryStream.ToArray());
		return cipherText;
	}

	public static IEnumerable<T[]> Chunk<T>(IEnumerable<T> source, int chunksize)
	{
		IList<T> list = (source as IList<T>) ?? source.ToList();
		for (int start = 0; start < list.Count; start += chunksize)
		{
			T[] array = new T[Math.Min(chunksize, list.Count - start)];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = list[start + i];
			}
			yield return array;
		}
	}

	public static double getDistance(string team1, string team2)
	{
		return JaroWinklerDistance.distance(team1, team2);
	}

	public static bool isSameMatch(string team1, string team2, bool bAdvanced = false)
	{
		try
		{
			string text = string.Empty;
			string text2 = string.Empty;
			string text3 = string.Empty;
			string text4 = string.Empty;
			if (team1.Contains(" vs "))
			{
				text = Regex.Split(team1, " vs ")[0].Trim();
				text3 = Regex.Split(team1, " vs ")[1].Trim();
			}
			else if (team1.Contains(" v "))
			{
				text = Regex.Split(team1, " v ")[0].Trim();
				text3 = Regex.Split(team1, " v ")[1].Trim();
			}
			else if (team1.Contains(" @ "))
			{
				text = Regex.Split(team1, " @ ")[0].Trim();
				text3 = Regex.Split(team1, " @ ")[1].Trim();
			}
			else if (team1.Contains(" - "))
			{
				text = Regex.Split(team1, " - ")[0].Trim();
				text3 = Regex.Split(team1, " - ")[1].Trim();
			}
			if (team2.Contains(" vs "))
			{
				text2 = Regex.Split(team2, " vs ")[0].Trim();
				text4 = Regex.Split(team2, " vs ")[1].Trim();
			}
			else if (team2.Contains(" v "))
			{
				text2 = Regex.Split(team2, " v ")[0].Trim();
				text4 = Regex.Split(team2, " v ")[1].Trim();
			}
			else if (team2.Contains(" @ "))
			{
				text2 = Regex.Split(team2, " @ ")[0].Trim();
				text4 = Regex.Split(team2, " @5 ")[1].Trim();
			}
			else if (team2.Contains(" - "))
			{
				text2 = Regex.Split(team2, " - ")[0].Trim();
				text4 = Regex.Split(team2, " - ")[1].Trim();
			}
			if (text == text2 && text3 == text4)
			{
				return true;
			}
			if (text == text2 || text3.Contains(text4) || text4.Contains(text3) || (JaroWinklerDistance.distance(text3, text4) < 0.15 && JaroWinklerDistance.distance(text, text2) < 0.15))
			{
				return true;
			}
			if (text3 == text4 || text.Contains(text2) || text2.Contains(text) || (JaroWinklerDistance.distance(text, text2) < 0.15 && JaroWinklerDistance.distance(text3, text4) < 0.15))
			{
				return true;
			}
			if (bAdvanced && (text.Contains(text2) || text2.Contains(text) || JaroWinklerDistance.distance(text, text2) < 0.15) && (text3.Contains(text4) || text4.Contains(text3) || JaroWinklerDistance.distance(text3, text4) < 0.15))
			{
				return true;
			}
			return false;
		}
		catch (Exception)
		{
		}
		return false;
	}

	public static bool isSameName(string team1, string team2)
	{
		try
		{
			if (team1 == team2)
			{
				return true;
			}
			if (team1 == team2 || team1.Contains(team2) || team2.Contains(team1) || JaroWinklerDistance.distance(team1, team2) < 0.2)
			{
				return true;
			}
			return false;
		}
		catch (Exception)
		{
		}
		return false;
	}

	public static double FractionToDouble(string fraction)
	{
		if (double.TryParse(fraction, out var result))
		{
			return result;
		}
		string[] array = fraction.Split(' ', '/');
		if ((array.Length == 2 || array.Length == 3) && int.TryParse(array[0], out var result2) && int.TryParse(array[1], out var result3))
		{
			if (array.Length == 2)
			{
				return 1.0 + Math.Floor(100.0 * (double)result2 / (double)result3) / 100.0;
			}
			if (int.TryParse(array[2], out var result4))
			{
				return (double)result2 + (double)result3 / (double)result4;
			}
		}
		throw new FormatException("Not a valid fraction. => " + fraction);
	}

	public static double getHandicap(string handicap)
	{
		double num = 100.0;
		if (handicap.Contains(","))
		{
			return (ParseToDouble(handicap.Split(new char[1] { ',' })[0].Trim()) + ParseToDouble(handicap.Split(new char[1] { ',' })[1].Trim())) / 2.0;
		}
		return ParseToDouble(handicap);
	}

	public static double GetStake(double balance, TelegramTip tip, double newOdds, ref double odds)
	{
		double result = 0.0;
		if (Setting.instance.stakeMethod == StakeMethod.Fixed)
		{
			if (tip.period == "FT")
			{
				if (tip.marketName == "OVER 0.5")
				{
					result = Setting.instance.stake05;
					odds = Setting.instance.odds05;
				}
				else if (tip.marketName == "OVER 1.5")
				{
					result = Setting.instance.stake15;
					odds = Setting.instance.odds15;
				}
				else if (tip.marketName == "OVER 2.5")
				{
					result = Setting.instance.stake25;
					odds = Setting.instance.odds25;
				}
				else if (tip.marketName == "OVER 3.5")
				{
					result = Setting.instance.stake35;
					odds = Setting.instance.odds35;
				}
				else if (tip.marketName == "OVER 4.5")
				{
					result = Setting.instance.stake45;
					odds = Setting.instance.odds45;
				}
				else if (tip.marketName == "OVER 5.5")
				{
					result = Setting.instance.stake55;
					odds = Setting.instance.odds55;
				}
				else if (tip.marketName == "OVER 6.5")
				{
					result = Setting.instance.stake65;
					odds = Setting.instance.odds65;
				}
				else if (tip.marketName == "OVER 7.5")
				{
					result = Setting.instance.stake75;
					odds = Setting.instance.odds75;
				}
				else if (tip.marketName == "UNDER 2.5")
				{
					result = Setting.instance.stakeU25;
					odds = Setting.instance.oddsU25;
				}
				else if (tip.marketName == "UNDER 3.5")
				{
					result = Setting.instance.stakeU35;
					odds = Setting.instance.oddsU35;
				}
				else if (tip.marketName == "UNDER 4.5")
				{
					result = Setting.instance.stakeU45;
					odds = Setting.instance.oddsU45;
				}
				else if (tip.marketName == "Both Teams to Score")
				{
					result = Setting.instance.stakeGGoal;
					odds = Setting.instance.oddsGGoal;
				}
				else if (tip.marketName == "next goal")
				{
					result = Setting.instance.stakehGoal;
					odds = Setting.instance.oddshGoal;
				}
			}
			else if (tip.period == "HT")
			{
				if (tip.marketName == "OVER 0.5 HT")
				{
					result = Setting.instance.stake05HT;
					odds = Setting.instance.odds05HT;
				}
				else if (tip.marketName == "OVER 1.5 HT")
				{
					result = Setting.instance.stake15HT;
					odds = Setting.instance.odds15HT;
				}
				else if (tip.marketName == "OVER 2.5 HT")
				{
					result = Setting.instance.stake25HT;
					odds = Setting.instance.odds25HT;
				}
			}
		}
		else if (Setting.instance.stakeMethod == StakeMethod.Masaniello)
		{
			BigStakeCtrl.Intance.UpdateRow("quota", BigStakeCtrl.Intance.current_id, newOdds.ToString());
			Thread.Sleep(1000);
			result = BigStakeCtrl.Intance.getLastStake();
		}
		else if (Setting.instance.stakeMethod == StakeMethod.Roserpina)
		{
			BigStakeCtrl.Intance.UpdateRosRow("quota", BigStakeCtrl.Intance.current_id, newOdds.ToString());
			Thread.Sleep(1000);
			result = BigStakeCtrl.Intance.getRosLastStake();
		}
		return result;
	}

	public static string decimalToFraction(double decimalOdds)
	{
		string text = string.Empty;
		try
		{
			foreach (KeyValuePair<double, string> item in FactionalPaired)
			{
				if (decimalOdds == item.Key)
				{
					text = item.Value;
					break;
				}
			}
			text = (string.IsNullOrEmpty(text) ? nearestPair(decimalOdds) : text);
		}
		catch
		{
		}
		return text;
	}

	public static string nearestPair(double goal)
	{
		string result = string.Empty;
		double num = 0.0;
		try
		{
			foreach (KeyValuePair<double, string> item in FactionalPaired)
			{
				if (num == 0.0 || Math.Abs(item.Key - goal) < Math.Abs(num - goal))
				{
					num = item.Key;
					result = item.Value;
				}
			}
		}
		catch
		{
		}
		return result;
	}

	public static string GetEventLink(TelegramTip tip)
	{
		string result = string.Empty;
		try
		{
			if (tip.sport == "Soccer")
			{
				if (tip.period == "Ordinary Time" && tip.marketName == "Asian Handicap")
				{
					result = "https://www." + Setting.instance.bet365Domain + "/#/AC/B1/C1/D8/E" + tip.matchId + "/F3/I3/";
				}
				else if (tip.period == "1st Half (Ordinary Time)" && tip.marketName == "Asian Handicap")
				{
					result = "https://www." + Setting.instance.bet365Domain + "/#/AC/B1/C1/D8/E" + tip.matchId + "/F3/I7/";
				}
				else if (tip.period == "Ordinary Time" && tip.marketName == "Full Time Result")
				{
					result = "https://www." + Setting.instance.bet365Domain + "/#/AC/B1/C1/D8/E" + tip.matchId + "/F3/I1/";
				}
				else if (tip.period == "1st Half (Ordinary Time)" && tip.marketName == "Full Time Result")
				{
					result = "https://www." + Setting.instance.bet365Domain + "/#/AC/B1/C1/D8/E" + tip.matchId + "/F3/I7/";
				}
				else if (tip.marketName == "Draw No Bet")
				{
					result = "https://www." + Setting.instance.bet365Domain + "/#/AC/B1/C1/D8/E" + tip.matchId + "/F3/I1/";
				}
				else if (tip.period == "Ordinary Time" && tip.marketName == "Total Goals")
				{
					result = ((ParseToDouble(tip.selection.Replace("Over", string.Empty).Replace("Under", string.Empty).Trim()) * 100.0 % 100.0 != 50.0) ? ("https://www." + Setting.instance.bet365Domain + "/#/AC/B1/C1/D8/E" + tip.matchId + "/F3/I3/") : ("https://www." + Setting.instance.bet365Domain + "/#/AC/B1/C1/D8/E" + tip.matchId + "/F3/I6/"));
				}
				else if (tip.period == "1st Half (Ordinary Time)" && tip.marketName == "Total Goals")
				{
					result = "https://www." + Setting.instance.bet365Domain + "/#/AC/B1/C1/D8/E" + tip.matchId + "/F3/I3/";
				}
			}
		}
		catch
		{
		}
		return result;
	}

	public static void SpliteTeam(string team, ref string home, ref string away)
	{
		if (team.Contains(" vs "))
		{
			home = Regex.Split(team, " vs ")[0].Trim();
			away = Regex.Split(team, " vs ")[1].Trim();
		}
		else if (team.Contains(" v "))
		{
			home = Regex.Split(team, " v ")[0].Trim();
			away = Regex.Split(team, " v ")[1].Trim();
		}
		else if (team.Contains(" @ "))
		{
			home = Regex.Split(team, " @ ")[0].Trim();
			away = Regex.Split(team, " @ ")[1].Trim();
		}
		else if (team.Contains(" - "))
		{
			home = Regex.Split(team, " - ")[0].Trim();
			away = Regex.Split(team, " - ")[1].Trim();
		}
	}

	public static bool isSameMatch_New(string team1, string team2, bool bAdvanced = false)
	{
		try
		{
			string text = string.Empty;
			string text2 = string.Empty;
			string text3 = string.Empty;
			string text4 = string.Empty;
			if (team1.Contains(" vs "))
			{
				text = Regex.Split(team1, " vs ")[0].Trim();
				text3 = Regex.Split(team1, " vs ")[1].Trim();
			}
			else if (team1.Contains(" v "))
			{
				text = Regex.Split(team1, " v ")[0].Trim();
				text3 = Regex.Split(team1, " v ")[1].Trim();
			}
			else if (team1.Contains(" @ "))
			{
				text = Regex.Split(team1, " @ ")[0].Trim();
				text3 = Regex.Split(team1, " @ ")[1].Trim();
			}
			else if (team1.Contains(" - "))
			{
				text = Regex.Split(team1, " - ")[0].Trim();
				text3 = Regex.Split(team1, " - ")[1].Trim();
			}
			if (team2.Contains(" vs "))
			{
				text2 = Regex.Split(team2, " vs ")[0].Trim();
				text4 = Regex.Split(team2, " vs ")[1].Trim();
			}
			else if (team2.Contains(" v "))
			{
				text2 = Regex.Split(team2, " v ")[0].Trim();
				text4 = Regex.Split(team2, " v ")[1].Trim();
			}
			else if (team2.Contains(" @ "))
			{
				text2 = Regex.Split(team2, " @ ")[0].Trim();
				text4 = Regex.Split(team2, " @ ")[1].Trim();
			}
			else if (team2.Contains(" - "))
			{
				text2 = Regex.Split(team2, " - ")[0].Trim();
				text4 = Regex.Split(team2, " - ")[1].Trim();
			}
			if (text == text2 && text3 == text4)
			{
				return true;
			}
			if (text == text2 || text3.Contains(text4) || text4.Contains(text3) || (JaroWinklerDistance.distance(text3, text4) < 0.2 && JaroWinklerDistance.distance(text, text2) < 0.2))
			{
				return true;
			}
			if (text3 == text4 || text.Contains(text2) || text2.Contains(text) || (JaroWinklerDistance.distance(text, text2) < 0.2 && JaroWinklerDistance.distance(text3, text4) < 0.2))
			{
				return true;
			}
			if (bAdvanced && (text.Contains(text2) || text2.Contains(text) || JaroWinklerDistance.distance(text, text2) < 0.2) && (text3.Contains(text4) || text4.Contains(text3) || JaroWinklerDistance.distance(text3, text4) < 0.2))
			{
				return true;
			}
			return false;
		}
		catch (Exception)
		{
		}
		return false;
	}

	public static bool isSameMatch(string mHome, string mAway, string eHome, string eAway, bool bAdvanced = false)
	{
		try
		{
			if (mHome == eHome && mAway == eAway)
			{
				return true;
			}
			if (mHome == eHome || mAway.Contains(eAway) || eAway.Contains(mAway) || (JaroWinklerDistance.distance(mAway, eAway) < 0.2 && JaroWinklerDistance.distance(mHome, eHome) < 0.2))
			{
				return true;
			}
			if (mAway == eAway || mHome.Contains(eHome) || eHome.Contains(mHome) || (JaroWinklerDistance.distance(mHome, eHome) < 0.2 && JaroWinklerDistance.distance(mAway, eAway) < 0.2))
			{
				return true;
			}
			if (bAdvanced && (mHome.Contains(eHome) || eHome.Contains(mHome) || JaroWinklerDistance.distance(mHome, eHome) < 0.2) && (mAway.Contains(eAway) || eAway.Contains(mAway) || JaroWinklerDistance.distance(mAway, eAway) < 0.2))
			{
				return true;
			}
			return false;
		}
		catch (Exception)
		{
		}
		return false;
	}

	public static int GetScoreNum(string score)
	{
		int num = parseToInt(score.Split(new char[1] { ':' })[0].Trim());
		int num2 = parseToInt(score.Split(new char[1] { ':' })[1].Trim());
		return num + num2;
	}
}
