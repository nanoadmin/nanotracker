using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace IMCDemo
{
    public partial class IMCTimerThreadBaseForm : IMCBaseForm
    {

        // The event of checking if the worker thread of initializing the control panel library is done
        IntPtr hEvtTimerThreadDone;

        // The time interval the worker thread is invoked
        protected int nInvokeWorkerThreadTime;

        // The default time interval the worker thread is invoked
        public static int sDefInvokeWorkerThreadTime = 500;

        // The time wait for the termination of the worker thread
        protected int nWaitForWorkerThreadTerminateTime;

        // The default time wait for the termination of the worker thread
        public static int sDefWaitForWorkerThreadTerminateTime = 2500;


// Constructor
        public IMCTimerThreadBaseForm()
        {
            InitializeComponent();
            hEvtTimerThreadDone = IntPtr.Zero;
            nWaitForWorkerThreadTerminateTime = sDefWaitForWorkerThreadTerminateTime;
            nInvokeWorkerThreadTime = sDefInvokeWorkerThreadTime;
        }
    }
}
