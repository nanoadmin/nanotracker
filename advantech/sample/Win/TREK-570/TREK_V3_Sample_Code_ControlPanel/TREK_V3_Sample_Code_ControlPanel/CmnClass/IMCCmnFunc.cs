using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Win32;          // For registry
using System.Windows.Forms;

namespace IMCDemo
{
    class IMCCmnFunc
    {
        // Centralize the window
        static public bool SetWindowPosAndSize(IntPtr hWnd, out bool bNeedHScroll, out bool bNeedVScroll)
        {
            bNeedHScroll = false;
            bNeedVScroll = false;
            if (hWnd == IntPtr.Zero)
                return false;

            // Get window resolution
            int nResolutionX = IMCWin32API.GetSystemMetrics(IMCWin32API.SM_CXSCREEN);
            int nResolutionY = IMCWin32API.GetSystemMetrics(IMCWin32API.SM_CYSCREEN);
            // Get window size
            int nWndX;
            int nWndY;
            if (!GetWindowSize(hWnd, out nWndX, out nWndY))
                return false;
            bNeedHScroll = ((nWndX > nResolutionX) ? true : false);
            bNeedVScroll = ((nWndY > nResolutionY) ? true : false);

            // Get the start position
            int nStartX = (bNeedHScroll ? 0 : (nResolutionX - nWndX) >> 1);
            int nStartY = (bNeedVScroll ? 0 : (nResolutionY - nWndY) >> 1);
            // Set window position
            IMCWin32API.SetWindowPos(
                hWnd, 
                IntPtr.Zero, 
                nStartX, 
                nStartY,
                (bNeedHScroll ? nResolutionX : nWndX),
                (bNeedVScroll ? nResolutionY : nWndY), 
                /*IMCWin32API.SWP_NOSIZE | */IMCWin32API.SWP_NOZORDER
                );
            return true;
        }

        static public bool GetWindowSize(IntPtr hWnd, out int nWndX, out int nWndY)
        {
            nWndX = nWndY = 0;
            if (hWnd == IntPtr.Zero)
                return false;
            IMCWin32API.RECT rcWnd = new IMCWin32API.RECT();
            IMCWin32API.GetWindowRect(hWnd, out rcWnd);
            nWndX = rcWnd.right - rcWnd.left + 1;
            nWndY = rcWnd.bottom - rcWnd.top + 1;
            return true;
        }

// Move window the topmost in z-order
        static public bool SetWindowZOrder(IntPtr hWnd, IntPtr hWndInsertAfter)
        {
            if (hWnd == IntPtr.Zero)
                return false;
            bool bSuccess = IMCWin32API.SetWindowPos(
                hWnd, 
                hWndInsertAfter, 
                0, 
                0, 
                0, 
                0, 
                IMCWin32API.SWP_NOMOVE | IMCWin32API.SWP_NOSIZE
                );
            return true;
        }

// Play sound when taking snapshot
        static public bool PlayCameraSound()
        {
            return IMCWin32API.PlaySound("camera.wav", IntPtr.Zero, IMCWin32API.SND_FILENAME | IMCWin32API.SND_ASYNC);
        }

// The main thread still handle the message while waiting for a worker thread
        static public void WaitForWorkerThread(IntPtr hEvtWait, UInt32 dwMilliSec)
        {
            if (hEvtWait == IntPtr.Zero)
                return;
            IMCWin32API.MSG msg = new IMCWin32API.MSG();
            while (true)
            {
                UInt32 nRes = IMCWin32API.WaitForSingleObject(hEvtWait, dwMilliSec);
                if (nRes == IMCWin32API.WAIT_OBJECT_0)
                    break;
                if (IMCWin32API.PeekMessage(out msg, IntPtr.Zero, 0, 0, IMCWin32API.PM_REMOVE))
                {
                    IMCWin32API.TranslateMessage(ref msg);
                    IMCWin32API.DispatchMessage(ref msg);
                }
            }
            IMCWin32API.CloseHandle(hEvtWait);
        }

        // Check if the characters are all numbers
        static public bool ChkNumChar(string strData)
        {
            byte[] byData = System.Text.Encoding.Default.GetBytes(strData);
            int nDataLen = byData.Length;
            bool bDot = false;
            for(int i = 0 ; i < nDataLen ; i++)
            {
                if(byData[i] == '.')
                {
                    if (bDot)
                        return false;
                    else
                    {
                        bDot = true;
                        continue;
                    }
                }
                if (byData[i] < '0' || byData[i] > '9')
                    return false;
            }
            return true;
        }
    }
}
