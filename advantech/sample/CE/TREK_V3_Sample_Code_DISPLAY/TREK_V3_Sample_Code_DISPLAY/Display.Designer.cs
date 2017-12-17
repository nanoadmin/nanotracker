namespace TREK_V3_Sample_Code_DISPLAY
{
    partial class Display
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
            this.StaticLibVersionValue = new System.Windows.Forms.TextBox();
            this.StaticLibVersion = new System.Windows.Forms.Label();
            this.DisplayBrightComBox = new System.Windows.Forms.ComboBox();
            this.DisplayBrightLabel = new System.Windows.Forms.Label();
            this.DisplayBrightGetBtn = new System.Windows.Forms.Button();
            this.DisplayBrightSetBtn = new System.Windows.Forms.Button();
            this.DisplayOnRadioBtn = new System.Windows.Forms.RadioButton();
            this.DisplayOffRadioBtn = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // StaticLibVersionValue
            // 
            this.StaticLibVersionValue.Location = new System.Drawing.Point(150, 14);
            this.StaticLibVersionValue.Name = "StaticLibVersionValue";
            this.StaticLibVersionValue.Size = new System.Drawing.Size(189, 23);
            this.StaticLibVersionValue.TabIndex = 3;
            // 
            // StaticLibVersion
            // 
            this.StaticLibVersion.Location = new System.Drawing.Point(26, 14);
            this.StaticLibVersion.Name = "StaticLibVersion";
            this.StaticLibVersion.Size = new System.Drawing.Size(118, 23);
            this.StaticLibVersion.Text = "Library Version : ";
            // 
            // DisplayBrightComBox
            // 
            this.DisplayBrightComBox.Location = new System.Drawing.Point(150, 43);
            this.DisplayBrightComBox.Name = "DisplayBrightComBox";
            this.DisplayBrightComBox.Size = new System.Drawing.Size(189, 23);
            this.DisplayBrightComBox.TabIndex = 5;
            // 
            // DisplayBrightLabel
            // 
            this.DisplayBrightLabel.Location = new System.Drawing.Point(26, 43);
            this.DisplayBrightLabel.Name = "DisplayBrightLabel";
            this.DisplayBrightLabel.Size = new System.Drawing.Size(118, 23);
            this.DisplayBrightLabel.Text = "Bright";
            // 
            // DisplayBrightGetBtn
            // 
            this.DisplayBrightGetBtn.Location = new System.Drawing.Point(150, 72);
            this.DisplayBrightGetBtn.Name = "DisplayBrightGetBtn";
            this.DisplayBrightGetBtn.Size = new System.Drawing.Size(89, 23);
            this.DisplayBrightGetBtn.TabIndex = 7;
            this.DisplayBrightGetBtn.Text = "Get";
            this.DisplayBrightGetBtn.Click += new System.EventHandler(this.DisplayBrightGetBtn_Click);
            // 
            // DisplayBrightSetBtn
            // 
            this.DisplayBrightSetBtn.Location = new System.Drawing.Point(250, 72);
            this.DisplayBrightSetBtn.Name = "DisplayBrightSetBtn";
            this.DisplayBrightSetBtn.Size = new System.Drawing.Size(89, 23);
            this.DisplayBrightSetBtn.TabIndex = 8;
            this.DisplayBrightSetBtn.Text = "Set";
            this.DisplayBrightSetBtn.Click += new System.EventHandler(this.DisplayBrightSetBtn_Click);
            // 
            // DisplayOnRadioBtn
            // 
            this.DisplayOnRadioBtn.Location = new System.Drawing.Point(26, 101);
            this.DisplayOnRadioBtn.Name = "DisplayOnRadioBtn";
            this.DisplayOnRadioBtn.Size = new System.Drawing.Size(224, 20);
            this.DisplayOnRadioBtn.TabIndex = 9;
            this.DisplayOnRadioBtn.Text = "Display &On ( Alt + O )";
            this.DisplayOnRadioBtn.CheckedChanged += new System.EventHandler(this.DisplayOnRadioBtn_CheckedChanged);
            // 
            // DisplayOffRadioBtn
            // 
            this.DisplayOffRadioBtn.Location = new System.Drawing.Point(26, 127);
            this.DisplayOffRadioBtn.Name = "DisplayOffRadioBtn";
            this.DisplayOffRadioBtn.Size = new System.Drawing.Size(224, 20);
            this.DisplayOffRadioBtn.TabIndex = 10;
            this.DisplayOffRadioBtn.Text = "Display OF&F ( Alt + F )";
            this.DisplayOffRadioBtn.CheckedChanged += new System.EventHandler(this.DisplayOffRadioBtn_CheckedChanged);
            // 
            // Display
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(346, 165);
            this.Controls.Add(this.DisplayOffRadioBtn);
            this.Controls.Add(this.DisplayOnRadioBtn);
            this.Controls.Add(this.DisplayBrightSetBtn);
            this.Controls.Add(this.DisplayBrightGetBtn);
            this.Controls.Add(this.DisplayBrightLabel);
            this.Controls.Add(this.DisplayBrightComBox);
            this.Controls.Add(this.StaticLibVersion);
            this.Controls.Add(this.StaticLibVersionValue);
            this.Name = "Display";
            this.Text = "TREK V3 DISPLAY Sample Code";
            this.Load += new System.EventHandler(this.Display_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox StaticLibVersionValue;
        private System.Windows.Forms.Label StaticLibVersion;
        private System.Windows.Forms.ComboBox DisplayBrightComBox;
        private System.Windows.Forms.Label DisplayBrightLabel;
        private System.Windows.Forms.Button DisplayBrightGetBtn;
        private System.Windows.Forms.Button DisplayBrightSetBtn;
        private System.Windows.Forms.RadioButton DisplayOnRadioBtn;
        private System.Windows.Forms.RadioButton DisplayOffRadioBtn;

    }
}

