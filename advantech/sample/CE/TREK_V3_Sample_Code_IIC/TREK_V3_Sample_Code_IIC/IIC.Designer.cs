namespace TREK_V3_Sample_Code_IIC
{
    partial class IIC
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
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.IICStaticLibVersionValue = new System.Windows.Forms.TextBox();
            this.IICStaticLibVersion = new System.Windows.Forms.Label();
            this.IICPrimaryRdBtn = new System.Windows.Forms.RadioButton();
            this.IICSmbusIICRdBtn = new System.Windows.Forms.RadioButton();
            this.IICSlaveAddressLabel = new System.Windows.Forms.Label();
            this.IICReadNumLabel = new System.Windows.Forms.Label();
            this.IICWriteNumLabel = new System.Windows.Forms.Label();
            this.IICSlaveAddressTextBox = new System.Windows.Forms.TextBox();
            this.IICReadNumTextBox = new System.Windows.Forms.TextBox();
            this.IICWriteNumTextBox = new System.Windows.Forms.TextBox();
            this.IICTypeLabel = new System.Windows.Forms.Label();
            this.IICReadBtn = new System.Windows.Forms.Button();
            this.IICWriteBtn = new System.Windows.Forms.Button();
            this.IICWRCombineBtn = new System.Windows.Forms.Button();
            this.IICInputLabel = new System.Windows.Forms.Label();
            this.IICInputTextBox = new System.Windows.Forms.TextBox();
            this.IICResultLabel = new System.Windows.Forms.Label();
            this.IICResultTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(0, 0);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 287);
            // 
            // IICStaticLibVersionValue
            // 
            this.IICStaticLibVersionValue.Location = new System.Drawing.Point(169, 20);
            this.IICStaticLibVersionValue.Name = "IICStaticLibVersionValue";
            this.IICStaticLibVersionValue.Size = new System.Drawing.Size(185, 23);
            this.IICStaticLibVersionValue.TabIndex = 3;
            // 
            // IICStaticLibVersion
            // 
            this.IICStaticLibVersion.Location = new System.Drawing.Point(36, 20);
            this.IICStaticLibVersion.Name = "IICStaticLibVersion";
            this.IICStaticLibVersion.Size = new System.Drawing.Size(127, 23);
            this.IICStaticLibVersion.Text = "IIC Library Version : ";
            // 
            // IICPrimaryRdBtn
            // 
            this.IICPrimaryRdBtn.Location = new System.Drawing.Point(142, 49);
            this.IICPrimaryRdBtn.Name = "IICPrimaryRdBtn";
            this.IICPrimaryRdBtn.Size = new System.Drawing.Size(100, 23);
            this.IICPrimaryRdBtn.TabIndex = 5;
            this.IICPrimaryRdBtn.Text = "Primary";
            // 
            // IICSmbusIICRdBtn
            // 
            this.IICSmbusIICRdBtn.Location = new System.Drawing.Point(142, 78);
            this.IICSmbusIICRdBtn.Name = "IICSmbusIICRdBtn";
            this.IICSmbusIICRdBtn.Size = new System.Drawing.Size(100, 23);
            this.IICSmbusIICRdBtn.TabIndex = 6;
            this.IICSmbusIICRdBtn.Text = "SMBus-IIC";
            // 
            // IICSlaveAddressLabel
            // 
            this.IICSlaveAddressLabel.Location = new System.Drawing.Point(36, 107);
            this.IICSlaveAddressLabel.Name = "IICSlaveAddressLabel";
            this.IICSlaveAddressLabel.Size = new System.Drawing.Size(100, 23);
            this.IICSlaveAddressLabel.Text = "Slave address";
            // 
            // IICReadNumLabel
            // 
            this.IICReadNumLabel.Location = new System.Drawing.Point(36, 136);
            this.IICReadNumLabel.Name = "IICReadNumLabel";
            this.IICReadNumLabel.Size = new System.Drawing.Size(100, 23);
            this.IICReadNumLabel.Text = "Read number";
            // 
            // IICWriteNumLabel
            // 
            this.IICWriteNumLabel.Location = new System.Drawing.Point(36, 165);
            this.IICWriteNumLabel.Name = "IICWriteNumLabel";
            this.IICWriteNumLabel.Size = new System.Drawing.Size(100, 23);
            this.IICWriteNumLabel.Text = "Write number";
            // 
            // IICSlaveAddressTextBox
            // 
            this.IICSlaveAddressTextBox.Location = new System.Drawing.Point(142, 107);
            this.IICSlaveAddressTextBox.Name = "IICSlaveAddressTextBox";
            this.IICSlaveAddressTextBox.Size = new System.Drawing.Size(100, 23);
            this.IICSlaveAddressTextBox.TabIndex = 12;
            this.IICSlaveAddressTextBox.Text = "f1";
            // 
            // IICReadNumTextBox
            // 
            this.IICReadNumTextBox.Location = new System.Drawing.Point(142, 136);
            this.IICReadNumTextBox.Name = "IICReadNumTextBox";
            this.IICReadNumTextBox.Size = new System.Drawing.Size(100, 23);
            this.IICReadNumTextBox.TabIndex = 13;
            this.IICReadNumTextBox.Text = "1";
            // 
            // IICWriteNumTextBox
            // 
            this.IICWriteNumTextBox.Location = new System.Drawing.Point(142, 165);
            this.IICWriteNumTextBox.Name = "IICWriteNumTextBox";
            this.IICWriteNumTextBox.Size = new System.Drawing.Size(100, 23);
            this.IICWriteNumTextBox.TabIndex = 14;
            this.IICWriteNumTextBox.Text = "1";
            // 
            // IICTypeLabel
            // 
            this.IICTypeLabel.Location = new System.Drawing.Point(36, 65);
            this.IICTypeLabel.Name = "IICTypeLabel";
            this.IICTypeLabel.Size = new System.Drawing.Size(100, 20);
            this.IICTypeLabel.Text = "IIC Type";
            // 
            // IICReadBtn
            // 
            this.IICReadBtn.Location = new System.Drawing.Point(36, 194);
            this.IICReadBtn.Name = "IICReadBtn";
            this.IICReadBtn.Size = new System.Drawing.Size(100, 23);
            this.IICReadBtn.TabIndex = 16;
            this.IICReadBtn.Text = "Read";
            this.IICReadBtn.Click += new System.EventHandler(this.IICReadBtn_Click);
            // 
            // IICWriteBtn
            // 
            this.IICWriteBtn.Location = new System.Drawing.Point(142, 194);
            this.IICWriteBtn.Name = "IICWriteBtn";
            this.IICWriteBtn.Size = new System.Drawing.Size(100, 23);
            this.IICWriteBtn.TabIndex = 17;
            this.IICWriteBtn.Text = "Write";
            this.IICWriteBtn.Click += new System.EventHandler(this.IICWriteBtn_Click);
            // 
            // IICWRCombineBtn
            // 
            this.IICWRCombineBtn.Location = new System.Drawing.Point(36, 223);
            this.IICWRCombineBtn.Name = "IICWRCombineBtn";
            this.IICWRCombineBtn.Size = new System.Drawing.Size(206, 23);
            this.IICWRCombineBtn.TabIndex = 18;
            this.IICWRCombineBtn.Text = "WR Combine";
            this.IICWRCombineBtn.Click += new System.EventHandler(this.IICWRCombineBtn_Click);
            // 
            // IICInputLabel
            // 
            this.IICInputLabel.Location = new System.Drawing.Point(248, 78);
            this.IICInputLabel.Name = "IICInputLabel";
            this.IICInputLabel.Size = new System.Drawing.Size(224, 23);
            this.IICInputLabel.Text = "Input Data ( ex. 00 ff 7f ... ) ( Hex )";
            // 
            // IICInputTextBox
            // 
            this.IICInputTextBox.Location = new System.Drawing.Point(249, 107);
            this.IICInputTextBox.Multiline = true;
            this.IICInputTextBox.Name = "IICInputTextBox";
            this.IICInputTextBox.Size = new System.Drawing.Size(223, 52);
            this.IICInputTextBox.TabIndex = 21;
            this.IICInputTextBox.Text = "f0";
            // 
            // IICResultLabel
            // 
            this.IICResultLabel.Location = new System.Drawing.Point(249, 165);
            this.IICResultLabel.Name = "IICResultLabel";
            this.IICResultLabel.Size = new System.Drawing.Size(223, 23);
            this.IICResultLabel.Text = "Result ( Hex )";
            // 
            // IICResultTextBox
            // 
            this.IICResultTextBox.Location = new System.Drawing.Point(249, 194);
            this.IICResultTextBox.Multiline = true;
            this.IICResultTextBox.Name = "IICResultTextBox";
            this.IICResultTextBox.Size = new System.Drawing.Size(223, 52);
            this.IICResultTextBox.TabIndex = 24;
            // 
            // IIC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(517, 287);
            this.Controls.Add(this.IICResultTextBox);
            this.Controls.Add(this.IICResultLabel);
            this.Controls.Add(this.IICInputTextBox);
            this.Controls.Add(this.IICInputLabel);
            this.Controls.Add(this.IICWRCombineBtn);
            this.Controls.Add(this.IICWriteBtn);
            this.Controls.Add(this.IICReadBtn);
            this.Controls.Add(this.IICTypeLabel);
            this.Controls.Add(this.IICWriteNumTextBox);
            this.Controls.Add(this.IICReadNumTextBox);
            this.Controls.Add(this.IICSlaveAddressTextBox);
            this.Controls.Add(this.IICWriteNumLabel);
            this.Controls.Add(this.IICReadNumLabel);
            this.Controls.Add(this.IICSlaveAddressLabel);
            this.Controls.Add(this.IICSmbusIICRdBtn);
            this.Controls.Add(this.IICPrimaryRdBtn);
            this.Controls.Add(this.IICStaticLibVersion);
            this.Controls.Add(this.IICStaticLibVersionValue);
            this.Controls.Add(this.splitter1);
            this.Name = "IIC";
            this.Text = "TREK V3 IIC Sample Code";
            this.Load += new System.EventHandler(this.IIC_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.TextBox IICStaticLibVersionValue;
        private System.Windows.Forms.Label IICStaticLibVersion;
        private System.Windows.Forms.RadioButton IICPrimaryRdBtn;
        private System.Windows.Forms.RadioButton IICSmbusIICRdBtn;
        private System.Windows.Forms.Label IICSlaveAddressLabel;
        private System.Windows.Forms.Label IICReadNumLabel;
        private System.Windows.Forms.Label IICWriteNumLabel;
        private System.Windows.Forms.TextBox IICSlaveAddressTextBox;
        private System.Windows.Forms.TextBox IICReadNumTextBox;
        private System.Windows.Forms.TextBox IICWriteNumTextBox;
        private System.Windows.Forms.Label IICTypeLabel;
        private System.Windows.Forms.Button IICReadBtn;
        private System.Windows.Forms.Button IICWriteBtn;
        private System.Windows.Forms.Button IICWRCombineBtn;
        private System.Windows.Forms.Label IICInputLabel;
        private System.Windows.Forms.TextBox IICInputTextBox;
        private System.Windows.Forms.Label IICResultLabel;
        private System.Windows.Forms.TextBox IICResultTextBox;

    }
}

