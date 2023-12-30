using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using CEBet365Placer.Json;

namespace CEBet365Placer;

internal class IOManager
{
	private static string accListFile = "accList.bin";

	private static string betDataFile = "betData.bin";

	public static void saveBetData(List<BetItem> infoList)
	{
		using Stream serializationStream = File.Open(Directory.GetCurrentDirectory() + "\\" + betDataFile, FileMode.Create);
		new BinaryFormatter().Serialize(serializationStream, infoList);
	}

	public static List<BetItem> readBetData()
	{
		List<BetItem> result = new List<BetItem>();
		try
		{
			using Stream serializationStream = File.Open(Directory.GetCurrentDirectory() + "\\" + betDataFile, FileMode.Open);
			result = (List<BetItem>)new BinaryFormatter().Deserialize(serializationStream);
		}
		catch (Exception)
		{
		}
		return result;
	}

	public static void removeBetData()
	{
		try
		{
			File.Delete(Directory.GetCurrentDirectory() + "\\" + betDataFile);
		}
		catch (Exception)
		{
		}
	}

	public static void saveAccountList(List<Account> accList)
	{
		using Stream serializationStream = File.Open(Directory.GetCurrentDirectory() + "\\" + accListFile, FileMode.Create);
		new BinaryFormatter().Serialize(serializationStream, accList);
	}

	public static void writeHtmlContent(string content, string filePrefix)
	{
		try
		{
			using StreamWriter streamWriter = new StreamWriter(Directory.GetCurrentDirectory() + "\\Temp\\" + filePrefix + "-betContent.html");
			streamWriter.Write(content);
		}
		catch (Exception)
		{
		}
	}

	public static List<Account> readAccountList()
	{
		List<Account> result = new List<Account>();
		try
		{
			using Stream serializationStream = File.Open(Directory.GetCurrentDirectory() + "\\" + accListFile, FileMode.Open);
			result = (List<Account>)new BinaryFormatter().Deserialize(serializationStream);
		}
		catch (Exception)
		{
		}
		return result;
	}

	public static List<Account> readAccountList1()
	{
		List<Account> result = new List<Account>();
		try
		{
			using Stream serializationStream = File.Open(Directory.GetCurrentDirectory() + "\\" + accListFile, FileMode.Open);
			result = (List<Account>)new BinaryFormatter().Deserialize(serializationStream);
		}
		catch (Exception)
		{
		}
		return result;
	}
}
