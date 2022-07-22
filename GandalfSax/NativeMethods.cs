using System;
using System.Runtime.InteropServices;
using System.Security;

namespace GandalfSax
{
	internal static class NativeMethods
	{
		[StructLayout(LayoutKind.Sequential)]
		public struct Rect
		{
			public int Left, Top, Right, Bottom;

			public Rect(int left, int top, int right, int bottom)
			{
				Left = left;
				Top = top;
				Right = right;
				Bottom = bottom;
			}

			public int Height
			{
				get { return Bottom - Top; }
				set { Bottom = value + Top; }
			}

			public int Width
			{
				get { return Right - Left; }
				set { Right = value + Left; }
			}
		}

		[DllImport("user32.dll")]
		internal static extern bool GetClientRect(IntPtr hWnd, ref Rect lpRect);

		[DllImport("user32.dll", SetLastError = true)]
		internal static extern int GetWindowLong(IntPtr hWnd, int nIndex);

		[DllImport("user32.dll", SetLastError = true)]
		internal static extern bool GetWindowRect(IntPtr hwnd, out Rect lpRect);

		[SecurityCritical]
		[SuppressUnmanagedCodeSecurity]
		[DllImport("user32.dll", CharSet = CharSet.Auto)]
		internal static extern IntPtr SetParent(IntPtr hWndChild, IntPtr hWndNewParent);

		[SecuritySafeCritical]
		internal static IntPtr SetWindowLong(IntPtr hWnd, int nIndex, long dwNewLong)
		{
			if (IntPtr.Size == 8)
			{
				return SetWindowLongPtr64(hWnd, nIndex, dwNewLong);
			}

			return new IntPtr(SetWindowLong32(hWnd, nIndex, (int)dwNewLong));
		}

		[DllImport("user32.dll", EntryPoint = "SetWindowLong")]
		private static extern int SetWindowLong32(IntPtr hWnd, int nIndex, int dwNewLong);

		[DllImport("user32.dll", EntryPoint = "SetWindowLongPtr")]
		private static extern IntPtr SetWindowLongPtr64(IntPtr hWnd, int nIndex, long dwNewLong);
	}
}
