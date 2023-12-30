using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
using CEBet365Placer.Json;

namespace CEBet365Placer.Controller;

public class MouseEvent
{
	private Random random = new Random();

	private int mouseSpeed = 20;

	private Point cur_point = new Point(0, 0);

	public const int WM_SETCURSOR = 32;

	public const int WM_LBUTTONDOWN = 513;

	public const int WM_LBUTTONUP = 514;

	public const uint WM_MOUSEWHEEL = 522u;

	public const uint WM_LBUTTONDBLCLK = 515u;

	public const uint WM_RBUTTONDOWN = 516u;

	public const uint WM_RBUTTONUP = 517u;

	public const uint WM_RBUTTONDBLCLK = 518u;

	public const uint WM_SETFOCUS = 7u;

	public const uint WM_ACTIVATE = 6u;

	private SynchronizationContext context;

	private static MouseEvent _instance;

	public static MouseEvent Instance
	{
		get
		{
			if (_instance == null)
			{
				_instance = new MouseEvent();
			}
			return _instance;
		}
	}

	[DllImport("user32")]
	private static extern int mouse_event(int dwFlags, int dx, int dy, int dwData, int dwExtraInfo);

	[DllImport("user32")]
	public static extern int SetCursorPos(int x, int y);

	[DllImport("user32.dll")]
	public static extern bool GetCursorPos(out Point p);

	[DllImport("User32.dll", CharSet = CharSet.Auto, SetLastError = true)]
	internal static extern bool PostMessage(IntPtr hWnd, uint Msg, IntPtr wParam, IntPtr lParam);

	[DllImport("user32.dll")]
	public static extern int SendMessage(IntPtr hWnd, uint wMsg, IntPtr wParam, IntPtr lParam);

	public MouseEvent()
	{
		context = SynchronizationContext.Current;
	}

	public void RunAction(ActionEntry action)
	{
		if (action.Type.Equals(ClickType.SendKeys))
		{
			WorkSendKeys(action);
		}
		else
		{
			WorkClick(action);
		}
		Thread.Sleep(Utils.GetRandValue(100, 400));
	}

	private void WorkSendKeys(object state)
	{
		context.Send(delegate
		{
			SendKeys.Send((state as ActionEntry).Text);
		}, state);
	}

	private void WorkClick(object state)
	{
		context.Send(delegate
		{
			ActionEntry actionEntry = state as ActionEntry;
			cur_point.X = actionEntry.X;
			cur_point.Y = actionEntry.Y;
			Win32.SetCurPosition(actionEntry.X, actionEntry.Y);
			if (actionEntry.Interval == 2)
			{
				SendMessage(Global.windowHandle, 6u, (IntPtr)1, (IntPtr)0);
			}
			Thread.Sleep(100);
			if (actionEntry.Type.Equals(ClickType.click))
			{
				IntPtr lParam = MAKELPARAM(actionEntry.X, actionEntry.Y);
				SendMessage(Global.windowHandle, 513u, (IntPtr)2, lParam);
				SendMessage(Global.windowHandle, 514u, (IntPtr)1, lParam);
			}
			else if (actionEntry.Type.Equals(ClickType.doubleClick))
			{
				IntPtr lParam2 = MAKELPARAM(actionEntry.X, actionEntry.Y);
				SendMessage(Global.windowHandle, 513u, (IntPtr)1, lParam2);
				SendMessage(Global.windowHandle, 514u, (IntPtr)1, lParam2);
				Thread.Sleep(100);
				SendMessage(Global.windowHandle, 513u, (IntPtr)1, lParam2);
				SendMessage(Global.windowHandle, 514u, (IntPtr)1, lParam2);
			}
			else if (actionEntry.Type.Equals(ClickType.TripleClick))
			{
				IntPtr lParam3 = MAKELPARAM(actionEntry.X, actionEntry.Y);
				SendMessage(Global.windowHandle, 513u, (IntPtr)1, lParam3);
				SendMessage(Global.windowHandle, 514u, (IntPtr)1, lParam3);
				Thread.Sleep(100);
				SendMessage(Global.windowHandle, 513u, (IntPtr)1, lParam3);
				SendMessage(Global.windowHandle, 514u, (IntPtr)1, lParam3);
				Thread.Sleep(100);
				SendMessage(Global.windowHandle, 513u, (IntPtr)1, lParam3);
				SendMessage(Global.windowHandle, 514u, (IntPtr)1, lParam3);
			}
			else if (actionEntry.Type.Equals(ClickType.rightClick))
			{
				IntPtr lParam4 = MAKELPARAM(actionEntry.X, actionEntry.Y);
				SendMessage(Global.windowHandle, 516u, (IntPtr)1, lParam4);
				Thread.Sleep(100);
				SendMessage(Global.windowHandle, 517u, (IntPtr)1, lParam4);
				Thread.Sleep(100);
			}
			else
			{
				int num = -1;
				if (actionEntry.Interval > 0)
				{
					num = -1;
					actionEntry.Interval = Math.Abs(actionEntry.Interval);
				}
				else
				{
					num = 1;
					actionEntry.Interval = Math.Abs(actionEntry.Interval);
				}
				IntPtr wParam = MAKEWPARAM(num, actionEntry.Interval);
				IntPtr lParam5 = MAKELPARAM(actionEntry.X, actionEntry.Y);
				PostMessage(Global.windowHandle, 522u, wParam, lParam5);
				Thread.Sleep(500);
			}
		}, state);
	}

	private void Scroll(ActionEntry action)
	{
		Point p = default(Point);
		GetCursorPos(out p);
		Win32.NativePoint nativePoint = default(Win32.NativePoint);
		nativePoint.x = p.X;
		nativePoint.y = p.Y;
		Win32.NativePoint lpPoint = nativePoint;
		Win32.ClientToScreen(Global.windowHandle, ref lpPoint);
		Cursor.Position = new Point(lpPoint.x, lpPoint.y);
		IntPtr wParam = MAKEWPARAM(-1, action.Interval);
		IntPtr lParam = MAKELPARAM(action.X, action.Y);
		PostMessage(Global.windowHandle, 522u, wParam, lParam);
	}

	public IntPtr MAKEWPARAM(int direction, float multiplier)
	{
		return (IntPtr)(((int)((float)SystemInformation.MouseWheelScrollDelta * multiplier) << 16) * Math.Sign(direction));
	}

	public IntPtr MAKEWPARAM(int direction, int delta)
	{
		return (IntPtr)((delta << 16) * Math.Sign(direction));
	}

	public IntPtr MAKELPARAM(int low, int high)
	{
		return (IntPtr)((high << 16) | (low & 0xFFFF));
	}

	public void SimRandomMouseMove()
	{
		try
		{
			int num = (int)Setting.instance.innerWidth;
			int num2 = (int)Setting.instance.innerHeight;
			int minValue = num / 16;
			int minValue2 = num2 / 24;
			int maxValue = num * 15 / 16;
			int num3 = num2 * 23 / 24;
			Point point = new Point(Utils.GetRandValue(minValue, maxValue), (Utils.GetRandValue(10) > 5) ? (num3 - Utils.GetRandValue(minValue2, num3)) : Utils.GetRandValue(minValue2, num3));
			MoveMouse(cur_point.X, cur_point.Y, point.X, point.Y);
			cur_point = point;
			Thread.Sleep(500);
		}
		catch (Exception)
		{
		}
	}

	public void MoveMouse(int x, int y, int rx, int ry)
	{
		x += random.Next(rx);
		y += random.Next(ry);
		double num = Math.Max(((double)random.Next(mouseSpeed) / 2.0 + (double)mouseSpeed) / 10.0, 0.1);
		WindMouse(cur_point.X, cur_point.Y, x, y, 9.0, 3.0, 10.0 / num, 15.0 / num, 10.0 * num, 10.0 * num);
	}

	public void WindMouse(double xs, double ys, double xe, double ye, double gravity, double wind, double minWait, double maxWait, double maxStep, double targetArea)
	{
		double num = 0.0;
		double num2 = 0.0;
		double num3 = 0.0;
		double num4 = 0.0;
		int num5 = (int)Math.Round(xs);
		int num6 = (int)Math.Round(ys);
		double num7 = maxWait - minWait;
		double num8 = Math.Sqrt(2.0);
		double num9 = Math.Sqrt(3.0);
		double num10 = Math.Sqrt(5.0);
		double num11 = Hypot(xe - xs, ye - ys);
		while (num11 > 1.0)
		{
			wind = Math.Min(wind, num11);
			if (num11 >= targetArea)
			{
				int num12 = random.Next((int)Math.Round(wind) * 2 + 1);
				num = num / num9 + ((double)num12 - wind) / num10;
				num2 = num2 / num9 + ((double)num12 - wind) / num10;
			}
			else
			{
				num /= num8;
				num2 /= num8;
				maxStep = ((!(maxStep < 3.0)) ? (maxStep / num10) : ((double)random.Next(3) + 3.0));
			}
			num3 += num;
			num4 += num2;
			num3 += gravity * (xe - xs) / num11;
			num4 += gravity * (ye - ys) / num11;
			if (Hypot(num3, num4) > maxStep)
			{
				double num13 = maxStep / 2.0 + (double)random.Next((int)Math.Round(maxStep) / 2);
				double num14 = Hypot(num3, num4);
				num3 = num3 / num14 * num13;
				num4 = num4 / num14 * num13;
			}
			int num15 = (int)Math.Round(xs);
			int num16 = (int)Math.Round(ys);
			xs += num3;
			ys += num4;
			num11 = Hypot(xe - xs, ye - ys);
			num5 = (int)Math.Round(xs);
			num6 = (int)Math.Round(ys);
			if (num15 != num5 || num16 != num6)
			{
				Win32.SetCurPosition(num5, num6);
				cur_point.X = num5;
				cur_point.Y = num6;
			}
			double num17 = Hypot(xs - (double)num15, ys - (double)num16);
			Thread.Sleep((int)Math.Round(num7 * (num17 / maxStep) + minWait));
		}
		int num18 = (int)Math.Round(xe);
		int num19 = (int)Math.Round(ye);
		if (num18 != num5 || num19 != num6)
		{
			Win32.SetCurPosition(num18, num19);
			cur_point.X = num18;
			cur_point.Y = num19;
		}
	}

	public double Hypot(double dx, double dy)
	{
		return Math.Sqrt(dx * dx + dy * dy);
	}
}
