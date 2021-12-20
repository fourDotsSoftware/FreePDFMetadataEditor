using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using iTextSharp;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.factories;

namespace FreePDFMetadataEditor
{
    public partial class frmDocumentInfo : FreePDFMetadataEditor.CustomForm
    {
        //public static frmDocumentMetadata Instance = new frmDocumentMetadata();
        private string InputFile = "";
        private string Password = "";
                        
        public frmDocumentInfo(string filepath,string password)
        {
            InitializeComponent();
            //Instance = this;
            InputFile = filepath;
            Password = password;
        }


        private void btnExit_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private string GetDocumentMetadata(string InputFile, string Password)
        {
            PdfReader reader = null;
            string err = "";

            try
            {
                while (true)
                {
                    using (Stream input = new FileStream(InputFile, FileMode.Open, FileAccess.Read, FileShare.Read))
                    {
                        try
                        {
                            if (!String.IsNullOrEmpty(Password))
                            {
                                reader = new PdfReader(input, Encoding.Default.GetBytes(Password));
                                //reader = new PdfReader(input, Encoding.UTF8.GetBytes(Password));
                            }
                            else
                            {
                                reader = new PdfReader(input);
                            }

                            break;
                        }
                        catch (iTextSharp.text.pdf.BadPasswordException ex)
                        {
                            if (reader != null)
                            {
                                reader.Close();
                            }

                            if (input != null)
                            {
                                input.Close();
                            }

                            if (string.IsNullOrEmpty(Password) && !string.IsNullOrEmpty(MetadataHelper.DefaultPassword))
                            {
                                Password = MetadataHelper.DefaultPassword;
                            }
                            else
                            {
                                Module.ShowMessage("Please enter the correct User Password !");

                                frmPassword f2 = new frmPassword(InputFile);

                                DialogResult dres = f2.ShowDialog();

                                if (dres == DialogResult.OK)
                                {
                                    Password = f2.txtPassword.Text;

                                    if (f2.chkPassword.Checked)
                                    {
                                        MetadataHelper.DefaultPassword = Password;
                                    }

                                }
                                else
                                {
                                    err += TranslateHelper.Translate("Error. Wrong User Password for File") + " : " + InputFile;
                                    return err;
                                }
                            }
                        }
                    }
                }

                if (reader.Info.ContainsKey("Author"))
                txtAuthor.Text = reader.Info["Author"];

                if (reader.Info.ContainsKey("Creator"))
                txtCreator.Text = reader.Info["Creator"];

                if (reader.Info.ContainsKey("Keywords"))
                txtKeywords.Text = reader.Info["Keywords"];

                if (reader.Info.ContainsKey("Subject"))
                txtSubject.Text = reader.Info["Subject"];

                if (reader.Info.ContainsKey("Title"))
                txtTitle.Text = reader.Info["Title"];

                if (reader.Info.ContainsKey("CreationDate"))
                txtCreationDate.Text = reader.Info["CreationDate"];

                if (reader.Info.ContainsKey("ModDate"))
                txtModificationDate.Text = reader.Info["ModDate"];

                DataTable dt = new DataTable("custom");
                dt.Columns.Add("customname");
                dt.Columns.Add("customvalue");

                foreach (KeyValuePair<string, string> d in reader.Info)
                {                    
                    if (d.Key.ToLower() != "author" &&
                        d.Key.ToLower() != "creator" &&
                        d.Key.ToLower() != "keywords" &&
                        d.Key.ToLower() != "title" &&
                        d.Key.ToLower() != "creationdate" &&
                        d.Key.ToLower() != "moddate")
                    {
                        DataRow dr = dt.NewRow();
                        dr["customname"] = d.Key;
                        dr["customvalue"] = d.Value;
                        dt.Rows.Add(dr);
                    }
                }

                dgCustomMetadata.DataSource = dt;
            }
            catch (Exception exm)
            {
                err += TranslateHelper.Translate("An error occured while getting Metadata from PDF File") + " : " + InputFile + "\r\n" + exm.Message + "\r\n";
            }
            finally
            {
                if (reader != null)
                {
                    reader.Close();
                }
            }

            return err;
        }

        private void frmDocumentInfo_Load(object sender, EventArgs e)
        {
            string err = GetDocumentMetadata(InputFile, Password);
            if (err != string.Empty)
            {
                frmMessage f = new frmMessage();
                f.lblMsg.Text = TranslateHelper.Translate("An error occured while getting Document's Metadata !");
                f.txtMsg.Text = err;
                f.ShowDialog();
            }

        }

        
    }
}

