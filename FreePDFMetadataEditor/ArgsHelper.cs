using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace FreePDFMetadataEditor
{ 
    class ArgsHelper
    {
        public static bool FromWindowsExplorer = false;

        public static bool ExamineArgs(string[] args)
        {
            if (args.Length == 0) return true;

            //MessageBox.Show(args[0]);

            try
            {
                if (args[0].ToLower().StartsWith("-tempfile:"))
                {
                    FromWindowsExplorer = true;

                    string tempfile = GetParameter(args[0]);

                    //MessageBox.Show(tempfile);

                    using (StreamReader sr = new StreamReader(tempfile, Encoding.Unicode))
                    {
                        string scont = sr.ReadToEnd();

                        //args = scont.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
                        args = SplitArguments(scont);
                        Module.args = args;

                       // MessageBox.Show(scont);
                    }
                }

            }
            catch (Exception ex)
            {
                Module.ShowError("Error could not parse Arguments !", ex);
                return false;
            }


            return true;
        }

        private static string GetParameter(string arg)
        {
            int spos = arg.IndexOf(":");
            if (spos == arg.Length - 1) return "";
            else
            {
                string str=arg.Substring(spos + 1);

                if ((str.StartsWith("\"") && str.EndsWith("\"")) ||
                    (str.StartsWith("'") && str.EndsWith("'")))
                {
                    if (str.Length > 2)
                    {
                        str = str.Substring(1, str.Length - 2);
                    }
                    else
                    {
                        str = "";
                    }
                }

                return str;
            }
        }

        public static string[] SplitArguments(string commandLine)
        {
            char[] parmChars = commandLine.ToCharArray();
            bool inSingleQuote = false;
            bool inDoubleQuote = false;
            for (int index = 0; index < parmChars.Length; index++)
            {
                if (parmChars[index] == '"' && !inSingleQuote)
                {
                    inDoubleQuote = !inDoubleQuote;
                    parmChars[index] = '\n';
                }
                if (parmChars[index] == '\'' && !inDoubleQuote)
                {
                    inSingleQuote = !inSingleQuote;
                    parmChars[index] = '\n';
                }
                if (!inSingleQuote && !inDoubleQuote && parmChars[index] == ' ')
                    parmChars[index] = '\n';
            }
            return (new string(parmChars)).Split(new char[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);
        }

        public static void ShowCommandUsage()
        {
            string msg = GetCommandUsage();

            Module.ShowMessage(msg);

            Environment.Exit(0);

        }
        public static string GetCommandUsage()
        {
            string msg = "RemoveMerges, splits , extracts and deletes pages from Pdf Files.\n\n" +
            "FreePDFMetadataEditor.exe [-merge|-split|-delete|-extract] [[file|directory]]" +
            "[/pagefrom:PAGE_FROM_VALUE] " +            
            "[/pageto:PAGE_TO_VALUE] " +
            "[/pageevenfrom:PAGE_EVEN_FROM_VALUE] " +
            "[/pageevento:PAGE_EVEN_TO_VALUE] " +
            "[/pageoddfrom:PAGE_ODD_FROM_VALUE] "+
            "[/pageoddto:PAGE_ODD_TO_VALUE] "+
            "[/pageevery:PAGE_EVERY_VALUE] "+
            "[/pageeveryfrom:PAGE_EVERY_FROM_VALUE] "+
            "[/pageeveryto:PAGE_EVERY_TO_VALUE] "+
            "[/pagecontaining:PAGE_CONTAINING_TEXT_VALUE] "+
            "[/title:TITLE_VALUE] "+
            "[/author:AUTHOR_VALUE] "+
            "[/subject:SUBJECT_VALUE] "+
            "[/keywords:KEYWORDS_VALUE] "+
            "[/userpassword:USER_PASSWORD_VALUE] "+
            "[/ownerpassword:OWNER_PASSWORD_VALUE] "+
            "[/subdirs] "+
            "[splitbookmarks:SPLIT_BOOKMARKS_LEVEL_VALUE] "+
            "[splitblank:SPLIT_BLANK_PAGES_VALUE] "+
            "[headertext:HEADER_TEXT_VALUE] "+
            "[footertext:FOOTER_TEXT_VALUE] "+
            "[outfilename:OUTPUT_FILENAME_PATTERN] "+
            "[OutputFolder:OUTPUT_FOLDER_VALUE] "+
            "[/?]\n\n\n" +
            "file : one or more pdf or image files to be processed.\n" +
            "directory : one or more directories containing pdf or images files to be processed.\n" +
            "pagefrom: process pages from\n"+
            "pageto: process pages to\n"+
            "pageevenfrom: process even pages from\n"+
            "pageevento: process even pages to\n"+
            "pageoddfrom: process odd pages from\n"+
            "pageoddto: process odd pages to\n"+
            "pageevery: process every PAGE_EVERY_VALUE pages\n"+
            "pageeveryfrom: process every PAGE_EVERY_VALUE pages starting from this value\n"+
            "pageeveryto: process every PAGE_EVERY_VALUE pages starting till this value\n" +
            "pagecontaining: process only pages containing text\n"+
            "title : Document title\n"+
            "author: Document author\n"+
            "subject: Document subject\n"+
            "keywords: Document keywords\n"+
            "userpassword: Document user password\n"+
            "ownerpassword: Document owner password\n"+
            "subdirs : process also subdirectories of specified directories\n"+
            "splitbookmarks: split document by bookmarks on this level value\n"+
            "splitblank : split document by number of continuous blank pages\n"+
            "headertext: Header text\n"+
            "footertext : Footer Text\n"+
            "outfilename : Output filename pattern. Enter [page] for page number and [file] for filename.\n" +
            "OutputFolder: Output folder value (if different than the folder of the first file)\n"+
            "/? : show help\n";

            return msg;
        }
              

        
                
                
    }

    public class ReadListsResult
    {
        public bool Success = true;
        public string err = "";
    }
}
