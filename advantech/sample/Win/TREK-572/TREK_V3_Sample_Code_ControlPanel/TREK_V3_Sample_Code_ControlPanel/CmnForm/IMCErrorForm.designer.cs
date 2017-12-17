namespace IMCDemo
{
    partial class IMCErrorForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.StaticErrCode = new System.Windows.Forms.Label();
            this.StaticErrCodeValue = new System.Windows.Forms.Label();
            this.StaticErrDesc = new System.Windows.Forms.Label();
            this.EditErrDescValue = new System.Windows.Forms.TextBox();
            this.PanelInner = new System.Windows.Forms.Panel();
            this.BtnScreenSnapshot = new System.Windows.Forms.Button();
            this.PicBoxAdvantechLogo = new System.Windows.Forms.PictureBox();
            this.MenuPopup = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.snapshotToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.PanelInner.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PicBoxAdvantechLogo)).BeginInit();
            this.MenuPopup.SuspendLayout();
            this.SuspendLayout();
            // 
            // StaticErrCode
            // 
            this.StaticErrCode.Font = new System.Drawing.Font("PMingLiU", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.StaticErrCode.Location = new System.Drawing.Point(3, 9);
            this.StaticErrCode.Name = "StaticErrCode";
            this.StaticErrCode.Size = new System.Drawing.Size(79, 16);
            this.StaticErrCode.TabIndex = 0;
            this.StaticErrCode.Text = "Error Code :";
            // 
            // StaticErrCodeValue
            // 
            this.StaticErrCodeValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.StaticErrCodeValue.Location = new System.Drawing.Point(88, 9);
            this.StaticErrCodeValue.Name = "StaticErrCodeValue";
            this.StaticErrCodeValue.Size = new System.Drawing.Size(166, 16);
            this.StaticErrCodeValue.TabIndex = 1;
            // 
            // StaticErrDesc
            // 
            this.StaticErrDesc.Font = new System.Drawing.Font("PMingLiU", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.StaticErrDesc.Location = new System.Drawing.Point(3, 35);
            this.StaticErrDesc.Name = "StaticErrDesc";
            this.StaticErrDesc.Size = new System.Drawing.Size(251, 16);
            this.StaticErrDesc.TabIndex = 2;
            this.StaticErrDesc.Text = "Error Description :";
            // 
            // EditErrDescValue
            // 
            this.EditErrDescValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.EditErrDescValue.Location = new System.Drawing.Point(5, 54);
            this.EditErrDescValue.Multiline = true;
            this.EditErrDescValue.Name = "EditErrDescValue";
            this.EditErrDescValue.ReadOnly = true;
            this.EditErrDescValue.Size = new System.Drawing.Size(249, 171);
            this.EditErrDescValue.TabIndex = 3;
            this.EditErrDescValue.TabStop = false;
            // 
            // PanelInner
            // 
            this.PanelInner.Controls.Add(this.BtnScreenSnapshot);
            this.PanelInner.Controls.Add(this.PicBoxAdvantechLogo);
            this.PanelInner.Controls.Add(this.StaticErrCode);
            this.PanelInner.Controls.Add(this.EditErrDescValue);
            this.PanelInner.Controls.Add(this.StaticErrCodeValue);
            this.PanelInner.Controls.Add(this.StaticErrDesc);
            this.PanelInner.Location = new System.Drawing.Point(4, 3);
            this.PanelInner.Name = "PanelInner";
            this.PanelInner.Size = new System.Drawing.Size(261, 272);
            this.PanelInner.TabIndex = 63;
            // 
            // BtnScreenSnapshot
            // 
            this.BtnScreenSnapshot.Image = global::TREK_V3_Sample_Code_ControlPanel.Properties.Resources.cam1;
            this.BtnScreenSnapshot.Location = new System.Drawing.Point(216, 234);
            this.BtnScreenSnapshot.Name = "BtnScreenSnapshot";
            this.BtnScreenSnapshot.Size = new System.Drawing.Size(38, 34);
            this.BtnScreenSnapshot.TabIndex = 49;
            this.BtnScreenSnapshot.UseVisualStyleBackColor = true;
            this.BtnScreenSnapshot.Click += new System.EventHandler(this.BtnScreenSnapshot_Click);
            // 
            // PicBoxAdvantechLogo
            // 
            this.PicBoxAdvantechLogo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PicBoxAdvantechLogo.Image = global::TREK_V3_Sample_Code_ControlPanel.Properties.Resources.AdvantechLogo;
            this.PicBoxAdvantechLogo.Location = new System.Drawing.Point(5, 232);
            this.PicBoxAdvantechLogo.Name = "PicBoxAdvantechLogo";
            this.PicBoxAdvantechLogo.Size = new System.Drawing.Size(181, 36);
            this.PicBoxAdvantechLogo.TabIndex = 48;
            this.PicBoxAdvantechLogo.TabStop = false;
            // 
            // MenuPopup
            // 
            this.MenuPopup.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.snapshotToolStripMenuItem});
            this.MenuPopup.Name = "MenuPopup";
            this.MenuPopup.Size = new System.Drawing.Size(113, 26);
            // 
            // snapshotToolStripMenuItem
            // 
            this.snapshotToolStripMenuItem.Name = "snapshotToolStripMenuItem";
            this.snapshotToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.snapshotToolStripMenuItem.Text = "Snapshot";
            this.snapshotToolStripMenuItem.Click += new System.EventHandler(this.snapshotToolStripMenuItem_Click);
            // 
            // IMCErrorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(269, 278);
            this.Controls.Add(this.PanelInner);
            this.Name = "IMCErrorForm";
            this.Text = "IMC API Error Message";
            this.Load += new System.EventHandler(this.IMCErrorForm_Load);
            this.Controls.SetChildIndex(this.PanelInner, 0);
            this.PanelInner.ResumeLayout(false);
            this.PanelInner.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PicBoxAdvantechLogo)).EndInit();
            this.MenuPopup.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label StaticErrCode;
        private System.Windows.Forms.Label StaticErrCodeValue;
        private System.Windows.Forms.Label StaticErrDesc;
        private System.Windows.Forms.TextBox EditErrDescValue;
        private System.Windows.Forms.Panel PanelInner;
        private System.Windows.Forms.Button BtnScreenSnapshot;
        private System.Windows.Forms.PictureBox PicBoxAdvantechLogo;
        private System.Windows.Forms.ContextMenuStrip MenuPopup;
        private System.Windows.Forms.ToolStripMenuItem snapshotToolStripMenuItem;
    }
}