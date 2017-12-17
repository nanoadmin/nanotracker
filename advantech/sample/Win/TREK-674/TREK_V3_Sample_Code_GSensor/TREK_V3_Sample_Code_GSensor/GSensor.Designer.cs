namespace TREK_V3_Sample_Code_GSensor
{
    partial class GSensor
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
            this.StaticGSensorXValue = new System.Windows.Forms.Label();
            this.StaticGSensorYValue = new System.Windows.Forms.Label();
            this.StaticGSensorZValue = new System.Windows.Forms.Label();
            this.TkBarGSensorStatus = new System.Windows.Forms.TrackBar();
            this.EditGSensorXValue = new System.Windows.Forms.TextBox();
            this.StaticGSenserStatus = new System.Windows.Forms.Label();
            this.StaticLibVersionValue = new System.Windows.Forms.TextBox();
            this.EditGSensorYValue = new System.Windows.Forms.TextBox();
            this.EditGSensorZValue = new System.Windows.Forms.TextBox();
            this.StaticLibVersion = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.GSensorGetValueTimer = new System.Windows.Forms.Timer(this.components);
            this.labelGsensorRes = new System.Windows.Forms.Label();
            this.comboBoxGsensorResValue = new System.Windows.Forms.ComboBox();
            this.buttonGsensorResGet = new System.Windows.Forms.Button();
            this.buttonGsensorResSet = new System.Windows.Forms.Button();
            this.labelGsensorUnit = new System.Windows.Forms.Label();
            this.labelAlarm = new System.Windows.Forms.Label();
            this.checkBoxAlarmActive = new System.Windows.Forms.CheckBox();
            this.textBoxAlarmThresholdValue = new System.Windows.Forms.TextBox();
            this.labelAlarmThreshold = new System.Windows.Forms.Label();
            this.textBoxWakeupThresholdValue = new System.Windows.Forms.TextBox();
            this.labelWakeupThreshold = new System.Windows.Forms.Label();
            this.buttonAlarmThSet = new System.Windows.Forms.Button();
            this.buttonAlarmThGet = new System.Windows.Forms.Button();
            this.buttonWakeupThSet = new System.Windows.Forms.Button();
            this.buttonWakeupThGet = new System.Windows.Forms.Button();
            this.listViewGsensorData = new System.Windows.Forms.ListView();
            this.buttonClear = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.TkBarGSensorStatus)).BeginInit();
            this.SuspendLayout();
            // 
            // StaticGSensorXValue
            // 
            this.StaticGSensorXValue.Location = new System.Drawing.Point(10, 79);
            this.StaticGSensorXValue.Name = "StaticGSensorXValue";
            this.StaticGSensorXValue.Size = new System.Drawing.Size(125, 20);
            this.StaticGSensorXValue.TabIndex = 15;
            this.StaticGSensorXValue.Text = "X-Axis";
            // 
            // StaticGSensorYValue
            // 
            this.StaticGSensorYValue.Location = new System.Drawing.Point(10, 108);
            this.StaticGSensorYValue.Name = "StaticGSensorYValue";
            this.StaticGSensorYValue.Size = new System.Drawing.Size(125, 20);
            this.StaticGSensorYValue.TabIndex = 14;
            this.StaticGSensorYValue.Text = "Y-Axis";
            // 
            // StaticGSensorZValue
            // 
            this.StaticGSensorZValue.Location = new System.Drawing.Point(10, 138);
            this.StaticGSensorZValue.Name = "StaticGSensorZValue";
            this.StaticGSensorZValue.Size = new System.Drawing.Size(125, 20);
            this.StaticGSensorZValue.TabIndex = 13;
            this.StaticGSensorZValue.Text = "Z-Axis";
            // 
            // TkBarGSensorStatus
            // 
            this.TkBarGSensorStatus.Location = new System.Drawing.Point(166, 48);
            this.TkBarGSensorStatus.Maximum = 1;
            this.TkBarGSensorStatus.Name = "TkBarGSensorStatus";
            this.TkBarGSensorStatus.Size = new System.Drawing.Size(49, 42);
            this.TkBarGSensorStatus.TabIndex = 3;
            this.TkBarGSensorStatus.ValueChanged += new System.EventHandler(this.TkBarGSensorStatus_ValueChanged);
            // 
            // EditGSensorXValue
            // 
            this.EditGSensorXValue.Location = new System.Drawing.Point(141, 77);
            this.EditGSensorXValue.Name = "EditGSensorXValue";
            this.EditGSensorXValue.Size = new System.Drawing.Size(100, 22);
            this.EditGSensorXValue.TabIndex = 4;
            // 
            // StaticGSenserStatus
            // 
            this.StaticGSenserStatus.Location = new System.Drawing.Point(10, 48);
            this.StaticGSenserStatus.Name = "StaticGSenserStatus";
            this.StaticGSenserStatus.Size = new System.Drawing.Size(125, 20);
            this.StaticGSenserStatus.TabIndex = 12;
            this.StaticGSenserStatus.Text = "GSensor Status";
            // 
            // StaticLibVersionValue
            // 
            this.StaticLibVersionValue.Location = new System.Drawing.Point(141, 12);
            this.StaticLibVersionValue.Name = "StaticLibVersionValue";
            this.StaticLibVersionValue.Size = new System.Drawing.Size(160, 22);
            this.StaticLibVersionValue.TabIndex = 9;
            // 
            // EditGSensorYValue
            // 
            this.EditGSensorYValue.Location = new System.Drawing.Point(141, 106);
            this.EditGSensorYValue.Name = "EditGSensorYValue";
            this.EditGSensorYValue.Size = new System.Drawing.Size(100, 22);
            this.EditGSensorYValue.TabIndex = 10;
            // 
            // EditGSensorZValue
            // 
            this.EditGSensorZValue.Location = new System.Drawing.Point(141, 135);
            this.EditGSensorZValue.Name = "EditGSensorZValue";
            this.EditGSensorZValue.Size = new System.Drawing.Size(100, 22);
            this.EditGSensorZValue.TabIndex = 11;
            // 
            // StaticLibVersion
            // 
            this.StaticLibVersion.Location = new System.Drawing.Point(10, 15);
            this.StaticLibVersion.Name = "StaticLibVersion";
            this.StaticLibVersion.Size = new System.Drawing.Size(125, 23);
            this.StaticLibVersion.TabIndex = 2;
            this.StaticLibVersion.Text = "Library Version : ";
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(141, 48);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(31, 20);
            this.label5.TabIndex = 1;
            this.label5.Text = "OFF";
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(210, 48);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(31, 20);
            this.label6.TabIndex = 0;
            this.label6.Text = "ON";
            // 
            // GSensorGetValueTimer
            // 
            this.GSensorGetValueTimer.Interval = 1000;
            this.GSensorGetValueTimer.Tick += new System.EventHandler(this.GSensorGetValueTimer_Tick);
            // 
            // labelGsensorRes
            // 
            this.labelGsensorRes.Location = new System.Drawing.Point(10, 168);
            this.labelGsensorRes.Name = "labelGsensorRes";
            this.labelGsensorRes.Size = new System.Drawing.Size(125, 20);
            this.labelGsensorRes.TabIndex = 16;
            this.labelGsensorRes.Text = "Resolution";
            // 
            // comboBoxGsensorResValue
            // 
            this.comboBoxGsensorResValue.FormattingEnabled = true;
            this.comboBoxGsensorResValue.Location = new System.Drawing.Point(141, 167);
            this.comboBoxGsensorResValue.Name = "comboBoxGsensorResValue";
            this.comboBoxGsensorResValue.Size = new System.Drawing.Size(100, 20);
            this.comboBoxGsensorResValue.TabIndex = 17;
            // 
            // buttonGsensorResGet
            // 
            this.buttonGsensorResGet.Location = new System.Drawing.Point(264, 163);
            this.buttonGsensorResGet.Name = "buttonGsensorResGet";
            this.buttonGsensorResGet.Size = new System.Drawing.Size(43, 23);
            this.buttonGsensorResGet.TabIndex = 18;
            this.buttonGsensorResGet.Text = "Get";
            this.buttonGsensorResGet.UseVisualStyleBackColor = true;
            this.buttonGsensorResGet.Click += new System.EventHandler(this.buttonGsensorResGet_Click);
            // 
            // buttonGsensorResSet
            // 
            this.buttonGsensorResSet.Location = new System.Drawing.Point(320, 163);
            this.buttonGsensorResSet.Name = "buttonGsensorResSet";
            this.buttonGsensorResSet.Size = new System.Drawing.Size(43, 23);
            this.buttonGsensorResSet.TabIndex = 19;
            this.buttonGsensorResSet.Text = "Set";
            this.buttonGsensorResSet.UseVisualStyleBackColor = true;
            this.buttonGsensorResSet.Click += new System.EventHandler(this.buttonGsensorResSet_Click);
            // 
            // labelGsensorUnit
            // 
            this.labelGsensorUnit.Location = new System.Drawing.Point(256, 80);
            this.labelGsensorUnit.Name = "labelGsensorUnit";
            this.labelGsensorUnit.Size = new System.Drawing.Size(45, 20);
            this.labelGsensorUnit.TabIndex = 20;
            this.labelGsensorUnit.Text = "unit: mg";
            // 
            // labelAlarm
            // 
            this.labelAlarm.Location = new System.Drawing.Point(377, 20);
            this.labelAlarm.Name = "labelAlarm";
            this.labelAlarm.Size = new System.Drawing.Size(44, 20);
            this.labelAlarm.TabIndex = 21;
            this.labelAlarm.Text = "Alarm";
            // 
            // checkBoxAlarmActive
            // 
            this.checkBoxAlarmActive.AutoSize = true;
            this.checkBoxAlarmActive.Enabled = false;
            this.checkBoxAlarmActive.Location = new System.Drawing.Point(421, 18);
            this.checkBoxAlarmActive.Name = "checkBoxAlarmActive";
            this.checkBoxAlarmActive.Size = new System.Drawing.Size(54, 16);
            this.checkBoxAlarmActive.TabIndex = 22;
            this.checkBoxAlarmActive.Text = "Active";
            this.checkBoxAlarmActive.UseVisualStyleBackColor = true;
            this.checkBoxAlarmActive.CheckedChanged += new System.EventHandler(this.checkBoxAlarmActive_CheckedChanged);
            // 
            // textBoxAlarmThresholdValue
            // 
            this.textBoxAlarmThresholdValue.Location = new System.Drawing.Point(141, 225);
            this.textBoxAlarmThresholdValue.Name = "textBoxAlarmThresholdValue";
            this.textBoxAlarmThresholdValue.Size = new System.Drawing.Size(100, 22);
            this.textBoxAlarmThresholdValue.TabIndex = 23;
            // 
            // labelAlarmThreshold
            // 
            this.labelAlarmThreshold.Location = new System.Drawing.Point(10, 228);
            this.labelAlarmThreshold.Name = "labelAlarmThreshold";
            this.labelAlarmThreshold.Size = new System.Drawing.Size(125, 20);
            this.labelAlarmThreshold.TabIndex = 24;
            this.labelAlarmThreshold.Text = "Alarm Threshold";
            // 
            // textBoxWakeupThresholdValue
            // 
            this.textBoxWakeupThresholdValue.Location = new System.Drawing.Point(141, 195);
            this.textBoxWakeupThresholdValue.Name = "textBoxWakeupThresholdValue";
            this.textBoxWakeupThresholdValue.Size = new System.Drawing.Size(100, 22);
            this.textBoxWakeupThresholdValue.TabIndex = 25;
            // 
            // labelWakeupThreshold
            // 
            this.labelWakeupThreshold.Location = new System.Drawing.Point(10, 197);
            this.labelWakeupThreshold.Name = "labelWakeupThreshold";
            this.labelWakeupThreshold.Size = new System.Drawing.Size(125, 20);
            this.labelWakeupThreshold.TabIndex = 26;
            this.labelWakeupThreshold.Text = "Wakeup Threshold";
            // 
            // buttonAlarmThSet
            // 
            this.buttonAlarmThSet.Location = new System.Drawing.Point(320, 223);
            this.buttonAlarmThSet.Name = "buttonAlarmThSet";
            this.buttonAlarmThSet.Size = new System.Drawing.Size(43, 23);
            this.buttonAlarmThSet.TabIndex = 28;
            this.buttonAlarmThSet.Text = "Set";
            this.buttonAlarmThSet.UseVisualStyleBackColor = true;
            this.buttonAlarmThSet.Click += new System.EventHandler(this.buttonAlarmThSet_Click);
            // 
            // buttonAlarmThGet
            // 
            this.buttonAlarmThGet.Location = new System.Drawing.Point(264, 223);
            this.buttonAlarmThGet.Name = "buttonAlarmThGet";
            this.buttonAlarmThGet.Size = new System.Drawing.Size(43, 23);
            this.buttonAlarmThGet.TabIndex = 27;
            this.buttonAlarmThGet.Text = "Get";
            this.buttonAlarmThGet.UseVisualStyleBackColor = true;
            this.buttonAlarmThGet.Click += new System.EventHandler(this.buttonAlarmThGet_Click);
            // 
            // buttonWakeupThSet
            // 
            this.buttonWakeupThSet.Location = new System.Drawing.Point(320, 194);
            this.buttonWakeupThSet.Name = "buttonWakeupThSet";
            this.buttonWakeupThSet.Size = new System.Drawing.Size(43, 23);
            this.buttonWakeupThSet.TabIndex = 30;
            this.buttonWakeupThSet.Text = "Set";
            this.buttonWakeupThSet.UseVisualStyleBackColor = true;
            this.buttonWakeupThSet.Click += new System.EventHandler(this.buttonWakeupThSet_Click);
            // 
            // buttonWakeupThGet
            // 
            this.buttonWakeupThGet.Location = new System.Drawing.Point(264, 194);
            this.buttonWakeupThGet.Name = "buttonWakeupThGet";
            this.buttonWakeupThGet.Size = new System.Drawing.Size(43, 23);
            this.buttonWakeupThGet.TabIndex = 29;
            this.buttonWakeupThGet.Text = "Get";
            this.buttonWakeupThGet.UseVisualStyleBackColor = true;
            this.buttonWakeupThGet.Click += new System.EventHandler(this.buttonWakeupThGet_Click);
            // 
            // listViewGsensorData
            // 
            this.listViewGsensorData.Location = new System.Drawing.Point(375, 48);
            this.listViewGsensorData.Name = "listViewGsensorData";
            this.listViewGsensorData.Size = new System.Drawing.Size(197, 200);
            this.listViewGsensorData.TabIndex = 31;
            this.listViewGsensorData.UseCompatibleStateImageBehavior = false;
            this.listViewGsensorData.View = System.Windows.Forms.View.Details;
            // 
            // buttonClear
            // 
            this.buttonClear.Location = new System.Drawing.Point(518, 15);
            this.buttonClear.Name = "buttonClear";
            this.buttonClear.Size = new System.Drawing.Size(54, 23);
            this.buttonClear.TabIndex = 32;
            this.buttonClear.Text = "Clear";
            this.buttonClear.UseVisualStyleBackColor = true;
            this.buttonClear.Click += new System.EventHandler(this.buttonClear_Click);
            // 
            // GSensor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(584, 263);
            this.Controls.Add(this.buttonClear);
            this.Controls.Add(this.listViewGsensorData);
            this.Controls.Add(this.buttonWakeupThSet);
            this.Controls.Add(this.buttonWakeupThGet);
            this.Controls.Add(this.buttonAlarmThSet);
            this.Controls.Add(this.buttonAlarmThGet);
            this.Controls.Add(this.textBoxWakeupThresholdValue);
            this.Controls.Add(this.labelWakeupThreshold);
            this.Controls.Add(this.textBoxAlarmThresholdValue);
            this.Controls.Add(this.labelAlarmThreshold);
            this.Controls.Add(this.checkBoxAlarmActive);
            this.Controls.Add(this.labelAlarm);
            this.Controls.Add(this.labelGsensorUnit);
            this.Controls.Add(this.buttonGsensorResSet);
            this.Controls.Add(this.buttonGsensorResGet);
            this.Controls.Add(this.comboBoxGsensorResValue);
            this.Controls.Add(this.labelGsensorRes);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.StaticLibVersion);
            this.Controls.Add(this.EditGSensorZValue);
            this.Controls.Add(this.EditGSensorYValue);
            this.Controls.Add(this.StaticLibVersionValue);
            this.Controls.Add(this.StaticGSenserStatus);
            this.Controls.Add(this.EditGSensorXValue);
            this.Controls.Add(this.TkBarGSensorStatus);
            this.Controls.Add(this.StaticGSensorZValue);
            this.Controls.Add(this.StaticGSensorYValue);
            this.Controls.Add(this.StaticGSensorXValue);
            this.Name = "GSensor";
            this.Text = "TREK V3 Sample Code GSensor";
            this.Load += new System.EventHandler(this.GSensor_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.GSensor_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.TkBarGSensorStatus)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label StaticGSensorXValue;
        private System.Windows.Forms.Label StaticGSensorYValue;
        private System.Windows.Forms.Label StaticGSensorZValue;
        private System.Windows.Forms.TrackBar TkBarGSensorStatus;
        private System.Windows.Forms.TextBox EditGSensorXValue;
        private System.Windows.Forms.Label StaticGSenserStatus;
        private System.Windows.Forms.TextBox StaticLibVersionValue;
        private System.Windows.Forms.TextBox EditGSensorYValue;
        private System.Windows.Forms.TextBox EditGSensorZValue;
        private System.Windows.Forms.Label StaticLibVersion;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Timer GSensorGetValueTimer;
        private System.Windows.Forms.Label labelGsensorRes;
        private System.Windows.Forms.ComboBox comboBoxGsensorResValue;
        private System.Windows.Forms.Button buttonGsensorResGet;
        private System.Windows.Forms.Button buttonGsensorResSet;
        private System.Windows.Forms.Label labelGsensorUnit;
        private System.Windows.Forms.Label labelAlarm;
        private System.Windows.Forms.CheckBox checkBoxAlarmActive;
        private System.Windows.Forms.TextBox textBoxAlarmThresholdValue;
        private System.Windows.Forms.Label labelAlarmThreshold;
        private System.Windows.Forms.TextBox textBoxWakeupThresholdValue;
        private System.Windows.Forms.Label labelWakeupThreshold;
        private System.Windows.Forms.Button buttonAlarmThSet;
        private System.Windows.Forms.Button buttonAlarmThGet;
        private System.Windows.Forms.Button buttonWakeupThSet;
        private System.Windows.Forms.Button buttonWakeupThGet;
        private System.Windows.Forms.ListView listViewGsensorData;
        private System.Windows.Forms.Button buttonClear;
    }
}

