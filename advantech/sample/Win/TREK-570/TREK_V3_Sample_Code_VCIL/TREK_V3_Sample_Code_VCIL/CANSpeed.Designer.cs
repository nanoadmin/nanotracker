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
            this.BtnSpeedOK = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.CanBusPortNumberCmbx = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // BtnSpeedOK
            // 
            this.BtnSpeedOK.Location = new System.Drawing.Point(21, 65);
            this.BtnSpeedOK.Name = "BtnSpeedOK";
            this.BtnSpeedOK.Size = new System.Drawing.Size(221, 23);
            this.BtnSpeedOK.TabIndex = 38;
            this.BtnSpeedOK.Text = "OK";
            this.BtnSpeedOK.Click += new System.EventHandler(this.BtnSpeedOK_Click);
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Arial", 12F);
            this.label2.Location = new System.Drawing.Point(18, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(224, 27);
            this.label2.TabIndex = 40;
            this.label2.Text = "Select your port number ...";
            // 
            // CanBusPortNumberCmbx
            // 
            this.CanBusPortNumberCmbx.Location = new System.Drawing.Point(21, 39);
            this.CanBusPortNumberCmbx.Name = "CanBusPortNumberCmbx";
            this.CanBusPortNumberCmbx.Size = new System.Drawing.Size(221, 20);
            this.CanBusPortNumberCmbx.TabIndex = 41;
            // 
            // CANSpeed
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(260, 99);
            this.Controls.Add(this.CanBusPortNumberCmbx);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.BtnSpeedOK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CANSpeed";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Can Bus Speed";
            this.Load += new System.EventHandler(this.CANSpeed_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button BtnSpeedOK;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox CanBusPortNumberCmbx;
    }
}