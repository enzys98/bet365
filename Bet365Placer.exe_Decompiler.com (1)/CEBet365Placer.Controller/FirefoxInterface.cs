using WebSocketSharp;
using WebSocketSharp.Server;

namespace CEBet365Placer.Controller;

public class FirefoxInterface : WebSocketBehavior
{
	protected override void OnMessage(MessageEventArgs e)
	{
		WebsocketServer.Instance.HandleIncomingMessages(e.Data);
	}
}
