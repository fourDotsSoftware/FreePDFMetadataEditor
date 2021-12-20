using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace FreePDFMetadataEditor
{
    public partial class frmProgress : CustomForm
    {
        public static frmProgress Instance = null;
        public frmProgress()
        {
            InitializeComponent();
            Instance = this;
            this.TopMost = true;
        }

        private delegate void HideFormDelegate();

        public void HideForm()
        {
            if (this.InvokeRequired)
            {
                this.Invoke((HideFormDelegate)HideForm, null);
            }
            else
            {
                this.Visible = false;
            }
        }

        private delegate void ShowFormDelegate();

        public void ShowForm()
        {
            if (this.InvokeRequired)
            {
                this.Invoke((ShowFormDelegate)ShowForm, null);
            }
            else
            {
                this.Visible = false;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            MetadataHelper.CANCELLED = true;
            frmMain.Instance.backgroundWorker1.CancelAsync();
        }
    }
}

