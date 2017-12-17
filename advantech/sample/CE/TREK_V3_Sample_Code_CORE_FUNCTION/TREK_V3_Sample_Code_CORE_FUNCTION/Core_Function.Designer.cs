namespace TREK_V3_Sample_Code_CORE_FUNCTION
{
    partial class Core_Function
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
            this.GetLibVersionBtn = new System.Windows.Forms.Button();
            this.LibVersionTxtBx = new System.Windows.Forms.TextBox();
            this.CoreAvailiabeBtn = new System.Windows.Forms.Button();
            this.CoreAvailableTxtBx = new System.Windows.Forms.TextBox();
            this.GetPlfNameBtn = new System.Windows.Forms.Button();
            this.GetPlfNameTxtBx = new System.Windows.Forms.TextBox();
            this.BootCntStatusLabel = new System.Windows.Forms.Label();
            this.BootTimesLabel = new System.Windows.Forms.Label();
            this.BootTimesTxtBx = new System.Windows.Forms.TextBox();
            this.BootCountGetBtn = new System.Windows.Forms.Button();
            this.BootCountSetBtn = new System.Windows.Forms.Button();
            this.BootCntStatusCmbBox = new System.Windows.Forms.ComboBox();
            this.SoftResetBtn = new System.Windows.Forms.Button();
            this.HardResetBtn = new System.Windows.Forms.Button();
            this.WinCEImgVersionLabel = new System.Windows.Forms.Label();
            this.WinCEBuiltDateLabel = new System.Windows.Forms.Label();
            this.BootloaderVersionLabel = new System.Windows.Forms.Label();
            this.BootloaderDateLabel = new System.Windows.Forms.Label();
            this.WinCEImgVersionTxtBx = new System.Windows.Forms.TextBox();
            this.WinCEBuiltDateTxtBx = new System.Windows.Forms.TextBox();
            this.BootloaderVersionTxtBx = new System.Windows.Forms.TextBox();
            this.BootloaderDateTxtBx = new System.Windows.Forms.TextBox();
            this.GetImageInfoBtn = new System.Windows.Forms.Button();
            this.SaveRegBtn = new System.Windows.Forms.Button();
            this.CleanRegBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // GetLibVersionBtn
            // 
            this.GetLibVersionBtn.Location = new System.Drawing.Point(35, 14);
            this.GetLibVersionBtn.Name = "GetLibVersionBtn";
            this.GetLibVersionBtn.Size = new System.Drawing.Size(134, 23);
            this.GetLibVersionBtn.TabIndex = 0;
            this.GetLibVersionBtn.Text = "Get lib version";
            this.GetLibVersionBtn.Click += new System.EventHandler(this.button1_Click);
            // 
            // LibVersionTxtBx
            // 
            this.LibVersionTxtBx.Location = new System.Drawing.Point(175, 14);
            this.LibVersionTxtBx.Name = "LibVersionTxtBx";
            this.LibVersionTxtBx.Size = new System.Drawing.Size(149, 23);
            this.LibVersionTxtBx.TabIndex = 1;
            // 
            // CoreAvailiabeBtn
            // 
            this.CoreAvailiabeBtn.Location = new System.Drawing.Point(35, 43);
            this.CoreAvailiabeBtn.Name = "CoreAvailiabeBtn";
            this.CoreAvailiabeBtn.Size = new System.Drawing.Size(134, 22);
            this.CoreAvailiabeBtn.TabIndex = 2;
            this.CoreAvailiabeBtn.Text = "Core Available";
            this.CoreAvailiabeBtn.Click += new System.EventHandler(this.button2_Click);
            // 
            // CoreAvailableTxtBx
            // 
            this.CoreAvailableTxtBx.Location = new System.Drawing.Point(175, 43);
            this.CoreAvailableTxtBx.Name = "CoreAvailableTxtBx";
            this.CoreAvailableTxtBx.Size = new System.Drawing.Size(149, 23);
            this.CoreAvailableTxtBx.TabIndex = 3;
            // 
            // GetPlfNameBtn
            // 
            this.GetPlfNameBtn.Location = new System.Drawing.Point(35, 71);
            this.GetPlfNameBtn.Name = "GetPlfNameBtn";
            this.GetPlfNameBtn.Size = new System.Drawing.Size(134, 23);
            this.GetPlfNameBtn.TabIndex = 4;
            this.GetPlfNameBtn.Text = "Get Platform Name";
            this.GetPlfNameBtn.Click += new System.EventHandler(this.button3_Click);
            // 
            // GetPlfNameTxtBx
            // 
            this.GetPlfNameTxtBx.Location = new System.Drawing.Point(175, 72);
            this.GetPlfNameTxtBx.Name = "GetPlfNameTxtBx";
            this.GetPlfNameTxtBx.Size = new System.Drawing.Size(149, 23);
            this.GetPlfNameTxtBx.TabIndex = 5;
            // 
            // BootCntStatusLabel
            // 
            this.BootCntStatusLabel.Location = new System.Drawing.Point(35, 101);
            this.BootCntStatusLabel.Name = "BootCntStatusLabel";
            this.BootCntStatusLabel.Size = new System.Drawing.Size(134, 23);
            this.BootCntStatusLabel.Text = "Boot Count Status :";
            // 
            // BootTimesLabel
            // 
            this.BootTimesLabel.Location = new System.Drawing.Point(35, 130);
            this.BootTimesLabel.Name = "BootTimesLabel";
            this.BootTimesLabel.Size = new System.Drawing.Size(134, 23);
            this.BootTimesLabel.Text = "Boot Times :";
            // 
            // BootTimesTxtBx
            // 
            this.BootTimesTxtBx.Location = new System.Drawing.Point(175, 130);
            this.BootTimesTxtBx.Name = "BootTimesTxtBx";
            this.BootTimesTxtBx.Size = new System.Drawing.Size(149, 23);
            this.BootTimesTxtBx.TabIndex = 9;
            // 
            // BootCountGetBtn
            // 
            this.BootCountGetBtn.Location = new System.Drawing.Point(175, 160);
            this.BootCountGetBtn.Name = "BootCountGetBtn";
            this.BootCountGetBtn.Size = new System.Drawing.Size(72, 20);
            this.BootCountGetBtn.TabIndex = 10;
            this.BootCountGetBtn.Text = "Get";
            this.BootCountGetBtn.Click += new System.EventHandler(this.button4_Click);
            // 
            // BootCountSetBtn
            // 
            this.BootCountSetBtn.Location = new System.Drawing.Point(254, 159);
            this.BootCountSetBtn.Name = "BootCountSetBtn";
            this.BootCountSetBtn.Size = new System.Drawing.Size(72, 20);
            this.BootCountSetBtn.TabIndex = 11;
            this.BootCountSetBtn.Text = "Set";
            this.BootCountSetBtn.Click += new System.EventHandler(this.button5_Click);
            // 
            // BootCntStatusCmbBox
            // 
            this.BootCntStatusCmbBox.Items.Add("True");
            this.BootCntStatusCmbBox.Items.Add("False");
            this.BootCntStatusCmbBox.Location = new System.Drawing.Point(175, 101);
            this.BootCntStatusCmbBox.Name = "BootCntStatusCmbBox";
            this.BootCntStatusCmbBox.Size = new System.Drawing.Size(151, 23);
            this.BootCntStatusCmbBox.TabIndex = 26;
            // 
            // SoftResetBtn
            // 
            this.SoftResetBtn.Location = new System.Drawing.Point(332, 160);
            this.SoftResetBtn.Name = "SoftResetBtn";
            this.SoftResetBtn.Size = new System.Drawing.Size(134, 22);
            this.SoftResetBtn.TabIndex = 29;
            this.SoftResetBtn.Text = "Soft Reset";
            this.SoftResetBtn.Click += new System.EventHandler(this.button6_Click);
            // 
            // HardResetBtn
            // 
            this.HardResetBtn.Location = new System.Drawing.Point(472, 160);
            this.HardResetBtn.Name = "HardResetBtn";
            this.HardResetBtn.Size = new System.Drawing.Size(134, 22);
            this.HardResetBtn.TabIndex = 30;
            this.HardResetBtn.Text = "Hard Reset";
            this.HardResetBtn.Click += new System.EventHandler(this.button7_Click);
            // 
            // WinCEImgVersionLabel
            // 
            this.WinCEImgVersionLabel.Location = new System.Drawing.Point(330, 14);
            this.WinCEImgVersionLabel.Name = "WinCEImgVersionLabel";
            this.WinCEImgVersionLabel.Size = new System.Drawing.Size(146, 23);
            this.WinCEImgVersionLabel.Text = "WinCE Image Version :";
            // 
            // WinCEBuiltDateLabel
            // 
            this.WinCEBuiltDateLabel.Location = new System.Drawing.Point(330, 43);
            this.WinCEBuiltDateLabel.Name = "WinCEBuiltDateLabel";
            this.WinCEBuiltDateLabel.Size = new System.Drawing.Size(134, 23);
            this.WinCEBuiltDateLabel.Text = "WinCE Built Date :";
            // 
            // BootloaderVersionLabel
            // 
            this.BootloaderVersionLabel.Location = new System.Drawing.Point(330, 71);
            this.BootloaderVersionLabel.Name = "BootloaderVersionLabel";
            this.BootloaderVersionLabel.Size = new System.Drawing.Size(146, 23);
            this.BootloaderVersionLabel.Text = "Bootloader Version :";
            // 
            // BootloaderDateLabel
            // 
            this.BootloaderDateLabel.Location = new System.Drawing.Point(330, 101);
            this.BootloaderDateLabel.Name = "BootloaderDateLabel";
            this.BootloaderDateLabel.Size = new System.Drawing.Size(134, 23);
            this.BootloaderDateLabel.Text = "Bootloader Date :";
            // 
            // WinCEImgVersionTxtBx
            // 
            this.WinCEImgVersionTxtBx.Location = new System.Drawing.Point(482, 14);
            this.WinCEImgVersionTxtBx.Name = "WinCEImgVersionTxtBx";
            this.WinCEImgVersionTxtBx.Size = new System.Drawing.Size(100, 23);
            this.WinCEImgVersionTxtBx.TabIndex = 43;
            // 
            // WinCEBuiltDateTxtBx
            // 
            this.WinCEBuiltDateTxtBx.Location = new System.Drawing.Point(482, 43);
            this.WinCEBuiltDateTxtBx.Name = "WinCEBuiltDateTxtBx";
            this.WinCEBuiltDateTxtBx.Size = new System.Drawing.Size(100, 23);
            this.WinCEBuiltDateTxtBx.TabIndex = 44;
            // 
            // BootloaderVersionTxtBx
            // 
            this.BootloaderVersionTxtBx.Location = new System.Drawing.Point(482, 72);
            this.BootloaderVersionTxtBx.Name = "BootloaderVersionTxtBx";
            this.BootloaderVersionTxtBx.Size = new System.Drawing.Size(100, 23);
            this.BootloaderVersionTxtBx.TabIndex = 45;
            // 
            // BootloaderDateTxtBx
            // 
            this.BootloaderDateTxtBx.Location = new System.Drawing.Point(482, 101);
            this.BootloaderDateTxtBx.Name = "BootloaderDateTxtBx";
            this.BootloaderDateTxtBx.Size = new System.Drawing.Size(100, 23);
            this.BootloaderDateTxtBx.TabIndex = 46;
            // 
            // GetImageInfoBtn
            // 
            this.GetImageInfoBtn.Location = new System.Drawing.Point(448, 130);
            this.GetImageInfoBtn.Name = "GetImageInfoBtn";
            this.GetImageInfoBtn.Size = new System.Drawing.Size(134, 23);
            this.GetImageInfoBtn.TabIndex = 47;
            this.GetImageInfoBtn.Text = "Get Image Info";
            this.GetImageInfoBtn.Click += new System.EventHandler(this.button9_Click);
            // 
            // SaveRegBtn
            // 
            this.SaveRegBtn.Location = new System.Drawing.Point(331, 188);
            this.SaveRegBtn.Name = "SaveRegBtn";
            this.SaveRegBtn.Size = new System.Drawing.Size(134, 23);
            this.SaveRegBtn.TabIndex = 48;
            this.SaveRegBtn.Text = "Save Registry";
            this.SaveRegBtn.Click += new System.EventHandler(this.button10_Click);
            // 
            // CleanRegBtn
            // 
            this.CleanRegBtn.Location = new System.Drawing.Point(472, 188);
            this.CleanRegBtn.Name = "CleanRegBtn";
            this.CleanRegBtn.Size = new System.Drawing.Size(134, 23);
            this.CleanRegBtn.TabIndex = 49;
            this.CleanRegBtn.Text = "Clean Registry";
            this.CleanRegBtn.Click += new System.EventHandler(this.button11_Click);
            // 
            // Core_Function
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(638, 229);
            this.Controls.Add(this.CleanRegBtn);
            this.Controls.Add(this.SaveRegBtn);
            this.Controls.Add(this.GetImageInfoBtn);
            this.Controls.Add(this.BootloaderDateTxtBx);
            this.Controls.Add(this.BootloaderVersionTxtBx);
            this.Controls.Add(this.WinCEBuiltDateTxtBx);
            this.Controls.Add(this.WinCEImgVersionTxtBx);
            this.Controls.Add(this.BootloaderDateLabel);
            this.Controls.Add(this.BootloaderVersionLabel);
            this.Controls.Add(this.WinCEBuiltDateLabel);
            this.Controls.Add(this.WinCEImgVersionLabel);
            this.Controls.Add(this.HardResetBtn);
            this.Controls.Add(this.SoftResetBtn);
            this.Controls.Add(this.BootCntStatusCmbBox);
            this.Controls.Add(this.BootCountSetBtn);
            this.Controls.Add(this.BootCountGetBtn);
            this.Controls.Add(this.BootTimesTxtBx);
            this.Controls.Add(this.BootTimesLabel);
            this.Controls.Add(this.BootCntStatusLabel);
            this.Controls.Add(this.GetPlfNameTxtBx);
            this.Controls.Add(this.GetPlfNameBtn);
            this.Controls.Add(this.CoreAvailableTxtBx);
            this.Controls.Add(this.CoreAvailiabeBtn);
            this.Controls.Add(this.LibVersionTxtBx);
            this.Controls.Add(this.GetLibVersionBtn);
            this.Name = "Core_Function";
            this.Text = "TREK V3 Core Function Sample Code";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button GetLibVersionBtn;
        private System.Windows.Forms.TextBox LibVersionTxtBx;
        private System.Windows.Forms.Button CoreAvailiabeBtn;
        private System.Windows.Forms.TextBox CoreAvailableTxtBx;
        private System.Windows.Forms.Button GetPlfNameBtn;
        private System.Windows.Forms.TextBox GetPlfNameTxtBx;
        private System.Windows.Forms.Label BootCntStatusLabel;
        private System.Windows.Forms.Label BootTimesLabel;
        private System.Windows.Forms.TextBox BootTimesTxtBx;
        private System.Windows.Forms.Button BootCountGetBtn;
        private System.Windows.Forms.Button BootCountSetBtn;
        private System.Windows.Forms.ComboBox BootCntStatusCmbBox;
        private System.Windows.Forms.Button SoftResetBtn;
        private System.Windows.Forms.Button HardResetBtn;
        private System.Windows.Forms.Label WinCEImgVersionLabel;
        private System.Windows.Forms.Label WinCEBuiltDateLabel;
        private System.Windows.Forms.Label BootloaderVersionLabel;
        private System.Windows.Forms.Label BootloaderDateLabel;
        private System.Windows.Forms.TextBox WinCEImgVersionTxtBx;
        private System.Windows.Forms.TextBox WinCEBuiltDateTxtBx;
        private System.Windows.Forms.TextBox BootloaderVersionTxtBx;
        private System.Windows.Forms.TextBox BootloaderDateTxtBx;
        private System.Windows.Forms.Button GetImageInfoBtn;
        private System.Windows.Forms.Button SaveRegBtn;
        private System.Windows.Forms.Button CleanRegBtn;
    }
}

