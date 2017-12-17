namespace IMCDemo
{
    partial class IMCWaitForm
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
            this.TimerWait = new System.Windows.Forms.Timer(this.components);
            this.PicBoxWait = new System.Windows.Forms.PictureBox();
            this.StaticBoxWait = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.PicBoxWait)).BeginInit();
            this.SuspendLayout();
            // 
            // TimerWait
            // 
            this.TimerWait.Tick += new System.EventHandler(this.TimerWait_Tick);
            // 
            // PicBoxWait
            // 
            this.PicBoxWait.Image = global::TREK_V3_Sample_Code_ControlPanel.Properties.Resources.Wait;
            this.PicBoxWait.Location = new System.Drawing.Point(7, 6);
            this.PicBoxWait.Name = "PicBoxWait";
            this.PicBoxWait.Size = new System.Drawing.Size(50, 50);
            this.PicBoxWait.TabIndex = 0;
            this.PicBoxWait.TabStop = false;
            // 
            // StaticBoxWait
            // 
            this.StaticBoxWait.Font = new System.Drawing.Font("PMingLiU", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.StaticBoxWait.Location = new System.Drawing.Point(65, 20);
            this.StaticBoxWait.Name = "StaticBoxWait";
            this.StaticBoxWait.Size = new System.Drawing.Size(140, 23);
            this.StaticBoxWait.TabIndex = 1;
            this.StaticBoxWait.Text = "Please Wait ...";
            this.StaticBoxWait.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // IMCWaitForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(219, 62);
            this.Controls.Add(this.StaticBoxWait);
            this.Controls.Add(this.PicBoxWait);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "IMCWaitForm";
            this.Text = "Waiting...";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.IMCWaitForm_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.IMCWaitForm_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.PicBoxWait)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox PicBoxWait;
        private System.Windows.Forms.Timer TimerWait;
        private System.Windows.Forms.Label StaticBoxWait;
    }
}