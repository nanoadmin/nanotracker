namespace TREK_V3_Sample_Code_VPM
{
    partial class VPM
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
            this.VPMTimer = new System.Windows.Forms.Timer(this.components);
            this.AlarmWakeupTabPage = new System.Windows.Forms.TabPage();
            this.panel10 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.DTTime = new System.Windows.Forms.DateTimePicker();
            this.DTDay = new System.Windows.Forms.DateTimePicker();
            this.StaticRTCTimeValue = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.StaticAlarmMinute = new System.Windows.Forms.Label();
            this.StaticAlarmHour = new System.Windows.Forms.Label();
            this.EditAlarmMinute = new System.Windows.Forms.TextBox();
            this.EditAlarmHour = new System.Windows.Forms.TextBox();
            this.EditAlarmDayOfWeek = new System.Windows.Forms.TextBox();
            this.StaticAlarmDayOfWeek = new System.Windows.Forms.Label();
            this.AlarmModeCmbx = new System.Windows.Forms.ComboBox();
            this.StaticAlarmModeLabel = new System.Windows.Forms.Label();
            this.BtnSetAlarmTime = new System.Windows.Forms.Button();
            this.AlarmStatusCmbx = new System.Windows.Forms.ComboBox();
            this.BtnGetAlarmStatus = new System.Windows.Forms.Button();
            this.BtnSetAlarmStatus = new System.Windows.Forms.Button();
            this.BtnGetAlarmTime = new System.Windows.Forms.Button();
            this.StaticAlarmStatusLabel = new System.Windows.Forms.Label();
            this.LBPIgnitionTabPage = new System.Windows.Forms.TabPage();
            this.panel2 = new System.Windows.Forms.Panel();
            this.EditIgnDelayOffEvent = new System.Windows.Forms.TextBox();
            this.StaticIgnDelayHardOff = new System.Windows.Forms.Label();
            this.StaticIgnDelayHardOffUnit = new System.Windows.Forms.Label();
            this.EditIgnDelayHardOff = new System.Windows.Forms.TextBox();
            this.StaticIgnDelayOnUnit = new System.Windows.Forms.Label();
            this.EditIgnDelayOn = new System.Windows.Forms.TextBox();
            this.StaticIgnDelayOffEventUnit = new System.Windows.Forms.Label();
            this.StaticIgnDelayOn = new System.Windows.Forms.Label();
            this.StaticIgnDelayOffEvent = new System.Windows.Forms.Label();
            this.RadioIgnDelayGet = new System.Windows.Forms.RadioButton();
            this.RadioIgnDelaySet = new System.Windows.Forms.RadioButton();
            this.BtnIgnDelayApply = new System.Windows.Forms.Button();
            this.StaticIgnitionDelayRes = new System.Windows.Forms.Label();
            this.StaticIgnitionDelay = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.ChkEnablePreBootLowBatterProtection = new System.Windows.Forms.CheckBox();
            this.panel8 = new System.Windows.Forms.Panel();
            this.EditDefault24VPreboot = new System.Windows.Forms.TextBox();
            this.EditDefault12VPreboot = new System.Windows.Forms.TextBox();
            this.EditDefault24VMin = new System.Windows.Forms.TextBox();
            this.EditDefault12VMin = new System.Windows.Forms.TextBox();
            this.EditDefault24VDef = new System.Windows.Forms.TextBox();
            this.EditDefault12VDef = new System.Windows.Forms.TextBox();
            this.EditDefault12VMax = new System.Windows.Forms.TextBox();
            this.EditDefault24VMax = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.StaticDefault24V = new System.Windows.Forms.Label();
            this.StaticDefault12V = new System.Windows.Forms.Label();
            this.StaticLowVoltageDefalultValue = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.EditPrebootThresholdValue24V = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.EditPrebootThresholdValue12V = new System.Windows.Forms.TextBox();
            this.StaticPrebootThreshold = new System.Windows.Forms.Label();
            this.StaticLBPThreshold = new System.Windows.Forms.Label();
            this.StaticLowVoltageThreshold24VUnit = new System.Windows.Forms.Label();
            this.StaticLowVoltageThreshold12VUnit = new System.Windows.Forms.Label();
            this.EditLowVoltageThresholdValue24V = new System.Windows.Forms.TextBox();
            this.EditLowVoltageThresholdValue12V = new System.Windows.Forms.TextBox();
            this.StaticLowVoltageThreshold24V = new System.Windows.Forms.Label();
            this.StaticLowVoltageThreshold12V = new System.Windows.Forms.Label();
            this.BtnLowVoltageThresholdApply = new System.Windows.Forms.Button();
            this.RadioLowVoltageThresholdGet = new System.Windows.Forms.RadioButton();
            this.RadioLowVoltageThresholdSet = new System.Windows.Forms.RadioButton();
            this.StaticLowVoltageThresholdRes = new System.Windows.Forms.Label();
            this.StaticLowVoltageThreshold = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.EditProtectionDelayLowHard = new System.Windows.Forms.TextBox();
            this.StaticProtectionDelayLowHard = new System.Windows.Forms.Label();
            this.EditProtectionDelayLow = new System.Windows.Forms.TextBox();
            this.StaticProtectionDelayLow = new System.Windows.Forms.Label();
            this.BtnProtectionApply = new System.Windows.Forms.Button();
            this.RadioProtectionGet = new System.Windows.Forms.RadioButton();
            this.RadioProtectionSet = new System.Windows.Forms.RadioButton();
            this.StaticLowThresholdRes = new System.Windows.Forms.Label();
            this.StaticLowThreshold = new System.Windows.Forms.Label();
            this.ChkEnableLowBatterProtection = new System.Windows.Forms.CheckBox();
            this.StaticBatteryVoltage = new System.Windows.Forms.Label();
            this.MainTabPage = new System.Windows.Forms.TabPage();
            this.panel12 = new System.Windows.Forms.Panel();
            this.ChkEnablePrePowerOff = new System.Windows.Forms.CheckBox();
            this.EditPrePowerOffAlarmDelayTime = new System.Windows.Forms.TextBox();
            this.labelPrePowerOffAlarmDelay = new System.Windows.Forms.Label();
            this.BtnPrePowerOffDelayApply = new System.Windows.Forms.Button();
            this.RadioPrePowerDelayGet = new System.Windows.Forms.RadioButton();
            this.RadioPrePowerDelaySet = new System.Windows.Forms.RadioButton();
            this.StaticPrePowerOffDelayRes = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.panel11 = new System.Windows.Forms.Panel();
            this.CmbShutdownSource = new System.Windows.Forms.ComboBox();
            this.DomianUDShutdownStatus = new System.Windows.Forms.DomainUpDown();
            this.radioShutdownSourceGet = new System.Windows.Forms.RadioButton();
            this.radioShutdownSoruceSet = new System.Windows.Forms.RadioButton();
            this.BtnShutdwonSource = new System.Windows.Forms.Button();
            this.StaticShutdownRes = new System.Windows.Forms.Label();
            this.labelShutdownSource = new System.Windows.Forms.Label();
            this.panel7 = new System.Windows.Forms.Panel();
            this.ChkEnableShutdownDelay = new System.Windows.Forms.CheckBox();
            this.EditShutdownDelayTime = new System.Windows.Forms.TextBox();
            this.labelShutdownDelay = new System.Windows.Forms.Label();
            this.BtnForceShutdownDelayApply = new System.Windows.Forms.Button();
            this.RadioForceShutdownDelayGet = new System.Windows.Forms.RadioButton();
            this.RadioForceShutdownDelaySet = new System.Windows.Forms.RadioButton();
            this.StaticForceShutdownDelayRes = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.panel9 = new System.Windows.Forms.Panel();
            this.StaticLastWakeupSourceRes = new System.Windows.Forms.Label();
            this.StaticLastWakeupSource = new System.Windows.Forms.Label();
            this.CmBxWakeupSource = new System.Windows.Forms.ComboBox();
            this.DomainUDWakeupSourceStatus = new System.Windows.Forms.DomainUpDown();
            this.RadioWakeupSourceGet = new System.Windows.Forms.RadioButton();
            this.RadioWakeupSourceSet = new System.Windows.Forms.RadioButton();
            this.BtnWakeupSourceApply = new System.Windows.Forms.Button();
            this.StaticWakeupSourceRes = new System.Windows.Forms.Label();
            this.StaticWakeupSource = new System.Windows.Forms.Label();
            this.CommonPanel = new System.Windows.Forms.Panel();
            this.BtnShutdown = new System.Windows.Forms.Button();
            this.CbBatteryVoltageModeValue = new System.Windows.Forms.ComboBox();
            this.BtnLoadDefault = new System.Windows.Forms.Button();
            this.StaticCurIgnStatusValue = new System.Windows.Forms.TextBox();
            this.StaticCurBatteryVoltageValue = new System.Windows.Forms.TextBox();
            this.StaticCurIgnStatus = new System.Windows.Forms.Label();
            this.StaticCurBatteryVoltage = new System.Windows.Forms.Label();
            this.StaticBatteryVoltageCBMode = new System.Windows.Forms.Label();
            this.StaticFirmwareVersionValue = new System.Windows.Forms.TextBox();
            this.StaticFirmwareVersion = new System.Windows.Forms.Label();
            this.StaticLibVersionValue = new System.Windows.Forms.TextBox();
            this.StaticLibVersion = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.DomainUDModeSwitchKeepAliveMode = new System.Windows.Forms.DomainUpDown();
            this.DomainUDModeSwitchATMode = new System.Windows.Forms.DomainUpDown();
            this.StaticModeSwitchKeepAliveMode = new System.Windows.Forms.Label();
            this.StaticModeSwitchATMode = new System.Windows.Forms.Label();
            this.RadioModeSwitchGet = new System.Windows.Forms.RadioButton();
            this.RadioModeSwitchSet = new System.Windows.Forms.RadioButton();
            this.BtnModeSwitchApply = new System.Windows.Forms.Button();
            this.StaticModeSwitchRes = new System.Windows.Forms.Label();
            this.StaticModeSwitch = new System.Windows.Forms.Label();
            this.VPM_TabControl = new System.Windows.Forms.TabControl();
            this.StaticPlatformName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.AlarmWakeupTabPage.SuspendLayout();
            this.panel10.SuspendLayout();
            this.panel1.SuspendLayout();
            this.LBPIgnitionTabPage.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel8.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel4.SuspendLayout();
            this.MainTabPage.SuspendLayout();
            this.panel12.SuspendLayout();
            this.panel11.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel9.SuspendLayout();
            this.CommonPanel.SuspendLayout();
            this.panel6.SuspendLayout();
            this.VPM_TabControl.SuspendLayout();
            this.SuspendLayout();
            // 
            // VPMTimer
            // 
            this.VPMTimer.Interval = 1000;
            this.VPMTimer.Tick += new System.EventHandler(this.PowerManagementTimer_Tick);
            // 
            // AlarmWakeupTabPage
            // 
            this.AlarmWakeupTabPage.Controls.Add(this.panel10);
            this.AlarmWakeupTabPage.Controls.Add(this.panel1);
            this.AlarmWakeupTabPage.Location = new System.Drawing.Point(4, 22);
            this.AlarmWakeupTabPage.Name = "AlarmWakeupTabPage";
            this.AlarmWakeupTabPage.Size = new System.Drawing.Size(738, 331);
            this.AlarmWakeupTabPage.TabIndex = 3;
            this.AlarmWakeupTabPage.Text = "Alarm Wakeup";
            // 
            // panel10
            // 
            this.panel10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel10.Controls.Add(this.button1);
            this.panel10.Controls.Add(this.DTTime);
            this.panel10.Controls.Add(this.DTDay);
            this.panel10.Controls.Add(this.StaticRTCTimeValue);
            this.panel10.Controls.Add(this.button3);
            this.panel10.Location = new System.Drawing.Point(273, 3);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(292, 213);
            this.panel10.TabIndex = 64;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(24, 37);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(103, 23);
            this.button1.TabIndex = 64;
            this.button1.Text = "Get";
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // DTTime
            // 
            this.DTTime.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.DTTime.Location = new System.Drawing.Point(150, 69);
            this.DTTime.MaxDate = new System.DateTime(2099, 12, 31, 0, 0, 0, 0);
            this.DTTime.MinDate = new System.DateTime(2000, 1, 1, 0, 0, 0, 0);
            this.DTTime.Name = "DTTime";
            this.DTTime.ShowUpDown = true;
            this.DTTime.Size = new System.Drawing.Size(136, 22);
            this.DTTime.TabIndex = 67;
            // 
            // DTDay
            // 
            this.DTDay.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DTDay.Location = new System.Drawing.Point(10, 69);
            this.DTDay.MaxDate = new System.DateTime(2099, 12, 31, 0, 0, 0, 0);
            this.DTDay.MinDate = new System.DateTime(2000, 1, 1, 0, 0, 0, 0);
            this.DTDay.Name = "DTDay";
            this.DTDay.Size = new System.Drawing.Size(136, 22);
            this.DTDay.TabIndex = 66;
            // 
            // StaticRTCTimeValue
            // 
            this.StaticRTCTimeValue.AutoSize = true;
            this.StaticRTCTimeValue.Location = new System.Drawing.Point(22, 8);
            this.StaticRTCTimeValue.Name = "StaticRTCTimeValue";
            this.StaticRTCTimeValue.Size = new System.Drawing.Size(79, 12);
            this.StaticRTCTimeValue.TabIndex = 65;
            this.StaticRTCTimeValue.Text = "RTCTimeValue";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(150, 37);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(103, 23);
            this.button3.TabIndex = 35;
            this.button3.Text = "Set";
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.StaticAlarmMinute);
            this.panel1.Controls.Add(this.StaticAlarmHour);
            this.panel1.Controls.Add(this.EditAlarmMinute);
            this.panel1.Controls.Add(this.EditAlarmHour);
            this.panel1.Controls.Add(this.EditAlarmDayOfWeek);
            this.panel1.Controls.Add(this.StaticAlarmDayOfWeek);
            this.panel1.Controls.Add(this.AlarmModeCmbx);
            this.panel1.Controls.Add(this.StaticAlarmModeLabel);
            this.panel1.Controls.Add(this.BtnSetAlarmTime);
            this.panel1.Controls.Add(this.AlarmStatusCmbx);
            this.panel1.Controls.Add(this.BtnGetAlarmStatus);
            this.panel1.Controls.Add(this.BtnSetAlarmStatus);
            this.panel1.Controls.Add(this.BtnGetAlarmTime);
            this.panel1.Controls.Add(this.StaticAlarmStatusLabel);
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(263, 213);
            this.panel1.TabIndex = 0;
            // 
            // StaticAlarmMinute
            // 
            this.StaticAlarmMinute.Location = new System.Drawing.Point(22, 124);
            this.StaticAlarmMinute.Name = "StaticAlarmMinute";
            this.StaticAlarmMinute.Size = new System.Drawing.Size(103, 23);
            this.StaticAlarmMinute.TabIndex = 0;
            this.StaticAlarmMinute.Text = "Minute";
            // 
            // StaticAlarmHour
            // 
            this.StaticAlarmHour.Location = new System.Drawing.Point(22, 95);
            this.StaticAlarmHour.Name = "StaticAlarmHour";
            this.StaticAlarmHour.Size = new System.Drawing.Size(103, 23);
            this.StaticAlarmHour.TabIndex = 1;
            this.StaticAlarmHour.Text = "Hour";
            // 
            // EditAlarmMinute
            // 
            this.EditAlarmMinute.Location = new System.Drawing.Point(145, 124);
            this.EditAlarmMinute.Name = "EditAlarmMinute";
            this.EditAlarmMinute.Size = new System.Drawing.Size(100, 22);
            this.EditAlarmMinute.TabIndex = 60;
            // 
            // EditAlarmHour
            // 
            this.EditAlarmHour.Location = new System.Drawing.Point(145, 95);
            this.EditAlarmHour.Name = "EditAlarmHour";
            this.EditAlarmHour.Size = new System.Drawing.Size(100, 22);
            this.EditAlarmHour.TabIndex = 59;
            // 
            // EditAlarmDayOfWeek
            // 
            this.EditAlarmDayOfWeek.Location = new System.Drawing.Point(145, 66);
            this.EditAlarmDayOfWeek.Name = "EditAlarmDayOfWeek";
            this.EditAlarmDayOfWeek.Size = new System.Drawing.Size(100, 22);
            this.EditAlarmDayOfWeek.TabIndex = 58;
            // 
            // StaticAlarmDayOfWeek
            // 
            this.StaticAlarmDayOfWeek.Location = new System.Drawing.Point(22, 66);
            this.StaticAlarmDayOfWeek.Name = "StaticAlarmDayOfWeek";
            this.StaticAlarmDayOfWeek.Size = new System.Drawing.Size(103, 23);
            this.StaticAlarmDayOfWeek.TabIndex = 61;
            this.StaticAlarmDayOfWeek.Text = "Day of Week";
            // 
            // AlarmModeCmbx
            // 
            this.AlarmModeCmbx.Items.AddRange(new object[] {
            "Hourly",
            "Daily",
            "Weekly"});
            this.AlarmModeCmbx.Location = new System.Drawing.Point(145, 153);
            this.AlarmModeCmbx.Name = "AlarmModeCmbx";
            this.AlarmModeCmbx.Size = new System.Drawing.Size(100, 20);
            this.AlarmModeCmbx.TabIndex = 50;
            // 
            // StaticAlarmModeLabel
            // 
            this.StaticAlarmModeLabel.Location = new System.Drawing.Point(3, 153);
            this.StaticAlarmModeLabel.Name = "StaticAlarmModeLabel";
            this.StaticAlarmModeLabel.Size = new System.Drawing.Size(150, 23);
            this.StaticAlarmModeLabel.TabIndex = 62;
            this.StaticAlarmModeLabel.Text = "Alarm Wakeup Mode :";
            // 
            // BtnSetAlarmTime
            // 
            this.BtnSetAlarmTime.Location = new System.Drawing.Point(142, 182);
            this.BtnSetAlarmTime.Name = "BtnSetAlarmTime";
            this.BtnSetAlarmTime.Size = new System.Drawing.Size(103, 23);
            this.BtnSetAlarmTime.TabIndex = 49;
            this.BtnSetAlarmTime.Text = "Set Alarm Time";
            this.BtnSetAlarmTime.Click += new System.EventHandler(this.BtnSetAlarmTime_Click);
            // 
            // AlarmStatusCmbx
            // 
            this.AlarmStatusCmbx.Items.AddRange(new object[] {
            "ON",
            "OFF"});
            this.AlarmStatusCmbx.Location = new System.Drawing.Point(145, 8);
            this.AlarmStatusCmbx.Name = "AlarmStatusCmbx";
            this.AlarmStatusCmbx.Size = new System.Drawing.Size(103, 20);
            this.AlarmStatusCmbx.TabIndex = 48;
            // 
            // BtnGetAlarmStatus
            // 
            this.BtnGetAlarmStatus.Location = new System.Drawing.Point(22, 37);
            this.BtnGetAlarmStatus.Name = "BtnGetAlarmStatus";
            this.BtnGetAlarmStatus.Size = new System.Drawing.Size(103, 23);
            this.BtnGetAlarmStatus.TabIndex = 47;
            this.BtnGetAlarmStatus.Text = "Get";
            this.BtnGetAlarmStatus.Click += new System.EventHandler(this.BtnGetAlarmStatus_Click);
            // 
            // BtnSetAlarmStatus
            // 
            this.BtnSetAlarmStatus.Location = new System.Drawing.Point(145, 37);
            this.BtnSetAlarmStatus.Name = "BtnSetAlarmStatus";
            this.BtnSetAlarmStatus.Size = new System.Drawing.Size(103, 23);
            this.BtnSetAlarmStatus.TabIndex = 35;
            this.BtnSetAlarmStatus.Text = "Set";
            this.BtnSetAlarmStatus.Click += new System.EventHandler(this.BtnSetAlarmStatus_Click);
            // 
            // BtnGetAlarmTime
            // 
            this.BtnGetAlarmTime.Location = new System.Drawing.Point(22, 182);
            this.BtnGetAlarmTime.Name = "BtnGetAlarmTime";
            this.BtnGetAlarmTime.Size = new System.Drawing.Size(103, 23);
            this.BtnGetAlarmTime.TabIndex = 45;
            this.BtnGetAlarmTime.Text = "Get Alarm Time";
            this.BtnGetAlarmTime.Click += new System.EventHandler(this.BtnGetAlarmTime_Click);
            // 
            // StaticAlarmStatusLabel
            // 
            this.StaticAlarmStatusLabel.Location = new System.Drawing.Point(3, 8);
            this.StaticAlarmStatusLabel.Name = "StaticAlarmStatusLabel";
            this.StaticAlarmStatusLabel.Size = new System.Drawing.Size(150, 23);
            this.StaticAlarmStatusLabel.TabIndex = 63;
            this.StaticAlarmStatusLabel.Text = "Alarm Wakeup Status :";
            // 
            // LBPIgnitionTabPage
            // 
            this.LBPIgnitionTabPage.Controls.Add(this.panel2);
            this.LBPIgnitionTabPage.Controls.Add(this.panel3);
            this.LBPIgnitionTabPage.Location = new System.Drawing.Point(4, 22);
            this.LBPIgnitionTabPage.Name = "LBPIgnitionTabPage";
            this.LBPIgnitionTabPage.Size = new System.Drawing.Size(738, 331);
            this.LBPIgnitionTabPage.TabIndex = 1;
            this.LBPIgnitionTabPage.Text = "LBP&Ignition";
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.EditIgnDelayOffEvent);
            this.panel2.Controls.Add(this.StaticIgnDelayHardOff);
            this.panel2.Controls.Add(this.StaticIgnDelayHardOffUnit);
            this.panel2.Controls.Add(this.EditIgnDelayHardOff);
            this.panel2.Controls.Add(this.StaticIgnDelayOnUnit);
            this.panel2.Controls.Add(this.EditIgnDelayOn);
            this.panel2.Controls.Add(this.StaticIgnDelayOffEventUnit);
            this.panel2.Controls.Add(this.StaticIgnDelayOn);
            this.panel2.Controls.Add(this.StaticIgnDelayOffEvent);
            this.panel2.Controls.Add(this.RadioIgnDelayGet);
            this.panel2.Controls.Add(this.RadioIgnDelaySet);
            this.panel2.Controls.Add(this.BtnIgnDelayApply);
            this.panel2.Controls.Add(this.StaticIgnitionDelayRes);
            this.panel2.Controls.Add(this.StaticIgnitionDelay);
            this.panel2.Location = new System.Drawing.Point(514, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(224, 324);
            this.panel2.TabIndex = 0;
            // 
            // EditIgnDelayOffEvent
            // 
            this.EditIgnDelayOffEvent.Location = new System.Drawing.Point(124, 86);
            this.EditIgnDelayOffEvent.Name = "EditIgnDelayOffEvent";
            this.EditIgnDelayOffEvent.Size = new System.Drawing.Size(49, 22);
            this.EditIgnDelayOffEvent.TabIndex = 16;
            this.EditIgnDelayOffEvent.Text = "5";
            // 
            // StaticIgnDelayHardOff
            // 
            this.StaticIgnDelayHardOff.Location = new System.Drawing.Point(4, 145);
            this.StaticIgnDelayHardOff.Name = "StaticIgnDelayHardOff";
            this.StaticIgnDelayHardOff.Size = new System.Drawing.Size(100, 23);
            this.StaticIgnDelayHardOff.TabIndex = 54;
            this.StaticIgnDelayHardOff.Text = "Hard Off Delay";
            // 
            // StaticIgnDelayHardOffUnit
            // 
            this.StaticIgnDelayHardOffUnit.Location = new System.Drawing.Point(179, 143);
            this.StaticIgnDelayHardOffUnit.Name = "StaticIgnDelayHardOffUnit";
            this.StaticIgnDelayHardOffUnit.Size = new System.Drawing.Size(49, 23);
            this.StaticIgnDelayHardOffUnit.TabIndex = 55;
            this.StaticIgnDelayHardOffUnit.Text = "Sec";
            // 
            // EditIgnDelayHardOff
            // 
            this.EditIgnDelayHardOff.Location = new System.Drawing.Point(124, 143);
            this.EditIgnDelayHardOff.Name = "EditIgnDelayHardOff";
            this.EditIgnDelayHardOff.Size = new System.Drawing.Size(49, 22);
            this.EditIgnDelayHardOff.TabIndex = 30;
            this.EditIgnDelayHardOff.Text = "60";
            // 
            // StaticIgnDelayOnUnit
            // 
            this.StaticIgnDelayOnUnit.Location = new System.Drawing.Point(179, 114);
            this.StaticIgnDelayOnUnit.Name = "StaticIgnDelayOnUnit";
            this.StaticIgnDelayOnUnit.Size = new System.Drawing.Size(49, 23);
            this.StaticIgnDelayOnUnit.TabIndex = 56;
            this.StaticIgnDelayOnUnit.Text = "Sec";
            // 
            // EditIgnDelayOn
            // 
            this.EditIgnDelayOn.Location = new System.Drawing.Point(124, 114);
            this.EditIgnDelayOn.Name = "EditIgnDelayOn";
            this.EditIgnDelayOn.Size = new System.Drawing.Size(49, 22);
            this.EditIgnDelayOn.TabIndex = 27;
            this.EditIgnDelayOn.Text = "2";
            // 
            // StaticIgnDelayOffEventUnit
            // 
            this.StaticIgnDelayOffEventUnit.Location = new System.Drawing.Point(179, 85);
            this.StaticIgnDelayOffEventUnit.Name = "StaticIgnDelayOffEventUnit";
            this.StaticIgnDelayOffEventUnit.Size = new System.Drawing.Size(49, 23);
            this.StaticIgnDelayOffEventUnit.TabIndex = 57;
            this.StaticIgnDelayOffEventUnit.Text = "Sec";
            // 
            // StaticIgnDelayOn
            // 
            this.StaticIgnDelayOn.Location = new System.Drawing.Point(4, 116);
            this.StaticIgnDelayOn.Name = "StaticIgnDelayOn";
            this.StaticIgnDelayOn.Size = new System.Drawing.Size(100, 23);
            this.StaticIgnDelayOn.TabIndex = 58;
            this.StaticIgnDelayOn.Text = "On Delay";
            // 
            // StaticIgnDelayOffEvent
            // 
            this.StaticIgnDelayOffEvent.Location = new System.Drawing.Point(4, 85);
            this.StaticIgnDelayOffEvent.Name = "StaticIgnDelayOffEvent";
            this.StaticIgnDelayOffEvent.Size = new System.Drawing.Size(100, 23);
            this.StaticIgnDelayOffEvent.TabIndex = 59;
            this.StaticIgnDelayOffEvent.Text = "Off Event Delay";
            // 
            // RadioIgnDelayGet
            // 
            this.RadioIgnDelayGet.Location = new System.Drawing.Point(179, 29);
            this.RadioIgnDelayGet.Name = "RadioIgnDelayGet";
            this.RadioIgnDelayGet.Size = new System.Drawing.Size(49, 22);
            this.RadioIgnDelayGet.TabIndex = 19;
            this.RadioIgnDelayGet.Text = "Get";
            // 
            // RadioIgnDelaySet
            // 
            this.RadioIgnDelaySet.Checked = true;
            this.RadioIgnDelaySet.Location = new System.Drawing.Point(124, 29);
            this.RadioIgnDelaySet.Name = "RadioIgnDelaySet";
            this.RadioIgnDelaySet.Size = new System.Drawing.Size(49, 22);
            this.RadioIgnDelaySet.TabIndex = 19;
            this.RadioIgnDelaySet.TabStop = true;
            this.RadioIgnDelaySet.Text = "Set";
            // 
            // BtnIgnDelayApply
            // 
            this.BtnIgnDelayApply.Location = new System.Drawing.Point(4, 29);
            this.BtnIgnDelayApply.Name = "BtnIgnDelayApply";
            this.BtnIgnDelayApply.Size = new System.Drawing.Size(72, 22);
            this.BtnIgnDelayApply.TabIndex = 19;
            this.BtnIgnDelayApply.Text = "Apply";
            this.BtnIgnDelayApply.Click += new System.EventHandler(this.BtnIgnDelayApply_Click);
            // 
            // StaticIgnitionDelayRes
            // 
            this.StaticIgnitionDelayRes.Location = new System.Drawing.Point(158, 4);
            this.StaticIgnitionDelayRes.Name = "StaticIgnitionDelayRes";
            this.StaticIgnitionDelayRes.Size = new System.Drawing.Size(70, 23);
            this.StaticIgnitionDelayRes.TabIndex = 60;
            this.StaticIgnitionDelayRes.Text = "Never Try";
            // 
            // StaticIgnitionDelay
            // 
            this.StaticIgnitionDelay.Location = new System.Drawing.Point(4, 4);
            this.StaticIgnitionDelay.Name = "StaticIgnitionDelay";
            this.StaticIgnitionDelay.Size = new System.Drawing.Size(109, 23);
            this.StaticIgnitionDelay.TabIndex = 61;
            this.StaticIgnitionDelay.Text = "Ignition ON/OFF";
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.ChkEnablePreBootLowBatterProtection);
            this.panel3.Controls.Add(this.panel8);
            this.panel3.Controls.Add(this.panel5);
            this.panel3.Controls.Add(this.panel4);
            this.panel3.Controls.Add(this.ChkEnableLowBatterProtection);
            this.panel3.Controls.Add(this.StaticBatteryVoltage);
            this.panel3.Location = new System.Drawing.Point(3, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(505, 324);
            this.panel3.TabIndex = 1;
            // 
            // ChkEnablePreBootLowBatterProtection
            // 
            this.ChkEnablePreBootLowBatterProtection.AutoSize = true;
            this.ChkEnablePreBootLowBatterProtection.Location = new System.Drawing.Point(244, 6);
            this.ChkEnablePreBootLowBatterProtection.Name = "ChkEnablePreBootLowBatterProtection";
            this.ChkEnablePreBootLowBatterProtection.Size = new System.Drawing.Size(64, 16);
            this.ChkEnablePreBootLowBatterProtection.TabIndex = 23;
            this.ChkEnablePreBootLowBatterProtection.Text = "Pre-boot";
            this.ChkEnablePreBootLowBatterProtection.UseVisualStyleBackColor = true;
            this.ChkEnablePreBootLowBatterProtection.CheckStateChanged += new System.EventHandler(this.ChkEnablePreBootLowBatterProtection_CheckStateChanged);
            // 
            // panel8
            // 
            this.panel8.Controls.Add(this.EditDefault24VPreboot);
            this.panel8.Controls.Add(this.EditDefault12VPreboot);
            this.panel8.Controls.Add(this.EditDefault24VMin);
            this.panel8.Controls.Add(this.EditDefault12VMin);
            this.panel8.Controls.Add(this.EditDefault24VDef);
            this.panel8.Controls.Add(this.EditDefault12VDef);
            this.panel8.Controls.Add(this.EditDefault12VMax);
            this.panel8.Controls.Add(this.EditDefault24VMax);
            this.panel8.Controls.Add(this.label11);
            this.panel8.Controls.Add(this.label10);
            this.panel8.Controls.Add(this.label9);
            this.panel8.Controls.Add(this.label8);
            this.panel8.Controls.Add(this.StaticDefault24V);
            this.panel8.Controls.Add(this.StaticDefault12V);
            this.panel8.Controls.Add(this.StaticLowVoltageDefalultValue);
            this.panel8.Location = new System.Drawing.Point(314, 28);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(188, 290);
            this.panel8.TabIndex = 0;
            // 
            // EditDefault24VPreboot
            // 
            this.EditDefault24VPreboot.Location = new System.Drawing.Point(122, 143);
            this.EditDefault24VPreboot.Name = "EditDefault24VPreboot";
            this.EditDefault24VPreboot.ReadOnly = true;
            this.EditDefault24VPreboot.Size = new System.Drawing.Size(58, 22);
            this.EditDefault24VPreboot.TabIndex = 72;
            this.EditDefault24VPreboot.Text = "0";
            // 
            // EditDefault12VPreboot
            // 
            this.EditDefault12VPreboot.Location = new System.Drawing.Point(61, 143);
            this.EditDefault12VPreboot.Name = "EditDefault12VPreboot";
            this.EditDefault12VPreboot.ReadOnly = true;
            this.EditDefault12VPreboot.Size = new System.Drawing.Size(58, 22);
            this.EditDefault12VPreboot.TabIndex = 71;
            this.EditDefault12VPreboot.Text = "0";
            // 
            // EditDefault24VMin
            // 
            this.EditDefault24VMin.Location = new System.Drawing.Point(122, 115);
            this.EditDefault24VMin.Name = "EditDefault24VMin";
            this.EditDefault24VMin.ReadOnly = true;
            this.EditDefault24VMin.Size = new System.Drawing.Size(58, 22);
            this.EditDefault24VMin.TabIndex = 70;
            this.EditDefault24VMin.Text = "0";
            // 
            // EditDefault12VMin
            // 
            this.EditDefault12VMin.Location = new System.Drawing.Point(61, 115);
            this.EditDefault12VMin.Name = "EditDefault12VMin";
            this.EditDefault12VMin.ReadOnly = true;
            this.EditDefault12VMin.Size = new System.Drawing.Size(58, 22);
            this.EditDefault12VMin.TabIndex = 69;
            this.EditDefault12VMin.Text = "0";
            // 
            // EditDefault24VDef
            // 
            this.EditDefault24VDef.Location = new System.Drawing.Point(122, 86);
            this.EditDefault24VDef.Name = "EditDefault24VDef";
            this.EditDefault24VDef.ReadOnly = true;
            this.EditDefault24VDef.Size = new System.Drawing.Size(58, 22);
            this.EditDefault24VDef.TabIndex = 68;
            this.EditDefault24VDef.Text = "0";
            // 
            // EditDefault12VDef
            // 
            this.EditDefault12VDef.Location = new System.Drawing.Point(61, 86);
            this.EditDefault12VDef.Name = "EditDefault12VDef";
            this.EditDefault12VDef.ReadOnly = true;
            this.EditDefault12VDef.Size = new System.Drawing.Size(58, 22);
            this.EditDefault12VDef.TabIndex = 67;
            this.EditDefault12VDef.Text = "0";
            // 
            // EditDefault12VMax
            // 
            this.EditDefault12VMax.Location = new System.Drawing.Point(61, 58);
            this.EditDefault12VMax.Name = "EditDefault12VMax";
            this.EditDefault12VMax.ReadOnly = true;
            this.EditDefault12VMax.Size = new System.Drawing.Size(58, 22);
            this.EditDefault12VMax.TabIndex = 66;
            this.EditDefault12VMax.Text = "0";
            // 
            // EditDefault24VMax
            // 
            this.EditDefault24VMax.Location = new System.Drawing.Point(122, 58);
            this.EditDefault24VMax.Name = "EditDefault24VMax";
            this.EditDefault24VMax.ReadOnly = true;
            this.EditDefault24VMax.Size = new System.Drawing.Size(58, 22);
            this.EditDefault24VMax.TabIndex = 37;
            this.EditDefault24VMax.Text = "0";
            // 
            // label11
            // 
            this.label11.Location = new System.Drawing.Point(3, 144);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(52, 23);
            this.label11.TabIndex = 73;
            this.label11.Text = "Preboot";
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(3, 115);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(52, 23);
            this.label10.TabIndex = 74;
            this.label10.Text = "Min";
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(3, 87);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(52, 23);
            this.label9.TabIndex = 75;
            this.label9.Text = "Default";
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(3, 58);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(52, 23);
            this.label8.TabIndex = 76;
            this.label8.Text = "Max";
            // 
            // StaticDefault24V
            // 
            this.StaticDefault24V.Location = new System.Drawing.Point(136, 31);
            this.StaticDefault24V.Name = "StaticDefault24V";
            this.StaticDefault24V.Size = new System.Drawing.Size(44, 23);
            this.StaticDefault24V.TabIndex = 77;
            this.StaticDefault24V.Text = "24V";
            // 
            // StaticDefault12V
            // 
            this.StaticDefault12V.Location = new System.Drawing.Point(81, 31);
            this.StaticDefault12V.Name = "StaticDefault12V";
            this.StaticDefault12V.Size = new System.Drawing.Size(44, 23);
            this.StaticDefault12V.TabIndex = 78;
            this.StaticDefault12V.Text = "12V";
            // 
            // StaticLowVoltageDefalultValue
            // 
            this.StaticLowVoltageDefalultValue.Location = new System.Drawing.Point(3, 5);
            this.StaticLowVoltageDefalultValue.Name = "StaticLowVoltageDefalultValue";
            this.StaticLowVoltageDefalultValue.Size = new System.Drawing.Size(182, 23);
            this.StaticLowVoltageDefalultValue.TabIndex = 79;
            this.StaticLowVoltageDefalultValue.Text = "Low Voltage Default Value";
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.label4);
            this.panel5.Controls.Add(this.EditPrebootThresholdValue24V);
            this.panel5.Controls.Add(this.label3);
            this.panel5.Controls.Add(this.EditPrebootThresholdValue12V);
            this.panel5.Controls.Add(this.StaticPrebootThreshold);
            this.panel5.Controls.Add(this.StaticLBPThreshold);
            this.panel5.Controls.Add(this.StaticLowVoltageThreshold24VUnit);
            this.panel5.Controls.Add(this.StaticLowVoltageThreshold12VUnit);
            this.panel5.Controls.Add(this.EditLowVoltageThresholdValue24V);
            this.panel5.Controls.Add(this.EditLowVoltageThresholdValue12V);
            this.panel5.Controls.Add(this.StaticLowVoltageThreshold24V);
            this.panel5.Controls.Add(this.StaticLowVoltageThreshold12V);
            this.panel5.Controls.Add(this.BtnLowVoltageThresholdApply);
            this.panel5.Controls.Add(this.RadioLowVoltageThresholdGet);
            this.panel5.Controls.Add(this.RadioLowVoltageThresholdSet);
            this.panel5.Controls.Add(this.StaticLowVoltageThresholdRes);
            this.panel5.Controls.Add(this.StaticLowVoltageThreshold);
            this.panel5.Location = new System.Drawing.Point(12, 150);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(296, 168);
            this.panel5.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(252, 115);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(13, 23);
            this.label4.TabIndex = 0;
            this.label4.Text = "V";
            // 
            // EditPrebootThresholdValue24V
            // 
            this.EditPrebootThresholdValue24V.Location = new System.Drawing.Point(176, 115);
            this.EditPrebootThresholdValue24V.Name = "EditPrebootThresholdValue24V";
            this.EditPrebootThresholdValue24V.Size = new System.Drawing.Size(70, 22);
            this.EditPrebootThresholdValue24V.TabIndex = 49;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(252, 86);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(13, 23);
            this.label3.TabIndex = 50;
            this.label3.Text = "V";
            // 
            // EditPrebootThresholdValue12V
            // 
            this.EditPrebootThresholdValue12V.Location = new System.Drawing.Point(176, 86);
            this.EditPrebootThresholdValue12V.Name = "EditPrebootThresholdValue12V";
            this.EditPrebootThresholdValue12V.Size = new System.Drawing.Size(70, 22);
            this.EditPrebootThresholdValue12V.TabIndex = 46;
            // 
            // StaticPrebootThreshold
            // 
            this.StaticPrebootThreshold.Location = new System.Drawing.Point(176, 60);
            this.StaticPrebootThreshold.Name = "StaticPrebootThreshold";
            this.StaticPrebootThreshold.Size = new System.Drawing.Size(108, 23);
            this.StaticPrebootThreshold.TabIndex = 51;
            this.StaticPrebootThreshold.Text = "Preboot Threshold";
            // 
            // StaticLBPThreshold
            // 
            this.StaticLBPThreshold.Location = new System.Drawing.Point(73, 60);
            this.StaticLBPThreshold.Name = "StaticLBPThreshold";
            this.StaticLBPThreshold.Size = new System.Drawing.Size(97, 23);
            this.StaticLBPThreshold.TabIndex = 52;
            this.StaticLBPThreshold.Text = "LBP Threshold";
            // 
            // StaticLowVoltageThreshold24VUnit
            // 
            this.StaticLowVoltageThreshold24VUnit.Location = new System.Drawing.Point(149, 115);
            this.StaticLowVoltageThreshold24VUnit.Name = "StaticLowVoltageThreshold24VUnit";
            this.StaticLowVoltageThreshold24VUnit.Size = new System.Drawing.Size(13, 23);
            this.StaticLowVoltageThreshold24VUnit.TabIndex = 53;
            this.StaticLowVoltageThreshold24VUnit.Text = "V";
            // 
            // StaticLowVoltageThreshold12VUnit
            // 
            this.StaticLowVoltageThreshold12VUnit.Location = new System.Drawing.Point(149, 86);
            this.StaticLowVoltageThreshold12VUnit.Name = "StaticLowVoltageThreshold12VUnit";
            this.StaticLowVoltageThreshold12VUnit.Size = new System.Drawing.Size(13, 23);
            this.StaticLowVoltageThreshold12VUnit.TabIndex = 54;
            this.StaticLowVoltageThreshold12VUnit.Text = "V";
            // 
            // EditLowVoltageThresholdValue24V
            // 
            this.EditLowVoltageThresholdValue24V.Location = new System.Drawing.Point(73, 115);
            this.EditLowVoltageThresholdValue24V.Name = "EditLowVoltageThresholdValue24V";
            this.EditLowVoltageThresholdValue24V.Size = new System.Drawing.Size(70, 22);
            this.EditLowVoltageThresholdValue24V.TabIndex = 37;
            // 
            // EditLowVoltageThresholdValue12V
            // 
            this.EditLowVoltageThresholdValue12V.Location = new System.Drawing.Point(73, 86);
            this.EditLowVoltageThresholdValue12V.Name = "EditLowVoltageThresholdValue12V";
            this.EditLowVoltageThresholdValue12V.Size = new System.Drawing.Size(70, 22);
            this.EditLowVoltageThresholdValue12V.TabIndex = 31;
            // 
            // StaticLowVoltageThreshold24V
            // 
            this.StaticLowVoltageThreshold24V.Location = new System.Drawing.Point(3, 115);
            this.StaticLowVoltageThreshold24V.Name = "StaticLowVoltageThreshold24V";
            this.StaticLowVoltageThreshold24V.Size = new System.Drawing.Size(67, 23);
            this.StaticLowVoltageThreshold24V.TabIndex = 55;
            this.StaticLowVoltageThreshold24V.Text = "24V Mode";
            // 
            // StaticLowVoltageThreshold12V
            // 
            this.StaticLowVoltageThreshold12V.Location = new System.Drawing.Point(3, 86);
            this.StaticLowVoltageThreshold12V.Name = "StaticLowVoltageThreshold12V";
            this.StaticLowVoltageThreshold12V.Size = new System.Drawing.Size(67, 23);
            this.StaticLowVoltageThreshold12V.TabIndex = 56;
            this.StaticLowVoltageThreshold12V.Text = "12V Mode";
            // 
            // BtnLowVoltageThresholdApply
            // 
            this.BtnLowVoltageThresholdApply.Location = new System.Drawing.Point(15, 34);
            this.BtnLowVoltageThresholdApply.Name = "BtnLowVoltageThresholdApply";
            this.BtnLowVoltageThresholdApply.Size = new System.Drawing.Size(72, 23);
            this.BtnLowVoltageThresholdApply.TabIndex = 31;
            this.BtnLowVoltageThresholdApply.Text = "Apply";
            this.BtnLowVoltageThresholdApply.Click += new System.EventHandler(this.BtnLowVoltageThresholdApply_Click);
            // 
            // RadioLowVoltageThresholdGet
            // 
            this.RadioLowVoltageThresholdGet.Location = new System.Drawing.Point(176, 34);
            this.RadioLowVoltageThresholdGet.Name = "RadioLowVoltageThresholdGet";
            this.RadioLowVoltageThresholdGet.Size = new System.Drawing.Size(49, 23);
            this.RadioLowVoltageThresholdGet.TabIndex = 19;
            this.RadioLowVoltageThresholdGet.Text = "Get";
            // 
            // RadioLowVoltageThresholdSet
            // 
            this.RadioLowVoltageThresholdSet.Checked = true;
            this.RadioLowVoltageThresholdSet.Location = new System.Drawing.Point(121, 34);
            this.RadioLowVoltageThresholdSet.Name = "RadioLowVoltageThresholdSet";
            this.RadioLowVoltageThresholdSet.Size = new System.Drawing.Size(49, 23);
            this.RadioLowVoltageThresholdSet.TabIndex = 19;
            this.RadioLowVoltageThresholdSet.TabStop = true;
            this.RadioLowVoltageThresholdSet.Text = "Set";
            this.RadioLowVoltageThresholdSet.CheckedChanged += new System.EventHandler(this.RadioLowVoltageThresholdSet_CheckedChanged);
            // 
            // StaticLowVoltageThresholdRes
            // 
            this.StaticLowVoltageThresholdRes.Location = new System.Drawing.Point(176, 5);
            this.StaticLowVoltageThresholdRes.Name = "StaticLowVoltageThresholdRes";
            this.StaticLowVoltageThresholdRes.Size = new System.Drawing.Size(70, 23);
            this.StaticLowVoltageThresholdRes.TabIndex = 57;
            this.StaticLowVoltageThresholdRes.Text = "Never Try";
            // 
            // StaticLowVoltageThreshold
            // 
            this.StaticLowVoltageThreshold.Location = new System.Drawing.Point(3, 5);
            this.StaticLowVoltageThreshold.Name = "StaticLowVoltageThreshold";
            this.StaticLowVoltageThreshold.Size = new System.Drawing.Size(143, 23);
            this.StaticLowVoltageThreshold.TabIndex = 58;
            this.StaticLowVoltageThreshold.Text = "Low Voltage Threshold";
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.EditProtectionDelayLowHard);
            this.panel4.Controls.Add(this.StaticProtectionDelayLowHard);
            this.panel4.Controls.Add(this.EditProtectionDelayLow);
            this.panel4.Controls.Add(this.StaticProtectionDelayLow);
            this.panel4.Controls.Add(this.BtnProtectionApply);
            this.panel4.Controls.Add(this.RadioProtectionGet);
            this.panel4.Controls.Add(this.RadioProtectionSet);
            this.panel4.Controls.Add(this.StaticLowThresholdRes);
            this.panel4.Controls.Add(this.StaticLowThreshold);
            this.panel4.Location = new System.Drawing.Point(12, 28);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(296, 116);
            this.panel4.TabIndex = 2;
            // 
            // EditProtectionDelayLowHard
            // 
            this.EditProtectionDelayLowHard.Location = new System.Drawing.Point(121, 86);
            this.EditProtectionDelayLowHard.Name = "EditProtectionDelayLowHard";
            this.EditProtectionDelayLowHard.Size = new System.Drawing.Size(100, 22);
            this.EditProtectionDelayLowHard.TabIndex = 30;
            this.EditProtectionDelayLowHard.Text = "60";
            // 
            // StaticProtectionDelayLowHard
            // 
            this.StaticProtectionDelayLowHard.Location = new System.Drawing.Point(3, 86);
            this.StaticProtectionDelayLowHard.Name = "StaticProtectionDelayLowHard";
            this.StaticProtectionDelayLowHard.Size = new System.Drawing.Size(112, 23);
            this.StaticProtectionDelayLowHard.TabIndex = 31;
            this.StaticProtectionDelayLowHard.Text = "Low Hard Delay";
            // 
            // EditProtectionDelayLow
            // 
            this.EditProtectionDelayLow.Location = new System.Drawing.Point(121, 57);
            this.EditProtectionDelayLow.Name = "EditProtectionDelayLow";
            this.EditProtectionDelayLow.Size = new System.Drawing.Size(100, 22);
            this.EditProtectionDelayLow.TabIndex = 17;
            this.EditProtectionDelayLow.Text = "30";
            // 
            // StaticProtectionDelayLow
            // 
            this.StaticProtectionDelayLow.Location = new System.Drawing.Point(3, 57);
            this.StaticProtectionDelayLow.Name = "StaticProtectionDelayLow";
            this.StaticProtectionDelayLow.Size = new System.Drawing.Size(112, 23);
            this.StaticProtectionDelayLow.TabIndex = 32;
            this.StaticProtectionDelayLow.Text = "Low Delay";
            // 
            // BtnProtectionApply
            // 
            this.BtnProtectionApply.Location = new System.Drawing.Point(15, 31);
            this.BtnProtectionApply.Name = "BtnProtectionApply";
            this.BtnProtectionApply.Size = new System.Drawing.Size(72, 23);
            this.BtnProtectionApply.TabIndex = 19;
            this.BtnProtectionApply.Text = "Apply";
            this.BtnProtectionApply.Click += new System.EventHandler(this.BtnProtectionApply_Click);
            // 
            // RadioProtectionGet
            // 
            this.RadioProtectionGet.Location = new System.Drawing.Point(176, 31);
            this.RadioProtectionGet.Name = "RadioProtectionGet";
            this.RadioProtectionGet.Size = new System.Drawing.Size(49, 23);
            this.RadioProtectionGet.TabIndex = 19;
            this.RadioProtectionGet.Text = "Get";
            // 
            // RadioProtectionSet
            // 
            this.RadioProtectionSet.Checked = true;
            this.RadioProtectionSet.Location = new System.Drawing.Point(121, 31);
            this.RadioProtectionSet.Name = "RadioProtectionSet";
            this.RadioProtectionSet.Size = new System.Drawing.Size(49, 23);
            this.RadioProtectionSet.TabIndex = 19;
            this.RadioProtectionSet.TabStop = true;
            this.RadioProtectionSet.Text = "Set";
            // 
            // StaticLowThresholdRes
            // 
            this.StaticLowThresholdRes.Location = new System.Drawing.Point(176, 5);
            this.StaticLowThresholdRes.Name = "StaticLowThresholdRes";
            this.StaticLowThresholdRes.Size = new System.Drawing.Size(70, 23);
            this.StaticLowThresholdRes.TabIndex = 33;
            this.StaticLowThresholdRes.Text = "Never Try";
            // 
            // StaticLowThreshold
            // 
            this.StaticLowThreshold.Location = new System.Drawing.Point(3, 5);
            this.StaticLowThreshold.Name = "StaticLowThreshold";
            this.StaticLowThreshold.Size = new System.Drawing.Size(143, 23);
            this.StaticLowThreshold.TabIndex = 34;
            this.StaticLowThreshold.Text = "Low Delay Threshold";
            // 
            // ChkEnableLowBatterProtection
            // 
            this.ChkEnableLowBatterProtection.Location = new System.Drawing.Point(161, 4);
            this.ChkEnableLowBatterProtection.Name = "ChkEnableLowBatterProtection";
            this.ChkEnableLowBatterProtection.Size = new System.Drawing.Size(100, 23);
            this.ChkEnableLowBatterProtection.TabIndex = 21;
            this.ChkEnableLowBatterProtection.Text = "Post-boot";
            this.ChkEnableLowBatterProtection.CheckStateChanged += new System.EventHandler(this.ChkEnableLowBatterProtection_CheckStateChanged);
            // 
            // StaticBatteryVoltage
            // 
            this.StaticBatteryVoltage.Location = new System.Drawing.Point(12, 4);
            this.StaticBatteryVoltage.Name = "StaticBatteryVoltage";
            this.StaticBatteryVoltage.Size = new System.Drawing.Size(143, 23);
            this.StaticBatteryVoltage.TabIndex = 22;
            this.StaticBatteryVoltage.Text = "Low Battery Protection";
            // 
            // MainTabPage
            // 
            this.MainTabPage.Controls.Add(this.panel12);
            this.MainTabPage.Controls.Add(this.panel11);
            this.MainTabPage.Controls.Add(this.panel7);
            this.MainTabPage.Controls.Add(this.panel9);
            this.MainTabPage.Controls.Add(this.CommonPanel);
            this.MainTabPage.Controls.Add(this.panel6);
            this.MainTabPage.Location = new System.Drawing.Point(4, 22);
            this.MainTabPage.Name = "MainTabPage";
            this.MainTabPage.Size = new System.Drawing.Size(738, 331);
            this.MainTabPage.TabIndex = 0;
            this.MainTabPage.Text = "Common";
            // 
            // panel12
            // 
            this.panel12.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel12.Controls.Add(this.ChkEnablePrePowerOff);
            this.panel12.Controls.Add(this.EditPrePowerOffAlarmDelayTime);
            this.panel12.Controls.Add(this.labelPrePowerOffAlarmDelay);
            this.panel12.Controls.Add(this.BtnPrePowerOffDelayApply);
            this.panel12.Controls.Add(this.RadioPrePowerDelayGet);
            this.panel12.Controls.Add(this.RadioPrePowerDelaySet);
            this.panel12.Controls.Add(this.StaticPrePowerOffDelayRes);
            this.panel12.Controls.Add(this.label5);
            this.panel12.Location = new System.Drawing.Point(535, 136);
            this.panel12.Name = "panel12";
            this.panel12.Size = new System.Drawing.Size(189, 163);
            this.panel12.TabIndex = 5;
            // 
            // ChkEnablePrePowerOff
            // 
            this.ChkEnablePrePowerOff.Location = new System.Drawing.Point(10, 30);
            this.ChkEnablePrePowerOff.Name = "ChkEnablePrePowerOff";
            this.ChkEnablePrePowerOff.Size = new System.Drawing.Size(62, 23);
            this.ChkEnablePrePowerOff.TabIndex = 35;
            this.ChkEnablePrePowerOff.Text = "Enable";
            this.ChkEnablePrePowerOff.CheckStateChanged += new System.EventHandler(this.ChkEnablePrePowerOff_CheckStateChanged);
            // 
            // EditPrePowerOffAlarmDelayTime
            // 
            this.EditPrePowerOffAlarmDelayTime.Location = new System.Drawing.Point(78, 91);
            this.EditPrePowerOffAlarmDelayTime.Name = "EditPrePowerOffAlarmDelayTime";
            this.EditPrePowerOffAlarmDelayTime.Size = new System.Drawing.Size(100, 22);
            this.EditPrePowerOffAlarmDelayTime.TabIndex = 17;
            this.EditPrePowerOffAlarmDelayTime.Text = "600";
            // 
            // labelPrePowerOffAlarmDelay
            // 
            this.labelPrePowerOffAlarmDelay.Location = new System.Drawing.Point(10, 91);
            this.labelPrePowerOffAlarmDelay.Name = "labelPrePowerOffAlarmDelay";
            this.labelPrePowerOffAlarmDelay.Size = new System.Drawing.Size(112, 23);
            this.labelPrePowerOffAlarmDelay.TabIndex = 32;
            this.labelPrePowerOffAlarmDelay.Text = "Delay";
            // 
            // BtnPrePowerOffDelayApply
            // 
            this.BtnPrePowerOffDelayApply.Location = new System.Drawing.Point(12, 57);
            this.BtnPrePowerOffDelayApply.Name = "BtnPrePowerOffDelayApply";
            this.BtnPrePowerOffDelayApply.Size = new System.Drawing.Size(72, 23);
            this.BtnPrePowerOffDelayApply.TabIndex = 19;
            this.BtnPrePowerOffDelayApply.Text = "Apply";
            this.BtnPrePowerOffDelayApply.Click += new System.EventHandler(this.BtnPrePowerOffDelayApply_Click);
            // 
            // RadioPrePowerDelayGet
            // 
            this.RadioPrePowerDelayGet.Location = new System.Drawing.Point(135, 57);
            this.RadioPrePowerDelayGet.Name = "RadioPrePowerDelayGet";
            this.RadioPrePowerDelayGet.Size = new System.Drawing.Size(49, 23);
            this.RadioPrePowerDelayGet.TabIndex = 19;
            this.RadioPrePowerDelayGet.Text = "Get";
            // 
            // RadioPrePowerDelaySet
            // 
            this.RadioPrePowerDelaySet.Checked = true;
            this.RadioPrePowerDelaySet.Location = new System.Drawing.Point(90, 57);
            this.RadioPrePowerDelaySet.Name = "RadioPrePowerDelaySet";
            this.RadioPrePowerDelaySet.Size = new System.Drawing.Size(49, 23);
            this.RadioPrePowerDelaySet.TabIndex = 19;
            this.RadioPrePowerDelaySet.TabStop = true;
            this.RadioPrePowerDelaySet.Text = "Set";
            // 
            // StaticPrePowerOffDelayRes
            // 
            this.StaticPrePowerOffDelayRes.Location = new System.Drawing.Point(114, 13);
            this.StaticPrePowerOffDelayRes.Name = "StaticPrePowerOffDelayRes";
            this.StaticPrePowerOffDelayRes.Size = new System.Drawing.Size(66, 23);
            this.StaticPrePowerOffDelayRes.TabIndex = 33;
            this.StaticPrePowerOffDelayRes.Text = "Never Try";
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(8, 13);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(143, 23);
            this.label5.TabIndex = 34;
            this.label5.Text = "Pre PowerOff";
            // 
            // panel11
            // 
            this.panel11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel11.Controls.Add(this.CmbShutdownSource);
            this.panel11.Controls.Add(this.DomianUDShutdownStatus);
            this.panel11.Controls.Add(this.radioShutdownSourceGet);
            this.panel11.Controls.Add(this.radioShutdownSoruceSet);
            this.panel11.Controls.Add(this.BtnShutdwonSource);
            this.panel11.Controls.Add(this.StaticShutdownRes);
            this.panel11.Controls.Add(this.labelShutdownSource);
            this.panel11.Location = new System.Drawing.Point(535, 11);
            this.panel11.Name = "panel11";
            this.panel11.Size = new System.Drawing.Size(189, 119);
            this.panel11.TabIndex = 4;
            // 
            // CmbShutdownSource
            // 
            this.CmbShutdownSource.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbShutdownSource.Items.AddRange(new object[] {
            "Power Button",
            "Ignition"});
            this.CmbShutdownSource.Location = new System.Drawing.Point(5, 61);
            this.CmbShutdownSource.Name = "CmbShutdownSource";
            this.CmbShutdownSource.Size = new System.Drawing.Size(95, 20);
            this.CmbShutdownSource.TabIndex = 83;
            // 
            // DomianUDShutdownStatus
            // 
            this.DomianUDShutdownStatus.Location = new System.Drawing.Point(106, 59);
            this.DomianUDShutdownStatus.Name = "DomianUDShutdownStatus";
            this.DomianUDShutdownStatus.ReadOnly = true;
            this.DomianUDShutdownStatus.Size = new System.Drawing.Size(72, 22);
            this.DomianUDShutdownStatus.TabIndex = 82;
            // 
            // radioShutdownSourceGet
            // 
            this.radioShutdownSourceGet.Location = new System.Drawing.Point(129, 27);
            this.radioShutdownSourceGet.Name = "radioShutdownSourceGet";
            this.radioShutdownSourceGet.Size = new System.Drawing.Size(49, 22);
            this.radioShutdownSourceGet.TabIndex = 81;
            this.radioShutdownSourceGet.Text = "Get";
            // 
            // radioShutdownSoruceSet
            // 
            this.radioShutdownSoruceSet.Checked = true;
            this.radioShutdownSoruceSet.Location = new System.Drawing.Point(89, 27);
            this.radioShutdownSoruceSet.Name = "radioShutdownSoruceSet";
            this.radioShutdownSoruceSet.Size = new System.Drawing.Size(49, 22);
            this.radioShutdownSoruceSet.TabIndex = 80;
            this.radioShutdownSoruceSet.TabStop = true;
            this.radioShutdownSoruceSet.Text = "Set";
            // 
            // BtnShutdwonSource
            // 
            this.BtnShutdwonSource.Location = new System.Drawing.Point(5, 27);
            this.BtnShutdwonSource.Name = "BtnShutdwonSource";
            this.BtnShutdwonSource.Size = new System.Drawing.Size(72, 22);
            this.BtnShutdwonSource.TabIndex = 79;
            this.BtnShutdwonSource.Text = "Apply";
            this.BtnShutdwonSource.Click += new System.EventHandler(this.BtnShutdwonSource_Click);
            // 
            // StaticShutdownRes
            // 
            this.StaticShutdownRes.Location = new System.Drawing.Point(114, 4);
            this.StaticShutdownRes.Name = "StaticShutdownRes";
            this.StaticShutdownRes.Size = new System.Drawing.Size(70, 23);
            this.StaticShutdownRes.TabIndex = 84;
            this.StaticShutdownRes.Text = "Never Try";
            // 
            // labelShutdownSource
            // 
            this.labelShutdownSource.Location = new System.Drawing.Point(3, 4);
            this.labelShutdownSource.Name = "labelShutdownSource";
            this.labelShutdownSource.Size = new System.Drawing.Size(109, 23);
            this.labelShutdownSource.TabIndex = 78;
            this.labelShutdownSource.Text = "Shutdown Source";
            // 
            // panel7
            // 
            this.panel7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel7.Controls.Add(this.ChkEnableShutdownDelay);
            this.panel7.Controls.Add(this.EditShutdownDelayTime);
            this.panel7.Controls.Add(this.labelShutdownDelay);
            this.panel7.Controls.Add(this.BtnForceShutdownDelayApply);
            this.panel7.Controls.Add(this.RadioForceShutdownDelayGet);
            this.panel7.Controls.Add(this.RadioForceShutdownDelaySet);
            this.panel7.Controls.Add(this.StaticForceShutdownDelayRes);
            this.panel7.Controls.Add(this.label6);
            this.panel7.Location = new System.Drawing.Point(3, 233);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(261, 95);
            this.panel7.TabIndex = 3;
            // 
            // ChkEnableShutdownDelay
            // 
            this.ChkEnableShutdownDelay.Location = new System.Drawing.Point(108, -1);
            this.ChkEnableShutdownDelay.Name = "ChkEnableShutdownDelay";
            this.ChkEnableShutdownDelay.Size = new System.Drawing.Size(62, 23);
            this.ChkEnableShutdownDelay.TabIndex = 35;
            this.ChkEnableShutdownDelay.Text = "Enable";
            this.ChkEnableShutdownDelay.CheckStateChanged += new System.EventHandler(this.ChkEnableShutdownDelay_CheckStateChanged);
            // 
            // EditShutdownDelayTime
            // 
            this.EditShutdownDelayTime.Location = new System.Drawing.Point(119, 55);
            this.EditShutdownDelayTime.Name = "EditShutdownDelayTime";
            this.EditShutdownDelayTime.Size = new System.Drawing.Size(100, 22);
            this.EditShutdownDelayTime.TabIndex = 17;
            this.EditShutdownDelayTime.Text = "600";
            // 
            // labelShutdownDelay
            // 
            this.labelShutdownDelay.Location = new System.Drawing.Point(9, 58);
            this.labelShutdownDelay.Name = "labelShutdownDelay";
            this.labelShutdownDelay.Size = new System.Drawing.Size(112, 23);
            this.labelShutdownDelay.TabIndex = 32;
            this.labelShutdownDelay.Text = "Delay";
            // 
            // BtnForceShutdownDelayApply
            // 
            this.BtnForceShutdownDelayApply.Location = new System.Drawing.Point(13, 29);
            this.BtnForceShutdownDelayApply.Name = "BtnForceShutdownDelayApply";
            this.BtnForceShutdownDelayApply.Size = new System.Drawing.Size(72, 23);
            this.BtnForceShutdownDelayApply.TabIndex = 19;
            this.BtnForceShutdownDelayApply.Text = "Apply";
            this.BtnForceShutdownDelayApply.Click += new System.EventHandler(this.BtnForceShutdownDelayApply_Click);
            // 
            // RadioForceShutdownDelayGet
            // 
            this.RadioForceShutdownDelayGet.Location = new System.Drawing.Point(174, 29);
            this.RadioForceShutdownDelayGet.Name = "RadioForceShutdownDelayGet";
            this.RadioForceShutdownDelayGet.Size = new System.Drawing.Size(49, 23);
            this.RadioForceShutdownDelayGet.TabIndex = 19;
            this.RadioForceShutdownDelayGet.Text = "Get";
            // 
            // RadioForceShutdownDelaySet
            // 
            this.RadioForceShutdownDelaySet.Checked = true;
            this.RadioForceShutdownDelaySet.Location = new System.Drawing.Point(119, 29);
            this.RadioForceShutdownDelaySet.Name = "RadioForceShutdownDelaySet";
            this.RadioForceShutdownDelaySet.Size = new System.Drawing.Size(49, 23);
            this.RadioForceShutdownDelaySet.TabIndex = 19;
            this.RadioForceShutdownDelaySet.TabStop = true;
            this.RadioForceShutdownDelaySet.Text = "Set";
            // 
            // StaticForceShutdownDelayRes
            // 
            this.StaticForceShutdownDelayRes.Location = new System.Drawing.Point(190, 3);
            this.StaticForceShutdownDelayRes.Name = "StaticForceShutdownDelayRes";
            this.StaticForceShutdownDelayRes.Size = new System.Drawing.Size(66, 23);
            this.StaticForceShutdownDelayRes.TabIndex = 33;
            this.StaticForceShutdownDelayRes.Text = "Never Try";
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(10, 3);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(143, 23);
            this.label6.TabIndex = 34;
            this.label6.Text = "Force Shutdown";
            // 
            // panel9
            // 
            this.panel9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel9.Controls.Add(this.StaticLastWakeupSourceRes);
            this.panel9.Controls.Add(this.StaticLastWakeupSource);
            this.panel9.Controls.Add(this.CmBxWakeupSource);
            this.panel9.Controls.Add(this.DomainUDWakeupSourceStatus);
            this.panel9.Controls.Add(this.RadioWakeupSourceGet);
            this.panel9.Controls.Add(this.RadioWakeupSourceSet);
            this.panel9.Controls.Add(this.BtnWakeupSourceApply);
            this.panel9.Controls.Add(this.StaticWakeupSourceRes);
            this.panel9.Controls.Add(this.StaticWakeupSource);
            this.panel9.Location = new System.Drawing.Point(270, 136);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(261, 114);
            this.panel9.TabIndex = 0;
            // 
            // StaticLastWakeupSourceRes
            // 
            this.StaticLastWakeupSourceRes.Location = new System.Drawing.Point(188, 87);
            this.StaticLastWakeupSourceRes.Name = "StaticLastWakeupSourceRes";
            this.StaticLastWakeupSourceRes.Size = new System.Drawing.Size(70, 23);
            this.StaticLastWakeupSourceRes.TabIndex = 0;
            this.StaticLastWakeupSourceRes.Text = "N/A";
            // 
            // StaticLastWakeupSource
            // 
            this.StaticLastWakeupSource.Location = new System.Drawing.Point(4, 87);
            this.StaticLastWakeupSource.Name = "StaticLastWakeupSource";
            this.StaticLastWakeupSource.Size = new System.Drawing.Size(135, 23);
            this.StaticLastWakeupSource.TabIndex = 1;
            this.StaticLastWakeupSource.Text = "Last Wakeup Source";
            // 
            // CmBxWakeupSource
            // 
            this.CmBxWakeupSource.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmBxWakeupSource.Location = new System.Drawing.Point(4, 57);
            this.CmBxWakeupSource.Name = "CmBxWakeupSource";
            this.CmBxWakeupSource.Size = new System.Drawing.Size(117, 20);
            this.CmBxWakeupSource.TabIndex = 75;
            // 
            // DomainUDWakeupSourceStatus
            // 
            this.DomainUDWakeupSourceStatus.Location = new System.Drawing.Point(133, 57);
            this.DomainUDWakeupSourceStatus.Name = "DomainUDWakeupSourceStatus";
            this.DomainUDWakeupSourceStatus.ReadOnly = true;
            this.DomainUDWakeupSourceStatus.Size = new System.Drawing.Size(112, 22);
            this.DomainUDWakeupSourceStatus.TabIndex = 74;
            // 
            // RadioWakeupSourceGet
            // 
            this.RadioWakeupSourceGet.Location = new System.Drawing.Point(188, 29);
            this.RadioWakeupSourceGet.Name = "RadioWakeupSourceGet";
            this.RadioWakeupSourceGet.Size = new System.Drawing.Size(49, 22);
            this.RadioWakeupSourceGet.TabIndex = 73;
            this.RadioWakeupSourceGet.Text = "Get";
            // 
            // RadioWakeupSourceSet
            // 
            this.RadioWakeupSourceSet.Checked = true;
            this.RadioWakeupSourceSet.Location = new System.Drawing.Point(133, 29);
            this.RadioWakeupSourceSet.Name = "RadioWakeupSourceSet";
            this.RadioWakeupSourceSet.Size = new System.Drawing.Size(49, 22);
            this.RadioWakeupSourceSet.TabIndex = 72;
            this.RadioWakeupSourceSet.TabStop = true;
            this.RadioWakeupSourceSet.Text = "Set";
            // 
            // BtnWakeupSourceApply
            // 
            this.BtnWakeupSourceApply.Location = new System.Drawing.Point(12, 29);
            this.BtnWakeupSourceApply.Name = "BtnWakeupSourceApply";
            this.BtnWakeupSourceApply.Size = new System.Drawing.Size(72, 22);
            this.BtnWakeupSourceApply.TabIndex = 71;
            this.BtnWakeupSourceApply.Text = "Apply";
            this.BtnWakeupSourceApply.Click += new System.EventHandler(this.BtnWakeupSourceApply_Click);
            // 
            // StaticWakeupSourceRes
            // 
            this.StaticWakeupSourceRes.Location = new System.Drawing.Point(188, 3);
            this.StaticWakeupSourceRes.Name = "StaticWakeupSourceRes";
            this.StaticWakeupSourceRes.Size = new System.Drawing.Size(70, 23);
            this.StaticWakeupSourceRes.TabIndex = 76;
            this.StaticWakeupSourceRes.Text = "Never Try";
            // 
            // StaticWakeupSource
            // 
            this.StaticWakeupSource.Location = new System.Drawing.Point(4, 3);
            this.StaticWakeupSource.Name = "StaticWakeupSource";
            this.StaticWakeupSource.Size = new System.Drawing.Size(109, 23);
            this.StaticWakeupSource.TabIndex = 77;
            this.StaticWakeupSource.Text = "Wakeup Source";
            // 
            // CommonPanel
            // 
            this.CommonPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CommonPanel.Controls.Add(this.StaticPlatformName);
            this.CommonPanel.Controls.Add(this.label1);
            this.CommonPanel.Controls.Add(this.BtnShutdown);
            this.CommonPanel.Controls.Add(this.CbBatteryVoltageModeValue);
            this.CommonPanel.Controls.Add(this.BtnLoadDefault);
            this.CommonPanel.Controls.Add(this.StaticCurIgnStatusValue);
            this.CommonPanel.Controls.Add(this.StaticCurBatteryVoltageValue);
            this.CommonPanel.Controls.Add(this.StaticCurIgnStatus);
            this.CommonPanel.Controls.Add(this.StaticCurBatteryVoltage);
            this.CommonPanel.Controls.Add(this.StaticBatteryVoltageCBMode);
            this.CommonPanel.Controls.Add(this.StaticFirmwareVersionValue);
            this.CommonPanel.Controls.Add(this.StaticFirmwareVersion);
            this.CommonPanel.Controls.Add(this.StaticLibVersionValue);
            this.CommonPanel.Controls.Add(this.StaticLibVersion);
            this.CommonPanel.Location = new System.Drawing.Point(3, 11);
            this.CommonPanel.Name = "CommonPanel";
            this.CommonPanel.Size = new System.Drawing.Size(261, 216);
            this.CommonPanel.TabIndex = 1;
            // 
            // BtnShutdown
            // 
            this.BtnShutdown.Location = new System.Drawing.Point(13, 179);
            this.BtnShutdown.Name = "BtnShutdown";
            this.BtnShutdown.Size = new System.Drawing.Size(108, 23);
            this.BtnShutdown.TabIndex = 64;
            this.BtnShutdown.Text = "Software PowerOff";
            this.BtnShutdown.UseVisualStyleBackColor = true;
            this.BtnShutdown.Click += new System.EventHandler(this.BtnShutdown_Click);
            // 
            // CbBatteryVoltageModeValue
            // 
            this.CbBatteryVoltageModeValue.FormattingEnabled = true;
            this.CbBatteryVoltageModeValue.Items.AddRange(new object[] {
            "24V",
            "12V"});
            this.CbBatteryVoltageModeValue.Location = new System.Drawing.Point(141, 87);
            this.CbBatteryVoltageModeValue.Name = "CbBatteryVoltageModeValue";
            this.CbBatteryVoltageModeValue.Size = new System.Drawing.Size(100, 20);
            this.CbBatteryVoltageModeValue.TabIndex = 63;
            this.CbBatteryVoltageModeValue.SelectedIndexChanged += new System.EventHandler(this.CbBatteryVoltageModeValue_SelectedIndexChanged);
            // 
            // BtnLoadDefault
            // 
            this.BtnLoadDefault.Location = new System.Drawing.Point(142, 179);
            this.BtnLoadDefault.Name = "BtnLoadDefault";
            this.BtnLoadDefault.Size = new System.Drawing.Size(100, 23);
            this.BtnLoadDefault.TabIndex = 57;
            this.BtnLoadDefault.Text = "Load Default";
            this.BtnLoadDefault.Click += new System.EventHandler(this.BtnLoadDefault_Click);
            // 
            // StaticCurIgnStatusValue
            // 
            this.StaticCurIgnStatusValue.Location = new System.Drawing.Point(142, 144);
            this.StaticCurIgnStatusValue.Name = "StaticCurIgnStatusValue";
            this.StaticCurIgnStatusValue.Size = new System.Drawing.Size(100, 22);
            this.StaticCurIgnStatusValue.TabIndex = 56;
            // 
            // StaticCurBatteryVoltageValue
            // 
            this.StaticCurBatteryVoltageValue.Location = new System.Drawing.Point(142, 113);
            this.StaticCurBatteryVoltageValue.Name = "StaticCurBatteryVoltageValue";
            this.StaticCurBatteryVoltageValue.Size = new System.Drawing.Size(100, 22);
            this.StaticCurBatteryVoltageValue.TabIndex = 55;
            // 
            // StaticCurIgnStatus
            // 
            this.StaticCurIgnStatus.Location = new System.Drawing.Point(10, 147);
            this.StaticCurIgnStatus.Name = "StaticCurIgnStatus";
            this.StaticCurIgnStatus.Size = new System.Drawing.Size(125, 23);
            this.StaticCurIgnStatus.TabIndex = 58;
            this.StaticCurIgnStatus.Text = "Ignition Status :";
            // 
            // StaticCurBatteryVoltage
            // 
            this.StaticCurBatteryVoltage.Location = new System.Drawing.Point(10, 118);
            this.StaticCurBatteryVoltage.Name = "StaticCurBatteryVoltage";
            this.StaticCurBatteryVoltage.Size = new System.Drawing.Size(125, 23);
            this.StaticCurBatteryVoltage.TabIndex = 59;
            this.StaticCurBatteryVoltage.Text = "Battery Voltage :";
            // 
            // StaticBatteryVoltageCBMode
            // 
            this.StaticBatteryVoltageCBMode.Location = new System.Drawing.Point(10, 89);
            this.StaticBatteryVoltageCBMode.Name = "StaticBatteryVoltageCBMode";
            this.StaticBatteryVoltageCBMode.Size = new System.Drawing.Size(125, 23);
            this.StaticBatteryVoltageCBMode.TabIndex = 60;
            this.StaticBatteryVoltageCBMode.Text = "Car Battery Mode :";
            // 
            // StaticFirmwareVersionValue
            // 
            this.StaticFirmwareVersionValue.Location = new System.Drawing.Point(141, 31);
            this.StaticFirmwareVersionValue.Name = "StaticFirmwareVersionValue";
            this.StaticFirmwareVersionValue.Size = new System.Drawing.Size(100, 22);
            this.StaticFirmwareVersionValue.TabIndex = 53;
            // 
            // StaticFirmwareVersion
            // 
            this.StaticFirmwareVersion.Location = new System.Drawing.Point(11, 38);
            this.StaticFirmwareVersion.Name = "StaticFirmwareVersion";
            this.StaticFirmwareVersion.Size = new System.Drawing.Size(125, 23);
            this.StaticFirmwareVersion.TabIndex = 61;
            this.StaticFirmwareVersion.Text = "Firmware Version : ";
            // 
            // StaticLibVersionValue
            // 
            this.StaticLibVersionValue.Location = new System.Drawing.Point(141, 6);
            this.StaticLibVersionValue.Name = "StaticLibVersionValue";
            this.StaticLibVersionValue.Size = new System.Drawing.Size(100, 22);
            this.StaticLibVersionValue.TabIndex = 52;
            // 
            // StaticLibVersion
            // 
            this.StaticLibVersion.Location = new System.Drawing.Point(11, 9);
            this.StaticLibVersion.Name = "StaticLibVersion";
            this.StaticLibVersion.Size = new System.Drawing.Size(125, 23);
            this.StaticLibVersion.TabIndex = 62;
            this.StaticLibVersion.Text = "Library Version : ";
            // 
            // panel6
            // 
            this.panel6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel6.Controls.Add(this.DomainUDModeSwitchKeepAliveMode);
            this.panel6.Controls.Add(this.DomainUDModeSwitchATMode);
            this.panel6.Controls.Add(this.StaticModeSwitchKeepAliveMode);
            this.panel6.Controls.Add(this.StaticModeSwitchATMode);
            this.panel6.Controls.Add(this.RadioModeSwitchGet);
            this.panel6.Controls.Add(this.RadioModeSwitchSet);
            this.panel6.Controls.Add(this.BtnModeSwitchApply);
            this.panel6.Controls.Add(this.StaticModeSwitchRes);
            this.panel6.Controls.Add(this.StaticModeSwitch);
            this.panel6.Location = new System.Drawing.Point(270, 11);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(261, 119);
            this.panel6.TabIndex = 2;
            // 
            // DomainUDModeSwitchKeepAliveMode
            // 
            this.DomainUDModeSwitchKeepAliveMode.Location = new System.Drawing.Point(133, 90);
            this.DomainUDModeSwitchKeepAliveMode.Name = "DomainUDModeSwitchKeepAliveMode";
            this.DomainUDModeSwitchKeepAliveMode.ReadOnly = true;
            this.DomainUDModeSwitchKeepAliveMode.Size = new System.Drawing.Size(112, 22);
            this.DomainUDModeSwitchKeepAliveMode.TabIndex = 66;
            // 
            // DomainUDModeSwitchATMode
            // 
            this.DomainUDModeSwitchATMode.Location = new System.Drawing.Point(133, 59);
            this.DomainUDModeSwitchATMode.Name = "DomainUDModeSwitchATMode";
            this.DomainUDModeSwitchATMode.ReadOnly = true;
            this.DomainUDModeSwitchATMode.Size = new System.Drawing.Size(112, 22);
            this.DomainUDModeSwitchATMode.TabIndex = 65;
            // 
            // StaticModeSwitchKeepAliveMode
            // 
            this.StaticModeSwitchKeepAliveMode.Location = new System.Drawing.Point(12, 90);
            this.StaticModeSwitchKeepAliveMode.Name = "StaticModeSwitchKeepAliveMode";
            this.StaticModeSwitchKeepAliveMode.Size = new System.Drawing.Size(115, 23);
            this.StaticModeSwitchKeepAliveMode.TabIndex = 67;
            this.StaticModeSwitchKeepAliveMode.Text = "Keep Alive Mode :";
            // 
            // StaticModeSwitchATMode
            // 
            this.StaticModeSwitchATMode.Location = new System.Drawing.Point(12, 57);
            this.StaticModeSwitchATMode.Name = "StaticModeSwitchATMode";
            this.StaticModeSwitchATMode.Size = new System.Drawing.Size(115, 23);
            this.StaticModeSwitchATMode.TabIndex = 68;
            this.StaticModeSwitchATMode.Text = "AT Mode :";
            // 
            // RadioModeSwitchGet
            // 
            this.RadioModeSwitchGet.Location = new System.Drawing.Point(188, 30);
            this.RadioModeSwitchGet.Name = "RadioModeSwitchGet";
            this.RadioModeSwitchGet.Size = new System.Drawing.Size(49, 22);
            this.RadioModeSwitchGet.TabIndex = 35;
            this.RadioModeSwitchGet.Text = "Get";
            // 
            // RadioModeSwitchSet
            // 
            this.RadioModeSwitchSet.Checked = true;
            this.RadioModeSwitchSet.Location = new System.Drawing.Point(133, 30);
            this.RadioModeSwitchSet.Name = "RadioModeSwitchSet";
            this.RadioModeSwitchSet.Size = new System.Drawing.Size(49, 22);
            this.RadioModeSwitchSet.TabIndex = 19;
            this.RadioModeSwitchSet.TabStop = true;
            this.RadioModeSwitchSet.Text = "Set";
            // 
            // BtnModeSwitchApply
            // 
            this.BtnModeSwitchApply.Location = new System.Drawing.Point(12, 29);
            this.BtnModeSwitchApply.Name = "BtnModeSwitchApply";
            this.BtnModeSwitchApply.Size = new System.Drawing.Size(72, 22);
            this.BtnModeSwitchApply.TabIndex = 19;
            this.BtnModeSwitchApply.Text = "Apply";
            this.BtnModeSwitchApply.Click += new System.EventHandler(this.BtnModeSwitchApply_Click);
            // 
            // StaticModeSwitchRes
            // 
            this.StaticModeSwitchRes.Location = new System.Drawing.Point(188, 4);
            this.StaticModeSwitchRes.Name = "StaticModeSwitchRes";
            this.StaticModeSwitchRes.Size = new System.Drawing.Size(70, 23);
            this.StaticModeSwitchRes.TabIndex = 69;
            this.StaticModeSwitchRes.Text = "Never Try";
            // 
            // StaticModeSwitch
            // 
            this.StaticModeSwitch.Location = new System.Drawing.Point(12, 4);
            this.StaticModeSwitch.Name = "StaticModeSwitch";
            this.StaticModeSwitch.Size = new System.Drawing.Size(109, 23);
            this.StaticModeSwitch.TabIndex = 70;
            this.StaticModeSwitch.Text = "Mode Switch";
            // 
            // VPM_TabControl
            // 
            this.VPM_TabControl.Controls.Add(this.MainTabPage);
            this.VPM_TabControl.Controls.Add(this.LBPIgnitionTabPage);
            this.VPM_TabControl.Controls.Add(this.AlarmWakeupTabPage);
            this.VPM_TabControl.Location = new System.Drawing.Point(3, 3);
            this.VPM_TabControl.Name = "VPM_TabControl";
            this.VPM_TabControl.SelectedIndex = 0;
            this.VPM_TabControl.Size = new System.Drawing.Size(746, 357);
            this.VPM_TabControl.TabIndex = 44;
            this.VPM_TabControl.SelectedIndexChanged += new System.EventHandler(this.VPM_TabControl_SelectedIndexChanged);
            // 
            // StaticPlatformName
            // 
            this.StaticPlatformName.Location = new System.Drawing.Point(141, 58);
            this.StaticPlatformName.Name = "StaticPlatformName";
            this.StaticPlatformName.Size = new System.Drawing.Size(100, 22);
            this.StaticPlatformName.TabIndex = 65;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(10, 64);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(125, 23);
            this.label1.TabIndex = 66;
            this.label1.Text = "Platform Name : ";
            // 
            // VPM
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(756, 360);
            this.Controls.Add(this.VPM_TabControl);
            this.Name = "VPM";
            this.Text = "TREK V3 VPM Sample Code";
            this.Load += new System.EventHandler(this.PowerManagement_Load);
            this.Closed += new System.EventHandler(this.PowerManagement_Closed);
            this.AlarmWakeupTabPage.ResumeLayout(false);
            this.panel10.ResumeLayout(false);
            this.panel10.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.LBPIgnitionTabPage.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel8.ResumeLayout(false);
            this.panel8.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.MainTabPage.ResumeLayout(false);
            this.panel12.ResumeLayout(false);
            this.panel12.PerformLayout();
            this.panel11.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.panel9.ResumeLayout(false);
            this.CommonPanel.ResumeLayout(false);
            this.CommonPanel.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.VPM_TabControl.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer VPMTimer;
        private System.Windows.Forms.TabPage AlarmWakeupTabPage;
        private System.Windows.Forms.Panel panel10;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DateTimePicker DTTime;
        private System.Windows.Forms.DateTimePicker DTDay;
        private System.Windows.Forms.Label StaticRTCTimeValue;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label StaticAlarmMinute;
        private System.Windows.Forms.Label StaticAlarmHour;
        private System.Windows.Forms.TextBox EditAlarmMinute;
        private System.Windows.Forms.TextBox EditAlarmHour;
        private System.Windows.Forms.TextBox EditAlarmDayOfWeek;
        private System.Windows.Forms.Label StaticAlarmDayOfWeek;
        private System.Windows.Forms.ComboBox AlarmModeCmbx;
        private System.Windows.Forms.Label StaticAlarmModeLabel;
        private System.Windows.Forms.Button BtnSetAlarmTime;
        private System.Windows.Forms.ComboBox AlarmStatusCmbx;
        private System.Windows.Forms.Button BtnGetAlarmStatus;
        private System.Windows.Forms.Button BtnSetAlarmStatus;
        private System.Windows.Forms.Button BtnGetAlarmTime;
        private System.Windows.Forms.Label StaticAlarmStatusLabel;
        private System.Windows.Forms.TabPage LBPIgnitionTabPage;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox EditIgnDelayOffEvent;
        private System.Windows.Forms.Label StaticIgnDelayHardOff;
        private System.Windows.Forms.Label StaticIgnDelayHardOffUnit;
        private System.Windows.Forms.TextBox EditIgnDelayHardOff;
        private System.Windows.Forms.Label StaticIgnDelayOnUnit;
        private System.Windows.Forms.TextBox EditIgnDelayOn;
        private System.Windows.Forms.Label StaticIgnDelayOffEventUnit;
        private System.Windows.Forms.Label StaticIgnDelayOn;
        private System.Windows.Forms.Label StaticIgnDelayOffEvent;
        private System.Windows.Forms.RadioButton RadioIgnDelayGet;
        private System.Windows.Forms.RadioButton RadioIgnDelaySet;
        private System.Windows.Forms.Button BtnIgnDelayApply;
        private System.Windows.Forms.Label StaticIgnitionDelayRes;
        private System.Windows.Forms.Label StaticIgnitionDelay;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.CheckBox ChkEnablePreBootLowBatterProtection;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.TextBox EditDefault24VPreboot;
        private System.Windows.Forms.TextBox EditDefault12VPreboot;
        private System.Windows.Forms.TextBox EditDefault24VMin;
        private System.Windows.Forms.TextBox EditDefault12VMin;
        private System.Windows.Forms.TextBox EditDefault24VDef;
        private System.Windows.Forms.TextBox EditDefault12VDef;
        private System.Windows.Forms.TextBox EditDefault12VMax;
        private System.Windows.Forms.TextBox EditDefault24VMax;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label StaticDefault24V;
        private System.Windows.Forms.Label StaticDefault12V;
        private System.Windows.Forms.Label StaticLowVoltageDefalultValue;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox EditPrebootThresholdValue24V;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox EditPrebootThresholdValue12V;
        private System.Windows.Forms.Label StaticPrebootThreshold;
        private System.Windows.Forms.Label StaticLBPThreshold;
        private System.Windows.Forms.Label StaticLowVoltageThreshold24VUnit;
        private System.Windows.Forms.Label StaticLowVoltageThreshold12VUnit;
        private System.Windows.Forms.TextBox EditLowVoltageThresholdValue24V;
        private System.Windows.Forms.TextBox EditLowVoltageThresholdValue12V;
        private System.Windows.Forms.Label StaticLowVoltageThreshold24V;
        private System.Windows.Forms.Label StaticLowVoltageThreshold12V;
        private System.Windows.Forms.Button BtnLowVoltageThresholdApply;
        private System.Windows.Forms.RadioButton RadioLowVoltageThresholdGet;
        private System.Windows.Forms.RadioButton RadioLowVoltageThresholdSet;
        private System.Windows.Forms.Label StaticLowVoltageThresholdRes;
        private System.Windows.Forms.Label StaticLowVoltageThreshold;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.TextBox EditProtectionDelayLowHard;
        private System.Windows.Forms.Label StaticProtectionDelayLowHard;
        private System.Windows.Forms.TextBox EditProtectionDelayLow;
        private System.Windows.Forms.Label StaticProtectionDelayLow;
        private System.Windows.Forms.Button BtnProtectionApply;
        private System.Windows.Forms.RadioButton RadioProtectionGet;
        private System.Windows.Forms.RadioButton RadioProtectionSet;
        private System.Windows.Forms.Label StaticLowThresholdRes;
        private System.Windows.Forms.Label StaticLowThreshold;
        private System.Windows.Forms.CheckBox ChkEnableLowBatterProtection;
        private System.Windows.Forms.Label StaticBatteryVoltage;
        private System.Windows.Forms.TabPage MainTabPage;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.Label StaticLastWakeupSourceRes;
        private System.Windows.Forms.Label StaticLastWakeupSource;
        private System.Windows.Forms.ComboBox CmBxWakeupSource;
        private System.Windows.Forms.DomainUpDown DomainUDWakeupSourceStatus;
        private System.Windows.Forms.RadioButton RadioWakeupSourceGet;
        private System.Windows.Forms.RadioButton RadioWakeupSourceSet;
        private System.Windows.Forms.Button BtnWakeupSourceApply;
        private System.Windows.Forms.Label StaticWakeupSourceRes;
        private System.Windows.Forms.Label StaticWakeupSource;
        private System.Windows.Forms.Panel CommonPanel;
        private System.Windows.Forms.Button BtnLoadDefault;
        private System.Windows.Forms.TextBox StaticCurIgnStatusValue;
        private System.Windows.Forms.TextBox StaticCurBatteryVoltageValue;
        private System.Windows.Forms.Label StaticCurIgnStatus;
        private System.Windows.Forms.Label StaticCurBatteryVoltage;
        private System.Windows.Forms.Label StaticBatteryVoltageCBMode;
        private System.Windows.Forms.TextBox StaticFirmwareVersionValue;
        private System.Windows.Forms.Label StaticFirmwareVersion;
        private System.Windows.Forms.TextBox StaticLibVersionValue;
        private System.Windows.Forms.Label StaticLibVersion;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.DomainUpDown DomainUDModeSwitchKeepAliveMode;
        private System.Windows.Forms.DomainUpDown DomainUDModeSwitchATMode;
        private System.Windows.Forms.Label StaticModeSwitchKeepAliveMode;
        private System.Windows.Forms.Label StaticModeSwitchATMode;
        private System.Windows.Forms.RadioButton RadioModeSwitchGet;
        private System.Windows.Forms.RadioButton RadioModeSwitchSet;
        private System.Windows.Forms.Button BtnModeSwitchApply;
        private System.Windows.Forms.Label StaticModeSwitchRes;
        private System.Windows.Forms.Label StaticModeSwitch;
        private System.Windows.Forms.TabControl VPM_TabControl;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.TextBox EditShutdownDelayTime;
        private System.Windows.Forms.Label labelShutdownDelay;
        private System.Windows.Forms.Button BtnForceShutdownDelayApply;
        private System.Windows.Forms.RadioButton RadioForceShutdownDelayGet;
        private System.Windows.Forms.RadioButton RadioForceShutdownDelaySet;
        private System.Windows.Forms.Label StaticForceShutdownDelayRes;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox ChkEnableShutdownDelay;
        private System.Windows.Forms.ComboBox CbBatteryVoltageModeValue;
        private System.Windows.Forms.Button BtnShutdown;
        private System.Windows.Forms.Panel panel11;
        private System.Windows.Forms.Label labelShutdownSource;
        private System.Windows.Forms.ComboBox CmbShutdownSource;
        private System.Windows.Forms.DomainUpDown DomianUDShutdownStatus;
        private System.Windows.Forms.RadioButton radioShutdownSourceGet;
        private System.Windows.Forms.RadioButton radioShutdownSoruceSet;
        private System.Windows.Forms.Button BtnShutdwonSource;
        private System.Windows.Forms.Label StaticShutdownRes;
        private System.Windows.Forms.Panel panel12;
        private System.Windows.Forms.CheckBox ChkEnablePrePowerOff;
        private System.Windows.Forms.TextBox EditPrePowerOffAlarmDelayTime;
        private System.Windows.Forms.Label labelPrePowerOffAlarmDelay;
        private System.Windows.Forms.Button BtnPrePowerOffDelayApply;
        private System.Windows.Forms.RadioButton RadioPrePowerDelayGet;
        private System.Windows.Forms.RadioButton RadioPrePowerDelaySet;
        private System.Windows.Forms.Label StaticPrePowerOffDelayRes;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox StaticPlatformName;
        private System.Windows.Forms.Label label1;
    }
}

