namespace IMCDemo
{
    partial class IMCBaseForm
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
            this.PanelShowScroll = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // PanelShowScroll
            // 
            this.PanelShowScroll.Location = new System.Drawing.Point(2, 1);
            this.PanelShowScroll.Name = "PanelShowScroll";
            this.PanelShowScroll.Size = new System.Drawing.Size(5, 5);
            this.PanelShowScroll.TabIndex = 62;
            // 
            // IMCBaseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(104, 10);
            this.Controls.Add(this.PanelShowScroll);
            this.Name = "IMCBaseForm";
            this.Text = "IMCBaseForm";
            this.Load += new System.EventHandler(this.IMCBaseForm_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.IMCBaseForm_FormClosed);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel PanelShowScroll;
    }
}