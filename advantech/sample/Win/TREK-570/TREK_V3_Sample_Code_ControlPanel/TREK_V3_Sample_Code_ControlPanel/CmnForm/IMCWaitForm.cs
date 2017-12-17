using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace IMCDemo
{
    public partial class IMCWaitForm : Form
    {
// The field
        static Int32 sDefTimerInterval = 500;

        // The flag of checking if the timer stop
        bool bStop;
// The constructor
        public IMCWaitForm()
        {
            InitializeComponent();
            bStop = false;
        }
// The member functions
// Show/Hide the wait window
        public void Start()
        {
            if (!TimerWait.Enabled)
            {
                TimerWait.Enabled = true;
                bStop = false;
            }        
        }

        public void Stop()
        {
            if (!TimerWait.Enabled)
            {
                TimerWait.Enabled = false;
                bStop = true;
            }
            if (Visible)
                Hide();
        }

// Set timer interval
        public void SetInterval(Int32 nTimerInterval)
        {
            TimerWait.Interval = nTimerInterval;
        }
// The event
        private void IMCWaitForm_Load(object sender, EventArgs e)
        {
            bool bNeedHScroll;
            bool bNeedVScroll;
            IMCCmnFunc.SetWindowPosAndSize(Handle, out bNeedHScroll, out bNeedVScroll);
            Hide();
            TimerWait.Enabled = false;
            TimerWait.Interval = sDefTimerInterval;
        }
        private void IMCWaitForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Stop();
        }

        private void TimerWait_Tick(object sender, EventArgs e)
        {
            if (!bStop)
            {
                Show();
    //            MessageBox.Show("Show", "Show");
                TimerWait.Enabled = false; // One shot     
                bStop = true;
            }
        }
    }
}
