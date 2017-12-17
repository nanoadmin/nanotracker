namespace TREK_V3_Sample_Code_DIO
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
            this.GetDIOStatusTimer = new System.Windows.Forms.Timer();
            this.MonitorBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // StaticLibVersion
            // 
            this.StaticLibVersion.Location = new System.Drawing.Point(3, 18);
            this.StaticLibVersion.Name = "StaticLibVersion";
            this.StaticLibVersion.Size = new System.Drawing.Size(109, 23);
            this.StaticLibVersion.Text = "Library Version : ";
            // 
            // StaticLibVersionValue
            // 
            this.StaticLibVersionValue.Location = new System.Drawing.Point(118, 18);
            this.StaticLibVersionValue.Name = "StaticLibVersionValue";
            this.StaticLibVersionValue.Size = new System.Drawing.Size(206, 23);
            this.StaticLibVersionValue.TabIndex = 1;
            // 
            // StaticDI
            // 
            this.StaticDI.Location = new System.Drawing.Point(3, 44);
            this.StaticDI.Name = "StaticDI";
            this.StaticDI.Size = new System.Drawing.Size(109, 23);
            this.StaticDI.Text = "Digital Input";
            // 
            // PicBoxDI0
            // 
            this.PicBoxDI0.Image = ((System.Drawing.Image)(resources.GetObject("PicBoxDI0.Image")));
            this.PicBoxDI0.Location = new System.Drawing.Point(3, 70);
            this.PicBoxDI0.Name = "PicBoxDI0";
            this.PicBoxDI0.Size = new System.Drawing.Size(64, 69);
            // 
            // PicBoxDI1
            // 
            this.PicBoxDI1.Image = ((System.Drawing.Image)(resources.GetObject("PicBoxDI1.Image")));
            this.PicBoxDI1.Location = new System.Drawing.Point(93, 70);
            this.PicBoxDI1.Name = "PicBoxDI1";
            this.PicBoxDI1.Size = new System.Drawing.Size(64, 69);
            // 
            // StaticDO
            // 
            this.StaticDO.Location = new System.Drawing.Point(224, 44);
            this.StaticDO.Name = "StaticDO";
            this.StaticDO.Size = new System.Drawing.Size(109, 23);
            this.StaticDO.Text = "Digital Output";
            // 
            // RadioDO0
            // 
            this.RadioDO0.Checked = true;
            this.RadioDO0.CheckState = System.Windows.Forms.CheckState.Checked;
            this.RadioDO0.Location = new System.Drawing.Point(224, 70);
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
            this.StaticDI0.Text = "Pin0";
            // 
            // StaticDI1
            // 
            this.StaticDI1.Location = new System.Drawing.Point(107, 142);
            this.StaticDI1.Name = "StaticDI1";
            this.StaticDI1.Size = new System.Drawing.Size(34, 20);
            this.StaticDI1.Text = "Pin1";
            // 
            // RadioDO1
            // 
            this.RadioDO1.Checked = true;
            this.RadioDO1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.RadioDO1.Location = new System.Drawing.Point(224, 96);
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
            // DIO
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(449, 197);
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
            this.ResumeLayout(false);

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
    }
}

