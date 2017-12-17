using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace TREK_V3_CanTestTool
{
    public partial class CANSpeed : Form
    {
        public static int CAN_SPEED_125K = 0;
        public static int CAN_SPEED_250K = 1;
        public static int CAN_SPEED_500K = 2;
        public static int CAN_SPEED_1M = 3;

        internal unsafe static int* can01_speed;
        internal unsafe static int* can02_speed;

        public CANSpeed()
        {
            InitializeComponent();
        }

        internal unsafe void SetChannel01SpeedParm(int* speed)
        {
            can01_speed = speed;
        }

        internal unsafe void SetChannel02SpeedParm(int* speed)
        {
            can02_speed = speed;
        }

        private void CANSpeed_Load(object sender, EventArgs e)
        {
            CanChannel01SpeedCmbx.Text = "250 K";
            CanChannel02SpeedCmbx.Text = "250 K";
        }

        private void BtnSpeedOK_Click(object sender, EventArgs e)
        {
            unsafe
            {
                if (CanChannel01SpeedCmbx.Text == "125 K")
                {
                    *can01_speed = CAN_SPEED_125K;
                }
                else if (CanChannel01SpeedCmbx.Text == "250 K")
                {
                    *can01_speed = CAN_SPEED_250K;
                }
                else if (CanChannel01SpeedCmbx.Text == "500 K")
                {
                    *can01_speed = CAN_SPEED_500K;
                }
                else
                {
                    *can01_speed = CAN_SPEED_1M;
                }

                if (CanChannel02SpeedCmbx.Text == "125 K")
                {
                    *can02_speed = CAN_SPEED_125K;
                }
                else if (CanChannel02SpeedCmbx.Text == "250 K")
                {
                    *can02_speed = CAN_SPEED_250K;
                }
                else if (CanChannel02SpeedCmbx.Text == "500 K")
                {
                    *can02_speed = CAN_SPEED_500K;
                }
                else
                {
                    *can02_speed = CAN_SPEED_1M;
                }
            }

            Hide();
            Dispose();
        }
    }
}