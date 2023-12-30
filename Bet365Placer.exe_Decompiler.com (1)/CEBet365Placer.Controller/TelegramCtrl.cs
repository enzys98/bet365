using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading;
using CEBet365Placer.Json;
using Newtonsoft.Json.Linq;
using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;

namespace CEBet365Placer.Controller;

public class TelegramCtrl
{
	private TelegramBotClient botClient;

	private onProcNewTipEvent onProcNewTip;

	public TelegramCtrl(onProcNewTipEvent _onProcNewTip)
	{
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		//IL_001e: Expected O, but got Unknown
		onProcNewTip = _onProcNewTip;
		botClient = new TelegramBotClient("1754574634:AAGQ_LgtpZHla6Ic1lNF7B2-nVY3KXuk-oc", (HttpClient)null);
		botClient.OnMessage += Bot_OnMessage;
		botClient.OnUpdate += Bot_OnUpdate;
	}

	public void StartRecieve()
	{
		try
		{
			botClient.StartReceiving((UpdateType[])null, default(CancellationToken));
		}
		catch
		{
		}
	}

	private void Bot_OnMessage(object sender, MessageEventArgs e)
	{
		try
		{
			Console.WriteLine(e.Message.Text);
		}
		catch
		{
		}
	}

	private void Bot_OnUpdate(object sender, UpdateEventArgs e)
	{
	}

	public void sendMessage(string message)
	{
		try
		{
			botClient.SendTextMessageAsync(ChatId.op_Implicit(-1001807847384L), message, (ParseMode)0, false, false, 0, (IReplyMarkup)null, default(CancellationToken));
		}
		catch
		{
		}
	}

	public string GetLiveGame(TelegramTip tip)
	{
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		string result = string.Empty;
		try
		{
			new List<Bet365LiveGame>();
			HttpResponseMessage result2 = new HttpClient().GetAsync("http://91.121.70.201:9002/matchData.json").Result;
			result2.EnsureSuccessStatusCode();
			foreach (KeyValuePair<string, JToken> item in JObject.Parse(result2.Content.ReadAsStringAsync().Result))
			{
				foreach (JToken item2 in (IEnumerable<JToken>)item.Value)
				{
					try
					{
						if (item2[(object)"isLive"] == null || !(((object)item2[(object)"isLive"]).ToString().ToLower() == "true") || !(((object)item2[(object)"type"]).ToString() == "EV"))
						{
							continue;
						}
						int num = Utils.ParseToInt(((object)item2[(object)"sportId"]).ToString());
						new Bet365LiveGame();
						if (num == 1)
						{
							string text = ((object)item2[(object)"NA"]).ToString();
							((object)item2[(object)"C1"]).ToString();
							string arg = ((object)item2[(object)"C2"]).ToString();
							((object)item2[(object)"C3"]).ToString();
							string text2 = ((object)item2[(object)"SS"]).ToString();
							Utils.ParseToInt(text2.Split(new char[1] { '-' })[0].Trim());
							Utils.ParseToInt(text2.Split(new char[1] { '-' })[1].Trim());
							string text3 = $"https://www.{Setting.instance.bet365Domain}/#/IP/EV15{arg}2C{num}";
							if (Utils.isSameMatch_New(tip.match.ToLower(), text.ToLower()))
							{
								result = text3;
								break;
							}
						}
					}
					catch
					{
					}
				}
			}
		}
		catch
		{
		}
		return result;
	}

	public void ParseGoalStatus(string content)
	{
		try
		{
			content = content.Replace("[", string.Empty).Replace("]", string.Empty).Trim();
			Regex.Match(content, " (?<Score1>[\\d]+):?<Score2>[\\d]+)");
			if (!content.Contains("Gol!") && !content.Contains("[FINE PARTITA]") && !content.Contains("Fine primo tempo"))
			{
				content.Contains("Inizio secondo tempo");
			}
		}
		catch
		{
		}
	}
}
