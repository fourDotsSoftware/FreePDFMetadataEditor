namespace FreePDFMetadataEditor
{
    partial class frmDownloadUpdate
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDownloadUpdate));
            this.pgBar = new FreePDFMetadataEditor.ucTextProgressBar();
            this.btnCancelDownload = new System.Windows.Forms.Button();
            this.bwDownload = new System.ComponentModel.BackgroundWorker();
            this.label1 = new System.Windows.Forms.Label();
            this.lblTotalSize = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // pgBar
            // 
            this.pgBar.BackColor = System.Drawing.SystemColors.Control;
            resources.ApplyResources(this.pgBar, "pgBar");
            this.pgBar.Name = "pgBar";
            // 
            // btnCancelDownload
            // 
            resources.ApplyResources(this.btnCancelDownload, "btnCancelDownload");
            this.btnCancelDownload.Name = "btnCancelDownload";
            this.btnCancelDownload.UseVisualStyleBackColor = true;
            this.btnCancelDownload.Click += new System.EventHandler(this.btnCancelDownload_Click);
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Name = "label1";
            // 
            // lblTotalSize
            // 
            resources.ApplyResources(this.lblTotalSize, "lblTotalSize");
            this.lblTotalSize.BackColor = System.Drawing.Color.Transparent;
            this.lblTotalSize.Name = "lblTotalSize";
            // 
            // frmDownloadUpdate
            // 
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.lblTotalSize);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCancelDownload);
            this.Controls.Add(this.pgBar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmDownloadUpdate";
            this.Load += new System.EventHandler(this.frmDownloadUpdate_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ucTextProgressBar pgBar;
        private System.Windows.Forms.Button btnCancelDownload;
        private System.ComponentModel.BackgroundWorker bwDownload;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblTotalSize;
    }
}
