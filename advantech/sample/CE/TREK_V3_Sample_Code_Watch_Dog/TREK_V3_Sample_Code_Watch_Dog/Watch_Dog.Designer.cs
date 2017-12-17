namespace TREK_V3_Sample_Code_Watch_Dog
{
    partial class Watch_Dog
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
            this.SetWDTimerBtn = new System.Windows.Forms.Button();
            this.GetWDTimerBtn = new System.Windows.Forms.Button();
            this.LibVersionTxtBx = new System.Windows.Forms.TextBox();
            this.StaticLibVersion = new System.Windows.Forms.Label();
            this.SetWDTimerTxt = new System.Windows.Forms.TextBox();
            this.GetWDTimerTxt = new System.Windows.Forms.TextBox();
            this.GetRangeBtn = new System.Windows.Forms.Button();
            this.TimeMinTxt = new System.Windows.Forms.TextBox();
            this.TimeMaxTxt = new System.Windows.Forms.TextBox();
            this.WDTimerEnabledBtn = new System.Windows.Forms.Button();
            this.WDTimerTriggerBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // SetWDTimerBtn
            // 
            this.SetWDTimerBtn.Location = new System.Drawing.Point(28, 61);
            this.SetWDTimerBtn.Name = "SetWDTimerBtn";
            this.SetWDTimerBtn.Size = new System.Drawing.Size(109, 23);
            this.SetWDTimerBtn.TabIndex = 1;
            this.SetWDTimerBtn.Text = "Set WD Time";
            this.SetWDTimerBtn.Click += new System.EventHandler(this.SetWDTimerBtn_Click);
            // 
            // GetWDTimerBtn
            // 
            this.GetWDTimerBtn.Location = new System.Drawing.Point(28, 90);
            this.GetWDTimerBtn.Name = "GetWDTimerBtn";
            this.GetWDTimerBtn.Size = new System.Drawing.Size(109, 23);
            this.GetWDTimerBtn.TabIndex = 3;
            this.GetWDTimerBtn.Text = "Get WD Time";
            this.GetWDTimerBtn.Click += new System.EventHandler(this.GetWDTimerBtn_Click);
            // 
            // LibVersionTxtBx
            // 
            this.LibVersionTxtBx.Location = new System.Drawing.Point(143, 3);
            this.LibVersionTxtBx.Name = "LibVersionTxtBx";
            this.LibVersionTxtBx.Size = new System.Drawing.Size(149, 23);
            this.LibVersionTxtBx.TabIndex = 5;
            // 
            // StaticLibVersion
            // 
            this.StaticLibVersion.Location = new System.Drawing.Point(28, 3);
            this.StaticLibVersion.Name = "StaticLibVersion";
            this.StaticLibVersion.Size = new System.Drawing.Size(109, 23);
            this.StaticLibVersion.Text = "Library Version : ";
            // 
            // SetWDTimerTxt
            // 
            this.SetWDTimerTxt.Location = new System.Drawing.Point(143, 61);
            this.SetWDTimerTxt.Name = "SetWDTimerTxt";
            this.SetWDTimerTxt.Size = new System.Drawing.Size(149, 23);
            this.SetWDTimerTxt.TabIndex = 6;
            // 
            // GetWDTimerTxt
            // 
            this.GetWDTimerTxt.Location = new System.Drawing.Point(143, 90);
            this.GetWDTimerTxt.Name = "GetWDTimerTxt";
            this.GetWDTimerTxt.Size = new System.Drawing.Size(149, 23);
            this.GetWDTimerTxt.TabIndex = 8;
            // 
            // GetRangeBtn
            // 
            this.GetRangeBtn.Location = new System.Drawing.Point(28, 32);
            this.GetRangeBtn.Name = "GetRangeBtn";
            this.GetRangeBtn.Size = new System.Drawing.Size(109, 23);
            this.GetRangeBtn.TabIndex = 9;
            this.GetRangeBtn.Text = "Get Range";
            this.GetRangeBtn.Click += new System.EventHandler(this.GetRangeBtn_Click);
            // 
            // TimeMinTxt
            // 
            this.TimeMinTxt.Location = new System.Drawing.Point(143, 32);
            this.TimeMinTxt.Name = "TimeMinTxt";
            this.TimeMinTxt.Size = new System.Drawing.Size(67, 23);
            this.TimeMinTxt.TabIndex = 10;
            // 
            // TimeMaxTxt
            // 
            this.TimeMaxTxt.Location = new System.Drawing.Point(225, 32);
            this.TimeMaxTxt.Name = "TimeMaxTxt";
            this.TimeMaxTxt.Size = new System.Drawing.Size(67, 23);
            this.TimeMaxTxt.TabIndex = 11;
            // 
            // WDTimerEnabledBtn
            // 
            this.WDTimerEnabledBtn.Location = new System.Drawing.Point(28, 119);
            this.WDTimerEnabledBtn.Name = "WDTimerEnabledBtn";
            this.WDTimerEnabledBtn.Size = new System.Drawing.Size(109, 23);
            this.WDTimerEnabledBtn.TabIndex = 12;
            this.WDTimerEnabledBtn.Text = "Start WD Timer";
            this.WDTimerEnabledBtn.Click += new System.EventHandler(this.WDTimerEnabledBtn_Click);
            // 
            // WDTimerTriggerBtn
            // 
            this.WDTimerTriggerBtn.Location = new System.Drawing.Point(28, 148);
            this.WDTimerTriggerBtn.Name = "WDTimerTriggerBtn";
            this.WDTimerTriggerBtn.Size = new System.Drawing.Size(109, 23);
            this.WDTimerTriggerBtn.TabIndex = 13;
            this.WDTimerTriggerBtn.Text = "Trigger Timer";
            this.WDTimerTriggerBtn.Click += new System.EventHandler(this.WDTimerTriggerBtn_Click);
            // 
            // Watch_Dog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(315, 189);
            this.Controls.Add(this.WDTimerTriggerBtn);
            this.Controls.Add(this.WDTimerEnabledBtn);
            this.Controls.Add(this.TimeMaxTxt);
            this.Controls.Add(this.TimeMinTxt);
            this.Controls.Add(this.GetRangeBtn);
            this.Controls.Add(this.GetWDTimerTxt);
            this.Controls.Add(this.SetWDTimerTxt);
            this.Controls.Add(this.StaticLibVersion);
            this.Controls.Add(this.LibVersionTxtBx);
            this.Controls.Add(this.GetWDTimerBtn);
            this.Controls.Add(this.SetWDTimerBtn);
            this.Name = "Watch_Dog";
            this.Text = "TREK V3 Watch Dog Sample Code";
            this.Load += new System.EventHandler(this.Watch_Dog_Load);
            this.Closed += new System.EventHandler(this.Watch_Dog_Closed);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button SetWDTimerBtn;
        private System.Windows.Forms.Button GetWDTimerBtn;
        private System.Windows.Forms.TextBox LibVersionTxtBx;
        private System.Windows.Forms.Label StaticLibVersion;
        private System.Windows.Forms.TextBox SetWDTimerTxt;
        private System.Windows.Forms.TextBox GetWDTimerTxt;
        private System.Windows.Forms.Button GetRangeBtn;
        private System.Windows.Forms.TextBox TimeMinTxt;
        private System.Windows.Forms.TextBox TimeMaxTxt;
        private System.Windows.Forms.Button WDTimerEnabledBtn;
        private System.Windows.Forms.Button WDTimerTriggerBtn;
    }
}

