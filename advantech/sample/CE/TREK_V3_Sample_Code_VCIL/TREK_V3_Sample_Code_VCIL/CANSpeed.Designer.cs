namespace TREK_V3_CanTestTool
{
    partial class CANSpeed
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
            this.CanChannel01SpeedCmbx = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.BtnSpeedOK = new System.Windows.Forms.Button();
            this.StaticCanChannel01Speed = new System.Windows.Forms.Label();
            this.StaticCanChannel02Speed = new System.Windows.Forms.Label();
            this.CanChannel02SpeedCmbx = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // CanChannel01SpeedCmbx
            // 
            this.CanChannel01SpeedCmbx.Items.Add("125 K");
            this.CanChannel01SpeedCmbx.Items.Add("250 K");
            this.CanChannel01SpeedCmbx.Items.Add("500 K");
            this.CanChannel01SpeedCmbx.Items.Add("1     M");
            this.CanChannel01SpeedCmbx.Location = new System.Drawing.Point(174, 60);
            this.CanChannel01SpeedCmbx.Name = "CanChannel01SpeedCmbx";
            this.CanChannel01SpeedCmbx.Size = new System.Drawing.Size(123, 23);
            this.CanChannel01SpeedCmbx.TabIndex = 36;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular);
            this.label1.Location = new System.Drawing.Point(21, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(224, 45);
            this.label1.Text = "Select your can bus speed ...";
            // 
            // BtnSpeedOK
            // 
            this.BtnSpeedOK.Location = new System.Drawing.Point(225, 118);
            this.BtnSpeedOK.Name = "BtnSpeedOK";
            this.BtnSpeedOK.Size = new System.Drawing.Size(72, 23);
            this.BtnSpeedOK.TabIndex = 38;
            this.BtnSpeedOK.Text = "OK";
            this.BtnSpeedOK.Click += new System.EventHandler(this.BtnSpeedOK_Click);
            // 
            // StaticCanChannel01Speed
            // 
            this.StaticCanChannel01Speed.Location = new System.Drawing.Point(21, 60);
            this.StaticCanChannel01Speed.Name = "StaticCanChannel01Speed";
            this.StaticCanChannel01Speed.Size = new System.Drawing.Size(147, 23);
            this.StaticCanChannel01Speed.Text = "CAN Channel 01 Speed";
            // 
            // StaticCanChannel02Speed
            // 
            this.StaticCanChannel02Speed.Location = new System.Drawing.Point(21, 89);
            this.StaticCanChannel02Speed.Name = "StaticCanChannel02Speed";
            this.StaticCanChannel02Speed.Size = new System.Drawing.Size(147, 23);
            this.StaticCanChannel02Speed.Text = "CAN Channel 02 Speed";
            // 
            // CanChannel02SpeedCmbx
            // 
            this.CanChannel02SpeedCmbx.Items.Add("125 K");
            this.CanChannel02SpeedCmbx.Items.Add("250 K");
            this.CanChannel02SpeedCmbx.Items.Add("500 K");
            this.CanChannel02SpeedCmbx.Items.Add("1     M");
            this.CanChannel02SpeedCmbx.Location = new System.Drawing.Point(174, 89);
            this.CanChannel02SpeedCmbx.Name = "CanChannel02SpeedCmbx";
            this.CanChannel02SpeedCmbx.Size = new System.Drawing.Size(123, 23);
            this.CanChannel02SpeedCmbx.TabIndex = 43;
            // 
            // CANSpeed
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(303, 151);
            this.Controls.Add(this.CanChannel02SpeedCmbx);
            this.Controls.Add(this.StaticCanChannel02Speed);
            this.Controls.Add(this.StaticCanChannel01Speed);
            this.Controls.Add(this.BtnSpeedOK);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.CanChannel01SpeedCmbx);
            this.Name = "CANSpeed";
            this.Text = "Can Bus Speed";
            this.Load += new System.EventHandler(this.CANSpeed_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox CanChannel01SpeedCmbx;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BtnSpeedOK;
        private System.Windows.Forms.Label StaticCanChannel01Speed;
        private System.Windows.Forms.Label StaticCanChannel02Speed;
        private System.Windows.Forms.ComboBox CanChannel02SpeedCmbx;
    }
}