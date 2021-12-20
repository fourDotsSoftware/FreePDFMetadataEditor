using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace FreePDFMetadataEditor
{
    public class ImportListHelper
    {
        public static bool SilentAdd = false;
        public static string SilentAddErr = "";

        public static void ImportList(string listfilepath)
        {
            string curdir = Environment.CurrentDirectory;

            try
            {
                SilentAdd = true;
                using (StreamReader sr = new StreamReader(listfilepath,Encoding.Default,true))
                {
                    string line = null;

                    while ((line = sr.ReadLine()) != null)
                    {
                        if (line.StartsWith("#"))
                        {
                            continue;
                        }

                        string filepath = line;
                        string password = "";

                        try
                        {
                            if (line.StartsWith("\""))
                            {
                                int epos = line.IndexOf("\"", 1);

                                if (epos > 0)
                                {
                                    filepath = line.Substring(1, epos - 1);
                                }
                            }
                            else if (line.StartsWith("'"))
                            {
                                int epos = line.IndexOf("'", 1);

                                if (epos > 0)
                                {
                                    filepath = line.Substring(1, epos - 1);
                                }
                            }

                            int compos = line.IndexOf(",");

                            if (compos > 0)
                            {
                                password = line.Substring(compos + 1);

                                if (!line.StartsWith("\"") && !line.StartsWith("'"))
                                {
                                    filepath = line.Substring(0, compos);
                                }

                                if ((password.StartsWith("\"") && password.EndsWith("\""))
                                    || (password.StartsWith("'") && password.EndsWith("'")))
                                {
                                    if (password.Length == 2)
                                    {
                                        password = "";
                                    }
                                    else
                                    {
                                        password = password.Substring(1, password.Length - 2);
                                    }
                                }

                            }
                        }
                        catch (Exception exq)
                        {
                            SilentAddErr += TranslateHelper.Translate("Error while processing List !") + " " + line + " " + exq.Message + "\r\n";
                        }

                        line = filepath;


                        Environment.CurrentDirectory = System.IO.Path.GetDirectoryName(listfilepath);  
                        line = Path.GetFullPath(line);


                        if (System.IO.File.Exists(line))
                        {
                            if (System.IO.Path.GetExtension(line).ToLower() == ".pdf")
                            {
                                frmMain.Instance.AddFile(line, password);
                            }
                            else
                            {
                                SilentAddErr += TranslateHelper.Translate("Error wrong file type !") + " " + line + "\r\n";
                            }
                        }
                        else if (System.IO.Directory.Exists(line))
                        {
                            frmMain.Instance.AddFolder(line, password);
                        }
                        else
                        {
                            SilentAddErr += TranslateHelper.Translate("Error. File or Directory not found !") + " " + line + "\r\n";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                SilentAddErr += TranslateHelper.Translate("Error could not read file !") + " " + ex.Message + "\r\n";
            }
            finally
            {
                SilentAdd = false;

                Environment.CurrentDirectory = curdir;
            }
        }
    }
}
