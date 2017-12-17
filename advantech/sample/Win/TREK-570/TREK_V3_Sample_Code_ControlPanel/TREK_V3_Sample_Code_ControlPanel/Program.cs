using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using IMCDemo.HotKey;

namespace TREK_V3_Sample_Code_ControlPanel
{
    static class Program
    {
        /// <summary>
        /// 應用程式的主要進入點。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new HotKeyForm());
        }
    }
}
