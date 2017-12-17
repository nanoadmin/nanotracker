using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;   // for using other APIs

namespace IMCDemo
{
    class IMCWin32API
    {
// Constants
        public static IntPtr HWND_TOP = new IntPtr(0);
        public static IntPtr HWND_BOTTOM = new IntPtr(1);
        public static IntPtr HWND_TOPMOST = new IntPtr(-1);
        public static IntPtr HWND_NOTOPMOST = new IntPtr(-2);
// Retains the current size (ignores the cx and cy parameters).
        public static uint SWP_NOSIZE = 0x1;
// Retains the current position (ignores X and Y parameters).
        public static uint SWP_NOMOVE = 0x2;
// Retains the current z-order.
        public static uint SWP_NOZORDER = 0x4;
// Width and height of the screen of the primary display monitor, in pixels.
        public static int SM_CXSCREEN = 0;
        public static int SM_CYSCREEN = 1;
// The error message form GetLastError
        public static int ERROR_ALREADY_EXISTS = 183;

        public static uint SND_FILENAME = 0x00020000;
        public static uint SND_ASYNC = 0x0001;

// the return value of synchronization function
        public static uint WAIT_OBJECT_0 = 0;

        public static uint PM_REMOVE = 0x0001;

// The OS version
        public static UInt32 VER_PLATFORM_WIN32s = 0;
        public static UInt32 VER_PLATFORM_WIN32_WINDOWS = 1;
        public static UInt32 VER_PLATFORM_WIN32_NT = 2;

// The structures
        [StructLayout(LayoutKind.Sequential)]
        public struct RECT
        {
            public Int32 left;
            public Int32 top;
            public Int32 right;
            public Int32 bottom;
        };

        [StructLayout(LayoutKind.Sequential)]
        public struct POINT
        {
            public int x;
            public int y; 
        };

        [StructLayout(LayoutKind.Sequential)]
        public struct MSG 
        { 
          public IntPtr hwnd; 
          public uint message; 
          public IntPtr wParam; 
          public IntPtr lParam; 
          public uint time; 
          POINT pt; 
        };

        [StructLayout(LayoutKind.Sequential)]
        public struct OSVERSIONINFO
        {
            public UInt32 dwOSVersionInfoSize;
            public UInt32 dwMajorVersion;
            public UInt32 dwMinorVersion;
            public UInt32 dwBuildNumber;
            public UInt32 dwPlatformId;
            public unsafe fixed byte szCSDVersion[128];
        };

// APIs
        [DllImport("Kernel32.dll")]
        public static extern Int32 InterlockedExchange(ref Int32 Target, Int32 Value);

        [DllImport("Kernel32.dll")]
        public static extern UInt32 WaitForSingleObject(IntPtr hHandle, UInt32 dwMilliseconds);

        [DllImport("Kernel32.dll")]
        public static extern void OutputDebugString(string lpOutputString);

        [DllImport("Kernel32.dll")]
        public static extern unsafe void CopyMemory(byte* dest, byte* src, uint count);

        [DllImport("Kernel32.dll")]
        public static extern IntPtr CreateEvent(IntPtr lpEventAttributes, bool bManualReset, bool bInitialState, string lpName);

        [DllImport("Kernel32.dll")]
        public static extern bool SetEvent(IntPtr hEvent);

        [DllImport("Kernel32.dll")]
        public static extern bool CloseHandle(IntPtr hObject);

        [DllImport("User32.dll")]
        public static extern void PostQuitMessage(int nExitCode);

        [DllImport("User32.dll")]
        public static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int cx, int cy, uint nFlag);

        [DllImport("User32.dll")]
        public static extern int GetSystemMetrics(int nIndex);

        [DllImport("User32.dll")]
        public static extern bool GetWindowRect(IntPtr hWnd, out RECT lpRect);

        [DllImport("User32.dll")]
        public static extern bool PostMessage(IntPtr hWnd, uint Msg, IntPtr wParam, IntPtr lParam);

        [DllImport("Kernel32.dll")]
        public static extern bool CreateDirectory(string lpPathName, IntPtr lpSecurityAttributes);

        [DllImport("Kernel32.dll")]
        public static extern UInt32 GetLastError();

        [DllImport("winmm.dll")]
        public static extern bool PlaySound(string pszSound, IntPtr hmod, uint fdwSound);

        [DllImport("User32.dll")]
        public static extern bool PeekMessage(out MSG lpMsg, IntPtr hWnd, uint wMsgFilterMin, uint wMsgFilterMax, uint wRemoveMsg); 

        [DllImport("User32.dll")]
        public static extern bool TranslateMessage(ref MSG lpMsg);

        [DllImport("User32.dll")]
        public static extern uint DispatchMessage(ref MSG lpMsg);

        [DllImport("User32.dll")]
        public static extern bool UpdateWindow(IntPtr hWnd);

        [DllImport("Kernel32.dll")]
        public static extern bool GetVersionEx(out OSVERSIONINFO lpVersionInfo);

        [DllImport("Kernel32.dll")]
        public static extern IntPtr CreateMutex(IntPtr lpMutexAttributes, bool bInitialOwner, string lpName);
    }
}
