namespace TREK_V3_Sample_Code_Light_Sensor
{
    partial class Light_Sensor
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
            this.button1 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.StaticLibVersion = new System.Windows.Forms.Label();
            this.StaticLibVersionValue = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(21, 47);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(145, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Get Light Sensor Value";
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(185, 47);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(138, 23);
            this.textBox1.TabIndex = 1;
            // 
            // StaticLibVersion
            // 
            this.StaticLibVersion.Location = new System.Drawing.Point(21, 18);
            this.StaticLibVersion.Name = "StaticLibVersion";
            this.StaticLibVersion.Size = new System.Drawing.Size(118, 23);
            this.StaticLibVersion.Text = "Library Version : ";
            // 
            // StaticLibVersionValue
            // 
            this.StaticLibVersionValue.Location = new System.Drawing.Point(185, 18);
            this.StaticLibVersionValue.Name = "StaticLibVersionValue";
            this.StaticLibVersionValue.Size = new System.Drawing.Size(138, 23);
            this.StaticLibVersionValue.TabIndex = 6;
            // 
            // Light_Sensor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(340, 87);
            this.Controls.Add(this.StaticLibVersionValue);
            this.Controls.Add(this.StaticLibVersion);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button1);
            this.Name = "Light_Sensor";
            this.Text = "TREK V3 Light Sensor Sample Code";
            this.Load += new System.EventHandler(this.Light_Sensor_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label StaticLibVersion;
        private System.Windows.Forms.TextBox StaticLibVersionValue;
    }
}

