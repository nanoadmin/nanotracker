using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace TREK_V3_Sample_Code_TemperatureSensor
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            UInt16 retcode;

            retcode = TEMP_API.SUSI_IMC_TEMPERATURESENSOR_Initialize();
            if (retcode != TEMP_API.IMC_ERR_NO_ERROR)
            {
                MessageBox.Show("SUSI_IMC_TEMPERATURESENSOR_Initialize fail "+ retcode.ToString("X4"));
                return;
            }
            //°C
            string[] arrCPUCore1Item = { "CPU Core 1", "Unknown" };
            string[] arrCPUCore2tem = { "CPU Core 2", "Unknown" };
            string[] arrSYS1Item = { "System 1", "Unknown" };
            ListViewItem itemCPU1 = new ListViewItem(arrCPUCore1Item);
            ListViewItem itemCPU2 = new ListViewItem(arrCPUCore2tem);
            ListViewItem itemSYS1 = new ListViewItem(arrSYS1Item);
            
            LiveData.Items.Add(itemCPU1);
            LiveData.Items.Add(itemCPU2);
            LiveData.Items.Add(itemSYS1);

            Updatetimer.Start();
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            TEMP_API.SUSI_IMC_TEMPERATURESENSOR_Deinitialize();            
        }

        private void Updatetimer_Tick(object sender, EventArgs e)
        {
            UInt16 retcode;
            byte val;

            retcode = TEMP_API.SUSI_IMC_TEMPERATURESENSOR_GetCPUCore1Temperature(out val);
            if (retcode != TEMP_API.IMC_ERR_NO_ERROR)
            {
                MessageBox.Show("SUSI_IMC_TEMPERATURESENSOR_GetCPUCore1Temperature fail " + retcode.ToString("X4"));
                Updatetimer.Stop();
                return;
            }

            LiveData.Items[0].SubItems[1].Text = val.ToString() + "°C";

            retcode = TEMP_API.SUSI_IMC_TEMPERATURESENSOR_GetCPUCore2Temperature(out val);
            if (retcode != TEMP_API.IMC_ERR_NO_ERROR)
            {
                MessageBox.Show("SUSI_IMC_TEMPERATURESENSOR_GetCPUCore2Temperature fail " + retcode.ToString("X4"));
                Updatetimer.Stop();
                return;
            }

            LiveData.Items[1].SubItems[1].Text = val.ToString() + "°C";

            retcode = TEMP_API.SUSI_IMC_TEMPERATURESENSOR_GetSystem1Temperature(out val);
            if (retcode != TEMP_API.IMC_ERR_NO_ERROR)
            {
                MessageBox.Show("SUSI_IMC_TEMPERATURESENSOR_GetSystem1Temperature fail " + retcode.ToString("X4"));
                Updatetimer.Stop();
                return;
            }

            LiveData.Items[2].SubItems[1].Text = val.ToString() + "°C";
        }
    }
}
