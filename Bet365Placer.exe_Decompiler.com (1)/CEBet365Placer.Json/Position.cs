namespace CEBet365Placer.Json;

public class Position
{
	public double x { get; set; }

	public double y { get; set; }

	public double width { get; set; }

	public double height { get; set; }

	public double top { get; set; }

	public double right { get; set; }

	public double bottom { get; set; }

	public double left { get; set; }

	public Position()
	{
		x = 0.0;
		y = 0.0;
		width = 0.0;
		height = 0.0;
		top = 0.0;
		right = 0.0;
		bottom = 0.0;
	}
}
