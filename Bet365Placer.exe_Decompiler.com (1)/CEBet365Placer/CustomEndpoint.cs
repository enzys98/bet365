using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using CEBet365Placer.Json;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace CEBet365Placer;

public class CustomEndpoint
{
	public static BrowserProfile getBrowserProfile(string username)
	{
		new BrowserProfile();
		try
		{
			HttpClient httpClient = getHttpClient();
			string text = $"http://37.187.91.64:5002/interface/getProfile/{Math.Abs(username.GetHashCode())}";
			return JsonConvert.DeserializeObject<BrowserProfile>(httpClient.GetAsync(text).Result.Content.ReadAsStringAsync().Result);
		}
		catch
		{
		}
		return null;
	}

	public static string CloseBrowser()
	{
		try
		{
			JsonConvert.DeserializeObject<object>(getHttpClient().GetAsync("http://127.0.0.1:35000/api/v1/profile/stop?profileId=" + Setting.instance.profileId).Result.Content.ReadAsStringAsync().Result);
			Thread.Sleep(7000);
		}
		catch
		{
		}
		return string.Empty;
	}

	public static string LaunchBrowser(onWriteStatusEvent onWriteStatus)
	{
		try
		{
			HttpClient httpClient = getHttpClient();
			_ = string.Empty;
			string result = httpClient.GetAsync("http://127.0.0.1:35000/api/v1/profile/start?automation=true&profileId=" + Setting.instance.profileId).Result.Content.ReadAsStringAsync().Result;
			onWriteStatus(result);
			dynamic val = JsonConvert.DeserializeObject<object>(result);
			string result2 = val.value.ToString();
			Thread.Sleep(10000);
			return result2;
		}
		catch
		{
		}
		return string.Empty;
	}

	public static string UpdateProxySetting(int proxyPort, string countryCode)
	{
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		//IL_0028: Expected O, but got Unknown
		//IL_0078: Unknown result type (might be due to invalid IL or missing references)
		//IL_0082: Expected O, but got Unknown
		if (string.IsNullOrEmpty(Setting.instance.proxyServer))
		{
			return string.Empty;
		}
		HttpClient httpClient = getHttpClient();
		dynamic val = (dynamic)new JObject();
		val.proxy = (dynamic)new JObject();
		val.proxy.carrier = "";
		val.proxy.city = "";
		val.proxy.country = countryCode.ToLower();
		val.proxy.state = "";
		val.proxy.preset = "session_long";
		StringContent val2 = new StringContent(val.ToString(), Encoding.UTF8, "application/json");
		string text = $"http://{Setting.instance.proxyServer}:22999/api/proxies/{proxyPort}";
		return httpClient.PutAsync(text, (HttpContent)(object)val2).Result.Content.ReadAsStringAsync().Result;
	}

	public static string RefreshProxyIP(int proxyPort)
	{
		if (string.IsNullOrEmpty(Setting.instance.proxyServer))
		{
			return string.Empty;
		}
		HttpClient httpClient = getHttpClient();
		string text = $"http://{Setting.instance.proxyServer}:22999/api/refresh_sessions/{proxyPort}";
		return httpClient.PostAsync(text, (HttpContent)null).Result.Content.ReadAsStringAsync().Result;
	}

	public static Account getAllocatedUser(int botIndex)
	{
		try
		{
			int num = 5;
			while (--num > 0)
			{
				try
				{
					HttpResponseMessage result = getHttpClient().GetAsync(string.Format("{1}/admin/account/getAllocatedUser/{0}", botIndex, Setting.instance.serverAddr)).Result;
					result.EnsureSuccessStatusCode();
					return JsonConvert.DeserializeObject<Account>(result.Content.ReadAsStringAsync().Result);
				}
				catch (Exception)
				{
				}
			}
		}
		catch (Exception)
		{
		}
		return null;
	}

	public static void sendNewUserTerm(string serverUrl, string payload)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001b: Expected O, but got Unknown
		try
		{
			HttpClient httpClient = getHttpClient();
			StringContent val = new StringContent(payload, Encoding.UTF8, "application/json");
			HttpResponseMessage result = httpClient.PostAsync(serverUrl + "/interface/userterm", (HttpContent)(object)val).Result;
			result.EnsureSuccessStatusCode();
			_ = result.Content.ReadAsStringAsync().Result;
		}
		catch (Exception)
		{
		}
	}

	public static HttpClient getHttpClient(string proxy = "")
	{
		//IL_0050: Unknown result type (might be due to invalid IL or missing references)
		//IL_0055: Unknown result type (might be due to invalid IL or missing references)
		//IL_005d: Expected O, but got Unknown
		//IL_005e: Unknown result type (might be due to invalid IL or missing references)
		//IL_006d: Unknown result type (might be due to invalid IL or missing references)
		//IL_007b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0091: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b9: Expected O, but got Unknown
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0043: Unknown result type (might be due to invalid IL or missing references)
		//IL_004e: Expected O, but got Unknown
		HttpClientHandler val;
		if (!string.IsNullOrEmpty(proxy) && proxy != null)
		{
			Uri address = new Uri(string.Format("{0}{1}", "http://", proxy));
			bool flag = false;
			WebProxy proxy2 = new WebProxy(address, BypassOnLocal: false);
			val = new HttpClientHandler
			{
				Proxy = proxy2,
				UseProxy = true,
				PreAuthenticate = flag,
				UseDefaultCredentials = !flag
			};
		}
		else
		{
			val = new HttpClientHandler
			{
				AutomaticDecompression = (DecompressionMethods.GZip | DecompressionMethods.Deflate)
			};
		}
		HttpClient val2 = new HttpClient((HttpMessageHandler)(object)val);
		ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
		val2.Timeout = new TimeSpan(0, 0, 5);
		((HttpHeaders)val2.DefaultRequestHeaders).TryAddWithoutValidation("Accept", "text/html, application/xhtml+xml, application/xml; q=0.9, image/webp, */*; q=0.8");
		((HttpHeaders)val2.DefaultRequestHeaders).TryAddWithoutValidation("User-Agent", "Mozilla/5.0 (Windows NT 6.3; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/47.0.2526.111 Safari/537.36");
		val2.DefaultRequestHeaders.ExpectContinue = false;
		return val2;
	}
}
