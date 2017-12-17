namespace TREK_V3_CanTestTool
{
    partial class VCIL
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置 Managed 資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改這個方法的內容。
        ///
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VCIL));
            this.ResetModuleBtn = new System.Windows.Forms.Button();
            this.StaticLibVersion = new System.Windows.Forms.Label();
            this.StaticLibVersionValue = new System.Windows.Forms.TextBox();
            this.StaticFWVersion = new System.Windows.Forms.Label();
            this.StaticFWVersionValue = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.RdBtnCANEvent = new System.Windows.Forms.RadioButton();
            this.RdBtnCANPolling = new System.Windows.Forms.RadioButton();
            this.ChkBxShowCANData = new System.Windows.Forms.CheckBox();
            this.BtnReadCANData = new System.Windows.Forms.Button();
            this.ListViewReadCANData = new System.Windows.Forms.ListView();
            this.StaticReadCANData = new System.Windows.Forms.Label();
            this.ReadCanDataTimer = new System.Windows.Forms.Timer(this.components);
            this.panel2 = new System.Windows.Forms.Panel();
            this.CmbxCANMaskNumber = new System.Windows.Forms.ComboBox();
            this.CleanAllCanMaskBtn = new System.Windows.Forms.Button();
            this.GetMaskBtn = new System.Windows.Forms.Button();
            this.CmbxMsgType = new System.Windows.Forms.ComboBox();
            this.StaticMsgType = new System.Windows.Forms.Label();
            this.StaticMsgMask = new System.Windows.Forms.Label();
            this.MaskConTxt = new System.Windows.Forms.TextBox();
            this.MaskIDTxt = new System.Windows.Forms.TextBox();
            this.StaticMask = new System.Windows.Forms.Label();
            this.StaticMsgID = new System.Windows.Forms.Label();
            this.StaticMaskID = new System.Windows.Forms.Label();
            this.RemoveMaskBtn = new System.Windows.Forms.Button();
            this.SetMaskBtn = new System.Windows.Forms.Button();
            this.SetCanBusSpeedBtn = new System.Windows.Forms.Button();
            this.CmbxCanBusSpeed = new System.Windows.Forms.ComboBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.CmbxWriteCANDataMessageType = new System.Windows.Forms.ComboBox();
            this.StaticWriteDataMessageType = new System.Windows.Forms.Label();
            this.WriteCANDataBtn = new System.Windows.Forms.Button();
            this.StaticWriteDataBufSize = new System.Windows.Forms.Label();
            this.StaticWriteDataBuf = new System.Windows.Forms.Label();
            this.StaticWriteDataMsgID = new System.Windows.Forms.Label();
            this.EditWriteDataBufSize = new System.Windows.Forms.TextBox();
            this.StaticCANWriteData = new System.Windows.Forms.Label();
            this.EditWriteDataBuf = new System.Windows.Forms.TextBox();
            this.EditWriteDataMsgID = new System.Windows.Forms.TextBox();
            this.StaticWriteDataChannelNumber = new System.Windows.Forms.Label();
            this.tabMain = new System.Windows.Forms.TabControl();
            this.tabVCILControl = new System.Windows.Forms.TabPage();
            this.panel7 = new System.Windows.Forms.Panel();
            this.cbBxModuleControlJ1708Channel = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cbBxModuleControlCANChannel02 = new System.Windows.Forms.ComboBox();
            this.cbBxModuleControlCANChannel01 = new System.Windows.Forms.ComboBox();
            this.StaticModuleControlChannel02 = new System.Windows.Forms.Label();
            this.StaticModuleControlChannel01 = new System.Windows.Forms.Label();
            this.StaticModuleControl = new System.Windows.Forms.Label();
            this.tabCan = new System.Windows.Forms.TabPage();
            this.CANErrorStatusValue = new System.Windows.Forms.Label();
            this.CANErrorStatus = new System.Windows.Forms.Label();
            this.btnGetCANErrorStatus = new System.Windows.Forms.Button();
            this.GetCanBusSpeedBtn = new System.Windows.Forms.Button();
            this.CANSilenceModeEnable = new System.Windows.Forms.CheckBox();
            this.tabJ1939 = new System.Windows.Forms.TabPage();
            this.panel14 = new System.Windows.Forms.Panel();
            this.EditJ1939TransmitConfigName = new System.Windows.Forms.TextBox();
            this.EditJ1939TransmitConfigAddress = new System.Windows.Forms.TextBox();
            this.BtnGetJ1939TransmitConfig = new System.Windows.Forms.Button();
            this.BtnSetJ1939TransmitConfig = new System.Windows.Forms.Button();
            this.StaticJ1939TransmitConfigName = new System.Windows.Forms.Label();
            this.StaticJ1939TransmitConfigAddress = new System.Windows.Forms.Label();
            this.StaticJ1939TransmitConfigChannel = new System.Windows.Forms.Label();
            this.StaticJ1939TransmitConfig = new System.Windows.Forms.Label();
            this.panel8 = new System.Windows.Forms.Panel();
            this.ListViewReadJ1939Data = new System.Windows.Forms.ListView();
            this.columnHeader9 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader10 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader11 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader12 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader13 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader14 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader15 = new System.Windows.Forms.ColumnHeader();
            this.RdBtnJ1939Event = new System.Windows.Forms.RadioButton();
            this.StaticJ1939ReadDataOff = new System.Windows.Forms.Label();
            this.StaticJ1939ReadDataOn = new System.Windows.Forms.Label();
            this.trBrJ1939Read = new System.Windows.Forms.TrackBar();
            this.RdBtnJ1939Polling = new System.Windows.Forms.RadioButton();
            this.ChkBxShowJ1939Data = new System.Windows.Forms.CheckBox();
            this.StaticReadJ1939Data = new System.Windows.Forms.Label();
            this.panel10 = new System.Windows.Forms.Panel();
            this.BtnGetJ1939Filter = new System.Windows.Forms.Button();
            this.ListBxJ1939Filter = new System.Windows.Forms.ListBox();
            this.BtnRemoveAllJ1939Filter = new System.Windows.Forms.Button();
            this.BtnRemoveJ1939Filter = new System.Windows.Forms.Button();
            this.EditJ1939FilterPGN = new System.Windows.Forms.TextBox();
            this.StaticJ1939MessageFilter = new System.Windows.Forms.Label();
            this.BtnSetJ1939Filter = new System.Windows.Forms.Button();
            this.panel9 = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label26 = new System.Windows.Forms.Label();
            this.tbRequestPGN = new System.Windows.Forms.TextBox();
            this.EditWriteJ1939PRI = new System.Windows.Forms.TextBox();
            this.StaticWriteJ1939DataPRI = new System.Windows.Forms.Label();
            this.EditWriteJ1939SRC = new System.Windows.Forms.TextBox();
            this.StaticWriteJ1939DataSRC = new System.Windows.Forms.Label();
            this.StaticWriteJ1939DataDST = new System.Windows.Forms.Label();
            this.EditWriteJ1939DST = new System.Windows.Forms.TextBox();
            this.StaticWriteJ1939DataPGN = new System.Windows.Forms.Label();
            this.EditWriteJ1939Buf = new System.Windows.Forms.TextBox();
            this.BtnWriteJ1939Data = new System.Windows.Forms.Button();
            this.StaticWriteJ1939DataBufSize = new System.Windows.Forms.Label();
            this.StaticWriteJ1939DataBuf = new System.Windows.Forms.Label();
            this.EditWriteJ1939BufSize = new System.Windows.Forms.TextBox();
            this.EditWriteJ1939PGN = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.tabOBD2 = new System.Windows.Forms.TabPage();
            this.panel17 = new System.Windows.Forms.Panel();
            this.BtnGetOBD2Filter = new System.Windows.Forms.Button();
            this.ListBxOBD2Filter = new System.Windows.Forms.ListBox();
            this.BtnRemoveAllOBD2Filter = new System.Windows.Forms.Button();
            this.BtnRemoveOBD2Filter = new System.Windows.Forms.Button();
            this.EditOBD2FilterPGN = new System.Windows.Forms.TextBox();
            this.StaticOBD2MessageFilter = new System.Windows.Forms.Label();
            this.BtnSetOBD2Filter = new System.Windows.Forms.Button();
            this.panel16 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbOBDTempService = new System.Windows.Forms.ComboBox();
            this.label24 = new System.Windows.Forms.Label();
            this.tbOBDTempPID = new System.Windows.Forms.TextBox();
            this.label25 = new System.Windows.Forms.Label();
            this.RDOBD29b = new System.Windows.Forms.RadioButton();
            this.RDOBD11b = new System.Windows.Forms.RadioButton();
            this.EditWriteOBD2ID = new System.Windows.Forms.TextBox();
            this.StaticWriteOBD2DataID = new System.Windows.Forms.Label();
            this.CmbxWriteOBD2DataTAT = new System.Windows.Forms.ComboBox();
            this.EditWriteOBD2PRI = new System.Windows.Forms.TextBox();
            this.StaticWriteOBD2DataPRI = new System.Windows.Forms.Label();
            this.StaticWriteOBD2DataTAT = new System.Windows.Forms.Label();
            this.EditWriteOBD2SRC = new System.Windows.Forms.TextBox();
            this.StaticWriteOBD2DataSRC = new System.Windows.Forms.Label();
            this.StaticWriteOBD2DataDST = new System.Windows.Forms.Label();
            this.EditWriteOBD2DST = new System.Windows.Forms.TextBox();
            this.EditWriteOBD2Buf = new System.Windows.Forms.TextBox();
            this.BtnWriteOBD2Data = new System.Windows.Forms.Button();
            this.StaticWriteOBD2DataBufSize = new System.Windows.Forms.Label();
            this.StaticWriteOBD2DataBuf = new System.Windows.Forms.Label();
            this.EditWriteOBD2BufSize = new System.Windows.Forms.TextBox();
            this.StaticOBD2WriteData = new System.Windows.Forms.Label();
            this.panel15 = new System.Windows.Forms.Panel();
            this.SetOBD2Bitrate = new System.Windows.Forms.Button();
            this.cbOBD2Bitrate = new System.Windows.Forms.ComboBox();
            this.ListViewReadOBD2Data = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader5 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader6 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader7 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader8 = new System.Windows.Forms.ColumnHeader();
            this.RdBtnOBD2Event = new System.Windows.Forms.RadioButton();
            this.StaticOBD2ReadDataOff = new System.Windows.Forms.Label();
            this.StaticOBD2ReadDataOn = new System.Windows.Forms.Label();
            this.trBrOBD2Read = new System.Windows.Forms.TrackBar();
            this.RdBtnOBD2Polling = new System.Windows.Forms.RadioButton();
            this.ChkBxShowOBD2Data = new System.Windows.Forms.CheckBox();
            this.StaticOBD2ReadData = new System.Windows.Forms.Label();
            this.tabJ1708 = new System.Windows.Forms.TabPage();
            this.panel6 = new System.Windows.Forms.Panel();
            this.StaticWriteJ1708DataPriority = new System.Windows.Forms.Label();
            this.EditWriteJ1708DataPriority = new System.Windows.Forms.TextBox();
            this.StaticWriteJ1708DataPID = new System.Windows.Forms.Label();
            this.EditWriteJ1708DataBuf = new System.Windows.Forms.TextBox();
            this.WriteJ1708DataBtn = new System.Windows.Forms.Button();
            this.StaticWriteJ1708DataBufSize = new System.Windows.Forms.Label();
            this.StaticWriteJ1708DataBuf = new System.Windows.Forms.Label();
            this.StaticWriteJ1708DataMID = new System.Windows.Forms.Label();
            this.EditWriteJ1708DataBufSize = new System.Windows.Forms.TextBox();
            this.EditWriteJ1708DataPID = new System.Windows.Forms.TextBox();
            this.EditWriteJ1708DataMID = new System.Windows.Forms.TextBox();
            this.StaticJ1708WriteData = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.ReadJ1708FilterBtn = new System.Windows.Forms.Button();
            this.RemoveAllJ1708FilterBtn = new System.Windows.Forms.Button();
            this.RemoveJ1708FilterBtn = new System.Windows.Forms.Button();
            this.EditJ1708FilterMid = new System.Windows.Forms.TextBox();
            this.StaticJ1708MessageFilter = new System.Windows.Forms.Label();
            this.SetJ1708FilterBtn = new System.Windows.Forms.Button();
            this.ListViewJ1708Filter = new System.Windows.Forms.ListBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.ShowJ1708DataChkBx = new System.Windows.Forms.CheckBox();
            this.J1708EventRdBtn = new System.Windows.Forms.RadioButton();
            this.J1708PollingRdBtn = new System.Windows.Forms.RadioButton();
            this.ReadJ1708DataBtn = new System.Windows.Forms.Button();
            this.ListViewReadJ1708Data = new System.Windows.Forms.ListView();
            this.StaticJ1708ReadData = new System.Windows.Forms.Label();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.panel13 = new System.Windows.Forms.Panel();
            this.ReadJ1587FilterBtn = new System.Windows.Forms.Button();
            this.RemoveAllJ1587FilterBtn = new System.Windows.Forms.Button();
            this.RemoveJ1587FilterBtn = new System.Windows.Forms.Button();
            this.EditJ1587FilterPid = new System.Windows.Forms.TextBox();
            this.StaticJ1587MessageFilter = new System.Windows.Forms.Label();
            this.SetJ1587FilterBtn = new System.Windows.Forms.Button();
            this.ListViewJ1587Filter = new System.Windows.Forms.ListBox();
            this.panel12 = new System.Windows.Forms.Panel();
            this.StaticWriteJ1587DataPriority = new System.Windows.Forms.Label();
            this.EditWriteJ1587DataPriority = new System.Windows.Forms.TextBox();
            this.StaticWriteJ1587DataPID = new System.Windows.Forms.Label();
            this.EditWriteJ1587DataBuf = new System.Windows.Forms.TextBox();
            this.WriteJ1587DataBtn = new System.Windows.Forms.Button();
            this.StaticWriteJ1587DataBufSize = new System.Windows.Forms.Label();
            this.StaticWriteJ1587DataBuf = new System.Windows.Forms.Label();
            this.StaticWriteJ1587DataMID = new System.Windows.Forms.Label();
            this.EditWriteJ1587DataBufSize = new System.Windows.Forms.TextBox();
            this.EditWriteJ1587DataPID = new System.Windows.Forms.TextBox();
            this.EditWriteJ1587DataMID = new System.Windows.Forms.TextBox();
            this.StaticJ1587WriteData = new System.Windows.Forms.Label();
            this.panel11 = new System.Windows.Forms.Panel();
            this.J1587EventRdBtn = new System.Windows.Forms.RadioButton();
            this.J1587PollingRdBtn = new System.Windows.Forms.RadioButton();
            this.ListViewReadJ1587Data = new System.Windows.Forms.ListView();
            this.StaticJ1587ReadDataOff = new System.Windows.Forms.Label();
            this.StaticJ1587ReadDataOn = new System.Windows.Forms.Label();
            this.trBrJ1587Read = new System.Windows.Forms.TrackBar();
            this.ShowJ1587DataChkBx = new System.Windows.Forms.CheckBox();
            this.StaticJ1587ReadData = new System.Windows.Forms.Label();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            this.listView1 = new System.Windows.Forms.ListView();
            this.label2 = new System.Windows.Forms.Label();
            this.ReadJ1708DataTimer = new System.Windows.Forms.Timer(this.components);
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.radioButton4 = new System.Windows.Forms.RadioButton();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.checkBox4 = new System.Windows.Forms.CheckBox();
            this.button2 = new System.Windows.Forms.Button();
            this.listView2 = new System.Windows.Forms.ListView();
            this.label4 = new System.Windows.Forms.Label();
            this.radioButton5 = new System.Windows.Forms.RadioButton();
            this.checkBox5 = new System.Windows.Forms.CheckBox();
            this.radioButton6 = new System.Windows.Forms.RadioButton();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.checkBox6 = new System.Windows.Forms.CheckBox();
            this.button3 = new System.Windows.Forms.Button();
            this.listView3 = new System.Windows.Forms.ListView();
            this.label6 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.button5 = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.textBox8 = new System.Windows.Forms.TextBox();
            this.textBox9 = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.radioButton7 = new System.Windows.Forms.RadioButton();
            this.radioButton8 = new System.Windows.Forms.RadioButton();
            this.checkBox7 = new System.Windows.Forms.CheckBox();
            this.button4 = new System.Windows.Forms.Button();
            this.listView4 = new System.Windows.Forms.ListView();
            this.label7 = new System.Windows.Forms.Label();
            this.ReadJ1939DataTimer = new System.Windows.Forms.Timer(this.components);
            this.radioButton9 = new System.Windows.Forms.RadioButton();
            this.checkBox8 = new System.Windows.Forms.CheckBox();
            this.radioButton10 = new System.Windows.Forms.RadioButton();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.checkBox9 = new System.Windows.Forms.CheckBox();
            this.button6 = new System.Windows.Forms.Button();
            this.listView5 = new System.Windows.Forms.ListView();
            this.label16 = new System.Windows.Forms.Label();
            this.ReadJ1587DataTimer = new System.Windows.Forms.Timer(this.components);
            this.label17 = new System.Windows.Forms.Label();
            this.textBox10 = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.textBox11 = new System.Windows.Forms.TextBox();
            this.button7 = new System.Windows.Forms.Button();
            this.label19 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.textBox12 = new System.Windows.Forms.TextBox();
            this.textBox13 = new System.Windows.Forms.TextBox();
            this.textBox14 = new System.Windows.Forms.TextBox();
            this.label23 = new System.Windows.Forms.Label();
            this.ReadOBD2DataTimer = new System.Windows.Forms.Timer(this.components);
            this.panel18 = new System.Windows.Forms.Panel();
            this.rbCANPort1 = new System.Windows.Forms.RadioButton();
            this.rbCANPort2 = new System.Windows.Forms.RadioButton();
            this.columnHeader16 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader17 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader18 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader19 = new System.Windows.Forms.ColumnHeader();
            this.rbJ1939Port2 = new System.Windows.Forms.RadioButton();
            this.rbJ1939Port1 = new System.Windows.Forms.RadioButton();
            this.label27 = new System.Windows.Forms.Label();
            this.label28 = new System.Windows.Forms.Label();
            this.rbOBD2Port2 = new System.Windows.Forms.RadioButton();
            this.rbOBD2Port1 = new System.Windows.Forms.RadioButton();
            this.label29 = new System.Windows.Forms.Label();
            this.columnHeader20 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader21 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader22 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader23 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader24 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader25 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader26 = new System.Windows.Forms.ColumnHeader();
            this.btCANMsgClear = new System.Windows.Forms.Button();
            this.btJ1939MsgClear = new System.Windows.Forms.Button();
            this.btOBD2MsgClear = new System.Windows.Forms.Button();
            this.btJ1708MsgClear = new System.Windows.Forms.Button();
            this.btJ1587MsgClear = new System.Windows.Forms.Button();
            this.columnHeader27 = new System.Windows.Forms.ColumnHeader();
            this.label30 = new System.Windows.Forms.Label();
            this.labelCANRecvCount = new System.Windows.Forms.Label();
            this.labelOBD2RecvCount = new System.Windows.Forms.Label();
            this.label32 = new System.Windows.Forms.Label();
            this.labelJ1939RecvCount = new System.Windows.Forms.Label();
            this.label33 = new System.Windows.Forms.Label();
            this.labelJ1708RecvCount = new System.Windows.Forms.Label();
            this.label35 = new System.Windows.Forms.Label();
            this.labelJ1587RecvCount = new System.Windows.Forms.Label();
            this.label37 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.tabMain.SuspendLayout();
            this.tabVCILControl.SuspendLayout();
            this.panel7.SuspendLayout();
            this.tabCan.SuspendLayout();
            this.tabJ1939.SuspendLayout();
            this.panel14.SuspendLayout();
            this.panel8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trBrJ1939Read)).BeginInit();
            this.panel10.SuspendLayout();
            this.panel9.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tabOBD2.SuspendLayout();
            this.panel17.SuspendLayout();
            this.panel16.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel15.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trBrOBD2Read)).BeginInit();
            this.tabJ1708.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel4.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.panel13.SuspendLayout();
            this.panel12.SuspendLayout();
            this.panel11.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trBrJ1587Read)).BeginInit();
            this.panel18.SuspendLayout();
            this.SuspendLayout();
            // 
            // ResetModuleBtn
            // 
            this.ResetModuleBtn.Location = new System.Drawing.Point(5, 69);
            this.ResetModuleBtn.Name = "ResetModuleBtn";
            this.ResetModuleBtn.Size = new System.Drawing.Size(123, 23);
            this.ResetModuleBtn.TabIndex = 5;
            this.ResetModuleBtn.Text = "Reset Moulde";
            this.ResetModuleBtn.Click += new System.EventHandler(this.ResetModuleBtn_Click);
            // 
            // StaticLibVersion
            // 
            this.StaticLibVersion.Location = new System.Drawing.Point(3, 11);
            this.StaticLibVersion.Name = "StaticLibVersion";
            this.StaticLibVersion.Size = new System.Drawing.Size(125, 23);
            this.StaticLibVersion.TabIndex = 1;
            this.StaticLibVersion.Text = "Library Version :";
            // 
            // StaticLibVersionValue
            // 
            this.StaticLibVersionValue.Location = new System.Drawing.Point(134, 11);
            this.StaticLibVersionValue.Name = "StaticLibVersionValue";
            this.StaticLibVersionValue.Size = new System.Drawing.Size(153, 22);
            this.StaticLibVersionValue.TabIndex = 22;
            // 
            // StaticFWVersion
            // 
            this.StaticFWVersion.Location = new System.Drawing.Point(3, 40);
            this.StaticFWVersion.Name = "StaticFWVersion";
            this.StaticFWVersion.Size = new System.Drawing.Size(125, 23);
            this.StaticFWVersion.TabIndex = 23;
            this.StaticFWVersion.Text = "Firmware Version :";
            // 
            // StaticFWVersionValue
            // 
            this.StaticFWVersionValue.Location = new System.Drawing.Point(134, 40);
            this.StaticFWVersionValue.Name = "StaticFWVersionValue";
            this.StaticFWVersionValue.Size = new System.Drawing.Size(153, 22);
            this.StaticFWVersionValue.TabIndex = 31;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.labelCANRecvCount);
            this.panel1.Controls.Add(this.label30);
            this.panel1.Controls.Add(this.btCANMsgClear);
            this.panel1.Controls.Add(this.RdBtnCANEvent);
            this.panel1.Controls.Add(this.RdBtnCANPolling);
            this.panel1.Controls.Add(this.ChkBxShowCANData);
            this.panel1.Controls.Add(this.BtnReadCANData);
            this.panel1.Controls.Add(this.ListViewReadCANData);
            this.panel1.Controls.Add(this.StaticReadCANData);
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(767, 212);
            this.panel1.TabIndex = 0;
            // 
            // RdBtnCANEvent
            // 
            this.RdBtnCANEvent.Checked = true;
            this.RdBtnCANEvent.Location = new System.Drawing.Point(273, 6);
            this.RdBtnCANEvent.Name = "RdBtnCANEvent";
            this.RdBtnCANEvent.Size = new System.Drawing.Size(89, 20);
            this.RdBtnCANEvent.TabIndex = 41;
            this.RdBtnCANEvent.TabStop = true;
            this.RdBtnCANEvent.Text = "Event Mode";
            this.RdBtnCANEvent.CheckedChanged += new System.EventHandler(this.PollingRdBtn_CheckedChanged);
            // 
            // RdBtnCANPolling
            // 
            this.RdBtnCANPolling.Location = new System.Drawing.Point(180, 6);
            this.RdBtnCANPolling.Name = "RdBtnCANPolling";
            this.RdBtnCANPolling.Size = new System.Drawing.Size(97, 20);
            this.RdBtnCANPolling.TabIndex = 40;
            this.RdBtnCANPolling.Text = "Polling Mode";
            this.RdBtnCANPolling.CheckedChanged += new System.EventHandler(this.PollingRdBtn_CheckedChanged);
            // 
            // ChkBxShowCANData
            // 
            this.ChkBxShowCANData.Checked = true;
            this.ChkBxShowCANData.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ChkBxShowCANData.Location = new System.Drawing.Point(368, 6);
            this.ChkBxShowCANData.Name = "ChkBxShowCANData";
            this.ChkBxShowCANData.Size = new System.Drawing.Size(86, 20);
            this.ChkBxShowCANData.TabIndex = 4;
            this.ChkBxShowCANData.Text = "Show Data";
            // 
            // BtnReadCANData
            // 
            this.BtnReadCANData.Location = new System.Drawing.Point(88, 6);
            this.BtnReadCANData.Name = "BtnReadCANData";
            this.BtnReadCANData.Size = new System.Drawing.Size(72, 20);
            this.BtnReadCANData.TabIndex = 2;
            this.BtnReadCANData.Text = "Start";
            this.BtnReadCANData.Click += new System.EventHandler(this.ReadDataBtn_Click);
            // 
            // ListViewReadCANData
            // 
            this.ListViewReadCANData.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader16,
            this.columnHeader17,
            this.columnHeader27,
            this.columnHeader18,
            this.columnHeader19});
            this.ListViewReadCANData.Location = new System.Drawing.Point(3, 32);
            this.ListViewReadCANData.Name = "ListViewReadCANData";
            this.ListViewReadCANData.Size = new System.Drawing.Size(759, 177);
            this.ListViewReadCANData.TabIndex = 1;
            this.ListViewReadCANData.UseCompatibleStateImageBehavior = false;
            this.ListViewReadCANData.View = System.Windows.Forms.View.Details;
            // 
            // StaticReadCANData
            // 
            this.StaticReadCANData.Location = new System.Drawing.Point(3, 6);
            this.StaticReadCANData.Name = "StaticReadCANData";
            this.StaticReadCANData.Size = new System.Drawing.Size(79, 20);
            this.StaticReadCANData.TabIndex = 42;
            this.StaticReadCANData.Text = "Read Data";
            // 
            // ReadCanDataTimer
            // 
            this.ReadCanDataTimer.Tick += new System.EventHandler(this.ReadCanDataTimer_Tick);
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.CmbxCANMaskNumber);
            this.panel2.Controls.Add(this.CleanAllCanMaskBtn);
            this.panel2.Controls.Add(this.GetMaskBtn);
            this.panel2.Controls.Add(this.CmbxMsgType);
            this.panel2.Controls.Add(this.StaticMsgType);
            this.panel2.Controls.Add(this.StaticMsgMask);
            this.panel2.Controls.Add(this.MaskConTxt);
            this.panel2.Controls.Add(this.MaskIDTxt);
            this.panel2.Controls.Add(this.StaticMask);
            this.panel2.Controls.Add(this.StaticMsgID);
            this.panel2.Controls.Add(this.StaticMaskID);
            this.panel2.Controls.Add(this.RemoveMaskBtn);
            this.panel2.Controls.Add(this.SetMaskBtn);
            this.panel2.Location = new System.Drawing.Point(440, 221);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(329, 156);
            this.panel2.TabIndex = 35;
            // 
            // CmbxCANMaskNumber
            // 
            this.CmbxCANMaskNumber.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbxCANMaskNumber.Location = new System.Drawing.Point(122, 56);
            this.CmbxCANMaskNumber.Name = "CmbxCANMaskNumber";
            this.CmbxCANMaskNumber.Size = new System.Drawing.Size(63, 20);
            this.CmbxCANMaskNumber.TabIndex = 53;
            // 
            // CleanAllCanMaskBtn
            // 
            this.CleanAllCanMaskBtn.Location = new System.Drawing.Point(219, 107);
            this.CleanAllCanMaskBtn.Name = "CleanAllCanMaskBtn";
            this.CleanAllCanMaskBtn.Size = new System.Drawing.Size(100, 23);
            this.CleanAllCanMaskBtn.TabIndex = 44;
            this.CleanAllCanMaskBtn.Text = "Clean all";
            this.CleanAllCanMaskBtn.Click += new System.EventHandler(this.CleanAllCanMaskBtn_Click);
            // 
            // GetMaskBtn
            // 
            this.GetMaskBtn.Location = new System.Drawing.Point(219, 49);
            this.GetMaskBtn.Name = "GetMaskBtn";
            this.GetMaskBtn.Size = new System.Drawing.Size(100, 23);
            this.GetMaskBtn.TabIndex = 36;
            this.GetMaskBtn.Text = "Get";
            this.GetMaskBtn.Click += new System.EventHandler(this.GetMaskBtn_Click);
            // 
            // CmbxMsgType
            // 
            this.CmbxMsgType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbxMsgType.Items.AddRange(new object[] {
            "STD",
            "EXT"});
            this.CmbxMsgType.Location = new System.Drawing.Point(122, 27);
            this.CmbxMsgType.Name = "CmbxMsgType";
            this.CmbxMsgType.Size = new System.Drawing.Size(63, 20);
            this.CmbxMsgType.TabIndex = 35;
            // 
            // StaticMsgType
            // 
            this.StaticMsgType.Location = new System.Drawing.Point(16, 30);
            this.StaticMsgType.Name = "StaticMsgType";
            this.StaticMsgType.Size = new System.Drawing.Size(83, 23);
            this.StaticMsgType.TabIndex = 62;
            this.StaticMsgType.Text = "Message Type :";
            // 
            // StaticMsgMask
            // 
            this.StaticMsgMask.Location = new System.Drawing.Point(3, 7);
            this.StaticMsgMask.Name = "StaticMsgMask";
            this.StaticMsgMask.Size = new System.Drawing.Size(113, 23);
            this.StaticMsgMask.TabIndex = 63;
            this.StaticMsgMask.Text = "Message Filter";
            // 
            // MaskConTxt
            // 
            this.MaskConTxt.Location = new System.Drawing.Point(122, 119);
            this.MaskConTxt.Name = "MaskConTxt";
            this.MaskConTxt.Size = new System.Drawing.Size(63, 22);
            this.MaskConTxt.TabIndex = 26;
            this.MaskConTxt.Text = "ffff";
            // 
            // MaskIDTxt
            // 
            this.MaskIDTxt.Location = new System.Drawing.Point(122, 88);
            this.MaskIDTxt.Name = "MaskIDTxt";
            this.MaskIDTxt.Size = new System.Drawing.Size(63, 22);
            this.MaskIDTxt.TabIndex = 25;
            this.MaskIDTxt.Text = "123";
            // 
            // StaticMask
            // 
            this.StaticMask.Location = new System.Drawing.Point(16, 119);
            this.StaticMask.Name = "StaticMask";
            this.StaticMask.Size = new System.Drawing.Size(83, 23);
            this.StaticMask.TabIndex = 64;
            this.StaticMask.Text = "Mask : (Hex)";
            // 
            // StaticMsgID
            // 
            this.StaticMsgID.Location = new System.Drawing.Point(16, 93);
            this.StaticMsgID.Name = "StaticMsgID";
            this.StaticMsgID.Size = new System.Drawing.Size(83, 23);
            this.StaticMsgID.TabIndex = 65;
            this.StaticMsgID.Text = "ID : (Hex)";
            // 
            // StaticMaskID
            // 
            this.StaticMaskID.Location = new System.Drawing.Point(16, 59);
            this.StaticMaskID.Name = "StaticMaskID";
            this.StaticMaskID.Size = new System.Drawing.Size(83, 20);
            this.StaticMaskID.TabIndex = 67;
            this.StaticMaskID.Text = "Mask ID :";
            // 
            // RemoveMaskBtn
            // 
            this.RemoveMaskBtn.Location = new System.Drawing.Point(219, 78);
            this.RemoveMaskBtn.Name = "RemoveMaskBtn";
            this.RemoveMaskBtn.Size = new System.Drawing.Size(100, 23);
            this.RemoveMaskBtn.TabIndex = 21;
            this.RemoveMaskBtn.Text = "Remove";
            this.RemoveMaskBtn.Click += new System.EventHandler(this.RemoveMaskBtn_Click);
            // 
            // SetMaskBtn
            // 
            this.SetMaskBtn.Location = new System.Drawing.Point(219, 20);
            this.SetMaskBtn.Name = "SetMaskBtn";
            this.SetMaskBtn.Size = new System.Drawing.Size(100, 23);
            this.SetMaskBtn.TabIndex = 20;
            this.SetMaskBtn.Text = "Set";
            this.SetMaskBtn.Click += new System.EventHandler(this.SetMaskBtn_Click);
            // 
            // SetCanBusSpeedBtn
            // 
            this.SetCanBusSpeedBtn.Location = new System.Drawing.Point(359, 380);
            this.SetCanBusSpeedBtn.Name = "SetCanBusSpeedBtn";
            this.SetCanBusSpeedBtn.Size = new System.Drawing.Size(71, 23);
            this.SetCanBusSpeedBtn.TabIndex = 34;
            this.SetCanBusSpeedBtn.Text = "Set";
            this.SetCanBusSpeedBtn.Click += new System.EventHandler(this.SetCanBusSpeedBtn_Click);
            // 
            // CmbxCanBusSpeed
            // 
            this.CmbxCanBusSpeed.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbxCanBusSpeed.Items.AddRange(new object[] {
            "125 K",
            "250 K",
            "500 K",
            "1     M",
            "200 K",
            "100 K"});
            this.CmbxCanBusSpeed.Location = new System.Drawing.Point(98, 382);
            this.CmbxCanBusSpeed.Name = "CmbxCanBusSpeed";
            this.CmbxCanBusSpeed.Size = new System.Drawing.Size(75, 20);
            this.CmbxCanBusSpeed.TabIndex = 35;
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.CmbxWriteCANDataMessageType);
            this.panel3.Controls.Add(this.StaticWriteDataMessageType);
            this.panel3.Controls.Add(this.WriteCANDataBtn);
            this.panel3.Controls.Add(this.StaticWriteDataBufSize);
            this.panel3.Controls.Add(this.StaticWriteDataBuf);
            this.panel3.Controls.Add(this.StaticWriteDataMsgID);
            this.panel3.Controls.Add(this.EditWriteDataBufSize);
            this.panel3.Controls.Add(this.StaticCANWriteData);
            this.panel3.Controls.Add(this.EditWriteDataBuf);
            this.panel3.Controls.Add(this.EditWriteDataMsgID);
            this.panel3.Location = new System.Drawing.Point(3, 221);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(431, 115);
            this.panel3.TabIndex = 1;
            // 
            // CmbxWriteCANDataMessageType
            // 
            this.CmbxWriteCANDataMessageType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbxWriteCANDataMessageType.Items.AddRange(new object[] {
            "STD",
            "EXT",
            "STD+RTR",
            "EXT+RTR"});
            this.CmbxWriteCANDataMessageType.Location = new System.Drawing.Point(111, 22);
            this.CmbxWriteCANDataMessageType.Name = "CmbxWriteCANDataMessageType";
            this.CmbxWriteCANDataMessageType.Size = new System.Drawing.Size(100, 20);
            this.CmbxWriteCANDataMessageType.TabIndex = 60;
            // 
            // StaticWriteDataMessageType
            // 
            this.StaticWriteDataMessageType.Location = new System.Drawing.Point(3, 26);
            this.StaticWriteDataMessageType.Name = "StaticWriteDataMessageType";
            this.StaticWriteDataMessageType.Size = new System.Drawing.Size(83, 23);
            this.StaticWriteDataMessageType.TabIndex = 61;
            this.StaticWriteDataMessageType.Text = "Message Type :";
            // 
            // WriteCANDataBtn
            // 
            this.WriteCANDataBtn.Location = new System.Drawing.Point(355, 80);
            this.WriteCANDataBtn.Name = "WriteCANDataBtn";
            this.WriteCANDataBtn.Size = new System.Drawing.Size(71, 23);
            this.WriteCANDataBtn.TabIndex = 41;
            this.WriteCANDataBtn.Text = "Write";
            this.WriteCANDataBtn.Click += new System.EventHandler(this.WriteDataBtn_Click);
            // 
            // StaticWriteDataBufSize
            // 
            this.StaticWriteDataBufSize.Location = new System.Drawing.Point(203, 54);
            this.StaticWriteDataBufSize.Name = "StaticWriteDataBufSize";
            this.StaticWriteDataBufSize.Size = new System.Drawing.Size(73, 23);
            this.StaticWriteDataBufSize.TabIndex = 63;
            this.StaticWriteDataBufSize.Text = "Buffer Size : ";
            // 
            // StaticWriteDataBuf
            // 
            this.StaticWriteDataBuf.Location = new System.Drawing.Point(3, 83);
            this.StaticWriteDataBuf.Name = "StaticWriteDataBuf";
            this.StaticWriteDataBuf.Size = new System.Drawing.Size(78, 23);
            this.StaticWriteDataBuf.TabIndex = 64;
            this.StaticWriteDataBuf.Text = "Buffer (Hex) :";
            // 
            // StaticWriteDataMsgID
            // 
            this.StaticWriteDataMsgID.Location = new System.Drawing.Point(3, 53);
            this.StaticWriteDataMsgID.Name = "StaticWriteDataMsgID";
            this.StaticWriteDataMsgID.Size = new System.Drawing.Size(96, 23);
            this.StaticWriteDataMsgID.TabIndex = 65;
            this.StaticWriteDataMsgID.Text = "Message ID (Hex) :";
            // 
            // EditWriteDataBufSize
            // 
            this.EditWriteDataBufSize.Location = new System.Drawing.Point(282, 51);
            this.EditWriteDataBufSize.Name = "EditWriteDataBufSize";
            this.EditWriteDataBufSize.Size = new System.Drawing.Size(20, 22);
            this.EditWriteDataBufSize.TabIndex = 34;
            this.EditWriteDataBufSize.Text = "8";
            // 
            // StaticCANWriteData
            // 
            this.StaticCANWriteData.Location = new System.Drawing.Point(3, 3);
            this.StaticCANWriteData.Name = "StaticCANWriteData";
            this.StaticCANWriteData.Size = new System.Drawing.Size(72, 23);
            this.StaticCANWriteData.TabIndex = 66;
            this.StaticCANWriteData.Text = "Write Data";
            // 
            // EditWriteDataBuf
            // 
            this.EditWriteDataBuf.Location = new System.Drawing.Point(111, 80);
            this.EditWriteDataBuf.Name = "EditWriteDataBuf";
            this.EditWriteDataBuf.Size = new System.Drawing.Size(151, 22);
            this.EditWriteDataBuf.TabIndex = 33;
            this.EditWriteDataBuf.Text = "FF86FFFFFFFFFFFF";
            this.EditWriteDataBuf.TextChanged += new System.EventHandler(this.EditWriteDataBuf_TextChanged);
            // 
            // EditWriteDataMsgID
            // 
            this.EditWriteDataMsgID.Location = new System.Drawing.Point(111, 50);
            this.EditWriteDataMsgID.Name = "EditWriteDataMsgID";
            this.EditWriteDataMsgID.Size = new System.Drawing.Size(72, 22);
            this.EditWriteDataMsgID.TabIndex = 32;
            this.EditWriteDataMsgID.Text = "18FEF600";
            // 
            // StaticWriteDataChannelNumber
            // 
            this.StaticWriteDataChannelNumber.Location = new System.Drawing.Point(538, 385);
            this.StaticWriteDataChannelNumber.Name = "StaticWriteDataChannelNumber";
            this.StaticWriteDataChannelNumber.Size = new System.Drawing.Size(101, 19);
            this.StaticWriteDataChannelNumber.TabIndex = 62;
            this.StaticWriteDataChannelNumber.Text = "Channel Number :";
            // 
            // tabMain
            // 
            this.tabMain.Controls.Add(this.tabVCILControl);
            this.tabMain.Controls.Add(this.tabCan);
            this.tabMain.Controls.Add(this.tabJ1939);
            this.tabMain.Controls.Add(this.tabOBD2);
            this.tabMain.Controls.Add(this.tabJ1708);
            this.tabMain.Controls.Add(this.tabPage1);
            this.tabMain.Location = new System.Drawing.Point(3, 3);
            this.tabMain.Name = "tabMain";
            this.tabMain.SelectedIndex = 0;
            this.tabMain.Size = new System.Drawing.Size(780, 434);
            this.tabMain.TabIndex = 40;
            // 
            // tabVCILControl
            // 
            this.tabVCILControl.Controls.Add(this.panel7);
            this.tabVCILControl.Controls.Add(this.StaticLibVersion);
            this.tabVCILControl.Controls.Add(this.StaticLibVersionValue);
            this.tabVCILControl.Controls.Add(this.StaticFWVersion);
            this.tabVCILControl.Controls.Add(this.StaticFWVersionValue);
            this.tabVCILControl.Controls.Add(this.ResetModuleBtn);
            this.tabVCILControl.Location = new System.Drawing.Point(4, 22);
            this.tabVCILControl.Name = "tabVCILControl";
            this.tabVCILControl.Size = new System.Drawing.Size(772, 408);
            this.tabVCILControl.TabIndex = 0;
            this.tabVCILControl.Text = "VCIL Control  ";
            this.tabVCILControl.UseVisualStyleBackColor = true;
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.cbBxModuleControlJ1708Channel);
            this.panel7.Controls.Add(this.label8);
            this.panel7.Controls.Add(this.cbBxModuleControlCANChannel02);
            this.panel7.Controls.Add(this.cbBxModuleControlCANChannel01);
            this.panel7.Controls.Add(this.StaticModuleControlChannel02);
            this.panel7.Controls.Add(this.StaticModuleControlChannel01);
            this.panel7.Controls.Add(this.StaticModuleControl);
            this.panel7.Location = new System.Drawing.Point(5, 98);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(282, 121);
            this.panel7.TabIndex = 0;
            // 
            // cbBxModuleControlJ1708Channel
            // 
            this.cbBxModuleControlJ1708Channel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbBxModuleControlJ1708Channel.Items.AddRange(new object[] {
            "J1708",
            "J1587"});
            this.cbBxModuleControlJ1708Channel.Location = new System.Drawing.Point(129, 83);
            this.cbBxModuleControlJ1708Channel.Name = "cbBxModuleControlJ1708Channel";
            this.cbBxModuleControlJ1708Channel.Size = new System.Drawing.Size(150, 20);
            this.cbBxModuleControlJ1708Channel.TabIndex = 104;
            this.cbBxModuleControlJ1708Channel.SelectedIndexChanged += new System.EventHandler(this.trBrModuleControl_ValueChanged);
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(3, 83);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(125, 23);
            this.label8.TabIndex = 105;
            this.label8.Text = "Channel 01";
            // 
            // cbBxModuleControlCANChannel02
            // 
            this.cbBxModuleControlCANChannel02.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbBxModuleControlCANChannel02.Items.AddRange(new object[] {
            "CAN",
            "CAN + Mask",
            "J1939",
            "J1939 + Filter",
            "OBD2",
            "OBD2 + Filter"});
            this.cbBxModuleControlCANChannel02.Location = new System.Drawing.Point(129, 54);
            this.cbBxModuleControlCANChannel02.Name = "cbBxModuleControlCANChannel02";
            this.cbBxModuleControlCANChannel02.Size = new System.Drawing.Size(150, 20);
            this.cbBxModuleControlCANChannel02.TabIndex = 83;
            this.cbBxModuleControlCANChannel02.SelectedIndexChanged += new System.EventHandler(this.trBrModuleControl_ValueChanged);
            // 
            // cbBxModuleControlCANChannel01
            // 
            this.cbBxModuleControlCANChannel01.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbBxModuleControlCANChannel01.Items.AddRange(new object[] {
            "CAN",
            "CAN + Mask",
            "J1939",
            "J1939+ Filter",
            "OBD2",
            "OBD2 + Filter"});
            this.cbBxModuleControlCANChannel01.Location = new System.Drawing.Point(129, 25);
            this.cbBxModuleControlCANChannel01.Name = "cbBxModuleControlCANChannel01";
            this.cbBxModuleControlCANChannel01.Size = new System.Drawing.Size(150, 20);
            this.cbBxModuleControlCANChannel01.TabIndex = 82;
            this.cbBxModuleControlCANChannel01.SelectedIndexChanged += new System.EventHandler(this.trBrModuleControl_ValueChanged);
            // 
            // StaticModuleControlChannel02
            // 
            this.StaticModuleControlChannel02.Location = new System.Drawing.Point(3, 54);
            this.StaticModuleControlChannel02.Name = "StaticModuleControlChannel02";
            this.StaticModuleControlChannel02.Size = new System.Drawing.Size(125, 23);
            this.StaticModuleControlChannel02.TabIndex = 106;
            this.StaticModuleControlChannel02.Text = "Channel 02";
            // 
            // StaticModuleControlChannel01
            // 
            this.StaticModuleControlChannel01.Location = new System.Drawing.Point(3, 25);
            this.StaticModuleControlChannel01.Name = "StaticModuleControlChannel01";
            this.StaticModuleControlChannel01.Size = new System.Drawing.Size(125, 23);
            this.StaticModuleControlChannel01.TabIndex = 107;
            this.StaticModuleControlChannel01.Text = "Channel 01";
            // 
            // StaticModuleControl
            // 
            this.StaticModuleControl.Location = new System.Drawing.Point(3, 2);
            this.StaticModuleControl.Name = "StaticModuleControl";
            this.StaticModuleControl.Size = new System.Drawing.Size(125, 23);
            this.StaticModuleControl.TabIndex = 108;
            this.StaticModuleControl.Text = "Module Control";
            // 
            // tabCan
            // 
            this.tabCan.Controls.Add(this.label27);
            this.tabCan.Controls.Add(this.rbCANPort2);
            this.tabCan.Controls.Add(this.rbCANPort1);
            this.tabCan.Controls.Add(this.panel18);
            this.tabCan.Controls.Add(this.panel1);
            this.tabCan.Controls.Add(this.CANSilenceModeEnable);
            this.tabCan.Controls.Add(this.panel3);
            this.tabCan.Controls.Add(this.GetCanBusSpeedBtn);
            this.tabCan.Controls.Add(this.StaticWriteDataChannelNumber);
            this.tabCan.Controls.Add(this.panel2);
            this.tabCan.Controls.Add(this.CmbxCanBusSpeed);
            this.tabCan.Controls.Add(this.SetCanBusSpeedBtn);
            this.tabCan.Location = new System.Drawing.Point(4, 22);
            this.tabCan.Name = "tabCan";
            this.tabCan.Size = new System.Drawing.Size(772, 408);
            this.tabCan.TabIndex = 1;
            this.tabCan.Text = "CAN";
            this.tabCan.UseVisualStyleBackColor = true;
            // 
            // CANErrorStatusValue
            // 
            this.CANErrorStatusValue.AutoSize = true;
            this.CANErrorStatusValue.Location = new System.Drawing.Point(109, 8);
            this.CANErrorStatusValue.Name = "CANErrorStatusValue";
            this.CANErrorStatusValue.Size = new System.Drawing.Size(9, 12);
            this.CANErrorStatusValue.TabIndex = 66;
            this.CANErrorStatusValue.Text = "-";
            // 
            // CANErrorStatus
            // 
            this.CANErrorStatus.AutoSize = true;
            this.CANErrorStatus.Location = new System.Drawing.Point(15, 9);
            this.CANErrorStatus.Name = "CANErrorStatus";
            this.CANErrorStatus.Size = new System.Drawing.Size(84, 12);
            this.CANErrorStatus.TabIndex = 65;
            this.CANErrorStatus.Text = "Bus Error Status:";
            // 
            // btnGetCANErrorStatus
            // 
            this.btnGetCANErrorStatus.Location = new System.Drawing.Point(355, 5);
            this.btnGetCANErrorStatus.Name = "btnGetCANErrorStatus";
            this.btnGetCANErrorStatus.Size = new System.Drawing.Size(71, 23);
            this.btnGetCANErrorStatus.TabIndex = 64;
            this.btnGetCANErrorStatus.Text = "Get";
            this.btnGetCANErrorStatus.UseVisualStyleBackColor = true;
            this.btnGetCANErrorStatus.Click += new System.EventHandler(this.btnGetCANErrorStatus_Click);
            // 
            // GetCanBusSpeedBtn
            // 
            this.GetCanBusSpeedBtn.Location = new System.Drawing.Point(290, 380);
            this.GetCanBusSpeedBtn.Name = "GetCanBusSpeedBtn";
            this.GetCanBusSpeedBtn.Size = new System.Drawing.Size(67, 23);
            this.GetCanBusSpeedBtn.TabIndex = 63;
            this.GetCanBusSpeedBtn.Text = "Get";
            this.GetCanBusSpeedBtn.Click += new System.EventHandler(this.GetCanBusSpeedBtn_Click);
            // 
            // CANSilenceModeEnable
            // 
            this.CANSilenceModeEnable.AutoSize = true;
            this.CANSilenceModeEnable.Location = new System.Drawing.Point(179, 384);
            this.CANSilenceModeEnable.Name = "CANSilenceModeEnable";
            this.CANSilenceModeEnable.Size = new System.Drawing.Size(87, 16);
            this.CANSilenceModeEnable.TabIndex = 36;
            this.CANSilenceModeEnable.Text = "Silence Mode";
            this.CANSilenceModeEnable.UseVisualStyleBackColor = true;
            // 
            // tabJ1939
            // 
            this.tabJ1939.Controls.Add(this.rbJ1939Port2);
            this.tabJ1939.Controls.Add(this.rbJ1939Port1);
            this.tabJ1939.Controls.Add(this.panel14);
            this.tabJ1939.Controls.Add(this.panel8);
            this.tabJ1939.Controls.Add(this.panel10);
            this.tabJ1939.Controls.Add(this.panel9);
            this.tabJ1939.Controls.Add(this.StaticJ1939TransmitConfigChannel);
            this.tabJ1939.Location = new System.Drawing.Point(4, 22);
            this.tabJ1939.Name = "tabJ1939";
            this.tabJ1939.Size = new System.Drawing.Size(772, 408);
            this.tabJ1939.TabIndex = 3;
            this.tabJ1939.Text = "J1939";
            this.tabJ1939.UseVisualStyleBackColor = true;
            // 
            // panel14
            // 
            this.panel14.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel14.Controls.Add(this.EditJ1939TransmitConfigName);
            this.panel14.Controls.Add(this.EditJ1939TransmitConfigAddress);
            this.panel14.Controls.Add(this.BtnGetJ1939TransmitConfig);
            this.panel14.Controls.Add(this.BtnSetJ1939TransmitConfig);
            this.panel14.Controls.Add(this.StaticJ1939TransmitConfigName);
            this.panel14.Controls.Add(this.StaticJ1939TransmitConfigAddress);
            this.panel14.Controls.Add(this.StaticJ1939TransmitConfig);
            this.panel14.Location = new System.Drawing.Point(373, 206);
            this.panel14.Name = "panel14";
            this.panel14.Size = new System.Drawing.Size(151, 169);
            this.panel14.TabIndex = 0;
            // 
            // EditJ1939TransmitConfigName
            // 
            this.EditJ1939TransmitConfigName.Location = new System.Drawing.Point(1, 81);
            this.EditJ1939TransmitConfigName.Name = "EditJ1939TransmitConfigName";
            this.EditJ1939TransmitConfigName.Size = new System.Drawing.Size(145, 22);
            this.EditJ1939TransmitConfigName.TabIndex = 79;
            // 
            // EditJ1939TransmitConfigAddress
            // 
            this.EditJ1939TransmitConfigAddress.Location = new System.Drawing.Point(66, 26);
            this.EditJ1939TransmitConfigAddress.Name = "EditJ1939TransmitConfigAddress";
            this.EditJ1939TransmitConfigAddress.Size = new System.Drawing.Size(51, 22);
            this.EditJ1939TransmitConfigAddress.TabIndex = 77;
            this.EditJ1939TransmitConfigAddress.Text = "254";
            // 
            // BtnGetJ1939TransmitConfig
            // 
            this.BtnGetJ1939TransmitConfig.Location = new System.Drawing.Point(3, 138);
            this.BtnGetJ1939TransmitConfig.Name = "BtnGetJ1939TransmitConfig";
            this.BtnGetJ1939TransmitConfig.Size = new System.Drawing.Size(145, 23);
            this.BtnGetJ1939TransmitConfig.TabIndex = 51;
            this.BtnGetJ1939TransmitConfig.Text = "Get Address/Name";
            this.BtnGetJ1939TransmitConfig.Click += new System.EventHandler(this.BtnGetJ1939TransmitConfig_Click);
            // 
            // BtnSetJ1939TransmitConfig
            // 
            this.BtnSetJ1939TransmitConfig.Location = new System.Drawing.Point(3, 109);
            this.BtnSetJ1939TransmitConfig.Name = "BtnSetJ1939TransmitConfig";
            this.BtnSetJ1939TransmitConfig.Size = new System.Drawing.Size(145, 23);
            this.BtnSetJ1939TransmitConfig.TabIndex = 50;
            this.BtnSetJ1939TransmitConfig.Text = "Set Address/Name";
            this.BtnSetJ1939TransmitConfig.Click += new System.EventHandler(this.BtnSetJ1939TransmitConfig_Click);
            // 
            // StaticJ1939TransmitConfigName
            // 
            this.StaticJ1939TransmitConfigName.Location = new System.Drawing.Point(5, 56);
            this.StaticJ1939TransmitConfigName.Name = "StaticJ1939TransmitConfigName";
            this.StaticJ1939TransmitConfigName.Size = new System.Drawing.Size(88, 23);
            this.StaticJ1939TransmitConfigName.TabIndex = 80;
            this.StaticJ1939TransmitConfigName.Text = "Name (Hex)";
            // 
            // StaticJ1939TransmitConfigAddress
            // 
            this.StaticJ1939TransmitConfigAddress.Location = new System.Drawing.Point(5, 29);
            this.StaticJ1939TransmitConfigAddress.Name = "StaticJ1939TransmitConfigAddress";
            this.StaticJ1939TransmitConfigAddress.Size = new System.Drawing.Size(46, 23);
            this.StaticJ1939TransmitConfigAddress.TabIndex = 81;
            this.StaticJ1939TransmitConfigAddress.Text = "Address";
            // 
            // StaticJ1939TransmitConfigChannel
            // 
            this.StaticJ1939TransmitConfigChannel.Location = new System.Drawing.Point(545, 385);
            this.StaticJ1939TransmitConfigChannel.Name = "StaticJ1939TransmitConfigChannel";
            this.StaticJ1939TransmitConfigChannel.Size = new System.Drawing.Size(106, 20);
            this.StaticJ1939TransmitConfigChannel.TabIndex = 82;
            this.StaticJ1939TransmitConfigChannel.Text = "Channel Number :";
            // 
            // StaticJ1939TransmitConfig
            // 
            this.StaticJ1939TransmitConfig.Location = new System.Drawing.Point(3, 4);
            this.StaticJ1939TransmitConfig.Name = "StaticJ1939TransmitConfig";
            this.StaticJ1939TransmitConfig.Size = new System.Drawing.Size(145, 19);
            this.StaticJ1939TransmitConfig.TabIndex = 83;
            this.StaticJ1939TransmitConfig.Text = "J1939 Address / Name";
            // 
            // panel8
            // 
            this.panel8.Controls.Add(this.labelJ1939RecvCount);
            this.panel8.Controls.Add(this.label33);
            this.panel8.Controls.Add(this.btJ1939MsgClear);
            this.panel8.Controls.Add(this.ListViewReadJ1939Data);
            this.panel8.Controls.Add(this.RdBtnJ1939Event);
            this.panel8.Controls.Add(this.StaticJ1939ReadDataOff);
            this.panel8.Controls.Add(this.StaticJ1939ReadDataOn);
            this.panel8.Controls.Add(this.trBrJ1939Read);
            this.panel8.Controls.Add(this.RdBtnJ1939Polling);
            this.panel8.Controls.Add(this.ChkBxShowJ1939Data);
            this.panel8.Controls.Add(this.StaticReadJ1939Data);
            this.panel8.Location = new System.Drawing.Point(0, 0);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(766, 200);
            this.panel8.TabIndex = 2;
            // 
            // ListViewReadJ1939Data
            // 
            this.ListViewReadJ1939Data.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader9,
            this.columnHeader10,
            this.columnHeader11,
            this.columnHeader12,
            this.columnHeader13,
            this.columnHeader14,
            this.columnHeader15});
            this.ListViewReadJ1939Data.Location = new System.Drawing.Point(3, 32);
            this.ListViewReadJ1939Data.Name = "ListViewReadJ1939Data";
            this.ListViewReadJ1939Data.Size = new System.Drawing.Size(763, 168);
            this.ListViewReadJ1939Data.TabIndex = 1;
            this.ListViewReadJ1939Data.UseCompatibleStateImageBehavior = false;
            this.ListViewReadJ1939Data.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "Port";
            this.columnHeader9.Width = 40;
            // 
            // columnHeader10
            // 
            this.columnHeader10.Text = "PRI";
            this.columnHeader10.Width = 30;
            // 
            // columnHeader11
            // 
            this.columnHeader11.Text = "PGN";
            // 
            // columnHeader12
            // 
            this.columnHeader12.Text = "DST";
            this.columnHeader12.Width = 40;
            // 
            // columnHeader13
            // 
            this.columnHeader13.Text = "SRC";
            this.columnHeader13.Width = 40;
            // 
            // columnHeader14
            // 
            this.columnHeader14.Text = "Length";
            this.columnHeader14.Width = 50;
            // 
            // columnHeader15
            // 
            this.columnHeader15.Text = "Data(Hex)";
            this.columnHeader15.Width = 255;
            // 
            // RdBtnJ1939Event
            // 
            this.RdBtnJ1939Event.Location = new System.Drawing.Point(348, 9);
            this.RdBtnJ1939Event.Name = "RdBtnJ1939Event";
            this.RdBtnJ1939Event.Size = new System.Drawing.Size(108, 20);
            this.RdBtnJ1939Event.TabIndex = 41;
            this.RdBtnJ1939Event.Text = "Event Mode";
            this.RdBtnJ1939Event.CheckedChanged += new System.EventHandler(this.RdBtnJ1939Polling_CheckedChanged);
            // 
            // StaticJ1939ReadDataOff
            // 
            this.StaticJ1939ReadDataOff.Location = new System.Drawing.Point(193, 6);
            this.StaticJ1939ReadDataOff.Name = "StaticJ1939ReadDataOff";
            this.StaticJ1939ReadDataOff.Size = new System.Drawing.Size(38, 23);
            this.StaticJ1939ReadDataOff.TabIndex = 0;
            this.StaticJ1939ReadDataOff.Text = "OFF";
            // 
            // StaticJ1939ReadDataOn
            // 
            this.StaticJ1939ReadDataOn.Location = new System.Drawing.Point(86, 6);
            this.StaticJ1939ReadDataOn.Name = "StaticJ1939ReadDataOn";
            this.StaticJ1939ReadDataOn.Size = new System.Drawing.Size(25, 23);
            this.StaticJ1939ReadDataOn.TabIndex = 1;
            this.StaticJ1939ReadDataOn.Text = "ON";
            // 
            // trBrJ1939Read
            // 
            this.trBrJ1939Read.Location = new System.Drawing.Point(117, 6);
            this.trBrJ1939Read.Maximum = 1;
            this.trBrJ1939Read.Name = "trBrJ1939Read";
            this.trBrJ1939Read.Size = new System.Drawing.Size(70, 45);
            this.trBrJ1939Read.TabIndex = 48;
            this.trBrJ1939Read.ValueChanged += new System.EventHandler(this.trBrJ1939Read_ValueChanged);
            // 
            // RdBtnJ1939Polling
            // 
            this.RdBtnJ1939Polling.Location = new System.Drawing.Point(234, 9);
            this.RdBtnJ1939Polling.Name = "RdBtnJ1939Polling";
            this.RdBtnJ1939Polling.Size = new System.Drawing.Size(108, 20);
            this.RdBtnJ1939Polling.TabIndex = 40;
            this.RdBtnJ1939Polling.Text = "Polling Mode";
            this.RdBtnJ1939Polling.CheckedChanged += new System.EventHandler(this.RdBtnJ1939Polling_CheckedChanged);
            // 
            // ChkBxShowJ1939Data
            // 
            this.ChkBxShowJ1939Data.Checked = true;
            this.ChkBxShowJ1939Data.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ChkBxShowJ1939Data.Location = new System.Drawing.Point(462, 9);
            this.ChkBxShowJ1939Data.Name = "ChkBxShowJ1939Data";
            this.ChkBxShowJ1939Data.Size = new System.Drawing.Size(96, 20);
            this.ChkBxShowJ1939Data.TabIndex = 4;
            this.ChkBxShowJ1939Data.Text = "Show Data";
            // 
            // StaticReadJ1939Data
            // 
            this.StaticReadJ1939Data.Location = new System.Drawing.Point(3, 6);
            this.StaticReadJ1939Data.Name = "StaticReadJ1939Data";
            this.StaticReadJ1939Data.Size = new System.Drawing.Size(79, 20);
            this.StaticReadJ1939Data.TabIndex = 49;
            this.StaticReadJ1939Data.Text = "Read Data";
            // 
            // panel10
            // 
            this.panel10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel10.Controls.Add(this.BtnGetJ1939Filter);
            this.panel10.Controls.Add(this.ListBxJ1939Filter);
            this.panel10.Controls.Add(this.BtnRemoveAllJ1939Filter);
            this.panel10.Controls.Add(this.BtnRemoveJ1939Filter);
            this.panel10.Controls.Add(this.EditJ1939FilterPGN);
            this.panel10.Controls.Add(this.StaticJ1939MessageFilter);
            this.panel10.Controls.Add(this.BtnSetJ1939Filter);
            this.panel10.Location = new System.Drawing.Point(527, 206);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(242, 169);
            this.panel10.TabIndex = 1;
            // 
            // BtnGetJ1939Filter
            // 
            this.BtnGetJ1939Filter.Location = new System.Drawing.Point(3, 119);
            this.BtnGetJ1939Filter.Name = "BtnGetJ1939Filter";
            this.BtnGetJ1939Filter.Size = new System.Drawing.Size(111, 23);
            this.BtnGetJ1939Filter.TabIndex = 75;
            this.BtnGetJ1939Filter.Text = "Get Filters";
            this.BtnGetJ1939Filter.Click += new System.EventHandler(this.BtnGetJ1939Filter_Click);
            // 
            // ListBxJ1939Filter
            // 
            this.ListBxJ1939Filter.ItemHeight = 12;
            this.ListBxJ1939Filter.Location = new System.Drawing.Point(126, 26);
            this.ListBxJ1939Filter.Name = "ListBxJ1939Filter";
            this.ListBxJ1939Filter.Size = new System.Drawing.Size(111, 136);
            this.ListBxJ1939Filter.TabIndex = 73;
            // 
            // BtnRemoveAllJ1939Filter
            // 
            this.BtnRemoveAllJ1939Filter.Location = new System.Drawing.Point(3, 90);
            this.BtnRemoveAllJ1939Filter.Name = "BtnRemoveAllJ1939Filter";
            this.BtnRemoveAllJ1939Filter.Size = new System.Drawing.Size(111, 23);
            this.BtnRemoveAllJ1939Filter.TabIndex = 49;
            this.BtnRemoveAllJ1939Filter.Text = "Remove All";
            this.BtnRemoveAllJ1939Filter.Click += new System.EventHandler(this.BtnRemoveAllJ1939Filter_Click);
            // 
            // BtnRemoveJ1939Filter
            // 
            this.BtnRemoveJ1939Filter.Location = new System.Drawing.Point(3, 61);
            this.BtnRemoveJ1939Filter.Name = "BtnRemoveJ1939Filter";
            this.BtnRemoveJ1939Filter.Size = new System.Drawing.Size(111, 23);
            this.BtnRemoveJ1939Filter.TabIndex = 48;
            this.BtnRemoveJ1939Filter.Text = "Remove select";
            this.BtnRemoveJ1939Filter.Click += new System.EventHandler(this.BtnRemoveJ1939Filter_Click);
            // 
            // EditJ1939FilterPGN
            // 
            this.EditJ1939FilterPGN.Location = new System.Drawing.Point(5, 35);
            this.EditJ1939FilterPGN.Name = "EditJ1939FilterPGN";
            this.EditJ1939FilterPGN.Size = new System.Drawing.Size(61, 22);
            this.EditJ1939FilterPGN.TabIndex = 44;
            // 
            // StaticJ1939MessageFilter
            // 
            this.StaticJ1939MessageFilter.Location = new System.Drawing.Point(3, 6);
            this.StaticJ1939MessageFilter.Name = "StaticJ1939MessageFilter";
            this.StaticJ1939MessageFilter.Size = new System.Drawing.Size(234, 20);
            this.StaticJ1939MessageFilter.TabIndex = 76;
            this.StaticJ1939MessageFilter.Text = "Message Filter (PGN - Hex)";
            // 
            // BtnSetJ1939Filter
            // 
            this.BtnSetJ1939Filter.Font = new System.Drawing.Font("Tahoma", 8F);
            this.BtnSetJ1939Filter.Location = new System.Drawing.Point(72, 33);
            this.BtnSetJ1939Filter.Name = "BtnSetJ1939Filter";
            this.BtnSetJ1939Filter.Size = new System.Drawing.Size(42, 23);
            this.BtnSetJ1939Filter.TabIndex = 44;
            this.BtnSetJ1939Filter.Text = "Add";
            this.BtnSetJ1939Filter.Click += new System.EventHandler(this.BtnSetJ1939Filter_Click);
            // 
            // panel9
            // 
            this.panel9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel9.Controls.Add(this.groupBox2);
            this.panel9.Controls.Add(this.EditWriteJ1939PRI);
            this.panel9.Controls.Add(this.StaticWriteJ1939DataPRI);
            this.panel9.Controls.Add(this.EditWriteJ1939SRC);
            this.panel9.Controls.Add(this.StaticWriteJ1939DataSRC);
            this.panel9.Controls.Add(this.StaticWriteJ1939DataDST);
            this.panel9.Controls.Add(this.EditWriteJ1939DST);
            this.panel9.Controls.Add(this.StaticWriteJ1939DataPGN);
            this.panel9.Controls.Add(this.EditWriteJ1939Buf);
            this.panel9.Controls.Add(this.BtnWriteJ1939Data);
            this.panel9.Controls.Add(this.StaticWriteJ1939DataBufSize);
            this.panel9.Controls.Add(this.StaticWriteJ1939DataBuf);
            this.panel9.Controls.Add(this.EditWriteJ1939BufSize);
            this.panel9.Controls.Add(this.EditWriteJ1939PGN);
            this.panel9.Controls.Add(this.label20);
            this.panel9.Location = new System.Drawing.Point(3, 206);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(368, 169);
            this.panel9.TabIndex = 3;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label26);
            this.groupBox2.Controls.Add(this.tbRequestPGN);
            this.groupBox2.Location = new System.Drawing.Point(5, 109);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(236, 46);
            this.groupBox2.TabIndex = 72;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Request PGN";
            // 
            // label26
            // 
            this.label26.Location = new System.Drawing.Point(13, 21);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(70, 23);
            this.label26.TabIndex = 69;
            this.label26.Text = "PGN (Hex) :";
            // 
            // tbRequestPGN
            // 
            this.tbRequestPGN.Location = new System.Drawing.Point(89, 18);
            this.tbRequestPGN.MaxLength = 5;
            this.tbRequestPGN.Name = "tbRequestPGN";
            this.tbRequestPGN.Size = new System.Drawing.Size(54, 22);
            this.tbRequestPGN.TabIndex = 68;
            this.tbRequestPGN.Text = "FEF6";
            this.tbRequestPGN.TextChanged += new System.EventHandler(this.textBox15_TextChanged);
            // 
            // EditWriteJ1939PRI
            // 
            this.EditWriteJ1939PRI.Location = new System.Drawing.Point(84, 29);
            this.EditWriteJ1939PRI.Name = "EditWriteJ1939PRI";
            this.EditWriteJ1939PRI.Size = new System.Drawing.Size(37, 22);
            this.EditWriteJ1939PRI.TabIndex = 63;
            this.EditWriteJ1939PRI.Text = "6";
            // 
            // StaticWriteJ1939DataPRI
            // 
            this.StaticWriteJ1939DataPRI.Location = new System.Drawing.Point(3, 32);
            this.StaticWriteJ1939DataPRI.Name = "StaticWriteJ1939DataPRI";
            this.StaticWriteJ1939DataPRI.Size = new System.Drawing.Size(62, 17);
            this.StaticWriteJ1939DataPRI.TabIndex = 64;
            this.StaticWriteJ1939DataPRI.Text = "PRI (Hex) :";
            // 
            // EditWriteJ1939SRC
            // 
            this.EditWriteJ1939SRC.Location = new System.Drawing.Point(315, 29);
            this.EditWriteJ1939SRC.Name = "EditWriteJ1939SRC";
            this.EditWriteJ1939SRC.Size = new System.Drawing.Size(37, 22);
            this.EditWriteJ1939SRC.TabIndex = 60;
            this.EditWriteJ1939SRC.Text = "0";
            // 
            // StaticWriteJ1939DataSRC
            // 
            this.StaticWriteJ1939DataSRC.Location = new System.Drawing.Point(247, 35);
            this.StaticWriteJ1939DataSRC.Name = "StaticWriteJ1939DataSRC";
            this.StaticWriteJ1939DataSRC.Size = new System.Drawing.Size(62, 19);
            this.StaticWriteJ1939DataSRC.TabIndex = 65;
            this.StaticWriteJ1939DataSRC.Text = "SRC (Hex) :";
            // 
            // StaticWriteJ1939DataDST
            // 
            this.StaticWriteJ1939DataDST.Location = new System.Drawing.Point(136, 35);
            this.StaticWriteJ1939DataDST.Name = "StaticWriteJ1939DataDST";
            this.StaticWriteJ1939DataDST.Size = new System.Drawing.Size(62, 18);
            this.StaticWriteJ1939DataDST.TabIndex = 66;
            this.StaticWriteJ1939DataDST.Text = "DST (Hex) :";
            // 
            // EditWriteJ1939DST
            // 
            this.EditWriteJ1939DST.Location = new System.Drawing.Point(204, 29);
            this.EditWriteJ1939DST.Name = "EditWriteJ1939DST";
            this.EditWriteJ1939DST.Size = new System.Drawing.Size(37, 22);
            this.EditWriteJ1939DST.TabIndex = 51;
            this.EditWriteJ1939DST.Text = "0";
            // 
            // StaticWriteJ1939DataPGN
            // 
            this.StaticWriteJ1939DataPGN.Location = new System.Drawing.Point(3, 59);
            this.StaticWriteJ1939DataPGN.Name = "StaticWriteJ1939DataPGN";
            this.StaticWriteJ1939DataPGN.Size = new System.Drawing.Size(74, 23);
            this.StaticWriteJ1939DataPGN.TabIndex = 67;
            this.StaticWriteJ1939DataPGN.Text = "PGN (Hex) :";
            // 
            // EditWriteJ1939Buf
            // 
            this.EditWriteJ1939Buf.Location = new System.Drawing.Point(84, 81);
            this.EditWriteJ1939Buf.Name = "EditWriteJ1939Buf";
            this.EditWriteJ1939Buf.Size = new System.Drawing.Size(268, 22);
            this.EditWriteJ1939Buf.TabIndex = 46;
            this.EditWriteJ1939Buf.Text = "FF86FFFFFFFFFFFF";
            this.EditWriteJ1939Buf.TextChanged += new System.EventHandler(this.EditWriteJ1939Buf_TextChanged);
            // 
            // BtnWriteJ1939Data
            // 
            this.BtnWriteJ1939Data.Location = new System.Drawing.Point(252, 133);
            this.BtnWriteJ1939Data.Name = "BtnWriteJ1939Data";
            this.BtnWriteJ1939Data.Size = new System.Drawing.Size(100, 20);
            this.BtnWriteJ1939Data.TabIndex = 41;
            this.BtnWriteJ1939Data.Text = "Write";
            this.BtnWriteJ1939Data.Click += new System.EventHandler(this.BtnWriteJ1939Data_Click);
            // 
            // StaticWriteJ1939DataBufSize
            // 
            this.StaticWriteJ1939DataBufSize.Location = new System.Drawing.Point(228, 59);
            this.StaticWriteJ1939DataBufSize.Name = "StaticWriteJ1939DataBufSize";
            this.StaticWriteJ1939DataBufSize.Size = new System.Drawing.Size(74, 18);
            this.StaticWriteJ1939DataBufSize.TabIndex = 68;
            this.StaticWriteJ1939DataBufSize.Text = "Buffer Size : ";
            // 
            // StaticWriteJ1939DataBuf
            // 
            this.StaticWriteJ1939DataBuf.Location = new System.Drawing.Point(4, 84);
            this.StaticWriteJ1939DataBuf.Name = "StaticWriteJ1939DataBuf";
            this.StaticWriteJ1939DataBuf.Size = new System.Drawing.Size(74, 23);
            this.StaticWriteJ1939DataBuf.TabIndex = 69;
            this.StaticWriteJ1939DataBuf.Text = "Buffer (Hex) :";
            // 
            // EditWriteJ1939BufSize
            // 
            this.EditWriteJ1939BufSize.Location = new System.Drawing.Point(314, 55);
            this.EditWriteJ1939BufSize.Name = "EditWriteJ1939BufSize";
            this.EditWriteJ1939BufSize.Size = new System.Drawing.Size(38, 22);
            this.EditWriteJ1939BufSize.TabIndex = 34;
            this.EditWriteJ1939BufSize.Text = "8";
            // 
            // EditWriteJ1939PGN
            // 
            this.EditWriteJ1939PGN.Location = new System.Drawing.Point(84, 56);
            this.EditWriteJ1939PGN.Name = "EditWriteJ1939PGN";
            this.EditWriteJ1939PGN.Size = new System.Drawing.Size(54, 22);
            this.EditWriteJ1939PGN.TabIndex = 33;
            this.EditWriteJ1939PGN.Text = "FEF6";
            // 
            // label20
            // 
            this.label20.Location = new System.Drawing.Point(3, 9);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(62, 20);
            this.label20.TabIndex = 71;
            this.label20.Text = "Write Data";
            // 
            // tabOBD2
            // 
            this.tabOBD2.Controls.Add(this.rbOBD2Port2);
            this.tabOBD2.Controls.Add(this.rbOBD2Port1);
            this.tabOBD2.Controls.Add(this.label29);
            this.tabOBD2.Controls.Add(this.label28);
            this.tabOBD2.Controls.Add(this.SetOBD2Bitrate);
            this.tabOBD2.Controls.Add(this.panel17);
            this.tabOBD2.Controls.Add(this.cbOBD2Bitrate);
            this.tabOBD2.Controls.Add(this.panel16);
            this.tabOBD2.Controls.Add(this.panel15);
            this.tabOBD2.Location = new System.Drawing.Point(4, 22);
            this.tabOBD2.Name = "tabOBD2";
            this.tabOBD2.Size = new System.Drawing.Size(772, 408);
            this.tabOBD2.TabIndex = 5;
            this.tabOBD2.Text = "OBD2";
            this.tabOBD2.UseVisualStyleBackColor = true;
            // 
            // panel17
            // 
            this.panel17.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel17.Controls.Add(this.BtnGetOBD2Filter);
            this.panel17.Controls.Add(this.ListBxOBD2Filter);
            this.panel17.Controls.Add(this.BtnRemoveAllOBD2Filter);
            this.panel17.Controls.Add(this.BtnRemoveOBD2Filter);
            this.panel17.Controls.Add(this.EditOBD2FilterPGN);
            this.panel17.Controls.Add(this.StaticOBD2MessageFilter);
            this.panel17.Controls.Add(this.BtnSetOBD2Filter);
            this.panel17.Location = new System.Drawing.Point(519, 209);
            this.panel17.Name = "panel17";
            this.panel17.Size = new System.Drawing.Size(245, 165);
            this.panel17.TabIndex = 0;
            // 
            // BtnGetOBD2Filter
            // 
            this.BtnGetOBD2Filter.Location = new System.Drawing.Point(3, 119);
            this.BtnGetOBD2Filter.Name = "BtnGetOBD2Filter";
            this.BtnGetOBD2Filter.Size = new System.Drawing.Size(111, 23);
            this.BtnGetOBD2Filter.TabIndex = 75;
            this.BtnGetOBD2Filter.Text = "Get Filters";
            this.BtnGetOBD2Filter.Click += new System.EventHandler(this.BtnGetOBD2Filter_Click);
            // 
            // ListBxOBD2Filter
            // 
            this.ListBxOBD2Filter.ItemHeight = 12;
            this.ListBxOBD2Filter.Location = new System.Drawing.Point(126, 25);
            this.ListBxOBD2Filter.Name = "ListBxOBD2Filter";
            this.ListBxOBD2Filter.Size = new System.Drawing.Size(111, 124);
            this.ListBxOBD2Filter.TabIndex = 73;
            // 
            // BtnRemoveAllOBD2Filter
            // 
            this.BtnRemoveAllOBD2Filter.Location = new System.Drawing.Point(3, 90);
            this.BtnRemoveAllOBD2Filter.Name = "BtnRemoveAllOBD2Filter";
            this.BtnRemoveAllOBD2Filter.Size = new System.Drawing.Size(111, 23);
            this.BtnRemoveAllOBD2Filter.TabIndex = 49;
            this.BtnRemoveAllOBD2Filter.Text = "Remove All";
            this.BtnRemoveAllOBD2Filter.Click += new System.EventHandler(this.BtnRemoveAllOBD2Filter_Click);
            // 
            // BtnRemoveOBD2Filter
            // 
            this.BtnRemoveOBD2Filter.Location = new System.Drawing.Point(3, 61);
            this.BtnRemoveOBD2Filter.Name = "BtnRemoveOBD2Filter";
            this.BtnRemoveOBD2Filter.Size = new System.Drawing.Size(111, 23);
            this.BtnRemoveOBD2Filter.TabIndex = 48;
            this.BtnRemoveOBD2Filter.Text = "Remove select";
            this.BtnRemoveOBD2Filter.Click += new System.EventHandler(this.BtnRemoveOBD2Filter_Click);
            // 
            // EditOBD2FilterPGN
            // 
            this.EditOBD2FilterPGN.Location = new System.Drawing.Point(5, 33);
            this.EditOBD2FilterPGN.Name = "EditOBD2FilterPGN";
            this.EditOBD2FilterPGN.Size = new System.Drawing.Size(53, 22);
            this.EditOBD2FilterPGN.TabIndex = 44;
            // 
            // StaticOBD2MessageFilter
            // 
            this.StaticOBD2MessageFilter.Location = new System.Drawing.Point(3, 6);
            this.StaticOBD2MessageFilter.Name = "StaticOBD2MessageFilter";
            this.StaticOBD2MessageFilter.Size = new System.Drawing.Size(234, 20);
            this.StaticOBD2MessageFilter.TabIndex = 76;
            this.StaticOBD2MessageFilter.Text = "Message Filter (PID - Hex)";
            // 
            // BtnSetOBD2Filter
            // 
            this.BtnSetOBD2Filter.Font = new System.Drawing.Font("Tahoma", 8F);
            this.BtnSetOBD2Filter.Location = new System.Drawing.Point(64, 32);
            this.BtnSetOBD2Filter.Name = "BtnSetOBD2Filter";
            this.BtnSetOBD2Filter.Size = new System.Drawing.Size(50, 23);
            this.BtnSetOBD2Filter.TabIndex = 44;
            this.BtnSetOBD2Filter.Text = "Add";
            this.BtnSetOBD2Filter.Click += new System.EventHandler(this.BtnSetOBD2Filter_Click);
            // 
            // panel16
            // 
            this.panel16.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel16.Controls.Add(this.groupBox1);
            this.panel16.Controls.Add(this.RDOBD29b);
            this.panel16.Controls.Add(this.RDOBD11b);
            this.panel16.Controls.Add(this.EditWriteOBD2ID);
            this.panel16.Controls.Add(this.StaticWriteOBD2DataID);
            this.panel16.Controls.Add(this.CmbxWriteOBD2DataTAT);
            this.panel16.Controls.Add(this.EditWriteOBD2PRI);
            this.panel16.Controls.Add(this.StaticWriteOBD2DataPRI);
            this.panel16.Controls.Add(this.StaticWriteOBD2DataTAT);
            this.panel16.Controls.Add(this.EditWriteOBD2SRC);
            this.panel16.Controls.Add(this.StaticWriteOBD2DataSRC);
            this.panel16.Controls.Add(this.StaticWriteOBD2DataDST);
            this.panel16.Controls.Add(this.EditWriteOBD2DST);
            this.panel16.Controls.Add(this.EditWriteOBD2Buf);
            this.panel16.Controls.Add(this.BtnWriteOBD2Data);
            this.panel16.Controls.Add(this.StaticWriteOBD2DataBufSize);
            this.panel16.Controls.Add(this.StaticWriteOBD2DataBuf);
            this.panel16.Controls.Add(this.EditWriteOBD2BufSize);
            this.panel16.Controls.Add(this.StaticOBD2WriteData);
            this.panel16.Location = new System.Drawing.Point(3, 209);
            this.panel16.Name = "panel16";
            this.panel16.Size = new System.Drawing.Size(510, 165);
            this.panel16.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbOBDTempService);
            this.groupBox1.Controls.Add(this.label24);
            this.groupBox1.Controls.Add(this.tbOBDTempPID);
            this.groupBox1.Controls.Add(this.label25);
            this.groupBox1.Location = new System.Drawing.Point(9, 108);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(239, 50);
            this.groupBox1.TabIndex = 88;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Request Data Template ";
            // 
            // cbOBDTempService
            // 
            this.cbOBDTempService.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbOBDTempService.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9"});
            this.cbOBDTempService.Location = new System.Drawing.Point(72, 18);
            this.cbOBDTempService.Name = "cbOBDTempService";
            this.cbOBDTempService.Size = new System.Drawing.Size(54, 20);
            this.cbOBDTempService.TabIndex = 88;
            this.cbOBDTempService.SelectedIndexChanged += new System.EventHandler(this.OBD2_TempValueChanged);
            // 
            // label24
            // 
            this.label24.Location = new System.Drawing.Point(18, 21);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(48, 19);
            this.label24.TabIndex = 85;
            this.label24.Text = "Service : ";
            // 
            // tbOBDTempPID
            // 
            this.tbOBDTempPID.Location = new System.Drawing.Point(191, 18);
            this.tbOBDTempPID.Name = "tbOBDTempPID";
            this.tbOBDTempPID.Size = new System.Drawing.Size(29, 22);
            this.tbOBDTempPID.TabIndex = 86;
            this.tbOBDTempPID.Text = "0";
            this.tbOBDTempPID.TextChanged += new System.EventHandler(this.OBD2_TempValueChanged);
            // 
            // label25
            // 
            this.label25.Location = new System.Drawing.Point(132, 21);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(60, 13);
            this.label25.TabIndex = 87;
            this.label25.Text = "PID(Hex) : ";
            // 
            // RDOBD29b
            // 
            this.RDOBD29b.AutoSize = true;
            this.RDOBD29b.Checked = true;
            this.RDOBD29b.Location = new System.Drawing.Point(267, 58);
            this.RDOBD29b.Name = "RDOBD29b";
            this.RDOBD29b.Size = new System.Drawing.Size(54, 16);
            this.RDOBD29b.TabIndex = 83;
            this.RDOBD29b.TabStop = true;
            this.RDOBD29b.Text = "29 bits";
            this.RDOBD29b.UseVisualStyleBackColor = true;
            // 
            // RDOBD11b
            // 
            this.RDOBD11b.AutoSize = true;
            this.RDOBD11b.Location = new System.Drawing.Point(196, 58);
            this.RDOBD11b.Name = "RDOBD11b";
            this.RDOBD11b.Size = new System.Drawing.Size(54, 16);
            this.RDOBD11b.TabIndex = 82;
            this.RDOBD11b.TabStop = true;
            this.RDOBD11b.Text = "11 bits";
            this.RDOBD11b.UseVisualStyleBackColor = true;
            this.RDOBD11b.CheckedChanged += new System.EventHandler(this.RDOBD11b_CheckedChanged);
            // 
            // EditWriteOBD2ID
            // 
            this.EditWriteOBD2ID.Location = new System.Drawing.Point(83, 52);
            this.EditWriteOBD2ID.Name = "EditWriteOBD2ID";
            this.EditWriteOBD2ID.Size = new System.Drawing.Size(100, 22);
            this.EditWriteOBD2ID.TabIndex = 80;
            this.EditWriteOBD2ID.Text = "18DB33F1";
            // 
            // StaticWriteOBD2DataID
            // 
            this.StaticWriteOBD2DataID.Location = new System.Drawing.Point(9, 54);
            this.StaticWriteOBD2DataID.Name = "StaticWriteOBD2DataID";
            this.StaticWriteOBD2DataID.Size = new System.Drawing.Size(79, 23);
            this.StaticWriteOBD2DataID.TabIndex = 81;
            this.StaticWriteOBD2DataID.Text = "ID (Hex) :";
            // 
            // CmbxWriteOBD2DataTAT
            // 
            this.CmbxWriteOBD2DataTAT.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbxWriteOBD2DataTAT.Items.AddRange(new object[] {
            "Functional",
            "Physical"});
            this.CmbxWriteOBD2DataTAT.Location = new System.Drawing.Point(186, 22);
            this.CmbxWriteOBD2DataTAT.Name = "CmbxWriteOBD2DataTAT";
            this.CmbxWriteOBD2DataTAT.Size = new System.Drawing.Size(73, 20);
            this.CmbxWriteOBD2DataTAT.TabIndex = 71;
            this.CmbxWriteOBD2DataTAT.SelectedIndexChanged += new System.EventHandler(this.OBD2_FieldChanged);
            // 
            // EditWriteOBD2PRI
            // 
            this.EditWriteOBD2PRI.Location = new System.Drawing.Point(83, 24);
            this.EditWriteOBD2PRI.Name = "EditWriteOBD2PRI";
            this.EditWriteOBD2PRI.Size = new System.Drawing.Size(26, 22);
            this.EditWriteOBD2PRI.TabIndex = 63;
            this.EditWriteOBD2PRI.Text = "6";
            this.EditWriteOBD2PRI.TextChanged += new System.EventHandler(this.OBD2_FieldChanged);
            // 
            // StaticWriteOBD2DataPRI
            // 
            this.StaticWriteOBD2DataPRI.Location = new System.Drawing.Point(7, 24);
            this.StaticWriteOBD2DataPRI.Name = "StaticWriteOBD2DataPRI";
            this.StaticWriteOBD2DataPRI.Size = new System.Drawing.Size(74, 20);
            this.StaticWriteOBD2DataPRI.TabIndex = 72;
            this.StaticWriteOBD2DataPRI.Text = "PRI (Hex) :";
            // 
            // StaticWriteOBD2DataTAT
            // 
            this.StaticWriteOBD2DataTAT.Location = new System.Drawing.Point(118, 25);
            this.StaticWriteOBD2DataTAT.Name = "StaticWriteOBD2DataTAT";
            this.StaticWriteOBD2DataTAT.Size = new System.Drawing.Size(72, 20);
            this.StaticWriteOBD2DataTAT.TabIndex = 73;
            this.StaticWriteOBD2DataTAT.Text = "TAT (Hex) :";
            // 
            // EditWriteOBD2SRC
            // 
            this.EditWriteOBD2SRC.Location = new System.Drawing.Point(442, 22);
            this.EditWriteOBD2SRC.Name = "EditWriteOBD2SRC";
            this.EditWriteOBD2SRC.Size = new System.Drawing.Size(28, 22);
            this.EditWriteOBD2SRC.TabIndex = 60;
            this.EditWriteOBD2SRC.Text = "F1";
            this.EditWriteOBD2SRC.TextChanged += new System.EventHandler(this.OBD2_FieldChanged);
            // 
            // StaticWriteOBD2DataSRC
            // 
            this.StaticWriteOBD2DataSRC.Location = new System.Drawing.Point(378, 25);
            this.StaticWriteOBD2DataSRC.Name = "StaticWriteOBD2DataSRC";
            this.StaticWriteOBD2DataSRC.Size = new System.Drawing.Size(72, 20);
            this.StaticWriteOBD2DataSRC.TabIndex = 74;
            this.StaticWriteOBD2DataSRC.Text = "SRC (Hex) :";
            // 
            // StaticWriteOBD2DataDST
            // 
            this.StaticWriteOBD2DataDST.Location = new System.Drawing.Point(265, 25);
            this.StaticWriteOBD2DataDST.Name = "StaticWriteOBD2DataDST";
            this.StaticWriteOBD2DataDST.Size = new System.Drawing.Size(63, 20);
            this.StaticWriteOBD2DataDST.TabIndex = 75;
            this.StaticWriteOBD2DataDST.Text = "DST (Hex) :";
            // 
            // EditWriteOBD2DST
            // 
            this.EditWriteOBD2DST.Location = new System.Drawing.Point(334, 22);
            this.EditWriteOBD2DST.Name = "EditWriteOBD2DST";
            this.EditWriteOBD2DST.Size = new System.Drawing.Size(29, 22);
            this.EditWriteOBD2DST.TabIndex = 51;
            this.EditWriteOBD2DST.Text = "33";
            this.EditWriteOBD2DST.TextChanged += new System.EventHandler(this.OBD2_FieldChanged);
            // 
            // EditWriteOBD2Buf
            // 
            this.EditWriteOBD2Buf.Location = new System.Drawing.Point(196, 80);
            this.EditWriteOBD2Buf.Name = "EditWriteOBD2Buf";
            this.EditWriteOBD2Buf.Size = new System.Drawing.Size(203, 22);
            this.EditWriteOBD2Buf.TabIndex = 46;
            this.EditWriteOBD2Buf.Text = "0100";
            this.EditWriteOBD2Buf.TextChanged += new System.EventHandler(this.EditWriteOBD2Buf_TextChanged);
            // 
            // BtnWriteOBD2Data
            // 
            this.BtnWriteOBD2Data.Location = new System.Drawing.Point(434, 138);
            this.BtnWriteOBD2Data.Name = "BtnWriteOBD2Data";
            this.BtnWriteOBD2Data.Size = new System.Drawing.Size(71, 20);
            this.BtnWriteOBD2Data.TabIndex = 41;
            this.BtnWriteOBD2Data.Text = "Write";
            this.BtnWriteOBD2Data.Click += new System.EventHandler(this.BtnWriteOBD2Data_Click);
            // 
            // StaticWriteOBD2DataBufSize
            // 
            this.StaticWriteOBD2DataBufSize.Location = new System.Drawing.Point(9, 83);
            this.StaticWriteOBD2DataBufSize.Name = "StaticWriteOBD2DataBufSize";
            this.StaticWriteOBD2DataBufSize.Size = new System.Drawing.Size(68, 23);
            this.StaticWriteOBD2DataBufSize.TabIndex = 76;
            this.StaticWriteOBD2DataBufSize.Text = "Buffer Size : ";
            // 
            // StaticWriteOBD2DataBuf
            // 
            this.StaticWriteOBD2DataBuf.Location = new System.Drawing.Point(118, 83);
            this.StaticWriteOBD2DataBuf.Name = "StaticWriteOBD2DataBuf";
            this.StaticWriteOBD2DataBuf.Size = new System.Drawing.Size(79, 23);
            this.StaticWriteOBD2DataBuf.TabIndex = 77;
            this.StaticWriteOBD2DataBuf.Text = "Buffer (Hex) :";
            // 
            // EditWriteOBD2BufSize
            // 
            this.EditWriteOBD2BufSize.Location = new System.Drawing.Point(83, 80);
            this.EditWriteOBD2BufSize.Name = "EditWriteOBD2BufSize";
            this.EditWriteOBD2BufSize.Size = new System.Drawing.Size(29, 22);
            this.EditWriteOBD2BufSize.TabIndex = 34;
            this.EditWriteOBD2BufSize.Text = "2";
            // 
            // StaticOBD2WriteData
            // 
            this.StaticOBD2WriteData.Location = new System.Drawing.Point(3, 4);
            this.StaticOBD2WriteData.Name = "StaticOBD2WriteData";
            this.StaticOBD2WriteData.Size = new System.Drawing.Size(113, 20);
            this.StaticOBD2WriteData.TabIndex = 79;
            this.StaticOBD2WriteData.Text = "Write Data";
            // 
            // panel15
            // 
            this.panel15.Controls.Add(this.labelOBD2RecvCount);
            this.panel15.Controls.Add(this.label32);
            this.panel15.Controls.Add(this.btOBD2MsgClear);
            this.panel15.Controls.Add(this.ListViewReadOBD2Data);
            this.panel15.Controls.Add(this.RdBtnOBD2Event);
            this.panel15.Controls.Add(this.StaticOBD2ReadDataOff);
            this.panel15.Controls.Add(this.StaticOBD2ReadDataOn);
            this.panel15.Controls.Add(this.trBrOBD2Read);
            this.panel15.Controls.Add(this.RdBtnOBD2Polling);
            this.panel15.Controls.Add(this.ChkBxShowOBD2Data);
            this.panel15.Controls.Add(this.StaticOBD2ReadData);
            this.panel15.Location = new System.Drawing.Point(3, 0);
            this.panel15.Name = "panel15";
            this.panel15.Size = new System.Drawing.Size(766, 203);
            this.panel15.TabIndex = 2;
            // 
            // SetOBD2Bitrate
            // 
            this.SetOBD2Bitrate.Location = new System.Drawing.Point(200, 379);
            this.SetOBD2Bitrate.Name = "SetOBD2Bitrate";
            this.SetOBD2Bitrate.Size = new System.Drawing.Size(47, 23);
            this.SetOBD2Bitrate.TabIndex = 50;
            this.SetOBD2Bitrate.Text = "Set";
            this.SetOBD2Bitrate.Click += new System.EventHandler(this.OBD2Bitrate_Click);
            // 
            // cbOBD2Bitrate
            // 
            this.cbOBD2Bitrate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbOBD2Bitrate.Items.AddRange(new object[] {
            "125 K",
            "250 K",
            "500 K"});
            this.cbOBD2Bitrate.Location = new System.Drawing.Point(76, 380);
            this.cbOBD2Bitrate.Name = "cbOBD2Bitrate";
            this.cbOBD2Bitrate.Size = new System.Drawing.Size(93, 20);
            this.cbOBD2Bitrate.TabIndex = 51;
            // 
            // ListViewReadOBD2Data
            // 
            this.ListViewReadOBD2Data.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6,
            this.columnHeader7,
            this.columnHeader8});
            this.ListViewReadOBD2Data.Location = new System.Drawing.Point(3, 30);
            this.ListViewReadOBD2Data.Name = "ListViewReadOBD2Data";
            this.ListViewReadOBD2Data.Size = new System.Drawing.Size(758, 163);
            this.ListViewReadOBD2Data.TabIndex = 1;
            this.ListViewReadOBD2Data.UseCompatibleStateImageBehavior = false;
            this.ListViewReadOBD2Data.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Port";
            this.columnHeader1.Width = 40;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Type";
            this.columnHeader2.Width = 40;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "ID(Hex)";
            this.columnHeader3.Width = 70;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "DST";
            this.columnHeader4.Width = 40;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "SRC";
            this.columnHeader5.Width = 40;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Length";
            this.columnHeader6.Width = 50;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Data(HEX)";
            this.columnHeader7.Width = 120;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "Description";
            this.columnHeader8.Width = 280;
            // 
            // RdBtnOBD2Event
            // 
            this.RdBtnOBD2Event.Checked = true;
            this.RdBtnOBD2Event.Location = new System.Drawing.Point(335, 3);
            this.RdBtnOBD2Event.Name = "RdBtnOBD2Event";
            this.RdBtnOBD2Event.Size = new System.Drawing.Size(86, 20);
            this.RdBtnOBD2Event.TabIndex = 41;
            this.RdBtnOBD2Event.TabStop = true;
            this.RdBtnOBD2Event.Text = "Event Mode";
            // 
            // StaticOBD2ReadDataOff
            // 
            this.StaticOBD2ReadDataOff.Location = new System.Drawing.Point(193, 6);
            this.StaticOBD2ReadDataOff.Name = "StaticOBD2ReadDataOff";
            this.StaticOBD2ReadDataOff.Size = new System.Drawing.Size(38, 23);
            this.StaticOBD2ReadDataOff.TabIndex = 0;
            this.StaticOBD2ReadDataOff.Text = "OFF";
            // 
            // StaticOBD2ReadDataOn
            // 
            this.StaticOBD2ReadDataOn.Location = new System.Drawing.Point(86, 6);
            this.StaticOBD2ReadDataOn.Name = "StaticOBD2ReadDataOn";
            this.StaticOBD2ReadDataOn.Size = new System.Drawing.Size(25, 23);
            this.StaticOBD2ReadDataOn.TabIndex = 1;
            this.StaticOBD2ReadDataOn.Text = "ON";
            // 
            // trBrOBD2Read
            // 
            this.trBrOBD2Read.Location = new System.Drawing.Point(117, 6);
            this.trBrOBD2Read.Maximum = 1;
            this.trBrOBD2Read.Name = "trBrOBD2Read";
            this.trBrOBD2Read.Size = new System.Drawing.Size(70, 45);
            this.trBrOBD2Read.TabIndex = 48;
            this.trBrOBD2Read.ValueChanged += new System.EventHandler(this.trBrOBD2Read_ValueChanged);
            // 
            // RdBtnOBD2Polling
            // 
            this.RdBtnOBD2Polling.Location = new System.Drawing.Point(237, 4);
            this.RdBtnOBD2Polling.Name = "RdBtnOBD2Polling";
            this.RdBtnOBD2Polling.Size = new System.Drawing.Size(92, 20);
            this.RdBtnOBD2Polling.TabIndex = 40;
            this.RdBtnOBD2Polling.Text = "Polling Mode";
            // 
            // ChkBxShowOBD2Data
            // 
            this.ChkBxShowOBD2Data.Checked = true;
            this.ChkBxShowOBD2Data.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ChkBxShowOBD2Data.Location = new System.Drawing.Point(441, 7);
            this.ChkBxShowOBD2Data.Name = "ChkBxShowOBD2Data";
            this.ChkBxShowOBD2Data.Size = new System.Drawing.Size(96, 20);
            this.ChkBxShowOBD2Data.TabIndex = 4;
            this.ChkBxShowOBD2Data.Text = "Show Data";
            // 
            // StaticOBD2ReadData
            // 
            this.StaticOBD2ReadData.Location = new System.Drawing.Point(3, 6);
            this.StaticOBD2ReadData.Name = "StaticOBD2ReadData";
            this.StaticOBD2ReadData.Size = new System.Drawing.Size(79, 20);
            this.StaticOBD2ReadData.TabIndex = 49;
            this.StaticOBD2ReadData.Text = "Read Data";
            // 
            // tabJ1708
            // 
            this.tabJ1708.Controls.Add(this.panel6);
            this.tabJ1708.Controls.Add(this.panel5);
            this.tabJ1708.Controls.Add(this.panel4);
            this.tabJ1708.Location = new System.Drawing.Point(4, 22);
            this.tabJ1708.Name = "tabJ1708";
            this.tabJ1708.Size = new System.Drawing.Size(772, 408);
            this.tabJ1708.TabIndex = 2;
            this.tabJ1708.Text = "J1708";
            this.tabJ1708.UseVisualStyleBackColor = true;
            // 
            // panel6
            // 
            this.panel6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel6.Controls.Add(this.StaticWriteJ1708DataPriority);
            this.panel6.Controls.Add(this.EditWriteJ1708DataPriority);
            this.panel6.Controls.Add(this.StaticWriteJ1708DataPID);
            this.panel6.Controls.Add(this.EditWriteJ1708DataBuf);
            this.panel6.Controls.Add(this.WriteJ1708DataBtn);
            this.panel6.Controls.Add(this.StaticWriteJ1708DataBufSize);
            this.panel6.Controls.Add(this.StaticWriteJ1708DataBuf);
            this.panel6.Controls.Add(this.StaticWriteJ1708DataMID);
            this.panel6.Controls.Add(this.EditWriteJ1708DataBufSize);
            this.panel6.Controls.Add(this.EditWriteJ1708DataPID);
            this.panel6.Controls.Add(this.EditWriteJ1708DataMID);
            this.panel6.Controls.Add(this.StaticJ1708WriteData);
            this.panel6.Location = new System.Drawing.Point(3, 225);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(460, 180);
            this.panel6.TabIndex = 0;
            // 
            // StaticWriteJ1708DataPriority
            // 
            this.StaticWriteJ1708DataPriority.Location = new System.Drawing.Point(156, 25);
            this.StaticWriteJ1708DataPriority.Name = "StaticWriteJ1708DataPriority";
            this.StaticWriteJ1708DataPriority.Size = new System.Drawing.Size(81, 23);
            this.StaticWriteJ1708DataPriority.TabIndex = 0;
            this.StaticWriteJ1708DataPriority.Text = "Priority (Hex) :";
            // 
            // EditWriteJ1708DataPriority
            // 
            this.EditWriteJ1708DataPriority.Location = new System.Drawing.Point(243, 22);
            this.EditWriteJ1708DataPriority.Name = "EditWriteJ1708DataPriority";
            this.EditWriteJ1708DataPriority.Size = new System.Drawing.Size(33, 22);
            this.EditWriteJ1708DataPriority.TabIndex = 51;
            this.EditWriteJ1708DataPriority.Text = "1";
            // 
            // StaticWriteJ1708DataPID
            // 
            this.StaticWriteJ1708DataPID.Location = new System.Drawing.Point(3, 59);
            this.StaticWriteJ1708DataPID.Name = "StaticWriteJ1708DataPID";
            this.StaticWriteJ1708DataPID.Size = new System.Drawing.Size(78, 23);
            this.StaticWriteJ1708DataPID.TabIndex = 52;
            this.StaticWriteJ1708DataPID.Text = "PID (Hex) :";
            // 
            // EditWriteJ1708DataBuf
            // 
            this.EditWriteJ1708DataBuf.Location = new System.Drawing.Point(87, 114);
            this.EditWriteJ1708DataBuf.Name = "EditWriteJ1708DataBuf";
            this.EditWriteJ1708DataBuf.Size = new System.Drawing.Size(365, 22);
            this.EditWriteJ1708DataBuf.TabIndex = 46;
            this.EditWriteJ1708DataBuf.Text = "1122";
            // 
            // WriteJ1708DataBtn
            // 
            this.WriteJ1708DataBtn.Location = new System.Drawing.Point(352, 142);
            this.WriteJ1708DataBtn.Name = "WriteJ1708DataBtn";
            this.WriteJ1708DataBtn.Size = new System.Drawing.Size(100, 20);
            this.WriteJ1708DataBtn.TabIndex = 41;
            this.WriteJ1708DataBtn.Text = "Write";
            this.WriteJ1708DataBtn.Click += new System.EventHandler(this.WriteJ1708DataBtn_Click);
            // 
            // StaticWriteJ1708DataBufSize
            // 
            this.StaticWriteJ1708DataBufSize.Location = new System.Drawing.Point(3, 87);
            this.StaticWriteJ1708DataBufSize.Name = "StaticWriteJ1708DataBufSize";
            this.StaticWriteJ1708DataBufSize.Size = new System.Drawing.Size(78, 23);
            this.StaticWriteJ1708DataBufSize.TabIndex = 53;
            this.StaticWriteJ1708DataBufSize.Text = "Buffer Size : ";
            // 
            // StaticWriteJ1708DataBuf
            // 
            this.StaticWriteJ1708DataBuf.Location = new System.Drawing.Point(3, 117);
            this.StaticWriteJ1708DataBuf.Name = "StaticWriteJ1708DataBuf";
            this.StaticWriteJ1708DataBuf.Size = new System.Drawing.Size(78, 23);
            this.StaticWriteJ1708DataBuf.TabIndex = 54;
            this.StaticWriteJ1708DataBuf.Text = "Buffer (Hex) :";
            // 
            // StaticWriteJ1708DataMID
            // 
            this.StaticWriteJ1708DataMID.Location = new System.Drawing.Point(3, 30);
            this.StaticWriteJ1708DataMID.Name = "StaticWriteJ1708DataMID";
            this.StaticWriteJ1708DataMID.Size = new System.Drawing.Size(78, 23);
            this.StaticWriteJ1708DataMID.TabIndex = 55;
            this.StaticWriteJ1708DataMID.Text = "MID (Hex) :";
            // 
            // EditWriteJ1708DataBufSize
            // 
            this.EditWriteJ1708DataBufSize.Location = new System.Drawing.Point(87, 84);
            this.EditWriteJ1708DataBufSize.Name = "EditWriteJ1708DataBufSize";
            this.EditWriteJ1708DataBufSize.Size = new System.Drawing.Size(29, 22);
            this.EditWriteJ1708DataBufSize.TabIndex = 34;
            this.EditWriteJ1708DataBufSize.Text = "2";
            // 
            // EditWriteJ1708DataPID
            // 
            this.EditWriteJ1708DataPID.Location = new System.Drawing.Point(87, 56);
            this.EditWriteJ1708DataPID.Name = "EditWriteJ1708DataPID";
            this.EditWriteJ1708DataPID.Size = new System.Drawing.Size(29, 22);
            this.EditWriteJ1708DataPID.TabIndex = 33;
            this.EditWriteJ1708DataPID.Text = "01";
            // 
            // EditWriteJ1708DataMID
            // 
            this.EditWriteJ1708DataMID.Location = new System.Drawing.Point(87, 26);
            this.EditWriteJ1708DataMID.Name = "EditWriteJ1708DataMID";
            this.EditWriteJ1708DataMID.Size = new System.Drawing.Size(29, 22);
            this.EditWriteJ1708DataMID.TabIndex = 32;
            this.EditWriteJ1708DataMID.Text = "80";
            // 
            // StaticJ1708WriteData
            // 
            this.StaticJ1708WriteData.Location = new System.Drawing.Point(3, 4);
            this.StaticJ1708WriteData.Name = "StaticJ1708WriteData";
            this.StaticJ1708WriteData.Size = new System.Drawing.Size(113, 20);
            this.StaticJ1708WriteData.TabIndex = 56;
            this.StaticJ1708WriteData.Text = "Write Data";
            // 
            // panel5
            // 
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel5.Controls.Add(this.ReadJ1708FilterBtn);
            this.panel5.Controls.Add(this.RemoveAllJ1708FilterBtn);
            this.panel5.Controls.Add(this.RemoveJ1708FilterBtn);
            this.panel5.Controls.Add(this.EditJ1708FilterMid);
            this.panel5.Controls.Add(this.StaticJ1708MessageFilter);
            this.panel5.Controls.Add(this.SetJ1708FilterBtn);
            this.panel5.Controls.Add(this.ListViewJ1708Filter);
            this.panel5.Location = new System.Drawing.Point(469, 225);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(300, 180);
            this.panel5.TabIndex = 1;
            // 
            // ReadJ1708FilterBtn
            // 
            this.ReadJ1708FilterBtn.Location = new System.Drawing.Point(3, 117);
            this.ReadJ1708FilterBtn.Name = "ReadJ1708FilterBtn";
            this.ReadJ1708FilterBtn.Size = new System.Drawing.Size(143, 23);
            this.ReadJ1708FilterBtn.TabIndex = 51;
            this.ReadJ1708FilterBtn.Text = "Read Filter list";
            this.ReadJ1708FilterBtn.Click += new System.EventHandler(this.ReadJ1708FilterBtn_Click);
            // 
            // RemoveAllJ1708FilterBtn
            // 
            this.RemoveAllJ1708FilterBtn.Location = new System.Drawing.Point(3, 59);
            this.RemoveAllJ1708FilterBtn.Name = "RemoveAllJ1708FilterBtn";
            this.RemoveAllJ1708FilterBtn.Size = new System.Drawing.Size(143, 23);
            this.RemoveAllJ1708FilterBtn.TabIndex = 49;
            this.RemoveAllJ1708FilterBtn.Text = "Remove All";
            this.RemoveAllJ1708FilterBtn.Click += new System.EventHandler(this.RemoveAllJ1708FilterBtn_Click);
            // 
            // RemoveJ1708FilterBtn
            // 
            this.RemoveJ1708FilterBtn.Location = new System.Drawing.Point(3, 88);
            this.RemoveJ1708FilterBtn.Name = "RemoveJ1708FilterBtn";
            this.RemoveJ1708FilterBtn.Size = new System.Drawing.Size(143, 23);
            this.RemoveJ1708FilterBtn.TabIndex = 48;
            this.RemoveJ1708FilterBtn.Text = "Remove select";
            this.RemoveJ1708FilterBtn.Click += new System.EventHandler(this.RemoveJ1708FilterBtn_Click);
            // 
            // EditJ1708FilterMid
            // 
            this.EditJ1708FilterMid.Location = new System.Drawing.Point(116, 29);
            this.EditJ1708FilterMid.Name = "EditJ1708FilterMid";
            this.EditJ1708FilterMid.Size = new System.Drawing.Size(30, 22);
            this.EditJ1708FilterMid.TabIndex = 44;
            this.EditJ1708FilterMid.Text = "80";
            // 
            // StaticJ1708MessageFilter
            // 
            this.StaticJ1708MessageFilter.Location = new System.Drawing.Point(3, 6);
            this.StaticJ1708MessageFilter.Name = "StaticJ1708MessageFilter";
            this.StaticJ1708MessageFilter.Size = new System.Drawing.Size(75, 20);
            this.StaticJ1708MessageFilter.TabIndex = 52;
            this.StaticJ1708MessageFilter.Text = "Message Filter";
            // 
            // SetJ1708FilterBtn
            // 
            this.SetJ1708FilterBtn.Location = new System.Drawing.Point(3, 29);
            this.SetJ1708FilterBtn.Name = "SetJ1708FilterBtn";
            this.SetJ1708FilterBtn.Size = new System.Drawing.Size(111, 23);
            this.SetJ1708FilterBtn.TabIndex = 44;
            this.SetJ1708FilterBtn.Text = "Add Mid (Hex)";
            this.SetJ1708FilterBtn.Click += new System.EventHandler(this.SetJ1708FilterBtn_Click);
            // 
            // ListViewJ1708Filter
            // 
            this.ListViewJ1708Filter.ItemHeight = 12;
            this.ListViewJ1708Filter.Location = new System.Drawing.Point(152, 6);
            this.ListViewJ1708Filter.Name = "ListViewJ1708Filter";
            this.ListViewJ1708Filter.Size = new System.Drawing.Size(144, 172);
            this.ListViewJ1708Filter.TabIndex = 2;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.labelJ1708RecvCount);
            this.panel4.Controls.Add(this.label35);
            this.panel4.Controls.Add(this.btJ1708MsgClear);
            this.panel4.Controls.Add(this.ShowJ1708DataChkBx);
            this.panel4.Controls.Add(this.J1708EventRdBtn);
            this.panel4.Controls.Add(this.J1708PollingRdBtn);
            this.panel4.Controls.Add(this.ReadJ1708DataBtn);
            this.panel4.Controls.Add(this.ListViewReadJ1708Data);
            this.panel4.Controls.Add(this.StaticJ1708ReadData);
            this.panel4.Location = new System.Drawing.Point(3, 3);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(766, 220);
            this.panel4.TabIndex = 2;
            // 
            // ShowJ1708DataChkBx
            // 
            this.ShowJ1708DataChkBx.Checked = true;
            this.ShowJ1708DataChkBx.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ShowJ1708DataChkBx.Location = new System.Drawing.Point(382, 6);
            this.ShowJ1708DataChkBx.Name = "ShowJ1708DataChkBx";
            this.ShowJ1708DataChkBx.Size = new System.Drawing.Size(96, 20);
            this.ShowJ1708DataChkBx.TabIndex = 4;
            this.ShowJ1708DataChkBx.Text = "Show Data";
            // 
            // J1708EventRdBtn
            // 
            this.J1708EventRdBtn.Location = new System.Drawing.Point(289, 6);
            this.J1708EventRdBtn.Name = "J1708EventRdBtn";
            this.J1708EventRdBtn.Size = new System.Drawing.Size(87, 20);
            this.J1708EventRdBtn.TabIndex = 41;
            this.J1708EventRdBtn.Text = "Event Mode";
            // 
            // J1708PollingRdBtn
            // 
            this.J1708PollingRdBtn.Location = new System.Drawing.Point(190, 6);
            this.J1708PollingRdBtn.Name = "J1708PollingRdBtn";
            this.J1708PollingRdBtn.Size = new System.Drawing.Size(93, 20);
            this.J1708PollingRdBtn.TabIndex = 40;
            this.J1708PollingRdBtn.Text = "Polling Mode";
            this.J1708PollingRdBtn.CheckedChanged += new System.EventHandler(this.J1708PollingRdBtn_CheckedChanged);
            // 
            // ReadJ1708DataBtn
            // 
            this.ReadJ1708DataBtn.Location = new System.Drawing.Point(98, 6);
            this.ReadJ1708DataBtn.Name = "ReadJ1708DataBtn";
            this.ReadJ1708DataBtn.Size = new System.Drawing.Size(72, 20);
            this.ReadJ1708DataBtn.TabIndex = 2;
            this.ReadJ1708DataBtn.Text = "Start";
            this.ReadJ1708DataBtn.Click += new System.EventHandler(this.ReadJ1708DataBtn_Click);
            // 
            // ListViewReadJ1708Data
            // 
            this.ListViewReadJ1708Data.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader20,
            this.columnHeader21,
            this.columnHeader22});
            this.ListViewReadJ1708Data.Location = new System.Drawing.Point(3, 32);
            this.ListViewReadJ1708Data.Name = "ListViewReadJ1708Data";
            this.ListViewReadJ1708Data.Size = new System.Drawing.Size(763, 184);
            this.ListViewReadJ1708Data.TabIndex = 1;
            this.ListViewReadJ1708Data.UseCompatibleStateImageBehavior = false;
            this.ListViewReadJ1708Data.View = System.Windows.Forms.View.Details;
            // 
            // StaticJ1708ReadData
            // 
            this.StaticJ1708ReadData.Location = new System.Drawing.Point(3, 6);
            this.StaticJ1708ReadData.Name = "StaticJ1708ReadData";
            this.StaticJ1708ReadData.Size = new System.Drawing.Size(79, 20);
            this.StaticJ1708ReadData.TabIndex = 42;
            this.StaticJ1708ReadData.Text = "Read Data";
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.panel13);
            this.tabPage1.Controls.Add(this.panel12);
            this.tabPage1.Controls.Add(this.panel11);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(772, 408);
            this.tabPage1.TabIndex = 4;
            this.tabPage1.Text = "J1587";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // panel13
            // 
            this.panel13.Controls.Add(this.ReadJ1587FilterBtn);
            this.panel13.Controls.Add(this.RemoveAllJ1587FilterBtn);
            this.panel13.Controls.Add(this.RemoveJ1587FilterBtn);
            this.panel13.Controls.Add(this.EditJ1587FilterPid);
            this.panel13.Controls.Add(this.StaticJ1587MessageFilter);
            this.panel13.Controls.Add(this.SetJ1587FilterBtn);
            this.panel13.Controls.Add(this.ListViewJ1587Filter);
            this.panel13.Location = new System.Drawing.Point(460, 234);
            this.panel13.Name = "panel13";
            this.panel13.Size = new System.Drawing.Size(312, 171);
            this.panel13.TabIndex = 0;
            // 
            // ReadJ1587FilterBtn
            // 
            this.ReadJ1587FilterBtn.Location = new System.Drawing.Point(3, 117);
            this.ReadJ1587FilterBtn.Name = "ReadJ1587FilterBtn";
            this.ReadJ1587FilterBtn.Size = new System.Drawing.Size(147, 23);
            this.ReadJ1587FilterBtn.TabIndex = 51;
            this.ReadJ1587FilterBtn.Text = "Read Filter list";
            this.ReadJ1587FilterBtn.Click += new System.EventHandler(this.ReadJ1587FilterBtn_Click);
            // 
            // RemoveAllJ1587FilterBtn
            // 
            this.RemoveAllJ1587FilterBtn.Location = new System.Drawing.Point(3, 59);
            this.RemoveAllJ1587FilterBtn.Name = "RemoveAllJ1587FilterBtn";
            this.RemoveAllJ1587FilterBtn.Size = new System.Drawing.Size(147, 23);
            this.RemoveAllJ1587FilterBtn.TabIndex = 49;
            this.RemoveAllJ1587FilterBtn.Text = "Remove All";
            this.RemoveAllJ1587FilterBtn.Click += new System.EventHandler(this.RemoveAllJ1587FilterBtn_Click);
            // 
            // RemoveJ1587FilterBtn
            // 
            this.RemoveJ1587FilterBtn.Location = new System.Drawing.Point(3, 88);
            this.RemoveJ1587FilterBtn.Name = "RemoveJ1587FilterBtn";
            this.RemoveJ1587FilterBtn.Size = new System.Drawing.Size(147, 23);
            this.RemoveJ1587FilterBtn.TabIndex = 48;
            this.RemoveJ1587FilterBtn.Text = "Remove select";
            this.RemoveJ1587FilterBtn.Click += new System.EventHandler(this.RemoveJ1587FilterBtn_Click);
            // 
            // EditJ1587FilterPid
            // 
            this.EditJ1587FilterPid.Location = new System.Drawing.Point(116, 29);
            this.EditJ1587FilterPid.Name = "EditJ1587FilterPid";
            this.EditJ1587FilterPid.Size = new System.Drawing.Size(34, 22);
            this.EditJ1587FilterPid.TabIndex = 44;
            this.EditJ1587FilterPid.Text = "80";
            // 
            // StaticJ1587MessageFilter
            // 
            this.StaticJ1587MessageFilter.Location = new System.Drawing.Point(3, 6);
            this.StaticJ1587MessageFilter.Name = "StaticJ1587MessageFilter";
            this.StaticJ1587MessageFilter.Size = new System.Drawing.Size(110, 20);
            this.StaticJ1587MessageFilter.TabIndex = 52;
            this.StaticJ1587MessageFilter.Text = "Message Filter";
            // 
            // SetJ1587FilterBtn
            // 
            this.SetJ1587FilterBtn.Location = new System.Drawing.Point(3, 29);
            this.SetJ1587FilterBtn.Name = "SetJ1587FilterBtn";
            this.SetJ1587FilterBtn.Size = new System.Drawing.Size(111, 23);
            this.SetJ1587FilterBtn.TabIndex = 44;
            this.SetJ1587FilterBtn.Text = "Add PID (Hex)";
            this.SetJ1587FilterBtn.Click += new System.EventHandler(this.SetJ1587FilterBtn_Click);
            // 
            // ListViewJ1587Filter
            // 
            this.ListViewJ1587Filter.ItemHeight = 12;
            this.ListViewJ1587Filter.Location = new System.Drawing.Point(156, 6);
            this.ListViewJ1587Filter.Name = "ListViewJ1587Filter";
            this.ListViewJ1587Filter.Size = new System.Drawing.Size(152, 136);
            this.ListViewJ1587Filter.TabIndex = 2;
            // 
            // panel12
            // 
            this.panel12.Controls.Add(this.StaticWriteJ1587DataPriority);
            this.panel12.Controls.Add(this.EditWriteJ1587DataPriority);
            this.panel12.Controls.Add(this.StaticWriteJ1587DataPID);
            this.panel12.Controls.Add(this.EditWriteJ1587DataBuf);
            this.panel12.Controls.Add(this.WriteJ1587DataBtn);
            this.panel12.Controls.Add(this.StaticWriteJ1587DataBufSize);
            this.panel12.Controls.Add(this.StaticWriteJ1587DataBuf);
            this.panel12.Controls.Add(this.StaticWriteJ1587DataMID);
            this.panel12.Controls.Add(this.EditWriteJ1587DataBufSize);
            this.panel12.Controls.Add(this.EditWriteJ1587DataPID);
            this.panel12.Controls.Add(this.EditWriteJ1587DataMID);
            this.panel12.Controls.Add(this.StaticJ1587WriteData);
            this.panel12.Location = new System.Drawing.Point(3, 234);
            this.panel12.Name = "panel12";
            this.panel12.Size = new System.Drawing.Size(454, 171);
            this.panel12.TabIndex = 1;
            // 
            // StaticWriteJ1587DataPriority
            // 
            this.StaticWriteJ1587DataPriority.Location = new System.Drawing.Point(161, 27);
            this.StaticWriteJ1587DataPriority.Name = "StaticWriteJ1587DataPriority";
            this.StaticWriteJ1587DataPriority.Size = new System.Drawing.Size(79, 23);
            this.StaticWriteJ1587DataPriority.TabIndex = 0;
            this.StaticWriteJ1587DataPriority.Text = "Priority (Hex) :";
            // 
            // EditWriteJ1587DataPriority
            // 
            this.EditWriteJ1587DataPriority.Location = new System.Drawing.Point(246, 24);
            this.EditWriteJ1587DataPriority.Name = "EditWriteJ1587DataPriority";
            this.EditWriteJ1587DataPriority.Size = new System.Drawing.Size(46, 22);
            this.EditWriteJ1587DataPriority.TabIndex = 51;
            this.EditWriteJ1587DataPriority.Text = "1";
            // 
            // StaticWriteJ1587DataPID
            // 
            this.StaticWriteJ1587DataPID.Location = new System.Drawing.Point(3, 59);
            this.StaticWriteJ1587DataPID.Name = "StaticWriteJ1587DataPID";
            this.StaticWriteJ1587DataPID.Size = new System.Drawing.Size(79, 23);
            this.StaticWriteJ1587DataPID.TabIndex = 52;
            this.StaticWriteJ1587DataPID.Text = "PID (Hex) :";
            // 
            // EditWriteJ1587DataBuf
            // 
            this.EditWriteJ1587DataBuf.Location = new System.Drawing.Point(88, 114);
            this.EditWriteJ1587DataBuf.Name = "EditWriteJ1587DataBuf";
            this.EditWriteJ1587DataBuf.Size = new System.Drawing.Size(341, 22);
            this.EditWriteJ1587DataBuf.TabIndex = 46;
            this.EditWriteJ1587DataBuf.Text = "1122";
            // 
            // WriteJ1587DataBtn
            // 
            this.WriteJ1587DataBtn.Location = new System.Drawing.Point(342, 145);
            this.WriteJ1587DataBtn.Name = "WriteJ1587DataBtn";
            this.WriteJ1587DataBtn.Size = new System.Drawing.Size(100, 20);
            this.WriteJ1587DataBtn.TabIndex = 41;
            this.WriteJ1587DataBtn.Text = "Write";
            this.WriteJ1587DataBtn.Click += new System.EventHandler(this.WriteJ1587DataBtn_Click);
            // 
            // StaticWriteJ1587DataBufSize
            // 
            this.StaticWriteJ1587DataBufSize.Location = new System.Drawing.Point(4, 87);
            this.StaticWriteJ1587DataBufSize.Name = "StaticWriteJ1587DataBufSize";
            this.StaticWriteJ1587DataBufSize.Size = new System.Drawing.Size(78, 23);
            this.StaticWriteJ1587DataBufSize.TabIndex = 53;
            this.StaticWriteJ1587DataBufSize.Text = "Buffer Size : ";
            // 
            // StaticWriteJ1587DataBuf
            // 
            this.StaticWriteJ1587DataBuf.Location = new System.Drawing.Point(3, 117);
            this.StaticWriteJ1587DataBuf.Name = "StaticWriteJ1587DataBuf";
            this.StaticWriteJ1587DataBuf.Size = new System.Drawing.Size(79, 23);
            this.StaticWriteJ1587DataBuf.TabIndex = 54;
            this.StaticWriteJ1587DataBuf.Text = "Buffer (Hex) :";
            // 
            // StaticWriteJ1587DataMID
            // 
            this.StaticWriteJ1587DataMID.Location = new System.Drawing.Point(3, 30);
            this.StaticWriteJ1587DataMID.Name = "StaticWriteJ1587DataMID";
            this.StaticWriteJ1587DataMID.Size = new System.Drawing.Size(79, 23);
            this.StaticWriteJ1587DataMID.TabIndex = 55;
            this.StaticWriteJ1587DataMID.Text = "MID (Hex) :";
            // 
            // EditWriteJ1587DataBufSize
            // 
            this.EditWriteJ1587DataBufSize.Location = new System.Drawing.Point(88, 87);
            this.EditWriteJ1587DataBufSize.Name = "EditWriteJ1587DataBufSize";
            this.EditWriteJ1587DataBufSize.Size = new System.Drawing.Size(27, 22);
            this.EditWriteJ1587DataBufSize.TabIndex = 34;
            this.EditWriteJ1587DataBufSize.Text = "2";
            // 
            // EditWriteJ1587DataPID
            // 
            this.EditWriteJ1587DataPID.Location = new System.Drawing.Point(88, 60);
            this.EditWriteJ1587DataPID.Name = "EditWriteJ1587DataPID";
            this.EditWriteJ1587DataPID.Size = new System.Drawing.Size(27, 22);
            this.EditWriteJ1587DataPID.TabIndex = 33;
            this.EditWriteJ1587DataPID.Text = "00";
            // 
            // EditWriteJ1587DataMID
            // 
            this.EditWriteJ1587DataMID.Location = new System.Drawing.Point(88, 27);
            this.EditWriteJ1587DataMID.Name = "EditWriteJ1587DataMID";
            this.EditWriteJ1587DataMID.Size = new System.Drawing.Size(27, 22);
            this.EditWriteJ1587DataMID.TabIndex = 32;
            this.EditWriteJ1587DataMID.Text = "80";
            // 
            // StaticJ1587WriteData
            // 
            this.StaticJ1587WriteData.Location = new System.Drawing.Point(3, 4);
            this.StaticJ1587WriteData.Name = "StaticJ1587WriteData";
            this.StaticJ1587WriteData.Size = new System.Drawing.Size(113, 20);
            this.StaticJ1587WriteData.TabIndex = 56;
            this.StaticJ1587WriteData.Text = "Write Data";
            // 
            // panel11
            // 
            this.panel11.Controls.Add(this.labelJ1587RecvCount);
            this.panel11.Controls.Add(this.label37);
            this.panel11.Controls.Add(this.btJ1587MsgClear);
            this.panel11.Controls.Add(this.J1587EventRdBtn);
            this.panel11.Controls.Add(this.J1587PollingRdBtn);
            this.panel11.Controls.Add(this.ListViewReadJ1587Data);
            this.panel11.Controls.Add(this.StaticJ1587ReadDataOff);
            this.panel11.Controls.Add(this.StaticJ1587ReadDataOn);
            this.panel11.Controls.Add(this.trBrJ1587Read);
            this.panel11.Controls.Add(this.ShowJ1587DataChkBx);
            this.panel11.Controls.Add(this.StaticJ1587ReadData);
            this.panel11.Location = new System.Drawing.Point(3, 3);
            this.panel11.Name = "panel11";
            this.panel11.Size = new System.Drawing.Size(769, 225);
            this.panel11.TabIndex = 2;
            // 
            // J1587EventRdBtn
            // 
            this.J1587EventRdBtn.Location = new System.Drawing.Point(325, 9);
            this.J1587EventRdBtn.Name = "J1587EventRdBtn";
            this.J1587EventRdBtn.Size = new System.Drawing.Size(88, 20);
            this.J1587EventRdBtn.TabIndex = 41;
            this.J1587EventRdBtn.Text = "Event Mode";
            this.J1587EventRdBtn.CheckedChanged += new System.EventHandler(this.J1587PollingRdBtn_CheckedChanged);
            // 
            // J1587PollingRdBtn
            // 
            this.J1587PollingRdBtn.Location = new System.Drawing.Point(227, 9);
            this.J1587PollingRdBtn.Name = "J1587PollingRdBtn";
            this.J1587PollingRdBtn.Size = new System.Drawing.Size(108, 20);
            this.J1587PollingRdBtn.TabIndex = 40;
            this.J1587PollingRdBtn.Text = "Polling Mode";
            this.J1587PollingRdBtn.CheckedChanged += new System.EventHandler(this.J1587PollingRdBtn_CheckedChanged);
            // 
            // ListViewReadJ1587Data
            // 
            this.ListViewReadJ1587Data.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader23,
            this.columnHeader24,
            this.columnHeader25,
            this.columnHeader26});
            this.ListViewReadJ1587Data.Location = new System.Drawing.Point(3, 35);
            this.ListViewReadJ1587Data.Name = "ListViewReadJ1587Data";
            this.ListViewReadJ1587Data.Size = new System.Drawing.Size(763, 183);
            this.ListViewReadJ1587Data.TabIndex = 1;
            this.ListViewReadJ1587Data.UseCompatibleStateImageBehavior = false;
            this.ListViewReadJ1587Data.View = System.Windows.Forms.View.Details;
            // 
            // StaticJ1587ReadDataOff
            // 
            this.StaticJ1587ReadDataOff.Location = new System.Drawing.Point(193, 6);
            this.StaticJ1587ReadDataOff.Name = "StaticJ1587ReadDataOff";
            this.StaticJ1587ReadDataOff.Size = new System.Drawing.Size(38, 23);
            this.StaticJ1587ReadDataOff.TabIndex = 0;
            this.StaticJ1587ReadDataOff.Text = "OFF";
            // 
            // StaticJ1587ReadDataOn
            // 
            this.StaticJ1587ReadDataOn.Location = new System.Drawing.Point(86, 6);
            this.StaticJ1587ReadDataOn.Name = "StaticJ1587ReadDataOn";
            this.StaticJ1587ReadDataOn.Size = new System.Drawing.Size(25, 23);
            this.StaticJ1587ReadDataOn.TabIndex = 1;
            this.StaticJ1587ReadDataOn.Text = "ON";
            // 
            // trBrJ1587Read
            // 
            this.trBrJ1587Read.Location = new System.Drawing.Point(117, 6);
            this.trBrJ1587Read.Maximum = 1;
            this.trBrJ1587Read.Name = "trBrJ1587Read";
            this.trBrJ1587Read.Size = new System.Drawing.Size(70, 45);
            this.trBrJ1587Read.TabIndex = 51;
            this.trBrJ1587Read.ValueChanged += new System.EventHandler(this.trBrJ1587Read_ValueChanged);
            // 
            // ShowJ1587DataChkBx
            // 
            this.ShowJ1587DataChkBx.Checked = true;
            this.ShowJ1587DataChkBx.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ShowJ1587DataChkBx.Location = new System.Drawing.Point(419, 9);
            this.ShowJ1587DataChkBx.Name = "ShowJ1587DataChkBx";
            this.ShowJ1587DataChkBx.Size = new System.Drawing.Size(96, 20);
            this.ShowJ1587DataChkBx.TabIndex = 4;
            this.ShowJ1587DataChkBx.Text = "Show Data";
            // 
            // StaticJ1587ReadData
            // 
            this.StaticJ1587ReadData.Location = new System.Drawing.Point(3, 6);
            this.StaticJ1587ReadData.Name = "StaticJ1587ReadData";
            this.StaticJ1587ReadData.Size = new System.Drawing.Size(79, 20);
            this.StaticJ1587ReadData.TabIndex = 52;
            this.StaticJ1587ReadData.Text = "Read Data";
            // 
            // radioButton1
            // 
            this.radioButton1.Location = new System.Drawing.Point(117, 58);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(108, 20);
            this.radioButton1.TabIndex = 41;
            this.radioButton1.Text = "Event Mode";
            // 
            // checkBox1
            // 
            this.checkBox1.Location = new System.Drawing.Point(176, 35);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(108, 20);
            this.checkBox1.TabIndex = 7;
            this.checkBox1.Text = "Show Count";
            // 
            // radioButton2
            // 
            this.radioButton2.Location = new System.Drawing.Point(3, 58);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(108, 20);
            this.radioButton2.TabIndex = 40;
            this.radioButton2.Text = "Polling Mode";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(98, 32);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(72, 22);
            this.textBox1.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(3, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Read Count :";
            // 
            // checkBox2
            // 
            this.checkBox2.Location = new System.Drawing.Point(176, 6);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(96, 20);
            this.checkBox2.TabIndex = 4;
            this.checkBox2.Text = "Show Data";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(98, 6);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(72, 20);
            this.button1.TabIndex = 2;
            this.button1.Text = "Start";
            // 
            // listView1
            // 
            this.listView1.Location = new System.Drawing.Point(3, 80);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(288, 281);
            this.listView1.TabIndex = 1;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(3, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 20);
            this.label2.TabIndex = 0;
            this.label2.Text = "Read Data";
            // 
            // ReadJ1708DataTimer
            // 
            this.ReadJ1708DataTimer.Tick += new System.EventHandler(this.ReadJ1708DataTimer_Tick);
            // 
            // radioButton3
            // 
            this.radioButton3.Location = new System.Drawing.Point(117, 58);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(108, 20);
            this.radioButton3.TabIndex = 41;
            this.radioButton3.Text = "Event Mode";
            // 
            // checkBox3
            // 
            this.checkBox3.Location = new System.Drawing.Point(176, 35);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(108, 20);
            this.checkBox3.TabIndex = 7;
            this.checkBox3.Text = "Show Count";
            // 
            // radioButton4
            // 
            this.radioButton4.Location = new System.Drawing.Point(3, 58);
            this.radioButton4.Name = "radioButton4";
            this.radioButton4.Size = new System.Drawing.Size(108, 20);
            this.radioButton4.TabIndex = 40;
            this.radioButton4.Text = "Polling Mode";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(98, 32);
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(72, 22);
            this.textBox2.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(3, 32);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 23);
            this.label3.TabIndex = 0;
            this.label3.Text = "Read Count :";
            // 
            // checkBox4
            // 
            this.checkBox4.Location = new System.Drawing.Point(176, 6);
            this.checkBox4.Name = "checkBox4";
            this.checkBox4.Size = new System.Drawing.Size(96, 20);
            this.checkBox4.TabIndex = 4;
            this.checkBox4.Text = "Show Data";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(98, 6);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(72, 20);
            this.button2.TabIndex = 2;
            this.button2.Text = "Start";
            // 
            // listView2
            // 
            this.listView2.Location = new System.Drawing.Point(3, 80);
            this.listView2.Name = "listView2";
            this.listView2.Size = new System.Drawing.Size(288, 317);
            this.listView2.TabIndex = 1;
            this.listView2.UseCompatibleStateImageBehavior = false;
            this.listView2.View = System.Windows.Forms.View.Details;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(3, 6);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 20);
            this.label4.TabIndex = 0;
            this.label4.Text = "Read Data";
            // 
            // radioButton5
            // 
            this.radioButton5.Location = new System.Drawing.Point(117, 58);
            this.radioButton5.Name = "radioButton5";
            this.radioButton5.Size = new System.Drawing.Size(108, 20);
            this.radioButton5.TabIndex = 41;
            this.radioButton5.Text = "Event Mode";
            // 
            // checkBox5
            // 
            this.checkBox5.Location = new System.Drawing.Point(176, 35);
            this.checkBox5.Name = "checkBox5";
            this.checkBox5.Size = new System.Drawing.Size(108, 20);
            this.checkBox5.TabIndex = 7;
            this.checkBox5.Text = "Show Count";
            // 
            // radioButton6
            // 
            this.radioButton6.Location = new System.Drawing.Point(3, 58);
            this.radioButton6.Name = "radioButton6";
            this.radioButton6.Size = new System.Drawing.Size(108, 20);
            this.radioButton6.TabIndex = 40;
            this.radioButton6.Text = "Polling Mode";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(98, 32);
            this.textBox3.Name = "textBox3";
            this.textBox3.ReadOnly = true;
            this.textBox3.Size = new System.Drawing.Size(72, 22);
            this.textBox3.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(3, 32);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(87, 23);
            this.label5.TabIndex = 0;
            this.label5.Text = "Read Count :";
            // 
            // checkBox6
            // 
            this.checkBox6.Location = new System.Drawing.Point(176, 6);
            this.checkBox6.Name = "checkBox6";
            this.checkBox6.Size = new System.Drawing.Size(96, 20);
            this.checkBox6.TabIndex = 4;
            this.checkBox6.Text = "Show Data";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(98, 6);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(72, 20);
            this.button3.TabIndex = 2;
            this.button3.Text = "Start";
            // 
            // listView3
            // 
            this.listView3.Location = new System.Drawing.Point(3, 80);
            this.listView3.Name = "listView3";
            this.listView3.Size = new System.Drawing.Size(288, 317);
            this.listView3.TabIndex = 1;
            this.listView3.UseCompatibleStateImageBehavior = false;
            this.listView3.View = System.Windows.Forms.View.Details;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(3, 6);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(79, 20);
            this.label6.TabIndex = 0;
            this.label6.Text = "Read Data";
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(3, 88);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(125, 23);
            this.label9.TabIndex = 0;
            this.label9.Text = "Priority (Hex) :";
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(139, 88);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(100, 22);
            this.textBox5.TabIndex = 51;
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(3, 59);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(125, 23);
            this.label10.TabIndex = 0;
            this.label10.Text = "PID (Hex) :";
            // 
            // textBox6
            // 
            this.textBox6.Location = new System.Drawing.Point(139, 117);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(100, 22);
            this.textBox6.TabIndex = 46;
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(139, 3);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(100, 20);
            this.button5.TabIndex = 41;
            this.button5.Text = "Write";
            // 
            // label11
            // 
            this.label11.Location = new System.Drawing.Point(3, 146);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(125, 23);
            this.label11.TabIndex = 0;
            this.label11.Text = "Buffer Size : ";
            // 
            // label12
            // 
            this.label12.Location = new System.Drawing.Point(3, 117);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(125, 23);
            this.label12.TabIndex = 0;
            this.label12.Text = "Buffer (Hex) :";
            // 
            // label13
            // 
            this.label13.Location = new System.Drawing.Point(3, 30);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(125, 23);
            this.label13.TabIndex = 0;
            this.label13.Text = "MID (Hex) :";
            // 
            // textBox7
            // 
            this.textBox7.Location = new System.Drawing.Point(139, 146);
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new System.Drawing.Size(100, 22);
            this.textBox7.TabIndex = 34;
            // 
            // textBox8
            // 
            this.textBox8.Location = new System.Drawing.Point(139, 59);
            this.textBox8.Name = "textBox8";
            this.textBox8.Size = new System.Drawing.Size(100, 22);
            this.textBox8.TabIndex = 33;
            // 
            // textBox9
            // 
            this.textBox9.Location = new System.Drawing.Point(139, 30);
            this.textBox9.Name = "textBox9";
            this.textBox9.Size = new System.Drawing.Size(100, 22);
            this.textBox9.TabIndex = 32;
            this.textBox9.Text = "80";
            // 
            // label14
            // 
            this.label14.Location = new System.Drawing.Point(3, 4);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(113, 20);
            this.label14.TabIndex = 0;
            this.label14.Text = "Write Data";
            // 
            // radioButton7
            // 
            this.radioButton7.Location = new System.Drawing.Point(117, 33);
            this.radioButton7.Name = "radioButton7";
            this.radioButton7.Size = new System.Drawing.Size(108, 20);
            this.radioButton7.TabIndex = 41;
            this.radioButton7.Text = "Event Mode";
            // 
            // radioButton8
            // 
            this.radioButton8.Location = new System.Drawing.Point(3, 33);
            this.radioButton8.Name = "radioButton8";
            this.radioButton8.Size = new System.Drawing.Size(108, 20);
            this.radioButton8.TabIndex = 40;
            this.radioButton8.Text = "Polling Mode";
            // 
            // checkBox7
            // 
            this.checkBox7.Location = new System.Drawing.Point(176, 6);
            this.checkBox7.Name = "checkBox7";
            this.checkBox7.Size = new System.Drawing.Size(96, 20);
            this.checkBox7.TabIndex = 4;
            this.checkBox7.Text = "Show Data";
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(98, 6);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(72, 20);
            this.button4.TabIndex = 2;
            this.button4.Text = "Start";
            // 
            // listView4
            // 
            this.listView4.Location = new System.Drawing.Point(3, 60);
            this.listView4.Name = "listView4";
            this.listView4.Size = new System.Drawing.Size(386, 296);
            this.listView4.TabIndex = 1;
            this.listView4.UseCompatibleStateImageBehavior = false;
            this.listView4.View = System.Windows.Forms.View.Details;
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(3, 6);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(79, 20);
            this.label7.TabIndex = 0;
            this.label7.Text = "Read Data";
            // 
            // ReadJ1939DataTimer
            // 
            this.ReadJ1939DataTimer.Tick += new System.EventHandler(this.ReadJ1939DataTimer_Tick);
            // 
            // radioButton9
            // 
            this.radioButton9.Location = new System.Drawing.Point(117, 58);
            this.radioButton9.Name = "radioButton9";
            this.radioButton9.Size = new System.Drawing.Size(108, 20);
            this.radioButton9.TabIndex = 41;
            this.radioButton9.Text = "Event Mode";
            // 
            // checkBox8
            // 
            this.checkBox8.Location = new System.Drawing.Point(176, 35);
            this.checkBox8.Name = "checkBox8";
            this.checkBox8.Size = new System.Drawing.Size(108, 20);
            this.checkBox8.TabIndex = 7;
            this.checkBox8.Text = "Show Count";
            // 
            // radioButton10
            // 
            this.radioButton10.Location = new System.Drawing.Point(3, 58);
            this.radioButton10.Name = "radioButton10";
            this.radioButton10.Size = new System.Drawing.Size(108, 20);
            this.radioButton10.TabIndex = 40;
            this.radioButton10.Text = "Polling Mode";
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(98, 32);
            this.textBox4.Name = "textBox4";
            this.textBox4.ReadOnly = true;
            this.textBox4.Size = new System.Drawing.Size(72, 22);
            this.textBox4.TabIndex = 6;
            // 
            // label15
            // 
            this.label15.Location = new System.Drawing.Point(3, 32);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(87, 23);
            this.label15.TabIndex = 0;
            this.label15.Text = "Read Count :";
            // 
            // checkBox9
            // 
            this.checkBox9.Location = new System.Drawing.Point(176, 6);
            this.checkBox9.Name = "checkBox9";
            this.checkBox9.Size = new System.Drawing.Size(96, 20);
            this.checkBox9.TabIndex = 4;
            this.checkBox9.Text = "Show Data";
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(98, 6);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(72, 20);
            this.button6.TabIndex = 2;
            this.button6.Text = "Start";
            // 
            // listView5
            // 
            this.listView5.Location = new System.Drawing.Point(3, 80);
            this.listView5.Name = "listView5";
            this.listView5.Size = new System.Drawing.Size(288, 317);
            this.listView5.TabIndex = 1;
            this.listView5.UseCompatibleStateImageBehavior = false;
            this.listView5.View = System.Windows.Forms.View.Details;
            // 
            // label16
            // 
            this.label16.Location = new System.Drawing.Point(3, 6);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(79, 20);
            this.label16.TabIndex = 0;
            this.label16.Text = "Read Data";
            // 
            // ReadJ1587DataTimer
            // 
            this.ReadJ1587DataTimer.Tick += new System.EventHandler(this.ReadJ1587DataTimer_Tick);
            // 
            // label17
            // 
            this.label17.Location = new System.Drawing.Point(3, 88);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(125, 23);
            this.label17.TabIndex = 0;
            this.label17.Text = "Priority (Hex) :";
            // 
            // textBox10
            // 
            this.textBox10.Location = new System.Drawing.Point(139, 88);
            this.textBox10.Name = "textBox10";
            this.textBox10.Size = new System.Drawing.Size(100, 22);
            this.textBox10.TabIndex = 51;
            // 
            // label18
            // 
            this.label18.Location = new System.Drawing.Point(3, 59);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(125, 23);
            this.label18.TabIndex = 0;
            this.label18.Text = "PID (Hex) :";
            // 
            // textBox11
            // 
            this.textBox11.Location = new System.Drawing.Point(139, 117);
            this.textBox11.Name = "textBox11";
            this.textBox11.Size = new System.Drawing.Size(100, 22);
            this.textBox11.TabIndex = 46;
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(139, 3);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(100, 20);
            this.button7.TabIndex = 41;
            this.button7.Text = "Write";
            // 
            // label19
            // 
            this.label19.Location = new System.Drawing.Point(3, 146);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(125, 23);
            this.label19.TabIndex = 0;
            this.label19.Text = "Buffer Size : ";
            // 
            // label21
            // 
            this.label21.Location = new System.Drawing.Point(3, 117);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(125, 23);
            this.label21.TabIndex = 0;
            this.label21.Text = "Buffer (Hex) :";
            // 
            // label22
            // 
            this.label22.Location = new System.Drawing.Point(3, 30);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(125, 23);
            this.label22.TabIndex = 0;
            this.label22.Text = "MID (Hex) :";
            // 
            // textBox12
            // 
            this.textBox12.Location = new System.Drawing.Point(139, 146);
            this.textBox12.Name = "textBox12";
            this.textBox12.Size = new System.Drawing.Size(100, 22);
            this.textBox12.TabIndex = 34;
            // 
            // textBox13
            // 
            this.textBox13.Location = new System.Drawing.Point(139, 59);
            this.textBox13.Name = "textBox13";
            this.textBox13.Size = new System.Drawing.Size(100, 22);
            this.textBox13.TabIndex = 33;
            // 
            // textBox14
            // 
            this.textBox14.Location = new System.Drawing.Point(139, 30);
            this.textBox14.Name = "textBox14";
            this.textBox14.Size = new System.Drawing.Size(100, 22);
            this.textBox14.TabIndex = 32;
            this.textBox14.Text = "80";
            // 
            // label23
            // 
            this.label23.Location = new System.Drawing.Point(3, 4);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(113, 20);
            this.label23.TabIndex = 0;
            this.label23.Text = "Write Data";
            // 
            // ReadOBD2DataTimer
            // 
            this.ReadOBD2DataTimer.Tick += new System.EventHandler(this.ReadOBD2DataTimer_Tick);
            // 
            // panel18
            // 
            this.panel18.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel18.Controls.Add(this.CANErrorStatusValue);
            this.panel18.Controls.Add(this.btnGetCANErrorStatus);
            this.panel18.Controls.Add(this.CANErrorStatus);
            this.panel18.Location = new System.Drawing.Point(3, 342);
            this.panel18.Name = "panel18";
            this.panel18.Size = new System.Drawing.Size(431, 35);
            this.panel18.TabIndex = 67;
            // 
            // rbCANPort1
            // 
            this.rbCANPort1.AutoSize = true;
            this.rbCANPort1.Checked = true;
            this.rbCANPort1.Location = new System.Drawing.Point(645, 383);
            this.rbCANPort1.Name = "rbCANPort1";
            this.rbCANPort1.Size = new System.Drawing.Size(51, 16);
            this.rbCANPort1.TabIndex = 68;
            this.rbCANPort1.TabStop = true;
            this.rbCANPort1.Text = "Port 1";
            this.rbCANPort1.UseVisualStyleBackColor = true;
            // 
            // rbCANPort2
            // 
            this.rbCANPort2.AutoSize = true;
            this.rbCANPort2.Location = new System.Drawing.Point(702, 383);
            this.rbCANPort2.Name = "rbCANPort2";
            this.rbCANPort2.Size = new System.Drawing.Size(51, 16);
            this.rbCANPort2.TabIndex = 69;
            this.rbCANPort2.Text = "Port 2";
            this.rbCANPort2.UseVisualStyleBackColor = true;
            // 
            // columnHeader16
            // 
            this.columnHeader16.Text = "Port";
            this.columnHeader16.Width = 50;
            // 
            // columnHeader17
            // 
            this.columnHeader17.Text = "ID (Hex)";
            this.columnHeader17.Width = 80;
            // 
            // columnHeader18
            // 
            this.columnHeader18.Text = "Length";
            this.columnHeader18.Width = 50;
            // 
            // columnHeader19
            // 
            this.columnHeader19.Text = "Data (Hex)";
            this.columnHeader19.Width = 200;
            // 
            // rbJ1939Port2
            // 
            this.rbJ1939Port2.AutoSize = true;
            this.rbJ1939Port2.Location = new System.Drawing.Point(714, 385);
            this.rbJ1939Port2.Name = "rbJ1939Port2";
            this.rbJ1939Port2.Size = new System.Drawing.Size(51, 16);
            this.rbJ1939Port2.TabIndex = 84;
            this.rbJ1939Port2.Text = "Port 2";
            this.rbJ1939Port2.UseVisualStyleBackColor = true;
            // 
            // rbJ1939Port1
            // 
            this.rbJ1939Port1.AutoSize = true;
            this.rbJ1939Port1.Checked = true;
            this.rbJ1939Port1.Location = new System.Drawing.Point(657, 385);
            this.rbJ1939Port1.Name = "rbJ1939Port1";
            this.rbJ1939Port1.Size = new System.Drawing.Size(51, 16);
            this.rbJ1939Port1.TabIndex = 83;
            this.rbJ1939Port1.TabStop = true;
            this.rbJ1939Port1.Text = "Port 1";
            this.rbJ1939Port1.UseVisualStyleBackColor = true;
            // 
            // label27
            // 
            this.label27.Location = new System.Drawing.Point(7, 384);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(52, 19);
            this.label27.TabIndex = 70;
            this.label27.Text = "Bitrate:";
            // 
            // label28
            // 
            this.label28.Location = new System.Drawing.Point(13, 383);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(52, 19);
            this.label28.TabIndex = 71;
            this.label28.Text = "Bitrate:";
            // 
            // rbOBD2Port2
            // 
            this.rbOBD2Port2.AutoSize = true;
            this.rbOBD2Port2.Location = new System.Drawing.Point(713, 382);
            this.rbOBD2Port2.Name = "rbOBD2Port2";
            this.rbOBD2Port2.Size = new System.Drawing.Size(51, 16);
            this.rbOBD2Port2.TabIndex = 87;
            this.rbOBD2Port2.Text = "Port 2";
            this.rbOBD2Port2.UseVisualStyleBackColor = true;
            // 
            // rbOBD2Port1
            // 
            this.rbOBD2Port1.AutoSize = true;
            this.rbOBD2Port1.Checked = true;
            this.rbOBD2Port1.Location = new System.Drawing.Point(656, 382);
            this.rbOBD2Port1.Name = "rbOBD2Port1";
            this.rbOBD2Port1.Size = new System.Drawing.Size(51, 16);
            this.rbOBD2Port1.TabIndex = 86;
            this.rbOBD2Port1.TabStop = true;
            this.rbOBD2Port1.Text = "Port 1";
            this.rbOBD2Port1.UseVisualStyleBackColor = true;
            // 
            // label29
            // 
            this.label29.Location = new System.Drawing.Point(544, 382);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(106, 20);
            this.label29.TabIndex = 85;
            this.label29.Text = "Channel Number :";
            // 
            // columnHeader20
            // 
            this.columnHeader20.Text = "MID (Hex)";
            this.columnHeader20.Width = 80;
            // 
            // columnHeader21
            // 
            this.columnHeader21.Text = "Length";
            // 
            // columnHeader22
            // 
            this.columnHeader22.Text = "Data(Hex)";
            this.columnHeader22.Width = 200;
            // 
            // columnHeader23
            // 
            this.columnHeader23.Text = "MID(Hex)";
            this.columnHeader23.Width = 80;
            // 
            // columnHeader24
            // 
            this.columnHeader24.Text = "PID(Hex)";
            this.columnHeader24.Width = 80;
            // 
            // columnHeader25
            // 
            this.columnHeader25.Text = "Length";
            // 
            // columnHeader26
            // 
            this.columnHeader26.Text = "Data(Hex)";
            this.columnHeader26.Width = 200;
            // 
            // btCANMsgClear
            // 
            this.btCANMsgClear.Location = new System.Drawing.Point(689, 6);
            this.btCANMsgClear.Name = "btCANMsgClear";
            this.btCANMsgClear.Size = new System.Drawing.Size(75, 23);
            this.btCANMsgClear.TabIndex = 43;
            this.btCANMsgClear.Text = "Clear";
            this.btCANMsgClear.UseVisualStyleBackColor = true;
            this.btCANMsgClear.Click += new System.EventHandler(this.btCANMsgClear_Click);
            // 
            // btJ1939MsgClear
            // 
            this.btJ1939MsgClear.Location = new System.Drawing.Point(688, 6);
            this.btJ1939MsgClear.Name = "btJ1939MsgClear";
            this.btJ1939MsgClear.Size = new System.Drawing.Size(75, 23);
            this.btJ1939MsgClear.TabIndex = 50;
            this.btJ1939MsgClear.Text = "Clear";
            this.btJ1939MsgClear.UseVisualStyleBackColor = true;
            this.btJ1939MsgClear.Click += new System.EventHandler(this.btJ1939MsgClear_Click);
            // 
            // btOBD2MsgClear
            // 
            this.btOBD2MsgClear.Location = new System.Drawing.Point(687, 5);
            this.btOBD2MsgClear.Name = "btOBD2MsgClear";
            this.btOBD2MsgClear.Size = new System.Drawing.Size(75, 23);
            this.btOBD2MsgClear.TabIndex = 50;
            this.btOBD2MsgClear.Text = "Clear";
            this.btOBD2MsgClear.UseVisualStyleBackColor = true;
            this.btOBD2MsgClear.Click += new System.EventHandler(this.btOBD2MsgClear_Click);
            // 
            // btJ1708MsgClear
            // 
            this.btJ1708MsgClear.Location = new System.Drawing.Point(687, 6);
            this.btJ1708MsgClear.Name = "btJ1708MsgClear";
            this.btJ1708MsgClear.Size = new System.Drawing.Size(75, 23);
            this.btJ1708MsgClear.TabIndex = 44;
            this.btJ1708MsgClear.Text = "Clear";
            this.btJ1708MsgClear.UseVisualStyleBackColor = true;
            this.btJ1708MsgClear.Click += new System.EventHandler(this.btJ1708MsgClear_Click);
            // 
            // btJ1587MsgClear
            // 
            this.btJ1587MsgClear.Location = new System.Drawing.Point(691, 3);
            this.btJ1587MsgClear.Name = "btJ1587MsgClear";
            this.btJ1587MsgClear.Size = new System.Drawing.Size(75, 23);
            this.btJ1587MsgClear.TabIndex = 53;
            this.btJ1587MsgClear.Text = "Clear";
            this.btJ1587MsgClear.UseVisualStyleBackColor = true;
            this.btJ1587MsgClear.Click += new System.EventHandler(this.btJ1587MsgClear_Click);
            // 
            // columnHeader27
            // 
            this.columnHeader27.Text = "Type";
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Location = new System.Drawing.Point(544, 10);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(64, 12);
            this.label30.TabIndex = 44;
            this.label30.Text = "Recv Count:";
            // 
            // labelCANRecvCount
            // 
            this.labelCANRecvCount.AutoSize = true;
            this.labelCANRecvCount.Location = new System.Drawing.Point(614, 10);
            this.labelCANRecvCount.Name = "labelCANRecvCount";
            this.labelCANRecvCount.Size = new System.Drawing.Size(11, 12);
            this.labelCANRecvCount.TabIndex = 45;
            this.labelCANRecvCount.Text = "0";
            // 
            // labelOBD2RecvCount
            // 
            this.labelOBD2RecvCount.AutoSize = true;
            this.labelOBD2RecvCount.Location = new System.Drawing.Point(626, 11);
            this.labelOBD2RecvCount.Name = "labelOBD2RecvCount";
            this.labelOBD2RecvCount.Size = new System.Drawing.Size(11, 12);
            this.labelOBD2RecvCount.TabIndex = 52;
            this.labelOBD2RecvCount.Text = "0";
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Location = new System.Drawing.Point(556, 11);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(64, 12);
            this.label32.TabIndex = 51;
            this.label32.Text = "Recv Count:";
            // 
            // labelJ1939RecvCount
            // 
            this.labelJ1939RecvCount.AutoSize = true;
            this.labelJ1939RecvCount.Location = new System.Drawing.Point(634, 13);
            this.labelJ1939RecvCount.Name = "labelJ1939RecvCount";
            this.labelJ1939RecvCount.Size = new System.Drawing.Size(11, 12);
            this.labelJ1939RecvCount.TabIndex = 54;
            this.labelJ1939RecvCount.Text = "0";
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.Location = new System.Drawing.Point(564, 13);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(64, 12);
            this.label33.TabIndex = 53;
            this.label33.Text = "Recv Count:";
            // 
            // labelJ1708RecvCount
            // 
            this.labelJ1708RecvCount.AutoSize = true;
            this.labelJ1708RecvCount.Location = new System.Drawing.Point(634, 11);
            this.labelJ1708RecvCount.Name = "labelJ1708RecvCount";
            this.labelJ1708RecvCount.Size = new System.Drawing.Size(11, 12);
            this.labelJ1708RecvCount.TabIndex = 54;
            this.labelJ1708RecvCount.Text = "0";
            // 
            // label35
            // 
            this.label35.AutoSize = true;
            this.label35.Location = new System.Drawing.Point(564, 11);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(64, 12);
            this.label35.TabIndex = 53;
            this.label35.Text = "Recv Count:";
            // 
            // labelJ1587RecvCount
            // 
            this.labelJ1587RecvCount.AutoSize = true;
            this.labelJ1587RecvCount.Location = new System.Drawing.Point(641, 9);
            this.labelJ1587RecvCount.Name = "labelJ1587RecvCount";
            this.labelJ1587RecvCount.Size = new System.Drawing.Size(11, 12);
            this.labelJ1587RecvCount.TabIndex = 55;
            this.labelJ1587RecvCount.Text = "0";
            // 
            // label37
            // 
            this.label37.AutoSize = true;
            this.label37.Location = new System.Drawing.Point(571, 9);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(64, 12);
            this.label37.TabIndex = 54;
            this.label37.Text = "Recv Count:";
            // 
            // VCIL
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(784, 442);
            this.Controls.Add(this.tabMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "VCIL";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TREK V3 VCIL Sample Code";
            this.Load += new System.EventHandler(this.VCIL_Load);
            this.Closed += new System.EventHandler(this.VCIL_Closed);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.tabMain.ResumeLayout(false);
            this.tabVCILControl.ResumeLayout(false);
            this.tabVCILControl.PerformLayout();
            this.panel7.ResumeLayout(false);
            this.tabCan.ResumeLayout(false);
            this.tabCan.PerformLayout();
            this.tabJ1939.ResumeLayout(false);
            this.tabJ1939.PerformLayout();
            this.panel14.ResumeLayout(false);
            this.panel14.PerformLayout();
            this.panel8.ResumeLayout(false);
            this.panel8.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trBrJ1939Read)).EndInit();
            this.panel10.ResumeLayout(false);
            this.panel10.PerformLayout();
            this.panel9.ResumeLayout(false);
            this.panel9.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.tabOBD2.ResumeLayout(false);
            this.tabOBD2.PerformLayout();
            this.panel17.ResumeLayout(false);
            this.panel17.PerformLayout();
            this.panel16.ResumeLayout(false);
            this.panel16.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel15.ResumeLayout(false);
            this.panel15.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trBrOBD2Read)).EndInit();
            this.tabJ1708.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.tabPage1.ResumeLayout(false);
            this.panel13.ResumeLayout(false);
            this.panel13.PerformLayout();
            this.panel12.ResumeLayout(false);
            this.panel12.PerformLayout();
            this.panel11.ResumeLayout(false);
            this.panel11.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trBrJ1587Read)).EndInit();
            this.panel18.ResumeLayout(false);
            this.panel18.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button ResetModuleBtn;
        private System.Windows.Forms.Label StaticLibVersion;
        private System.Windows.Forms.TextBox StaticLibVersionValue;
        private System.Windows.Forms.Label StaticFWVersion;
        private System.Windows.Forms.TextBox StaticFWVersionValue;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button BtnReadCANData;
        private System.Windows.Forms.ListView ListViewReadCANData;
        private System.Windows.Forms.Label StaticReadCANData;
        private System.Windows.Forms.Timer ReadCanDataTimer;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox MaskConTxt;
        private System.Windows.Forms.TextBox MaskIDTxt;
        private System.Windows.Forms.Label StaticMask;
        private System.Windows.Forms.Label StaticMsgID;
        private System.Windows.Forms.Label StaticMaskID;
        private System.Windows.Forms.Button RemoveMaskBtn;
        private System.Windows.Forms.Button SetMaskBtn;
        private System.Windows.Forms.Label StaticMsgMask;
        private System.Windows.Forms.Button SetCanBusSpeedBtn;
        private System.Windows.Forms.ComboBox CmbxCanBusSpeed;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label StaticWriteDataBufSize;
        private System.Windows.Forms.Label StaticWriteDataBuf;
        private System.Windows.Forms.Label StaticWriteDataMsgID;
        private System.Windows.Forms.TextBox EditWriteDataBufSize;
        private System.Windows.Forms.TextBox EditWriteDataBuf;
        private System.Windows.Forms.TextBox EditWriteDataMsgID;
        private System.Windows.Forms.Label StaticCANWriteData;
        private System.Windows.Forms.Button WriteCANDataBtn;
        private System.Windows.Forms.CheckBox ChkBxShowCANData;
        private System.Windows.Forms.ComboBox CmbxMsgType;
        private System.Windows.Forms.Label StaticMsgType;
        private System.Windows.Forms.Button GetMaskBtn;
        private System.Windows.Forms.RadioButton RdBtnCANPolling;
        private System.Windows.Forms.RadioButton RdBtnCANEvent;
        private System.Windows.Forms.Button CleanAllCanMaskBtn;
        private System.Windows.Forms.TabControl tabMain;
        private System.Windows.Forms.TabPage tabVCILControl;
        private System.Windows.Forms.TabPage tabCan;
        private System.Windows.Forms.TabPage tabJ1708;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.RadioButton J1708EventRdBtn;
        private System.Windows.Forms.RadioButton J1708PollingRdBtn;
        private System.Windows.Forms.CheckBox ShowJ1708DataChkBx;
        private System.Windows.Forms.Button ReadJ1708DataBtn;
        private System.Windows.Forms.ListView ListViewReadJ1708Data;
        private System.Windows.Forms.Label StaticJ1708ReadData;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label StaticJ1708MessageFilter;
        private System.Windows.Forms.Button SetJ1708FilterBtn;
        private System.Windows.Forms.ListBox ListViewJ1708Filter;
        private System.Windows.Forms.TextBox EditJ1708FilterMid;
        private System.Windows.Forms.Button RemoveAllJ1708FilterBtn;
        private System.Windows.Forms.Button RemoveJ1708FilterBtn;
        private System.Windows.Forms.Timer ReadJ1708DataTimer;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Button WriteJ1708DataBtn;
        private System.Windows.Forms.Label StaticWriteJ1708DataBufSize;
        private System.Windows.Forms.Label StaticWriteJ1708DataBuf;
        private System.Windows.Forms.Label StaticWriteJ1708DataMID;
        private System.Windows.Forms.TextBox EditWriteJ1708DataBufSize;
        private System.Windows.Forms.TextBox EditWriteJ1708DataPID;
        private System.Windows.Forms.TextBox EditWriteJ1708DataMID;
        private System.Windows.Forms.Label StaticJ1708WriteData;
        private System.Windows.Forms.TextBox EditWriteJ1708DataBuf;
        private System.Windows.Forms.Label StaticWriteJ1708DataPID;
        private System.Windows.Forms.TextBox EditWriteJ1708DataPriority;
        private System.Windows.Forms.Label StaticWriteJ1708DataPriority;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Label StaticModuleControl;
        private System.Windows.Forms.Label StaticModuleControlChannel02;
        private System.Windows.Forms.Label StaticModuleControlChannel01;
        private System.Windows.Forms.ComboBox cbBxModuleControlCANChannel02;
        private System.Windows.Forms.ComboBox cbBxModuleControlCANChannel01;
        private System.Windows.Forms.TabPage tabJ1939;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.CheckBox checkBox3;
        private System.Windows.Forms.RadioButton radioButton4;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox checkBox4;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ListView listView2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RadioButton radioButton5;
        private System.Windows.Forms.CheckBox checkBox5;
        private System.Windows.Forms.RadioButton radioButton6;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox checkBox6;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.ListView listView3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label StaticWriteDataChannelNumber;
        private System.Windows.Forms.ComboBox CmbxCANMaskNumber;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.Label StaticWriteJ1939DataDST;
        private System.Windows.Forms.TextBox EditWriteJ1939DST;
        private System.Windows.Forms.Label StaticWriteJ1939DataPGN;
        private System.Windows.Forms.TextBox EditWriteJ1939Buf;
        private System.Windows.Forms.Button BtnWriteJ1939Data;
        private System.Windows.Forms.Label StaticWriteJ1939DataBufSize;
        private System.Windows.Forms.Label StaticWriteJ1939DataBuf;
        private System.Windows.Forms.TextBox EditWriteJ1939BufSize;
        private System.Windows.Forms.TextBox EditWriteJ1939PGN;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox textBox7;
        private System.Windows.Forms.TextBox textBox8;
        private System.Windows.Forms.TextBox textBox9;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox EditWriteJ1939PRI;
        private System.Windows.Forms.Label StaticWriteJ1939DataPRI;
        private System.Windows.Forms.TextBox EditWriteJ1939SRC;
        private System.Windows.Forms.Label StaticWriteJ1939DataSRC;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.RadioButton RdBtnJ1939Event;
        private System.Windows.Forms.RadioButton RdBtnJ1939Polling;
        private System.Windows.Forms.CheckBox ChkBxShowJ1939Data;
        private System.Windows.Forms.ListView ListViewReadJ1939Data;
        private System.Windows.Forms.Label StaticReadJ1939Data;
        private System.Windows.Forms.RadioButton radioButton7;
        private System.Windows.Forms.RadioButton radioButton8;
        private System.Windows.Forms.CheckBox checkBox7;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.ListView listView4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label StaticJ1939ReadDataOff;
        private System.Windows.Forms.Label StaticJ1939ReadDataOn;
        private System.Windows.Forms.TrackBar trBrJ1939Read;
        private System.Windows.Forms.Timer ReadJ1939DataTimer;
        private System.Windows.Forms.Panel panel10;
        private System.Windows.Forms.Button BtnRemoveAllJ1939Filter;
        private System.Windows.Forms.Button BtnRemoveJ1939Filter;
        private System.Windows.Forms.TextBox EditJ1939FilterPGN;
        private System.Windows.Forms.Label StaticJ1939MessageFilter;
        private System.Windows.Forms.Button BtnSetJ1939Filter;
        private System.Windows.Forms.ListBox ListBxJ1939Filter;
        private System.Windows.Forms.Button ReadJ1708FilterBtn;
        private System.Windows.Forms.ComboBox cbBxModuleControlJ1708Channel;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button BtnGetJ1939Filter;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Panel panel11;
        private System.Windows.Forms.RadioButton J1587EventRdBtn;
        private System.Windows.Forms.RadioButton J1587PollingRdBtn;
        private System.Windows.Forms.CheckBox ShowJ1587DataChkBx;
        private System.Windows.Forms.ListView ListViewReadJ1587Data;
        private System.Windows.Forms.Label StaticJ1587ReadData;
        private System.Windows.Forms.RadioButton radioButton9;
        private System.Windows.Forms.CheckBox checkBox8;
        private System.Windows.Forms.RadioButton radioButton10;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.CheckBox checkBox9;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.ListView listView5;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label StaticJ1587ReadDataOff;
        private System.Windows.Forms.Label StaticJ1587ReadDataOn;
        private System.Windows.Forms.TrackBar trBrJ1587Read;
        private System.Windows.Forms.Timer ReadJ1587DataTimer;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox textBox10;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox textBox11;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.TextBox textBox12;
        private System.Windows.Forms.TextBox textBox13;
        private System.Windows.Forms.TextBox textBox14;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Panel panel12;
        private System.Windows.Forms.Label StaticWriteJ1587DataPriority;
        private System.Windows.Forms.TextBox EditWriteJ1587DataPriority;
        private System.Windows.Forms.Label StaticWriteJ1587DataPID;
        private System.Windows.Forms.TextBox EditWriteJ1587DataBuf;
        private System.Windows.Forms.Button WriteJ1587DataBtn;
        private System.Windows.Forms.Label StaticWriteJ1587DataBufSize;
        private System.Windows.Forms.Label StaticWriteJ1587DataBuf;
        private System.Windows.Forms.Label StaticWriteJ1587DataMID;
        private System.Windows.Forms.TextBox EditWriteJ1587DataBufSize;
        private System.Windows.Forms.TextBox EditWriteJ1587DataPID;
        private System.Windows.Forms.TextBox EditWriteJ1587DataMID;
        private System.Windows.Forms.Label StaticJ1587WriteData;
        private System.Windows.Forms.Panel panel13;
        private System.Windows.Forms.Button ReadJ1587FilterBtn;
        private System.Windows.Forms.Button RemoveAllJ1587FilterBtn;
        private System.Windows.Forms.Button RemoveJ1587FilterBtn;
        private System.Windows.Forms.TextBox EditJ1587FilterPid;
        private System.Windows.Forms.Label StaticJ1587MessageFilter;
        private System.Windows.Forms.Button SetJ1587FilterBtn;
        private System.Windows.Forms.ListBox ListViewJ1587Filter;
        private System.Windows.Forms.ComboBox CmbxWriteCANDataMessageType;
        private System.Windows.Forms.Label StaticWriteDataMessageType;
        private System.Windows.Forms.Panel panel14;
        private System.Windows.Forms.Label StaticJ1939TransmitConfigChannel;
        private System.Windows.Forms.Label StaticJ1939TransmitConfig;
        private System.Windows.Forms.Label StaticJ1939TransmitConfigAddress;
        private System.Windows.Forms.TextBox EditJ1939TransmitConfigName;
        private System.Windows.Forms.TextBox EditJ1939TransmitConfigAddress;
        private System.Windows.Forms.Button BtnGetJ1939TransmitConfig;
        private System.Windows.Forms.Button BtnSetJ1939TransmitConfig;
        private System.Windows.Forms.Label StaticJ1939TransmitConfigName;
        private System.Windows.Forms.TabPage tabOBD2;
        private System.Windows.Forms.Panel panel15;
        private System.Windows.Forms.Label StaticOBD2ReadDataOff;
        private System.Windows.Forms.Label StaticOBD2ReadDataOn;
        private System.Windows.Forms.TrackBar trBrOBD2Read;
        private System.Windows.Forms.RadioButton RdBtnOBD2Event;
        private System.Windows.Forms.RadioButton RdBtnOBD2Polling;
        private System.Windows.Forms.CheckBox ChkBxShowOBD2Data;
        private System.Windows.Forms.ListView ListViewReadOBD2Data;
        private System.Windows.Forms.Label StaticOBD2ReadData;
        private System.Windows.Forms.Panel panel16;
        private System.Windows.Forms.TextBox EditWriteOBD2PRI;
        private System.Windows.Forms.Label StaticWriteOBD2DataPRI;
        private System.Windows.Forms.TextBox EditWriteOBD2SRC;
        private System.Windows.Forms.Label StaticWriteOBD2DataSRC;
        private System.Windows.Forms.Label StaticWriteOBD2DataDST;
        private System.Windows.Forms.TextBox EditWriteOBD2DST;
        private System.Windows.Forms.TextBox EditWriteOBD2Buf;
        private System.Windows.Forms.Button BtnWriteOBD2Data;
        private System.Windows.Forms.Label StaticWriteOBD2DataBufSize;
        private System.Windows.Forms.Label StaticWriteOBD2DataBuf;
        private System.Windows.Forms.TextBox EditWriteOBD2BufSize;
        private System.Windows.Forms.Label StaticOBD2WriteData;
        private System.Windows.Forms.Label StaticWriteOBD2DataTAT;
        private System.Windows.Forms.ComboBox CmbxWriteOBD2DataTAT;
        private System.Windows.Forms.Panel panel17;
        private System.Windows.Forms.Button BtnGetOBD2Filter;
        private System.Windows.Forms.ListBox ListBxOBD2Filter;
        private System.Windows.Forms.Button BtnRemoveAllOBD2Filter;
        private System.Windows.Forms.Button BtnRemoveOBD2Filter;
        private System.Windows.Forms.TextBox EditOBD2FilterPGN;
        private System.Windows.Forms.Label StaticOBD2MessageFilter;
        private System.Windows.Forms.Button BtnSetOBD2Filter;
        private System.Windows.Forms.Timer ReadOBD2DataTimer;
        private System.Windows.Forms.CheckBox CANSilenceModeEnable;
        private System.Windows.Forms.Button GetCanBusSpeedBtn;
        private System.Windows.Forms.Label CANErrorStatusValue;
        private System.Windows.Forms.Label CANErrorStatus;
        private System.Windows.Forms.Button btnGetCANErrorStatus;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.RadioButton RDOBD11b;
        private System.Windows.Forms.TextBox EditWriteOBD2ID;
        private System.Windows.Forms.Label StaticWriteOBD2DataID;
        private System.Windows.Forms.RadioButton RDOBD29b;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.TextBox tbOBDTempPID;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cbOBDTempService;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.ColumnHeader columnHeader9;
        private System.Windows.Forms.ColumnHeader columnHeader10;
        private System.Windows.Forms.ColumnHeader columnHeader11;
        private System.Windows.Forms.ColumnHeader columnHeader12;
        private System.Windows.Forms.ColumnHeader columnHeader13;
        private System.Windows.Forms.ColumnHeader columnHeader14;
        private System.Windows.Forms.ColumnHeader columnHeader15;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.TextBox tbRequestPGN;
        private System.Windows.Forms.Button SetOBD2Bitrate;
        private System.Windows.Forms.ComboBox cbOBD2Bitrate;
        private System.Windows.Forms.Panel panel18;
        private System.Windows.Forms.RadioButton rbCANPort2;
        private System.Windows.Forms.RadioButton rbCANPort1;
        private System.Windows.Forms.ColumnHeader columnHeader16;
        private System.Windows.Forms.ColumnHeader columnHeader17;
        private System.Windows.Forms.ColumnHeader columnHeader18;
        private System.Windows.Forms.ColumnHeader columnHeader19;
        private System.Windows.Forms.RadioButton rbJ1939Port2;
        private System.Windows.Forms.RadioButton rbJ1939Port1;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.RadioButton rbOBD2Port2;
        private System.Windows.Forms.RadioButton rbOBD2Port1;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.ColumnHeader columnHeader20;
        private System.Windows.Forms.ColumnHeader columnHeader21;
        private System.Windows.Forms.ColumnHeader columnHeader22;
        private System.Windows.Forms.ColumnHeader columnHeader23;
        private System.Windows.Forms.ColumnHeader columnHeader24;
        private System.Windows.Forms.ColumnHeader columnHeader25;
        private System.Windows.Forms.ColumnHeader columnHeader26;
        private System.Windows.Forms.Button btCANMsgClear;
        private System.Windows.Forms.Button btJ1939MsgClear;
        private System.Windows.Forms.Button btOBD2MsgClear;
        private System.Windows.Forms.Button btJ1708MsgClear;
        private System.Windows.Forms.Button btJ1587MsgClear;
        private System.Windows.Forms.ColumnHeader columnHeader27;
        private System.Windows.Forms.Label labelCANRecvCount;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.Label labelOBD2RecvCount;
        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.Label labelJ1939RecvCount;
        private System.Windows.Forms.Label label33;
        private System.Windows.Forms.Label labelJ1708RecvCount;
        private System.Windows.Forms.Label label35;
        private System.Windows.Forms.Label labelJ1587RecvCount;
        private System.Windows.Forms.Label label37;
    }
}

