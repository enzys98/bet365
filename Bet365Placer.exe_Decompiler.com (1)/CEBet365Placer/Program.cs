using System;
using System.Windows.Forms;

namespace CEBet365Placer;

internal static class Program
{
	[STAThread]
	private static void Main(string[] args)
	{
		Application.EnableVisualStyles();
		Application.SetCompatibleTextRenderingDefault(false);
		Application.Run((Form)(object)new frmLogin());
	}
}
