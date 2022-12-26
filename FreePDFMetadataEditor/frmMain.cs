using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
/*
using iTextSharp;
using iTextSharp.text.pdf;
using iTextSharp.text;
*/
using System.IO;
using Microsoft.Win32;
using System.Diagnostics;

namespace FreePDFMetadataEditor
{
    public partial class frmMain : CustomForm
    {
        public static frmMain Instance = null;

        public DataTable dt = new DataTable("pdfs");
        public DataTable dtcustom = new DataTable("custom");

        public frmMain()
        {
            InitializeComponent();
            
            Instance = this;

            if (Module.IsCommandLine)
            {
                this.Visible = false;
                this.ShowInTaskbar = false;
            }
            else
            {
                if (Properties.Settings.Default.ShowPromotion)
                {
                    frmPromotion fp = new frmPromotion();
                    fp.Show(this);
                }
            }
            this.Icon = Properties.Resources.pdf_properties_changer;
        }


        private void button1_Click(object sender, EventArgs e)
        {
            //iTextSharp.text.Document doc = new iTextSharp.text.Document();
            /*
            PdfReader reader = new PdfReader(@"c:\4\head first ajax.pdf");

            Document doc = new Document(reader.GetPageSizeWithRotation(1));

            PdfWriter writer = PdfWriter.GetInstance(doc, new FileStream(@"c:\4\test.pdf",FileMode.Create));
            doc.Open();
            PdfContentByte cb = writer.DirectContent;
            */
            /*
            for (int k = 1; k <= reader.NumberOfPages; k++)
            {
                doc.SetPageSize(reader.GetPageSizeWithRotation(i));
                PdfDictionary pdfdict=pdfReader.GetPageN(k);
                PdfImportedPage imp=pdfWriter.GetImportedPage(pdfReader, k);
                pdfWriter.Add(imp);

            }
            */
        }

        private void AddVisual(string[] argsvisual)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                //Module.ShowMessage("Is From Windows Explorer");                                

                for (int k = 0; k < argsvisual.Length; k++)
                {
                    if (System.IO.File.Exists(argsvisual[k]))
                    {
                        AddFile(argsvisual[k]);

                    }
                    else if (System.IO.Directory.Exists(argsvisual[k]))
                    {
                        AddFolder(argsvisual[k]);
                    }
                }
            }
            finally
            {
                this.Cursor = null;
            }
        }

        private void SetupOutputFolders()
        {
            cmbOutputDir.Items.Add(TranslateHelper.Translate("Same Folder of PDF Document"));
            cmbOutputDir.Items.Add(TranslateHelper.Translate("Overwrite PDF Document"));
            cmbOutputDir.Items.Add(TranslateHelper.Translate("Subfolder of PDF Document"));
            cmbOutputDir.Items.Add(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments).ToString());
            cmbOutputDir.Items.Add("---------------------------------------------------------------------------------------");

            OutputFolderHelper.LoadOutputFolders();
            cmbOutputDir.SelectedIndex = Properties.Settings.Default.OutputFolderIndex;

            if (cmbOutputDir.SelectedIndex == 1)
            {
                chkKeepBackup.Visible = true;
            }

            chkKeepBackup.Checked = Properties.Settings.Default.KeepBackup;

        }
        private void SetupOnLoad()
        {
            dgFiles.AutoGenerateColumns = false;

            dgFiles.DataSource = dt;
            dgCustomMetadata.DataSource = dtcustom;

            this.Icon = Properties.Resources.pdf_properties_changer;

            this.Text = Module.ApplicationTitle;
            //this.Width = System.Windows.Forms.Screen.PrimaryScreen.WorkingArea.Width;
            //this.Left = 0;
            AddLanguageMenuItems();

            DownloadSuggestionsHelper ds = new DownloadSuggestionsHelper();
            ds.SetupDownloadMenuItems(downloadToolStripMenuItem);

            AdjustSizeLocation();

            SetupOutputFolders();

            keepFolderStructureToolStripMenuItem.Checked = Properties.Settings.Default.KeepFolderStructure;

            chkClearMetadata.Checked = Properties.Settings.Default.ClearMetadata;

            checkForNewVersionEachWeekToolStripMenuItem.Checked = Properties.Settings.Default.CheckWeek;

            //=========

            exploreOutputFolderWhenDoneToolStripMenuItem.Checked =
                Properties.Settings.Default.ExploreOutputFolder;

            keepCreationDateToolStripMenuItem.Checked =
                Properties.Settings.Default.KeepCreationDate;

            keepLastModificationDateToolStripMenuItem.Checked =
                Properties.Settings.Default.KeepLastModificationDate;

            showMessageOnSucessToolStripMenuItem.Checked =
                Properties.Settings.Default.ShowMessageOnSucess;
        }

        private void AdjustSizeLocation()
        {
            if (Properties.Settings.Default.Maximized)
            {
                this.WindowState = FormWindowState.Maximized;
            }
            else
            {

                if (Properties.Settings.Default.Width == -1)
                {
                    this.CenterToScreen();
                    return;
                }
                else
                {
                    this.Width = Properties.Settings.Default.Width;
                }
                if (Properties.Settings.Default.Height != 0)
                {
                    this.Height = Properties.Settings.Default.Height;
                }

                if (Properties.Settings.Default.Left != -1)
                {
                    this.Left = Properties.Settings.Default.Left;
                }

                if (Properties.Settings.Default.Top != -1)
                {
                    this.Top = Properties.Settings.Default.Top;
                }
                
                if (this.Top < 0)
                {
                    this.Top = 0;
                }
                if (this.Left < 0)
                {
                    this.Left = 0;
                }
            }

        }

        private void SaveSizeLocation()
        {
            Properties.Settings.Default.Maximized = (this.WindowState == FormWindowState.Maximized);
            if (this.WindowState != FormWindowState.Minimized){
                Properties.Settings.Default.Left = this.Left;
                Properties.Settings.Default.Top = this.Top;
            }
            Properties.Settings.Default.Width = this.Width;
            Properties.Settings.Default.Height = this.Height;
            Properties.Settings.Default.Save();

        }

        private void frmMain_Load(object sender, EventArgs e)
        {           
            dt.Columns.Add("filename");            
            dt.Columns.Add("sizekb");
            dt.Columns.Add("fullfilepath");
            dt.Columns.Add("filedate");
            dt.Columns.Add("userpassword");
            dt.Columns.Add("rootfolder");           

            dtcustom.Columns.Add("customname");
            dtcustom.Columns.Add("customvalue");

            //dtcustom.Rows.Add(dtcustom.NewRow());

            SetupOnLoad();

            if (Properties.Settings.Default.CheckWeek)
            {
                UpdateHelper.InitializeCheckVersionWeek();
            }

            if (ArgsHelper.FromWindowsExplorer || (Module.args!=null && Module.args.Length>0 && (System.IO.File.Exists(Module.args[0]) || System.IO.Directory.Exists(Module.args[0]))))
            {
                AddVisual(Module.args);
            }

            chkTitle.Checked = Properties.Settings.Default.CTitle;
            chkAuthor.Checked = Properties.Settings.Default.CAuhor;
            chkCreationDate.Checked = Properties.Settings.Default.CCreationDate;
            chkCreator.Checked = Properties.Settings.Default.CCreator;
            chkKeywords.Checked = Properties.Settings.Default.CKeywords;
            chkModificationDate.Checked = Properties.Settings.Default.CModificationDate;
            chkSubject.Checked = Properties.Settings.Default.CSubject;

            txtTitle.Text = Properties.Settings.Default.MTitle;
            txtAuthor.Text = Properties.Settings.Default.MAuthor;
            txtCreator.Text = Properties.Settings.Default.MCreator;
            txtKeywords.Text = Properties.Settings.Default.MKeywords;
            txtSubject.Text = Properties.Settings.Default.MSubject;

            if (Properties.Settings.Default.CCreationDate)
            {
                dpCreationDate.Value = Properties.Settings.Default.MCreationDate;
            }

            if (Properties.Settings.Default.CModificationDate)
            {
                dpModificationDate.Value = Properties.Settings.Default.MModificationDate;
            }

            if (chkAuthor.Checked) chkAuthor_CheckedChanged(null, null);
            if (chkCreationDate.Checked) chkCreationDate_CheckedChanged(null, null);
            if (chkCreator.Checked) chkCreator_CheckedChanged(null, null);
            if (chkKeywords.Checked) chkKeywords_CheckedChanged(null, null);
            if (chkModificationDate.Checked) chkModificationDate_CheckedChanged(null, null);
            if (chkSubject.Checked) chkSubject_CheckedChanged(null, null);
            if (chkTitle.Checked) chkTitle_CheckedChanged(null, null);

            string[] cz = Properties.Settings.Default.MCustomMetadata.Split(new string[] { "|||" }, StringSplitOptions.None);

            try
            {
                for (int k = 0; k < cz.Length-1; k += 2)
                {
                    DataRow dr = dtcustom.NewRow();
                    dr["customname"] = cz[k];
                    dr["customvalue"] = cz[k + 1];

                    dtcustom.Rows.Add(dr);
                }
            }
            catch { }
        }

        #region Localization

        private void AddLanguageMenuItems()
        {
            for (int k = 0; k < frmLanguage.LangCodes.Count; k++)
            {
                ToolStripMenuItem ti = new ToolStripMenuItem();
                ti.Text = frmLanguage.LangDesc[k];
                ti.Tag = frmLanguage.LangCodes[k];
                ti.Image = frmLanguage.LangImg[k];

                if (Module.SelectedLanguage == frmLanguage.LangCodes[k])
                {
                    ti.Checked = true;
                }

                ti.Click += new EventHandler(tiLang_Click);
                languageToolStripMenuItem.DropDownItems.Add(ti);
            }
        }

        void tiLang_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem ti = (ToolStripMenuItem)sender;
            string langcode = ti.Tag.ToString();
            ChangeLanguage(langcode);

            for (int k = 0; k < languageToolStripMenuItem.DropDownItems.Count; k++)
            {
                ToolStripMenuItem til = (ToolStripMenuItem)languageToolStripMenuItem.DropDownItems[k];
                if (til == ti)
                {
                    til.Checked = true;
                }
                else
                {
                    til.Checked = false;
                }
            }
        }

        private void ChangeLanguage(string language_code)
        {
            Properties.Settings.Default.Language = language_code;
            Program.SetLanguage();

            bool maximized = (this.WindowState == FormWindowState.Maximized);
            this.WindowState = FormWindowState.Normal;

            RegistryKey key = Registry.CurrentUser;
            RegistryKey key2 = Registry.CurrentUser;

            try
            {
                key = key.OpenSubKey("Software\\4dots Software", true);

                if (key == null)
                {
                    key = Registry.CurrentUser.CreateSubKey("SOFTWARE\\4dots Software");
                }

                key2 = key.OpenSubKey("PDF Metadata Editor", true);

                if (key2 == null)
                {
                    key2 = key.CreateSubKey("PDF Metadata Editor");
                }

                key = key2;

                //key.SetValue("Language", language_code);
                key.SetValue("Menu Item Caption", TranslateHelper.Translate("Change PDF Properties"));
            }
            catch (Exception ex)
            {
                Module.ShowError(ex);
                return;
            }
            finally
            {
                key.Close();
                key2.Close();
            }

            SaveSizeLocation();

            this.Controls.Clear();

            InitializeComponent();

            SetupOnLoad();

            if (maximized)
            {
                this.WindowState = FormWindowState.Maximized;
            }

            this.ResumeLayout(true);                    
                       
            /*
            bool t1e = timer1.Enabled;
            bool t2e = timer2.Enabled;
            bool t3e = timer3.Enabled;
            */            

            /*
            timer1.Enabled = t1e;
            timer2.Enabled = t2e;
            timer3.Enabled = t3e;
            */           
        }

        #endregion
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAbout f = new frmAbout();
            f.ShowDialog();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnAddFiles_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = Module.DialogFilesFilter;
            openFileDialog1.Multiselect = true;
            
            openFileDialog1.FileName = "";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    this.Cursor = Cursors.WaitCursor;

                    for (int k = 0; k < openFileDialog1.FileNames.Length; k++)
                    {                        
                        AddFile(openFileDialog1.FileNames[k]);
                    }
                }
                finally
                {
                    this.Cursor = null;
                }
            }
        }

        public bool AddFile(string filepath)
        {
            return AddFile(filepath, "","");
        }

        public bool AddFile(string filepath, string password)
        {
            return AddFile(filepath, password, "");
        }

        public bool AddFile(string filepath,string password,string rootfolder)
        {
            if (filepath.Trim() == string.Empty) return false;

            if (System.IO.Path.GetExtension(filepath).ToLower() != ".pdf")
            {
                Module.ShowMessage("Please add only PDF Files !");
                return false;
            }

            DataRow dr = dt.NewRow();
                        
            FileInfo fi=new FileInfo(filepath);

            long sizekb=fi.Length/1024;
            dr["filename"]=fi.Name;
            dr["fullfilepath"] = filepath;
            dr["sizekb"] = sizekb.ToString() + "KB";
            dr["filedate"] = fi.LastWriteTime.ToString();
            dr["rootfolder"] = rootfolder;
            dr["userpassword"] = password;

            dt.Rows.Add(dr);

            return true;
        }                                                                

        private void btnAddFolder_Click(object sender, EventArgs e)
        {            
            folderBrowserDialog1.SelectedPath = "";
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                AddFolder(folderBrowserDialog1.SelectedPath);   
            }
        }

        public void AddFolder(string folder_path)
        {
            AddFolder(folder_path, "");
        }

        public void AddFolder(string folder_path,string password)
        {
            string[] filez = null;

            if (Module.IsCommandLine)
            {
                if (Module.CmdAddSubdirectories)
                {
                    filez = System.IO.Directory.GetFiles(folder_path, "*.pdf", SearchOption.AllDirectories);
                }
                else
                {
                    filez = System.IO.Directory.GetFiles(folder_path, "*.pdf", SearchOption.TopDirectoryOnly);
                }
            }
            else
            {

                if (System.IO.Directory.GetDirectories(folder_path).Length > 0)
                {
                    DialogResult dres = Module.ShowQuestionDialog("Would you like to add also Subdirectories ?", "Add Subdirectories ?");

                    if (dres == DialogResult.Yes)
                    {
                        filez = System.IO.Directory.GetFiles(folder_path, "*.pdf", SearchOption.AllDirectories);
                    }
                    else
                    {
                        filez = System.IO.Directory.GetFiles(folder_path, "*.pdf", SearchOption.TopDirectoryOnly);
                    }
                }
                else
                {
                    filez = System.IO.Directory.GetFiles(folder_path, "*.pdf", SearchOption.TopDirectoryOnly);
                }
            }

            try
            {
                this.Cursor = Cursors.WaitCursor;

                for (int k = 0; k < filez.Length; k++)
                {
                    if (filez[k].ToLower().EndsWith(".pdf"))
                    {
                        AddFile(filez[k],password,folder_path);
                    }
                    
                }
            }
            finally
            {
                this.Cursor = null;
            }

        }

        
                

        private void btnRemoveFile_Click(object sender, EventArgs e)
        {
            DataGridViewSelectedCellCollection cells = dgFiles.SelectedCells;
            List<DataGridViewRow> rows = new List<DataGridViewRow>();

            for (int k = 0; k < cells.Count; k++)
            {
                if (rows.IndexOf(dgFiles.Rows[cells[k].RowIndex]) < 0)
                {
                    rows.Add(dgFiles.Rows[cells[k].RowIndex]);
                }
            }

            for (int k = 0; k < rows.Count; k++)
            {
                dgFiles.Rows.Remove(rows[k]);
            }
                       
        }

        private void tiHelpFeedback_Click(object sender, EventArgs e)
        {
            /*
            frmUninstallQuestionnaire f = new frmUninstallQuestionnaire(false);
            f.ShowDialog();
            */

            System.Diagnostics.Process.Start("https://www.4dots-software.com/support/bugfeature.php?app=" + System.Web.HttpUtility.UrlEncode(Module.ShortApplicationTitle));
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgFiles.CurrentRow==null) return;

            System.Diagnostics.Process.Start(dgFiles.CurrentRow.Cells["colFullFilepath"].Value.ToString());

        }               

        private bool IsDragging = false;

        /*
        private void lvDocs_DragOver(object sender, DragEventArgs e)
        {
            
        }

        private void lvDocs_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop,false))
            {
                IsDragging = true;
                e.Effect = DragDropEffects.All;

            }
            else
            {
                e.Effect = DragDropEffects.None;
            }

        }

        private void lvDocs_DragDrop(object sender, DragEventArgs e)
        {           

            Point pt = lvDocs.PointToClient(Cursor.Position);
            ListViewHitTestInfo hiti = lvDocs.HitTest(pt.X, pt.Y);

            //if (hiti.Item != null)
            //{

            int ind = -1;
            if (hiti.Item != null)
            {
                ind = hiti.Item.Index;
            }

            List<ListViewItem> lst = new List<ListViewItem>();

            if (e.Data.GetDataPresent(DataFormats.FileDrop, false))
            {
                string[] filez = (string[])e.Data.GetData(DataFormats.FileDrop);

                for (int k = 0; k < filez.Length; k++)
                {
                    bool isimage = false;                                        

                    try
                    {
                        this.Cursor = Cursors.WaitCursor;
                        AddFile(filez[k]);
                    }
                    finally
                    {
                        this.Cursor = null;
                    }

                    lst.Add(lvDocs.Items[lvDocs.Items.Count - 1]);
                }

                if (hiti.Item != null && (lvDocs.Items.Count != lst.Count))
                {
                    for (int k = 0; k < lst.Count; k++)
                    {
                        lvDocs.Items.Remove(lst[k]);
                    }

                    for (int k = 0; k < lst.Count; k++)
                    {
                        lvDocs.Items.Insert(ind + k, lst[k]);
                    }
                }
            }


            //}

        }
        */                                                             

        private void buyNowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(Module.StoreUrl);
        }
                
        protected override void WndProc(ref Message m)
        {
            /*
            if (m.Msg == Program.WM_MULTIPLE_SEARCH_REPLACE)
            {
                MessageBox.Show(m.GetLParam(typeof(string)).ToString());
                lstIncludePaths.Items.Add(m.GetLParam(typeof(string)));
            }
            base.WndProc(ref m);
            */

            if (m.Msg == MessageHelper.WM_COPYDATA)
            {
                MessageHelper.COPYDATASTRUCT mystr = new MessageHelper.COPYDATASTRUCT();
                Type mytype = mystr.GetType();
                mystr = (MessageHelper.COPYDATASTRUCT)m.GetLParam(mytype);
                //MessageBox.Show(mystr.lpData);

                string arg = mystr.lpData;

                //MessageBox.Show("RECEIVED MESSAGE :" + arg);
                string[] args = arg.Split(new string[] { "|||" }, StringSplitOptions.RemoveEmptyEntries);

                //frmClientImages.Instance.ShowSendToMenuForm(args);
                for (int n = 1; n <= args.GetUpperBound(0); n++)
                {
                    //MessageBox.Show(args[n]);
                }

                AddVisual(args);


            }
            else if (m.Msg == MessageHelper.WM_ACTIVATEAPP)
            {
                this.WindowState = FormWindowState.Normal;
                this.Show();
            }



            base.WndProc(ref m);
        }

        private void helpGuideToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(Module.HelpURL);
        }

        private void btnClearMerge_Click(object sender, EventArgs e)
        {
            dt.Rows.Clear();                        
            
        }

        private void btnSetMetadata_Click(object sender, EventArgs e)
        {
            //=========

            Properties.Settings.Default.ExploreOutputFolder = exploreOutputFolderWhenDoneToolStripMenuItem.Checked;

            Properties.Settings.Default.KeepCreationDate = keepCreationDateToolStripMenuItem.Checked;

            Properties.Settings.Default.KeepLastModificationDate = keepLastModificationDateToolStripMenuItem.Checked;

            Properties.Settings.Default.ShowMessageOnSucess = showMessageOnSucessToolStripMenuItem.Checked;

            try
            {
                dgFiles.EndEdit();
                dgFiles.BindingContext[dt].EndCurrentEdit();
                dgCustomMetadata.EndEdit();
                dgCustomMetadata.BindingContext[dtcustom].EndCurrentEdit();

                if (dt.Rows.Count == 0)
                {
                    Module.ShowMessage("Please add PDF Files first !");
                    return;
                }

                for (int m = 0; m < frmMain.Instance.dtcustom.Rows.Count; m++)
                {
                    if (frmMain.Instance.dtcustom.Rows[m]["customvalue"].ToString().Trim() != string.Empty
                        && frmMain.Instance.dtcustom.Rows[m]["customname"].ToString().Trim() == string.Empty)
                    {
                        Module.ShowMessage("Please insert a Custom Metadata Property Name !");
                        return;
                    }
                }                               

                backgroundWorker1.RunWorkerAsync();

                string err = MetadataHelper.SetMetadataMultiplePDF(dt,chkClearMetadata.Checked);

                backgroundWorker1.CancelAsync();

                while (backgroundWorker1.IsBusy)
                {
                    Application.DoEvents();
                }

                if (MetadataHelper.CANCELLED)
                {
                    Module.ShowMessage("Operation Cancelled !");
                    return;
                }

                if (err == String.Empty)
                {
                    if (Properties.Settings.Default.ShowMessageOnSucess)
                    {
                        Module.ShowMessage("Operation completed successfully !");
                    }

                    if (Properties.Settings.Default.ExploreOutputFolder)
                    {
                        btnOpenFolder_Click(null, null);
                    }
                }
                else
                {
                    frmMessage f = new frmMessage();
                    f.lblMsg.Text = TranslateHelper.Translate("Operation completed with Errors !");
                    f.txtMsg.Text = err;

                    f.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                Module.ShowError("Error", ex);
            }
            finally
            {
                
            }
        }

        private void frmMain_Resize(object sender, EventArgs e)
        {
            /*
            int bsize = btnEncrypt.Width + 20 + btnExit.Width;
            btnEncrypt.Left = (this.ClientRectangle.Width / 2) - (bsize / 2);
            btnExit.Left = btnEncrypt.Right + 20;
            */
            
        }

        private void dgFiles_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop, false))
            {
                string[] filez = (string[])e.Data.GetData(DataFormats.FileDrop);

                for (int k = 0; k < filez.Length; k++)
                {
                    bool isimage = false;

                    try
                    {
                        this.Cursor = Cursors.WaitCursor;
                        AddFile(filez[k]);
                    }
                    finally
                    {
                        this.Cursor = null;
                    }                    
                }                
            }

        }

        private void dgFiles_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop, false))
            {
                IsDragging = true;
                e.Effect = DragDropEffects.All;

            }
            else
            {
                e.Effect = DragDropEffects.None;
            }

        }

        private void dgFiles_DragOver(object sender, DragEventArgs e)
        {
            IsDragging = true;
            if ((e.AllowedEffect & DragDropEffects.Copy) == DragDropEffects.Copy)
            {
                e.Effect = DragDropEffects.Copy;
            }
        }                

        private void visit4dotsSoftwareWebsiteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.4dots-software.com");
        }

        private void btnOpenFolder_Click(object sender, EventArgs e)
        {
            dgFiles.EndEdit();

            if (dt.Rows.Count == 0)
            {
                Module.ShowMessage("Please add a PDF File first !");

            }
            else
            {
                string dirpath = "";
                string filepath = "";
                string outfilepath = "";

                if (dgFiles.SelectedCells.Count == 0)
                {
                    filepath = dgFiles.Rows[0].Cells["colFullfilepath"].Value.ToString();
                }
                else
                {
                    filepath = dgFiles.SelectedCells[0].OwningRow.Cells["colFullfilepath"].Value.ToString();
                }

                if (frmMain.Instance.cmbOutputDir.Text.Trim() == TranslateHelper.Translate("Same Folder of PDF Document"))
                {
                    dirpath = System.IO.Path.GetDirectoryName(filepath);
                    outfilepath = System.IO.Path.Combine(dirpath, System.IO.Path.GetFileNameWithoutExtension(filepath) + "_with_metadata.pdf");
                }
                else if (frmMain.Instance.cmbOutputDir.Text.ToString().StartsWith(TranslateHelper.Translate("Subfolder") + " : "))
                {
                    int subfolderspos = (TranslateHelper.Translate("Subfolder") + " : ").Length;
                    string subfolder = frmMain.Instance.cmbOutputDir.Text.ToString().Substring(subfolderspos);

                    outfilepath = System.IO.Path.Combine(System.IO.Path.GetDirectoryName(filepath) + "\\" + subfolder, System.IO.Path.GetFileName(filepath));
                }
                else if (frmMain.Instance.cmbOutputDir.Text.Trim() == TranslateHelper.Translate("Overwrite PDF Document"))
                {
                    outfilepath = filepath;
                }
                else
                {
                    outfilepath = System.IO.Path.Combine(frmMain.Instance.cmbOutputDir.Text, System.IO.Path.GetFileName(filepath));
                }

                string args = string.Format("/e, /select, \"{0}\"", outfilepath);
                ProcessStartInfo info = new ProcessStartInfo();
                info.FileName = "explorer";
                info.UseShellExecute = true;
                info.Arguments = args;
                Process.Start(info);
            }
        }

        private void btnChangeFolder_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog2.ShowDialog() == DialogResult.OK)
            {
                OutputFolderHelper.SaveOutputFolder(folderBrowserDialog2.SelectedPath);
            }
        }

        

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            frmProgress fp = new frmProgress();
            fp.Show();

            while (true)
            {
                if (backgroundWorker1.CancellationPending)
                {
                    fp.Close();
                    return;
                }

                Application.DoEvents();
                
            }
        }                   

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveSizeLocation();
            Properties.Settings.Default.KeepBackup = chkKeepBackup.Checked;
            Properties.Settings.Default.OutputFolderIndex = cmbOutputDir.SelectedIndex;

            Properties.Settings.Default.ClearMetadata = chkClearMetadata.Checked;

            Properties.Settings.Default.MTitle = txtTitle.Text;
            Properties.Settings.Default.MAuthor = txtAuthor.Text;
            Properties.Settings.Default.MCreator = txtCreator.Text;
            Properties.Settings.Default.MKeywords = txtKeywords.Text;
            Properties.Settings.Default.MSubject = txtSubject.Text;

            Properties.Settings.Default.MCreationDate = dpCreationDate.Value;

            Properties.Settings.Default.MModificationDate = dpModificationDate.Value;

            Properties.Settings.Default.CTitle = chkTitle.Checked;
            Properties.Settings.Default.CAuhor = chkAuthor.Checked;
            Properties.Settings.Default.CCreationDate = chkCreationDate.Checked;
            Properties.Settings.Default.CCreator = chkCreator.Checked;
            Properties.Settings.Default.CKeywords = chkKeywords.Checked;
            Properties.Settings.Default.CModificationDate = chkModificationDate.Checked;
            Properties.Settings.Default.CSubject = chkSubject.Checked;

            Properties.Settings.Default.CheckWeek = checkForNewVersionEachWeekToolStripMenuItem.Checked;

            try
            {
                string cz = "";

                for (int k = 0; k < dtcustom.Rows.Count; k++)
                {
                    cz += dtcustom.Rows[k]["customname"] + "|||" + dtcustom.Rows[k]["customvalue"] + "|||";
                }

                Properties.Settings.Default.MCustomMetadata = cz;

            }
            catch { }

            //=========

            Properties.Settings.Default.ExploreOutputFolder = exploreOutputFolderWhenDoneToolStripMenuItem.Checked;

            Properties.Settings.Default.KeepCreationDate = keepCreationDateToolStripMenuItem.Checked;

            Properties.Settings.Default.KeepLastModificationDate = keepLastModificationDateToolStripMenuItem.Checked;

            Properties.Settings.Default.ShowMessageOnSucess = showMessageOnSucessToolStripMenuItem.Checked;

            Properties.Settings.Default.Save();
        }

        private void cmbOutputDir_SelectedIndexChanged(object sender, EventArgs e)
        {
            chkKeepBackup.Visible = false;

            if (cmbOutputDir.SelectedIndex == 4)
            {
                Module.ShowMessage("Please specify another option as the Output Folder !");
                cmbOutputDir.SelectedIndex = Properties.Settings.Default.OutputFolderIndex;
            }
            else if (cmbOutputDir.SelectedIndex == 2)
            {
                frmOutputSubFolder fob = new frmOutputSubFolder();

                if (fob.ShowDialog() == DialogResult.OK)
                {
                    OutputFolderHelper.SaveOutputFolder(TranslateHelper.Translate("Subfolder") + " : " + fob.txtSubfolder.Text);
                }
                else
                {
                    return;
                }
            }
            else if (cmbOutputDir.SelectedIndex == 1)
            {
                chkKeepBackup.Visible = true;
            }
        }

        private void btnCustomAdd_Click(object sender, EventArgs e)
        {
            dtcustom.Rows.Add(dtcustom.NewRow());
        }

        private void btnCustomDelete_Click(object sender, EventArgs e)
        {
            if (dgCustomMetadata.Rows.Count > 0)
            {
                DataRowView drv = null;

                if (dgCustomMetadata.CurrentRow == null)
                {
                    drv = (DataRowView)dgCustomMetadata.Rows[0].DataBoundItem;
                }
                else
                {
                    drv = (DataRowView)dgCustomMetadata.CurrentRow.DataBoundItem;
                }

                if (drv!=null && drv.Row != null)
                {
                    dtcustom.Rows.Remove(drv.Row);
                }
            }

            
        }
                
        private void exploreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgFiles.CurrentRow==null) return;

            string filepath = dgFiles.CurrentRow.Cells["colFullFilepath"].Value.ToString();            

            string args = string.Format("/e, /select, \"{0}\"", filepath);
            ProcessStartInfo info = new ProcessStartInfo();
            info.FileName = "explorer";
            info.UseShellExecute = true;
            info.Arguments = args;
            Process.Start(info);
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            Point p = dgFiles.PointToClient(new Point(Control.MousePosition.X, Control.MousePosition.Y));
            DataGridView.HitTestInfo hit=dgFiles.HitTest(p.X,p.Y);

            if (hit.Type == DataGridViewHitTestType.Cell)
            {
                dgFiles.CurrentCell = dgFiles.Rows[hit.RowIndex].Cells[hit.ColumnIndex];
            }
            
            if (dgFiles.CurrentRow==null)
            {
                e.Cancel = true;
            }
        }

        private void chkTitle_CheckedChanged(object sender, EventArgs e)
        {
            txtTitle.Enabled = chkTitle.Checked;
        }

        private void chkAuthor_CheckedChanged(object sender, EventArgs e)
        {
            txtAuthor.Enabled = chkAuthor.Checked;
        }

        private void chkSubject_CheckedChanged(object sender, EventArgs e)
        {
            txtSubject.Enabled = chkSubject.Checked;
        }

        private void chkKeywords_CheckedChanged(object sender, EventArgs e)
        {
            txtKeywords.Enabled = chkKeywords.Checked;
        }

        private void chkCreator_CheckedChanged(object sender, EventArgs e)
        {
            txtCreator.Enabled = chkCreator.Checked;
        }

        private void chkCreationDate_CheckedChanged(object sender, EventArgs e)
        {
            dpCreationDate.Enabled = chkCreationDate.Checked;
            //tpCreationDate.Enabled = tpCreationDate.Checked;
        }

        private void chkModificationDate_CheckedChanged(object sender, EventArgs e)
        {
            dpModificationDate.Enabled = chkModificationDate.Checked;
            //tpModificationDate.Enabled = chkModificationDate.Checked;
        }

        private void followUsOnTwitterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.twitter.com/4dotsSoftware");
        }

        private void btnInsertSpecial_Click(object sender, EventArgs e)
        {
            frmSpecialItem f = new frmSpecialItem();

            if (f.ShowDialog() == DialogResult.OK)
            {
                if (dgCustomMetadata.CurrentCell == null)
                {
                    dgCustomMetadata.CurrentCell = dgCustomMetadata.Rows[0].Cells[0];
                }

                //paste it into the custom value cell
                dgCustomMetadata.CurrentRow.Cells[1].Value = dgCustomMetadata.CurrentRow.Cells[1].Value.ToString()+ f.SelectedItem;
            }
        }

        private void documentsMetadataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tsbDocumetMetadata_Click(null, null);
        }

        private void tsbDocumetMetadata_Click(object sender, EventArgs e)
        {
            if (dgFiles.CurrentRow == null)
            {
                Module.ShowMessage("Please select a PDF document first !");
                return;
            }

            frmDocumentInfo f = new frmDocumentInfo(dgFiles.CurrentRow.Cells["colFullfilepath"].Value.ToString(),
                dgFiles.CurrentRow.Cells["colUserPassword"].Value.ToString());

            f.ShowDialog();

        }

        private void btnSpecialTitle_Click_1(object sender, EventArgs e)
        {
            frmSpecialItem f = new frmSpecialItem();

            if (f.ShowDialog() == DialogResult.OK)
            {                
                if (sender == btnSpecialAuthor)
                {
                    txtAuthor.Text += f.SelectedItem;
                    chkAuthor.Checked = true;
                    txtAuthor.Enabled = true;
                }
                else if (sender == btnSpecialCreator)
                {
                    txtCreator.Text += f.SelectedItem;
                    chkCreator.Checked = true;
                    txtCreator.Enabled = true;
                }
                else if (sender == btnSpecialKeywords)
                {
                    txtKeywords.Text += f.SelectedItem;
                    chkKeywords.Checked = true;
                    txtKeywords.Enabled = true;
                }
                else if (sender == btnSpecialSubject)
                {
                    txtSubject.Text += f.SelectedItem;
                    chkSubject.Checked = true;
                    txtSubject.Enabled = true;
                }
                else if (sender == btnSpecialTitle)
                {
                    txtTitle.Text += f.SelectedItem;
                    chkTitle.Checked = true;
                    txtTitle.Enabled = true;
                }
                
            }
        }

        private void keepFolderStructureToolStripMenuItem_Click(object sender, EventArgs e)
        {
            keepFolderStructureToolStripMenuItem.Checked = !keepFolderStructureToolStripMenuItem.Checked;

            Properties.Settings.Default.KeepFolderStructure = keepFolderStructureToolStripMenuItem.Checked;
        }

        private void tsdbImportList_ButtonClick(object sender, EventArgs e)
        {
            ImportListHelper.SilentAddErr = "";

            openFileDialog1.Filter = "Text Files (*.txt)|*.txt|CSV Files (*.csv)|*.csv|All Files (*.*)|*.*";
            openFileDialog1.FilterIndex = 0;
            openFileDialog1.FileName = "";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                ImportListHelper.ImportList(openFileDialog1.FileName);
                //3RecentFilesHelper.ImportListRecent(openFileDialog1.FileName);

                if (ImportListHelper.SilentAddErr != string.Empty)
                {
                    Module.ShowMessage(TranslateHelper.Translate("An error occured while Importing the List !")+"\n\n"+ ImportListHelper.SilentAddErr);
                    //3frmError f = new frmError(TranslateHelper.Translate("An error occured while Importing the List !"), ImportListHelper.SilentAddErr);
                    //3f.ShowDialog();
                }
            }
        }        

        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int k=0;k<dgFiles.Rows.Count;k++)
            {
                dgFiles.Rows[k].Selected = true;
            }
        }

        private void selectNoneToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int k = 0; k < dgFiles.Rows.Count; k++)
            {
                dgFiles.Rows[k].Selected = false;
            }
        }

        private void invertSelectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int k = 0; k < dgFiles.Rows.Count; k++)
            {
                dgFiles.Rows[k].Selected = !dgFiles.Rows[k].Selected;
            }
        }

        private void importListFromExcelFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.FileName = "";
            openFileDialog1.Filter = "Excel Files (*.xls;*.xlsx;*.xlt)|*.xls;*.xlsx;*.xlt";
            openFileDialog1.Multiselect = false;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                ExcelImporter xl = new ExcelImporter();
                xl.ImportListExcel(openFileDialog1.FileName);
            }

        }

        private void enterFileListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string txt = "";

            for (int k = 0; k < dt.Rows.Count; k++)
            {
                txt += dt.Rows[k]["fullfilepath"].ToString() + "\r\n";
            }

            frmMultipleFiles f = new frmMultipleFiles(false, txt);

            if (f.ShowDialog() == DialogResult.OK)
            {
                dt.Rows.Clear();

                for (int k = 0; k < f.txtFiles.Lines.Length; k++)
                {
                    AddFile(f.txtFiles.Lines[k].Trim());
                }
            }

        }

        private void saveCurrentFileListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dt.Rows.Count == 0)
            {
                Module.ShowMessage("Current Selection is Empty !");
                return;
            }

            saveFileDialog1.FileName = "";
            saveFileDialog1.Filter = "Text Files (*.txt)|*.txt";

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                using (StreamWriter sw = new StreamWriter(saveFileDialog1.FileName, false, Encoding.Default))
                {
                    for (int k = 0; k < dt.Rows.Count; k++)
                    {
                        sw.WriteLine(dt.Rows[k]["fullfilepath"].ToString());
                    }
                }
            }

        }

        private void donateViaPaypalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.4dots-software.com/donate.php");
        }

        private void youtubeChannelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.youtube.com/channel/UCovA-lld9Q79l08K-V1QEng");
        }

        private void tryOnlineVersionAtOnlinepdfappscomToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://onlinepdfapps.com");
        }

        private void commandLineArgumentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmMessage fm = new frmMessage(true);
            fm.ShowDialog(this);
        }
    }
}

