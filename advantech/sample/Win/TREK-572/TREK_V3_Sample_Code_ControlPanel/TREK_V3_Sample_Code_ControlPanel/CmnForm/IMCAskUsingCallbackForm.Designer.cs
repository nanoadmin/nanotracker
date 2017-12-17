namespace IMCDemo
{
    partial class IMCAskUsingCallbackForm
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
            this.StaticUseCallback = new System.Windows.Forms.Label();
            this.RadioUseCallbackYes = new System.Windows.Forms.RadioButton();
            this.RadioUseCallbackNo = new System.Windows.Forms.RadioButton();
            this.BtnUseCallbackOK = new System.Windows.Forms.Button();
            this.BtnUseCallbackCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // StaticUseCallback
            // 
            this.StaticUseCallback.AutoSize = true;
            this.StaticUseCallback.Location = new System.Drawing.Point(9, 9);
            this.StaticUseCallback.Name = "StaticUseCallback";
            this.StaticUseCallback.Size = new System.Drawing.Size(142, 12);
            this.StaticUseCallback.TabIndex = 0;
            this.StaticUseCallback.Text = "Read Data in Callback Way ?";
            // 
            // RadioUseCallbackYes
            // 
            this.RadioUseCallbackYes.AutoSize = true;
            this.RadioUseCallbackYes.Location = new System.Drawing.Point(33, 33);
            this.RadioUseCallbackYes.Name = "RadioUseCallbackYes";
            this.RadioUseCallbackYes.Size = new System.Drawing.Size(40, 16);
            this.RadioUseCallbackYes.TabIndex = 1;
            this.RadioUseCallbackYes.TabStop = true;
            this.RadioUseCallbackYes.Text = "Yes";
            this.RadioUseCallbackYes.UseVisualStyleBackColor = true;
            // 
            // RadioUseCallbackNo
            // 
            this.RadioUseCallbackNo.AutoSize = true;
            this.RadioUseCallbackNo.Checked = true;
            this.RadioUseCallbackNo.Location = new System.Drawing.Point(89, 33);
            this.RadioUseCallbackNo.Name = "RadioUseCallbackNo";
            this.RadioUseCallbackNo.Size = new System.Drawing.Size(37, 16);
            this.RadioUseCallbackNo.TabIndex = 2;
            this.RadioUseCallbackNo.TabStop = true;
            this.RadioUseCallbackNo.Text = "No";
            this.RadioUseCallbackNo.UseVisualStyleBackColor = true;
            // 
            // BtnUseCallbackOK
            // 
            this.BtnUseCallbackOK.Location = new System.Drawing.Point(29, 55);
            this.BtnUseCallbackOK.Name = "BtnUseCallbackOK";
            this.BtnUseCallbackOK.Size = new System.Drawing.Size(54, 23);
            this.BtnUseCallbackOK.TabIndex = 3;
            this.BtnUseCallbackOK.Text = "OK";
            this.BtnUseCallbackOK.UseVisualStyleBackColor = true;
            this.BtnUseCallbackOK.Click += new System.EventHandler(this.BtnUseCallbackOK_Click);
            // 
            // BtnUseCallbackCancel
            // 
            this.BtnUseCallbackCancel.Location = new System.Drawing.Point(91, 55);
            this.BtnUseCallbackCancel.Name = "BtnUseCallbackCancel";
            this.BtnUseCallbackCancel.Size = new System.Drawing.Size(54, 23);
            this.BtnUseCallbackCancel.TabIndex = 4;
            this.BtnUseCallbackCancel.Text = "Cancel";
            this.BtnUseCallbackCancel.UseVisualStyleBackColor = true;
            this.BtnUseCallbackCancel.Click += new System.EventHandler(this.BtnUseCallbackCancel_Click);
            // 
            // IMCAskUsingCallbackForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(159, 86);
            this.Controls.Add(this.BtnUseCallbackCancel);
            this.Controls.Add(this.BtnUseCallbackOK);
            this.Controls.Add(this.RadioUseCallbackNo);
            this.Controls.Add(this.RadioUseCallbackYes);
            this.Controls.Add(this.StaticUseCallback);
            this.Name = "IMCAskUsingCallbackForm";
            this.Text = "Callback";
            this.Load += new System.EventHandler(this.IMCAskUsingCallbackForm_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.IMCAskUsingCallbackForm_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label StaticUseCallback;
        private System.Windows.Forms.RadioButton RadioUseCallbackYes;
        private System.Windows.Forms.RadioButton RadioUseCallbackNo;
        private System.Windows.Forms.Button BtnUseCallbackOK;
        private System.Windows.Forms.Button BtnUseCallbackCancel;
    }
}