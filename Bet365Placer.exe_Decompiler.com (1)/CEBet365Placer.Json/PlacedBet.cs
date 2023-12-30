using System;
using System.Collections.Generic;
using System.Xml;

namespace CEBet365Placer.Json;

public class PlacedBet
{
	public List<PlacedBetRunner> runners;

	public string betType { get; set; }

	public string stake { get; set; }

	public string possibleWin { get; set; }

	public string betId { get; set; }

	public string selection { get; set; }

	public PlacedBet(string type, string stake, string selection)
	{
		betType = type;
		this.stake = stake;
		this.selection = selection;
		runners = new List<PlacedBetRunner>();
	}

	public PlacedBet()
	{
		runners = new List<PlacedBetRunner>();
	}

	public string ToXML()
	{
		string text = "<PlacedBet>";
		text += $"<BetType>{betType}</BetType>";
		text += $"<Stake>{stake}</Stake>";
		text += $"<BetId>{betId}</BetId>";
		text += $"<Selection>{selection}</Selection>";
		text += "<Runners>";
		foreach (PlacedBetRunner runner in runners)
		{
			text += runner.ToXML();
		}
		text += "</Runners>";
		return text + "</PlacedBet>";
	}

	public bool parseFromXML(string xml)
	{
		try
		{
			XmlDocument xmlDocument = new XmlDocument();
			xmlDocument.LoadXml(xml);
			XmlNode xmlNode = xmlDocument.DocumentElement.SelectSingleNode("/PlacedBet");
			if (xmlNode == null)
			{
				return false;
			}
			betType = xmlNode.SelectSingleNode("BetType").InnerText;
			stake = xmlNode.SelectSingleNode("Stake").InnerText;
			selection = xmlNode.SelectSingleNode("Selection").InnerText;
			betId = xmlNode.SelectSingleNode("BetId").InnerText;
			foreach (XmlNode item in xmlNode.SelectNodes("Runners/Runner"))
			{
				PlacedBetRunner placedBetRunner = new PlacedBetRunner();
				placedBetRunner.parseFromXML("<Runner>" + item.InnerXml + "</Runner>");
				runners.Add(placedBetRunner);
			}
			return true;
		}
		catch (Exception)
		{
		}
		return false;
	}

	public bool compareWith(PlacedBet B)
	{
		if (betType != B.betType)
		{
			return false;
		}
		if (stake != B.stake)
		{
			return false;
		}
		for (int i = 0; i < runners.Count; i++)
		{
			PlacedBetRunner placedBetRunner = runners[i];
			PlacedBetRunner placedBetRunner2 = B.runners[i];
			if (placedBetRunner.selection != placedBetRunner2.selection)
			{
				return false;
			}
			if (placedBetRunner.type != placedBetRunner2.type)
			{
				return false;
			}
			if (placedBetRunner.eventName != placedBetRunner2.eventName)
			{
				return false;
			}
		}
		return true;
	}
}
