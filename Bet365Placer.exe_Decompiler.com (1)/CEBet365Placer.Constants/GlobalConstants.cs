namespace CEBet365Placer.Constants;

public class GlobalConstants
{
	public static State state = State.Init;

	public static ValidationState validationState = ValidationState.SUCCESS;

	public static string DELIM_RECORD = "\u0001";

	public static string DELIM_FIELD = "\u0002";

	public static string DELIM_HANDSHAKE_MSG = "\u0003";

	public static string DELIM_MSG = "\b";

	public static char CLIENT_CONNECT = '\0';

	public static char CLIENT_POLL = '\u0001';

	public static char CLIENT_SEND = '\u0002';

	public static char CLIENT_CONNECT_FAST = '\u0003';

	public static char INITIAL_TOPIC_LOAD = '\u0014';

	public static char DELTA = '\u0015';

	public static char CLIENT_SUBSCRIBE = '\u0016';

	public static char CLIENT_UNSUBSCRIBE = '\u0017';

	public static char CLIENT_SWAP_SUBSCRIPTIONS = '\u001a';

	public static char NONE_ENCODING = '\0';

	public static char ENCRYPTED_ENCODING = '\u0011';

	public static char COMPRESSED_ENCODING = '\u0012';

	public static char BASE64_ENCODING = '\u0013';

	public static char SERVER_PING = '\u0018';

	public static char CLIENT_PING = '\u0019';

	public static char CLIENT_ABORT = '\u001c';

	public static char CLIENT_CLOSE = '\u001d';

	public static char ACK_ITL = '\u001e';

	public static char ACK_DELTA = '\u001f';

	public static char ACK_RESPONSE = ' ';

	public static char HANDSHAKE_PROTOCOL = '#';

	public static char HANDSHAKE_VERSION = '\u0003';

	public static char HANDSHAKE_CONNECTION_TYPE = 'P';

	public static char HANDSHAKE_CAPABILITIES_FLAG = '\u0001';

	public static string HANDSHAKE_STATUS_CONNECTED = "100";

	public static string HANDSHAKE_STATUS_REJECTED = "111";
}
