using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using WebSocketSharp.Server;

namespace CEBet365Placer.Controller;

public class WebsocketServer
{
	private static WebsocketServer _instance;

	private onWriteStatusEvent m_handlerWriteStatus;

	private WebSocketServer wssv;

	public static WebsocketServer Instance => _instance;

	public WebsocketServer(onWriteStatusEvent handlerWriteStatusEvent)
	{
		m_handlerWriteStatus = handlerWriteStatusEvent;
	}

	public static void CreateInstance(onWriteStatusEvent handlerWriteStatusEvent)
	{
		_instance = new WebsocketServer(handlerWriteStatusEvent);
	}

	public void Start()
	{
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		//IL_001a: Expected O, but got Unknown
		wssv = new WebSocketServer((int)Setting.instance.numAgentPort);
		wssv.AddWebSocketService<FirefoxInterface>("/firefox");
		wssv.Start();
		m_handlerWriteStatus($"Websocket server is listening on {(int)Setting.instance.numAgentPort}");
	}

	public void Stop()
	{
		wssv.Stop();
	}

	public void SendData(string message)
	{
		try
		{
			wssv.WebSocketServices.Broadcast(message);
		}
		catch
		{
		}
	}

	public void ExecuteScript(string jsCode)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Expected O, but got Unknown
		dynamic val = (dynamic)new JObject();
		val.type = "jscode";
		val.body = jsCode;
		SendData(val.ToString());
	}

	public void HandleIncomingMessages(string data)
	{
		try
		{
			JObject message = JsonConvert.DeserializeObject<JObject>(data);
			BetController.Intance.WebResourceResponseReceived(message);
		}
		catch
		{
		}
	}
}
