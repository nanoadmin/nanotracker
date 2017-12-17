using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;


namespace TREK_V3_CanTestTool
{
    public partial class CANSpeed : Form
    {
        internal unsafe static char* com_port;
       
        System.IO.Ports.SerialPort sp;

        public CANSpeed()
        {
            InitializeComponent();
        }

        internal unsafe void GetPortNumber(char* port_number)
        {
            com_port = port_number;
        }

        private void CANSpeed_Load(object sender, EventArgs e)
        {
            scan_com_port();
            CanBusPortNumberCmbx.Text = "7";
        }

        private void BtnSpeedOK_Click(object sender, EventArgs e)
        {
            unsafe
            {
                *com_port =(char) Convert.ToInt16( CanBusPortNumberCmbx.SelectedItem );
            }

            Hide();
            Dispose();
        }

        private void scan_com_port()
        { 
            int baud = 19200;
            System.IO.Ports.Parity parity = System.IO.Ports.Parity.None;
            System.IO.Ports.StopBits stopbits = System.IO.Ports.StopBits.One;
            int databits = 8;
            //System.IO.Ports.Handshake handshake = System.IO.Ports.Handshake.None;

            for (int ii = 1; ii <= 256; ii++)
            {
                try
                {
                    sp = new System.IO.Ports.SerialPort("COM" + ii.ToString(), baud, parity, databits, stopbits);
                    sp.Open();
                    if (sp.IsOpen)
                    {
                        CanBusPortNumberCmbx.Items.Add(ii.ToString());
                    }
                }
                catch (Exception)  //開埠不成功就會到這來
                {
                    // 執行開埠不成功的處理
                }
                finally
                {
                    sp.Close();
                }
            }
            CanBusPortNumberCmbx.SelectedIndex = 0;
        }
    }
}