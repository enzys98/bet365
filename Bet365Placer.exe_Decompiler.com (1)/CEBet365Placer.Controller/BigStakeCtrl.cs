using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using CEBet365Placer.Json;
using HtmlAgilityPack;
using Newtonsoft.Json.Linq;

namespace CEBet365Placer.Controller;

public class BigStakeCtrl
{
	private HttpClient client;

	public CookieContainer container = new CookieContainer();

	public string current_id = string.Empty;

	private TelegramTip lastTip;

	private static BigStakeCtrl _instance;

	public static BigStakeCtrl Intance => _instance;

	public BigStakeCtrl()
	{
		client = getHttpClient(container);
	}

	public static void CreateInstance()
	{
		_instance = new BigStakeCtrl();
	}

	private HttpClient getHttpClient(CookieContainer container)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0005: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Expected O, but got Unknown
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_004c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0062: Unknown result type (might be due to invalid IL or missing references)
		//IL_0078: Unknown result type (might be due to invalid IL or missing references)
		//IL_008e: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cc: Expected O, but got Unknown
		HttpClient val = new HttpClient((HttpMessageHandler)new HttpClientHandler
		{
			AutomaticDecompression = (DecompressionMethods.GZip | DecompressionMethods.Deflate),
			CookieContainer = container
		});
		ServicePointManager.DefaultConnectionLimit = 2;
		ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
		ServicePointManager.ServerCertificateValidationCallback = (object _003Cp0_003E, X509Certificate _003Cp1_003E, X509Chain _003Cp2_003E, SslPolicyErrors _003Cp3_003E) => true;
		((HttpHeaders)val.DefaultRequestHeaders).TryAddWithoutValidation("Accept", "*/*");
		((HttpHeaders)val.DefaultRequestHeaders).TryAddWithoutValidation("Accept-Language", "en-US,en;q=0.9");
		((HttpHeaders)val.DefaultRequestHeaders).TryAddWithoutValidation("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/67.0.3396.99 Safari/537.36");
		((HttpHeaders)val.DefaultRequestHeaders).TryAddWithoutValidation("X-Requested-With", "XMLHttpRequest");
		((HttpHeaders)val.DefaultRequestHeaders).TryAddWithoutValidation("Connection", "keep-alive");
		val.DefaultRequestHeaders.ExpectContinue = false;
		return val;
	}

	public bool DoLogin()
	{
		//IL_0075: Unknown result type (might be due to invalid IL or missing references)
		//IL_007f: Expected O, but got Unknown
		bool result = false;
		try
		{
			HttpResponseMessage result2 = client.PostAsync("https://www.bigstake.it/ajax.php", (HttpContent)new FormUrlEncodedContent((IEnumerable<KeyValuePair<string, string>>)new KeyValuePair<string, string>[4]
			{
				new KeyValuePair<string, string>("action", "dologin"),
				new KeyValuePair<string, string>("player", Setting.instance.bigStakUsername),
				new KeyValuePair<string, string>("password", Setting.instance.bigStakePass),
				new KeyValuePair<string, string>("lang", "en")
			})).Result;
			result2.EnsureSuccessStatusCode();
			if (((object)JObject.Parse(result2.Content.ReadAsStringAsync().Result)["esito"]).ToString() == "True")
			{
				result = true;
			}
		}
		catch
		{
		}
		return result;
	}

	public void GoToMasaniello(TelegramTip tip)
	{
		//IL_0062: Unknown result type (might be due to invalid IL or missing references)
		//IL_0067: Unknown result type (might be due to invalid IL or missing references)
		int num = 3;
		while (num-- > 0)
		{
			try
			{
				HttpResponseMessage result = client.GetAsync("https://www.bigstake.it/cassa/masaniello.php?id=" + Setting.instance.massId).Result;
				result.EnsureSuccessStatusCode();
				string result2 = result.Content.ReadAsStringAsync().Result;
				if (!result2.Contains(Setting.instance.bigStakUsername) && DoLogin())
				{
					continue;
				}
				HtmlDocument val = new HtmlDocument();
				val.LoadHtml(result2);
				IEnumerable<HtmlNode> enumerable = from node in val.DocumentNode.Descendants("table")
					where node.Attributes["class"] != null && node.Attributes["class"].Value == "table table-hover cell-center"
					select node;
				if (enumerable == null || enumerable.LongCount() == 0L)
				{
					break;
				}
				foreach (HtmlNode item in enumerable.ToArray()[0].Descendants("tbody").FirstOrDefault().Descendants("tr"))
				{
					IEnumerable<HtmlNode> source = item.Descendants("td");
					if (!(source.ToArray()[0].InnerText.Trim() == "0"))
					{
						current_id = source.ToArray()[0].InnerText.Trim();
						HtmlNode val2 = source.FirstOrDefault((Func<HtmlNode, bool>)((HtmlNode n) => n.Id != null && n.Id.Contains("stat")));
						if (val2 != null && val2.InnerText.Trim() != "Ongoing")
						{
							break;
						}
					}
				}
				UpdateRow("data", current_id, DateTime.Now.ToString("MM/dd/yyyy"));
				Thread.Sleep(1200);
				UpdateRow("partita", current_id, tip.match);
				Thread.Sleep(1200);
				UpdateRow("segno", current_id, tip.marketName);
				Thread.Sleep(1200);
				lastTip = tip;
			}
			catch
			{
			}
		}
	}

	public void GoToRossllo(TelegramTip tip)
	{
		//IL_009d: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a2: Unknown result type (might be due to invalid IL or missing references)
		int num = 3;
		while (num-- > 0)
		{
			try
			{
				HttpResponseMessage result = client.GetAsync("https://www.bigstake.it/cassa/roserpina.php?id=" + Setting.instance.rossId).Result;
				result.EnsureSuccessStatusCode();
				string result2 = result.Content.ReadAsStringAsync().Result;
				if (!result2.Contains(Setting.instance.bigStakUsername) && DoLogin())
				{
					continue;
				}
				HttpResponseMessage result3 = client.GetAsync("https://www.bigstake.it/cassa/roserpina.php?id=" + Setting.instance.rossId).Result;
				result3.EnsureSuccessStatusCode();
				result2 = result3.Content.ReadAsStringAsync().Result;
				HtmlDocument val = new HtmlDocument();
				val.LoadHtml(result2);
				IEnumerable<HtmlNode> enumerable = from node in val.DocumentNode.Descendants("table")
					where node.Attributes["class"] != null && node.Attributes["class"].Value == "table table-hover cell-center"
					select node;
				if (enumerable == null || enumerable.LongCount() == 0L)
				{
					break;
				}
				foreach (HtmlNode item in from node in enumerable.ToArray()[0].Descendants("tbody").FirstOrDefault().Descendants("tr")
					where node.Id != null && node.Id.Contains("tr")
					select node)
				{
					IEnumerable<HtmlNode> enumerable2 = item.Descendants("td");
					if (enumerable2 == null || enumerable2.LongCount() == 0L)
					{
						continue;
					}
					IEnumerable<HtmlNode> enumerable3 = from node in enumerable2.ToArray()[0].Descendants("input")
						where node.Attributes["id"] != null && node.Attributes["id"].Value.Contains("partita")
						select node;
					if (enumerable3 == null || enumerable3.LongCount() == 0L)
					{
						continue;
					}
					current_id = enumerable3.ToArray()[0].Attributes["data-step"].Value.ToString();
					string value = string.Empty;
					IEnumerable<HtmlNode> enumerable4 = item.Descendants("select");
					if (enumerable4 == null || enumerable4.LongCount() == 0L)
					{
						continue;
					}
					IEnumerable<HtmlNode> enumerable5 = from node in enumerable4.ToArray()[0].Descendants("option")
						where node.Attributes["selected"] != null
						select node;
					if (enumerable5 == null || enumerable5.LongCount() == 0L)
					{
						value = "";
					}
					else
					{
						switch (enumerable5.ToArray()[0].Attributes["value"].Value.ToString())
						{
						case "1":
							value = "Win";
							break;
						case "0":
							value = "Loss";
							break;
						case "2":
							value = "";
							break;
						}
					}
					if (string.IsNullOrEmpty(value))
					{
						break;
					}
				}
				UpdateRosRow("partita", current_id, tip.match);
				Thread.Sleep(1200);
				UpdateRosRow("segno", current_id, tip.marketName);
				lastTip = tip;
			}
			catch
			{
			}
		}
	}

	public double getLastStake()
	{
		//IL_00a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a6: Unknown result type (might be due to invalid IL or missing references)
		double result = -1.0;
		try
		{
			HttpResponseMessage result2 = client.GetAsync("https://www.bigstake.it/cassa/masaniello.php?id=" + Setting.instance.massId).Result;
			result2.EnsureSuccessStatusCode();
			string result3 = result2.Content.ReadAsStringAsync().Result;
			if (!result3.Contains(Setting.instance.bigStakUsername) && !DoLogin())
			{
				return result;
			}
			HttpResponseMessage result4 = client.GetAsync("https://www.bigstake.it/cassa/masaniello.php?id=" + Setting.instance.massId).Result;
			result4.EnsureSuccessStatusCode();
			result3 = result4.Content.ReadAsStringAsync().Result;
			HtmlDocument val = new HtmlDocument();
			val.LoadHtml(result3);
			IEnumerable<HtmlNode> enumerable = from node in val.DocumentNode.Descendants("table")
				where node.Attributes["class"] != null && node.Attributes["class"].Value == "table table-hover cell-center"
				select node;
			if (enumerable == null || enumerable.LongCount() == 0L)
			{
				return result;
			}
			foreach (HtmlNode item in enumerable.ToArray()[0].Descendants("tbody").FirstOrDefault().Descendants("tr"))
			{
				IEnumerable<HtmlNode> source = item.Descendants("td");
				if (source.ToArray()[0].InnerText.Trim() == "0")
				{
					continue;
				}
				current_id = source.ToArray()[0].InnerText.Trim();
				HtmlNode val2 = source.FirstOrDefault((Func<HtmlNode, bool>)((HtmlNode n) => n.Id != null && n.Id.Contains("stat")));
				if (val2 == null)
				{
					continue;
				}
				HtmlNode val3 = source.FirstOrDefault((Func<HtmlNode, bool>)((HtmlNode n) => n.Id != null && n.Id.Contains("giocata")));
				if (val3 != null)
				{
					result = Utils.parseToInt(val3.InnerText.Replace("€", "").Trim());
					if (val2.InnerText.Trim() != "Ongoing")
					{
						break;
					}
				}
			}
		}
		catch
		{
		}
		return result;
	}

	public double getRosLastStake()
	{
		//IL_00a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a6: Unknown result type (might be due to invalid IL or missing references)
		double result = -1.0;
		try
		{
			HttpResponseMessage result2 = client.GetAsync("https://www.bigstake.it/cassa/roserpina.php?id=" + Setting.instance.rossId).Result;
			result2.EnsureSuccessStatusCode();
			string result3 = result2.Content.ReadAsStringAsync().Result;
			if (!result3.Contains(Setting.instance.bigStakUsername) && !DoLogin())
			{
				return result;
			}
			HttpResponseMessage result4 = client.GetAsync("https://www.bigstake.it/cassa/roserpina.php?id=" + Setting.instance.rossId).Result;
			result4.EnsureSuccessStatusCode();
			result3 = result4.Content.ReadAsStringAsync().Result;
			HtmlDocument val = new HtmlDocument();
			val.LoadHtml(result3);
			IEnumerable<HtmlNode> enumerable = from node in val.DocumentNode.Descendants("table")
				where node.Attributes["class"] != null && node.Attributes["class"].Value == "table table-hover cell-center"
				select node;
			if (enumerable == null || enumerable.LongCount() == 0L)
			{
				return result;
			}
			foreach (HtmlNode item in enumerable.ToArray()[0].Descendants("tbody").FirstOrDefault().Descendants("tr"))
			{
				IEnumerable<HtmlNode> enumerable2 = item.Descendants("td");
				if (enumerable2 == null || enumerable2.LongCount() == 0L)
				{
					continue;
				}
				IEnumerable<HtmlNode> enumerable3 = from node in enumerable2.ToArray()[0].Descendants("input")
					where node.Attributes["id"] != null && node.Attributes["id"].Value.Contains("partita")
					select node;
				if (enumerable3 == null || enumerable3.LongCount() == 0L)
				{
					continue;
				}
				current_id = enumerable2.ToArray()[0].Descendants("input").First().Attributes["data-step"].Value.ToString();
				IEnumerable<HtmlNode> enumerable4 = from node in item.Descendants("select")
					where node.Id != null && node.Id.Contains("esito")
					select node;
				if (enumerable4 == null || enumerable4.LongCount() == 0L)
				{
					continue;
				}
				string value = string.Empty;
				IEnumerable<HtmlNode> enumerable5 = from node in enumerable4.ToArray()[0].Descendants("option")
					where node.Attributes["selected"] != null
					select node;
				if (enumerable5 == null || enumerable5.LongCount() == 0L)
				{
					value = "";
				}
				else
				{
					switch (enumerable5.ToArray()[0].Attributes["value"].Value.ToString())
					{
					case "1":
						value = "Win";
						break;
					case "0":
						value = "Loss";
						break;
					case "2":
						value = "";
						break;
					}
				}
				if (!string.IsNullOrEmpty(value))
				{
					continue;
				}
				HtmlNode val2 = enumerable2.FirstOrDefault((Func<HtmlNode, bool>)((HtmlNode n) => n.Id != null && n.Id.Contains("giocata")));
				if (val2 != null)
				{
					string text = val2.InnerText.Trim();
					if (string.IsNullOrWhiteSpace(text))
					{
						break;
					}
					result = Utils.parseToInt(text.Replace("€", "").Trim());
					if (string.IsNullOrEmpty(value))
					{
						break;
					}
				}
			}
		}
		catch
		{
		}
		return result;
	}

	public void UpdateRow(string type, string tbId, string val)
	{
		//IL_006d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0077: Expected O, but got Unknown
		try
		{
			GetCurrentMasaId();
			HttpResponseMessage result = client.PostAsync("https://www.bigstake.it/cassa/ajax.php", (HttpContent)new FormUrlEncodedContent((IEnumerable<KeyValuePair<string, string>>)new KeyValuePair<string, string>[4]
			{
				new KeyValuePair<string, string>("masaid", Setting.instance.massId),
				new KeyValuePair<string, string>("type", type),
				new KeyValuePair<string, string>("id", current_id),
				new KeyValuePair<string, string>("value", val)
			})).Result;
			result.EnsureSuccessStatusCode();
			_ = result.Content.ReadAsStringAsync().Result;
		}
		catch
		{
		}
	}

	public void UpdateRosRow(string type, string tbId, string val)
	{
		//IL_0083: Unknown result type (might be due to invalid IL or missing references)
		//IL_008d: Expected O, but got Unknown
		try
		{
			GetCurrentRossId();
			HttpResponseMessage result = client.PostAsync("https://www.bigstake.it/cassa/ajax.php", (HttpContent)new FormUrlEncodedContent((IEnumerable<KeyValuePair<string, string>>)new KeyValuePair<string, string>[5]
			{
				new KeyValuePair<string, string>("progr", "roserpina"),
				new KeyValuePair<string, string>("roseid", Setting.instance.rossId),
				new KeyValuePair<string, string>("type", type),
				new KeyValuePair<string, string>("step", current_id),
				new KeyValuePair<string, string>("value", val)
			})).Result;
			result.EnsureSuccessStatusCode();
			_ = result.Content.ReadAsStringAsync().Result;
		}
		catch
		{
		}
	}

	public void GetCurrentMasaId()
	{
		//IL_0055: Unknown result type (might be due to invalid IL or missing references)
		//IL_005a: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			string result2;
			do
			{
				HttpResponseMessage result = client.GetAsync("https://www.bigstake.it/cassa/masaniello.php?id=" + Setting.instance.massId).Result;
				result.EnsureSuccessStatusCode();
				result2 = result.Content.ReadAsStringAsync().Result;
			}
			while (!result2.Contains(Setting.instance.bigStakUsername) && DoLogin());
			HtmlDocument val = new HtmlDocument();
			val.LoadHtml(result2);
			IEnumerable<HtmlNode> enumerable = from node in val.DocumentNode.Descendants("table")
				where node.Attributes["class"] != null && node.Attributes["class"].Value == "table table-hover cell-center"
				select node;
			if (enumerable == null || enumerable.LongCount() == 0L)
			{
				return;
			}
			foreach (HtmlNode item in enumerable.ToArray()[0].Descendants("tbody").FirstOrDefault().Descendants("tr"))
			{
				IEnumerable<HtmlNode> source = item.Descendants("td");
				if (!(source.ToArray()[0].InnerText.Trim() == "0"))
				{
					current_id = source.ToArray()[0].InnerText.Trim();
					HtmlNode val2 = source.FirstOrDefault((Func<HtmlNode, bool>)((HtmlNode n) => n.Id != null && n.Id.Contains("stat")));
					if (val2 != null && val2.InnerText.Trim() != "Ongoing")
					{
						break;
					}
				}
			}
		}
		catch
		{
		}
	}

	public void GetCurrentRossId()
	{
		//IL_003b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0040: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			HttpResponseMessage result = client.GetAsync("https://www.bigstake.it/cassa/roserpina.php?id=" + Setting.instance.rossId).Result;
			result.EnsureSuccessStatusCode();
			string result2 = result.Content.ReadAsStringAsync().Result;
			HtmlDocument val = new HtmlDocument();
			val.LoadHtml(result2);
			IEnumerable<HtmlNode> enumerable = from node in val.DocumentNode.Descendants("table")
				where node.Attributes["class"] != null && node.Attributes["class"].Value == "table table-hover cell-center"
				select node;
			if (enumerable == null || enumerable.LongCount() == 0L)
			{
				return;
			}
			foreach (HtmlNode item in from node in enumerable.ToArray()[0].Descendants("tbody").FirstOrDefault().Descendants("tr")
				where node.Id != null && node.Id.Contains("tr")
				select node)
			{
				IEnumerable<HtmlNode> enumerable2 = item.Descendants("td");
				if (enumerable2 == null || enumerable2.LongCount() == 0L)
				{
					continue;
				}
				IEnumerable<HtmlNode> enumerable3 = from node in enumerable2.ToArray()[0].Descendants("input")
					where node.Attributes["id"] != null && node.Attributes["id"].Value.Contains("partita")
					select node;
				if (enumerable3 == null || enumerable3.LongCount() == 0L)
				{
					continue;
				}
				current_id = enumerable3.ToArray()[0].Attributes["data-step"].Value.ToString();
				IEnumerable<HtmlNode> enumerable4 = from node in item.Descendants("select")
					where node.Id != null && node.Id.Contains("esito")
					select node;
				if (enumerable4 == null || enumerable4.LongCount() == 0L)
				{
					continue;
				}
				string value = string.Empty;
				IEnumerable<HtmlNode> enumerable5 = from node in enumerable4.ToArray()[0].Descendants("option")
					where node.Attributes["selected"] != null
					select node;
				if (enumerable5 == null || enumerable5.LongCount() == 0L)
				{
					value = "";
				}
				else
				{
					switch (enumerable5.ToArray()[0].Attributes["value"].Value.ToString())
					{
					case "1":
						value = "Win";
						break;
					case "0":
						value = "Loss";
						break;
					case "2":
						value = "";
						break;
					}
				}
				HtmlNode val2 = enumerable2.FirstOrDefault((Func<HtmlNode, bool>)((HtmlNode n) => n.Id != null && n.Id.Contains("giocata")));
				if (val2 != null)
				{
					val2.InnerText.Trim();
					if (string.IsNullOrEmpty(value))
					{
						break;
					}
				}
			}
		}
		catch
		{
		}
	}
}
