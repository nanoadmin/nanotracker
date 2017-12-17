namespace IMCDemo
{
    partial class IMCProgressForm
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
            this.ProgressValue = new System.Windows.Forms.ProgressBar();
            this.StaticValue = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // ProgressValue
            // 
            this.ProgressValue.Location = new System.Drawing.Point(5, 8);
            this.ProgressValue.Name = "ProgressValue";
            this.ProgressValue.Size = new System.Drawing.Size(273, 23);
            this.ProgressValue.TabIndex = 0;
            // 
            // StaticValue
            // 
            this.StaticValue.Font = new System.Drawing.Font("PMingLiU", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.StaticValue.Location = new System.Drawing.Point(284, 9);
            this.StaticValue.Name = "StaticValue";
            this.StaticValue.Size = new System.Drawing.Size(40, 23);
            this.StaticValue.TabIndex = 1;
            this.StaticValue.Text = "0%";
            this.StaticValue.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // IMCProgressForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(326, 38);
            this.ControlBox = false;
            this.Controls.Add(this.StaticValue);
            this.Controls.Add(this.ProgressValue);
            this.Name = "IMCProgressForm";
            this.Text = "Progress";
            this.Load += new System.EventHandler(this.IMCProgressForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ProgressBar ProgressValue;
        private System.Windows.Forms.Label StaticValue;
    }
}