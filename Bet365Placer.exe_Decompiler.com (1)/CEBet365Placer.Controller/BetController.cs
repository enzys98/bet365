using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using CEBet365Placer.Constants;
using CEBet365Placer.Json;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using WindowsInput;
using WindowsInput.Native;

namespace CEBet365Placer.Controller;

public class BetController
{
	private const int MOUSEEVENTF_MOVE = 1;

	private const int MOUSEEVENTF_LEFTDOWN = 2;

	private const int MOUSEEVENTF_LEFTUP = 4;

	private const int MOUSEEVENTF_RIGHTDOWN = 8;

	private const int MOUSEEVENTF_RIGHTUP = 16;

	private const int MOUSEEVENTF_MIDDLEDOWN = 32;

	private const int MOUSEEVENTF_MIDDLEUP = 64;

	private const int MOUSEEVENTF_XDOWN = 128;

	private const int MOUSEEVENTF_XUP = 256;

	private const int MOUSEEVENTF_WHEEL = 2048;

	private const int MOUSEEVENTF_VIRTUALDESK = 16384;

	private const int MOUSEEVENTF_ABSOLUTE = 32768;

	private static BetController _instance;

	private onWriteStatusEvent m_handlerWriteStatus;

	private onWriteLogEvent m_handlerWriteLog;

	private onWriteResultEvent m_resultEvent;

	private onUpdateStatusEvent m_updateStatus;

	private int betCount;

	private double _balance;

	private double _lastMaxStake;

	public string _lastBetGuid = string.Empty;

	protected const int _TIMEOUT_SESSION_LOCKED = 5000;

	protected const int _TIMEOUT_ODDS_CHANGED = 7000;

	protected const int _TIMEOUT_ZERO_MS = 3000;

	private const string strLoginScript = "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";

	private const string strInjectScript = "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";

	protected List<HorseItem> _retryBetList = new List<HorseItem>();

	protected string _GUID = string.Empty;

	private Account m_account;

	private List<dynamic> placebetResults = new List<object>();

	public int totalBetCnt;

	public bool _isInjected;

	public bool WaitingForLogin;

	public bool PlacingBet;

	public string RespBody = string.Empty;

	private bool isArrivedJSResult;

	private string _jsResult;

	private string stake_pos = string.Empty;

	private string placebetBtn_pos = string.Empty;

	public List<Settledbet> settledbets = new List<Settledbet>();

	public int refreshCnt;

	public TelegramTip pendingTip;

	public bool _isPageLoaded { get; set; }

	public bool WaitingForAPI { get; private set; }

	public static BetController Intance => _instance;

	public DateTime _lastCallPlaceBet { get; private set; }

	public bool LOGGED { get; internal set; }

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Auto)]
	public static extern void mouse_event(int dwFlags, int dx, int dy, int cButtons, int dwExtraInfo);

	[DllImport("user32")]
	public static extern int SetCursorPos(int x, int y);

	public BetController(onWriteStatusEvent _handlerWriteStatus, onWriteLogEvent _handlerWriteLog, onWriteResultEvent resultEvent, onUpdateStatusEvent updateStatus)
	{
		m_handlerWriteStatus = _handlerWriteStatus;
		m_handlerWriteLog = _handlerWriteLog;
		m_resultEvent = resultEvent;
		m_updateStatus = updateStatus;
		_GUID = Guid.NewGuid().ToString();
		m_account = Setting.instance.account;
	}

	public static void CreateInstance(onWriteStatusEvent _handlerWriteStatus, onWriteLogEvent _handlerWriteLog, onWriteResultEvent resultEvent, onUpdateStatusEvent updateStatus)
	{
		_instance = new BetController(_handlerWriteStatus, _handlerWriteLog, resultEvent, updateStatus);
	}

	public string GetCurrentURL()
	{
		string result = string.Empty;
		try
		{
			result = Global.CurrentUrl("");
		}
		catch
		{
		}
		return result;
	}

	public bool CheckIfJSLibLoaded()
	{
		try
		{
			string jsCode = Guard.Algorithms.DecryptData(Global.FindSearchScript);
			string text = ExecuteScript(jsCode, requiredResult: true);
			if (!string.IsNullOrEmpty(text) && !text.Contains("Empty"))
			{
				return true;
			}
		}
		catch (Exception)
		{
		}
		return false;
	}

	public void WebResourceResponseReceived(JObject message)
	{
		try
		{
			string text = string.Empty;
			string text2 = ((object)((JToken)message).SelectToken("url")).ToString().ToLower();
			if (((JToken)message).SelectToken("response") != null)
			{
				text = ((object)((JToken)message).SelectToken("response")).ToString();
			}
			else if (((JToken)message).SelectToken("response") == null)
			{
				return;
			}
			if (text2 == "jsresult")
			{
				isArrivedJSResult = true;
				_jsResult = text;
			}
			if (text2.Contains("recaptcha/enterprise.js?render="))
			{
				_isPageLoaded = true;
			}
			else if (text2.Contains("uicountersapi/increment"))
			{
				_isPageLoaded = true;
			}
			else if (text2.Contains("recaptcha/enterprise"))
			{
				_isPageLoaded = true;
			}
			else if (text2.Contains("defaultapi/sports-configuration"))
			{
				WaitingForLogin = false;
				if (text.ToLower().Contains(Setting.instance.account.b365Username.ToLower()))
				{
					LOGGED = true;
				}
				else
				{
					LOGGED = false;
				}
			}
			else if (text2.Contains("betswebapi"))
			{
				RespBody = text;
				WaitingForAPI = false;
			}
		}
		catch (Exception)
		{
		}
	}

	private bool Is365HomePage(string currentUrl)
	{
		if (currentUrl.Contains("setlastactiontime") || !currentUrl.Contains(m_account.domain))
		{
			return false;
		}
		return true;
	}

	public int GetMyBetsCount()
	{
		int result = 0;
		try
		{
			result = Utils.parseToInt(ExecuteScript("Locator.treeLookup.getReference('OPENBETS').data.BC", requiredResult: true));
		}
		catch (Exception)
		{
		}
		return result;
	}

	public void AdjustPosition()
	{
		try
		{
			if (Setting.instance.browserType == 0)
			{
				Setting.instance.heightDiff = 0.0;
			}
			else
			{
				Setting.instance.heightDiff = 91.0;
			}
		}
		catch
		{
		}
	}

	public bool SearchMatchWithName(string eventName)
	{
		//IL_0215: Unknown result type (might be due to invalid IL or missing references)
		//IL_021c: Expected O, but got Unknown
		refreshCnt++;
		if (refreshCnt == 4)
		{
			DoLoad365Page("https://" + Setting.instance.bet365Domain + "/#/HO/");
			refreshCnt = 0;
		}
		string scriptResult = ExecuteScript("JSON.stringify(ns_sitesearchlib_ui_header.SearchHeader.Instance.closeButton._active_element.getBoundingClientRect())", requiredResult: true);
		ClickOnPoint(scriptResult);
		string empty = string.Empty;
		string empty2 = string.Empty;
		if (eventName.Contains(" vs "))
		{
			empty = Regex.Split(eventName, " vs ")[0].Trim();
			empty2 = Regex.Split(eventName, " vs ")[1].Trim();
		}
		else if (eventName.Contains(" v "))
		{
			empty = Regex.Split(eventName, " v ")[0].Trim();
			empty2 = Regex.Split(eventName, " v ")[1].Trim();
		}
		else if (eventName.Contains(" @ "))
		{
			empty = Regex.Split(eventName, " @ ")[0].Trim();
			empty2 = Regex.Split(eventName, " @ ")[1].Trim();
		}
		else if (eventName.Contains(" - "))
		{
			empty = Regex.Split(eventName, " - ")[0].Trim();
			empty2 = Regex.Split(eventName, " - ")[1].Trim();
		}
		else
		{
			empty = eventName;
			empty2 = eventName;
		}
		if (empty.Contains("(") && empty.Contains(")"))
		{
			empty = Utils.Between("xx" + empty, "xx", "(");
		}
		if (empty2.Contains("(") && empty2.Contains(")"))
		{
			empty2 = Utils.Between("xx" + empty2, "xx", "(");
		}
		bool flag = false;
		int num = 0;
		string text = string.Empty;
		Path.GetDirectoryName(Application.ExecutablePath);
		string jsCode = Guard.Algorithms.DecryptData(Global.FindSearchScript);
		string jsCode2 = Guard.Algorithms.DecryptData(Global.FindEventNameScript);
		while (num < 2)
		{
			switch (num)
			{
			case 0:
				text = empty;
				break;
			case 1:
				text = empty2;
				break;
			}
			scriptResult = ExecuteScript(jsCode, requiredResult: true);
			ClickOnPoint(scriptResult);
			scriptResult = ExecuteScript("JSON.stringify(ns_sitesearchlib_ui_header.SearchHeader.Instance.searchInput._active_element.getBoundingClientRect())", requiredResult: true);
			ClickOnPoint(scriptResult, ClickType.TripleClick);
			InputSimulator val = new InputSimulator();
			char[] array = text.ToCharArray();
			foreach (char c in array)
			{
				Thread.Sleep(Utils.GetRandValue(10, 100));
				val.Keyboard.TextEntry(c);
			}
			Thread.Sleep(1200);
			scriptResult = ExecuteScript(jsCode2, requiredResult: true);
			if (scriptResult == "Not Search Event")
			{
				m_handlerWriteStatus("Not Search Event");
				ExecuteScript("ns_sitesearchlib_ui_header.SearchHeader.Instance.clearButton.clickHandler()");
				num++;
				continue;
			}
			try
			{
				List<SearchEvent> list = JsonConvert.DeserializeObject<List<SearchEvent>>(scriptResult);
				SearchEvent searchEvent = new SearchEvent();
				double num2 = 0.15;
				if (list.Count > 0)
				{
					num2 = Utils.getDistance(eventName, list[0].name);
					searchEvent = list[0];
				}
				foreach (SearchEvent item in list)
				{
					if (item.position.x != 0.0 || item.position.y != 0.0)
					{
						double distance = Utils.getDistance(eventName, item.name);
						m_handlerWriteStatus(item.name + " Dis :" + distance);
						if (num2 > distance)
						{
							num2 = distance;
							searchEvent = item;
						}
					}
				}
				if (!string.IsNullOrEmpty(searchEvent.name))
				{
					flag = CLickOnPoint((int)searchEvent.position.x, (int)searchEvent.position.y + 10);
					break;
				}
			}
			catch
			{
			}
			if (flag)
			{
				break;
			}
			num++;
		}
		scriptResult = ExecuteScript("ns_sitesearchlib_ui_header.SearchHeader.Instance.closeButton._active_element.getBoundingClientRect();", requiredResult: true);
		ClickOnPoint(scriptResult);
		return flag;
	}

	public bool SearchHorseWithName(string eventName, ref TelegramTip betItem)
	{
		//IL_00b5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bc: Expected O, but got Unknown
		betCount++;
		if (betCount > 10)
		{
			DoLoad365Page();
			betCount = 0;
		}
		string scriptResult = ExecuteScript("JSON.stringify(ns_sitesearchlib_ui_header.SearchHeader.Instance.closeButton._active_element.getBoundingClientRect())", requiredResult: true);
		ClickOnPoint(scriptResult);
		bool flag = false;
		int num = 0;
		Path.GetDirectoryName(Application.ExecutablePath);
		string jsCode = Guard.Algorithms.DecryptData(Global.FindSearchScript);
		string jsCode2 = Guard.Algorithms.DecryptData(Global.horseOddsScript);
		string text = Guard.Algorithms.DecryptData(Global.FineTabScript);
		text = text.Replace("[sport]", "'Horse Racing'");
		while (num < 2)
		{
			scriptResult = ExecuteScript(jsCode, requiredResult: true);
			ClickOnPoint(scriptResult);
			scriptResult = ExecuteScript("JSON.stringify(ns_sitesearchlib_ui_header.SearchHeader.Instance.searchInput._active_element.getBoundingClientRect())", requiredResult: true);
			ClickOnPoint(scriptResult, ClickType.TripleClick);
			InputSimulator val = new InputSimulator();
			char[] array = eventName.ToCharArray();
			foreach (char c in array)
			{
				Thread.Sleep(Utils.GetRandValue(10, 100));
				val.Keyboard.TextEntry(c);
			}
			Thread.Sleep(3000);
			string text2 = ExecuteScript(text, requiredResult: true);
			if (!string.IsNullOrEmpty(text2))
			{
				ClickOnPoint(text2);
			}
			scriptResult = ExecuteScript(jsCode2, requiredResult: true);
			if (scriptResult == "Not Search Event")
			{
				m_handlerWriteStatus("Not Search Event");
				ExecuteScript("ns_sitesearchlib_ui_header.SearchHeader.Instance.clearButton.clickHandler()");
				num++;
				continue;
			}
			try
			{
				List<HorseEvent> list = (from n in JsonConvert.DeserializeObject<List<HorseEvent>>(scriptResult)
					where n.N2 == "Win and Each Way" && n.OD != "0/0"
					select n).ToList();
				HorseEvent horseEvent = new HorseEvent();
				double num2 = 0.15;
				if (list.Count > 0)
				{
					num2 = Utils.getDistance(eventName, list[0].NA);
					horseEvent = list[0];
				}
				foreach (HorseEvent item in list)
				{
					double distance = Utils.getDistance(eventName, item.NA);
					m_handlerWriteStatus(item.NA + " Dis :" + distance);
					if (num2 > distance)
					{
						num2 = distance;
						horseEvent = item;
					}
				}
				if (!string.IsNullOrEmpty(horseEvent.NA))
				{
					flag = true;
					betItem.selectionId = horseEvent.ID;
					betItem.matchId = horseEvent.FI;
					break;
				}
			}
			catch
			{
			}
			if (flag)
			{
				break;
			}
			num++;
		}
		return flag;
	}

	public Bet365Feed FindOdds(TelegramTip tip)
	{
		Bet365Feed result = new Bet365Feed();
		string jsCode = Guard.Algorithms.DecryptData(Global.ExanpGroupScript);
		ExecuteScript(jsCode);
		Thread.Sleep(new Random().Next(1000, 2000));
		string jsCode2 = Guard.Algorithms.DecryptData(Global.GetAllDataScript);
		int num = 0;
		bool flag = false;
		while (num < 3)
		{
			try
			{
				Thread.Sleep(400);
				List<Bet365Feed> list = JsonConvert.DeserializeObject<List<Bet365Feed>>(ExecuteScript(jsCode2, requiredResult: true));
				if (list == null || list.LongCount() == 0L)
				{
					num++;
					continue;
				}
				List<Bet365Feed> list2 = list.Where((Bet365Feed node) => string.IsNullOrEmpty(node.MA) && string.IsNullOrEmpty(node.NA)).ToList();
				if (list2 != null && list2.Count > 0)
				{
					num++;
					continue;
				}
				if (tip.period == "FT")
				{
					if (tip.marketName == "next goal")
					{
						int score = Utils.GetScoreNum(tip.score) + 1;
						List<Bet365Feed> list3 = list.Where((Bet365Feed f) => f.MA.ToLower().Contains("goal") && f.MA.Contains(score.ToString())).ToList();
						if (list3 == null || list3.Count == 0)
						{
							flag = false;
							break;
						}
						Bet365Feed bet365Feed = list3.FirstOrDefault((Bet365Feed f) => f.NA.ToLower() == tip.selection.ToLower());
						if (bet365Feed == null)
						{
							goto IL_032d;
						}
						result = bet365Feed;
						flag = true;
						break;
					}
					if (tip.marketName == "Both Teams to Score")
					{
						List<Bet365Feed> list4 = list.Where((Bet365Feed f) => f.MA == "Both Teams to Score" || f.MA == "Entrambe le squadre segnano").ToList();
						if (list4 == null || list4.Count == 0)
						{
							flag = false;
							break;
						}
						Bet365Feed bet365Feed2 = list4.FirstOrDefault((Bet365Feed f) => f.NA.ToLower() == tip.selection.ToLower() || f.NA == "Sì");
						if (bet365Feed2 == null)
						{
							goto IL_032d;
						}
						result = bet365Feed2;
						flag = true;
						break;
					}
					List<Bet365Feed> list5 = list.Where((Bet365Feed f) => f.MA == "Goal nell'incontro" || f.MA == "Somma goal aggiuntiva" || f.MA == "Match Goals" || f.MA == "Alternative Match Goals").ToList();
					if (list5 == null || list5.Count == 0)
					{
						flag = false;
						break;
					}
					Bet365Feed bet365Feed3 = list5.FirstOrDefault((Bet365Feed f) => Utils.ParseToDouble(f.HA) == tip.handicap && (((f.NA == "Meno di" || f.NA == "Under") && tip.selection == "UNDER") || ((f.NA == "Più di" || f.NA == "Over") && tip.selection == "OVER")));
					if (bet365Feed3 == null)
					{
						goto IL_032d;
					}
					result = bet365Feed3;
					flag = true;
					break;
				}
				if (!(tip.period == "HT"))
				{
					goto IL_032d;
				}
				List<Bet365Feed> list6 = list.Where((Bet365Feed f) => f.MA == "Goal nel 1° tempo" || f.MA == "First Half Goals").ToList();
				if (list6 == null || list6.Count == 0)
				{
					flag = false;
					break;
				}
				Bet365Feed bet365Feed4 = list6.FirstOrDefault((Bet365Feed f) => Utils.ParseToDouble(f.HA) == tip.handicap && (((f.NA == "Meno di" || f.NA == "Under") && tip.selection == "UNDER") || ((f.NA == "Più di" || f.NA == "Over") && tip.selection == "OVER")));
				if (bet365Feed4 == null)
				{
					goto IL_032d;
				}
				result = bet365Feed4;
				flag = true;
				goto end_IL_0057;
				IL_032d:
				if (flag)
				{
					break;
				}
				continue;
				end_IL_0057:;
			}
			catch (Exception)
			{
				continue;
			}
			break;
		}
		return result;
	}

	public string DoAddBetScript(string FI, string PI, string odds, ref int betStatus)
	{
		RespBody = string.Empty;
		WaitingForAPI = true;
		try
		{
			string text = "pt=N#o=" + odds + "#f=" + FI + "#fp=" + PI + "#so=#c=1#mt=2#id=" + FI + "-" + PI + "Y#|TP=BS" + FI + "-" + PI + "#";
			_ = string.Empty;
			string text2 = Guard.Algorithms.DecryptData(Global.AddbetScript1);
			text2 = text2.Replace("[bs]", "'" + text + "'");
			text2 = text2.Replace("[FI]", "'" + FI + "'");
			text2 = text2.Replace("[odds]", "'" + odds + "'");
			text2 = text2.Replace("[PI]", "'" + PI + "'");
			text2 = text2.Replace("[uid]", "'" + FI + "-" + PI + "'");
			ExecuteScript(text2);
			Thread.Sleep(new Random().Next(200, 500));
			RespBody = string.Empty;
			int num = 0;
			while (WaitingForAPI)
			{
				num++;
				Thread.Sleep(50);
				if (num >= 150)
				{
					break;
				}
			}
			dynamic val = JsonConvert.DeserializeObject<object>(RespBody);
			m_handlerWriteStatus(val.ToString());
		}
		catch (Exception)
		{
		}
		if (string.IsNullOrEmpty(RespBody))
		{
			betStatus = 0;
		}
		else
		{
			betStatus = 1;
		}
		return RespBody;
	}

	public string DoAddBetUI(string runnerId, ref int betStatus)
	{
		RespBody = string.Empty;
		WaitingForAPI = true;
		try
		{
			string text = Guard.Algorithms.DecryptData(Global.AddbetScript);
			text = text.Replace("[FI]", runnerId);
			string empty = string.Empty;
			decimal num = default(decimal);
			decimal num2 = default(decimal);
			empty = ExecuteScript(text, requiredResult: true);
			m_handlerWriteStatus("scrollBetIntoView('" + runnerId + "') => " + empty);
			if (empty.ToLower() == "0")
			{
				betStatus = 0;
				m_handlerWriteStatus("Bet is not found!");
				string jsCode = Guard.Algorithms.DecryptData(Global.ExanpGroupScript);
				ExecuteScript(jsCode);
				Thread.Sleep(new Random().Next(1500, 3000));
				empty = ExecuteScript(text, requiredResult: true);
				if (empty.ToLower() == "0")
				{
					ExecuteScript("BetSlipLocator.betSlipManager.betslip.loadSlip(1, false , _activeElement.scope.getBetItem())");
				}
			}
			else
			{
				if (empty.ToLower() == "2")
				{
					betStatus = 2;
					m_handlerWriteStatus("Bet is suspended!");
					return RespBody;
				}
				if (empty.ToLower() == "3")
				{
					m_handlerWriteStatus("Suspended");
					RespBody = "3";
					return RespBody;
				}
			}
			Thread.Sleep(new Random().Next(1000, 1500));
			empty = ExecuteScript("JSON.stringify(_activeElement.scope._active_element.getBoundingClientRect())", requiredResult: true);
			Thread.Sleep(500);
			JObject obj = JsonConvert.DeserializeObject<JObject>(empty);
			num = decimal.Parse(((object)((JToken)obj).SelectToken("x")).ToString());
			num2 = decimal.Parse(((object)((JToken)obj).SelectToken("y")).ToString());
			if (num == 0m && num2 == 0m)
			{
				m_handlerWriteStatus($"Odds Pos : X : {num} , Y: {num2}");
				ExecuteScript("BetSlipLocator.betSlipManager.betslip.loadSlip(1, false , _activeElement.scope.getBetItem())");
			}
			else
			{
				m_handlerWriteStatus($"Odds Pos : X : {num} , Y: {num2}");
				ClickOnPoint(empty);
			}
			betStatus = 1;
			RespBody = string.Empty;
			int num3 = 0;
			while (WaitingForAPI)
			{
				num3++;
				Thread.Sleep(100);
				if (num3 >= 100)
				{
					break;
				}
			}
			dynamic val = JsonConvert.DeserializeObject<object>(RespBody);
			m_handlerWriteStatus(val.ToString());
		}
		catch (Exception)
		{
		}
		return RespBody;
	}

	private string DoPlacebetUI(double stake, double oldOdds, double handicap, string marketName)
	{
		//IL_0117: Unknown result type (might be due to invalid IL or missing references)
		//IL_011d: Expected O, but got Unknown
		m_handlerWriteStatus("DoPlacebetUI");
		RespBody = string.Empty;
		WaitingForAPI = true;
		int num = 0;
		try
		{
			if (string.IsNullOrEmpty(stake_pos))
			{
				int num2 = 3;
				while (num2-- > 0)
				{
					stake_pos = ExecuteScript("BetSlipLocator.betSlipManager.betslip.activeModule.slip.footer.stakeBox.stakeValueInputElement.getBoundingClientRect()", requiredResult: true);
					if (!string.IsNullOrEmpty(stake_pos))
					{
						break;
					}
					Thread.Sleep(1000);
				}
			}
			m_handlerWriteStatus("betslip pos => " + stake_pos);
			_ = string.Empty;
			if (!string.IsNullOrEmpty(stake_pos))
			{
				JsonConvert.DeserializeObject<JObject>(stake_pos);
			}
			decimal num3 = default(decimal);
			decimal num4 = default(decimal);
			if (!string.IsNullOrEmpty(stake_pos))
			{
				JObject obj = JsonConvert.DeserializeObject<JObject>(stake_pos);
				num3 = decimal.Parse(((object)((JToken)obj).SelectToken("x")).ToString());
				num4 = decimal.Parse(((object)((JToken)obj).SelectToken("y")).ToString());
			}
			ClickOnPoint(stake_pos, ClickType.TripleClick);
			Thread.Sleep(Utils.GetRandValue(10, 500));
			InputSimulator val = new InputSimulator();
			char[] array = stake.ToString().ToCharArray();
			foreach (char c in array)
			{
				val.Keyboard.KeyPress((VirtualKeyCode)c);
				Thread.Sleep(Utils.GetRandValue(10, 100));
			}
			string jsCode = Guard.Algorithms.DecryptData(Global.PlacebetScript);
			while (num < 4)
			{
				if (!Setting.instance.AcceptChangeOdds)
				{
					double betslipOdds = GetBetslipOdds();
					if (betslipOdds != 0.0 && !checkOdds(oldOdds, betslipOdds))
					{
						RespBody = "Odds is changed while place bet!";
						return RespBody;
					}
				}
				if (marketName == "Asian Handicap")
				{
					double handicap2 = GetHandicap();
					if (handicap2 != handicap)
					{
						m_handlerWriteStatus($"Asian Handicap Line is changed from {handicap} to {handicap2}");
						RespBody = $"Asian Handicap Line is changed from {handicap} to {handicap2}";
						return RespBody;
					}
				}
				decimal num5 = default(decimal);
				decimal num6 = default(decimal);
				WaitingForAPI = true;
				int num7 = 3;
				if (string.IsNullOrEmpty(placebetBtn_pos))
				{
					while (num7-- > 0)
					{
						placebetBtn_pos = ExecuteScript(jsCode, requiredResult: true);
						if (!string.IsNullOrEmpty(placebetBtn_pos))
						{
							break;
						}
						Thread.Sleep(1000);
					}
				}
				m_handlerWriteStatus("Placebet Button pos => " + placebetBtn_pos);
				if (!string.IsNullOrEmpty(placebetBtn_pos) && !placebetBtn_pos.Contains("Placebet btn is disable now"))
				{
					ClickOnPoint(placebetBtn_pos);
				}
				else
				{
					num5 = num3 + 250m;
					num6 = num4;
					CLickOnPoint((int)num5, (int)num6);
				}
				_lastCallPlaceBet = DateTime.Now;
				int num8 = 0;
				while (WaitingForAPI)
				{
					num8++;
					Thread.Sleep(100);
					if (num8 >= 150)
					{
						break;
					}
				}
				dynamic val2 = JsonConvert.DeserializeObject<object>(RespBody);
				switch ((string)val2.sr.ToString())
				{
				case "11":
					if (!string.IsNullOrEmpty(placebetBtn_pos) && !placebetBtn_pos.Contains("Placebet btn is disable now"))
					{
						ClickOnPoint(placebetBtn_pos);
					}
					else
					{
						num5 = num3 + 250m;
						num6 = num4;
						CLickOnPoint((int)num5, (int)num6);
					}
					num++;
					Thread.Sleep(3500);
					continue;
				case "0":
					Thread.Sleep(2000);
					ExecuteScript("BetSlipLocator.betSlipManager.betslip.activeModule.slip.receiptContent.receiptContentDoneButtonClicked();");
					break;
				case "14":
					if (!string.IsNullOrEmpty(placebetBtn_pos) && !placebetBtn_pos.Contains("Placebet btn is disable now"))
					{
						ClickOnPoint(placebetBtn_pos);
					}
					else
					{
						num5 = num3 + 250m;
						num6 = num4;
						CLickOnPoint((int)num5, (int)num6);
					}
					Thread.Sleep(4000);
					num++;
					continue;
				case "24":
					if (!string.IsNullOrEmpty(placebetBtn_pos) && !placebetBtn_pos.Contains("Placebet btn is disable now"))
					{
						ClickOnPoint(placebetBtn_pos);
					}
					else
					{
						num5 = num3 + 250m;
						num6 = num4;
						CLickOnPoint((int)num5, (int)num6);
					}
					num++;
					Thread.Sleep(2000);
					continue;
				}
				break;
			}
		}
		catch (Exception)
		{
		}
		return RespBody;
	}

	private double GetBetslipOdds()
	{
		double result = 0.0;
		int num = 0;
		while (num < 4)
		{
			try
			{
				string text = ExecuteScript("BetSlipLocator.betSlipManager.betslip.activeModule.slip.header.standardContent.oddsValue._text", requiredResult: true);
				if (string.IsNullOrEmpty(text))
				{
					num++;
					Thread.Sleep(500);
					continue;
				}
				result = Utils.ParseToDouble(text);
			}
			catch
			{
				continue;
			}
			break;
		}
		return result;
	}

	private bool checkSuspended()
	{
		bool result = false;
		try
		{
			string jsCode = Guard.Algorithms.DecryptData(Global.suspendedScript);
			if (ExecuteScript(jsCode, requiredResult: true) == "true")
			{
				result = true;
			}
		}
		catch
		{
		}
		return result;
	}

	private bool checkOdds(double oldOdds, double newOdds)
	{
		m_handlerWriteStatus($"Trademate Odds : {oldOdds} , Bet365 Odds : {newOdds}");
		if (newOdds < oldOdds && Math.Abs(oldOdds - newOdds) > 0.02)
		{
			m_handlerWriteStatus($"The Odd is change from {oldOdds} to {newOdds}");
			return false;
		}
		return true;
	}

	public void MakeBet(TelegramTip betitem, ref bool isSucccssed)
	{
		//IL_004a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0050: Expected O, but got Unknown
		//IL_021d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0224: Expected O, but got Unknown
		m_handlerWriteStatus(" *** MakeBet *** ");
		m_handlerWriteStatus(JsonConvert.SerializeObject((object)betitem));
		Win32.SetForegroundWindow(Global.windowHandle);
		PlacingBet = true;
		new BetSlipJson();
		betitem.fract_odds = Utils.decimalToFraction(betitem.odds);
		dynamic val = (dynamic)new JObject();
		val.username = Setting.instance.betUsername;
		val.tipster = betitem.tipster;
		val.message = "***EMPTY***";
		double balance = GetBalance();
		if (balance > 0.0)
		{
			_balance = balance;
		}
		m_handlerWriteStatus("Current Balance : " + balance);
		betitem.fract_odds = Utils.decimalToFraction(betitem.odds);
		double odds = betitem.odds;
		m_handlerWriteStatus("CheckIfLoggedIn");
		if (!CheckIfLogged())
		{
			DoLogin("https://" + Setting.instance.bet365Domain + "/#/HO/");
			Thread.Sleep(500);
		}
		else
		{
			m_handlerWriteStatus("Logged In Already!");
		}
		try
		{
			DoClickDlgBox();
			_ = _lastBetGuid;
			string text = string.Empty;
			dynamic val2 = (dynamic)new JObject();
			int num = 0;
			bool flag = false;
			string link = betitem.link;
			m_handlerWriteStatus(link);
			if (link.Contains("EV"))
			{
				NavigateInvoke(link);
				flag = true;
			}
			else if (Setting.instance.RunMode == RUNMODE.UI)
			{
				for (int i = 0; i < 3; i++)
				{
					flag = SearchMatchWithName(betitem.match);
					if (flag)
					{
						break;
					}
				}
			}
			if (!flag)
			{
				m_handlerWriteStatus("Not Found Event on Bet365...");
				return;
			}
			if (checkSuspended())
			{
				m_handlerWriteStatus("Sorry, this page is no longer avaliable. Betting has closed or has been suspended.");
				Setting.instance.failedTips.Add(betitem);
				return;
			}
			if (Setting.instance.bet365Domain.Contains("bet365.it"))
			{
				DoClickBetslipAttempt();
			}
			if (string.IsNullOrEmpty(betitem.selectionId))
			{
				Bet365Feed bet365Feed = FindOdds(betitem);
				if (bet365Feed == null || string.IsNullOrEmpty(bet365Feed.ID))
				{
					m_handlerWriteStatus("Not Found Odds on Bet365..");
					return;
				}
				betitem.selectionId = bet365Feed.ID;
				betitem.matchId = bet365Feed.FI;
				betitem.fract_odds = bet365Feed.OD;
			}
			double num2 = Utils.FractionToDouble(betitem.fract_odds);
			m_handlerWriteStatus($"Registering new Odds on Bigstake . New Odds Value is {num2}");
			double stake = Utils.GetStake(_balance, betitem, num2, ref odds);
			m_handlerWriteStatus("New Stake : " + stake);
			if (balance > 0.0 && balance < stake)
			{
				m_handlerWriteStatus("Balance is Low now! Skip bets now!");
				return;
			}
			val.stake = stake;
			Removebet();
			int num3 = 0;
			int betStatus = 0;
			while (num3 < 2)
			{
				m_handlerWriteStatus("Running AddbetScript...");
				if (Setting.instance.RunMode == RUNMODE.SCRIPT)
				{
					text = DoAddBetScript(betitem.matchId, betitem.selectionId, betitem.fract_odds, ref betStatus);
					if (Utils.parseToInt(ExecuteScript("BetSlipLocator.betSlipManager.betslip.activeModule.slip.bets.length", requiredResult: true)) != 0 || !string.IsNullOrEmpty(text))
					{
						break;
					}
					num3++;
				}
				else if (Setting.instance.RunMode == RUNMODE.UI)
				{
					text = DoAddBetUI(betitem.selectionId, ref betStatus);
					if (Utils.parseToInt(ExecuteScript("BetSlipLocator.betSlipManager.betslip.activeModule.slip.bets.length", requiredResult: true)) != 0 || !string.IsNullOrEmpty(text))
					{
						break;
					}
					num3++;
				}
			}
			if (betStatus == 0 || betStatus == 2)
			{
				if (CheckPageSuspended())
				{
					m_handlerWriteStatus("Sorry, this page is no longer available. Betting has closed or has been suspended!");
					Setting.instance.failedTips.Add(betitem);
				}
				return;
			}
			if (Setting.instance.bet365Domain.Contains("bet365.it"))
			{
				int num4 = 3;
				while (--num4 > 0 && !DoClickBetslipAttempt())
				{
					Thread.Sleep(1000);
				}
			}
			if (text == "{}")
			{
				Removebet();
				m_handlerWriteStatus("Logout From bet365... Bot will try again!");
				return;
			}
			if (text == "3")
			{
				m_handlerWriteStatus("Sorry, this page is no longer available. Betting has closed or has been suspended.");
				Setting.instance.failedTips.Add(betitem);
				return;
			}
			if (string.IsNullOrEmpty(text))
			{
				try
				{
					if (Utils.parseToInt(ExecuteScript("BetSlipLocator.betSlipManager.betslip.activeModule.slip.bets.length", requiredResult: true)) == 0)
					{
						m_handlerWriteStatus("Unkonown Failed!");
						Removebet();
						return;
					}
				}
				catch
				{
				}
			}
			if (betitem.marketName == "Asian Handicap")
			{
				double handicap = GetHandicap();
				if (handicap != betitem.minHandicap)
				{
					m_handlerWriteStatus($"Asian Handicap Line is changed from {betitem.minHandicap} to {handicap}");
					Setting.instance.failedTips.Add(betitem);
					return;
				}
			}
			string empty = string.Empty;
			if (!string.IsNullOrEmpty(text))
			{
				val2 = JsonConvert.DeserializeObject<object>(text);
				try
				{
					if (((string)val2.bt[0].su.ToString()).ToLower() == "true")
					{
						PlacingBet = false;
						return;
					}
					if (((string)val2.bt[0].pt[0].md.ToString()).ToLower() == "")
					{
						PlacingBet = false;
						return;
					}
				}
				catch
				{
				}
				try
				{
					string text2 = val2.bt[0].od.ToString();
					m_handlerWriteStatus("Fractional Odds : " + text2);
					num2 = (betitem.odds = Utils.FractionToDouble(text2));
					if (!Setting.instance.AcceptChangeOdds && !checkOdds(odds, num2))
					{
						Setting.instance.failedTips.Add(betitem);
						return;
					}
				}
				catch
				{
				}
				empty = val2.sr.ToString();
				if (empty == "-1" || empty == "15")
				{
					Removebet();
					m_handlerWriteStatus($"[{DateTime.Now}] Reason: addbet response code => {empty}");
					return;
				}
				foreach (BetSlipItem item in JsonConvert.DeserializeObject<BetSlipJson>(text).bt)
				{
					if (item.pt[0].pi == betitem.selectionId)
					{
						if (item.su)
						{
							m_handlerWriteStatus($"The line is not existed {betitem.match} {betitem.marketName}");
							return;
						}
						num++;
					}
				}
			}
			else
			{
				num2 = GetBetslipOdds();
				if (!Setting.instance.AcceptChangeOdds)
				{
					if (num2 == 0.0)
					{
						return;
					}
					betitem.odds = num2;
					if (!checkOdds(odds, num2))
					{
						Setting.instance.failedTips.Add(betitem);
						return;
					}
				}
			}
			if (betitem.EW == "1")
			{
				ExecuteScript("BetSlipLocator.betSlipManager.betslip.activeModule.slip.bets[0].eachWayCheckbox.setChecked()");
				Thread.Sleep(500);
				ExecuteScript("BetSlipLocator.betSlipManager.betslip.activeModule.slip.bets[0].eachwayCheckboxChecked()");
				ExecuteScript("BetSlipLocator.betSlipManager.betslip.activeModule.slip.bets[0].ewexCheckbox.setChecked()");
				Thread.Sleep(500);
				ExecuteScript("BetSlipLocator.betSlipManager.betslip.activeModule.slip.bets[0].ewexCheckboxChecked()");
			}
			dynamic empty2 = string.Empty;
			_ = string.Empty;
			_ = string.Empty;
			string betUsername = Setting.instance.betUsername;
			string betPassword = Setting.instance.betPassword;
			BETRESP_CODE bETRESP_CODE = BETRESP_CODE.UNKNOWN;
			int num6 = 3;
			while (--num6 > 0)
			{
				m_handlerWriteStatus("Trying to place bet!");
				string text3 = DoPlacebetUI(stake, odds, betitem.minHandicap, betitem.marketName);
				if (string.IsNullOrEmpty(text3))
				{
					m_handlerWriteStatus("BetResponse is Null!");
					val.message = $"[{betUsername}:{betPassword}] BetResponse is Null!!";
					break;
				}
				if (text3.Contains("Asian Handicap Line is changed"))
				{
					val.message = $"[{betUsername}:{betPassword}] Asian Handicap Line is changed!!";
					break;
				}
				if (text3.Contains("Stake Limited..."))
				{
					m_handlerWriteStatus("Stake Limited...!");
					val.message = $"[{betUsername}:{betPassword}] Stake Limited...";
					break;
				}
				if (text3.Contains("Odds is changed while place bet!"))
				{
					m_handlerWriteStatus("Odds is changed while place bet!");
					val.message = $"[{betUsername}:{betPassword}] Odds is changed while place bet!";
					break;
				}
				empty2 = JsonConvert.DeserializeObject<object>(text3);
				empty = empty2.sr.ToString();
				try
				{
					if (empty2["bt"][0]["rs"] != null)
					{
						double num7 = Utils.ParseToDouble(empty2["bt"][0]["rs"].ToString());
						if (num7 > 0.0)
						{
							_lastMaxStake = Math.Floor(num7);
						}
					}
					if (empty2["bt"][0]["ms"] != null)
					{
						double num8 = Utils.ParseToDouble(empty2["bt"][0]["ms"].ToString());
						if (num8 > 0.0)
						{
							_lastMaxStake = Math.Floor(num8);
						}
					}
				}
				catch
				{
				}
				double balance2 = GetBalance();
				if (empty == "0" || balance2 < _balance)
				{
					double num9 = Utils.ParseToDouble(empty2.ts.ToString());
					double num10 = Utils.ParseToDouble(empty2.re.ToString());
					double odds2 = Math.Floor(100.0 * num10 / stake) / 100.0;
					betitem.odds = odds2;
					double num11 = num10 / num9;
					if (empty2.mo != null)
					{
						string text4 = empty2.mo[0].od.ToString();
						num11 = ((!text4.Contains("/")) ? Utils.ParseToDouble(text4) : (Utils.ParseToDouble(text4.Split(new char[1] { '/' })[0]) / Utils.ParseToDouble(text4.Split(new char[1] { '/' })[1]) + 1.0));
					}
					val.tipSource = betitem.tipSource.ToString();
					val.stake = num9;
					val.odds = num11;
					val.tournament = betitem.league;
					val.eventName = betitem.match;
					val.probability = betitem.selection;
					val.market = betitem.marketName;
					val.placedAt = DateTime.Now.ToString();
					val.selection = betitem.selection;
					val.handicap = betitem.handicap;
					string pattern = "\"tr\":\\d{18}";
					RegexOptions options = RegexOptions.Multiline;
					foreach (Match item2 in Regex.Matches(text3, pattern, options))
					{
						val.betId = item2.Value.Replace("\"", "").Replace(":", "").Replace("tr", "")
							.Trim();
					}
					val.message = $"[{betUsername}:{betPassword}] SUCCESS. Stake:{num9} Odds:{num11}";
					totalBetCnt++;
					((List<object>)placebetResults).Add(val);
					m_resultEvent(placebetResults);
					Setting.instance.totalTennisTips.Add(betitem);
					Setting.instance.successInfos.Add(betitem);
					if (Setting.instance.stakeMethod == StakeMethod.Masaniello || Setting.instance.stakeMethod == StakeMethod.Roserpina)
					{
						pendingTip = betitem;
						pendingTip.bFinished = false;
					}
					bETRESP_CODE = BETRESP_CODE.SUCCESS;
					isSucccssed = true;
					_balance -= stake;
					int myBetsCount = GetMyBetsCount();
					m_updateStatus(_balance, myBetsCount, placebetResults.Count);
					DoLoad365Page("https://" + Setting.instance.bet365Domain + "/#/MB/");
					Thread.Sleep(3000);
					break;
				}
				dynamic val3 = empty2.ToString().Contains("Session Locked");
				if (!(val3 ? true : false) && !((val3 | (empty == "-2")) ? true : false))
				{
					switch (empty)
					{
					case "9":
						num6--;
						continue;
					case "19":
						Thread.Sleep(1000);
						continue;
					case "8":
						Thread.Sleep(2500);
						num6--;
						continue;
					case "10":
						val.message = $"[{betUsername}:{betPassword}] Balance is small ";
						Removebet();
						break;
					case "11":
					{
						string text5 = empty2["bt"][0]["rs"].ToString();
						if (string.IsNullOrEmpty(text5))
						{
							val.message = string.Format("Stake is wrong: {0}", empty2.ToString());
							Thread.Sleep(3000);
							continue;
						}
						double num12 = Utils.ParseToDouble(text5);
						if (num12 == 0.0)
						{
							val.message = "Market suspended: max stake is 0.";
							Thread.Sleep(3000);
							num6--;
						}
						_lastMaxStake = num12;
						m_handlerWriteStatus($"Max stake: {num12}");
						val.message = $"Max stake: {text5}";
						num6--;
						Thread.Sleep(3000);
						continue;
					}
					case "14":
						Thread.Sleep(1500);
						num6--;
						continue;
					case "15":
						m_handlerWriteStatus($"[{DateTime.Now}] Reason: placebet response code => {empty}");
						break;
					case "41":
						val.message = "Allow login others";
						num6--;
						break;
					case "24":
						try
						{
							if (num6 == 1)
							{
								Setting.instance.failedTips.Add(betitem);
								break;
							}
						}
						catch
						{
						}
						Thread.Sleep(2300);
						num6--;
						continue;
					default:
						if (num6 == 1)
						{
							Setting.instance.failedTips.Add(betitem);
							break;
						}
						m_handlerWriteStatus("Place bet failed .." + empty2.ToString());
						val.message = string.Format("[{0}:{1}] Place bet failed {2} ", betUsername, betPassword, empty2.ToString());
						break;
					}
					break;
				}
				val.message = $"[{betUsername}:{betPassword}] Session Locked!! ";
				Thread.Sleep(5000);
				return;
			}
			m_handlerWriteStatus(val.message.ToString());
			val.balance = _balance;
			val.success = bETRESP_CODE;
			val.bookie = 2;
			val.dbId = betitem.dbId;
			m_handlerWriteStatus(val.ToString());
			if (bETRESP_CODE == BETRESP_CODE.SUCCESS)
			{
				Setting.instance.totalTennisTips.Add(betitem);
			}
			else
			{
				Setting.instance.failedTips.Add(betitem);
			}
			Removebet();
		}
		catch (Exception ex)
		{
			m_handlerWriteStatus("Exception in MakeBet: " + ex.ToString());
			Removebet();
		}
		Thread.Sleep(8000);
		PlacingBet = false;
	}

	public bool DoClickBetslipAttempt()
	{
		bool result = false;
		try
		{
			string jsCode = Guard.Algorithms.DecryptData(Global.BetslipAttemptScript);
			string text = ExecuteScript(jsCode, requiredResult: true);
			if (!string.IsNullOrEmpty(text) && !text.Contains("nodialog") && !text.Contains("exception"))
			{
				m_handlerWriteStatus("BetslipAttemptPage :" + text);
				ClickOnPoint(text);
				result = true;
				Thread.Sleep(900);
			}
			else
			{
				result = false;
			}
		}
		catch
		{
		}
		return result;
	}

	public bool CheckPageSuspended()
	{
		bool result = false;
		try
		{
			string jsCode = Guard.Algorithms.DecryptData(Global.suspendedScript);
			string text = ExecuteScript(jsCode, requiredResult: true);
			m_handlerWriteStatus("PageSuspended :" + text);
			result = text.ToLower() == "true";
		}
		catch
		{
		}
		return result;
	}

	public double GetBalance()
	{
		double num = -1.0;
		int num2 = 10;
		while (num2-- > 0)
		{
			try
			{
				string text = ExecuteScript("Locator.user._balance.totalBalance", requiredResult: true);
				m_handlerWriteStatus(text);
				if (string.IsNullOrEmpty(text) || text == "null" || text == "undefined")
				{
					return -1.0;
				}
				text = text.Replace("\"", "").Replace("'", "");
				text = text.Substring(0, text.Length - 1);
				num = Utils.ParseToDouble(text.Replace(",", "").Replace(",", "."));
				m_handlerWriteStatus($"Current balance : {num}");
				if (num > -1.0)
				{
					break;
				}
				Thread.Sleep(500);
				continue;
			}
			catch
			{
				continue;
			}
		}
		return num;
	}

	public bool Removebet()
	{
		string jsCode = Guard.Algorithms.DecryptData(Global.RemoveScript);
		ExecuteScript(jsCode);
		return true;
	}

	public bool CheckIfLogged()
	{
		try
		{
			string text = ExecuteScript("flashvars.USER_NAME", requiredResult: true);
			if (string.IsNullOrEmpty(text))
			{
				return false;
			}
			if (text.ToLower().Contains(Setting.instance.betUsername.ToLower()))
			{
				return true;
			}
		}
		catch (Exception)
		{
		}
		return false;
	}

	public void DoLogin(string visitUrl = "")
	{
		try
		{
			m_handlerWriteStatus("DoLogin");
			DoLoad365Page(visitUrl);
			if (CheckIfLogged())
			{
				return;
			}
			string text = Guard.Algorithms.DecryptData(Global.LoginScript);
			text = text.Replace("[username]", "'" + Setting.instance.betUsername + "'");
			text = text.Replace("[password]", "'" + Setting.instance.betPassword + "'");
			text = text.Replace("[domain]", "'" + Setting.instance.bet365Domain + "'");
			LOGGED = false;
			int num = 3;
			while (--num > 0)
			{
				WaitingForLogin = true;
				ExecuteScript(text);
				m_handlerWriteStatus("Executed login script!");
				int num2 = 0;
				while (WaitingForLogin && !CheckIfLogged())
				{
					num2++;
					Thread.Sleep(200);
					if (num2 >= 100)
					{
						break;
					}
				}
				if (WaitingForLogin)
				{
					DoLoad365Page(visitUrl);
				}
				Thread.Sleep(3000);
				if (CheckIfLogged())
				{
					break;
				}
			}
			m_handlerWriteStatus("Login Success!");
			Thread.Sleep(3000);
			DoClickDlgBox();
		}
		catch
		{
		}
		WaitingForLogin = false;
	}

	public void DoLoad365Page(string visitUrl = "")
	{
		try
		{
			m_handlerWriteStatus("DoLoad365Page");
			_isPageLoaded = false;
			LOGGED = false;
			_isInjected = false;
			bool flag = false;
			if (string.IsNullOrEmpty(visitUrl))
			{
				flag = true;
				visitUrl = Setting.instance.bet365Domain;
			}
			int num = 4;
			while (--num > 0)
			{
				try
				{
					NavigateInvoke(visitUrl);
					if (flag)
					{
						Thread.Sleep(4000);
					}
					int num2 = 0;
					while (!_isPageLoaded && !CheckIfJSLibLoaded())
					{
						Thread.Sleep(100);
						num2++;
						if (num2 >= 200)
						{
							break;
						}
					}
					m_handlerWriteStatus("365 page is loaded!");
					string jsCode = File.ReadAllText("inject.txt");
					ExecuteScript(jsCode);
				}
				catch
				{
					continue;
				}
				break;
			}
			DoClickDlgBox();
		}
		catch (Exception ex)
		{
			m_handlerWriteStatus("Exception in DoLoad365Page: " + ex.ToString());
		}
	}

	public bool DoClickDlgBox()
	{
		string empty = string.Empty;
		try
		{
			string jsCode = Guard.Algorithms.DecryptData(Global.popupScript);
			empty = ExecuteScript(jsCode, requiredResult: true);
			if (!string.IsNullOrEmpty(empty) && !empty.Contains("nodialog") && !empty.Contains("exception"))
			{
				m_handlerWriteStatus("LastLoginModule_Button Clicked");
				ClickOnPoint(empty);
				Thread.Sleep(900);
			}
		}
		catch
		{
		}
		return true;
	}

	public bool NavigateInvoke(string visitUrl)
	{
		try
		{
			if (!visitUrl.StartsWith("https://"))
			{
				visitUrl = "https://" + visitUrl;
			}
			ExecuteScript(string.Format("location.href==='{0}'?0:location.href='{0}'", visitUrl));
		}
		catch (Exception ex)
		{
			m_handlerWriteStatus(ex.ToString());
		}
		return true;
	}

	public string ExecuteScript(string jsCode, bool requiredResult = false)
	{
		string result = string.Empty;
		try
		{
			WebsocketServer.Instance.ExecuteScript(jsCode);
			if (!requiredResult)
			{
				return result;
			}
			Task task = Task.Run(delegate
			{
				isArrivedJSResult = false;
				_jsResult = string.Empty;
				while (!isArrivedJSResult)
				{
					Thread.Sleep(10);
				}
			});
			TimeSpan timeout = TimeSpan.FromMilliseconds(5000.0);
			task.Wait(timeout);
			result = _jsResult;
		}
		catch (Exception)
		{
		}
		return result;
	}

	public List<Settledbet> GetSettledBets()
	{
		List<Settledbet> list = new List<Settledbet>();
		try
		{
			if (ExecuteScript("ns_navlib_util.WebsiteNavigationManager.CurrentPageData", requiredResult: true) != "#MB#")
			{
				NavigateInvoke("https://" + Setting.instance.bet365Domain + "/#/MB/");
			}
			Thread.Sleep(3000);
			string jsCode = Guard.Algorithms.DecryptData(Global.settledbetScript);
			list = JsonConvert.DeserializeObject<List<Settledbet>>(ExecuteScript(jsCode, requiredResult: true));
			m_handlerWriteStatus(list.Count + " Settled bets!!!");
		}
		catch
		{
		}
		return list;
	}

	private double GetHandicap()
	{
		double result = 100.0;
		int num = 0;
		while (num < 4)
		{
			try
			{
				string text = ExecuteScript("BetSlipLocator.betSlipManager.betslip.activeModule.slip.bets[0].handicapLabel._text", requiredResult: true);
				if (string.IsNullOrEmpty(text))
				{
					num++;
					Thread.Sleep(1000);
					continue;
				}
				result = ((!text.Contains(",")) ? Utils.ParseToDouble(text) : ((Utils.ParseToDouble(text.Split(new char[1] { ',' })[0].Trim()) + Utils.ParseToDouble(text.Split(new char[1] { ',' })[1].Trim())) / 2.0));
			}
			catch
			{
				continue;
			}
			break;
		}
		return result;
	}

	public bool ClickOnPoint(string scriptResult, ClickType clickType = ClickType.click, int interval = 1)
	{
		try
		{
			JObject obj = JObject.Parse(scriptResult);
			decimal num = decimal.Parse(((object)((JToken)obj).SelectToken("x")).ToString());
			decimal num2 = decimal.Parse(((object)((JToken)obj).SelectToken("y")).ToString());
			decimal num3 = Utils.ParseToDecimal(((object)((JToken)obj).SelectToken("width")).ToString());
			decimal num4 = Utils.ParseToDecimal(((object)((JToken)obj).SelectToken("height")).ToString());
			num2 += (decimal)Setting.instance.heightDiff;
			if (!(num == 0m) || !(num2 == 0m))
			{
				Random random = new Random();
				int num5 = random.Next((int)num3 / 5, (int)num3 / 2);
				int num6 = random.Next((int)num4 / 5, (int)num4 / 2);
				MouseEvent.Instance.MoveMouse((int)num + num5, (int)num2 + num6, 0, 0);
				Thread.Sleep(Utils.GetRandValue(500, 1000));
				ActionEntry action = new ActionEntry((int)num + num5, (int)num2 + num6, string.Empty, interval, clickType);
				MouseEvent.Instance.RunAction(action);
				return true;
			}
			m_handlerWriteStatus("Wrong position detected!");
		}
		catch (Exception)
		{
		}
		return false;
	}

	public bool CLickOnPoint(int x, int y, ClickType clickType = ClickType.click)
	{
		try
		{
			y += (int)Setting.instance.heightDiff;
			if (x == 0 && y == 0)
			{
				m_handlerWriteStatus("Wrong position detected!");
				return false;
			}
			int num = new Random().Next(5, 20);
			MouseEvent.Instance.MoveMouse(x + num, y, 0, 0);
			ActionEntry action = new ActionEntry(x, y, string.Empty, 1, clickType);
			MouseEvent.Instance.RunAction(action);
			return true;
		}
		catch
		{
		}
		return true;
	}
}
