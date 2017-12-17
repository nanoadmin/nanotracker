using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using IMCDemo;

namespace IMCDemo
{
    public partial class IMCAskUsingCallbackForm : IMCBaseForm
    {
// Field
// The flag of reading data in callback way
        private bool bCallback;

// Property
        public bool Callback
        {
            set
            {
                bCallback = value;
            }
            get
            {
                return bCallback;
            }
        }

// The member functions
        void UseCallback(bool bUseCallback)
        {
            bCallback = bUseCallback;
        }

// The events
        public IMCAskUsingCallbackForm()
        {
            InitializeComponent();
            ControlBox = false;
            MaximizeBox = false;
            MinimizeBox = false;
            bCallback = false;
        }

        private void IMCAskUsingCallbackForm_Load(object sender, EventArgs e)
        {
            RadioUseCallbackYes.Checked = bCallback;
            RadioUseCallbackNo.Checked = !bCallback;
        }

        private void IMCAskUsingCallbackForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            bCallback = (RadioUseCallbackYes.Checked ? true : false);

        }

        private void BtnUseCallbackOK_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void BtnUseCallbackCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }





    }
}
