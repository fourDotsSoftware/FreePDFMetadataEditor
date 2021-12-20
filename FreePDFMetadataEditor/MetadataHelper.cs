using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

using iTextSharp;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.factories;
 
using System.IO;
using System.Collections;
using System.Windows.Forms;
/*1
using PdfSharp.Drawing;
using PdfSharp.Pdf;
using PdfSharp.Pdf.IO;
using PdfSharp.Pdf.Advanced;
using PdfSharp.Pdf.Security;
*/

namespace FreePDFMetadataEditor
{
    class MetadataHelper
    {
        //PdfEncryptor.Encrypt(reader,myFileStream,PdfWriter.ENCRYPTION_RC4_128,sU 
        //Password,"test",PdfWriter.AllowPrinting|PdfWriter.AllowCopy); 

        public static string Title = "";
        public static string Author = "";
        public static string Subject = "";
        public static string Keywords = "";

        public static DateTime CreationDate = DateTime.Now;
        public static DateTime ModificationDate = DateTime.Now;
        public static string Creator = "";

        public static bool SetDocInfo = false;

        public static bool CANCELLED = false;

        public static string DefaultPassword = "";

        public static string SetMetadataMultiplePDF(DataTable dt,bool clearMetadata)
        {
            string err = "";
            CANCELLED = false;

            for (int k = 0; k < dt.Rows.Count; k++)
            {
                if (CANCELLED)
                {
                    return err;
                }

                string outfilepath="";
                string filepath=dt.Rows[k]["fullfilepath"].ToString();
                string password = dt.Rows[k]["userpassword"].ToString();
                string rootfolder = dt.Rows[k]["rootfolder"].ToString();

                if (frmMain.Instance.cmbOutputDir.Text.Trim() == TranslateHelper.Translate("Same Folder of PDF Document"))
                {
                    string dirpath = System.IO.Path.GetDirectoryName(filepath);
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
                    if (rootfolder != string.Empty && Properties.Settings.Default.KeepFolderStructure)
                    {
                        string dep = System.IO.Path.GetDirectoryName(filepath).Substring(rootfolder.Length);

                        string outdfp = frmMain.Instance.cmbOutputDir.Text + dep;

                        outfilepath = System.IO.Path.Combine(outdfp, System.IO.Path.GetFileName(filepath));

                        if (!System.IO.Directory.Exists(System.IO.Path.GetDirectoryName(outfilepath)))
                        {
                            System.IO.Directory.CreateDirectory(System.IO.Path.GetDirectoryName(outfilepath));
                        }
                    }
                    else
                    {
                        outfilepath = System.IO.Path.Combine(frmMain.Instance.cmbOutputDir.Text, System.IO.Path.GetFileName(filepath));
                    }                    
                }                                                

                try
                {
                    err += SetMetadataSinglePDF(filepath, outfilepath,password,clearMetadata);
                }
                catch (Exception ex)
                {
                    err += ex.Message + "\r\n";
                }
            }

            return err;
        }                       

        public static string SetMetadataSinglePDF(string InputFile, string OutputFile,string Password,bool clearMetadata)
        {
            string err = "";

            try
            {
                //                using (FileStream input = new FileStream(InputFile, FileMode.Open, FileAccess.Read, FileShare.Read))
                //{
                PdfReader reader = null;

                if (!System.IO.Directory.Exists(System.IO.Path.GetDirectoryName(OutputFile)))
                {
                    try
                    {
                        System.IO.Directory.CreateDirectory(System.IO.Path.GetDirectoryName(OutputFile));
                    }
                    catch (Exception exd)
                    {
                        err += TranslateHelper.Translate("Error. Could not Create Directory for File") + " : " + InputFile+"\r\n"+exd.Message+"\r\n";
                        return err;
                    }
                }


                try
                {
                    //  reader = new PdfReader(input);

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

                                //frmMain.Instance.backgroundWorker1.CancelAsync();

                                //while (frmMain.Instance.backgroundWorker1.IsBusy)
                                //{
                                //Application.DoEvents();
                                //}

                                if (string.IsNullOrEmpty(Password) && !string.IsNullOrEmpty(DefaultPassword))
                                {
                                    Password = DefaultPassword;
                                }
                                else
                                {
                                    frmProgress.Instance.HideForm();

                                    Module.ShowMessage("Please enter the correct User Password !");

                                    frmPassword f2 = new frmPassword(InputFile);



                                    DialogResult dres = f2.ShowDialog();

                                    frmProgress.Instance.ShowForm();

                                    //frmMain.Instance.backgroundWorker1.RunWorkerAsync();

                                    if (dres == DialogResult.OK)
                                    {
                                        Password = f2.txtPassword.Text;

                                        if (f2.chkPassword.Checked)
                                        {
                                            DefaultPassword = Password;
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

                    System.IO.FileInfo fi = new FileInfo(InputFile);
                    DateTime dtcreated = fi.CreationTime;
                    DateTime dtlastmod = fi.LastWriteTime;

                    Dictionary<string, string> dict = new Dictionary<string, string>();
                    //PdfDictionary dict = new PdfDictionary();

                    if (frmMain.Instance.chkAuthor.Checked)
                    {
                        dict.Add("Author", GetSpecialValue("Author", reader.Info, InputFile, frmMain.Instance.txtAuthor.Text));
                    }
                    if (frmMain.Instance.chkCreator.Checked)
                    {
                        dict.Add("Creator", GetSpecialValue("Creator", reader.Info, InputFile, frmMain.Instance.txtCreator.Text));
                    }
                    if (frmMain.Instance.chkKeywords.Checked)
                    {
                        dict.Add("Keywords", GetSpecialValue("Keywords", reader.Info, InputFile, frmMain.Instance.txtKeywords.Text));
                    }

                    if (frmMain.Instance.chkModificationDate.Checked)
                    {
                        //dict.Add("ModificationDate", ModificationDate.ToString());
                        //dict.Add("ModDate", new PdfDate(ModificationDate).ToString());
                        dict.Add(PdfName.MODDATE.ToString(), new PdfDate(frmMain.Instance.dpModificationDate.Value).ToString());
                    }

                    if (frmMain.Instance.chkCreationDate.Checked)
                    {
                        dict.Add("CreationDate", new PdfDate(frmMain.Instance.dpCreationDate.Value).ToString());
                    }

                    if (frmMain.Instance.chkTitle.Checked)
                    {
                        dict.Add("Title", GetSpecialValue("Title", reader.Info, InputFile, frmMain.Instance.txtTitle.Text));
                    }

                    if (frmMain.Instance.chkSubject.Checked)
                    {
                        dict.Add("Subject", GetSpecialValue("Subject", reader.Info, InputFile, frmMain.Instance.txtSubject.Text));
                    }

                    DateTime curdate = DateTime.Now;

                    for (int m = 0; m < frmMain.Instance.dtcustom.Rows.Count; m++)
                    {
                        if (frmMain.Instance.dtcustom.Rows[m]["customname"].ToString().Trim() != string.Empty)
                        {
                            string customvalue = GetSpecialValue(frmMain.Instance.dtcustom.Rows[m]["customname"].ToString(), reader.Info, InputFile, frmMain.Instance.dtcustom.Rows[m]["customvalue"].ToString());

                            dict.Add(frmMain.Instance.dtcustom.Rows[m]["customname"].ToString(), customvalue);

                        }
                    }

                    string TmpFile = "";

                    if (frmMain.Instance.cmbOutputDir.Text == TranslateHelper.Translate("Overwrite PDF Document"))
                    {
                        TmpFile = OutputFile;
                        OutputFile = System.IO.Path.GetTempFileName();
                    }

                    /*
                    if (clearMetadata)
                    {
                        reader.Catalog.Remove(PdfName.METADATA);
                        reader.RemoveUnusedObjects();
                    }
                    */
                    using (MemoryStream memoryStream = new MemoryStream())
                    {
                        PdfStamper stamper = new PdfStamper(reader, memoryStream);


                        if (clearMetadata)
                        {
                            dict = new Dictionary<string, string>();

                            foreach (KeyValuePair<string, string> kv in reader.Info)
                            {
                                dict.Add(kv.Key, null);
                            }

                            if (dict.Count > 0)
                            {
                                stamper.MoreInfo = dict;
                            }

                            using (MemoryStream msb = new MemoryStream())
                            {
                                iTextSharp.text.xml.xmp.XmpWriter xmpw = new iTextSharp.text.xml.xmp.XmpWriter(msb);
                                xmpw.Close();
                                stamper.XmpMetadata = msb.ToArray();

                            }

                            /*
                        iTextSharp.xmp.xmp

                            stamper.
                        ByteArrayOutputStream baos = new ByteArrayOutputStream();
                        XmpWriter xmp = new XmpWriter(baos, info);
                        xmp.close();
                        stamper.setXmpMetadata(baos.toByteArray());*/
                        }
                        else if (!clearMetadata)
                        {
                            if (dict.Count > 0)
                            {
                                stamper.MoreInfo = dict;
                            }
                        }

                        stamper.Close();
                        reader.Close();

                        File.WriteAllBytes(OutputFile, memoryStream.ToArray());
                    }

                    if (TmpFile != string.Empty)
                    {
                        if (frmMain.Instance.chkKeepBackup.Checked)
                        {
                            string bakfilepath = System.IO.Path.Combine(System.IO.Path.GetDirectoryName(TmpFile),
                            System.IO.Path.GetFileNameWithoutExtension(TmpFile) + ".bak.pdf");

                            System.IO.File.Move(TmpFile, bakfilepath);
                        }
                        else
                        {
                            System.IO.File.Delete(TmpFile);
                        }
                        System.IO.File.Move(OutputFile, TmpFile);

                        FileInfo fi3 = new FileInfo(TmpFile);

                        if (Properties.Settings.Default.KeepCreationDate)
                        {
                            fi3.CreationTime = dtcreated;
                        }

                        if (Properties.Settings.Default.KeepLastModificationDate)
                        {
                            fi3.LastWriteTime = dtlastmod;
                        }
                    }

                    FileInfo fi2 = new FileInfo(OutputFile);

                    if (Properties.Settings.Default.KeepCreationDate)
                    {
                        fi2.CreationTime = dtcreated;
                    }

                    if (Properties.Settings.Default.KeepLastModificationDate)
                    {
                        fi2.LastWriteTime = dtlastmod;
                    }

                    return err;

                }
                catch (Exception exm)
                {
                    err += TranslateHelper.Translate("An error occured while protecting PDF File") + " : " + InputFile + "\r\n" + exm.Message + "\r\n";
                }
                finally
                {
                    if (reader != null)
                    {
                        reader.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                err += TranslateHelper.Translate("An error occured while protecting PDF File") + " : " + InputFile + "\r\n" + ex.Message + "\r\n";
            }

            return err;
        }

        private static string GetSpecialValue(string field,Dictionary<string,string> info,string InputFile,string pattern)
        {
            string curval = "";

            if (info.ContainsKey(field))
            {
                curval = info[field];
            }

            DateTime curdate = DateTime.Now;

            string filename = System.IO.Path.GetFileName(InputFile);
            string filnoext = System.IO.Path.GetFileNameWithoutExtension(InputFile);
            string directoryname = System.IO.Path.GetFileName(System.IO.Path.GetDirectoryName(InputFile));
            string fullfilepath = InputFile;
            string directorypath = System.IO.Path.GetDirectoryName(InputFile);

            FileInfo fi = new FileInfo(InputFile);

            string custval = pattern;
            custval = custval.Replace("{SEC}", curdate.Second.ToString("D2"))
            .Replace("{MIN}", curdate.Minute.ToString("D2"))
            .Replace("{HOUR}", curdate.Hour.ToString("D2"))
            .Replace("{YEAR}", curdate.Year.ToString("D4"))
            .Replace("{MONTH}", curdate.Month.ToString("D2"))
            .Replace("{DAY}", curdate.Day.ToString("D2"))
            .Replace("{CURRENT DATETIME}", curdate.ToString())
            .Replace("{CURRENT TIME}", curdate.ToShortTimeString())
            .Replace("{CURRENT DATE}", curdate.ToShortDateString())
            .Replace("{LAST ACCESS TIME}", fi.LastAccessTime.ToString())
            .Replace("{CREATION TIME}", fi.CreationTime.ToString())
            .Replace("{LAST WRITE TIME}", fi.LastWriteTime.ToString())
            .Replace("{DIRECTORY PATH}", directorypath)
            .Replace("{DIRECTORY NAME}", directoryname)
            .Replace("{FULLFILEPATH}", fullfilepath)
            .Replace("{FILENAME WITHOUT EXTENSION}", filnoext)
            .Replace("{FILENAME}", filename)
            .Replace("{CURRENT VALUE}",curval);

            int fspos = 0;

            while (true)
            {                
                fspos = custval.IndexOf("|||Find:",fspos);

                if (fspos >= 0)
                {
                    int fispos=fspos;

                    fspos = fspos + "|||Find:".Length;

                    int fepos = custval.IndexOf("|||", fspos+1);

                    string findtxt = custval.Substring(fspos, fepos - fspos);

                    int rspos = custval.IndexOf("|||Replace:", fepos);
                    int repos = custval.IndexOf("|||", rspos+1);

                    if (rspos>=0)
                    {
                        rspos+="|||Replace:".Length;

                        string replacetxt = custval.Substring(rspos, repos - rspos);
                                                
                        string sp = Module.RegexEscape(findtxt);

                        string replaceStr = FindReplaceValue(curval, sp, replacetxt);

                        repos += "|||".Length;

                        if ((repos+1) < (custval.Length-1))
                        {
                            custval = custval.Substring(0, fispos) + replaceStr + custval.Substring(repos);
                        }
                        else
                        {
                            custval = custval.Substring(0, fispos) + replaceStr;
                        }

                        fspos = fispos + replaceStr.Length;
                    }
                }
                else
                {
                    break;
                }                
            }

            fspos = 0;

            while (true)
            {                
                fspos = custval.IndexOf("|||FindWildcards:", fspos);

                if (fspos >= 0)
                {
                    int fispos = fspos;

                    fspos = fspos + "|||FindWildcards:".Length;

                    int fepos = custval.IndexOf("|||", fspos+1);

                    string findtxt = custval.Substring(fspos, fepos - fspos);

                    int rspos = custval.IndexOf("|||Replace:", fepos);
                    int repos = custval.IndexOf("|||", rspos+1);

                    if (rspos >= 0)
                    {
                        rspos += "|||Replace:".Length;

                        string replacetxt = custval.Substring(rspos, repos - rspos);

                        string sp = Module.RegexEscape(findtxt);

                        sp = sp.Replace(@"\?", ".{1}").Replace(@"\*", ".*?\\b");

                        //sp = @"\b" + sp + @"\b";

                        string replaceStr = FindReplaceValue(curval, sp, replacetxt);

                        repos += "|||".Length;

                        if ((repos + 1) < (custval.Length - 1))
                        {
                            custval = custval.Substring(0, fispos) + replaceStr + custval.Substring(repos);
                        }
                        else
                        {
                            custval = custval.Substring(0, fispos) + replaceStr;
                        }

                        fspos = fispos + replaceStr.Length;
                    }
                }
                else
                {
                    break;
                }                
            }

            fspos = 0;            

            while (true)
            {                                
                fspos = custval.IndexOf("|||FindRegExp:", fspos);

                if (fspos >= 0)
                {
                    int fispos = fspos;

                    fspos = fspos + "|||FindRegExp:".Length;

                    int fepos = custval.IndexOf("|||", fspos+1);

                    string findtxt = custval.Substring(fspos, fepos - fspos);

                    int rspos = custval.IndexOf("|||Replace:", fepos);
                    int repos = custval.IndexOf("|||", rspos+1);

                    if (rspos >= 0)
                    {
                        rspos += "|||Replace:".Length;

                        string replacetxt = custval.Substring(rspos, repos - rspos);

                        string replaceStr = FindReplaceValue(curval, findtxt, replacetxt);

                        repos += "|||".Length;

                        if ((repos + 1) < (custval.Length - 1))
                        {
                            custval = custval.Substring(0, fispos) + replaceStr + custval.Substring(repos);
                        }
                        else
                        {
                            custval = custval.Substring(0, fispos) + replaceStr;
                        }

                        fspos = fispos + replaceStr.Length;
                    }
                }
                else
                {
                    break;
                }                
            }

            while (true)
            {
                int spos = custval.IndexOf("{CUSTOM DATE:");
                if (spos >= 0)
                {
                    int spos2 = spos + "{CUSTOM DATE:".Length;
                    int epos = custval.IndexOf("}", spos2);

                    string custdate = custval.Substring(spos2, epos - spos2);

                    string custend = "";

                    if (epos < custval.Length - 1)
                    {
                        custend = custval.Substring(epos, custval.Length - epos);
                    }

                    custval = custval.Substring(0, spos) + curdate.ToString(custdate) + custend;

                }
                else
                {
                    break;
                }
            }

            return custval;

        }

        private static string FindReplaceValue(string currentValue, string findPattern, string replaceTxt)
        {            
            System.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex(findPattern);

            System.Text.RegularExpressions.MatchCollection macol = regex.Matches(currentValue);

            string replaceValue = currentValue;

            int changedchars = 0;

            for (int k = 0; k < macol.Count; k++)
            {
                string reptxt = replaceTxt;

                int fspos = 0;

                while (true)
                {
                    fspos = reptxt.IndexOf("###MATCH GROUP:", fspos);

                    int ilen = reptxt.Length;

                    if (fspos >= 0)
                    {
                        int fepos = reptxt.IndexOf("###", fspos + 1);

                        //fspos+="###MATCH GROUP:".Length;

                        string mg = reptxt.Substring(fspos + "###MATCH GROUP:".Length, fepos - fspos - "###MATCH GROUP:".Length);

                        if ((fepos + 1) < (reptxt.Length - 1))
                        {
                            reptxt = reptxt.Substring(0, fspos) + macol[k].Groups[mg].Value + reptxt.Substring(fepos + "###".Length);
                        }
                        else
                        {
                            reptxt = reptxt.Substring(0, fspos) + macol[k].Groups[mg].Value;
                        }

                        fspos = fspos + macol[k].Groups[mg].Value.Length;
                    }
                    else
                    {
                        break;
                    }
                }

                replaceValue = replaceValue.Substring(0, macol[k].Index+changedchars) + reptxt + replaceValue.Substring(macol[k].Index + macol[k].Value.Length+changedchars);

                changedchars += macol[k].Value.Length - replaceTxt.Length;

            }

            return replaceValue;
        }
    }
}
