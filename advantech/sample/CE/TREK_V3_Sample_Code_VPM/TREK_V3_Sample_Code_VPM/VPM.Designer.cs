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
            this.VPM_TabControl = new System.Windows.Forms.TabControl();
            this.MainTabPage = new System.Windows.Forms.TabPage();
            this.panel9 = new System.Windows.Forms.Panel();
            this.BtnGetLastWakeupSource = new System.Windows.Forms.Button();
            this.StaticLastWakeupSourceRes = new System.Windows.Forms.Label();
            this.CmBxWakeupSource = new System.Windows.Forms.ComboBox();
            this.DomainUDWakeupSourceStatus = new System.Windows.Forms.DomainUpDown();
            this.RadioWakeupSourceGet = new System.Windows.Forms.RadioButton();
            this.RadioWakeupSourceSet = new System.Windows.Forms.RadioButton();
            this.BtnWakeupSourceApply = new System.Windows.Forms.Button();
            this.StaticWakeupSourceRes = new System.Windows.Forms.Label();
            this.StaticWakeupSource = new System.Windows.Forms.Label();
            this.CommonPanel = new System.Windows.Forms.Panel();
            this.BtnLoadDefault = new System.Windows.Forms.Button();
            this.StaticCurIgnStatusValue = new System.Windows.Forms.TextBox();
            this.StaticCurBatteryVoltageValue = new System.Windows.Forms.TextBox();
            this.StaticCurIgnStatus = new System.Windows.Forms.Label();
            this.StaticCurBatteryVoltage = new System.Windows.Forms.Label();
            this.StaticBatteryVoltageCBModeValue = new System.Windows.Forms.TextBox();
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
            this.LBPIgnitionTabPage = new System.Windows.Forms.TabPage();
            this.panel2 = new System.Windows.Forms.Panel();
            this.TrkBrIgnitionDelayMode = new System.Windows.Forms.TrackBar();
            this.StaticIgnitionDelayModeSuspend = new System.Windows.Forms.Label();
            this.StaticIgnitionDelayModeOff = new System.Windows.Forms.Label();
            this.StaticIgnitionDelayMode = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.EditIgnDelaySuspendOff = new System.Windows.Forms.TextBox();
            this.StaticIgnDelaySuspendOff = new System.Windows.Forms.Label();
            this.StaticIgnDelayHardOff = new System.Windows.Forms.Label();
            this.StaticIgnDelayHardOffUnit = new System.Windows.Forms.Label();
            this.EditIgnDelayHardOff = new System.Windows.Forms.TextBox();
            this.StaticIgnDelayOnUnit = new System.Windows.Forms.Label();
            this.EditIgnDelayOn = new System.Windows.Forms.TextBox();
            this.StaticIgnDelayOffEventUnit = new System.Windows.Forms.Label();
            this.EditIgnDelayOffEvent = new System.Windows.Forms.TextBox();
            this.StaticIgnDelayOn = new System.Windows.Forms.Label();
            this.StaticIgnDelayOffEvent = new System.Windows.Forms.Label();
            this.RadioIgnDelayGet = new System.Windows.Forms.RadioButton();
            this.RadioIgnDelaySet = new System.Windows.Forms.RadioButton();
            this.BtnIgnDelayApply = new System.Windows.Forms.Button();
            this.StaticIgnitionDelayRes = new System.Windows.Forms.Label();
            this.StaticIgnitionDelay = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.ChkEnablePrebootLowBatterProtection = new System.Windows.Forms.CheckBox();
            this.StaticPrebootLowBatteryProtection = new System.Windows.Forms.Label();
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
            this.StaticLowBatteryProtection = new System.Windows.Forms.Label();
            this.BackupBatteryTabPage = new System.Windows.Forms.TabPage();
            this.panel7 = new System.Windows.Forms.Panel();
            this.StaticBackupBatteryMaxCapacity = new System.Windows.Forms.Label();
            this.EditBackupBatteryTimeToFull = new System.Windows.Forms.TextBox();
            this.EditBackupBatteryRemainingTime = new System.Windows.Forms.TextBox();
            this.EditBackupBatteryTemperture = new System.Windows.Forms.TextBox();
            this.EditBackupBattery_BatteryCharge = new System.Windows.Forms.TextBox();
            this.EditBackupBatteryMaxCapacity = new System.Windows.Forms.TextBox();
            this.EditBackupBatteryRemainingCapacity = new System.Windows.Forms.TextBox();
            this.EditBackupBatteryVoltage = new System.Windows.Forms.TextBox();
            this.StaticBackupBatteryTimeToFull = new System.Windows.Forms.Label();
            this.StaticBackupBatteryRemainingTime = new System.Windows.Forms.Label();
            this.StaticBatteryBatteryTemperture = new System.Windows.Forms.Label();
            this.StaticBackupBattery_BatteryCharge = new System.Windows.Forms.Label();
            this.StaticBackupBatteryRemainingCapacity = new System.Windows.Forms.Label();
            this.StaticBackupBatteryVoltage = new System.Windows.Forms.Label();
            this.StaticBackupBattery = new System.Windows.Forms.Label();
            this.AlarmWakeupTabPage = new System.Windows.Forms.TabPage();
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
            this.VPM_TabControl.SuspendLayout();
            this.MainTabPage.SuspendLayout();
            this.panel9.SuspendLayout();
            this.CommonPanel.SuspendLayout();
            this.panel6.SuspendLayout();
            this.LBPIgnitionTabPage.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel8.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel4.SuspendLayout();
            this.BackupBatteryTabPage.SuspendLayout();
            this.panel7.SuspendLayout();
            this.AlarmWakeupTabPage.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // VPM_TabControl
            // 
            this.VPM_TabControl.Controls.Add(this.MainTabPage);
            this.VPM_TabControl.Controls.Add(this.LBPIgnitionTabPage);
            this.VPM_TabControl.Controls.Add(this.BackupBatteryTabPage);
            this.VPM_TabControl.Controls.Add(this.AlarmWakeupTabPage);
            this.VPM_TabControl.Location = new System.Drawing.Point(3, 3);
            this.VPM_TabControl.Name = "VPM_TabControl";
            this.VPM_TabControl.SelectedIndex = 0;
            this.VPM_TabControl.Size = new System.Drawing.Size(786, 419);
            this.VPM_TabControl.TabIndex = 44;
            // 
            // MainTabPage
            // 
            this.MainTabPage.Controls.Add(this.panel9);
            this.MainTabPage.Controls.Add(this.CommonPanel);
            this.MainTabPage.Controls.Add(this.panel6);
            this.MainTabPage.Location = new System.Drawing.Point(4, 25);
            this.MainTabPage.Name = "MainTabPage";
            this.MainTabPage.Size = new System.Drawing.Size(778, 390);
            this.MainTabPage.Text = "Common";
            // 
            // panel9
            // 
            this.panel9.Controls.Add(this.BtnGetLastWakeupSource);
            this.panel9.Controls.Add(this.StaticLastWakeupSourceRes);
            this.panel9.Controls.Add(this.CmBxWakeupSource);
            this.panel9.Controls.Add(this.DomainUDWakeupSourceStatus);
            this.panel9.Controls.Add(this.RadioWakeupSourceGet);
            this.panel9.Controls.Add(this.RadioWakeupSourceSet);
            this.panel9.Controls.Add(this.BtnWakeupSourceApply);
            this.panel9.Controls.Add(this.StaticWakeupSourceRes);
            this.panel9.Controls.Add(this.StaticWakeupSource);
            this.panel9.Location = new System.Drawing.Point(270, 136);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(261, 149);
            // 
            // BtnGetLastWakeupSource
            // 
            this.BtnGetLastWakeupSource.Location = new System.Drawing.Point(4, 86);
            this.BtnGetLastWakeupSource.Name = "BtnGetLastWakeupSource";
            this.BtnGetLastWakeupSource.Size = new System.Drawing.Size(253, 22);
            this.BtnGetLastWakeupSource.TabIndex = 78;
            this.BtnGetLastWakeupSource.Text = "Get Last Wakeup Source";
            this.BtnGetLastWakeupSource.Click += new System.EventHandler(this.BtnGetLastWakeupSource_Click);
            // 
            // StaticLastWakeupSourceRes
            // 
            this.StaticLastWakeupSourceRes.Location = new System.Drawing.Point(3, 115);
            this.StaticLastWakeupSourceRes.Name = "StaticLastWakeupSourceRes";
            this.StaticLastWakeupSourceRes.Size = new System.Drawing.Size(254, 23);
            this.StaticLastWakeupSourceRes.Text = "N/A";
            this.StaticLastWakeupSourceRes.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // CmBxWakeupSource
            // 
            this.CmBxWakeupSource.Location = new System.Drawing.Point(4, 57);
            this.CmBxWakeupSource.Name = "CmBxWakeupSource";
            this.CmBxWakeupSource.Size = new System.Drawing.Size(117, 23);
            this.CmBxWakeupSource.TabIndex = 75;
            // 
            // DomainUDWakeupSourceStatus
            // 
            this.DomainUDWakeupSourceStatus.Location = new System.Drawing.Point(133, 57);
            this.DomainUDWakeupSourceStatus.Name = "DomainUDWakeupSourceStatus";
            this.DomainUDWakeupSourceStatus.ReadOnly = true;
            this.DomainUDWakeupSourceStatus.Size = new System.Drawing.Size(125, 24);
            this.DomainUDWakeupSourceStatus.TabIndex = 74;
            // 
            // RadioWakeupSourceGet
            // 
            this.RadioWakeupSourceGet.Location = new System.Drawing.Point(188, 29);
            this.RadioWakeupSourceGet.Name = "RadioWakeupSourceGet";
            this.RadioWakeupSourceGet.Size = new System.Drawing.Size(49, 22);
            this.RadioWakeupSourceGet.TabIndex = 73;
            this.RadioWakeupSourceGet.TabStop = false;
            this.RadioWakeupSourceGet.Text = "Get";
            // 
            // RadioWakeupSourceSet
            // 
            this.RadioWakeupSourceSet.Checked = true;
            this.RadioWakeupSourceSet.Location = new System.Drawing.Point(133, 29);
            this.RadioWakeupSourceSet.Name = "RadioWakeupSourceSet";
            this.RadioWakeupSourceSet.Size = new System.Drawing.Size(49, 22);
            this.RadioWakeupSourceSet.TabIndex = 72;
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
            this.StaticWakeupSourceRes.Text = "Never Try";
            // 
            // StaticWakeupSource
            // 
            this.StaticWakeupSource.Location = new System.Drawing.Point(4, 3);
            this.StaticWakeupSource.Name = "StaticWakeupSource";
            this.StaticWakeupSource.Size = new System.Drawing.Size(109, 23);
            this.StaticWakeupSource.Text = "Wakeup Source";
            // 
            // CommonPanel
            // 
            this.CommonPanel.Controls.Add(this.BtnLoadDefault);
            this.CommonPanel.Controls.Add(this.StaticCurIgnStatusValue);
            this.CommonPanel.Controls.Add(this.StaticCurBatteryVoltageValue);
            this.CommonPanel.Controls.Add(this.StaticCurIgnStatus);
            this.CommonPanel.Controls.Add(this.StaticCurBatteryVoltage);
            this.CommonPanel.Controls.Add(this.StaticBatteryVoltageCBModeValue);
            this.CommonPanel.Controls.Add(this.StaticBatteryVoltageCBMode);
            this.CommonPanel.Controls.Add(this.StaticFirmwareVersionValue);
            this.CommonPanel.Controls.Add(this.StaticFirmwareVersion);
            this.CommonPanel.Controls.Add(this.StaticLibVersionValue);
            this.CommonPanel.Controls.Add(this.StaticLibVersion);
            this.CommonPanel.Location = new System.Drawing.Point(3, 11);
            this.CommonPanel.Name = "CommonPanel";
            this.CommonPanel.Size = new System.Drawing.Size(261, 187);
            // 
            // BtnLoadDefault
            // 
            this.BtnLoadDefault.Location = new System.Drawing.Point(142, 154);
            this.BtnLoadDefault.Name = "BtnLoadDefault";
            this.BtnLoadDefault.Size = new System.Drawing.Size(100, 23);
            this.BtnLoadDefault.TabIndex = 57;
            this.BtnLoadDefault.Text = "Load Default";
            this.BtnLoadDefault.Click += new System.EventHandler(this.BtnLoadDefault_Click);
            // 
            // StaticCurIgnStatusValue
            // 
            this.StaticCurIgnStatusValue.Location = new System.Drawing.Point(142, 125);
            this.StaticCurIgnStatusValue.Name = "StaticCurIgnStatusValue";
            this.StaticCurIgnStatusValue.Size = new System.Drawing.Size(100, 23);
            this.StaticCurIgnStatusValue.TabIndex = 56;
            // 
            // StaticCurBatteryVoltageValue
            // 
            this.StaticCurBatteryVoltageValue.Location = new System.Drawing.Point(142, 96);
            this.StaticCurBatteryVoltageValue.Name = "StaticCurBatteryVoltageValue";
            this.StaticCurBatteryVoltageValue.Size = new System.Drawing.Size(100, 23);
            this.StaticCurBatteryVoltageValue.TabIndex = 55;
            // 
            // StaticCurIgnStatus
            // 
            this.StaticCurIgnStatus.Location = new System.Drawing.Point(11, 125);
            this.StaticCurIgnStatus.Name = "StaticCurIgnStatus";
            this.StaticCurIgnStatus.Size = new System.Drawing.Size(125, 23);
            this.StaticCurIgnStatus.Text = "Ignition Status :";
            // 
            // StaticCurBatteryVoltage
            // 
            this.StaticCurBatteryVoltage.Location = new System.Drawing.Point(11, 96);
            this.StaticCurBatteryVoltage.Name = "StaticCurBatteryVoltage";
            this.StaticCurBatteryVoltage.Size = new System.Drawing.Size(125, 23);
            this.StaticCurBatteryVoltage.Text = "Battery Voltage :";
            // 
            // StaticBatteryVoltageCBModeValue
            // 
            this.StaticBatteryVoltageCBModeValue.Location = new System.Drawing.Point(142, 67);
            this.StaticBatteryVoltageCBModeValue.Name = "StaticBatteryVoltageCBModeValue";
            this.StaticBatteryVoltageCBModeValue.Size = new System.Drawing.Size(100, 23);
            this.StaticBatteryVoltageCBModeValue.TabIndex = 54;
            // 
            // StaticBatteryVoltageCBMode
            // 
            this.StaticBatteryVoltageCBMode.Location = new System.Drawing.Point(11, 67);
            this.StaticBatteryVoltageCBMode.Name = "StaticBatteryVoltageCBMode";
            this.StaticBatteryVoltageCBMode.Size = new System.Drawing.Size(125, 23);
            this.StaticBatteryVoltageCBMode.Text = "Car Battery Mode :";
            // 
            // StaticFirmwareVersionValue
            // 
            this.StaticFirmwareVersionValue.Location = new System.Drawing.Point(142, 38);
            this.StaticFirmwareVersionValue.Name = "StaticFirmwareVersionValue";
            this.StaticFirmwareVersionValue.Size = new System.Drawing.Size(100, 23);
            this.StaticFirmwareVersionValue.TabIndex = 53;
            // 
            // StaticFirmwareVersion
            // 
            this.StaticFirmwareVersion.Location = new System.Drawing.Point(11, 38);
            this.StaticFirmwareVersion.Name = "StaticFirmwareVersion";
            this.StaticFirmwareVersion.Size = new System.Drawing.Size(125, 23);
            this.StaticFirmwareVersion.Text = "Firmware Version : ";
            // 
            // StaticLibVersionValue
            // 
            this.StaticLibVersionValue.Location = new System.Drawing.Point(142, 9);
            this.StaticLibVersionValue.Name = "StaticLibVersionValue";
            this.StaticLibVersionValue.Size = new System.Drawing.Size(100, 23);
            this.StaticLibVersionValue.TabIndex = 52;
            // 
            // StaticLibVersion
            // 
            this.StaticLibVersion.Location = new System.Drawing.Point(11, 9);
            this.StaticLibVersion.Name = "StaticLibVersion";
            this.StaticLibVersion.Size = new System.Drawing.Size(125, 23);
            this.StaticLibVersion.Text = "Library Version : ";
            // 
            // panel6
            // 
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
            // 
            // DomainUDModeSwitchKeepAliveMode
            // 
            this.DomainUDModeSwitchKeepAliveMode.Location = new System.Drawing.Point(133, 90);
            this.DomainUDModeSwitchKeepAliveMode.Name = "DomainUDModeSwitchKeepAliveMode";
            this.DomainUDModeSwitchKeepAliveMode.ReadOnly = true;
            this.DomainUDModeSwitchKeepAliveMode.Size = new System.Drawing.Size(125, 24);
            this.DomainUDModeSwitchKeepAliveMode.TabIndex = 66;
            // 
            // DomainUDModeSwitchATMode
            // 
            this.DomainUDModeSwitchATMode.Location = new System.Drawing.Point(133, 59);
            this.DomainUDModeSwitchATMode.Name = "DomainUDModeSwitchATMode";
            this.DomainUDModeSwitchATMode.ReadOnly = true;
            this.DomainUDModeSwitchATMode.Size = new System.Drawing.Size(125, 24);
            this.DomainUDModeSwitchATMode.TabIndex = 65;
            // 
            // StaticModeSwitchKeepAliveMode
            // 
            this.StaticModeSwitchKeepAliveMode.Location = new System.Drawing.Point(12, 90);
            this.StaticModeSwitchKeepAliveMode.Name = "StaticModeSwitchKeepAliveMode";
            this.StaticModeSwitchKeepAliveMode.Size = new System.Drawing.Size(115, 23);
            this.StaticModeSwitchKeepAliveMode.Text = "Keep Alive Mode :";
            // 
            // StaticModeSwitchATMode
            // 
            this.StaticModeSwitchATMode.Location = new System.Drawing.Point(12, 57);
            this.StaticModeSwitchATMode.Name = "StaticModeSwitchATMode";
            this.StaticModeSwitchATMode.Size = new System.Drawing.Size(115, 23);
            this.StaticModeSwitchATMode.Text = "AT Mode :";
            // 
            // RadioModeSwitchGet
            // 
            this.RadioModeSwitchGet.Location = new System.Drawing.Point(188, 30);
            this.RadioModeSwitchGet.Name = "RadioModeSwitchGet";
            this.RadioModeSwitchGet.Size = new System.Drawing.Size(49, 22);
            this.RadioModeSwitchGet.TabIndex = 35;
            this.RadioModeSwitchGet.TabStop = false;
            this.RadioModeSwitchGet.Text = "Get";
            // 
            // RadioModeSwitchSet
            // 
            this.RadioModeSwitchSet.Checked = true;
            this.RadioModeSwitchSet.Location = new System.Drawing.Point(133, 30);
            this.RadioModeSwitchSet.Name = "RadioModeSwitchSet";
            this.RadioModeSwitchSet.Size = new System.Drawing.Size(49, 22);
            this.RadioModeSwitchSet.TabIndex = 19;
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
            this.StaticModeSwitchRes.Text = "Never Try";
            // 
            // StaticModeSwitch
            // 
            this.StaticModeSwitch.Location = new System.Drawing.Point(12, 4);
            this.StaticModeSwitch.Name = "StaticModeSwitch";
            this.StaticModeSwitch.Size = new System.Drawing.Size(109, 23);
            this.StaticModeSwitch.Text = "Mode Switch";
            // 
            // LBPIgnitionTabPage
            // 
            this.LBPIgnitionTabPage.Controls.Add(this.panel2);
            this.LBPIgnitionTabPage.Controls.Add(this.panel3);
            this.LBPIgnitionTabPage.Location = new System.Drawing.Point(4, 25);
            this.LBPIgnitionTabPage.Name = "LBPIgnitionTabPage";
            this.LBPIgnitionTabPage.Size = new System.Drawing.Size(778, 390);
            this.LBPIgnitionTabPage.Text = "LBP&Ignition";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.TrkBrIgnitionDelayMode);
            this.panel2.Controls.Add(this.StaticIgnitionDelayModeSuspend);
            this.panel2.Controls.Add(this.StaticIgnitionDelayModeOff);
            this.panel2.Controls.Add(this.StaticIgnitionDelayMode);
            this.panel2.Controls.Add(this.label13);
            this.panel2.Controls.Add(this.EditIgnDelaySuspendOff);
            this.panel2.Controls.Add(this.StaticIgnDelaySuspendOff);
            this.panel2.Controls.Add(this.StaticIgnDelayHardOff);
            this.panel2.Controls.Add(this.StaticIgnDelayHardOffUnit);
            this.panel2.Controls.Add(this.EditIgnDelayHardOff);
            this.panel2.Controls.Add(this.StaticIgnDelayOnUnit);
            this.panel2.Controls.Add(this.EditIgnDelayOn);
            this.panel2.Controls.Add(this.StaticIgnDelayOffEventUnit);
            this.panel2.Controls.Add(this.EditIgnDelayOffEvent);
            this.panel2.Controls.Add(this.StaticIgnDelayOn);
            this.panel2.Controls.Add(this.StaticIgnDelayOffEvent);
            this.panel2.Controls.Add(this.RadioIgnDelayGet);
            this.panel2.Controls.Add(this.RadioIgnDelaySet);
            this.panel2.Controls.Add(this.BtnIgnDelayApply);
            this.panel2.Controls.Add(this.StaticIgnitionDelayRes);
            this.panel2.Controls.Add(this.StaticIgnitionDelay);
            this.panel2.Location = new System.Drawing.Point(514, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(261, 324);
            // 
            // TrkBrIgnitionDelayMode
            // 
            this.TrkBrIgnitionDelayMode.Location = new System.Drawing.Point(136, 57);
            this.TrkBrIgnitionDelayMode.Maximum = 1;
            this.TrkBrIgnitionDelayMode.Name = "TrkBrIgnitionDelayMode";
            this.TrkBrIgnitionDelayMode.Size = new System.Drawing.Size(50, 23);
            this.TrkBrIgnitionDelayMode.TabIndex = 48;
            this.TrkBrIgnitionDelayMode.ValueChanged += new System.EventHandler(this.TrkBrIgnitionDelayMode_ValueChanged);
            // 
            // StaticIgnitionDelayModeSuspend
            // 
            this.StaticIgnitionDelayModeSuspend.Location = new System.Drawing.Point(188, 59);
            this.StaticIgnitionDelayModeSuspend.Name = "StaticIgnitionDelayModeSuspend";
            this.StaticIgnitionDelayModeSuspend.Size = new System.Drawing.Size(70, 23);
            this.StaticIgnitionDelayModeSuspend.Text = "Susspend";
            // 
            // StaticIgnitionDelayModeOff
            // 
            this.StaticIgnitionDelayModeOff.Location = new System.Drawing.Point(110, 59);
            this.StaticIgnitionDelayModeOff.Name = "StaticIgnitionDelayModeOff";
            this.StaticIgnitionDelayModeOff.Size = new System.Drawing.Size(34, 23);
            this.StaticIgnitionDelayModeOff.Text = "Off";
            // 
            // StaticIgnitionDelayMode
            // 
            this.StaticIgnitionDelayMode.Location = new System.Drawing.Point(6, 59);
            this.StaticIgnitionDelayMode.Name = "StaticIgnitionDelayMode";
            this.StaticIgnitionDelayMode.Size = new System.Drawing.Size(98, 23);
            this.StaticIgnitionDelayMode.Text = "Ignition Mode";
            // 
            // label13
            // 
            this.label13.Location = new System.Drawing.Point(179, 171);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(49, 23);
            this.label13.Text = "Sec";
            // 
            // EditIgnDelaySuspendOff
            // 
            this.EditIgnDelaySuspendOff.Location = new System.Drawing.Point(124, 171);
            this.EditIgnDelaySuspendOff.Name = "EditIgnDelaySuspendOff";
            this.EditIgnDelaySuspendOff.Size = new System.Drawing.Size(49, 23);
            this.EditIgnDelaySuspendOff.TabIndex = 39;
            this.EditIgnDelaySuspendOff.Text = "5";
            // 
            // StaticIgnDelaySuspendOff
            // 
            this.StaticIgnDelaySuspendOff.Location = new System.Drawing.Point(4, 173);
            this.StaticIgnDelaySuspendOff.Name = "StaticIgnDelaySuspendOff";
            this.StaticIgnDelaySuspendOff.Size = new System.Drawing.Size(100, 23);
            this.StaticIgnDelaySuspendOff.Text = "Suspend Delay";
            // 
            // StaticIgnDelayHardOff
            // 
            this.StaticIgnDelayHardOff.Location = new System.Drawing.Point(4, 145);
            this.StaticIgnDelayHardOff.Name = "StaticIgnDelayHardOff";
            this.StaticIgnDelayHardOff.Size = new System.Drawing.Size(100, 23);
            this.StaticIgnDelayHardOff.Text = "Hard Off Delay";
            // 
            // StaticIgnDelayHardOffUnit
            // 
            this.StaticIgnDelayHardOffUnit.Location = new System.Drawing.Point(179, 143);
            this.StaticIgnDelayHardOffUnit.Name = "StaticIgnDelayHardOffUnit";
            this.StaticIgnDelayHardOffUnit.Size = new System.Drawing.Size(49, 23);
            this.StaticIgnDelayHardOffUnit.Text = "Sec";
            // 
            // EditIgnDelayHardOff
            // 
            this.EditIgnDelayHardOff.Location = new System.Drawing.Point(124, 143);
            this.EditIgnDelayHardOff.Name = "EditIgnDelayHardOff";
            this.EditIgnDelayHardOff.Size = new System.Drawing.Size(49, 23);
            this.EditIgnDelayHardOff.TabIndex = 30;
            this.EditIgnDelayHardOff.Text = "60";
            // 
            // StaticIgnDelayOnUnit
            // 
            this.StaticIgnDelayOnUnit.Location = new System.Drawing.Point(179, 114);
            this.StaticIgnDelayOnUnit.Name = "StaticIgnDelayOnUnit";
            this.StaticIgnDelayOnUnit.Size = new System.Drawing.Size(49, 23);
            this.StaticIgnDelayOnUnit.Text = "Sec";
            // 
            // EditIgnDelayOn
            // 
            this.EditIgnDelayOn.Location = new System.Drawing.Point(124, 114);
            this.EditIgnDelayOn.Name = "EditIgnDelayOn";
            this.EditIgnDelayOn.Size = new System.Drawing.Size(49, 23);
            this.EditIgnDelayOn.TabIndex = 27;
            this.EditIgnDelayOn.Text = "2";
            // 
            // StaticIgnDelayOffEventUnit
            // 
            this.StaticIgnDelayOffEventUnit.Location = new System.Drawing.Point(179, 85);
            this.StaticIgnDelayOffEventUnit.Name = "StaticIgnDelayOffEventUnit";
            this.StaticIgnDelayOffEventUnit.Size = new System.Drawing.Size(49, 23);
            this.StaticIgnDelayOffEventUnit.Text = "Sec";
            // 
            // EditIgnDelayOffEvent
            // 
            this.EditIgnDelayOffEvent.Location = new System.Drawing.Point(124, 86);
            this.EditIgnDelayOffEvent.Name = "EditIgnDelayOffEvent";
            this.EditIgnDelayOffEvent.Size = new System.Drawing.Size(49, 23);
            this.EditIgnDelayOffEvent.TabIndex = 16;
            this.EditIgnDelayOffEvent.Text = "5";
            // 
            // StaticIgnDelayOn
            // 
            this.StaticIgnDelayOn.Location = new System.Drawing.Point(4, 116);
            this.StaticIgnDelayOn.Name = "StaticIgnDelayOn";
            this.StaticIgnDelayOn.Size = new System.Drawing.Size(100, 23);
            this.StaticIgnDelayOn.Text = "On Delay";
            // 
            // StaticIgnDelayOffEvent
            // 
            this.StaticIgnDelayOffEvent.Location = new System.Drawing.Point(4, 85);
            this.StaticIgnDelayOffEvent.Name = "StaticIgnDelayOffEvent";
            this.StaticIgnDelayOffEvent.Size = new System.Drawing.Size(100, 23);
            this.StaticIgnDelayOffEvent.Text = "Off Event Delay";
            // 
            // RadioIgnDelayGet
            // 
            this.RadioIgnDelayGet.Location = new System.Drawing.Point(179, 29);
            this.RadioIgnDelayGet.Name = "RadioIgnDelayGet";
            this.RadioIgnDelayGet.Size = new System.Drawing.Size(49, 22);
            this.RadioIgnDelayGet.TabIndex = 19;
            this.RadioIgnDelayGet.TabStop = false;
            this.RadioIgnDelayGet.Text = "Get";
            // 
            // RadioIgnDelaySet
            // 
            this.RadioIgnDelaySet.Checked = true;
            this.RadioIgnDelaySet.Location = new System.Drawing.Point(124, 29);
            this.RadioIgnDelaySet.Name = "RadioIgnDelaySet";
            this.RadioIgnDelaySet.Size = new System.Drawing.Size(49, 22);
            this.RadioIgnDelaySet.TabIndex = 19;
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
            this.StaticIgnitionDelayRes.Text = "Never Try";
            // 
            // StaticIgnitionDelay
            // 
            this.StaticIgnitionDelay.Location = new System.Drawing.Point(4, 4);
            this.StaticIgnitionDelay.Name = "StaticIgnitionDelay";
            this.StaticIgnitionDelay.Size = new System.Drawing.Size(109, 23);
            this.StaticIgnitionDelay.Text = "Ignition ON/OFF";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.ChkEnablePrebootLowBatterProtection);
            this.panel3.Controls.Add(this.StaticPrebootLowBatteryProtection);
            this.panel3.Controls.Add(this.panel8);
            this.panel3.Controls.Add(this.panel5);
            this.panel3.Controls.Add(this.panel4);
            this.panel3.Controls.Add(this.ChkEnableLowBatterProtection);
            this.panel3.Controls.Add(this.StaticLowBatteryProtection);
            this.panel3.Location = new System.Drawing.Point(3, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(505, 324);
            // 
            // ChkEnablePrebootLowBatterProtection
            // 
            this.ChkEnablePrebootLowBatterProtection.Location = new System.Drawing.Point(432, 4);
            this.ChkEnablePrebootLowBatterProtection.Name = "ChkEnablePrebootLowBatterProtection";
            this.ChkEnablePrebootLowBatterProtection.Size = new System.Drawing.Size(70, 23);
            this.ChkEnablePrebootLowBatterProtection.TabIndex = 25;
            this.ChkEnablePrebootLowBatterProtection.Text = "Enable";
            this.ChkEnablePrebootLowBatterProtection.CheckStateChanged += new System.EventHandler(this.ChkEnablePrebootLowBatterProtection_CheckStateChanged);
            // 
            // StaticPrebootLowBatteryProtection
            // 
            this.StaticPrebootLowBatteryProtection.Location = new System.Drawing.Point(237, 4);
            this.StaticPrebootLowBatteryProtection.Name = "StaticPrebootLowBatteryProtection";
            this.StaticPrebootLowBatteryProtection.Size = new System.Drawing.Size(196, 23);
            this.StaticPrebootLowBatteryProtection.Text = "Preboot Low Battery Protection";
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
            // 
            // EditDefault24VPreboot
            // 
            this.EditDefault24VPreboot.Location = new System.Drawing.Point(122, 143);
            this.EditDefault24VPreboot.Name = "EditDefault24VPreboot";
            this.EditDefault24VPreboot.ReadOnly = true;
            this.EditDefault24VPreboot.Size = new System.Drawing.Size(58, 23);
            this.EditDefault24VPreboot.TabIndex = 72;
            this.EditDefault24VPreboot.Text = "0";
            // 
            // EditDefault12VPreboot
            // 
            this.EditDefault12VPreboot.Location = new System.Drawing.Point(61, 143);
            this.EditDefault12VPreboot.Name = "EditDefault12VPreboot";
            this.EditDefault12VPreboot.ReadOnly = true;
            this.EditDefault12VPreboot.Size = new System.Drawing.Size(58, 23);
            this.EditDefault12VPreboot.TabIndex = 71;
            this.EditDefault12VPreboot.Text = "0";
            // 
            // EditDefault24VMin
            // 
            this.EditDefault24VMin.Location = new System.Drawing.Point(122, 115);
            this.EditDefault24VMin.Name = "EditDefault24VMin";
            this.EditDefault24VMin.ReadOnly = true;
            this.EditDefault24VMin.Size = new System.Drawing.Size(58, 23);
            this.EditDefault24VMin.TabIndex = 70;
            this.EditDefault24VMin.Text = "0";
            // 
            // EditDefault12VMin
            // 
            this.EditDefault12VMin.Location = new System.Drawing.Point(61, 115);
            this.EditDefault12VMin.Name = "EditDefault12VMin";
            this.EditDefault12VMin.ReadOnly = true;
            this.EditDefault12VMin.Size = new System.Drawing.Size(58, 23);
            this.EditDefault12VMin.TabIndex = 69;
            this.EditDefault12VMin.Text = "0";
            // 
            // EditDefault24VDef
            // 
            this.EditDefault24VDef.Location = new System.Drawing.Point(122, 86);
            this.EditDefault24VDef.Name = "EditDefault24VDef";
            this.EditDefault24VDef.ReadOnly = true;
            this.EditDefault24VDef.Size = new System.Drawing.Size(58, 23);
            this.EditDefault24VDef.TabIndex = 68;
            this.EditDefault24VDef.Text = "0";
            // 
            // EditDefault12VDef
            // 
            this.EditDefault12VDef.Location = new System.Drawing.Point(61, 86);
            this.EditDefault12VDef.Name = "EditDefault12VDef";
            this.EditDefault12VDef.ReadOnly = true;
            this.EditDefault12VDef.Size = new System.Drawing.Size(58, 23);
            this.EditDefault12VDef.TabIndex = 67;
            this.EditDefault12VDef.Text = "0";
            // 
            // EditDefault12VMax
            // 
            this.EditDefault12VMax.Location = new System.Drawing.Point(61, 58);
            this.EditDefault12VMax.Name = "EditDefault12VMax";
            this.EditDefault12VMax.ReadOnly = true;
            this.EditDefault12VMax.Size = new System.Drawing.Size(58, 23);
            this.EditDefault12VMax.TabIndex = 66;
            this.EditDefault12VMax.Text = "0";
            // 
            // EditDefault24VMax
            // 
            this.EditDefault24VMax.Location = new System.Drawing.Point(122, 58);
            this.EditDefault24VMax.Name = "EditDefault24VMax";
            this.EditDefault24VMax.ReadOnly = true;
            this.EditDefault24VMax.Size = new System.Drawing.Size(58, 23);
            this.EditDefault24VMax.TabIndex = 37;
            this.EditDefault24VMax.Text = "0";
            // 
            // label11
            // 
            this.label11.Location = new System.Drawing.Point(3, 144);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(52, 23);
            this.label11.Text = "Preboot";
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(3, 115);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(52, 23);
            this.label10.Text = "Min";
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(3, 87);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(52, 23);
            this.label9.Text = "Default";
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(3, 58);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(52, 23);
            this.label8.Text = "Max";
            // 
            // StaticDefault24V
            // 
            this.StaticDefault24V.Location = new System.Drawing.Point(136, 31);
            this.StaticDefault24V.Name = "StaticDefault24V";
            this.StaticDefault24V.Size = new System.Drawing.Size(44, 23);
            this.StaticDefault24V.Text = "24V";
            // 
            // StaticDefault12V
            // 
            this.StaticDefault12V.Location = new System.Drawing.Point(81, 31);
            this.StaticDefault12V.Name = "StaticDefault12V";
            this.StaticDefault12V.Size = new System.Drawing.Size(44, 23);
            this.StaticDefault12V.Text = "12V";
            // 
            // StaticLowVoltageDefalultValue
            // 
            this.StaticLowVoltageDefalultValue.Location = new System.Drawing.Point(3, 5);
            this.StaticLowVoltageDefalultValue.Name = "StaticLowVoltageDefalultValue";
            this.StaticLowVoltageDefalultValue.Size = new System.Drawing.Size(182, 23);
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
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(252, 115);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(13, 23);
            this.label4.Text = "V";
            // 
            // EditPrebootThresholdValue24V
            // 
            this.EditPrebootThresholdValue24V.Location = new System.Drawing.Point(176, 115);
            this.EditPrebootThresholdValue24V.Name = "EditPrebootThresholdValue24V";
            this.EditPrebootThresholdValue24V.Size = new System.Drawing.Size(70, 23);
            this.EditPrebootThresholdValue24V.TabIndex = 49;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(252, 86);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(13, 23);
            this.label3.Text = "V";
            // 
            // EditPrebootThresholdValue12V
            // 
            this.EditPrebootThresholdValue12V.Location = new System.Drawing.Point(176, 86);
            this.EditPrebootThresholdValue12V.Name = "EditPrebootThresholdValue12V";
            this.EditPrebootThresholdValue12V.Size = new System.Drawing.Size(70, 23);
            this.EditPrebootThresholdValue12V.TabIndex = 46;
            // 
            // StaticPrebootThreshold
            // 
            this.StaticPrebootThreshold.Location = new System.Drawing.Point(176, 60);
            this.StaticPrebootThreshold.Name = "StaticPrebootThreshold";
            this.StaticPrebootThreshold.Size = new System.Drawing.Size(118, 23);
            this.StaticPrebootThreshold.Text = "Preboot Threshold";
            // 
            // StaticLBPThreshold
            // 
            this.StaticLBPThreshold.Location = new System.Drawing.Point(73, 60);
            this.StaticLBPThreshold.Name = "StaticLBPThreshold";
            this.StaticLBPThreshold.Size = new System.Drawing.Size(97, 23);
            this.StaticLBPThreshold.Text = "LBP Threshold";
            // 
            // StaticLowVoltageThreshold24VUnit
            // 
            this.StaticLowVoltageThreshold24VUnit.Location = new System.Drawing.Point(149, 115);
            this.StaticLowVoltageThreshold24VUnit.Name = "StaticLowVoltageThreshold24VUnit";
            this.StaticLowVoltageThreshold24VUnit.Size = new System.Drawing.Size(13, 23);
            this.StaticLowVoltageThreshold24VUnit.Text = "V";
            // 
            // StaticLowVoltageThreshold12VUnit
            // 
            this.StaticLowVoltageThreshold12VUnit.Location = new System.Drawing.Point(149, 86);
            this.StaticLowVoltageThreshold12VUnit.Name = "StaticLowVoltageThreshold12VUnit";
            this.StaticLowVoltageThreshold12VUnit.Size = new System.Drawing.Size(13, 23);
            this.StaticLowVoltageThreshold12VUnit.Text = "V";
            // 
            // EditLowVoltageThresholdValue24V
            // 
            this.EditLowVoltageThresholdValue24V.Location = new System.Drawing.Point(73, 115);
            this.EditLowVoltageThresholdValue24V.Name = "EditLowVoltageThresholdValue24V";
            this.EditLowVoltageThresholdValue24V.Size = new System.Drawing.Size(70, 23);
            this.EditLowVoltageThresholdValue24V.TabIndex = 37;
            // 
            // EditLowVoltageThresholdValue12V
            // 
            this.EditLowVoltageThresholdValue12V.Location = new System.Drawing.Point(73, 86);
            this.EditLowVoltageThresholdValue12V.Name = "EditLowVoltageThresholdValue12V";
            this.EditLowVoltageThresholdValue12V.Size = new System.Drawing.Size(70, 23);
            this.EditLowVoltageThresholdValue12V.TabIndex = 31;
            // 
            // StaticLowVoltageThreshold24V
            // 
            this.StaticLowVoltageThreshold24V.Location = new System.Drawing.Point(3, 115);
            this.StaticLowVoltageThreshold24V.Name = "StaticLowVoltageThreshold24V";
            this.StaticLowVoltageThreshold24V.Size = new System.Drawing.Size(67, 23);
            this.StaticLowVoltageThreshold24V.Text = "24V Mode";
            // 
            // StaticLowVoltageThreshold12V
            // 
            this.StaticLowVoltageThreshold12V.Location = new System.Drawing.Point(3, 86);
            this.StaticLowVoltageThreshold12V.Name = "StaticLowVoltageThreshold12V";
            this.StaticLowVoltageThreshold12V.Size = new System.Drawing.Size(67, 23);
            this.StaticLowVoltageThreshold12V.Text = "12V Mode";
            // 
            // BtnLowVoltageThresholdApply
            // 
            this.BtnLowVoltageThresholdApply.Location = new System.Drawing.Point(32, 34);
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
            this.RadioLowVoltageThresholdGet.TabStop = false;
            this.RadioLowVoltageThresholdGet.Text = "Get";
            this.RadioLowVoltageThresholdGet.CheckedChanged += new System.EventHandler(this.RadioLowVoltageThresholdGet_CheckedChanged);
            // 
            // RadioLowVoltageThresholdSet
            // 
            this.RadioLowVoltageThresholdSet.Checked = true;
            this.RadioLowVoltageThresholdSet.Location = new System.Drawing.Point(121, 34);
            this.RadioLowVoltageThresholdSet.Name = "RadioLowVoltageThresholdSet";
            this.RadioLowVoltageThresholdSet.Size = new System.Drawing.Size(49, 23);
            this.RadioLowVoltageThresholdSet.TabIndex = 19;
            this.RadioLowVoltageThresholdSet.Text = "Set";
            this.RadioLowVoltageThresholdSet.CheckedChanged += new System.EventHandler(this.RadioLowVoltageThreshold_CheckedChanged);
            // 
            // StaticLowVoltageThresholdRes
            // 
            this.StaticLowVoltageThresholdRes.Location = new System.Drawing.Point(176, 5);
            this.StaticLowVoltageThresholdRes.Name = "StaticLowVoltageThresholdRes";
            this.StaticLowVoltageThresholdRes.Size = new System.Drawing.Size(70, 23);
            this.StaticLowVoltageThresholdRes.Text = "Never Try";
            // 
            // StaticLowVoltageThreshold
            // 
            this.StaticLowVoltageThreshold.Location = new System.Drawing.Point(3, 5);
            this.StaticLowVoltageThreshold.Name = "StaticLowVoltageThreshold";
            this.StaticLowVoltageThreshold.Size = new System.Drawing.Size(143, 23);
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
            // 
            // EditProtectionDelayLowHard
            // 
            this.EditProtectionDelayLowHard.Location = new System.Drawing.Point(121, 86);
            this.EditProtectionDelayLowHard.Name = "EditProtectionDelayLowHard";
            this.EditProtectionDelayLowHard.Size = new System.Drawing.Size(100, 23);
            this.EditProtectionDelayLowHard.TabIndex = 30;
            this.EditProtectionDelayLowHard.Text = "60";
            // 
            // StaticProtectionDelayLowHard
            // 
            this.StaticProtectionDelayLowHard.Location = new System.Drawing.Point(3, 86);
            this.StaticProtectionDelayLowHard.Name = "StaticProtectionDelayLowHard";
            this.StaticProtectionDelayLowHard.Size = new System.Drawing.Size(112, 23);
            this.StaticProtectionDelayLowHard.Text = "Low Hard Delay";
            // 
            // EditProtectionDelayLow
            // 
            this.EditProtectionDelayLow.Location = new System.Drawing.Point(121, 57);
            this.EditProtectionDelayLow.Name = "EditProtectionDelayLow";
            this.EditProtectionDelayLow.Size = new System.Drawing.Size(100, 23);
            this.EditProtectionDelayLow.TabIndex = 17;
            this.EditProtectionDelayLow.Text = "30";
            // 
            // StaticProtectionDelayLow
            // 
            this.StaticProtectionDelayLow.Location = new System.Drawing.Point(3, 57);
            this.StaticProtectionDelayLow.Name = "StaticProtectionDelayLow";
            this.StaticProtectionDelayLow.Size = new System.Drawing.Size(112, 23);
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
            this.RadioProtectionGet.TabStop = false;
            this.RadioProtectionGet.Text = "Get";
            // 
            // RadioProtectionSet
            // 
            this.RadioProtectionSet.Checked = true;
            this.RadioProtectionSet.Location = new System.Drawing.Point(121, 31);
            this.RadioProtectionSet.Name = "RadioProtectionSet";
            this.RadioProtectionSet.Size = new System.Drawing.Size(49, 23);
            this.RadioProtectionSet.TabIndex = 19;
            this.RadioProtectionSet.Text = "Set";
            // 
            // StaticLowThresholdRes
            // 
            this.StaticLowThresholdRes.Location = new System.Drawing.Point(176, 5);
            this.StaticLowThresholdRes.Name = "StaticLowThresholdRes";
            this.StaticLowThresholdRes.Size = new System.Drawing.Size(70, 23);
            this.StaticLowThresholdRes.Text = "Never Try";
            // 
            // StaticLowThreshold
            // 
            this.StaticLowThreshold.Location = new System.Drawing.Point(3, 5);
            this.StaticLowThreshold.Name = "StaticLowThreshold";
            this.StaticLowThreshold.Size = new System.Drawing.Size(143, 23);
            this.StaticLowThreshold.Text = "Low Delay Threshold";
            // 
            // ChkEnableLowBatterProtection
            // 
            this.ChkEnableLowBatterProtection.Location = new System.Drawing.Point(161, 4);
            this.ChkEnableLowBatterProtection.Name = "ChkEnableLowBatterProtection";
            this.ChkEnableLowBatterProtection.Size = new System.Drawing.Size(70, 23);
            this.ChkEnableLowBatterProtection.TabIndex = 21;
            this.ChkEnableLowBatterProtection.Text = "Enable";
            this.ChkEnableLowBatterProtection.CheckStateChanged += new System.EventHandler(this.ChkEnableLowBatterProtection_CheckStateChanged);
            // 
            // StaticLowBatteryProtection
            // 
            this.StaticLowBatteryProtection.Location = new System.Drawing.Point(12, 4);
            this.StaticLowBatteryProtection.Name = "StaticLowBatteryProtection";
            this.StaticLowBatteryProtection.Size = new System.Drawing.Size(143, 23);
            this.StaticLowBatteryProtection.Text = "Low Battery Protection";
            // 
            // BackupBatteryTabPage
            // 
            this.BackupBatteryTabPage.Controls.Add(this.panel7);
            this.BackupBatteryTabPage.Location = new System.Drawing.Point(4, 25);
            this.BackupBatteryTabPage.Name = "BackupBatteryTabPage";
            this.BackupBatteryTabPage.Size = new System.Drawing.Size(778, 390);
            this.BackupBatteryTabPage.Text = "BackupBattery";
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.StaticBackupBatteryMaxCapacity);
            this.panel7.Controls.Add(this.EditBackupBatteryTimeToFull);
            this.panel7.Controls.Add(this.EditBackupBatteryRemainingTime);
            this.panel7.Controls.Add(this.EditBackupBatteryTemperture);
            this.panel7.Controls.Add(this.EditBackupBattery_BatteryCharge);
            this.panel7.Controls.Add(this.EditBackupBatteryMaxCapacity);
            this.panel7.Controls.Add(this.EditBackupBatteryRemainingCapacity);
            this.panel7.Controls.Add(this.EditBackupBatteryVoltage);
            this.panel7.Controls.Add(this.StaticBackupBatteryTimeToFull);
            this.panel7.Controls.Add(this.StaticBackupBatteryRemainingTime);
            this.panel7.Controls.Add(this.StaticBatteryBatteryTemperture);
            this.panel7.Controls.Add(this.StaticBackupBattery_BatteryCharge);
            this.panel7.Controls.Add(this.StaticBackupBatteryRemainingCapacity);
            this.panel7.Controls.Add(this.StaticBackupBatteryVoltage);
            this.panel7.Controls.Add(this.StaticBackupBattery);
            this.panel7.Location = new System.Drawing.Point(3, 3);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(328, 236);
            // 
            // StaticBackupBatteryMaxCapacity
            // 
            this.StaticBackupBatteryMaxCapacity.Location = new System.Drawing.Point(3, 83);
            this.StaticBackupBatteryMaxCapacity.Name = "StaticBackupBatteryMaxCapacity";
            this.StaticBackupBatteryMaxCapacity.Size = new System.Drawing.Size(124, 23);
            this.StaticBackupBatteryMaxCapacity.Text = "Max Capacity";
            // 
            // EditBackupBatteryTimeToFull
            // 
            this.EditBackupBatteryTimeToFull.Location = new System.Drawing.Point(158, 199);
            this.EditBackupBatteryTimeToFull.Name = "EditBackupBatteryTimeToFull";
            this.EditBackupBatteryTimeToFull.ReadOnly = true;
            this.EditBackupBatteryTimeToFull.Size = new System.Drawing.Size(100, 23);
            this.EditBackupBatteryTimeToFull.TabIndex = 41;
            // 
            // EditBackupBatteryRemainingTime
            // 
            this.EditBackupBatteryRemainingTime.Location = new System.Drawing.Point(158, 170);
            this.EditBackupBatteryRemainingTime.Name = "EditBackupBatteryRemainingTime";
            this.EditBackupBatteryRemainingTime.ReadOnly = true;
            this.EditBackupBatteryRemainingTime.Size = new System.Drawing.Size(100, 23);
            this.EditBackupBatteryRemainingTime.TabIndex = 40;
            // 
            // EditBackupBatteryTemperture
            // 
            this.EditBackupBatteryTemperture.Location = new System.Drawing.Point(158, 141);
            this.EditBackupBatteryTemperture.Name = "EditBackupBatteryTemperture";
            this.EditBackupBatteryTemperture.ReadOnly = true;
            this.EditBackupBatteryTemperture.Size = new System.Drawing.Size(100, 23);
            this.EditBackupBatteryTemperture.TabIndex = 39;
            // 
            // EditBackupBattery_BatteryCharge
            // 
            this.EditBackupBattery_BatteryCharge.Location = new System.Drawing.Point(158, 112);
            this.EditBackupBattery_BatteryCharge.Name = "EditBackupBattery_BatteryCharge";
            this.EditBackupBattery_BatteryCharge.ReadOnly = true;
            this.EditBackupBattery_BatteryCharge.Size = new System.Drawing.Size(100, 23);
            this.EditBackupBattery_BatteryCharge.TabIndex = 38;
            // 
            // EditBackupBatteryMaxCapacity
            // 
            this.EditBackupBatteryMaxCapacity.Location = new System.Drawing.Point(158, 83);
            this.EditBackupBatteryMaxCapacity.Name = "EditBackupBatteryMaxCapacity";
            this.EditBackupBatteryMaxCapacity.ReadOnly = true;
            this.EditBackupBatteryMaxCapacity.Size = new System.Drawing.Size(100, 23);
            this.EditBackupBatteryMaxCapacity.TabIndex = 37;
            // 
            // EditBackupBatteryRemainingCapacity
            // 
            this.EditBackupBatteryRemainingCapacity.Location = new System.Drawing.Point(158, 54);
            this.EditBackupBatteryRemainingCapacity.Name = "EditBackupBatteryRemainingCapacity";
            this.EditBackupBatteryRemainingCapacity.ReadOnly = true;
            this.EditBackupBatteryRemainingCapacity.Size = new System.Drawing.Size(100, 23);
            this.EditBackupBatteryRemainingCapacity.TabIndex = 36;
            // 
            // EditBackupBatteryVoltage
            // 
            this.EditBackupBatteryVoltage.Location = new System.Drawing.Point(158, 25);
            this.EditBackupBatteryVoltage.Name = "EditBackupBatteryVoltage";
            this.EditBackupBatteryVoltage.ReadOnly = true;
            this.EditBackupBatteryVoltage.Size = new System.Drawing.Size(100, 23);
            this.EditBackupBatteryVoltage.TabIndex = 35;
            // 
            // StaticBackupBatteryTimeToFull
            // 
            this.StaticBackupBatteryTimeToFull.Location = new System.Drawing.Point(3, 199);
            this.StaticBackupBatteryTimeToFull.Name = "StaticBackupBatteryTimeToFull";
            this.StaticBackupBatteryTimeToFull.Size = new System.Drawing.Size(124, 23);
            this.StaticBackupBatteryTimeToFull.Text = "Time To Full";
            // 
            // StaticBackupBatteryRemainingTime
            // 
            this.StaticBackupBatteryRemainingTime.Location = new System.Drawing.Point(3, 170);
            this.StaticBackupBatteryRemainingTime.Name = "StaticBackupBatteryRemainingTime";
            this.StaticBackupBatteryRemainingTime.Size = new System.Drawing.Size(124, 23);
            this.StaticBackupBatteryRemainingTime.Text = "Remaining Time";
            // 
            // StaticBatteryBatteryTemperture
            // 
            this.StaticBatteryBatteryTemperture.Location = new System.Drawing.Point(3, 141);
            this.StaticBatteryBatteryTemperture.Name = "StaticBatteryBatteryTemperture";
            this.StaticBatteryBatteryTemperture.Size = new System.Drawing.Size(124, 23);
            this.StaticBatteryBatteryTemperture.Text = "Temperture";
            // 
            // StaticBackupBattery_BatteryCharge
            // 
            this.StaticBackupBattery_BatteryCharge.Location = new System.Drawing.Point(3, 112);
            this.StaticBackupBattery_BatteryCharge.Name = "StaticBackupBattery_BatteryCharge";
            this.StaticBackupBattery_BatteryCharge.Size = new System.Drawing.Size(124, 23);
            this.StaticBackupBattery_BatteryCharge.Text = "Battery Charge";
            // 
            // StaticBackupBatteryRemainingCapacity
            // 
            this.StaticBackupBatteryRemainingCapacity.Location = new System.Drawing.Point(3, 54);
            this.StaticBackupBatteryRemainingCapacity.Name = "StaticBackupBatteryRemainingCapacity";
            this.StaticBackupBatteryRemainingCapacity.Size = new System.Drawing.Size(124, 23);
            this.StaticBackupBatteryRemainingCapacity.Text = "Remaining Capacity";
            // 
            // StaticBackupBatteryVoltage
            // 
            this.StaticBackupBatteryVoltage.Location = new System.Drawing.Point(3, 25);
            this.StaticBackupBatteryVoltage.Name = "StaticBackupBatteryVoltage";
            this.StaticBackupBatteryVoltage.Size = new System.Drawing.Size(124, 23);
            this.StaticBackupBatteryVoltage.Text = "Voltage";
            // 
            // StaticBackupBattery
            // 
            this.StaticBackupBattery.Location = new System.Drawing.Point(3, 4);
            this.StaticBackupBattery.Name = "StaticBackupBattery";
            this.StaticBackupBattery.Size = new System.Drawing.Size(124, 23);
            this.StaticBackupBattery.Text = "Backup Battery";
            // 
            // AlarmWakeupTabPage
            // 
            this.AlarmWakeupTabPage.Controls.Add(this.panel1);
            this.AlarmWakeupTabPage.Location = new System.Drawing.Point(4, 25);
            this.AlarmWakeupTabPage.Name = "AlarmWakeupTabPage";
            this.AlarmWakeupTabPage.Size = new System.Drawing.Size(778, 390);
            this.AlarmWakeupTabPage.Text = "Alarm Wakeup";
            // 
            // panel1
            // 
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
            // 
            // StaticAlarmMinute
            // 
            this.StaticAlarmMinute.Location = new System.Drawing.Point(22, 124);
            this.StaticAlarmMinute.Name = "StaticAlarmMinute";
            this.StaticAlarmMinute.Size = new System.Drawing.Size(103, 23);
            this.StaticAlarmMinute.Text = "Minute";
            // 
            // StaticAlarmHour
            // 
            this.StaticAlarmHour.Location = new System.Drawing.Point(22, 95);
            this.StaticAlarmHour.Name = "StaticAlarmHour";
            this.StaticAlarmHour.Size = new System.Drawing.Size(103, 23);
            this.StaticAlarmHour.Text = "Hour";
            // 
            // EditAlarmMinute
            // 
            this.EditAlarmMinute.Location = new System.Drawing.Point(145, 124);
            this.EditAlarmMinute.Name = "EditAlarmMinute";
            this.EditAlarmMinute.Size = new System.Drawing.Size(100, 23);
            this.EditAlarmMinute.TabIndex = 60;
            // 
            // EditAlarmHour
            // 
            this.EditAlarmHour.Location = new System.Drawing.Point(145, 95);
            this.EditAlarmHour.Name = "EditAlarmHour";
            this.EditAlarmHour.Size = new System.Drawing.Size(100, 23);
            this.EditAlarmHour.TabIndex = 59;
            // 
            // EditAlarmDayOfWeek
            // 
            this.EditAlarmDayOfWeek.Location = new System.Drawing.Point(145, 66);
            this.EditAlarmDayOfWeek.Name = "EditAlarmDayOfWeek";
            this.EditAlarmDayOfWeek.Size = new System.Drawing.Size(100, 23);
            this.EditAlarmDayOfWeek.TabIndex = 58;
            // 
            // StaticAlarmDayOfWeek
            // 
            this.StaticAlarmDayOfWeek.Location = new System.Drawing.Point(22, 66);
            this.StaticAlarmDayOfWeek.Name = "StaticAlarmDayOfWeek";
            this.StaticAlarmDayOfWeek.Size = new System.Drawing.Size(103, 23);
            this.StaticAlarmDayOfWeek.Text = "Day of Week";
            // 
            // AlarmModeCmbx
            // 
            this.AlarmModeCmbx.Items.Add("No Alarm");
            this.AlarmModeCmbx.Items.Add("Hourly");
            this.AlarmModeCmbx.Items.Add("Daily");
            this.AlarmModeCmbx.Items.Add("Weekly");
            this.AlarmModeCmbx.Location = new System.Drawing.Point(156, 153);
            this.AlarmModeCmbx.Name = "AlarmModeCmbx";
            this.AlarmModeCmbx.Size = new System.Drawing.Size(89, 23);
            this.AlarmModeCmbx.TabIndex = 50;
            // 
            // StaticAlarmModeLabel
            // 
            this.StaticAlarmModeLabel.Location = new System.Drawing.Point(3, 153);
            this.StaticAlarmModeLabel.Name = "StaticAlarmModeLabel";
            this.StaticAlarmModeLabel.Size = new System.Drawing.Size(150, 23);
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
            this.AlarmStatusCmbx.Items.Add("ON");
            this.AlarmStatusCmbx.Items.Add("OFF");
            this.AlarmStatusCmbx.Location = new System.Drawing.Point(159, 8);
            this.AlarmStatusCmbx.Name = "AlarmStatusCmbx";
            this.AlarmStatusCmbx.Size = new System.Drawing.Size(89, 23);
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
            this.StaticAlarmStatusLabel.Text = "Alarm Wakeup Status :";
            // 
            // VPM
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(792, 424);
            this.Controls.Add(this.VPM_TabControl);
            this.Name = "VPM";
            this.Text = "TREK V3 VPM Sample Code";
            this.Load += new System.EventHandler(this.VPM_Load);
            this.Closed += new System.EventHandler(this.VPM_Closed);
            this.VPM_TabControl.ResumeLayout(false);
            this.MainTabPage.ResumeLayout(false);
            this.panel9.ResumeLayout(false);
            this.CommonPanel.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.LBPIgnitionTabPage.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel8.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.BackupBatteryTabPage.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            this.AlarmWakeupTabPage.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl VPM_TabControl;
        private System.Windows.Forms.TabPage MainTabPage;
        private System.Windows.Forms.TabPage LBPIgnitionTabPage;
        private System.Windows.Forms.TabPage BackupBatteryTabPage;
        private System.Windows.Forms.TabPage AlarmWakeupTabPage;
        private System.Windows.Forms.Panel CommonPanel;
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
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label StaticIgnDelayHardOff;
        private System.Windows.Forms.Label StaticIgnDelayHardOffUnit;
        private System.Windows.Forms.TextBox EditIgnDelayHardOff;
        private System.Windows.Forms.Label StaticIgnDelayOnUnit;
        private System.Windows.Forms.TextBox EditIgnDelayOn;
        private System.Windows.Forms.Label StaticIgnDelayOffEventUnit;
        private System.Windows.Forms.TextBox EditIgnDelayOffEvent;
        private System.Windows.Forms.Label StaticIgnDelayOn;
        private System.Windows.Forms.Label StaticIgnDelayOffEvent;
        private System.Windows.Forms.RadioButton RadioIgnDelayGet;
        private System.Windows.Forms.RadioButton RadioIgnDelaySet;
        private System.Windows.Forms.Button BtnIgnDelayApply;
        private System.Windows.Forms.Label StaticIgnitionDelayRes;
        private System.Windows.Forms.Label StaticIgnitionDelay;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel5;
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
        private System.Windows.Forms.Label StaticLowBatteryProtection;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Label StaticBackupBatteryMaxCapacity;
        private System.Windows.Forms.TextBox EditBackupBatteryTimeToFull;
        private System.Windows.Forms.TextBox EditBackupBatteryRemainingTime;
        private System.Windows.Forms.TextBox EditBackupBatteryTemperture;
        private System.Windows.Forms.TextBox EditBackupBattery_BatteryCharge;
        private System.Windows.Forms.TextBox EditBackupBatteryMaxCapacity;
        private System.Windows.Forms.TextBox EditBackupBatteryRemainingCapacity;
        private System.Windows.Forms.TextBox EditBackupBatteryVoltage;
        private System.Windows.Forms.Label StaticBackupBatteryTimeToFull;
        private System.Windows.Forms.Label StaticBackupBatteryRemainingTime;
        private System.Windows.Forms.Label StaticBatteryBatteryTemperture;
        private System.Windows.Forms.Label StaticBackupBattery_BatteryCharge;
        private System.Windows.Forms.Label StaticBackupBatteryRemainingCapacity;
        private System.Windows.Forms.Label StaticBackupBatteryVoltage;
        private System.Windows.Forms.Label StaticBackupBattery;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox AlarmModeCmbx;
        private System.Windows.Forms.Label StaticAlarmModeLabel;
        private System.Windows.Forms.Button BtnSetAlarmTime;
        private System.Windows.Forms.ComboBox AlarmStatusCmbx;
        private System.Windows.Forms.Button BtnGetAlarmStatus;
        private System.Windows.Forms.Button BtnSetAlarmStatus;
        private System.Windows.Forms.Button BtnGetAlarmTime;
        private System.Windows.Forms.Label StaticAlarmStatusLabel;
        private System.Windows.Forms.Button BtnLoadDefault;
        private System.Windows.Forms.TextBox StaticCurIgnStatusValue;
        private System.Windows.Forms.TextBox StaticCurBatteryVoltageValue;
        private System.Windows.Forms.Label StaticCurIgnStatus;
        private System.Windows.Forms.Label StaticCurBatteryVoltage;
        private System.Windows.Forms.TextBox StaticBatteryVoltageCBModeValue;
        private System.Windows.Forms.Label StaticBatteryVoltageCBMode;
        private System.Windows.Forms.TextBox StaticFirmwareVersionValue;
        private System.Windows.Forms.Label StaticFirmwareVersion;
        private System.Windows.Forms.TextBox StaticLibVersionValue;
        private System.Windows.Forms.Label StaticLibVersion;
        private System.Windows.Forms.Label StaticLBPThreshold;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Label StaticDefault12V;
        private System.Windows.Forms.Label StaticLowVoltageDefalultValue;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox EditPrebootThresholdValue24V;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox EditPrebootThresholdValue12V;
        private System.Windows.Forms.Label StaticPrebootThreshold;
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
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox EditIgnDelaySuspendOff;
        private System.Windows.Forms.Label StaticIgnDelaySuspendOff;
        private System.Windows.Forms.TrackBar TrkBrIgnitionDelayMode;
        private System.Windows.Forms.Label StaticIgnitionDelayModeSuspend;
        private System.Windows.Forms.Label StaticIgnitionDelayModeOff;
        private System.Windows.Forms.Label StaticIgnitionDelayMode;
        private System.Windows.Forms.Label StaticAlarmMinute;
        private System.Windows.Forms.Label StaticAlarmHour;
        private System.Windows.Forms.TextBox EditAlarmMinute;
        private System.Windows.Forms.TextBox EditAlarmHour;
        private System.Windows.Forms.TextBox EditAlarmDayOfWeek;
        private System.Windows.Forms.Label StaticAlarmDayOfWeek;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.Label StaticLastWakeupSourceRes;
        private System.Windows.Forms.ComboBox CmBxWakeupSource;
        private System.Windows.Forms.DomainUpDown DomainUDWakeupSourceStatus;
        private System.Windows.Forms.RadioButton RadioWakeupSourceGet;
        private System.Windows.Forms.RadioButton RadioWakeupSourceSet;
        private System.Windows.Forms.Button BtnWakeupSourceApply;
        private System.Windows.Forms.Label StaticWakeupSourceRes;
        private System.Windows.Forms.Label StaticWakeupSource;
        private System.Windows.Forms.Button BtnGetLastWakeupSource;
        private System.Windows.Forms.CheckBox ChkEnablePrebootLowBatterProtection;
        private System.Windows.Forms.Label StaticPrebootLowBatteryProtection;
    }
}

