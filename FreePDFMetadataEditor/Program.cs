using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Microsoft.Win32;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Threading;
using System.IO;

namespace FreePDFMetadataEditor
{
    static class Program
    {
        [DllImport("kernel32.dll")]
        public static extern Boolean FreeConsole();

        [DllImport("kernel32.dll")]
        static extern bool AttachConsole(int dwProcessId);
        [DllImport("kernel32.dll")]
        public static extern Boolean AllocConsole();

        const int ATTACH_PARENT_PROCESS = -1;
        const int ERROR_ACCESS_DENIED = 5;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        /// 

        static void SetupLocalized()
        {
            string[] dirz = System.IO.Directory.GetDirectories(@"c:\Code\Pdf Tools\FreePDFPasswordRemover\helpfile\");
            for (int k = 0; k < dirz.Length; k++)
            {
                System.IO.File.Copy(dirz[k] + "\\PDF Password Remover Users Manual.chm",
                    @"c:\Code\Pdf Tools\FreePDFPasswordRemover\FreePDFPasswordRemover\bin\Debug\" +
                System.IO.Path.GetFileName(dirz[k]) + "\\PDF Password Remover Users Manual.chm");
            }

            dirz = System.IO.Directory.GetDirectories(@"c:\MyWebpages\4dotsSoftware\pdfdocmerge\pdf_password_remover\");

            for (int k = 0; k < dirz.Length; k++)
            {
                System.IO.File.Copy(dirz[k]+"\\index.html",
                @"c:\MyWebpages\4dotsSoftware\pdfdocmerge\pdf_password_remover\index_"+
                System.IO.Path.GetFileName(dirz[k])+".html");
            }
        }

        static void SetupNSILang()
        {
            string[] dirz = System.IO.Directory.GetDirectories(@"c:\MyWebpages\4dotsSoftware\pdfdocmerge\pdf_password_remover\");

            using (StreamWriter sw = new StreamWriter(@"c:\Code\Pdf Tools\FreePDFPasswordRemover\FreePDFPasswordRemover\bin\Debug\nsilang.txt"))
            {
                for (int k = 0; k < dirz.Length; k++)
                {
                    sw.WriteLine("CreateDirectory \"$INSTDIR\\" + System.IO.Path.GetFileName(dirz[k]) + "\"");
                    sw.WriteLine("SetOutPath \"$INSTDIR\\" + System.IO.Path.GetFileName(dirz[k]) + "\"");
                    sw.WriteLine("File \"..\\..\\..\\Dotfuscated\\" + System.IO.Path.GetFileName(dirz[k]) + "\\PDFPasswordRemover.resources.dll\"");
                    sw.WriteLine("File \"" + System.IO.Path.GetFileName(dirz[k]) + "\\PDF Password Remover Users Manual.chm\"");
                }
            }
        }

        [STAThread]
        static void Main(string[] args)
        {
            //SetupNSILang();
            //SetupLocalized();
            //Environment.Exit(0);
            //ContextMenuHelper.WriteTest();
            //Environment.Exit(0);
            
            //Module.args = args;
            
            for (int k = 0; k < args.Length; k++)
            {
                //Module.ShowMessage(args[k]);

            }
            

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            frmLanguage.SetLanguages();
            SetLanguage();

            if (args.Length > 0 && args[0].StartsWith("/uninstall"))
            {
                Module.DeleteApplicationSettingsFile();

                /*
                frmUninstallQuestionnaire fq = new frmUninstallQuestionnaire();
                fq.ShowDialog();
                */

                System.Diagnostics.Process.Start("https://www.4dots-software.com/support/bugfeature.php?uninstall=true&app=" + System.Web.HttpUtility.UrlEncode(Module.ShortApplicationTitle));

                return;
                Environment.Exit(0);
            }
            
            ExceptionHandlersHelper.AddUnhandledExceptionHandlers();

            if (args.Length > 0)
            {
                //System.Threading.Thread.Sleep(2000);
            }

            Module.args = args;

            ArgsHelper.ExamineArgs(args);

            //add comments for not test version !

            Application.Run(new frmMain());

            return;
            
            /* REMOVE COMMENTS FOR TRIAL
            ContextMenuHelper.DisplayContextMenu();
            */                       

            /*
            if (ArgsHelper.IsCommandLine())
            {
                if (!AttachConsole(ATTACH_PARENT_PROCESS) && Marshal.GetLastWin32Error() == ERROR_ACCESS_DENIED)
                {
                    AllocConsole();
                }



                ArgsHelper.ExecuteCommandLine();

                Environment.Exit(0);
            }
             */
            /*
            InitRegistryLuminati();

            while (true)
            {
                string regval = RegistryHelper2.GetKeyValue("Free PDF Metadata Editor 4dots", "LuminatiChoice");

                if (regval == "NOTSET")
                {
                    System.Threading.Thread.Sleep(1000);
                }
                else if (regval == "ACCEPT")
                {
                    break;
                }
                else
                {
                    Environment.Exit(0);

                    return;
                }

                Application.DoEvents();
            }           

            // REMOVE FOR TRIAL
            Application.Run(new frmMain());
            //end

            //else
            //{
            /* REMOVE COMMENTS FOR TRIAL
                AppDomain.CurrentDomain.ProcessExit += new EventHandler(MiscHelper.CurrentDomain_ProcessExit);

                if (frmProsEggrafi.RenMove)
                {
                    return;
                }

                if (frmMain.Instance == null)
                {
                    Application.Run(new frmMain());
                }
                else
                {
                    if (!frmMain.Instance.IsDisposed)
                    {
                        Application.Run(frmMain.Instance);
                    }
                }
            //}
        
            
            Environment.Exit(0);   
             */
        }

        public static void InitRegistryLuminati()
        {
            if (Properties.Settings.Default.FirstTimeRun)
            {
                System.Diagnostics.Process proc2 = new Process();
                proc2.StartInfo.Arguments = "-clearchoice \"Free PDF Password Metadata Editor 4dots\"";
                proc2.StartInfo.FileName = System.IO.Path.Combine(Application.StartupPath, "LuminatiHelper.exe");
                proc2.Start();

                Properties.Settings.Default.FirstTimeRun = false;
            }
            RegistryHelper2.SetKeyValue("Free PDF Metadata Editor 4dots", "LuminatiChoice", "NOTSET");

            System.Diagnostics.Process proc = new Process();
            proc.StartInfo.Arguments = "-setup \"win_freepdfmetadataeditor.4dotssoftware.com\" \"Free PDF Metadata Editor 4dots\" \"" + System.IO.Path.Combine(Application.StartupPath, "free-pdf-metadata-editor-150.png") + "\"";
            proc.StartInfo.FileName = System.IO.Path.Combine(Application.StartupPath, "LuminatiHelper.exe");
            proc.Start();
        }
        public static void SetLanguage()
        {
            string lang = Properties.Settings.Default.Language;
            bool setlang = false;

            if (Properties.Settings.Default.LastVersion != Module.ApplicationTitle)
            {
                Properties.Settings.Default.LanguagesDownloaded = "";
                Properties.Settings.Default.LastVersion = Module.ApplicationTitle;
                Properties.Settings.Default.Save();
                setlang = true;
                
            }                       

            if (Properties.Settings.Default.Language == string.Empty || setlang)
            {
                frmLanguage fl = new frmLanguage();
                fl.ShowDialog();
                Properties.Settings.Default.Language = frmLanguage.SelectedLanguageCode;
                lang = frmLanguage.SelectedLanguageCode;
                setlang = true;
            }

            Module.SelectedLanguage = lang;

            if (lang != "en-US")
            {
                if (!frmLanguage.DownloadLanguage(lang))
                {
                    lang = "en-US";
                    Properties.Settings.Default.Language = "en-US";
                }

                
            }

            if (lang == "en-US")
            {
                System.Threading.Thread.CurrentThread.CurrentUICulture =
                    System.Globalization.CultureInfo.InvariantCulture;

                //Application.CurrentCulture = System.Globalization.CultureInfo.InvariantCulture;
            }
            else
            {
                try
                {
                    System.Threading.Thread.CurrentThread.CurrentUICulture = new
                    System.Globalization.CultureInfo(lang);

                    //Application.CurrentCulture = new System.Globalization.CultureInfo(lang);
                }
                catch (Exception ex)
                {
                    Module.ShowError(ex);
                }
            }


            if (setlang)
            {
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

                    key.SetValue("Menu Item Caption", TranslateHelper.Translate("Change PDF Properties"));
                }
                catch (Exception exr)
                {
                    Module.ShowError(exr);
                }
                finally
                {
                    key.Close();
                    key2.Close();
                }
            }
        }

        /*
        public static void SetLanguage()
        {
            RegistryKey key = Registry.CurrentUser;
            RegistryKey key2 = Registry.CurrentUser;
            string lang = "";

            try
            {
                key = key.OpenSubKey("Software\\4dots Software", true);

                if (key == null)
                {
                    key = Registry.CurrentUser.CreateSubKey("SOFTWARE\\4dots Software");
                }

                key2 = key.OpenSubKey("PDF Encrypter", true);

                if (key2 == null)
                {
                    key2 = key.CreateSubKey("PDF Encrypter");
                }

                key = key2;

                bool setlang = false;

                if (key.GetValue("Language") == null)
                {
                    frmLanguage fl = new frmLanguage();
                    fl.ShowDialog();

                    key.SetValue("Language", frmLanguage.SelectedLanguageCode);
                    setlang = true;   
                    
                }

                if (key != null && key.GetValue("Language") != null)
                {
                    lang = key.GetValue("Language").ToString();
                    Module.SelectedLanguage = lang;
                    if (lang == "en-US")
                    {
                        System.Threading.Thread.CurrentThread.CurrentUICulture =
                            System.Globalization.CultureInfo.InvariantCulture;

                        Application.CurrentCulture = System.Globalization.CultureInfo.InvariantCulture;

                    }
                    else
                    {

                        try
                        {
                            System.Threading.Thread.CurrentThread.CurrentUICulture = new
                            System.Globalization.CultureInfo(lang);

                            Application.CurrentCulture = new System.Globalization.CultureInfo(lang);
                        }
                        catch (Exception ex)
                        {
                            Module.ShowError(ex);
                        }
                    }
                }

                if (setlang)
                {
                    key.SetValue("Menu Item Caption", TranslateHelper.Translate("Encrypt PDF"));
                }
                
            }
            catch (Exception exr)
            {
                Module.ShowError(exr);
            }
            finally
            {
                key.Close();
                key2.Close();
            }            
        }*/
    }
}