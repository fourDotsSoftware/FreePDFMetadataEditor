namespace FreePDFMetadataEditor
{
    partial class frmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exploreToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.documentsMedataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.folderBrowserDialog2 = new System.Windows.Forms.FolderBrowserDialog();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.btnCustomDelete = new System.Windows.Forms.Button();
            this.btnCustomAdd = new System.Windows.Forms.Button();
            this.btnChangeFolder = new System.Windows.Forms.Button();
            this.btnOpenFolder = new System.Windows.Forms.Button();
            this.btnInsertSpecial = new System.Windows.Forms.Button();
            this.btnSpecialTitle = new System.Windows.Forms.Button();
            this.btnSpecialCreator = new System.Windows.Forms.Button();
            this.btnSpecialKeywords = new System.Windows.Forms.Button();
            this.btnSpecialSubject = new System.Windows.Forms.Button();
            this.btnSpecialAuthor = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.grpCustomMetadata = new System.Windows.Forms.GroupBox();
            this.dgCustomMetadata = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chkModificationDate = new System.Windows.Forms.CheckBox();
            this.chkCreationDate = new System.Windows.Forms.CheckBox();
            this.chkCreator = new System.Windows.Forms.CheckBox();
            this.chkKeywords = new System.Windows.Forms.CheckBox();
            this.chkSubject = new System.Windows.Forms.CheckBox();
            this.chkAuthor = new System.Windows.Forms.CheckBox();
            this.chkTitle = new System.Windows.Forms.CheckBox();
            this.dpModificationDate = new System.Windows.Forms.DateTimePicker();
            this.dpCreationDate = new System.Windows.Forms.DateTimePicker();
            this.txtCreator = new System.Windows.Forms.TextBox();
            this.txtKeywords = new System.Windows.Forms.TextBox();
            this.txtSubject = new System.Windows.Forms.TextBox();
            this.txtAuthor = new System.Windows.Forms.TextBox();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbAddFile = new System.Windows.Forms.ToolStripButton();
            this.tsbRemove = new System.Windows.Forms.ToolStripButton();
            this.tsbAddFolder = new System.Windows.Forms.ToolStripButton();
            this.tsbImportList = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbDocumetMetadata = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbSetMetadata = new System.Windows.Forms.ToolStripButton();
            this.dgFiles = new System.Windows.Forms.DataGridView();
            this.colFilename = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colUserPassword = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSize = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFileDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFullFilePath = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkKeepBackup = new System.Windows.Forms.CheckBox();
            this.cmbOutputDir = new System.Windows.Forms.ComboBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addFilesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.importListFormTextFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importListFromExcelFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.enterFileListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveCurrentFileListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.clearToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.selectAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.selectNoneToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.invertSelectionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.keepFolderStructureToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exploreOutputFolderWhenDoneToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.keepCreationDateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.keepLastModificationDateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showMessageOnSucessToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editMetadataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.downloadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.languageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpGuideToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tryOnlineVersionAtOnlinepdfappscomToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.commandLineArgumentsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.checkForNewVersionEachWeekToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tiHelpFeedback = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.donateViaPaypalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.followUsOnTwitterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.visit4dotsSoftwareWebsiteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.youtubeChannelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.chkClearMetadata = new System.Windows.Forms.CheckBox();
            this.contextMenuStrip1.SuspendLayout();
            this.grpCustomMetadata.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgCustomMetadata)).BeginInit();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgFiles)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.exploreToolStripMenuItem,
            this.documentsMedataToolStripMenuItem,
            this.removeToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            resources.ApplyResources(this.contextMenuStrip1, "contextMenuStrip1");
            this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Image = global::FreePDFMetadataEditor.Properties.Resources.folder;
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            resources.ApplyResources(this.openToolStripMenuItem, "openToolStripMenuItem");
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // exploreToolStripMenuItem
            // 
            this.exploreToolStripMenuItem.Name = "exploreToolStripMenuItem";
            resources.ApplyResources(this.exploreToolStripMenuItem, "exploreToolStripMenuItem");
            this.exploreToolStripMenuItem.Click += new System.EventHandler(this.exploreToolStripMenuItem_Click);
            // 
            // documentsMedataToolStripMenuItem
            // 
            this.documentsMedataToolStripMenuItem.Image = global::FreePDFMetadataEditor.Properties.Resources.information;
            this.documentsMedataToolStripMenuItem.Name = "documentsMedataToolStripMenuItem";
            resources.ApplyResources(this.documentsMedataToolStripMenuItem, "documentsMedataToolStripMenuItem");
            this.documentsMedataToolStripMenuItem.Click += new System.EventHandler(this.documentsMetadataToolStripMenuItem_Click);
            // 
            // removeToolStripMenuItem
            // 
            this.removeToolStripMenuItem.Image = global::FreePDFMetadataEditor.Properties.Resources.delete;
            this.removeToolStripMenuItem.Name = "removeToolStripMenuItem";
            resources.ApplyResources(this.removeToolStripMenuItem, "removeToolStripMenuItem");
            this.removeToolStripMenuItem.Click += new System.EventHandler(this.btnRemoveFile_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerSupportsCancellation = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            // 
            // btnCustomDelete
            // 
            resources.ApplyResources(this.btnCustomDelete, "btnCustomDelete");
            this.btnCustomDelete.Image = global::FreePDFMetadataEditor.Properties.Resources.delete;
            this.btnCustomDelete.Name = "btnCustomDelete";
            this.toolTip1.SetToolTip(this.btnCustomDelete, resources.GetString("btnCustomDelete.ToolTip"));
            this.btnCustomDelete.UseVisualStyleBackColor = true;
            this.btnCustomDelete.Click += new System.EventHandler(this.btnCustomDelete_Click);
            // 
            // btnCustomAdd
            // 
            resources.ApplyResources(this.btnCustomAdd, "btnCustomAdd");
            this.btnCustomAdd.Image = global::FreePDFMetadataEditor.Properties.Resources.add;
            this.btnCustomAdd.Name = "btnCustomAdd";
            this.toolTip1.SetToolTip(this.btnCustomAdd, resources.GetString("btnCustomAdd.ToolTip"));
            this.btnCustomAdd.UseVisualStyleBackColor = true;
            this.btnCustomAdd.Click += new System.EventHandler(this.btnCustomAdd_Click);
            // 
            // btnChangeFolder
            // 
            resources.ApplyResources(this.btnChangeFolder, "btnChangeFolder");
            this.btnChangeFolder.Name = "btnChangeFolder";
            this.toolTip1.SetToolTip(this.btnChangeFolder, resources.GetString("btnChangeFolder.ToolTip"));
            this.btnChangeFolder.UseVisualStyleBackColor = true;
            this.btnChangeFolder.Click += new System.EventHandler(this.btnChangeFolder_Click);
            // 
            // btnOpenFolder
            // 
            resources.ApplyResources(this.btnOpenFolder, "btnOpenFolder");
            this.btnOpenFolder.Image = global::FreePDFMetadataEditor.Properties.Resources.folder1;
            this.btnOpenFolder.Name = "btnOpenFolder";
            this.toolTip1.SetToolTip(this.btnOpenFolder, resources.GetString("btnOpenFolder.ToolTip"));
            this.btnOpenFolder.UseVisualStyleBackColor = true;
            this.btnOpenFolder.Click += new System.EventHandler(this.btnOpenFolder_Click);
            // 
            // btnInsertSpecial
            // 
            resources.ApplyResources(this.btnInsertSpecial, "btnInsertSpecial");
            this.btnInsertSpecial.Image = global::FreePDFMetadataEditor.Properties.Resources.edit;
            this.btnInsertSpecial.Name = "btnInsertSpecial";
            this.toolTip1.SetToolTip(this.btnInsertSpecial, resources.GetString("btnInsertSpecial.ToolTip"));
            this.btnInsertSpecial.UseVisualStyleBackColor = true;
            this.btnInsertSpecial.Click += new System.EventHandler(this.btnInsertSpecial_Click);
            // 
            // btnSpecialTitle
            // 
            resources.ApplyResources(this.btnSpecialTitle, "btnSpecialTitle");
            this.btnSpecialTitle.Image = global::FreePDFMetadataEditor.Properties.Resources.edit;
            this.btnSpecialTitle.Name = "btnSpecialTitle";
            this.toolTip1.SetToolTip(this.btnSpecialTitle, resources.GetString("btnSpecialTitle.ToolTip"));
            this.btnSpecialTitle.UseVisualStyleBackColor = true;
            this.btnSpecialTitle.Click += new System.EventHandler(this.btnSpecialTitle_Click_1);
            // 
            // btnSpecialCreator
            // 
            resources.ApplyResources(this.btnSpecialCreator, "btnSpecialCreator");
            this.btnSpecialCreator.Image = global::FreePDFMetadataEditor.Properties.Resources.edit;
            this.btnSpecialCreator.Name = "btnSpecialCreator";
            this.toolTip1.SetToolTip(this.btnSpecialCreator, resources.GetString("btnSpecialCreator.ToolTip"));
            this.btnSpecialCreator.UseVisualStyleBackColor = true;
            this.btnSpecialCreator.Click += new System.EventHandler(this.btnSpecialTitle_Click_1);
            // 
            // btnSpecialKeywords
            // 
            resources.ApplyResources(this.btnSpecialKeywords, "btnSpecialKeywords");
            this.btnSpecialKeywords.Image = global::FreePDFMetadataEditor.Properties.Resources.edit;
            this.btnSpecialKeywords.Name = "btnSpecialKeywords";
            this.toolTip1.SetToolTip(this.btnSpecialKeywords, resources.GetString("btnSpecialKeywords.ToolTip"));
            this.btnSpecialKeywords.UseVisualStyleBackColor = true;
            this.btnSpecialKeywords.Click += new System.EventHandler(this.btnSpecialTitle_Click_1);
            // 
            // btnSpecialSubject
            // 
            resources.ApplyResources(this.btnSpecialSubject, "btnSpecialSubject");
            this.btnSpecialSubject.Image = global::FreePDFMetadataEditor.Properties.Resources.edit;
            this.btnSpecialSubject.Name = "btnSpecialSubject";
            this.toolTip1.SetToolTip(this.btnSpecialSubject, resources.GetString("btnSpecialSubject.ToolTip"));
            this.btnSpecialSubject.UseVisualStyleBackColor = true;
            this.btnSpecialSubject.Click += new System.EventHandler(this.btnSpecialTitle_Click_1);
            // 
            // btnSpecialAuthor
            // 
            resources.ApplyResources(this.btnSpecialAuthor, "btnSpecialAuthor");
            this.btnSpecialAuthor.Image = global::FreePDFMetadataEditor.Properties.Resources.edit;
            this.btnSpecialAuthor.Name = "btnSpecialAuthor";
            this.toolTip1.SetToolTip(this.btnSpecialAuthor, resources.GetString("btnSpecialAuthor.ToolTip"));
            this.btnSpecialAuthor.UseVisualStyleBackColor = true;
            this.btnSpecialAuthor.Click += new System.EventHandler(this.btnSpecialTitle_Click_1);
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Name = "label1";
            // 
            // grpCustomMetadata
            // 
            resources.ApplyResources(this.grpCustomMetadata, "grpCustomMetadata");
            this.grpCustomMetadata.BackColor = System.Drawing.Color.Transparent;
            this.grpCustomMetadata.Controls.Add(this.btnInsertSpecial);
            this.grpCustomMetadata.Controls.Add(this.dgCustomMetadata);
            this.grpCustomMetadata.Controls.Add(this.btnCustomDelete);
            this.grpCustomMetadata.Controls.Add(this.btnCustomAdd);
            this.grpCustomMetadata.Name = "grpCustomMetadata";
            this.grpCustomMetadata.TabStop = false;
            // 
            // dgCustomMetadata
            // 
            this.dgCustomMetadata.AllowDrop = true;
            this.dgCustomMetadata.AllowUserToDeleteRows = false;
            this.dgCustomMetadata.AllowUserToResizeRows = false;
            resources.ApplyResources(this.dgCustomMetadata, "dgCustomMetadata");
            this.dgCustomMetadata.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(240)))), ((int)(((byte)(227)))));
            this.dgCustomMetadata.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(231)))), ((int)(((byte)(228)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgCustomMetadata.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgCustomMetadata.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgCustomMetadata.GridColor = System.Drawing.Color.Black;
            this.dgCustomMetadata.Name = "dgCustomMetadata";
            this.dgCustomMetadata.RowHeadersVisible = false;
            this.dgCustomMetadata.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.dataGridViewTextBoxColumn1.DataPropertyName = "customname";
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGridViewTextBoxColumn1.DefaultCellStyle = dataGridViewCellStyle1;
            resources.ApplyResources(this.dataGridViewTextBoxColumn1, "dataGridViewTextBoxColumn1");
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "customvalue";
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGridViewTextBoxColumn2.DefaultCellStyle = dataGridViewCellStyle2;
            resources.ApplyResources(this.dataGridViewTextBoxColumn2, "dataGridViewTextBoxColumn2");
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // chkModificationDate
            // 
            resources.ApplyResources(this.chkModificationDate, "chkModificationDate");
            this.chkModificationDate.BackColor = System.Drawing.Color.Transparent;
            this.chkModificationDate.Name = "chkModificationDate";
            this.chkModificationDate.UseVisualStyleBackColor = false;
            this.chkModificationDate.CheckedChanged += new System.EventHandler(this.chkModificationDate_CheckedChanged);
            // 
            // chkCreationDate
            // 
            resources.ApplyResources(this.chkCreationDate, "chkCreationDate");
            this.chkCreationDate.BackColor = System.Drawing.Color.Transparent;
            this.chkCreationDate.Name = "chkCreationDate";
            this.chkCreationDate.UseVisualStyleBackColor = false;
            this.chkCreationDate.CheckedChanged += new System.EventHandler(this.chkCreationDate_CheckedChanged);
            // 
            // chkCreator
            // 
            resources.ApplyResources(this.chkCreator, "chkCreator");
            this.chkCreator.BackColor = System.Drawing.Color.Transparent;
            this.chkCreator.Name = "chkCreator";
            this.chkCreator.UseVisualStyleBackColor = false;
            this.chkCreator.CheckedChanged += new System.EventHandler(this.chkCreator_CheckedChanged);
            // 
            // chkKeywords
            // 
            resources.ApplyResources(this.chkKeywords, "chkKeywords");
            this.chkKeywords.BackColor = System.Drawing.Color.Transparent;
            this.chkKeywords.Name = "chkKeywords";
            this.chkKeywords.UseVisualStyleBackColor = false;
            this.chkKeywords.CheckedChanged += new System.EventHandler(this.chkKeywords_CheckedChanged);
            // 
            // chkSubject
            // 
            resources.ApplyResources(this.chkSubject, "chkSubject");
            this.chkSubject.BackColor = System.Drawing.Color.Transparent;
            this.chkSubject.Name = "chkSubject";
            this.chkSubject.UseVisualStyleBackColor = false;
            this.chkSubject.CheckedChanged += new System.EventHandler(this.chkSubject_CheckedChanged);
            // 
            // chkAuthor
            // 
            resources.ApplyResources(this.chkAuthor, "chkAuthor");
            this.chkAuthor.BackColor = System.Drawing.Color.Transparent;
            this.chkAuthor.Name = "chkAuthor";
            this.chkAuthor.UseVisualStyleBackColor = false;
            this.chkAuthor.CheckedChanged += new System.EventHandler(this.chkAuthor_CheckedChanged);
            // 
            // chkTitle
            // 
            resources.ApplyResources(this.chkTitle, "chkTitle");
            this.chkTitle.BackColor = System.Drawing.Color.Transparent;
            this.chkTitle.Name = "chkTitle";
            this.chkTitle.UseVisualStyleBackColor = false;
            this.chkTitle.CheckedChanged += new System.EventHandler(this.chkTitle_CheckedChanged);
            // 
            // dpModificationDate
            // 
            resources.ApplyResources(this.dpModificationDate, "dpModificationDate");
            this.dpModificationDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dpModificationDate.Name = "dpModificationDate";
            // 
            // dpCreationDate
            // 
            resources.ApplyResources(this.dpCreationDate, "dpCreationDate");
            this.dpCreationDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dpCreationDate.Name = "dpCreationDate";
            // 
            // txtCreator
            // 
            resources.ApplyResources(this.txtCreator, "txtCreator");
            this.txtCreator.Name = "txtCreator";
            // 
            // txtKeywords
            // 
            resources.ApplyResources(this.txtKeywords, "txtKeywords");
            this.txtKeywords.Name = "txtKeywords";
            // 
            // txtSubject
            // 
            resources.ApplyResources(this.txtSubject, "txtSubject");
            this.txtSubject.Name = "txtSubject";
            // 
            // txtAuthor
            // 
            resources.ApplyResources(this.txtAuthor, "txtAuthor");
            this.txtAuthor.Name = "txtAuthor";
            // 
            // txtTitle
            // 
            resources.ApplyResources(this.txtTitle, "txtTitle");
            this.txtTitle.Name = "txtTitle";
            // 
            // toolStrip1
            // 
            resources.ApplyResources(this.toolStrip1, "toolStrip1");
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbAddFile,
            this.tsbRemove,
            this.tsbAddFolder,
            this.tsbImportList,
            this.toolStripSeparator2,
            this.tsbDocumetMetadata,
            this.toolStripSeparator1,
            this.tsbSetMetadata});
            this.toolStrip1.Name = "toolStrip1";
            // 
            // tsbAddFile
            // 
            resources.ApplyResources(this.tsbAddFile, "tsbAddFile");
            this.tsbAddFile.Image = global::FreePDFMetadataEditor.Properties.Resources.add2;
            this.tsbAddFile.Name = "tsbAddFile";
            this.tsbAddFile.Click += new System.EventHandler(this.btnAddFiles_Click);
            // 
            // tsbRemove
            // 
            resources.ApplyResources(this.tsbRemove, "tsbRemove");
            this.tsbRemove.Image = global::FreePDFMetadataEditor.Properties.Resources.delete1;
            this.tsbRemove.Name = "tsbRemove";
            this.tsbRemove.Click += new System.EventHandler(this.btnRemoveFile_Click);
            // 
            // tsbAddFolder
            // 
            resources.ApplyResources(this.tsbAddFolder, "tsbAddFolder");
            this.tsbAddFolder.Image = global::FreePDFMetadataEditor.Properties.Resources.folder_add1;
            this.tsbAddFolder.Name = "tsbAddFolder";
            this.tsbAddFolder.Click += new System.EventHandler(this.btnAddFolder_Click);
            // 
            // tsbImportList
            // 
            resources.ApplyResources(this.tsbImportList, "tsbImportList");
            this.tsbImportList.Image = global::FreePDFMetadataEditor.Properties.Resources.import1;
            this.tsbImportList.Name = "tsbImportList";
            this.tsbImportList.Click += new System.EventHandler(this.tsdbImportList_ButtonClick);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            resources.ApplyResources(this.toolStripSeparator2, "toolStripSeparator2");
            // 
            // tsbDocumetMetadata
            // 
            resources.ApplyResources(this.tsbDocumetMetadata, "tsbDocumetMetadata");
            this.tsbDocumetMetadata.Image = global::FreePDFMetadataEditor.Properties.Resources.information1;
            this.tsbDocumetMetadata.Name = "tsbDocumetMetadata";
            this.tsbDocumetMetadata.Click += new System.EventHandler(this.tsbDocumetMetadata_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            resources.ApplyResources(this.toolStripSeparator1, "toolStripSeparator1");
            // 
            // tsbSetMetadata
            // 
            resources.ApplyResources(this.tsbSetMetadata, "tsbSetMetadata");
            this.tsbSetMetadata.ForeColor = System.Drawing.Color.DarkBlue;
            this.tsbSetMetadata.Image = global::FreePDFMetadataEditor.Properties.Resources.flash;
            this.tsbSetMetadata.Name = "tsbSetMetadata";
            this.tsbSetMetadata.Click += new System.EventHandler(this.btnSetMetadata_Click);
            // 
            // dgFiles
            // 
            this.dgFiles.AllowDrop = true;
            this.dgFiles.AllowUserToAddRows = false;
            this.dgFiles.AllowUserToDeleteRows = false;
            this.dgFiles.AllowUserToResizeRows = false;
            resources.ApplyResources(this.dgFiles, "dgFiles");
            this.dgFiles.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(240)))), ((int)(((byte)(227)))));
            this.dgFiles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgFiles.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colFilename,
            this.colUserPassword,
            this.colSize,
            this.colFileDate,
            this.colFullFilePath});
            this.dgFiles.ContextMenuStrip = this.contextMenuStrip1;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(231)))), ((int)(((byte)(228)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgFiles.DefaultCellStyle = dataGridViewCellStyle5;
            this.dgFiles.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgFiles.GridColor = System.Drawing.Color.Black;
            this.dgFiles.Name = "dgFiles";
            this.dgFiles.RowHeadersVisible = false;
            this.dgFiles.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgFiles.DragDrop += new System.Windows.Forms.DragEventHandler(this.dgFiles_DragDrop);
            this.dgFiles.DragEnter += new System.Windows.Forms.DragEventHandler(this.dgFiles_DragEnter);
            this.dgFiles.DragOver += new System.Windows.Forms.DragEventHandler(this.dgFiles_DragOver);
            // 
            // colFilename
            // 
            this.colFilename.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colFilename.DataPropertyName = "filename";
            resources.ApplyResources(this.colFilename, "colFilename");
            this.colFilename.Name = "colFilename";
            this.colFilename.ReadOnly = true;
            // 
            // colUserPassword
            // 
            this.colUserPassword.DataPropertyName = "userpassword";
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            this.colUserPassword.DefaultCellStyle = dataGridViewCellStyle4;
            resources.ApplyResources(this.colUserPassword, "colUserPassword");
            this.colUserPassword.Name = "colUserPassword";
            // 
            // colSize
            // 
            this.colSize.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colSize.DataPropertyName = "sizekb";
            resources.ApplyResources(this.colSize, "colSize");
            this.colSize.Name = "colSize";
            this.colSize.ReadOnly = true;
            // 
            // colFileDate
            // 
            this.colFileDate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colFileDate.DataPropertyName = "filedate";
            resources.ApplyResources(this.colFileDate, "colFileDate");
            this.colFileDate.Name = "colFileDate";
            this.colFileDate.ReadOnly = true;
            // 
            // colFullFilePath
            // 
            this.colFullFilePath.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colFullFilePath.DataPropertyName = "fullfilepath";
            resources.ApplyResources(this.colFullFilePath, "colFullFilePath");
            this.colFullFilePath.Name = "colFullFilePath";
            this.colFullFilePath.ReadOnly = true;
            // 
            // groupBox1
            // 
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.chkKeepBackup);
            this.groupBox1.Controls.Add(this.cmbOutputDir);
            this.groupBox1.Controls.Add(this.btnChangeFolder);
            this.groupBox1.Controls.Add(this.btnOpenFolder);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            // 
            // chkKeepBackup
            // 
            resources.ApplyResources(this.chkKeepBackup, "chkKeepBackup");
            this.chkKeepBackup.Name = "chkKeepBackup";
            this.chkKeepBackup.UseVisualStyleBackColor = true;
            // 
            // cmbOutputDir
            // 
            resources.ApplyResources(this.cmbOutputDir, "cmbOutputDir");
            this.cmbOutputDir.FormattingEnabled = true;
            this.cmbOutputDir.Name = "cmbOutputDir";
            this.cmbOutputDir.SelectedIndexChanged += new System.EventHandler(this.cmbOutputDir_SelectedIndexChanged);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.optionsToolStripMenuItem,
            this.toolsToolStripMenuItem,
            this.downloadToolStripMenuItem,
            this.languageToolStripMenuItem,
            this.helpToolStripMenuItem});
            resources.ApplyResources(this.menuStrip1, "menuStrip1");
            this.menuStrip1.Name = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addFilesToolStripMenuItem,
            this.addFolderToolStripMenuItem,
            this.toolStripMenuItem3,
            this.importListFormTextFileToolStripMenuItem,
            this.importListFromExcelFileToolStripMenuItem,
            this.enterFileListToolStripMenuItem,
            this.saveCurrentFileListToolStripMenuItem,
            this.toolStripMenuItem4,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            resources.ApplyResources(this.fileToolStripMenuItem, "fileToolStripMenuItem");
            // 
            // addFilesToolStripMenuItem
            // 
            this.addFilesToolStripMenuItem.Image = global::FreePDFMetadataEditor.Properties.Resources.add;
            this.addFilesToolStripMenuItem.Name = "addFilesToolStripMenuItem";
            resources.ApplyResources(this.addFilesToolStripMenuItem, "addFilesToolStripMenuItem");
            this.addFilesToolStripMenuItem.Click += new System.EventHandler(this.btnAddFiles_Click);
            // 
            // addFolderToolStripMenuItem
            // 
            this.addFolderToolStripMenuItem.Image = global::FreePDFMetadataEditor.Properties.Resources.folder_add;
            this.addFolderToolStripMenuItem.Name = "addFolderToolStripMenuItem";
            resources.ApplyResources(this.addFolderToolStripMenuItem, "addFolderToolStripMenuItem");
            this.addFolderToolStripMenuItem.Click += new System.EventHandler(this.btnAddFolder_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            resources.ApplyResources(this.toolStripMenuItem3, "toolStripMenuItem3");
            // 
            // importListFormTextFileToolStripMenuItem
            // 
            this.importListFormTextFileToolStripMenuItem.Image = global::FreePDFMetadataEditor.Properties.Resources.import1;
            this.importListFormTextFileToolStripMenuItem.Name = "importListFormTextFileToolStripMenuItem";
            resources.ApplyResources(this.importListFormTextFileToolStripMenuItem, "importListFormTextFileToolStripMenuItem");
            this.importListFormTextFileToolStripMenuItem.Click += new System.EventHandler(this.tsdbImportList_ButtonClick);
            // 
            // importListFromExcelFileToolStripMenuItem
            // 
            this.importListFromExcelFileToolStripMenuItem.Image = global::FreePDFMetadataEditor.Properties.Resources.import1;
            this.importListFromExcelFileToolStripMenuItem.Name = "importListFromExcelFileToolStripMenuItem";
            resources.ApplyResources(this.importListFromExcelFileToolStripMenuItem, "importListFromExcelFileToolStripMenuItem");
            this.importListFromExcelFileToolStripMenuItem.Click += new System.EventHandler(this.importListFromExcelFileToolStripMenuItem_Click);
            // 
            // enterFileListToolStripMenuItem
            // 
            this.enterFileListToolStripMenuItem.Name = "enterFileListToolStripMenuItem";
            resources.ApplyResources(this.enterFileListToolStripMenuItem, "enterFileListToolStripMenuItem");
            this.enterFileListToolStripMenuItem.Click += new System.EventHandler(this.enterFileListToolStripMenuItem_Click);
            // 
            // saveCurrentFileListToolStripMenuItem
            // 
            this.saveCurrentFileListToolStripMenuItem.Name = "saveCurrentFileListToolStripMenuItem";
            resources.ApplyResources(this.saveCurrentFileListToolStripMenuItem, "saveCurrentFileListToolStripMenuItem");
            this.saveCurrentFileListToolStripMenuItem.Click += new System.EventHandler(this.saveCurrentFileListToolStripMenuItem_Click);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            resources.ApplyResources(this.toolStripMenuItem4, "toolStripMenuItem4");
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Image = global::FreePDFMetadataEditor.Properties.Resources.exit;
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            resources.ApplyResources(this.exitToolStripMenuItem, "exitToolStripMenuItem");
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.removeToolStripMenuItem1,
            this.clearToolStripMenuItem,
            this.toolStripMenuItem2,
            this.selectAllToolStripMenuItem,
            this.selectNoneToolStripMenuItem,
            this.invertSelectionToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            resources.ApplyResources(this.editToolStripMenuItem, "editToolStripMenuItem");
            // 
            // removeToolStripMenuItem1
            // 
            this.removeToolStripMenuItem1.Image = global::FreePDFMetadataEditor.Properties.Resources.delete;
            this.removeToolStripMenuItem1.Name = "removeToolStripMenuItem1";
            resources.ApplyResources(this.removeToolStripMenuItem1, "removeToolStripMenuItem1");
            this.removeToolStripMenuItem1.Click += new System.EventHandler(this.btnRemoveFile_Click);
            // 
            // clearToolStripMenuItem
            // 
            this.clearToolStripMenuItem.Image = global::FreePDFMetadataEditor.Properties.Resources.brush2;
            this.clearToolStripMenuItem.Name = "clearToolStripMenuItem";
            resources.ApplyResources(this.clearToolStripMenuItem, "clearToolStripMenuItem");
            this.clearToolStripMenuItem.Click += new System.EventHandler(this.btnClearMerge_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            resources.ApplyResources(this.toolStripMenuItem2, "toolStripMenuItem2");
            // 
            // selectAllToolStripMenuItem
            // 
            this.selectAllToolStripMenuItem.Name = "selectAllToolStripMenuItem";
            resources.ApplyResources(this.selectAllToolStripMenuItem, "selectAllToolStripMenuItem");
            this.selectAllToolStripMenuItem.Click += new System.EventHandler(this.selectAllToolStripMenuItem_Click);
            // 
            // selectNoneToolStripMenuItem
            // 
            this.selectNoneToolStripMenuItem.Name = "selectNoneToolStripMenuItem";
            resources.ApplyResources(this.selectNoneToolStripMenuItem, "selectNoneToolStripMenuItem");
            this.selectNoneToolStripMenuItem.Click += new System.EventHandler(this.selectNoneToolStripMenuItem_Click);
            // 
            // invertSelectionToolStripMenuItem
            // 
            this.invertSelectionToolStripMenuItem.Name = "invertSelectionToolStripMenuItem";
            resources.ApplyResources(this.invertSelectionToolStripMenuItem, "invertSelectionToolStripMenuItem");
            this.invertSelectionToolStripMenuItem.Click += new System.EventHandler(this.invertSelectionToolStripMenuItem_Click);
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.keepFolderStructureToolStripMenuItem,
            this.exploreOutputFolderWhenDoneToolStripMenuItem,
            this.keepCreationDateToolStripMenuItem,
            this.keepLastModificationDateToolStripMenuItem,
            this.showMessageOnSucessToolStripMenuItem});
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            resources.ApplyResources(this.optionsToolStripMenuItem, "optionsToolStripMenuItem");
            // 
            // keepFolderStructureToolStripMenuItem
            // 
            this.keepFolderStructureToolStripMenuItem.Name = "keepFolderStructureToolStripMenuItem";
            resources.ApplyResources(this.keepFolderStructureToolStripMenuItem, "keepFolderStructureToolStripMenuItem");
            this.keepFolderStructureToolStripMenuItem.Click += new System.EventHandler(this.keepFolderStructureToolStripMenuItem_Click);
            // 
            // exploreOutputFolderWhenDoneToolStripMenuItem
            // 
            this.exploreOutputFolderWhenDoneToolStripMenuItem.CheckOnClick = true;
            this.exploreOutputFolderWhenDoneToolStripMenuItem.Name = "exploreOutputFolderWhenDoneToolStripMenuItem";
            resources.ApplyResources(this.exploreOutputFolderWhenDoneToolStripMenuItem, "exploreOutputFolderWhenDoneToolStripMenuItem");
            // 
            // keepCreationDateToolStripMenuItem
            // 
            this.keepCreationDateToolStripMenuItem.CheckOnClick = true;
            this.keepCreationDateToolStripMenuItem.Name = "keepCreationDateToolStripMenuItem";
            resources.ApplyResources(this.keepCreationDateToolStripMenuItem, "keepCreationDateToolStripMenuItem");
            // 
            // keepLastModificationDateToolStripMenuItem
            // 
            this.keepLastModificationDateToolStripMenuItem.CheckOnClick = true;
            this.keepLastModificationDateToolStripMenuItem.Name = "keepLastModificationDateToolStripMenuItem";
            resources.ApplyResources(this.keepLastModificationDateToolStripMenuItem, "keepLastModificationDateToolStripMenuItem");
            // 
            // showMessageOnSucessToolStripMenuItem
            // 
            this.showMessageOnSucessToolStripMenuItem.CheckOnClick = true;
            this.showMessageOnSucessToolStripMenuItem.Name = "showMessageOnSucessToolStripMenuItem";
            resources.ApplyResources(this.showMessageOnSucessToolStripMenuItem, "showMessageOnSucessToolStripMenuItem");
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editMetadataToolStripMenuItem});
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            resources.ApplyResources(this.toolsToolStripMenuItem, "toolsToolStripMenuItem");
            // 
            // editMetadataToolStripMenuItem
            // 
            this.editMetadataToolStripMenuItem.Image = global::FreePDFMetadataEditor.Properties.Resources.flash;
            this.editMetadataToolStripMenuItem.Name = "editMetadataToolStripMenuItem";
            resources.ApplyResources(this.editMetadataToolStripMenuItem, "editMetadataToolStripMenuItem");
            this.editMetadataToolStripMenuItem.Click += new System.EventHandler(this.btnSetMetadata_Click);
            // 
            // downloadToolStripMenuItem
            // 
            this.downloadToolStripMenuItem.Name = "downloadToolStripMenuItem";
            resources.ApplyResources(this.downloadToolStripMenuItem, "downloadToolStripMenuItem");
            // 
            // languageToolStripMenuItem
            // 
            this.languageToolStripMenuItem.Name = "languageToolStripMenuItem";
            resources.ApplyResources(this.languageToolStripMenuItem, "languageToolStripMenuItem");
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.helpGuideToolStripMenuItem,
            this.tryOnlineVersionAtOnlinepdfappscomToolStripMenuItem,
            this.commandLineArgumentsToolStripMenuItem,
            this.checkForNewVersionEachWeekToolStripMenuItem,
            this.tiHelpFeedback,
            this.toolStripMenuItem1,
            this.donateViaPaypalToolStripMenuItem,
            this.followUsOnTwitterToolStripMenuItem,
            this.visit4dotsSoftwareWebsiteToolStripMenuItem,
            this.youtubeChannelToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            resources.ApplyResources(this.helpToolStripMenuItem, "helpToolStripMenuItem");
            // 
            // helpGuideToolStripMenuItem
            // 
            this.helpGuideToolStripMenuItem.Image = global::FreePDFMetadataEditor.Properties.Resources.help2;
            this.helpGuideToolStripMenuItem.Name = "helpGuideToolStripMenuItem";
            resources.ApplyResources(this.helpGuideToolStripMenuItem, "helpGuideToolStripMenuItem");
            this.helpGuideToolStripMenuItem.Click += new System.EventHandler(this.helpGuideToolStripMenuItem_Click);
            // 
            // tryOnlineVersionAtOnlinepdfappscomToolStripMenuItem
            // 
            resources.ApplyResources(this.tryOnlineVersionAtOnlinepdfappscomToolStripMenuItem, "tryOnlineVersionAtOnlinepdfappscomToolStripMenuItem");
            this.tryOnlineVersionAtOnlinepdfappscomToolStripMenuItem.Name = "tryOnlineVersionAtOnlinepdfappscomToolStripMenuItem";
            this.tryOnlineVersionAtOnlinepdfappscomToolStripMenuItem.Click += new System.EventHandler(this.tryOnlineVersionAtOnlinepdfappscomToolStripMenuItem_Click);
            // 
            // commandLineArgumentsToolStripMenuItem
            // 
            this.commandLineArgumentsToolStripMenuItem.Name = "commandLineArgumentsToolStripMenuItem";
            resources.ApplyResources(this.commandLineArgumentsToolStripMenuItem, "commandLineArgumentsToolStripMenuItem");
            this.commandLineArgumentsToolStripMenuItem.Click += new System.EventHandler(this.commandLineArgumentsToolStripMenuItem_Click);
            // 
            // checkForNewVersionEachWeekToolStripMenuItem
            // 
            this.checkForNewVersionEachWeekToolStripMenuItem.CheckOnClick = true;
            this.checkForNewVersionEachWeekToolStripMenuItem.Name = "checkForNewVersionEachWeekToolStripMenuItem";
            resources.ApplyResources(this.checkForNewVersionEachWeekToolStripMenuItem, "checkForNewVersionEachWeekToolStripMenuItem");
            // 
            // tiHelpFeedback
            // 
            this.tiHelpFeedback.Image = global::FreePDFMetadataEditor.Properties.Resources.edit;
            this.tiHelpFeedback.Name = "tiHelpFeedback";
            resources.ApplyResources(this.tiHelpFeedback, "tiHelpFeedback");
            this.tiHelpFeedback.Click += new System.EventHandler(this.tiHelpFeedback_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            resources.ApplyResources(this.toolStripMenuItem1, "toolStripMenuItem1");
            // 
            // donateViaPaypalToolStripMenuItem
            // 
            this.donateViaPaypalToolStripMenuItem.BackColor = System.Drawing.Color.Gold;
            resources.ApplyResources(this.donateViaPaypalToolStripMenuItem, "donateViaPaypalToolStripMenuItem");
            this.donateViaPaypalToolStripMenuItem.Name = "donateViaPaypalToolStripMenuItem";
            this.donateViaPaypalToolStripMenuItem.Click += new System.EventHandler(this.donateViaPaypalToolStripMenuItem_Click);
            // 
            // followUsOnTwitterToolStripMenuItem
            // 
            this.followUsOnTwitterToolStripMenuItem.Image = global::FreePDFMetadataEditor.Properties.Resources.social_twitter_box_white_icon_24;
            this.followUsOnTwitterToolStripMenuItem.Name = "followUsOnTwitterToolStripMenuItem";
            resources.ApplyResources(this.followUsOnTwitterToolStripMenuItem, "followUsOnTwitterToolStripMenuItem");
            this.followUsOnTwitterToolStripMenuItem.Click += new System.EventHandler(this.followUsOnTwitterToolStripMenuItem_Click);
            // 
            // visit4dotsSoftwareWebsiteToolStripMenuItem
            // 
            this.visit4dotsSoftwareWebsiteToolStripMenuItem.Name = "visit4dotsSoftwareWebsiteToolStripMenuItem";
            resources.ApplyResources(this.visit4dotsSoftwareWebsiteToolStripMenuItem, "visit4dotsSoftwareWebsiteToolStripMenuItem");
            this.visit4dotsSoftwareWebsiteToolStripMenuItem.Click += new System.EventHandler(this.visit4dotsSoftwareWebsiteToolStripMenuItem_Click);
            // 
            // youtubeChannelToolStripMenuItem
            // 
            this.youtubeChannelToolStripMenuItem.Image = global::FreePDFMetadataEditor.Properties.Resources.youtube_32;
            this.youtubeChannelToolStripMenuItem.Name = "youtubeChannelToolStripMenuItem";
            resources.ApplyResources(this.youtubeChannelToolStripMenuItem, "youtubeChannelToolStripMenuItem");
            this.youtubeChannelToolStripMenuItem.Click += new System.EventHandler(this.youtubeChannelToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Image = global::FreePDFMetadataEditor.Properties.Resources.about;
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            resources.ApplyResources(this.aboutToolStripMenuItem, "aboutToolStripMenuItem");
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // chkClearMetadata
            // 
            resources.ApplyResources(this.chkClearMetadata, "chkClearMetadata");
            this.chkClearMetadata.BackColor = System.Drawing.Color.Transparent;
            this.chkClearMetadata.Name = "chkClearMetadata";
            this.chkClearMetadata.UseVisualStyleBackColor = false;
            // 
            // frmMain
            // 
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.chkClearMetadata);
            this.Controls.Add(this.btnSpecialAuthor);
            this.Controls.Add(this.btnSpecialSubject);
            this.Controls.Add(this.btnSpecialKeywords);
            this.Controls.Add(this.btnSpecialCreator);
            this.Controls.Add(this.btnSpecialTitle);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.grpCustomMetadata);
            this.Controls.Add(this.chkModificationDate);
            this.Controls.Add(this.chkCreationDate);
            this.Controls.Add(this.chkCreator);
            this.Controls.Add(this.chkKeywords);
            this.Controls.Add(this.chkSubject);
            this.Controls.Add(this.chkAuthor);
            this.Controls.Add(this.chkTitle);
            this.Controls.Add(this.dpModificationDate);
            this.Controls.Add(this.dpCreationDate);
            this.Controls.Add(this.txtCreator);
            this.Controls.Add(this.txtKeywords);
            this.Controls.Add(this.txtSubject);
            this.Controls.Add(this.txtAuthor);
            this.Controls.Add(this.txtTitle);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.dgFiles);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmMain";
            this.ShowInTaskbar = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.Resize += new System.EventHandler(this.frmMain_Resize);
            this.contextMenuStrip1.ResumeLayout(false);
            this.grpCustomMetadata.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgCustomMetadata)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgFiles)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpGuideToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.ToolStripMenuItem tiHelpFeedback;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem exploreToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.DataGridView dgFiles;
        private System.Windows.Forms.ToolStripMenuItem downloadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem visit4dotsSoftwareWebsiteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem languageToolStripMenuItem;
        private System.Windows.Forms.Button btnOpenFolder;
        private System.Windows.Forms.Button btnChangeFolder;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog2;
        private System.Windows.Forms.GroupBox groupBox1;
        public System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsbAddFile;
        private System.Windows.Forms.ToolStripButton tsbAddFolder;
        private System.Windows.Forms.ToolStripButton tsbRemove;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton tsbSetMetadata;
        private System.Windows.Forms.ToolTip toolTip1;
        public System.Windows.Forms.ComboBox cmbOutputDir;
        public System.Windows.Forms.CheckBox chkModificationDate;
        public System.Windows.Forms.CheckBox chkCreationDate;
        public System.Windows.Forms.CheckBox chkCreator;
        public System.Windows.Forms.CheckBox chkKeywords;
        public System.Windows.Forms.CheckBox chkSubject;
        public System.Windows.Forms.CheckBox chkAuthor;
        public System.Windows.Forms.CheckBox chkTitle;
        public System.Windows.Forms.DateTimePicker dpModificationDate;
        public System.Windows.Forms.DateTimePicker dpCreationDate;
        public System.Windows.Forms.TextBox txtCreator;
        public System.Windows.Forms.TextBox txtKeywords;
        public System.Windows.Forms.TextBox txtSubject;
        public System.Windows.Forms.TextBox txtAuthor;
        public System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.GroupBox grpCustomMetadata;
        private System.Windows.Forms.DataGridView dgCustomMetadata;
        private System.Windows.Forms.Button btnCustomDelete;
        private System.Windows.Forms.Button btnCustomAdd;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFilename;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUserPassword;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSize;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFileDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFullFilePath;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripMenuItem removeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem followUsOnTwitterToolStripMenuItem;
        private System.Windows.Forms.Button btnInsertSpecial;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        public System.Windows.Forms.CheckBox chkKeepBackup;
        private System.Windows.Forms.ToolStripMenuItem documentsMedataToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton tsbDocumetMetadata;
        private System.Windows.Forms.Button btnSpecialTitle;
        private System.Windows.Forms.Button btnSpecialCreator;
        private System.Windows.Forms.Button btnSpecialKeywords;
        private System.Windows.Forms.Button btnSpecialSubject;
        private System.Windows.Forms.Button btnSpecialAuthor;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem keepFolderStructureToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton tsbImportList;
        public System.Windows.Forms.CheckBox chkClearMetadata;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removeToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem clearToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem selectAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem selectNoneToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem invertSelectionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addFilesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addFolderToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem importListFormTextFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importListFromExcelFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem enterFileListToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveCurrentFileListToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem donateViaPaypalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem youtubeChannelToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem checkForNewVersionEachWeekToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exploreOutputFolderWhenDoneToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem keepCreationDateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem keepLastModificationDateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showMessageOnSucessToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editMetadataToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tryOnlineVersionAtOnlinepdfappscomToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem commandLineArgumentsToolStripMenuItem;
    }
}
