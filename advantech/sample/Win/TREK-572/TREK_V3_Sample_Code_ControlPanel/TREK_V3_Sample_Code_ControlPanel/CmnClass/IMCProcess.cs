using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;   // for using other APIs

namespace SUSI_IMC_PROCESS
{
    class IMCProcessInfo
    {
        [System.Runtime.InteropServices.StructLayout(LayoutKind.Sequential)]
        public class SECURITY_ATTRIBUTES
        {
            public int nLength;
            public string lpSecurityDescriptor;
            public bool bInheritHandle;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct STARTUPINFO
        {
            public int cb;
            public string lpReserved;
            public string lpDesktop;
            public int lpTitle;
            public int dwX;
            public int dwY;
            public int dwXSize;
            public int dwYSize;
            public int dwXCountChars;
            public int dwYCountChars;
            public int dwFillAttribute;
            public int dwFlags;
            public int wShowWindow;
            public int cbReserved2;
            public byte lpReserved2;
            public IntPtr hStdInput;
            public IntPtr hStdOutput;
            public IntPtr hStdError;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct PROCESS_INFORMATION
        {
            public IntPtr hProcess;
            public IntPtr hThread;
            public int dwProcessId;
            public int dwThreadId;
        }

        [DllImport("Kernel32.dll", CharSet = CharSet.Auto)]
        public static extern bool CreateProcess(
            StringBuilder lpApplicationName, 
            StringBuilder lpCommandLine,
            SECURITY_ATTRIBUTES lpProcessAttributes,
            SECURITY_ATTRIBUTES lpThreadAttributes,
            bool bInheritHandles,
            int dwCreationFlags,
            StringBuilder lpEnvironment,
            StringBuilder lpCurrentDirectory,
            ref STARTUPINFO lpStartupInfo,
            ref PROCESS_INFORMATION lpProcessInformation
            );

        public static int OpenProgram(string fullpath)
        {
            //uint exit_code = 0;
            STARTUPINFO sInfo = new STARTUPINFO();
            IMCProcessInfo.PROCESS_INFORMATION pInfo = new IMCProcessInfo.PROCESS_INFORMATION();

            if (!IMCProcessInfo.CreateProcess(null, new StringBuilder(fullpath), null, null, false, 0, null, null, ref sInfo, ref pInfo))
            {
                return -1;
            }
            return 0;
        }
    }
}
