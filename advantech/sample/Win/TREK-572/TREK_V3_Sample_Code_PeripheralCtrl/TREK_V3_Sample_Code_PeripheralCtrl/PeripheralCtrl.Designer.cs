namespace TREK_V3_Sample_Code_PeripheralCtrl
{
    partial class PeripheralCtrl
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
            this.StaticLibVersion = new System.Windows.Forms.Label();
            this.StaticLibVersionValue = new System.Windows.Forms.TextBox();
            this.ComboPeripheralCtrl = new System.Windows.Forms.ComboBox();
            this.ComboPeripheralCtrlValue = new System.Windows.Forms.ComboBox();
            this.BtnPeripheralCtrlApply = new System.Windows.Forms.Button();
            this.RadioPeripheralCtrlSet = new System.Windows.Forms.RadioButton();
            this.RadioPeripheralCtrlGet = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // StaticLibVersion
            // 
            this.StaticLibVersion.Location = new System.Drawing.Point(3, 3);
            this.StaticLibVersion.Name = "StaticLibVersion";
            this.StaticLibVersion.Size = new System.Drawing.Size(132, 23);
            this.StaticLibVersion.Text = "Library Version : ";
            // 
            // StaticLibVersionValue
            // 
            this.StaticLibVersionValue.Location = new System.Drawing.Point(141, 3);
            this.StaticLibVersionValue.Name = "StaticLibVersionValue";
            this.StaticLibVersionValue.Size = new System.Drawing.Size(100, 23);
            this.StaticLibVersionValue.TabIndex = 1;
            // 
            // ComboPeripheralCtrl
            // 
            this.ComboPeripheralCtrl.Location = new System.Drawing.Point(3, 32);
            this.ComboPeripheralCtrl.Name = "ComboPeripheralCtrl";
            this.ComboPeripheralCtrl.Size = new System.Drawing.Size(132, 23);
            this.ComboPeripheralCtrl.TabIndex = 2;
            // 
            // ComboPeripheralCtrlValue
            // 
            this.ComboPeripheralCtrlValue.Location = new System.Drawing.Point(141, 32);
            this.ComboPeripheralCtrlValue.Name = "ComboPeripheralCtrlValue";
            this.ComboPeripheralCtrlValue.Size = new System.Drawing.Size(100, 23);
            this.ComboPeripheralCtrlValue.TabIndex = 3;
            // 
            // BtnPeripheralCtrlApply
            // 
            this.BtnPeripheralCtrlApply.Location = new System.Drawing.Point(63, 71);
            this.BtnPeripheralCtrlApply.Name = "BtnPeripheralCtrlApply";
            this.BtnPeripheralCtrlApply.Size = new System.Drawing.Size(72, 23);
            this.BtnPeripheralCtrlApply.TabIndex = 4;
            this.BtnPeripheralCtrlApply.Text = "Apply";
            this.BtnPeripheralCtrlApply.Click += new System.EventHandler(this.BtnPeripheralCtrlApply_Click);
            // 
            // RadioPeripheralCtrlSet
            // 
            this.RadioPeripheralCtrlSet.Checked = true;
            this.RadioPeripheralCtrlSet.Location = new System.Drawing.Point(141, 61);
            this.RadioPeripheralCtrlSet.Name = "RadioPeripheralCtrlSet";
            this.RadioPeripheralCtrlSet.Size = new System.Drawing.Size(100, 20);
            this.RadioPeripheralCtrlSet.TabIndex = 5;
            this.RadioPeripheralCtrlSet.Text = "Set";
            // 
            // RadioPeripheralCtrlGet
            // 
            this.RadioPeripheralCtrlGet.Location = new System.Drawing.Point(141, 87);
            this.RadioPeripheralCtrlGet.Name = "RadioPeripheralCtrlGet";
            this.RadioPeripheralCtrlGet.Size = new System.Drawing.Size(100, 20);
            this.RadioPeripheralCtrlGet.TabIndex = 6;
            this.RadioPeripheralCtrlGet.Text = "Get";
            // 
            // PeripheralCtrl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(258, 122);
            this.Controls.Add(this.RadioPeripheralCtrlGet);
            this.Controls.Add(this.RadioPeripheralCtrlSet);
            this.Controls.Add(this.BtnPeripheralCtrlApply);
            this.Controls.Add(this.ComboPeripheralCtrlValue);
            this.Controls.Add(this.ComboPeripheralCtrl);
            this.Controls.Add(this.StaticLibVersionValue);
            this.Controls.Add(this.StaticLibVersion);
            this.Name = "PeripheralCtrl";
            this.Text = "TREK V3 PeripheralCtrl Sample Code";
            this.Load += new System.EventHandler(this.PeripheralCtrl_Load);
            this.Closed += new System.EventHandler(this.PeripheralCtrl_Closed);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label StaticLibVersion;
        private System.Windows.Forms.TextBox StaticLibVersionValue;
        private System.Windows.Forms.ComboBox ComboPeripheralCtrl;
        private System.Windows.Forms.ComboBox ComboPeripheralCtrlValue;
        private System.Windows.Forms.Button BtnPeripheralCtrlApply;
        private System.Windows.Forms.RadioButton RadioPeripheralCtrlSet;
        private System.Windows.Forms.RadioButton RadioPeripheralCtrlGet;
    }
}

