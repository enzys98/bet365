using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using CEBet365Placer.Constants;
using CEBet365Placer.Controller;
using CEBet365Placer.Json;
using CEBet365Placer.Properties;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Siticone.Desktop.UI.WinForms;
using Siticone.Desktop.UI.WinForms.Enums;
using Siticone.UI.WinForms;
using Siticone.UI.WinForms.Suite;

namespace CEBet365Placer;

public class Form1 : Form
{
	public Thread m_refreshThread;

	public Thread m_telegramThread;

	public Thread m_bigStakeThread;

	private SocketConnector m_socketConnector;

	private string m_lastToken = string.Empty;

	private string m_path;

	private List<TelegramTip> _betList = new List<TelegramTip>();

	private LiveMatchScore _liveScore = new LiveMatchScore();

	private object lockObj = new object();

	public List<BetItem> failedResults = new List<BetItem>();

	private string license = string.Empty;

	private IContainer components;

	private BindingSource AccountSource;

	private BindingSource ResultSource;

	private Timer setTimer;

	private SiticonePanel DragPanel;

	private SiticoneHtmlLabel siticoneHtmlLabel12;

	private SiticoneControlBox siticoneControlBox2;

	private SiticoneControlBox siticoneControlBox1;

	private SiticoneButton btnStart;

	private SiticoneButton btnLaunch;

	private SiticonePanel siticonePanel1;

	private SiticoneHtmlLabel siticoneHtmlLabel3;

	private SiticonePanel siticonePanel2;

	private SiticonePanel siticonePanel3;

	private SiticoneHtmlLabel siticoneHtmlLabel2;

	private SiticoneHtmlLabel siticoneHtmlLabel1;

	private RichTextBox rtLog;

	private SiticoneDataGridView tbResult;

	private DataGridViewTextBoxColumn Column5;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;

	private DataGridViewTextBoxColumn selection;

	private DataGridViewTextBoxColumn Column1;

	private DataGridViewTextBoxColumn Stake;

	private DataGridViewTextBoxColumn Column4;

	private Label label11;

	private Label label3;

	private SiticoneHtmlLabel lbTotalbets;

	private SiticoneHtmlLabel siticoneHtmlLabel7;

	private SiticoneHtmlLabel lbOpendbets;

	private SiticoneHtmlLabel siticoneHtmlLabel5;

	private SiticoneHtmlLabel lbBalance;

	private SiticoneGradientPanel siticoneGradientPanel1;

	private SiticoneTextBox txtPassBet365;

	private SiticoneTextBox txtUserBet365;

	private SiticoneSeparator siticoneSeparator1;

	private SiticoneHtmlLabel siticoneHtmlLabel9;

	private SiticoneComboBox comboBrowser;

	private SiticoneSeparator siticoneSeparator2;

	private SiticoneHtmlLabel siticoneHtmlLabel11;

	private SiticoneHtmlLabel siticoneHtmlLabel13;

	private SiticoneComboBox chkDomain;

	private SiticoneGradientPanel siticoneGradientPanel2;

	private SiticoneButton btnSet;

	private SiticoneButton btnBigStake;

	private SiticoneRadioButton rdFixed;

	private SiticoneRadioButton rdFollow;

	private SiticoneTextBox txtServerUrl;

	private SiticoneTextBox txtChannel;

	private SiticoneRadioButton rdRos;

	private SiticoneButton siticoneButton1;

	public event onProcUpdateNetworkStatusEvent onProcUpdateNetworkStatusEvent;

	public event onWriteLogEvent onWriteLog;

	public event onWriteStatusEvent onWriteStatus;

	public event onProcNewTipEvent onProcNewTipEvent;

	public event onWriteResultEvent onWriteResult;

	public event onUpdateStatusEvent onUpdateStatus;

	public event onProcNewScoreEvent onProcNewScoreEvent;

	public Form1(string _license)
	{
		//IL_0125: Unknown result type (might be due to invalid IL or missing references)
		//IL_004f: Unknown result type (might be due to invalid IL or missing references)
		//IL_005b: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			InitializeComponent();
			new SiticoneShadowForm((Form)(object)this);
			new SiticoneDragControl((Control)(object)DragPanel);
			license = _license;
			Setting.instance.loadSettingInfo();
			onProcNewTipEvent += procNewTip;
			onWriteStatus += writeStatus;
			onWriteLog += LogToFile;
			onWriteResult += refreshResultInfo;
			onUpdateStatus += updateStatus;
			onProcNewScoreEvent += procNewScore;
			createLogFolders();
			loadSettingInfo();
			m_socketConnector = new SocketConnector(this.onWriteLog, this.onWriteStatus, this.onProcNewTipEvent, this.onProcNewScoreEvent);
			m_socketConnector.m_handlerProcUpdateNetworkStatus = this.onProcUpdateNetworkStatusEvent;
		}
		catch (Exception ex)
		{
			MessageBox.Show(ex.ToString());
		}
	}

	private void loadSettingInfo()
	{
		txtUserBet365.Text = Setting.instance.betUsername;
		txtPassBet365.Text = Setting.instance.betPassword;
		txtServerUrl.Text = Setting.instance.serverAddr;
		txtChannel.Text = Setting.instance.channel;
		if (Setting.instance.stakeMethod == StakeMethod.Fixed)
		{
			((RadioButton)rdFixed).Checked = true;
		}
		else if (Setting.instance.stakeMethod == StakeMethod.Masaniello)
		{
			((RadioButton)rdFollow).Checked = true;
		}
		else if (Setting.instance.stakeMethod == StakeMethod.Roserpina)
		{
			((RadioButton)rdRos).Checked = true;
		}
	}

	private void SelectMethod()
	{
		string[] array = File.ReadAllText("app.txt").Split(new char[1] { '\n' });
		for (int i = 0; i < array.Length; i++)
		{
			string[] array2 = array[i].Split(new char[1] { '=' });
			string text = array2[1].Trim();
			switch (array2[0].Trim())
			{
			case "DOMBETTING":
				Setting.instance.UseDombetting = text == "true";
				break;
			case "TELEGRAM":
				Setting.instance.UseTelegram = text == "true";
				break;
			case "WODDS":
				Setting.instance.UseWOdds = text == "true";
				break;
			case "HANDBALL":
				Setting.instance.UseHandball = text == "true";
				break;
			case "HORSERACING":
				Setting.instance.UseHorseRacing = text == "true";
				break;
			case "LIVEBET":
				Setting.instance.UseLivebet = text == "true";
				break;
			case "COPYBETTING":
				Setting.instance.UseCopybetting = text == "true";
				break;
			}
		}
	}

	private void createLogFolders()
	{
		m_path = Directory.GetCurrentDirectory();
		if (!Directory.Exists(m_path + "\\Log\\"))
		{
			Directory.CreateDirectory(m_path + "\\Log\\");
		}
		if (!Directory.Exists(m_path + "\\Bet\\"))
		{
			Directory.CreateDirectory(m_path + "\\Bet\\");
		}
	}

	private bool CheckIfWorkingFrame()
	{
		double num = DateTime.Now.Hour + 1;
		if (8.0 <= num && num <= 23.0)
		{
			return true;
		}
		return false;
	}

	private void TelegramThreadFunc()
	{
		new TelegramCtrl(this.onProcNewTipEvent).StartRecieve();
	}

	public void refreshThreadFunc()
	{
		try
		{
			if (!BetController.Intance.LOGGED)
			{
				BetController.Intance.DoLogin("https://" + Setting.instance.bet365Domain + "/#/HO/");
			}
		}
		catch (Exception ex)
		{
			this.onWriteStatus("refreshThreadFunc :" + ex.ToString());
		}
		Thread.Sleep(3000);
		BigStakeCtrl.Intance.DoLogin();
		double balance = BetController.Intance.GetBalance();
		int myBetsCount = BetController.Intance.GetMyBetsCount();
		if (BetController.Intance.settledbets == null || BetController.Intance.settledbets.Count == 0)
		{
			BetController.Intance.settledbets = BetController.Intance.GetSettledBets();
		}
		updateStatus(balance, myBetsCount, BetController.Intance.totalBetCnt);
		writeStatus($"Current Balance: {balance}");
		writeStatus("Page is initialized!");
		while (GlobalConstants.state == State.Running)
		{
			try
			{
				Thread.Sleep(100);
				lock (_betList)
				{
					if (_betList == null || _betList.Count == 0 || BetController.Intance.PlacingBet)
					{
						continue;
					}
					foreach (TelegramTip bet in _betList)
					{
						int num = 0;
						while (num < 2)
						{
							try
							{
								if (string.IsNullOrEmpty(bet.match))
								{
									continue;
								}
								if (checkFailedLine(bet))
								{
									writeStatus("This Line '" + bet.match + "' - '" + bet.selection + "' is already existed on Failed bets!");
									num++;
									continue;
								}
								if (checkWrongLine(bet))
								{
									writeStatus("Skip this line because it is wrong!");
									num++;
									continue;
								}
								if (checkSameLine(bet))
								{
									writeStatus("This Line is already existed on Settled bets!");
									num++;
									continue;
								}
								if (Setting.instance.bet365Domain.Contains("bet365.es") && bet.match.Contains("U19"))
								{
									writeStatus("This Match is not existed on Page...");
									num++;
									continue;
								}
								if (checkSettledbets(bet))
								{
									writeStatus("This bet is settled already!");
									num++;
									continue;
								}
								if ((Setting.instance.stakeMethod == StakeMethod.Masaniello || Setting.instance.stakeMethod == StakeMethod.Roserpina) && BetController.Intance.pendingTip != null && !BetController.Intance.pendingTip.bFinished)
								{
									writeStatus("Pending bet is not finished.!");
									break;
								}
								bool isSucccssed = false;
								BetController.Intance.MakeBet(bet, ref isSucccssed);
								if (Setting.instance.stakeMethod == StakeMethod.Masaniello && isSucccssed)
								{
									writeStatus("Trying to register tip at Bigstake Masaniello Table");
									BigStakeCtrl.Intance.GoToMasaniello(bet);
									writeStatus("Registered tip at Masaniello Table Successfully!");
								}
								else if (Setting.instance.stakeMethod == StakeMethod.Roserpina && isSucccssed)
								{
									writeStatus("Trying to register tip at Bigstake Roserpina Table");
									BigStakeCtrl.Intance.GoToRossllo(bet);
									writeStatus("Registered tip at Roserpina Table Successfully!");
								}
								Thread.Sleep(3000);
								goto IL_033c;
							}
							catch (Exception ex2)
							{
								writeStatus("checkWrongLine : " + ex2.StackTrace.ToString());
								goto IL_033c;
							}
							IL_033c:
							num++;
						}
					}
					_betList.Clear();
					BetController.Intance.PlacingBet = false;
				}
			}
			catch
			{
			}
		}
	}

	private bool checkSameEvent(TelegramTip info)
	{
		if (Setting.instance.totalTennisTips.Count == 0)
		{
			return false;
		}
		List<TelegramTip> list = Setting.instance.totalTennisTips.FindAll((TelegramTip node) => node.match == info.match && node.marketName == info.marketName && node.selection == info.selection);
		if (list == null || list.Count < 1)
		{
			return false;
		}
		return true;
	}

	private bool checkSameRacing(TelegramTip info)
	{
		if (Setting.instance.totalTennisTips.Count == 0)
		{
			return false;
		}
		List<TelegramTip> list = Setting.instance.totalTennisTips.FindAll((TelegramTip node) => node.match == info.match);
		if (list == null || list.Count < 2)
		{
			return false;
		}
		return true;
	}

	private bool checkSameHorse(TelegramTip info)
	{
		if (Setting.instance.totalTennisTips.Count == 0)
		{
			return false;
		}
		List<TelegramTip> list = Setting.instance.totalTennisTips.FindAll((TelegramTip node) => node.match == info.match && node.selection == info.selection);
		if (list == null || list.Count < 1)
		{
			return false;
		}
		return true;
	}

	private bool checkFailedLine(TelegramTip info)
	{
		if (Setting.instance.failedTips.Count == 0)
		{
			return false;
		}
		List<TelegramTip> list = Setting.instance.failedTips.FindAll((TelegramTip node) => node.match == info.match && node.selection == info.selection && node.handicap == info.handicap);
		if (list == null || list.LongCount() < 1)
		{
			return false;
		}
		return true;
	}

	private bool checkWrongLine(TelegramTip info)
	{
		try
		{
			if (Setting.instance.totalTennisTips.Count == 0)
			{
				return false;
			}
			List<TelegramTip> list = Setting.instance.totalTennisTips.FindAll((TelegramTip node) => node.match == info.match);
			if (list == null || list.Count() == 0)
			{
				return false;
			}
			if (info.output != list[0].output)
			{
				return true;
			}
		}
		catch (Exception ex)
		{
			this.onWriteStatus("checkWrongLine : " + ex.StackTrace.ToString());
		}
		return false;
	}

	private bool checkSameLine(TelegramTip info)
	{
		if (Setting.instance.totalTennisTips.Count == 0)
		{
			return false;
		}
		List<TelegramTip> list = Setting.instance.totalTennisTips.FindAll((TelegramTip node) => node.match == info.match && node.selection == info.selection && node.handicap == info.handicap && node.period == info.period);
		if (list == null || list.Count < 1)
		{
			return false;
		}
		return true;
	}

	private bool checkSettledbets(TelegramTip betitem)
	{
		bool flag = false;
		if (BetController.Intance.settledbets == null)
		{
			return flag;
		}
		foreach (Settledbet settledbet in BetController.Intance.settledbets)
		{
			if (settledbet.I2 == betitem.selectionId)
			{
				flag = true;
				break;
			}
		}
		if (flag)
		{
			return true;
		}
		return false;
	}

	private bool checkSameLiveEvent(TelegramTip info)
	{
		if (Setting.instance.totalTennisTips.Count == 0)
		{
			return false;
		}
		List<TelegramTip> list = Setting.instance.totalTennisTips.FindAll((TelegramTip node) => node.match == info.match);
		if (list == null || list.Count <= Setting.instance.maxbetCnt)
		{
			return false;
		}
		return true;
	}

	private bool checkFailedEvent(TelegramTip info)
	{
		if (Setting.instance.failedResults.Count == 0)
		{
			return false;
		}
		List<TelegramTip> list = Setting.instance.failedResults.FindAll((TelegramTip node) => node.match == info.match && node.marketName == info.marketName && node.selection == node.selection && node.odds == info.odds);
		if (list == null || list.Count < 1)
		{
			return false;
		}
		return true;
	}

	private void writeStatus(string status)
	{
		try
		{
			if (((Control)rtLog).InvokeRequired)
			{
				((Control)rtLog).Invoke((Delegate)this.onWriteStatus, new object[1] { status });
				return;
			}
			string text = (string.IsNullOrEmpty(((Control)rtLog).Text) ? "" : "\r\n") + string.Format("{0} {1}", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), status);
			if (((TextBoxBase)rtLog).Lines.Length > 3000)
			{
				((TextBoxBase)rtLog).Clear();
			}
			((TextBoxBase)rtLog).AppendText(text);
			((TextBoxBase)rtLog).ScrollToCaret();
			this.onWriteLog(text);
		}
		catch (Exception)
		{
		}
	}

	private void updateStatus(double balance, int openbetCnt, int totalbetCnt)
	{
		try
		{
			((Control)this).Invoke((Delegate)(Action)delegate
			{
				((Control)lbBalance).Text = balance.ToString();
				((Control)lbOpendbets).Text = openbetCnt + " (bets)";
				((Control)lbTotalbets).Text = totalbetCnt + " (bets)";
			});
		}
		catch (Exception)
		{
		}
	}

	private void LogToFile(string result)
	{
		try
		{
			string text = m_path + "\\Log\\" + string.Format("log_{0}.txt", DateTime.Now.ToString("yyyy-MM-dd"));
			if (!string.IsNullOrEmpty(text))
			{
				StreamWriter streamWriter = new StreamWriter(File.Open(text, FileMode.Append, FileAccess.Write, FileShare.Read), Encoding.UTF8);
				if (!string.IsNullOrEmpty(result))
				{
					streamWriter.WriteLine(result);
				}
				streamWriter.Close();
			}
		}
		catch (Exception)
		{
		}
	}

	private void GuardStart()
	{
		Setting.instance.key = "0e0mh583kfclx8m4obp0kzgdpc56gwjb";
		Setting.instance.salt = "t49f66ynufrq2abx";
		Guard.Start_Session();
	}

	private void Form1_Load(object sender, EventArgs e)
	{
		GuardStart();
		refreshSiteInfo();
	}

	private void Form1_Closing(object sender, FormClosingEventArgs e)
	{
		try
		{
			logoutFromServer();
			Setting.instance.saveSettingInfo();
			if (m_refreshThread != null)
			{
				m_refreshThread.Abort();
			}
			Environment.Exit(-1);
		}
		catch
		{
		}
	}

	private void logoutFromServer()
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0005: Unknown result type (might be due to invalid IL or missing references)
		//IL_000b: Expected O, but got Unknown
		//IL_0036: Unknown result type (might be due to invalid IL or missing references)
		//IL_0040: Expected O, but got Unknown
		try
		{
			HttpClient val = new HttpClient();
			JObject val2 = new JObject();
			val2["username"] = JToken.op_Implicit(license);
			_ = val.PostAsync("http://173.212.250.148:9002/interface/logout", (HttpContent)new StringContent(((object)val2).ToString(), Encoding.UTF8, "application/json")).Result.Content.ReadAsStringAsync().Result;
		}
		catch (Exception)
		{
		}
	}

	private void procNewTip(List<TelegramTip> betitems)
	{
		lock (_betList)
		{
			foreach (TelegramTip betitem in betitems)
			{
				if (_betList.Find((TelegramTip x) => x.odds == betitem.odds && x.match == betitem.match && x.selection == betitem.selection) == null)
				{
					_betList.Add(betitem);
				}
			}
		}
	}

	private void procNewScore(LiveMatchScore score)
	{
		this.onWriteStatus("New Score is updated...");
		this.onWriteStatus(JsonConvert.SerializeObject((object)score));
		if (Setting.instance.stakeMethod == StakeMethod.Fixed || BetController.Intance.pendingTip == null || (BetController.Intance.pendingTip != null && BetController.Intance.pendingTip.bFinished))
		{
			return;
		}
		this.onWriteStatus("New Score : " + score.home + " vs " + score.away + "  " + score.score);
		this.onWriteStatus("Pending tip Score : " + BetController.Intance.pendingTip.match + " " + BetController.Intance.pendingTip.score);
		int num = Utils.parseToInt(score.score.Split(new char[1] { ':' })[0].Trim());
		int num2 = Utils.parseToInt(score.score.Split(new char[1] { ':' })[1].Trim());
		int num3 = Utils.parseToInt(BetController.Intance.pendingTip.score.Split(new char[1] { ':' })[0].Trim());
		int num4 = Utils.parseToInt(BetController.Intance.pendingTip.score.Split(new char[1] { ':' })[1].Trim());
		string period = BetController.Intance.pendingTip.period;
		string match = BetController.Intance.pendingTip.match;
		string text = string.Empty;
		string text2 = string.Empty;
		if (match.Contains(" vs "))
		{
			text = Regex.Split(match, " vs ")[0].Trim();
			text2 = Regex.Split(match, " vs ")[1].Trim();
		}
		else if (match.Contains(" v "))
		{
			text = Regex.Split(match, " v ")[0].Trim();
			text2 = Regex.Split(match, " v ")[1].Trim();
		}
		else if (match.Contains(" @ "))
		{
			text = Regex.Split(match, " @ ")[0].Trim();
			text2 = Regex.Split(match, " @ ")[1].Trim();
		}
		else if (match.Contains(" - "))
		{
			text = Regex.Split(match, " - ")[0].Trim();
			text2 = Regex.Split(match, " - ")[1].Trim();
		}
		if (!Utils.isSameMatch(text, text2, score.home, score.away, bAdvanced: true))
		{
			return;
		}
		if (BetController.Intance.pendingTip.marketName.Contains("OVER"))
		{
			if ((double)(num + num2) > BetController.Intance.pendingTip.handicap)
			{
				this.onWriteStatus("Pending Tip is winning now...");
				BetController.Intance.pendingTip.bFinished = true;
				if (Setting.instance.stakeMethod == StakeMethod.Masaniello)
				{
					BigStakeCtrl.Intance.UpdateRow("esito", BigStakeCtrl.Intance.current_id, "1");
				}
				else if (Setting.instance.stakeMethod == StakeMethod.Roserpina)
				{
					BigStakeCtrl.Intance.UpdateRosRow("esito", BigStakeCtrl.Intance.current_id, "1");
				}
			}
			else if (period == "FT" && score.gameTime == GAMETIME.END)
			{
				this.onWriteStatus("Pending Tip is lost now...");
				BetController.Intance.pendingTip.bFinished = true;
				if (Setting.instance.stakeMethod == StakeMethod.Masaniello)
				{
					BigStakeCtrl.Intance.UpdateRow("esito", BigStakeCtrl.Intance.current_id, "0");
				}
				else if (Setting.instance.stakeMethod == StakeMethod.Roserpina)
				{
					BigStakeCtrl.Intance.UpdateRosRow("esito", BigStakeCtrl.Intance.current_id, "0");
				}
			}
			else if (period == "HT" && score.gameTime == GAMETIME.HALF)
			{
				this.onWriteStatus("Pending Tip is lost now...");
				BetController.Intance.pendingTip.bFinished = true;
				if (Setting.instance.stakeMethod == StakeMethod.Masaniello)
				{
					BigStakeCtrl.Intance.UpdateRow("esito", BigStakeCtrl.Intance.current_id, "0");
				}
				else if (Setting.instance.stakeMethod == StakeMethod.Roserpina)
				{
					BigStakeCtrl.Intance.UpdateRosRow("esito", BigStakeCtrl.Intance.current_id, "0");
				}
			}
		}
		else if (BetController.Intance.pendingTip.marketName.Contains("UNDER"))
		{
			if (!(period == "FT") || score.gameTime != GAMETIME.END)
			{
				return;
			}
			if ((double)(num + num2) < BetController.Intance.pendingTip.handicap)
			{
				this.onWriteStatus("Pending tip is winning now...");
				BetController.Intance.pendingTip.bFinished = true;
				if (Setting.instance.stakeMethod == StakeMethod.Masaniello)
				{
					BigStakeCtrl.Intance.UpdateRow("esito", BigStakeCtrl.Intance.current_id, "1");
				}
				else if (Setting.instance.stakeMethod == StakeMethod.Roserpina)
				{
					BigStakeCtrl.Intance.UpdateRosRow("esito", BigStakeCtrl.Intance.current_id, "1");
				}
			}
			else
			{
				this.onWriteStatus("Pending Tip is lost now...");
				BetController.Intance.pendingTip.bFinished = true;
				if (Setting.instance.stakeMethod == StakeMethod.Masaniello)
				{
					BigStakeCtrl.Intance.UpdateRow("esito", BigStakeCtrl.Intance.current_id, "0");
				}
				else if (Setting.instance.stakeMethod == StakeMethod.Roserpina)
				{
					BigStakeCtrl.Intance.UpdateRosRow("esito", BigStakeCtrl.Intance.current_id, "0");
				}
			}
		}
		else if (BetController.Intance.pendingTip.marketName == "Both Teams to Score")
		{
			if (num > 0 && num2 > 0)
			{
				this.onWriteStatus("Pending Tip is winning now...");
				BetController.Intance.pendingTip.bFinished = true;
				if (Setting.instance.stakeMethod == StakeMethod.Masaniello)
				{
					BigStakeCtrl.Intance.UpdateRow("esito", BigStakeCtrl.Intance.current_id, "1");
				}
				else if (Setting.instance.stakeMethod == StakeMethod.Roserpina)
				{
					BigStakeCtrl.Intance.UpdateRosRow("esito", BigStakeCtrl.Intance.current_id, "1");
				}
			}
			else if (period == "FT" && score.gameTime == GAMETIME.END)
			{
				this.onWriteStatus("Pending Tip is lost now...");
				BetController.Intance.pendingTip.bFinished = true;
				if (Setting.instance.stakeMethod == StakeMethod.Masaniello)
				{
					BigStakeCtrl.Intance.UpdateRow("esito", BigStakeCtrl.Intance.current_id, "0");
				}
				else if (Setting.instance.stakeMethod == StakeMethod.Roserpina)
				{
					BigStakeCtrl.Intance.UpdateRosRow("esito", BigStakeCtrl.Intance.current_id, "0");
				}
			}
		}
		else
		{
			if (!(BetController.Intance.pendingTip.marketName == "next goal"))
			{
				return;
			}
			string text3 = "";
			if (text.ToLower().Contains(BetController.Intance.pendingTip.selection.ToLower()))
			{
				text3 = "home";
			}
			else if (text2.ToLower().Contains(BetController.Intance.pendingTip.selection.ToLower()))
			{
				text3 = "away";
			}
			if (text3 == "home" && num == num3 + 1)
			{
				this.onWriteStatus("Pending Tip is Winning now...");
				BetController.Intance.pendingTip.bFinished = true;
				if (Setting.instance.stakeMethod == StakeMethod.Masaniello)
				{
					BigStakeCtrl.Intance.UpdateRow("esito", BigStakeCtrl.Intance.current_id, "1");
				}
				else if (Setting.instance.stakeMethod == StakeMethod.Roserpina)
				{
					BigStakeCtrl.Intance.UpdateRosRow("esito", BigStakeCtrl.Intance.current_id, "1");
				}
			}
			else if (text3 == "away" && num2 == num4 + 1)
			{
				this.onWriteStatus("Pending Tip is Winning now...");
				BetController.Intance.pendingTip.bFinished = true;
				if (Setting.instance.stakeMethod == StakeMethod.Masaniello)
				{
					BigStakeCtrl.Intance.UpdateRow("esito", BigStakeCtrl.Intance.current_id, "1");
				}
				else if (Setting.instance.stakeMethod == StakeMethod.Roserpina)
				{
					BigStakeCtrl.Intance.UpdateRosRow("esito", BigStakeCtrl.Intance.current_id, "1");
				}
			}
			else if (period == "FT" && score.gameTime == GAMETIME.END)
			{
				this.onWriteStatus("Pending Tip is lost now...");
				BetController.Intance.pendingTip.bFinished = true;
				if (Setting.instance.stakeMethod == StakeMethod.Masaniello)
				{
					BigStakeCtrl.Intance.UpdateRow("esito", BigStakeCtrl.Intance.current_id, "0");
				}
				else if (Setting.instance.stakeMethod == StakeMethod.Roserpina)
				{
					BigStakeCtrl.Intance.UpdateRosRow("esito", BigStakeCtrl.Intance.current_id, "0");
				}
			}
		}
	}

	private bool canStart()
	{
		if (GlobalConstants.state == State.Running)
		{
			writeStatus("The bot has been started already!");
			return false;
		}
		if (string.IsNullOrEmpty(Setting.instance.betUsername) || string.IsNullOrEmpty(Setting.instance.betPassword))
		{
			writeStatus("Pleas enter bet365 account.");
			return false;
		}
		return true;
	}

	private void refreshControls(bool state)
	{
		try
		{
			((Control)this).Invoke((Delegate)(Action)delegate
			{
				if (state)
				{
					((Control)btnStart).Text = "Start Bot";
					btnStart.FillColor = Color.SpringGreen;
				}
				else
				{
					((Control)btnStart).Text = "Stop Bot";
					btnStart.FillColor = Color.Red;
				}
			});
			GlobalConstants.state = ((!state) ? State.Running : State.Stop);
		}
		catch (Exception)
		{
		}
	}

	private void tsExit_Click(object sender, EventArgs e)
	{
		((Form)this).Close();
		Environment.Exit(-1);
	}

	private void ExitProcess(string procName)
	{
		try
		{
			Process[] processes = Process.GetProcesses();
			if (processes == null)
			{
				return;
			}
			Process[] array = processes;
			foreach (Process process in array)
			{
				if (process.ProcessName == procName && process.Id != Process.GetCurrentProcess().Id)
				{
					process.Kill();
				}
			}
		}
		catch (Exception)
		{
		}
	}

	private void testFunc()
	{
		TelegramTip telegramTip = new TelegramTip();
		telegramTip.EW = "2";
		telegramTip.odds = 2.2;
		telegramTip.marketName = "Asian Handicap";
		telegramTip.link = "https://www.bet365.com/#/AC/B1/C1/D8/E125367649/F3/I3/";
		telegramTip.match = "werwerwew";
		telegramTip.selection = "werwerwerwe";
		telegramTip.marketName = "werwerwer";
		telegramTip.matchId = "125367650";
		telegramTip.selectionId = "1595047661";
		BetController.CreateInstance(this.onWriteStatus, this.onWriteLog, this.onWriteResult, this.onUpdateStatus);
	}

	private bool CanStart()
	{
		//IL_0017: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_006b: Unknown result type (might be due to invalid IL or missing references)
		//IL_008a: Unknown result type (might be due to invalid IL or missing references)
		if (string.IsNullOrEmpty(txtUserBet365.Text))
		{
			MessageBox.Show("Please input bet365 username!");
			txtUserBet365.Focus();
			return false;
		}
		if (string.IsNullOrEmpty(txtPassBet365.Text))
		{
			MessageBox.Show("Please input bet365 password!");
			txtPassBet365.Focus();
			return false;
		}
		if (string.IsNullOrEmpty(txtChannel.Text))
		{
			MessageBox.Show("Please input Telegram Channel Name!");
			txtChannel.Focus();
			return false;
		}
		if (BetController.Intance == null)
		{
			MessageBox.Show("Please Connect to Browser first!");
			((Control)btnLaunch).Focus();
			return false;
		}
		return true;
	}

	private void SetValues()
	{
		GlobalConstants.state = State.Running;
		Setting.instance.RunMode = RUNMODE.UI;
		Setting.instance.browserType = ((ListControl)comboBrowser).SelectedIndex;
		Setting.instance.betUsername = txtUserBet365.Text;
		Setting.instance.betPassword = txtPassBet365.Text;
		Setting.instance.bet365Domain = ((Control)chkDomain).Text;
		Setting.instance.serverAddr = txtServerUrl.Text;
		Setting.instance.channel = txtChannel.Text;
		Setting.instance.stakeMethod = (((RadioButton)rdFollow).Checked ? StakeMethod.Masaniello : (((RadioButton)rdRos).Checked ? StakeMethod.Roserpina : StakeMethod.Fixed));
	}

	private void refreshSiteInfo()
	{
		try
		{
			((Control)this).Invoke((Delegate)(Action)delegate
			{
				AccountSource.DataSource = Setting.instance.accounts;
				AccountSource.ResetBindings(false);
			});
		}
		catch (Exception ex)
		{
			_ = ex.Message;
		}
	}

	private void refreshResultInfo(List<dynamic> results)
	{
		try
		{
			((Control)this).Invoke((Delegate)(Action)delegate
			{
				ResultSource.DataSource = results;
				ResultSource.ResetBindings(false);
			});
		}
		catch (Exception ex)
		{
			_ = ex.Message;
		}
	}

	private void LunchBrowser()
	{
		try
		{
			CatchBrowser();
			WebsocketServer.CreateInstance(this.onWriteStatus);
			WebsocketServer.Instance.Start();
			BetController.CreateInstance(this.onWriteStatus, this.onWriteLog, this.onWriteResult, this.onUpdateStatus);
			BetController.Intance.AdjustPosition();
			BetController.Intance.DoLogin("https://" + Setting.instance.bet365Domain + "/#/HO/");
			MouseEvent.Instance.SimRandomMouseMove();
			BetController.Intance.DoClickDlgBox();
			BetController.Intance.settledbets = BetController.Intance.GetSettledBets();
			this.onWriteStatus("Browser Connected!");
		}
		catch (Exception)
		{
		}
	}

	private bool CatchBrowser()
	{
		Process[] array = null;
		IntPtr intPtr = IntPtr.Zero;
		if (Setting.instance.browserType == 1)
		{
			array = Process.GetProcessesByName("firefox");
		}
		else if (Setting.instance.browserType == 0)
		{
			array = Process.GetProcessesByName("chrome");
		}
		if (array.Length != 0)
		{
			Process[] array2 = array;
			foreach (Process process in array2)
			{
				if (process.MainWindowHandle == IntPtr.Zero)
				{
					continue;
				}
				string className = Win32.GetClassName(process.MainWindowHandle);
				intPtr = process.MainWindowHandle;
				if (Setting.instance.browserType == 1)
				{
					if (className == "MozillaWindowClass")
					{
						this.onWriteStatus("MozillaWindowClass");
						Global.windowHandle = intPtr;
						Win32.SetWindowRect();
						Win32.SetForegroundWindow(intPtr);
					}
				}
				else
				{
					Win32.SetWindowPos(intPtr, -1, 0, 0, 0, 0, 3);
					Win32.SetForegroundWindow(intPtr);
				}
				break;
			}
		}
		if (intPtr != IntPtr.Zero)
		{
			foreach (IntPtr allChildHandle in Win32.GetAllChildHandles(intPtr))
			{
				string className2 = Win32.GetClassName(allChildHandle);
				if (Setting.instance.browserType == 0 && className2 == "Chrome_RenderWidgetHostHWND")
				{
					this.onWriteStatus("Chrome_RenderWidgetHostHWND");
					Global.windowHandle = allChildHandle;
					Win32.SetWindowRect();
					break;
				}
			}
		}
		return true;
	}

	private void comboBrowser_SelectedIndexChanged(object sender, EventArgs e)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Expected O, but got Unknown
		ComboBox val = (ComboBox)sender;
		Setting.instance.browserType = ((ListControl)val).SelectedIndex;
	}

	private void setTimer_Tick(object sender, EventArgs e)
	{
		if (BetController.Intance == null)
		{
			return;
		}
		Task.Run(delegate
		{
			lock (_betList)
			{
				if (BetController.Intance.PlacingBet)
				{
					return;
				}
			}
			BetController.Intance.DoClickDlgBox();
		});
	}

	private void button1_Click(object sender, EventArgs e)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Expected O, but got Unknown
		dynamic val = (dynamic)new JObject();
		val.username = Setting.instance.betUsername;
		val.stake = 5;
		val.tipster = "Tipster";
		val.message = "[FATIMAJE353:CABALLERO6] SUCCESS. Stake:80 Odds:1.5405";
		val.eventName = "BKN Nets @ MIN Timberwolves";
		val.balance = 5;
		val.betId = "1232345235345";
		val.success = 0;
		val.balance = 6319;
		val.bookie = 2;
		val.odds = 1.5;
		val.placedAt = "14/07/2022 09:43:32 a. m.";
		m_socketConnector.SendData("betresult", val);
	}

	private void btnStart_Click(object sender, EventArgs e)
	{
		if (GlobalConstants.state == State.Running && ((Control)btnStart).Text == "Stop Bot")
		{
			refreshControls(state: true);
			m_socketConnector.CloseSocket();
			GlobalConstants.state = State.Stop;
			if (m_refreshThread != null)
			{
				m_refreshThread.Abort();
			}
			writeStatus("The bot has been stopped!");
		}
		else if (CanStart())
		{
			setTimer.Start();
			SetValues();
			refreshControls(state: false);
			writeStatus("The bot has been started!");
			BigStakeCtrl.CreateInstance();
			m_refreshThread = new Thread(refreshThreadFunc);
			m_refreshThread.Start();
			m_socketConnector.startListening();
		}
	}

	private void btnLaunch_Click_1(object sender, EventArgs e)
	{
		//IL_0017: Unknown result type (might be due to invalid IL or missing references)
		//IL_0040: Unknown result type (might be due to invalid IL or missing references)
		if (string.IsNullOrEmpty(txtUserBet365.Text))
		{
			MessageBox.Show("Please input bet365 username!");
			txtUserBet365.Focus();
		}
		else if (string.IsNullOrEmpty(txtPassBet365.Text))
		{
			MessageBox.Show("Please input bet365 password!");
			txtPassBet365.Focus();
		}
		else
		{
			SetValues();
			LunchBrowser();
		}
	}

	private void btnSet_Click(object sender, EventArgs e)
	{
		//IL_0005: Unknown result type (might be due to invalid IL or missing references)
		//IL_000b: Invalid comparison between Unknown and I4
		if ((int)((Form)new frmSet()).ShowDialog() == 1)
		{
			Setting.instance.saveSettingInfo();
		}
	}

	private void comboBrowser_SelectedIndexChanged_1(object sender, EventArgs e)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Expected O, but got Unknown
		ComboBox val = (ComboBox)sender;
		Setting.instance.browserType = ((ListControl)val).SelectedIndex;
	}

	private void btnBigStake_Click(object sender, EventArgs e)
	{
		//IL_0005: Unknown result type (might be due to invalid IL or missing references)
		((Form)new frmbigstake()).ShowDialog();
		_ = 1;
	}

	private void rdFollow_CheckedChanged(object sender, EventArgs e)
	{
		Setting.instance.stakeMethod = StakeMethod.Masaniello;
		if (BigStakeCtrl.Intance != null)
		{
			BigStakeCtrl.Intance.current_id = string.Empty;
		}
	}

	private void rdFixed_CheckedChanged(object sender, EventArgs e)
	{
		Setting.instance.stakeMethod = StakeMethod.Fixed;
	}

	private void rdRos_CheckedChanged(object sender, EventArgs e)
	{
		Setting.instance.stakeMethod = StakeMethod.Roserpina;
		if (BigStakeCtrl.Intance != null)
		{
			BigStakeCtrl.Intance.current_id = string.Empty;
		}
	}

	private void siticoneButton1_Click(object sender, EventArgs e)
	{
		BigStakeCtrl.CreateInstance();
		BigStakeCtrl.Intance.DoLogin();
		BigStakeCtrl.Intance.UpdateRosRow("quota", "", "1.5");
		BigStakeCtrl.Intance.getRosLastStake();
	}

	private void siticoneButton1_Click_1(object sender, EventArgs e)
	{
		BigStakeCtrl.CreateInstance();
		BigStakeCtrl.Intance.DoLogin();
		BigStakeCtrl.Intance.UpdateRow("quota", "", "1.5");
		BigStakeCtrl.Intance.getLastStake();
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing && components != null)
		{
			components.Dispose();
		}
		((Form)this).Dispose(disposing);
	}

	private void InitializeComponent()
	{
		//IL_000b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0011: Expected O, but got Unknown
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		//IL_0017: Expected O, but got Unknown
		//IL_0017: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Expected O, but got Unknown
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		//IL_003e: Expected O, but got Unknown
		//IL_003f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0049: Expected O, but got Unknown
		//IL_004a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0054: Expected O, but got Unknown
		//IL_0055: Unknown result type (might be due to invalid IL or missing references)
		//IL_005f: Expected O, but got Unknown
		//IL_0060: Unknown result type (might be due to invalid IL or missing references)
		//IL_006a: Expected O, but got Unknown
		//IL_006b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0075: Expected O, but got Unknown
		//IL_0076: Unknown result type (might be due to invalid IL or missing references)
		//IL_0080: Expected O, but got Unknown
		//IL_0081: Unknown result type (might be due to invalid IL or missing references)
		//IL_008b: Expected O, but got Unknown
		//IL_008c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0096: Expected O, but got Unknown
		//IL_0097: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a1: Expected O, but got Unknown
		//IL_00a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ac: Expected O, but got Unknown
		//IL_00ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b7: Expected O, but got Unknown
		//IL_00b8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c2: Expected O, but got Unknown
		//IL_00c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cd: Expected O, but got Unknown
		//IL_00ce: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d8: Expected O, but got Unknown
		//IL_00d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e3: Expected O, but got Unknown
		//IL_00e4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ee: Expected O, but got Unknown
		//IL_00ef: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f9: Expected O, but got Unknown
		//IL_00fa: Unknown result type (might be due to invalid IL or missing references)
		//IL_0104: Expected O, but got Unknown
		//IL_0105: Unknown result type (might be due to invalid IL or missing references)
		//IL_010f: Expected O, but got Unknown
		//IL_0110: Unknown result type (might be due to invalid IL or missing references)
		//IL_011a: Expected O, but got Unknown
		//IL_011b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0125: Expected O, but got Unknown
		//IL_0126: Unknown result type (might be due to invalid IL or missing references)
		//IL_0130: Expected O, but got Unknown
		//IL_0131: Unknown result type (might be due to invalid IL or missing references)
		//IL_013b: Expected O, but got Unknown
		//IL_013c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0146: Expected O, but got Unknown
		//IL_0147: Unknown result type (might be due to invalid IL or missing references)
		//IL_0151: Expected O, but got Unknown
		//IL_0152: Unknown result type (might be due to invalid IL or missing references)
		//IL_015c: Expected O, but got Unknown
		//IL_015d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0167: Expected O, but got Unknown
		//IL_0168: Unknown result type (might be due to invalid IL or missing references)
		//IL_0172: Expected O, but got Unknown
		//IL_0173: Unknown result type (might be due to invalid IL or missing references)
		//IL_017d: Expected O, but got Unknown
		//IL_017e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0188: Expected O, but got Unknown
		//IL_018f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0199: Expected O, but got Unknown
		//IL_019a: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a4: Expected O, but got Unknown
		//IL_01a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_01af: Expected O, but got Unknown
		//IL_01b0: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ba: Expected O, but got Unknown
		//IL_01bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c5: Expected O, but got Unknown
		//IL_01c6: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d0: Expected O, but got Unknown
		//IL_01d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_01db: Expected O, but got Unknown
		//IL_01dc: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e6: Expected O, but got Unknown
		//IL_01e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f1: Expected O, but got Unknown
		//IL_01f2: Unknown result type (might be due to invalid IL or missing references)
		//IL_01fc: Expected O, but got Unknown
		//IL_01fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0207: Expected O, but got Unknown
		//IL_0208: Unknown result type (might be due to invalid IL or missing references)
		//IL_0212: Expected O, but got Unknown
		//IL_0213: Unknown result type (might be due to invalid IL or missing references)
		//IL_021d: Expected O, but got Unknown
		//IL_021e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0228: Expected O, but got Unknown
		//IL_0229: Unknown result type (might be due to invalid IL or missing references)
		//IL_0233: Expected O, but got Unknown
		//IL_0234: Unknown result type (might be due to invalid IL or missing references)
		//IL_023e: Expected O, but got Unknown
		//IL_023f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0249: Expected O, but got Unknown
		//IL_024a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0254: Expected O, but got Unknown
		//IL_0255: Unknown result type (might be due to invalid IL or missing references)
		//IL_025f: Expected O, but got Unknown
		//IL_0266: Unknown result type (might be due to invalid IL or missing references)
		//IL_0270: Expected O, but got Unknown
		//IL_0384: Unknown result type (might be due to invalid IL or missing references)
		//IL_0423: Unknown result type (might be due to invalid IL or missing references)
		//IL_042d: Expected O, but got Unknown
		//IL_06c6: Unknown result type (might be due to invalid IL or missing references)
		//IL_06d0: Expected O, but got Unknown
		//IL_07e0: Unknown result type (might be due to invalid IL or missing references)
		//IL_07ea: Expected O, but got Unknown
		//IL_09f9: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a03: Expected O, but got Unknown
		//IL_0ab0: Unknown result type (might be due to invalid IL or missing references)
		//IL_0aba: Expected O, but got Unknown
		//IL_0b45: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b4f: Expected O, but got Unknown
		//IL_0bda: Unknown result type (might be due to invalid IL or missing references)
		//IL_0be4: Expected O, but got Unknown
		//IL_0c6f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c79: Expected O, but got Unknown
		//IL_0d04: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d0e: Expected O, but got Unknown
		//IL_0d99: Unknown result type (might be due to invalid IL or missing references)
		//IL_0da3: Expected O, but got Unknown
		//IL_0f3c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f46: Expected O, but got Unknown
		//IL_1062: Unknown result type (might be due to invalid IL or missing references)
		//IL_106c: Expected O, but got Unknown
		//IL_138f: Unknown result type (might be due to invalid IL or missing references)
		//IL_1399: Expected O, but got Unknown
		//IL_1479: Unknown result type (might be due to invalid IL or missing references)
		//IL_1483: Expected O, but got Unknown
		//IL_1667: Unknown result type (might be due to invalid IL or missing references)
		//IL_1671: Expected O, but got Unknown
		//IL_1725: Unknown result type (might be due to invalid IL or missing references)
		//IL_172f: Expected O, but got Unknown
		//IL_1c8e: Unknown result type (might be due to invalid IL or missing references)
		//IL_1c98: Expected O, but got Unknown
		//IL_1ec0: Unknown result type (might be due to invalid IL or missing references)
		//IL_1eca: Expected O, but got Unknown
		//IL_200c: Unknown result type (might be due to invalid IL or missing references)
		//IL_2016: Expected O, but got Unknown
		//IL_224e: Unknown result type (might be due to invalid IL or missing references)
		//IL_2258: Expected O, but got Unknown
		//IL_249d: Unknown result type (might be due to invalid IL or missing references)
		//IL_24a7: Expected O, but got Unknown
		//IL_263f: Unknown result type (might be due to invalid IL or missing references)
		//IL_2649: Expected O, but got Unknown
		//IL_2723: Unknown result type (might be due to invalid IL or missing references)
		//IL_272d: Expected O, but got Unknown
		//IL_286b: Unknown result type (might be due to invalid IL or missing references)
		//IL_2875: Expected O, but got Unknown
		//IL_2900: Unknown result type (might be due to invalid IL or missing references)
		//IL_290a: Expected O, but got Unknown
		//IL_2faa: Unknown result type (might be due to invalid IL or missing references)
		//IL_2fb4: Expected O, but got Unknown
		//IL_2fe0: Unknown result type (might be due to invalid IL or missing references)
		//IL_2fea: Expected O, but got Unknown
		components = new Container();
		DataGridViewCellStyle val = new DataGridViewCellStyle();
		DataGridViewCellStyle val2 = new DataGridViewCellStyle();
		DataGridViewCellStyle val3 = new DataGridViewCellStyle();
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(Form1));
		setTimer = new Timer(components);
		DragPanel = new SiticonePanel();
		siticoneHtmlLabel12 = new SiticoneHtmlLabel();
		siticoneControlBox2 = new SiticoneControlBox();
		siticoneControlBox1 = new SiticoneControlBox();
		btnStart = new SiticoneButton();
		btnLaunch = new SiticoneButton();
		siticonePanel1 = new SiticonePanel();
		siticoneButton1 = new SiticoneButton();
		lbTotalbets = new SiticoneHtmlLabel();
		siticoneHtmlLabel7 = new SiticoneHtmlLabel();
		lbOpendbets = new SiticoneHtmlLabel();
		siticoneHtmlLabel5 = new SiticoneHtmlLabel();
		lbBalance = new SiticoneHtmlLabel();
		siticoneHtmlLabel3 = new SiticoneHtmlLabel();
		siticonePanel2 = new SiticonePanel();
		btnBigStake = new SiticoneButton();
		btnSet = new SiticoneButton();
		siticonePanel3 = new SiticonePanel();
		siticoneHtmlLabel2 = new SiticoneHtmlLabel();
		siticoneHtmlLabel1 = new SiticoneHtmlLabel();
		rtLog = new RichTextBox();
		tbResult = new SiticoneDataGridView();
		Column5 = new DataGridViewTextBoxColumn();
		dataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
		dataGridViewTextBoxColumn2 = new DataGridViewTextBoxColumn();
		dataGridViewTextBoxColumn4 = new DataGridViewTextBoxColumn();
		selection = new DataGridViewTextBoxColumn();
		Column1 = new DataGridViewTextBoxColumn();
		Stake = new DataGridViewTextBoxColumn();
		Column4 = new DataGridViewTextBoxColumn();
		ResultSource = new BindingSource(components);
		label11 = new Label();
		label3 = new Label();
		siticoneGradientPanel1 = new SiticoneGradientPanel();
		txtChannel = new SiticoneTextBox();
		txtServerUrl = new SiticoneTextBox();
		chkDomain = new SiticoneComboBox();
		txtPassBet365 = new SiticoneTextBox();
		txtUserBet365 = new SiticoneTextBox();
		siticoneSeparator1 = new SiticoneSeparator();
		siticoneHtmlLabel9 = new SiticoneHtmlLabel();
		comboBrowser = new SiticoneComboBox();
		siticoneSeparator2 = new SiticoneSeparator();
		siticoneHtmlLabel11 = new SiticoneHtmlLabel();
		siticoneHtmlLabel13 = new SiticoneHtmlLabel();
		siticoneGradientPanel2 = new SiticoneGradientPanel();
		rdRos = new SiticoneRadioButton();
		rdFixed = new SiticoneRadioButton();
		rdFollow = new SiticoneRadioButton();
		AccountSource = new BindingSource(components);
		((Control)DragPanel).SuspendLayout();
		((Control)siticonePanel1).SuspendLayout();
		((Control)siticonePanel2).SuspendLayout();
		((Control)siticonePanel3).SuspendLayout();
		((ISupportInitialize)tbResult).BeginInit();
		((ISupportInitialize)ResultSource).BeginInit();
		((Control)siticoneGradientPanel1).SuspendLayout();
		((Control)siticoneGradientPanel2).SuspendLayout();
		((ISupportInitialize)AccountSource).BeginInit();
		((Control)this).SuspendLayout();
		setTimer.Enabled = true;
		setTimer.Interval = 30000;
		setTimer.Tick += setTimer_Tick;
		((Control)DragPanel).BackColor = Color.FromArgb(44, 46, 86);
		((Control)DragPanel).Controls.Add((Control)(object)siticoneHtmlLabel12);
		((Control)DragPanel).Controls.Add((Control)(object)siticoneControlBox2);
		((Control)DragPanel).Controls.Add((Control)(object)siticoneControlBox1);
		DragPanel.CustomBorderColor = Color.FromArgb(62, 65, 121);
		DragPanel.CustomBorderThickness = new Padding(0, 0, 0, 1);
		((Control)DragPanel).Dock = (DockStyle)1;
		DragPanel.FillColor = Color.FromArgb(44, 46, 86);
		((Control)DragPanel).Location = new Point(0, 0);
		((Control)DragPanel).Name = "DragPanel";
		((Control)DragPanel).Size = new Size(1079, 50);
		((Control)DragPanel).TabIndex = 52;
		((Control)siticoneHtmlLabel12).BackColor = Color.Transparent;
		((Control)siticoneHtmlLabel12).Enabled = false;
		siticoneHtmlLabel12.Font = new Font("Bahnschrift SemiBold SemiConden", 20f, (FontStyle)1);
		siticoneHtmlLabel12.ForeColor = Color.White;
		((Control)siticoneHtmlLabel12).Location = new Point(12, 8);
		((Control)siticoneHtmlLabel12).Name = "siticoneHtmlLabel12";
		((Control)siticoneHtmlLabel12).Size = new Size(194, 35);
		((Control)siticoneHtmlLabel12).TabIndex = 5;
		((Control)siticoneHtmlLabel12).Text = "Bottino Bet365 Bot";
		((Control)siticoneControlBox2).Anchor = (AnchorStyles)9;
		siticoneControlBox2.ControlBoxType = (ControlBoxType)0;
		((Control)siticoneControlBox2).Cursor = Cursors.Hand;
		siticoneControlBox2.FillColor = Color.FromArgb(44, 46, 86);
		siticoneControlBox2.HoverState.FillColor = Color.FromArgb(44, 46, 86);
		siticoneControlBox2.HoverState.IconColor = Color.Red;
		siticoneControlBox2.IconColor = Color.LightGray;
		((Control)siticoneControlBox2).Location = new Point(978, 2);
		((Control)siticoneControlBox2).Name = "siticoneControlBox2";
		siticoneControlBox2.PressedColor = Color.White;
		((Control)siticoneControlBox2).Size = new Size(49, 45);
		((Control)siticoneControlBox2).TabIndex = 4;
		((Control)siticoneControlBox1).Anchor = (AnchorStyles)9;
		((Control)siticoneControlBox1).Cursor = Cursors.Hand;
		siticoneControlBox1.FillColor = Color.FromArgb(44, 46, 86);
		siticoneControlBox1.HoverState.FillColor = Color.FromArgb(44, 46, 86);
		siticoneControlBox1.HoverState.IconColor = Color.Red;
		siticoneControlBox1.IconColor = Color.LightGray;
		((Control)siticoneControlBox1).Location = new Point(1027, 2);
		((Control)siticoneControlBox1).Name = "siticoneControlBox1";
		siticoneControlBox1.PressedColor = Color.White;
		((Control)siticoneControlBox1).Size = new Size(49, 45);
		((Control)siticoneControlBox1).TabIndex = 0;
		btnStart.DisabledState.BorderColor = Color.DarkGray;
		btnStart.DisabledState.CustomBorderColor = Color.DarkGray;
		btnStart.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
		btnStart.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
		btnStart.FillColor = Color.RoyalBlue;
		((Control)btnStart).Font = new Font("Bahnschrift SemiCondensed", 12f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)btnStart).ForeColor = Color.White;
		((Control)btnStart).Location = new Point(17, 33);
		((Control)btnStart).Name = "btnStart";
		((Control)btnStart).Size = new Size(89, 33);
		((Control)btnStart).TabIndex = 6;
		((Control)btnStart).Text = "Start bot";
		((Control)btnStart).Click += btnStart_Click;
		btnLaunch.DisabledState.BorderColor = Color.DarkGray;
		btnLaunch.DisabledState.CustomBorderColor = Color.DarkGray;
		btnLaunch.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
		btnLaunch.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
		btnLaunch.FillColor = Color.LightSeaGreen;
		((Control)btnLaunch).Font = new Font("Bahnschrift SemiCondensed", 12f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)btnLaunch).ForeColor = Color.White;
		((Control)btnLaunch).Location = new Point(30, 99);
		((Control)btnLaunch).Name = "btnLaunch";
		((Control)btnLaunch).Size = new Size(207, 33);
		((Control)btnLaunch).TabIndex = 53;
		((Control)btnLaunch).Text = "Connect Browser";
		((Control)btnLaunch).Click += btnLaunch_Click_1;
		((Control)siticonePanel1).BackColor = Color.FromArgb(60, 62, 118);
		((Control)siticonePanel1).Controls.Add((Control)(object)siticoneButton1);
		((Control)siticonePanel1).Controls.Add((Control)(object)lbTotalbets);
		((Control)siticonePanel1).Controls.Add((Control)(object)siticoneHtmlLabel7);
		((Control)siticonePanel1).Controls.Add((Control)(object)lbOpendbets);
		((Control)siticonePanel1).Controls.Add((Control)(object)siticoneHtmlLabel5);
		((Control)siticonePanel1).Controls.Add((Control)(object)lbBalance);
		((Control)siticonePanel1).Controls.Add((Control)(object)siticoneHtmlLabel3);
		((Control)siticonePanel1).Location = new Point(310, 51);
		((Control)siticonePanel1).Name = "siticonePanel1";
		((Control)siticonePanel1).Size = new Size(769, 95);
		((Control)siticonePanel1).TabIndex = 56;
		siticoneButton1.DisabledState.BorderColor = Color.DarkGray;
		siticoneButton1.DisabledState.CustomBorderColor = Color.DarkGray;
		siticoneButton1.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
		siticoneButton1.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
		siticoneButton1.FillColor = Color.Green;
		((Control)siticoneButton1).Font = new Font("Bahnschrift SemiCondensed", 12f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)siticoneButton1).ForeColor = Color.White;
		((Control)siticoneButton1).Location = new Point(260, 3);
		((Control)siticoneButton1).Name = "siticoneButton1";
		((Control)siticoneButton1).Size = new Size(87, 33);
		((Control)siticoneButton1).TabIndex = 56;
		((Control)siticoneButton1).Text = "테스트";
		((Control)siticoneButton1).Visible = false;
		((Control)siticoneButton1).Click += siticoneButton1_Click_1;
		((Control)lbTotalbets).BackColor = Color.Transparent;
		lbTotalbets.Font = new Font("Bahnschrift SemiCondensed", 18f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		lbTotalbets.ForeColor = Color.DarkGoldenrod;
		((Control)lbTotalbets).Location = new Point(649, 35);
		((Control)lbTotalbets).Name = "lbTotalbets";
		((Control)lbTotalbets).Size = new Size(15, 31);
		((Control)lbTotalbets).TabIndex = 46;
		((Control)lbTotalbets).Text = "0";
		((Control)siticoneHtmlLabel7).BackColor = Color.Transparent;
		siticoneHtmlLabel7.Font = new Font("Bahnschrift SemiCondensed", 14.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		siticoneHtmlLabel7.ForeColor = Color.White;
		((Control)siticoneHtmlLabel7).Location = new Point(541, 37);
		((Control)siticoneHtmlLabel7).Name = "siticoneHtmlLabel7";
		((Control)siticoneHtmlLabel7).Size = new Size(102, 25);
		((Control)siticoneHtmlLabel7).TabIndex = 47;
		((Control)siticoneHtmlLabel7).Text = "Settled Bets : ";
		((Control)lbOpendbets).BackColor = Color.Transparent;
		lbOpendbets.Font = new Font("Bahnschrift SemiCondensed", 18f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		lbOpendbets.ForeColor = Color.Red;
		((Control)lbOpendbets).Location = new Point(396, 35);
		((Control)lbOpendbets).Name = "lbOpendbets";
		((Control)lbOpendbets).Size = new Size(15, 31);
		((Control)lbOpendbets).TabIndex = 44;
		((Control)lbOpendbets).Text = "0";
		((Control)siticoneHtmlLabel5).BackColor = Color.Transparent;
		siticoneHtmlLabel5.Font = new Font("Bahnschrift SemiCondensed", 14.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		siticoneHtmlLabel5.ForeColor = Color.White;
		((Control)siticoneHtmlLabel5).Location = new Point(294, 37);
		((Control)siticoneHtmlLabel5).Name = "siticoneHtmlLabel5";
		((Control)siticoneHtmlLabel5).Size = new Size(94, 25);
		((Control)siticoneHtmlLabel5).TabIndex = 45;
		((Control)siticoneHtmlLabel5).Text = "Opend Bets : ";
		((Control)lbBalance).BackColor = Color.Transparent;
		lbBalance.Font = new Font("Bahnschrift SemiCondensed", 18f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		lbBalance.ForeColor = Color.Coral;
		((Control)lbBalance).Location = new Point(165, 35);
		((Control)lbBalance).Name = "lbBalance";
		((Control)lbBalance).Size = new Size(32, 31);
		((Control)lbBalance).TabIndex = 43;
		((Control)lbBalance).Text = "0.0";
		((Control)siticoneHtmlLabel3).BackColor = Color.Transparent;
		siticoneHtmlLabel3.Font = new Font("Bahnschrift SemiCondensed", 14.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		siticoneHtmlLabel3.ForeColor = Color.White;
		((Control)siticoneHtmlLabel3).Location = new Point(86, 37);
		((Control)siticoneHtmlLabel3).Name = "siticoneHtmlLabel3";
		((Control)siticoneHtmlLabel3).Size = new Size(70, 25);
		((Control)siticoneHtmlLabel3).TabIndex = 43;
		((Control)siticoneHtmlLabel3).Text = "Balance : ";
		((Control)siticonePanel2).BackColor = Color.FromArgb(55, 57, 108);
		((Control)siticonePanel2).Controls.Add((Control)(object)btnBigStake);
		((Control)siticonePanel2).Controls.Add((Control)(object)btnSet);
		((Control)siticonePanel2).Controls.Add((Control)(object)btnStart);
		((Control)siticonePanel2).Location = new Point(0, 51);
		((Control)siticonePanel2).Name = "siticonePanel2";
		((Control)siticonePanel2).Size = new Size(310, 95);
		((Control)siticonePanel2).TabIndex = 57;
		btnBigStake.DisabledState.BorderColor = Color.DarkGray;
		btnBigStake.DisabledState.CustomBorderColor = Color.DarkGray;
		btnBigStake.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
		btnBigStake.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
		btnBigStake.FillColor = Color.Green;
		((Control)btnBigStake).Font = new Font("Bahnschrift SemiCondensed", 12f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)btnBigStake).ForeColor = Color.White;
		((Control)btnBigStake).Location = new Point(203, 33);
		((Control)btnBigStake).Name = "btnBigStake";
		((Control)btnBigStake).Size = new Size(87, 33);
		((Control)btnBigStake).TabIndex = 55;
		((Control)btnBigStake).Text = "BigStake";
		((Control)btnBigStake).Click += btnBigStake_Click;
		btnSet.DisabledState.BorderColor = Color.DarkGray;
		btnSet.DisabledState.CustomBorderColor = Color.DarkGray;
		btnSet.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
		btnSet.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
		btnSet.FillColor = Color.FromArgb(192, 64, 0);
		((Control)btnSet).Font = new Font("Bahnschrift SemiCondensed", 12f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)btnSet).ForeColor = Color.White;
		((Control)btnSet).Location = new Point(112, 33);
		((Control)btnSet).Name = "btnSet";
		((Control)btnSet).Size = new Size(87, 33);
		((Control)btnSet).TabIndex = 54;
		((Control)btnSet).Text = "Setting";
		((Control)btnSet).Click += btnSet_Click;
		((Control)siticonePanel3).BackColor = Color.FromArgb(53, 54, 103);
		((Control)siticonePanel3).Controls.Add((Control)(object)siticoneHtmlLabel2);
		((Control)siticonePanel3).Controls.Add((Control)(object)siticoneHtmlLabel1);
		((Control)siticonePanel3).Controls.Add((Control)(object)rtLog);
		((Control)siticonePanel3).Controls.Add((Control)(object)tbResult);
		((Control)siticonePanel3).Controls.Add((Control)(object)label11);
		((Control)siticonePanel3).Controls.Add((Control)(object)label3);
		((Control)siticonePanel3).Location = new Point(310, 145);
		((Control)siticonePanel3).Name = "siticonePanel3";
		((Control)siticonePanel3).Size = new Size(769, 478);
		((Control)siticonePanel3).TabIndex = 58;
		((Control)siticoneHtmlLabel2).BackColor = Color.Transparent;
		siticoneHtmlLabel2.ForeColor = Color.White;
		((Control)siticoneHtmlLabel2).Location = new Point(38, 181);
		((Control)siticoneHtmlLabel2).Name = "siticoneHtmlLabel2";
		((Control)siticoneHtmlLabel2).Size = new Size(52, 15);
		((Control)siticoneHtmlLabel2).TabIndex = 66;
		((Control)siticoneHtmlLabel2).Text = "Bet history";
		siticoneHtmlLabel2.TextAlignment = (ContentAlignment)2;
		((Control)siticoneHtmlLabel1).BackColor = Color.Transparent;
		siticoneHtmlLabel1.ForeColor = Color.White;
		((Control)siticoneHtmlLabel1).Location = new Point(38, 25);
		((Control)siticoneHtmlLabel1).Name = "siticoneHtmlLabel1";
		((Control)siticoneHtmlLabel1).Size = new Size(54, 15);
		((Control)siticoneHtmlLabel1).TabIndex = 65;
		((Control)siticoneHtmlLabel1).Text = "Status Log";
		((Control)rtLog).Location = new Point(38, 46);
		((Control)rtLog).Name = "rtLog";
		((Control)rtLog).Size = new Size(686, 125);
		((Control)rtLog).TabIndex = 59;
		((Control)rtLog).Text = "";
		val.BackColor = Color.FromArgb(185, 226, 218);
		((DataGridView)tbResult).AlternatingRowsDefaultCellStyle = val;
		((DataGridView)tbResult).AutoGenerateColumns = false;
		tbResult.BorderStyle = (BorderStyle)1;
		val2.Alignment = (DataGridViewContentAlignment)16;
		val2.BackColor = Color.FromArgb(22, 160, 133);
		val2.Font = new Font("Microsoft Sans Serif", 8.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		val2.ForeColor = Color.White;
		val2.SelectionBackColor = SystemColors.Highlight;
		val2.SelectionForeColor = SystemColors.HighlightText;
		val2.WrapMode = (DataGridViewTriState)1;
		((DataGridView)tbResult).ColumnHeadersDefaultCellStyle = val2;
		((DataGridView)tbResult).ColumnHeadersHeight = 27;
		((DataGridView)tbResult).Columns.AddRange((DataGridViewColumn[])(object)new DataGridViewColumn[8]
		{
			(DataGridViewColumn)Column5,
			(DataGridViewColumn)dataGridViewTextBoxColumn1,
			(DataGridViewColumn)dataGridViewTextBoxColumn2,
			(DataGridViewColumn)dataGridViewTextBoxColumn4,
			(DataGridViewColumn)selection,
			(DataGridViewColumn)Column1,
			(DataGridViewColumn)Stake,
			(DataGridViewColumn)Column4
		});
		((DataGridView)tbResult).DataSource = ResultSource;
		val3.Alignment = (DataGridViewContentAlignment)16;
		val3.BackColor = Color.FromArgb(208, 235, 230);
		val3.Font = new Font("Microsoft Sans Serif", 8.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		val3.ForeColor = Color.Black;
		val3.SelectionBackColor = Color.FromArgb(99, 191, 173);
		val3.SelectionForeColor = Color.Black;
		val3.WrapMode = (DataGridViewTriState)2;
		((DataGridView)tbResult).DefaultCellStyle = val3;
		((DataGridView)tbResult).GridColor = Color.FromArgb(182, 224, 216);
		((Control)tbResult).Location = new Point(38, 199);
		((Control)tbResult).Name = "tbResult";
		tbResult.RowHeadersVisible = false;
		((Control)tbResult).Size = new Size(686, 239);
		((Control)tbResult).TabIndex = 58;
		tbResult.Theme = (DataGridViewPresetThemes)7;
		tbResult.ThemeStyle.AlternatingRowsStyle.BackColor = Color.FromArgb(185, 226, 218);
		tbResult.ThemeStyle.AlternatingRowsStyle.Font = null;
		tbResult.ThemeStyle.AlternatingRowsStyle.ForeColor = Color.Empty;
		tbResult.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = Color.Empty;
		tbResult.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = Color.Empty;
		tbResult.ThemeStyle.BackColor = Color.White;
		tbResult.ThemeStyle.GridColor = Color.FromArgb(182, 224, 216);
		tbResult.ThemeStyle.HeaderStyle.BackColor = Color.FromArgb(22, 160, 133);
		tbResult.ThemeStyle.HeaderStyle.BorderStyle = (DataGridViewHeaderBorderStyle)4;
		tbResult.ThemeStyle.HeaderStyle.Font = new Font("Microsoft Sans Serif", 8.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		tbResult.ThemeStyle.HeaderStyle.ForeColor = Color.White;
		tbResult.ThemeStyle.HeaderStyle.HeaightSizeMode = (DataGridViewColumnHeadersHeightSizeMode)1;
		tbResult.ThemeStyle.HeaderStyle.Height = 27;
		tbResult.ThemeStyle.ReadOnly = false;
		tbResult.ThemeStyle.RowsStyle.BackColor = Color.FromArgb(208, 235, 230);
		tbResult.ThemeStyle.RowsStyle.BorderStyle = (DataGridViewCellBorderStyle)8;
		tbResult.ThemeStyle.RowsStyle.Font = new Font("Microsoft Sans Serif", 8.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		tbResult.ThemeStyle.RowsStyle.ForeColor = Color.Black;
		tbResult.ThemeStyle.RowsStyle.Height = 22;
		tbResult.ThemeStyle.RowsStyle.SelectionBackColor = Color.FromArgb(99, 191, 173);
		tbResult.ThemeStyle.RowsStyle.SelectionForeColor = Color.Black;
		((DataGridViewColumn)Column5).DataPropertyName = "tipSource";
		((DataGridViewColumn)Column5).FillWeight = 60f;
		((DataGridViewColumn)Column5).HeaderText = "TipSource";
		((DataGridViewColumn)Column5).Name = "Column5";
		((DataGridViewColumn)dataGridViewTextBoxColumn1).DataPropertyName = "tournament";
		((DataGridViewColumn)dataGridViewTextBoxColumn1).FillWeight = 85f;
		((DataGridViewColumn)dataGridViewTextBoxColumn1).HeaderText = "Tournament";
		((DataGridViewColumn)dataGridViewTextBoxColumn1).Name = "dataGridViewTextBoxColumn1";
		((DataGridViewColumn)dataGridViewTextBoxColumn2).DataPropertyName = "eventName";
		((DataGridViewColumn)dataGridViewTextBoxColumn2).FillWeight = 65.98985f;
		((DataGridViewColumn)dataGridViewTextBoxColumn2).HeaderText = "Match";
		((DataGridViewColumn)dataGridViewTextBoxColumn2).Name = "dataGridViewTextBoxColumn2";
		((DataGridViewColumn)dataGridViewTextBoxColumn4).DataPropertyName = "Market";
		((DataGridViewColumn)dataGridViewTextBoxColumn4).FillWeight = 65.98985f;
		((DataGridViewColumn)dataGridViewTextBoxColumn4).HeaderText = "Market";
		((DataGridViewColumn)dataGridViewTextBoxColumn4).Name = "dataGridViewTextBoxColumn4";
		((DataGridViewColumn)selection).DataPropertyName = "selection";
		((DataGridViewColumn)selection).FillWeight = 65.98985f;
		((DataGridViewColumn)selection).HeaderText = "Selection";
		((DataGridViewColumn)selection).Name = "selection";
		((DataGridViewColumn)Column1).DataPropertyName = "odds";
		((DataGridViewColumn)Column1).FillWeight = 50f;
		((DataGridViewColumn)Column1).HeaderText = "Odds";
		((DataGridViewColumn)Column1).Name = "Column1";
		((DataGridViewColumn)Stake).DataPropertyName = "stake";
		((DataGridViewColumn)Stake).FillWeight = 65.98985f;
		((DataGridViewColumn)Stake).HeaderText = "stake";
		((DataGridViewColumn)Stake).Name = "Stake";
		((DataGridViewColumn)Column4).DataPropertyName = "placedAt";
		((DataGridViewColumn)Column4).FillWeight = 65.98985f;
		((DataGridViewColumn)Column4).HeaderText = "PlacedAt";
		((DataGridViewColumn)Column4).Name = "Column4";
		((Control)label11).AutoSize = true;
		((Control)label11).Location = new Point(243, 109);
		((Control)label11).Name = "label11";
		((Control)label11).Size = new Size(0, 13);
		((Control)label11).TabIndex = 57;
		((Control)label3).AutoSize = true;
		((Control)label3).BackColor = Color.Transparent;
		((Control)label3).Location = new Point(35, 41);
		((Control)label3).Name = "label3";
		((Control)label3).Size = new Size(76, 13);
		((Control)label3).TabIndex = 56;
		((Control)label3).Text = "Recent Orders";
		((Control)siticoneGradientPanel1).BackColor = Color.Transparent;
		siticoneGradientPanel1.BorderColor = Color.White;
		siticoneGradientPanel1.BorderRadius = 1;
		siticoneGradientPanel1.BorderStyle = (DashStyle)2;
		siticoneGradientPanel1.BorderThickness = 1;
		((Control)siticoneGradientPanel1).Controls.Add((Control)(object)txtChannel);
		((Control)siticoneGradientPanel1).Controls.Add((Control)(object)txtServerUrl);
		((Control)siticoneGradientPanel1).Controls.Add((Control)(object)chkDomain);
		((Control)siticoneGradientPanel1).Controls.Add((Control)(object)txtPassBet365);
		((Control)siticoneGradientPanel1).Controls.Add((Control)(object)txtUserBet365);
		((Control)siticoneGradientPanel1).Location = new Point(22, 167);
		((Control)siticoneGradientPanel1).Name = "siticoneGradientPanel1";
		((Control)siticoneGradientPanel1).Size = new Size(271, 239);
		((Control)siticoneGradientPanel1).TabIndex = 67;
		txtChannel.Animated = true;
		txtChannel.BorderColor = Color.FromArgb(224, 224, 224);
		txtChannel.BorderThickness = 2;
		((Control)txtChannel).Cursor = Cursors.IBeam;
		txtChannel.DefaultText = "";
		txtChannel.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
		txtChannel.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
		txtChannel.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
		txtChannel.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
		txtChannel.FocusedState.BorderColor = Color.FromArgb(81, 67, 163);
		txtChannel.FocusedState.FillColor = Color.White;
		txtChannel.Font = new Font("Segoe UI", 9f);
		txtChannel.ForeColor = Color.Black;
		txtChannel.HoverState.BorderColor = Color.Silver;
		txtChannel.HoverState.FillColor = Color.White;
		txtChannel.HoverState.ForeColor = Color.DimGray;
		txtChannel.IconLeftOffset = new Point(10, 0);
		txtChannel.IconLeftSize = new Size(17, 17);
		((Control)txtChannel).Location = new Point(30, 188);
		((Control)txtChannel).Name = "txtChannel";
		txtChannel.PasswordChar = '\0';
		txtChannel.PlaceholderText = "Enter Telegram Channel";
		txtChannel.SelectedText = "";
		((Control)txtChannel).Size = new Size(207, 36);
		((Control)txtChannel).TabIndex = 7;
		txtChannel.TextOffset = new Point(5, 0);
		txtServerUrl.Animated = true;
		txtServerUrl.BorderColor = Color.FromArgb(224, 224, 224);
		txtServerUrl.BorderThickness = 2;
		((Control)txtServerUrl).Cursor = Cursors.IBeam;
		txtServerUrl.DefaultText = "";
		txtServerUrl.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
		txtServerUrl.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
		txtServerUrl.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
		txtServerUrl.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
		txtServerUrl.FocusedState.BorderColor = Color.FromArgb(81, 67, 163);
		txtServerUrl.FocusedState.FillColor = Color.White;
		txtServerUrl.Font = new Font("Segoe UI", 9f);
		txtServerUrl.ForeColor = Color.Black;
		txtServerUrl.HoverState.BorderColor = Color.Silver;
		txtServerUrl.HoverState.FillColor = Color.White;
		txtServerUrl.HoverState.ForeColor = Color.DimGray;
		txtServerUrl.IconLeftOffset = new Point(10, 0);
		txtServerUrl.IconLeftSize = new Size(17, 17);
		((Control)txtServerUrl).Location = new Point(30, 145);
		((Control)txtServerUrl).Name = "txtServerUrl";
		txtServerUrl.PasswordChar = '\0';
		txtServerUrl.PlaceholderText = "Enter Server Url";
		txtServerUrl.SelectedText = "";
		((Control)txtServerUrl).Size = new Size(207, 36);
		((Control)txtServerUrl).TabIndex = 6;
		txtServerUrl.TextOffset = new Point(5, 0);
		((Control)chkDomain).BackColor = Color.Transparent;
		((ComboBox)chkDomain).DrawMode = (DrawMode)1;
		((ComboBox)chkDomain).DropDownStyle = (ComboBoxStyle)2;
		((ComboBox)chkDomain).FlatStyle = (FlatStyle)1;
		((Control)chkDomain).Font = new Font("Segoe UI", 10f);
		((Control)chkDomain).ForeColor = Color.FromArgb(68, 88, 112);
		((ListControl)chkDomain).FormattingEnabled = true;
		chkDomain.HoveredState.Parent = (ComboBox)(object)chkDomain;
		((ComboBox)chkDomain).ItemHeight = 30;
		((ComboBox)chkDomain).Items.AddRange(new object[5] { "bet365.it", "bet365.com", "bet365.gr", "bet365.es", "3256871.com" });
		chkDomain.ItemsAppearance.Parent = (ComboBox)(object)chkDomain;
		((Control)chkDomain).Location = new Point(30, 102);
		((Control)chkDomain).Name = "chkDomain";
		chkDomain.ShadowDecoration.Parent = (Control)(object)chkDomain;
		((Control)chkDomain).Size = new Size(207, 36);
		chkDomain.StartIndex = 0;
		((Control)chkDomain).TabIndex = 5;
		chkDomain.TextRenderingHint = (TextRenderingHint)3;
		txtPassBet365.Animated = true;
		txtPassBet365.BorderColor = Color.FromArgb(224, 224, 224);
		txtPassBet365.BorderThickness = 2;
		((Control)txtPassBet365).Cursor = Cursors.IBeam;
		txtPassBet365.DefaultText = "";
		txtPassBet365.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
		txtPassBet365.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
		txtPassBet365.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
		txtPassBet365.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
		txtPassBet365.FocusedState.BorderColor = Color.FromArgb(81, 67, 163);
		txtPassBet365.FocusedState.FillColor = Color.White;
		txtPassBet365.Font = new Font("Segoe UI", 9f);
		txtPassBet365.ForeColor = Color.Black;
		txtPassBet365.HoverState.BorderColor = Color.Silver;
		txtPassBet365.HoverState.FillColor = Color.White;
		txtPassBet365.HoverState.ForeColor = Color.DimGray;
		txtPassBet365.IconLeft = (Image)(object)Resources.password_idle;
		txtPassBet365.IconLeftOffset = new Point(10, 0);
		txtPassBet365.IconLeftSize = new Size(16, 18);
		((Control)txtPassBet365).Location = new Point(30, 59);
		((Control)txtPassBet365).Name = "txtPassBet365";
		txtPassBet365.PasswordChar = '●';
		txtPassBet365.PlaceholderText = "Enter your Bet365 Password";
		txtPassBet365.SelectedText = "";
		((Control)txtPassBet365).Size = new Size(207, 36);
		((Control)txtPassBet365).TabIndex = 4;
		txtPassBet365.TextOffset = new Point(5, 0);
		txtPassBet365.UseSystemPasswordChar = true;
		txtUserBet365.Animated = true;
		txtUserBet365.BorderColor = Color.FromArgb(224, 224, 224);
		txtUserBet365.BorderThickness = 2;
		((Control)txtUserBet365).Cursor = Cursors.IBeam;
		txtUserBet365.DefaultText = "";
		txtUserBet365.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
		txtUserBet365.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
		txtUserBet365.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
		txtUserBet365.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
		txtUserBet365.FocusedState.BorderColor = Color.FromArgb(81, 67, 163);
		txtUserBet365.FocusedState.FillColor = Color.White;
		txtUserBet365.Font = new Font("Segoe UI", 9f);
		txtUserBet365.ForeColor = Color.Black;
		txtUserBet365.HoverState.BorderColor = Color.Silver;
		txtUserBet365.HoverState.FillColor = Color.White;
		txtUserBet365.HoverState.ForeColor = Color.DimGray;
		txtUserBet365.IconLeft = (Image)(object)Resources.username_idle;
		txtUserBet365.IconLeftOffset = new Point(10, 0);
		txtUserBet365.IconLeftSize = new Size(17, 17);
		((Control)txtUserBet365).Location = new Point(30, 16);
		((Control)txtUserBet365).Name = "txtUserBet365";
		txtUserBet365.PasswordChar = '\0';
		txtUserBet365.PlaceholderText = "Enter your Bet365 Username";
		txtUserBet365.SelectedText = "";
		((Control)txtUserBet365).Size = new Size(207, 36);
		((Control)txtUserBet365).TabIndex = 3;
		txtUserBet365.TextOffset = new Point(5, 0);
		siticoneSeparator1.FillColor = Color.FromArgb(224, 224, 224);
		((Control)siticoneSeparator1).Location = new Point(22, 412);
		((Control)siticoneSeparator1).Name = "siticoneSeparator1";
		((Control)siticoneSeparator1).Size = new Size(271, 10);
		((Control)siticoneSeparator1).TabIndex = 68;
		((Control)siticoneHtmlLabel9).BackColor = Color.Transparent;
		siticoneHtmlLabel9.Font = new Font("Bahnschrift SemiCondensed", 12f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		siticoneHtmlLabel9.ForeColor = Color.White;
		((Control)siticoneHtmlLabel9).Location = new Point(33, 52);
		((Control)siticoneHtmlLabel9).Name = "siticoneHtmlLabel9";
		((Control)siticoneHtmlLabel9).Size = new Size(63, 21);
		((Control)siticoneHtmlLabel9).TabIndex = 74;
		((Control)siticoneHtmlLabel9).Text = "Browser :";
		((Control)comboBrowser).BackColor = Color.Transparent;
		comboBrowser.DrawMode = (DrawMode)1;
		comboBrowser.DropDownStyle = (ComboBoxStyle)2;
		comboBrowser.FocusedColor = Color.FromArgb(94, 148, 255);
		comboBrowser.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
		((Control)comboBrowser).Font = new Font("Segoe UI", 10f);
		((Control)comboBrowser).ForeColor = Color.FromArgb(68, 88, 112);
		((ComboBox)comboBrowser).ItemHeight = 30;
		((ComboBox)comboBrowser).Items.AddRange(new object[2] { "Chrome", "Firefox" });
		((Control)comboBrowser).Location = new Point(113, 47);
		((Control)comboBrowser).Name = "comboBrowser";
		((Control)comboBrowser).Size = new Size(124, 36);
		comboBrowser.StartIndex = 0;
		((Control)comboBrowser).TabIndex = 75;
		((ComboBox)comboBrowser).SelectedIndexChanged += comboBrowser_SelectedIndexChanged_1;
		siticoneSeparator2.FillColor = Color.FromArgb(224, 224, 224);
		((Control)siticoneSeparator2).Location = new Point(20, 585);
		((Control)siticoneSeparator2).Name = "siticoneSeparator2";
		((Control)siticoneSeparator2).Size = new Size(271, 10);
		((Control)siticoneSeparator2).TabIndex = 78;
		((Control)siticoneHtmlLabel11).BackColor = Color.Transparent;
		siticoneHtmlLabel11.Font = new Font("Bahnschrift SemiCondensed", 12f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		siticoneHtmlLabel11.ForeColor = Color.White;
		((Control)siticoneHtmlLabel11).Location = new Point(22, 596);
		((Control)siticoneHtmlLabel11).Name = "siticoneHtmlLabel11";
		((Control)siticoneHtmlLabel11).Size = new Size(57, 21);
		((Control)siticoneHtmlLabel11).TabIndex = 79;
		((Control)siticoneHtmlLabel11).Text = "Version : ";
		((Control)siticoneHtmlLabel13).BackColor = Color.Transparent;
		siticoneHtmlLabel13.Font = new Font("Bahnschrift SemiCondensed", 12f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		siticoneHtmlLabel13.ForeColor = Color.LimeGreen;
		((Control)siticoneHtmlLabel13).Location = new Point(85, 596);
		((Control)siticoneHtmlLabel13).Name = "siticoneHtmlLabel13";
		((Control)siticoneHtmlLabel13).Size = new Size(30, 21);
		((Control)siticoneHtmlLabel13).TabIndex = 80;
		((Control)siticoneHtmlLabel13).Text = "1.0.8";
		((Control)siticoneGradientPanel2).BackColor = Color.Transparent;
		siticoneGradientPanel2.BorderColor = Color.White;
		siticoneGradientPanel2.BorderRadius = 1;
		siticoneGradientPanel2.BorderStyle = (DashStyle)2;
		siticoneGradientPanel2.BorderThickness = 1;
		((Control)siticoneGradientPanel2).Controls.Add((Control)(object)rdRos);
		((Control)siticoneGradientPanel2).Controls.Add((Control)(object)rdFixed);
		((Control)siticoneGradientPanel2).Controls.Add((Control)(object)rdFollow);
		((Control)siticoneGradientPanel2).Controls.Add((Control)(object)btnLaunch);
		((Control)siticoneGradientPanel2).Controls.Add((Control)(object)comboBrowser);
		((Control)siticoneGradientPanel2).Controls.Add((Control)(object)siticoneHtmlLabel9);
		((Control)siticoneGradientPanel2).Location = new Point(22, 428);
		((Control)siticoneGradientPanel2).Name = "siticoneGradientPanel2";
		((Control)siticoneGradientPanel2).Size = new Size(271, 151);
		((Control)siticoneGradientPanel2).TabIndex = 81;
		((Control)rdRos).AutoSize = true;
		rdRos.CheckedState.BorderColor = Color.FromArgb(94, 148, 255);
		rdRos.CheckedState.BorderThickness = 0;
		rdRos.CheckedState.FillColor = Color.FromArgb(94, 148, 255);
		rdRos.CheckedState.InnerColor = Color.White;
		((Control)rdRos).ForeColor = Color.White;
		((Control)rdRos).Location = new Point(95, 11);
		((Control)rdRos).Name = "rdRos";
		((Control)rdRos).Size = new Size(73, 17);
		((Control)rdRos).TabIndex = 79;
		((Control)rdRos).Text = "Roserpina";
		rdRos.UncheckedState.BorderColor = Color.FromArgb(125, 137, 149);
		rdRos.UncheckedState.BorderThickness = 2;
		rdRos.UncheckedState.FillColor = Color.Transparent;
		rdRos.UncheckedState.InnerColor = Color.Transparent;
		((ButtonBase)rdRos).UseVisualStyleBackColor = true;
		((RadioButton)rdRos).CheckedChanged += rdRos_CheckedChanged;
		((Control)rdFixed).AutoSize = true;
		((RadioButton)rdFixed).Checked = true;
		rdFixed.CheckedState.BorderColor = Color.FromArgb(94, 148, 255);
		rdFixed.CheckedState.BorderThickness = 0;
		rdFixed.CheckedState.FillColor = Color.FromArgb(94, 148, 255);
		rdFixed.CheckedState.InnerColor = Color.White;
		((Control)rdFixed).ForeColor = Color.White;
		((Control)rdFixed).Location = new Point(179, 11);
		((Control)rdFixed).Name = "rdFixed";
		((Control)rdFixed).Size = new Size(80, 17);
		((Control)rdFixed).TabIndex = 77;
		((RadioButton)rdFixed).TabStop = true;
		((Control)rdFixed).Text = "Stake Fisso";
		rdFixed.UncheckedState.BorderColor = Color.FromArgb(125, 137, 149);
		rdFixed.UncheckedState.BorderThickness = 2;
		rdFixed.UncheckedState.FillColor = Color.Transparent;
		rdFixed.UncheckedState.InnerColor = Color.Transparent;
		((ButtonBase)rdFixed).UseVisualStyleBackColor = true;
		((RadioButton)rdFixed).CheckedChanged += rdFixed_CheckedChanged;
		((Control)rdFollow).AutoSize = true;
		rdFollow.CheckedState.BorderColor = Color.FromArgb(94, 148, 255);
		rdFollow.CheckedState.BorderThickness = 0;
		rdFollow.CheckedState.FillColor = Color.FromArgb(94, 148, 255);
		rdFollow.CheckedState.InnerColor = Color.White;
		((Control)rdFollow).ForeColor = Color.White;
		((Control)rdFollow).Location = new Point(16, 11);
		((Control)rdFollow).Name = "rdFollow";
		((Control)rdFollow).Size = new Size(75, 17);
		((Control)rdFollow).TabIndex = 76;
		((Control)rdFollow).Text = "Masaniello";
		rdFollow.UncheckedState.BorderColor = Color.FromArgb(125, 137, 149);
		rdFollow.UncheckedState.BorderThickness = 2;
		rdFollow.UncheckedState.FillColor = Color.Transparent;
		rdFollow.UncheckedState.InnerColor = Color.Transparent;
		((ButtonBase)rdFollow).UseVisualStyleBackColor = true;
		((RadioButton)rdFollow).CheckedChanged += rdFollow_CheckedChanged;
		((ContainerControl)this).AutoScaleDimensions = new SizeF(6f, 13f);
		((ContainerControl)this).AutoScaleMode = (AutoScaleMode)1;
		((Control)this).BackColor = Color.FromArgb(44, 46, 86);
		((Form)this).ClientSize = new Size(1079, 624);
		((Control)this).Controls.Add((Control)(object)siticoneGradientPanel2);
		((Control)this).Controls.Add((Control)(object)siticoneHtmlLabel13);
		((Control)this).Controls.Add((Control)(object)siticoneHtmlLabel11);
		((Control)this).Controls.Add((Control)(object)siticoneSeparator2);
		((Control)this).Controls.Add((Control)(object)siticoneSeparator1);
		((Control)this).Controls.Add((Control)(object)siticoneGradientPanel1);
		((Control)this).Controls.Add((Control)(object)siticonePanel3);
		((Control)this).Controls.Add((Control)(object)siticonePanel2);
		((Control)this).Controls.Add((Control)(object)siticonePanel1);
		((Control)this).Controls.Add((Control)(object)DragPanel);
		((Form)this).FormBorderStyle = (FormBorderStyle)0;
		((Form)this).Icon = (Icon)componentResourceManager.GetObject("$this.Icon");
		((Form)this).MaximizeBox = false;
		((Control)this).Name = "Form1";
		((Form)this).StartPosition = (FormStartPosition)1;
		((Control)this).Text = "Bet365 Placer";
		((Form)this).FormClosing += new FormClosingEventHandler(Form1_Closing);
		((Form)this).Load += Form1_Load;
		((Control)DragPanel).ResumeLayout(false);
		((Control)DragPanel).PerformLayout();
		((Control)siticonePanel1).ResumeLayout(false);
		((Control)siticonePanel1).PerformLayout();
		((Control)siticonePanel2).ResumeLayout(false);
		((Control)siticonePanel3).ResumeLayout(false);
		((Control)siticonePanel3).PerformLayout();
		((ISupportInitialize)tbResult).EndInit();
		((ISupportInitialize)ResultSource).EndInit();
		((Control)siticoneGradientPanel1).ResumeLayout(false);
		((Control)siticoneGradientPanel2).ResumeLayout(false);
		((Control)siticoneGradientPanel2).PerformLayout();
		((ISupportInitialize)AccountSource).EndInit();
		((Control)this).ResumeLayout(false);
		((Control)this).PerformLayout();
	}
}
