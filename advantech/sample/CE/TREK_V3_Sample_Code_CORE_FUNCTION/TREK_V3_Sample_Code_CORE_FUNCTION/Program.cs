﻿using System;

using System.Collections.Generic;
using System.Windows.Forms;

namespace TREK_V3_Sample_Code_CORE_FUNCTION
{
    static class Program
    {
        /// <summary>
        /// 應用程式的主要進入點。
        /// </summary>
        [MTAThread]
        static void Main()
        {
            Application.Run(new Core_Function());
        }
    }
}