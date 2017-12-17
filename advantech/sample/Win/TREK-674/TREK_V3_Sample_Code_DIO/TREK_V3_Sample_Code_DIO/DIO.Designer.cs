﻿namespace TREK_V3_Sample_Code_DIO
{
    partial class DIO
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DIO));
            this.StaticLibVersion = new System.Windows.Forms.Label();
            this.StaticLibVersionValue = new System.Windows.Forms.TextBox();
            this.StaticDI = new System.Windows.Forms.Label();
            this.PicBoxDI0 = new System.Windows.Forms.PictureBox();
            this.PicBoxDI1 = new System.Windows.Forms.PictureBox();
            this.StaticDO = new System.Windows.Forms.Label();
            this.RadioDO0 = new System.Windows.Forms.CheckBox();
            this.StaticDI0 = new System.Windows.Forms.Label();
            this.StaticDI1 = new System.Windows.Forms.Label();
            this.RadioDO1 = new System.Windows.Forms.CheckBox();
            this.GetDIOStatusTimer = new System.Windows.Forms.Timer(this.components);
            this.MonitorBtn = new System.Windows.Forms.Button();
            this.PicBoxDI2 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.PicBoxDI3 = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.radioButtonVoiceSourceMicIN = new System.Windows.Forms.RadioButton();
            this.radioButtonVoiceSourceBluetooth = new System.Windows.Forms.RadioButton();
            this.radioButtonMC809X = new System.Windows.Forms.RadioButton();
            this.radioButtonMC73X4 = new System.Windows.Forms.RadioButton();
            this.groupBoxVoiceSource = new System.Windows.Forms.GroupBox();
            this.groupBoxVoiceModule = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.PicBoxDI0)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicBoxDI1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicBoxDI2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicBoxDI3)).BeginInit();
            this.groupBoxVoiceSource.SuspendLayout();
            this.groupBoxVoiceModule.SuspendLayout();
            this.SuspendLayout();
            // 
            // StaticLibVersion
            // 
            this.StaticLibVersion.Location = new System.Drawing.Point(3, 18);
            this.StaticLibVersion.Name = "StaticLibVersion";
            this.StaticLibVersion.Size = new System.Drawing.Size(109, 23);
            this.StaticLibVersion.TabIndex = 21;
            this.StaticLibVersion.Text = "Library Version : ";
            // 
            // StaticLibVersionValue
            // 
            this.StaticLibVersionValue.Location = new System.Drawing.Point(118, 18);
            this.StaticLibVersionValue.Name = "StaticLibVersionValue";
            this.StaticLibVersionValue.Size = new System.Drawing.Size(206, 22);
            this.StaticLibVersionValue.TabIndex = 1;
            // 
            // StaticDI
            // 
            this.StaticDI.Location = new System.Drawing.Point(3, 44);
            this.StaticDI.Name = "StaticDI";
            this.StaticDI.Size = new System.Drawing.Size(109, 23);
            this.StaticDI.TabIndex = 20;
            this.StaticDI.Text = "Digital Input";
            // 
            // PicBoxDI0
            // 
            this.PicBoxDI0.Image = ((System.Drawing.Image)(resources.GetObject("PicBoxDI0.Image")));
            this.PicBoxDI0.Location = new System.Drawing.Point(3, 70);
            this.PicBoxDI0.Name = "PicBoxDI0";
            this.PicBoxDI0.Size = new System.Drawing.Size(64, 69);
            this.PicBoxDI0.TabIndex = 19;
            this.PicBoxDI0.TabStop = false;
            // 
            // PicBoxDI1
            // 
            this.PicBoxDI1.Image = ((System.Drawing.Image)(resources.GetObject("PicBoxDI1.Image")));
            this.PicBoxDI1.Location = new System.Drawing.Point(80, 70);
            this.PicBoxDI1.Name = "PicBoxDI1";
            this.PicBoxDI1.Size = new System.Drawing.Size(64, 69);
            this.PicBoxDI1.TabIndex = 18;
            this.PicBoxDI1.TabStop = false;
            // 
            // StaticDO
            // 
            this.StaticDO.Location = new System.Drawing.Point(335, 44);
            this.StaticDO.Name = "StaticDO";
            this.StaticDO.Size = new System.Drawing.Size(109, 23);
            this.StaticDO.TabIndex = 17;
            this.StaticDO.Text = "Digital Output";
            // 
            // RadioDO0
            // 
            this.RadioDO0.Checked = true;
            this.RadioDO0.CheckState = System.Windows.Forms.CheckState.Checked;
            this.RadioDO0.Location = new System.Drawing.Point(335, 70);
            this.RadioDO0.Name = "RadioDO0";
            this.RadioDO0.Size = new System.Drawing.Size(100, 20);
            this.RadioDO0.TabIndex = 9;
            this.RadioDO0.Text = "Pin0";
            this.RadioDO0.CheckStateChanged += new System.EventHandler(this.RadioDO0_CheckStateChanged);
            // 
            // StaticDI0
            // 
            this.StaticDI0.Location = new System.Drawing.Point(19, 142);
            this.StaticDI0.Name = "StaticDI0";
            this.StaticDI0.Size = new System.Drawing.Size(34, 20);
            this.StaticDI0.TabIndex = 16;
            this.StaticDI0.Text = "Pin0";
            // 
            // StaticDI1
            // 
            this.StaticDI1.Location = new System.Drawing.Point(94, 142);
            this.StaticDI1.Name = "StaticDI1";
            this.StaticDI1.Size = new System.Drawing.Size(34, 20);
            this.StaticDI1.TabIndex = 15;
            this.StaticDI1.Text = "Pin1";
            // 
            // RadioDO1
            // 
            this.RadioDO1.Checked = true;
            this.RadioDO1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.RadioDO1.Location = new System.Drawing.Point(335, 96);
            this.RadioDO1.Name = "RadioDO1";
            this.RadioDO1.Size = new System.Drawing.Size(100, 20);
            this.RadioDO1.TabIndex = 13;
            this.RadioDO1.Text = "Pin1";
            this.RadioDO1.CheckStateChanged += new System.EventHandler(this.RadioDO1_CheckStateChanged);
            // 
            // GetDIOStatusTimer
            // 
            this.GetDIOStatusTimer.Interval = 500;
            this.GetDIOStatusTimer.Tick += new System.EventHandler(this.GetDIOStatusTimer_Tick);
            // 
            // MonitorBtn
            // 
            this.MonitorBtn.Location = new System.Drawing.Point(3, 165);
            this.MonitorBtn.Name = "MonitorBtn";
            this.MonitorBtn.Size = new System.Drawing.Size(154, 20);
            this.MonitorBtn.TabIndex = 14;
            this.MonitorBtn.Text = "Start Monitor DI Status";
            this.MonitorBtn.Click += new System.EventHandler(this.MonitorBtn_Click);
            // 
            // PicBoxDI2
            // 
            this.PicBoxDI2.Image = ((System.Drawing.Image)(resources.GetObject("PicBoxDI2.Image")));
            this.PicBoxDI2.Location = new System.Drawing.Point(157, 70);
            this.PicBoxDI2.Name = "PicBoxDI2";
            this.PicBoxDI2.Size = new System.Drawing.Size(64, 69);
            this.PicBoxDI2.TabIndex = 22;
            this.PicBoxDI2.TabStop = false;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(171, 142);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 20);
            this.label1.TabIndex = 23;
            this.label1.Text = "Pin2";
            // 
            // PicBoxDI3
            // 
            this.PicBoxDI3.Image = ((System.Drawing.Image)(resources.GetObject("PicBoxDI3.Image")));
            this.PicBoxDI3.Location = new System.Drawing.Point(235, 70);
            this.PicBoxDI3.Name = "PicBoxDI3";
            this.PicBoxDI3.Size = new System.Drawing.Size(64, 69);
            this.PicBoxDI3.TabIndex = 24;
            this.PicBoxDI3.TabStop = false;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(247, 142);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 20);
            this.label2.TabIndex = 25;
            this.label2.Text = "Pin3";
            // 
            // radioButtonVoiceSourceMicIN
            // 
            this.radioButtonVoiceSourceMicIN.AutoSize = true;
            this.radioButtonVoiceSourceMicIN.Location = new System.Drawing.Point(16, 41);
            this.radioButtonVoiceSourceMicIN.Margin = new System.Windows.Forms.Padding(2);
            this.radioButtonVoiceSourceMicIN.Name = "radioButtonVoiceSourceMicIN";
            this.radioButtonVoiceSourceMicIN.Size = new System.Drawing.Size(61, 16);
            this.radioButtonVoiceSourceMicIN.TabIndex = 29;
            this.radioButtonVoiceSourceMicIN.TabStop = true;
            this.radioButtonVoiceSourceMicIN.Text = "MIC-IN";
            this.radioButtonVoiceSourceMicIN.UseVisualStyleBackColor = true;
            // 
            // radioButtonVoiceSourceBluetooth
            // 
            this.radioButtonVoiceSourceBluetooth.AutoSize = true;
            this.radioButtonVoiceSourceBluetooth.Location = new System.Drawing.Point(16, 20);
            this.radioButtonVoiceSourceBluetooth.Margin = new System.Windows.Forms.Padding(2);
            this.radioButtonVoiceSourceBluetooth.Name = "radioButtonVoiceSourceBluetooth";
            this.radioButtonVoiceSourceBluetooth.Size = new System.Drawing.Size(69, 16);
            this.radioButtonVoiceSourceBluetooth.TabIndex = 30;
            this.radioButtonVoiceSourceBluetooth.TabStop = true;
            this.radioButtonVoiceSourceBluetooth.Text = "Bluetooth";
            this.radioButtonVoiceSourceBluetooth.UseVisualStyleBackColor = true;
            this.radioButtonVoiceSourceBluetooth.CheckedChanged += new System.EventHandler(this.radioButtonVoiceSourceBluetooth_CheckedChanged);
            // 
            // radioButtonMC809X
            // 
            this.radioButtonMC809X.AutoSize = true;
            this.radioButtonMC809X.Location = new System.Drawing.Point(17, 20);
            this.radioButtonMC809X.Margin = new System.Windows.Forms.Padding(2);
            this.radioButtonMC809X.Name = "radioButtonMC809X";
            this.radioButtonMC809X.Size = new System.Drawing.Size(67, 16);
            this.radioButtonMC809X.TabIndex = 33;
            this.radioButtonMC809X.TabStop = true;
            this.radioButtonMC809X.Text = "MC809X";
            this.radioButtonMC809X.UseVisualStyleBackColor = true;
            this.radioButtonMC809X.CheckedChanged += new System.EventHandler(this.radioButtonMC809X_CheckedChanged);
            // 
            // radioButtonMC73X4
            // 
            this.radioButtonMC73X4.AutoSize = true;
            this.radioButtonMC73X4.Location = new System.Drawing.Point(17, 41);
            this.radioButtonMC73X4.Margin = new System.Windows.Forms.Padding(2);
            this.radioButtonMC73X4.Name = "radioButtonMC73X4";
            this.radioButtonMC73X4.Size = new System.Drawing.Size(67, 16);
            this.radioButtonMC73X4.TabIndex = 32;
            this.radioButtonMC73X4.TabStop = true;
            this.radioButtonMC73X4.Text = "MX73X4";
            this.radioButtonMC73X4.UseVisualStyleBackColor = true;
            // 
            // groupBoxVoiceSource
            // 
            this.groupBoxVoiceSource.Controls.Add(this.radioButtonVoiceSourceBluetooth);
            this.groupBoxVoiceSource.Controls.Add(this.radioButtonVoiceSourceMicIN);
            this.groupBoxVoiceSource.Location = new System.Drawing.Point(426, 44);
            this.groupBoxVoiceSource.Name = "groupBoxVoiceSource";
            this.groupBoxVoiceSource.Size = new System.Drawing.Size(100, 69);
            this.groupBoxVoiceSource.TabIndex = 34;
            this.groupBoxVoiceSource.TabStop = false;
            this.groupBoxVoiceSource.Text = "Voice Source";
            // 
            // groupBoxVoiceModule
            // 
            this.groupBoxVoiceModule.Controls.Add(this.radioButtonMC809X);
            this.groupBoxVoiceModule.Controls.Add(this.radioButtonMC73X4);
            this.groupBoxVoiceModule.Location = new System.Drawing.Point(426, 119);
            this.groupBoxVoiceModule.Name = "groupBoxVoiceModule";
            this.groupBoxVoiceModule.Size = new System.Drawing.Size(100, 66);
            this.groupBoxVoiceModule.TabIndex = 35;
            this.groupBoxVoiceModule.TabStop = false;
            this.groupBoxVoiceModule.Text = "Voice Module";
            // 
            // DIO
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(556, 201);
            this.Controls.Add(this.groupBoxVoiceModule);
            this.Controls.Add(this.groupBoxVoiceSource);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.PicBoxDI3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.PicBoxDI2);
            this.Controls.Add(this.MonitorBtn);
            this.Controls.Add(this.RadioDO1);
            this.Controls.Add(this.StaticDI1);
            this.Controls.Add(this.StaticDI0);
            this.Controls.Add(this.RadioDO0);
            this.Controls.Add(this.StaticDO);
            this.Controls.Add(this.PicBoxDI1);
            this.Controls.Add(this.PicBoxDI0);
            this.Controls.Add(this.StaticDI);
            this.Controls.Add(this.StaticLibVersionValue);
            this.Controls.Add(this.StaticLibVersion);
            this.Name = "DIO";
            this.Text = "TREK V3 DIO Sample Code";
            this.Load += new System.EventHandler(this.DIO_Load);
            this.Closed += new System.EventHandler(this.DIO_Closed);
            ((System.ComponentModel.ISupportInitialize)(this.PicBoxDI0)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicBoxDI1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicBoxDI2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicBoxDI3)).EndInit();
            this.groupBoxVoiceSource.ResumeLayout(false);
            this.groupBoxVoiceSource.PerformLayout();
            this.groupBoxVoiceModule.ResumeLayout(false);
            this.groupBoxVoiceModule.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label StaticLibVersion;
        private System.Windows.Forms.TextBox StaticLibVersionValue;
        private System.Windows.Forms.Label StaticDI;
        private System.Windows.Forms.PictureBox PicBoxDI0;
        private System.Windows.Forms.PictureBox PicBoxDI1;
        private System.Windows.Forms.Label StaticDO;
        private System.Windows.Forms.CheckBox RadioDO0;
        private System.Windows.Forms.Label StaticDI0;
        private System.Windows.Forms.Label StaticDI1;
        private System.Windows.Forms.CheckBox RadioDO1;
        private System.Windows.Forms.Timer GetDIOStatusTimer;
        private System.Windows.Forms.Button MonitorBtn;
        private System.Windows.Forms.PictureBox PicBoxDI2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox PicBoxDI3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton radioButtonVoiceSourceMicIN;
        private System.Windows.Forms.RadioButton radioButtonVoiceSourceBluetooth;
        private System.Windows.Forms.RadioButton radioButtonMC809X;
        private System.Windows.Forms.RadioButton radioButtonMC73X4;
        private System.Windows.Forms.GroupBox groupBoxVoiceSource;
        private System.Windows.Forms.GroupBox groupBoxVoiceModule;
    }
}

