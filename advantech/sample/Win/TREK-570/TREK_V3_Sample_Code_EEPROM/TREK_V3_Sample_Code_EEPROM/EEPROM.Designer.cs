namespace TREK_V3_Sample_Code_EEPROM
{
    partial class EEPROM
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
            this.labelLibVersion = new System.Windows.Forms.Label();
            this.labelEEPROMSize = new System.Windows.Forms.Label();
            this.textBoxLibVersion = new System.Windows.Forms.TextBox();
            this.textBoxEEPROMSize = new System.Windows.Forms.TextBox();
            this.labelEERPOMSizeUnit = new System.Windows.Forms.Label();
            this.groupBoxSingleByte = new System.Windows.Forms.GroupBox();
            this.buttonByteApply = new System.Windows.Forms.Button();
            this.textBoxByteData = new System.Windows.Forms.TextBox();
            this.textBoxByteAddress = new System.Windows.Forms.TextBox();
            this.labelByteData = new System.Windows.Forms.Label();
            this.labelByteAddress = new System.Windows.Forms.Label();
            this.radioButtonWriteByte = new System.Windows.Forms.RadioButton();
            this.radioButtonReadByte = new System.Windows.Forms.RadioButton();
            this.groupBoxMultiByte = new System.Windows.Forms.GroupBox();
            this.buttonMultiApply = new System.Windows.Forms.Button();
            this.labelNumByteReadWrite = new System.Windows.Forms.Label();
            this.textBoxMultiNumReadWrite = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxMultiSize = new System.Windows.Forms.TextBox();
            this.labelMultiSize = new System.Windows.Forms.Label();
            this.textBoxMultiData = new System.Windows.Forms.TextBox();
            this.textBoxMultiAddress = new System.Windows.Forms.TextBox();
            this.labelMultiData = new System.Windows.Forms.Label();
            this.labelMultiAddress = new System.Windows.Forms.Label();
            this.radioButtonWriteMulti = new System.Windows.Forms.RadioButton();
            this.radioButtonReadMulti = new System.Windows.Forms.RadioButton();
            this.groupBoxSingleByte.SuspendLayout();
            this.groupBoxMultiByte.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelLibVersion
            // 
            this.labelLibVersion.AutoSize = true;
            this.labelLibVersion.Location = new System.Drawing.Point(23, 20);
            this.labelLibVersion.Name = "labelLibVersion";
            this.labelLibVersion.Size = new System.Drawing.Size(88, 12);
            this.labelLibVersion.TabIndex = 0;
            this.labelLibVersion.Text = "Library Version : ";
            // 
            // labelEEPROMSize
            // 
            this.labelEEPROMSize.AutoSize = true;
            this.labelEEPROMSize.Location = new System.Drawing.Point(27, 45);
            this.labelEEPROMSize.Name = "labelEEPROMSize";
            this.labelEEPROMSize.Size = new System.Drawing.Size(79, 12);
            this.labelEEPROMSize.TabIndex = 1;
            this.labelEEPROMSize.Text = "EEPROM Size :";
            // 
            // textBoxLibVersion
            // 
            this.textBoxLibVersion.Location = new System.Drawing.Point(112, 17);
            this.textBoxLibVersion.Name = "textBoxLibVersion";
            this.textBoxLibVersion.Size = new System.Drawing.Size(132, 22);
            this.textBoxLibVersion.TabIndex = 2;
            // 
            // textBoxEEPROMSize
            // 
            this.textBoxEEPROMSize.Enabled = false;
            this.textBoxEEPROMSize.Location = new System.Drawing.Point(112, 45);
            this.textBoxEEPROMSize.Name = "textBoxEEPROMSize";
            this.textBoxEEPROMSize.Size = new System.Drawing.Size(53, 22);
            this.textBoxEEPROMSize.TabIndex = 3;
            // 
            // labelEERPOMSizeUnit
            // 
            this.labelEERPOMSizeUnit.AutoSize = true;
            this.labelEERPOMSizeUnit.Location = new System.Drawing.Point(171, 50);
            this.labelEERPOMSizeUnit.Name = "labelEERPOMSizeUnit";
            this.labelEERPOMSizeUnit.Size = new System.Drawing.Size(31, 12);
            this.labelEERPOMSizeUnit.TabIndex = 4;
            this.labelEERPOMSizeUnit.Text = "Bytes";
            // 
            // groupBoxSingleByte
            // 
            this.groupBoxSingleByte.Controls.Add(this.buttonByteApply);
            this.groupBoxSingleByte.Controls.Add(this.textBoxByteData);
            this.groupBoxSingleByte.Controls.Add(this.textBoxByteAddress);
            this.groupBoxSingleByte.Controls.Add(this.labelByteData);
            this.groupBoxSingleByte.Controls.Add(this.labelByteAddress);
            this.groupBoxSingleByte.Controls.Add(this.radioButtonWriteByte);
            this.groupBoxSingleByte.Controls.Add(this.radioButtonReadByte);
            this.groupBoxSingleByte.Font = new System.Drawing.Font("新細明體", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.groupBoxSingleByte.Location = new System.Drawing.Point(15, 82);
            this.groupBoxSingleByte.Name = "groupBoxSingleByte";
            this.groupBoxSingleByte.Size = new System.Drawing.Size(285, 118);
            this.groupBoxSingleByte.TabIndex = 5;
            this.groupBoxSingleByte.TabStop = false;
            this.groupBoxSingleByte.Text = "Single Byte";
            // 
            // buttonByteApply
            // 
            this.buttonByteApply.Font = new System.Drawing.Font("新細明體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.buttonByteApply.Location = new System.Drawing.Point(195, 73);
            this.buttonByteApply.Name = "buttonByteApply";
            this.buttonByteApply.Size = new System.Drawing.Size(75, 23);
            this.buttonByteApply.TabIndex = 6;
            this.buttonByteApply.Text = "Apply";
            this.buttonByteApply.UseVisualStyleBackColor = true;
            this.buttonByteApply.Click += new System.EventHandler(this.buttonByteApply_Click);
            // 
            // textBoxByteData
            // 
            this.textBoxByteData.Font = new System.Drawing.Font("新細明體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.textBoxByteData.Location = new System.Drawing.Point(120, 75);
            this.textBoxByteData.Name = "textBoxByteData";
            this.textBoxByteData.Size = new System.Drawing.Size(53, 22);
            this.textBoxByteData.TabIndex = 5;
            // 
            // textBoxByteAddress
            // 
            this.textBoxByteAddress.Font = new System.Drawing.Font("新細明體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.textBoxByteAddress.Location = new System.Drawing.Point(120, 45);
            this.textBoxByteAddress.Name = "textBoxByteAddress";
            this.textBoxByteAddress.Size = new System.Drawing.Size(53, 22);
            this.textBoxByteAddress.TabIndex = 4;
            this.textBoxByteAddress.Text = "00";
            // 
            // labelByteData
            // 
            this.labelByteData.AutoSize = true;
            this.labelByteData.Font = new System.Drawing.Font("新細明體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.labelByteData.Location = new System.Drawing.Point(22, 78);
            this.labelByteData.Name = "labelByteData";
            this.labelByteData.Size = new System.Drawing.Size(66, 12);
            this.labelByteData.TabIndex = 3;
            this.labelByteData.Text = "Data (HEX) :";
            // 
            // labelByteAddress
            // 
            this.labelByteAddress.AutoSize = true;
            this.labelByteAddress.Font = new System.Drawing.Font("新細明體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.labelByteAddress.Location = new System.Drawing.Point(22, 48);
            this.labelByteAddress.Name = "labelByteAddress";
            this.labelByteAddress.Size = new System.Drawing.Size(82, 12);
            this.labelByteAddress.TabIndex = 2;
            this.labelByteAddress.Text = "Address (HEX) :";
            // 
            // radioButtonWriteByte
            // 
            this.radioButtonWriteByte.AutoSize = true;
            this.radioButtonWriteByte.Font = new System.Drawing.Font("新細明體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.radioButtonWriteByte.Location = new System.Drawing.Point(78, 21);
            this.radioButtonWriteByte.Name = "radioButtonWriteByte";
            this.radioButtonWriteByte.Size = new System.Drawing.Size(49, 16);
            this.radioButtonWriteByte.TabIndex = 1;
            this.radioButtonWriteByte.TabStop = true;
            this.radioButtonWriteByte.Text = "Write";
            this.radioButtonWriteByte.UseVisualStyleBackColor = true;
            // 
            // radioButtonReadByte
            // 
            this.radioButtonReadByte.AutoSize = true;
            this.radioButtonReadByte.Checked = true;
            this.radioButtonReadByte.Font = new System.Drawing.Font("新細明體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.radioButtonReadByte.Location = new System.Drawing.Point(24, 22);
            this.radioButtonReadByte.Name = "radioButtonReadByte";
            this.radioButtonReadByte.Size = new System.Drawing.Size(47, 16);
            this.radioButtonReadByte.TabIndex = 0;
            this.radioButtonReadByte.TabStop = true;
            this.radioButtonReadByte.Text = "Read";
            this.radioButtonReadByte.UseVisualStyleBackColor = true;
            // 
            // groupBoxMultiByte
            // 
            this.groupBoxMultiByte.Controls.Add(this.buttonMultiApply);
            this.groupBoxMultiByte.Controls.Add(this.labelNumByteReadWrite);
            this.groupBoxMultiByte.Controls.Add(this.textBoxMultiNumReadWrite);
            this.groupBoxMultiByte.Controls.Add(this.label4);
            this.groupBoxMultiByte.Controls.Add(this.textBoxMultiSize);
            this.groupBoxMultiByte.Controls.Add(this.labelMultiSize);
            this.groupBoxMultiByte.Controls.Add(this.textBoxMultiData);
            this.groupBoxMultiByte.Controls.Add(this.textBoxMultiAddress);
            this.groupBoxMultiByte.Controls.Add(this.labelMultiData);
            this.groupBoxMultiByte.Controls.Add(this.labelMultiAddress);
            this.groupBoxMultiByte.Controls.Add(this.radioButtonWriteMulti);
            this.groupBoxMultiByte.Controls.Add(this.radioButtonReadMulti);
            this.groupBoxMultiByte.Font = new System.Drawing.Font("新細明體", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.groupBoxMultiByte.Location = new System.Drawing.Point(15, 206);
            this.groupBoxMultiByte.Name = "groupBoxMultiByte";
            this.groupBoxMultiByte.Size = new System.Drawing.Size(285, 228);
            this.groupBoxMultiByte.TabIndex = 6;
            this.groupBoxMultiByte.TabStop = false;
            this.groupBoxMultiByte.Text = "Multiple Bytes";
            // 
            // buttonMultiApply
            // 
            this.buttonMultiApply.Font = new System.Drawing.Font("新細明體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.buttonMultiApply.Location = new System.Drawing.Point(195, 188);
            this.buttonMultiApply.Name = "buttonMultiApply";
            this.buttonMultiApply.Size = new System.Drawing.Size(75, 23);
            this.buttonMultiApply.TabIndex = 7;
            this.buttonMultiApply.Text = "Apply";
            this.buttonMultiApply.UseVisualStyleBackColor = true;
            this.buttonMultiApply.Click += new System.EventHandler(this.buttonMultiApply_Click);
            // 
            // labelNumByteReadWrite
            // 
            this.labelNumByteReadWrite.AutoSize = true;
            this.labelNumByteReadWrite.Font = new System.Drawing.Font("新細明體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.labelNumByteReadWrite.Location = new System.Drawing.Point(22, 151);
            this.labelNumByteReadWrite.Name = "labelNumByteReadWrite";
            this.labelNumByteReadWrite.Size = new System.Drawing.Size(141, 12);
            this.labelNumByteReadWrite.TabIndex = 15;
            this.labelNumByteReadWrite.Text = "Number of Bytes Read/Write";
            // 
            // textBoxMultiNumReadWrite
            // 
            this.textBoxMultiNumReadWrite.Font = new System.Drawing.Font("新細明體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.textBoxMultiNumReadWrite.Location = new System.Drawing.Point(169, 148);
            this.textBoxMultiNumReadWrite.Name = "textBoxMultiNumReadWrite";
            this.textBoxMultiNumReadWrite.Size = new System.Drawing.Size(53, 22);
            this.textBoxMultiNumReadWrite.TabIndex = 14;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("新細明體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label4.Location = new System.Drawing.Point(156, 85);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(31, 12);
            this.label4.TabIndex = 12;
            this.label4.Text = "Bytes";
            // 
            // textBoxMultiSize
            // 
            this.textBoxMultiSize.Font = new System.Drawing.Font("新細明體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.textBoxMultiSize.Location = new System.Drawing.Point(97, 82);
            this.textBoxMultiSize.Name = "textBoxMultiSize";
            this.textBoxMultiSize.Size = new System.Drawing.Size(53, 22);
            this.textBoxMultiSize.TabIndex = 11;
            this.textBoxMultiSize.Text = "10";
            // 
            // labelMultiSize
            // 
            this.labelMultiSize.AutoSize = true;
            this.labelMultiSize.Font = new System.Drawing.Font("新細明體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.labelMultiSize.Location = new System.Drawing.Point(22, 85);
            this.labelMultiSize.Name = "labelMultiSize";
            this.labelMultiSize.Size = new System.Drawing.Size(64, 12);
            this.labelMultiSize.TabIndex = 10;
            this.labelMultiSize.Text = "Size (HEX) :";
            // 
            // textBoxMultiData
            // 
            this.textBoxMultiData.Font = new System.Drawing.Font("新細明體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.textBoxMultiData.Location = new System.Drawing.Point(97, 113);
            this.textBoxMultiData.Name = "textBoxMultiData";
            this.textBoxMultiData.Size = new System.Drawing.Size(173, 22);
            this.textBoxMultiData.TabIndex = 9;
            // 
            // textBoxMultiAddress
            // 
            this.textBoxMultiAddress.Font = new System.Drawing.Font("新細明體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.textBoxMultiAddress.Location = new System.Drawing.Point(134, 51);
            this.textBoxMultiAddress.Name = "textBoxMultiAddress";
            this.textBoxMultiAddress.Size = new System.Drawing.Size(53, 22);
            this.textBoxMultiAddress.TabIndex = 8;
            this.textBoxMultiAddress.Text = "00";
            // 
            // labelMultiData
            // 
            this.labelMultiData.AutoSize = true;
            this.labelMultiData.Font = new System.Drawing.Font("新細明體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.labelMultiData.Location = new System.Drawing.Point(22, 116);
            this.labelMultiData.Name = "labelMultiData";
            this.labelMultiData.Size = new System.Drawing.Size(66, 12);
            this.labelMultiData.TabIndex = 7;
            this.labelMultiData.Text = "Data (HEX) :";
            // 
            // labelMultiAddress
            // 
            this.labelMultiAddress.AutoSize = true;
            this.labelMultiAddress.Font = new System.Drawing.Font("新細明體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.labelMultiAddress.Location = new System.Drawing.Point(22, 54);
            this.labelMultiAddress.Name = "labelMultiAddress";
            this.labelMultiAddress.Size = new System.Drawing.Size(106, 12);
            this.labelMultiAddress.TabIndex = 6;
            this.labelMultiAddress.Text = "Start Address (HEX) :";
            // 
            // radioButtonWriteMulti
            // 
            this.radioButtonWriteMulti.AutoSize = true;
            this.radioButtonWriteMulti.Font = new System.Drawing.Font("新細明體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.radioButtonWriteMulti.Location = new System.Drawing.Point(78, 21);
            this.radioButtonWriteMulti.Name = "radioButtonWriteMulti";
            this.radioButtonWriteMulti.Size = new System.Drawing.Size(49, 16);
            this.radioButtonWriteMulti.TabIndex = 1;
            this.radioButtonWriteMulti.TabStop = true;
            this.radioButtonWriteMulti.Text = "Write";
            this.radioButtonWriteMulti.UseVisualStyleBackColor = true;
            // 
            // radioButtonReadMulti
            // 
            this.radioButtonReadMulti.AutoSize = true;
            this.radioButtonReadMulti.Checked = true;
            this.radioButtonReadMulti.Font = new System.Drawing.Font("新細明體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.radioButtonReadMulti.Location = new System.Drawing.Point(24, 22);
            this.radioButtonReadMulti.Name = "radioButtonReadMulti";
            this.radioButtonReadMulti.Size = new System.Drawing.Size(47, 16);
            this.radioButtonReadMulti.TabIndex = 0;
            this.radioButtonReadMulti.TabStop = true;
            this.radioButtonReadMulti.Text = "Read";
            this.radioButtonReadMulti.UseVisualStyleBackColor = true;
            // 
            // EEPROM
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(319, 452);
            this.Controls.Add(this.groupBoxMultiByte);
            this.Controls.Add(this.groupBoxSingleByte);
            this.Controls.Add(this.labelEERPOMSizeUnit);
            this.Controls.Add(this.textBoxEEPROMSize);
            this.Controls.Add(this.textBoxLibVersion);
            this.Controls.Add(this.labelEEPROMSize);
            this.Controls.Add(this.labelLibVersion);
            this.Name = "EEPROM";
            this.Text = "TREK V3 VPM Sample Code";
            this.Load += new System.EventHandler(this.EEPROM_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.EEPROM_FormClosed);
            this.groupBoxSingleByte.ResumeLayout(false);
            this.groupBoxSingleByte.PerformLayout();
            this.groupBoxMultiByte.ResumeLayout(false);
            this.groupBoxMultiByte.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelLibVersion;
        private System.Windows.Forms.Label labelEEPROMSize;
        private System.Windows.Forms.TextBox textBoxLibVersion;
        private System.Windows.Forms.TextBox textBoxEEPROMSize;
        private System.Windows.Forms.Label labelEERPOMSizeUnit;
        private System.Windows.Forms.GroupBox groupBoxSingleByte;
        private System.Windows.Forms.RadioButton radioButtonReadByte;
        private System.Windows.Forms.TextBox textBoxByteData;
        private System.Windows.Forms.TextBox textBoxByteAddress;
        private System.Windows.Forms.Label labelByteData;
        private System.Windows.Forms.Label labelByteAddress;
        private System.Windows.Forms.RadioButton radioButtonWriteByte;
        private System.Windows.Forms.Button buttonByteApply;
        private System.Windows.Forms.GroupBox groupBoxMultiByte;
        private System.Windows.Forms.RadioButton radioButtonReadMulti;
        private System.Windows.Forms.TextBox textBoxMultiData;
        private System.Windows.Forms.TextBox textBoxMultiAddress;
        private System.Windows.Forms.Label labelMultiData;
        private System.Windows.Forms.Label labelMultiAddress;
        private System.Windows.Forms.RadioButton radioButtonWriteMulti;
        private System.Windows.Forms.Label labelNumByteReadWrite;
        private System.Windows.Forms.TextBox textBoxMultiNumReadWrite;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxMultiSize;
        private System.Windows.Forms.Label labelMultiSize;
        private System.Windows.Forms.Button buttonMultiApply;
    }
}

