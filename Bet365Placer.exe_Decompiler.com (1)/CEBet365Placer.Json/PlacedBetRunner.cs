using System;
using System.Xml;

namespace CEBet365Placer.Json;

public class PlacedBetRunner
{
	public string selection { get; set; }

	public string eventName { get; set; }

	public string type { get; set; }

	public PlacedBetRunner()
	{
	}

	public PlacedBetRunner(string selection, string eventName, string type)
	{
		this.selection = selection;
		this.eventName = eventName;
		this.type = type;
	}

	public string ToXML()
	{
		return string.Concat(string.Concat(string.Concat("<Runner>" + $"<Runner-Selection>{selection}</Runner-Selection>", $"<Runner-Event>{eventName}</Runner-Event>"), $"<Runner-Type>{type}</Runner-Type>"), "</Runner>");
	}

	public bool parseFromXML(string xml)
	{
		try
		{
			XmlDocument xmlDocument = new XmlDocument();
			xmlDocument.LoadXml(xml);
			XmlNode xmlNode = xmlDocument.DocumentElement.SelectSingleNode("/Runner");
			if (xmlNode == null)
			{
				return false;
			}
			selection = xmlNode.SelectSingleNode("Runner-Selection").InnerText;
			eventName = xmlNode.SelectSingleNode("Runner-Event").InnerText;
			type = xmlNode.SelectSingleNode("Runner-Type").InnerText;
			return true;
		}
		catch (Exception)
		{
		}
		return false;
	}
}
