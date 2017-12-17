namespace TREK_V3_Sample_Code_RearView
{
    partial class RearViewForm
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
            this.labelLibVersion = new System.Windows.Forms.Label();
            this.tbLibVersion = new System.Windows.Forms.TextBox();
            this.btnMainSrc = new System.Windows.Forms.Button();
            this.btnExtSrc = new System.Windows.Forms.Button();
            this.cbAutoSwitchTime = new System.Windows.Forms.ComboBox();
            this.labelTextSec = new System.Windows.Forms.Label();
            this.checkBoxAutoSwitch = new System.Windows.Forms.CheckBox();
            this.timerAutoSwitchMainSrc = new System.Windows.Forms.Timer(this.components);
            this.checkBoxAutoSwitchBaseDI = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // labelLibVersion
            // 
            this.labelLibVersion.AutoSize = true;
            this.labelLibVersion.Location = new System.Drawing.Point(36, 25);
            this.labelLibVersion.Name = "labelLibVersion";
            this.labelLibVersion.Size = new System.Drawing.Size(83, 12);
            this.labelLibVersion.TabIndex = 0;
            this.labelLibVersion.Text = "Library version :";
            // 
            // tbLibVersion
            // 
            this.tbLibVersion.Location = new System.Drawing.Point(123, 19);
            this.tbLibVersion.Name = "tbLibVersion";
            this.tbLibVersion.Size = new System.Drawing.Size(151, 22);
            this.tbLibVersion.TabIndex = 1;
            // 
            // btnMainSrc
            // 
            this.btnMainSrc.Enabled = false;
            this.btnMainSrc.Location = new System.Drawing.Point(28, 117);
            this.btnMainSrc.Name = "btnMainSrc";
            this.btnMainSrc.Size = new System.Drawing.Size(115, 56);
            this.btnMainSrc.TabIndex = 2;
            this.btnMainSrc.Text = "Main";
            this.btnMainSrc.UseVisualStyleBackColor = true;
            this.btnMainSrc.Click += new System.EventHandler(this.btnMainSrc_Click);
            // 
            // btnExtSrc
            // 
            this.btnExtSrc.Location = new System.Drawing.Point(149, 117);
            this.btnExtSrc.Name = "btnExtSrc";
            this.btnExtSrc.Size = new System.Drawing.Size(119, 56);
            this.btnExtSrc.TabIndex = 3;
            this.btnExtSrc.Text = "External";
            this.btnExtSrc.UseVisualStyleBackColor = true;
            this.btnExtSrc.Click += new System.EventHandler(this.btnExtSrc_Click);
            // 
            // cbAutoSwitchTime
            // 
            this.cbAutoSwitchTime.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbAutoSwitchTime.FormattingEnabled = true;
            this.cbAutoSwitchTime.Items.AddRange(new object[] {
            "5",
            "10",
            "15",
            "20",
            "25",
            "30"});
            this.cbAutoSwitchTime.Location = new System.Drawing.Point(38, 78);
            this.cbAutoSwitchTime.Name = "cbAutoSwitchTime";
            this.cbAutoSwitchTime.Size = new System.Drawing.Size(50, 20);
            this.cbAutoSwitchTime.TabIndex = 6;
            // 
            // labelTextSec
            // 
            this.labelTextSec.AutoSize = true;
            this.labelTextSec.Location = new System.Drawing.Point(94, 81);
            this.labelTextSec.Name = "labelTextSec";
            this.labelTextSec.Size = new System.Drawing.Size(41, 12);
            this.labelTextSec.TabIndex = 7;
            this.labelTextSec.Text = "seconds";
            // 
            // checkBoxAutoSwitch
            // 
            this.checkBoxAutoSwitch.AutoSize = true;
            this.checkBoxAutoSwitch.Checked = true;
            this.checkBoxAutoSwitch.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxAutoSwitch.Location = new System.Drawing.Point(38, 49);
            this.checkBoxAutoSwitch.Name = "checkBoxAutoSwitch";
            this.checkBoxAutoSwitch.Size = new System.Drawing.Size(180, 16);
            this.checkBoxAutoSwitch.TabIndex = 8;
            this.checkBoxAutoSwitch.Text = "Auto switch to main source after :";
            this.checkBoxAutoSwitch.UseVisualStyleBackColor = true;
            // 
            // timerAutoSwitchMainSrc
            // 
            this.timerAutoSwitchMainSrc.Interval = 1000;
            this.timerAutoSwitchMainSrc.Tick += new System.EventHandler(this.timerAutoSwitchMainSrc_Tick);
            // 
            // checkBoxAutoSwitchBaseDI
            // 
            this.checkBoxAutoSwitchBaseDI.AutoSize = true;
            this.checkBoxAutoSwitchBaseDI.Location = new System.Drawing.Point(38, 197);
            this.checkBoxAutoSwitchBaseDI.Name = "checkBoxAutoSwitchBaseDI";
            this.checkBoxAutoSwitchBaseDI.Size = new System.Drawing.Size(168, 16);
            this.checkBoxAutoSwitchBaseDI.TabIndex = 9;
            this.checkBoxAutoSwitchBaseDI.Text = "Auto switch hook Digital Input";
            this.checkBoxAutoSwitchBaseDI.UseVisualStyleBackColor = true;
            this.checkBoxAutoSwitchBaseDI.CheckedChanged += new System.EventHandler(this.checkBoxAutoSwitchBaseDI_CheckedChanged);
            // 
            // RearViewForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(306, 244);
            this.Controls.Add(this.checkBoxAutoSwitchBaseDI);
            this.Controls.Add(this.checkBoxAutoSwitch);
            this.Controls.Add(this.labelTextSec);
            this.Controls.Add(this.cbAutoSwitchTime);
            this.Controls.Add(this.btnExtSrc);
            this.Controls.Add(this.btnMainSrc);
            this.Controls.Add(this.tbLibVersion);
            this.Controls.Add(this.labelLibVersion);
            this.Name = "RearViewForm";
            this.Text = "TREK V3 Rear View Sample Code";
            this.Load += new System.EventHandler(this.RearViewForm_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.RearViewForm_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelLibVersion;
        private System.Windows.Forms.TextBox tbLibVersion;
        private System.Windows.Forms.Button btnMainSrc;
        private System.Windows.Forms.Button btnExtSrc;
        private System.Windows.Forms.ComboBox cbAutoSwitchTime;
        private System.Windows.Forms.Label labelTextSec;
        private System.Windows.Forms.CheckBox checkBoxAutoSwitch;
        private System.Windows.Forms.Timer timerAutoSwitchMainSrc;
        private System.Windows.Forms.CheckBox checkBoxAutoSwitchBaseDI;
    }
}

