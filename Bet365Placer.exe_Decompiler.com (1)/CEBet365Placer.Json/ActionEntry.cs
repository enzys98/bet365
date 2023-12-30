namespace CEBet365Placer.Json;

public class ActionEntry
{
	private int x;

	private int y;

	private string text;

	private int interval;

	private ClickType type;

	public int X
	{
		get
		{
			return x;
		}
		set
		{
			x = value;
		}
	}

	public int Y
	{
		get
		{
			return y;
		}
		set
		{
			y = value;
		}
	}

	public string Text
	{
		get
		{
			return text;
		}
		set
		{
			text = value;
		}
	}

	public int Interval
	{
		get
		{
			return interval;
		}
		set
		{
			interval = value;
		}
	}

	public ClickType Type
	{
		get
		{
			return type;
		}
		set
		{
			type = value;
		}
	}

	public ActionEntry(int x, int y, string text, int interval, ClickType type)
	{
		this.x = x;
		this.y = y;
		this.text = text;
		this.interval = interval;
		this.type = type;
	}
}
