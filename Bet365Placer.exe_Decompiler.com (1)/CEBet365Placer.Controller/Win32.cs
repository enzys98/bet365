using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace CEBet365Placer.Controller;

public class Win32
{
	public delegate bool EnumThreadDelegate(IntPtr hWnd, IntPtr lParam);

	public delegate bool EnumWindowProc(IntPtr hwnd, IntPtr lParam);

	public struct NativePoint
	{
		public int x;

		public int y;

		public override string ToString()
		{
			return $"X: {x}, Y: {y}";
		}
	}

	public struct Rect
	{
		public int Left;

		public int Top;

		public int Right;

		public int Bottom;
	}

	public struct MousePoint
	{
		public int X;

		public int Y;

		public MousePoint(int x, int y)
		{
			X = x;
			Y = y;
		}
	}

	public const int WM_COMMAND = 273;

	public const int WM_LBUTTONDOWN = 513;

	public const int WM_LBUTTONUP = 514;

	public const int WM_LBUTTONDBLCLK = 515;

	public const int WM_RBUTTONDOWN = 516;

	public const int WM_RBUTTONUP = 517;

	public const int WM_RBUTTONDBLCLK = 518;

	public const int WM_KEYDOWN = 256;

	public const int WM_KEYUP = 257;

	public const int SW_RESTORE = 9;

	public const int SW_MAXIMIZE = 3;

	public const int WM_PASTE = 770;

	public const int WM_SETTEXT = 12;

	public const int CB_SETCURSEL = 334;

	public const uint CB_GETLBTEXT = 328u;

	public const int HWND_TOPMOST = -1;

	public const int HWND_NOTOPMOST = -2;

	public const int SWP_NOMOVE = 2;

	public const int SWP_NOSIZE = 1;

	public const uint SWP_NOZORDER = 4u;

	public const int EM_GETSEL = 176;

	public const int EM_LINEFROMCHAR = 201;

	public const int EM_LINEINDEX = 187;

	public const int WM_SETCURSOR = 32;

	[DllImport("User32.dll")]
	public static extern int FindWindow(string strClassName, string strWindowName);

	[DllImport("user32.dll", SetLastError = true)]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool SetWindowPos(IntPtr hWnd, int hWndInsertAfter, int x, int y, int cx, int cy, int uFlags);

	[DllImport("user32.dll", CharSet = CharSet.Auto)]
	public static extern IntPtr SendMessage(IntPtr hWnd, uint Msg, int wParam, string lParam);

	[DllImport("user32.dll", CharSet = CharSet.Auto, EntryPoint = "SendMessage")]
	public static extern IntPtr SendRefMessage(IntPtr hWnd, uint Msg, int wParam, StringBuilder lParam);

	[DllImport("User32.dll")]
	public static extern int FindWindowEx(int hwndParent, int hwndChildAfter, string strClassName, string strWindowName);

	[DllImport("user32.dll")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool GetWindowRect(IntPtr hwnd, ref Rect rectangle);

	[DllImport("user32.dll")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool SetForegroundWindow(IntPtr hWnd);

	[DllImport("USER32.DLL")]
	public static extern int GetClassName(IntPtr hWnd, StringBuilder lpClassName, int nMaxCount);

	[DllImport("user32.dll")]
	public static extern bool EnumThreadWindows(int dwThreadId, EnumThreadDelegate lpfn, IntPtr lParam);

	[DllImport("user32.dll", SetLastError = true)]
	public static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int cx, int cy, uint uFlags);

	[DllImport("User32.dll")]
	public static extern int SendMessage(int hWnd, int Msg, int wParam, int lParam);

	[DllImport("user32.dll")]
	public static extern int SendMessage(int hwnd, int wMsg, int wParam, ref int lParam);

	[DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
	public static extern int GetWindowText(IntPtr hWnd, StringBuilder lpString, int nMaxCount);

	[DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
	public static extern int GetWindowTextLength(IntPtr hWnd);

	[DllImport("user32")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool EnumChildWindows(IntPtr window, EnumWindowProc callback, IntPtr lParam);

	[DllImport("user32.dll")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool ClientToScreen([In] IntPtr hWnd, ref NativePoint lpPoint);

	[DllImport("user32.dll")]
	[return: MarshalAs(UnmanagedType.Bool)]
	private static extern bool GetCursorPos(out MousePoint lpMousePoint);

	[DllImport("user32.dll")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool ScreenToClient([In] IntPtr hWnd, ref NativePoint lpPoint);

	[DllImport("user32.dll")]
	[return: MarshalAs(UnmanagedType.Bool)]
	private static extern bool SetCursorPos(int x, int y);

	[DllImport("user32.dll")]
	private static extern void mouse_event(int dwFlags, int dx, int dy, int dwData, int dwExtraInfo);

	public static void SetCursorPosition(int x, int y)
	{
		SetCursorPos(x, y);
	}

	public static void SetCursorPosition(MousePoint point)
	{
		SetCursorPos(point.X, point.Y);
	}

	public static void SetCurPosition(int x, int y)
	{
		NativePoint nativePoint = default(NativePoint);
		nativePoint.x = x;
		nativePoint.y = y;
		NativePoint lpPoint = nativePoint;
		ClientToScreen(Global.windowHandle, ref lpPoint);
		SetCursorPos(lpPoint.x, lpPoint.y);
	}

	public static void SetWindowRect()
	{
		Rect rectangle = default(Rect);
		GetWindowRect(Global.windowHandle, ref rectangle);
		Setting.instance.innerHeight = rectangle.Bottom - rectangle.Top;
		Setting.instance.innerWidth = rectangle.Right - rectangle.Left;
	}

	public static string GetClassName(IntPtr hWnd)
	{
		StringBuilder stringBuilder = new StringBuilder(256);
		GetClassName(hWnd, stringBuilder, stringBuilder.Capacity);
		return stringBuilder.ToString();
	}

	public static List<IntPtr> GetAllChildHandles(IntPtr handle)
	{
		List<IntPtr> list = new List<IntPtr>();
		GCHandle value = GCHandle.Alloc(list);
		IntPtr lParam = GCHandle.ToIntPtr(value);
		try
		{
			EnumWindowProc callback = EnumWindow;
			EnumChildWindows(handle, callback, lParam);
			return list;
		}
		finally
		{
			value.Free();
		}
	}

	private static bool EnumWindow(IntPtr hWnd, IntPtr lParam)
	{
		GCHandle gCHandle = GCHandle.FromIntPtr(lParam);
		if (gCHandle.Target == null)
		{
			return false;
		}
		(gCHandle.Target as List<IntPtr>).Add(hWnd);
		return true;
	}

	public static MousePoint GetCursorPosition()
	{
		if (!GetCursorPos(out var lpMousePoint))
		{
			lpMousePoint = new MousePoint(0, 0);
		}
		return lpMousePoint;
	}

	public static void MouseEvent(MouseEventFlags value)
	{
		MousePoint cursorPosition = GetCursorPosition();
		mouse_event((int)value, cursorPosition.X, cursorPosition.Y, 0, 0);
	}
}
