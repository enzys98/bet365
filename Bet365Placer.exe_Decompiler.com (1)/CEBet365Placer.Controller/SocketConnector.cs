using System;
using System.Collections.Generic;
using System.Threading;
using CEBet365Placer.Constants;
using CEBet365Placer.Json;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Quobject.EngineIoClientDotNet.ComponentEmitter;
using Quobject.SocketIoClientDotNet.Client;

namespace CEBet365Placer.Controller;

public class SocketConnector
{
	private Socket _socket;

	private Thread m_pingThread;

	private onWriteLogEvent m_handlerWriteLog;

	private onWriteStatusEvent m_handlerWriteStatus;

	private onProcNewTipEvent m_handlerProcNewtip;

	private onProcNewScoreEvent m_handlerProcNewScore;

	public onProcUpdateNetworkStatusEvent m_handlerProcUpdateNetworkStatus;

	private List<string> m_receivedBetList = new List<string>();

	public List<TelegramTip> m_placedBetList = new List<TelegramTip>();

	public SocketConnector(onWriteLogEvent onWriteLog, onWriteStatusEvent onWriteStatus, onProcNewTipEvent onProcNewTipEvent, onProcNewScoreEvent onProceNewScoreEvent)
	{
		m_handlerWriteLog = onWriteLog;
		m_handlerWriteStatus = onWriteStatus;
		m_handlerProcNewtip = onProcNewTipEvent;
		m_handlerProcNewScore = onProceNewScoreEvent;
	}

	public void CloseSocket()
	{
		_socket.Close();
	}

	private void pingThreadFunc()
	{
		while (true)
		{
			try
			{
				((Emitter)_socket).Emit("test", new object[1] { "test" });
				Thread.Sleep(10000);
			}
			catch
			{
			}
		}
	}

	public void startListening(string bet365UserName = "")
	{
		if (_socket != null)
		{
			((Emitter)_socket).Off(Socket.EVENT_CONNECT);
			((Emitter)_socket).Off(Socket.EVENT_DISCONNECT);
			((Emitter)_socket).Off(Socket.EVENT_ERROR);
			((Emitter)_socket).Off("bot_index");
			((Emitter)_socket).Off("bottino_tips");
			((Emitter)_socket).Off("score_tips");
			m_pingThread.Abort();
			_socket.Close();
			_socket = null;
		}
		_socket = IO.Socket(Setting.instance.serverAddr);
		m_pingThread = new Thread(pingThreadFunc);
		m_pingThread.Start();
		((Emitter)_socket).On(Socket.EVENT_CONNECT, (Action)delegate
		{
			m_handlerWriteStatus("Connected Socket Server!!!");
		});
		((Emitter)_socket).On(Socket.EVENT_DISCONNECT, (Action<object>)delegate(object reason)
		{
			m_handlerWriteStatus("Disconnected Socket Server!!! || " + reason);
		});
		((Emitter)_socket).On(Socket.EVENT_ERROR, (Action)delegate
		{
			m_handlerWriteStatus("Error occurs in Socket Server!!!");
		});
		((Emitter)_socket).On("bot_index", (Action<object>)delegate(object data)
		{
			try
			{
				JsonConvert.DeserializeObject<Account>(data.ToString());
			}
			catch
			{
			}
		});
		((Emitter)_socket).On("bottino_tips", (Action<object>)delegate(object data)
		{
			try
			{
				List<TelegramTip> list = new List<TelegramTip>();
				TelegramTip telegramTip = JsonConvert.DeserializeObject<TelegramTip>(data.ToString());
				if (!(telegramTip.channel.Trim().ToLower() != Setting.instance.channel.Trim().ToLower()))
				{
					if (Setting.instance.bet365Domain.Contains("bet365.it"))
					{
						telegramTip.match = telegramTip.match.Replace("Reserves", "Riserve");
						telegramTip.match = telegramTip.match.Replace("Women", "Femminile");
					}
					list.Add(telegramTip);
					m_handlerWriteStatus($"Recieve {list.Count} new bets From Copybet Server!");
					if (GlobalConstants.state == State.Running)
					{
						m_handlerProcNewtip(list);
					}
				}
			}
			catch (Exception ex2)
			{
				m_handlerWriteStatus("Exception in BetslipNew message: " + ex2.ToString());
			}
		});
		((Emitter)_socket).On("bottino_score", (Action<object>)delegate(object data)
		{
			try
			{
				LiveMatchScore liveMatchScore = JsonConvert.DeserializeObject<LiveMatchScore>(data.ToString());
				if (Setting.instance.bet365Domain.Contains("bet365.it"))
				{
					liveMatchScore.home = liveMatchScore.home.Replace("Women", "Femminile");
					liveMatchScore.away = liveMatchScore.away.Replace("Women", "Femminile");
				}
				m_handlerWriteStatus("Recieve new Match Score From Copybet Server!");
				if (GlobalConstants.state == State.Running)
				{
					m_handlerProcNewScore(liveMatchScore);
				}
			}
			catch (Exception ex)
			{
				m_handlerWriteStatus("Exception in BetslipNew message: " + ex.ToString());
			}
		});
	}

	public void SendData(string messageCode, JObject payload)
	{
		try
		{
			((Emitter)_socket).Emit(messageCode, new object[1] { payload });
		}
		catch (Exception ex)
		{
			m_handlerWriteStatus("Exception in SocketConnector.SendData message: " + ex.ToString());
		}
	}
}
