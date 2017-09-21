using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;
using Microsoft.Office.Interop.Word;
using System.Runtime.InteropServices;

namespace PublicClass
{
    public static class Module
    {
        public static string ConString = "Server=.;Database=AFSS;User Id=sa;Password=123456;";
        public static string encryptKey = "1549523A648E345DFED23490DFD2345D";
        public static string UserName = "";
        public static bool IsDataOwner = false;
        public static string GetTextFromPDF(string Path)
        {
            StringBuilder text = new StringBuilder();
            using (PdfReader reader = new PdfReader(Path))
            {
                for (int i = 1; i <= reader.NumberOfPages; i++)
                {
                    text.Append(PdfTextExtractor.GetTextFromPage(reader, i));
                }
            }

            return text.ToString();
        }
        public static string GetTextFromWord(string Path)
        {
            StringBuilder text = new StringBuilder();
            Microsoft.Office.Interop.Word.Application word = new Microsoft.Office.Interop.Word.Application();
            object miss = System.Reflection.Missing.Value;
            object path = @Path;
            object readOnly = false;
            Microsoft.Office.Interop.Word.Document docs = word.Documents.Open(ref path, ref miss, false, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss);
            //docs.Application.Documents.Open(path);
            for (int i = 0; i < docs.Paragraphs.Count; i++)
            {
                text.Append(" \r\n " + docs.Paragraphs[i + 1].Range.Text.ToString());
            }
            return text.ToString();
        }
        public static void OpenWordDocument(string Path)
        {
            StringBuilder text = new StringBuilder();
            Microsoft.Office.Interop.Word.Application word = new Microsoft.Office.Interop.Word.Application();
            object miss = System.Reflection.Missing.Value;
            object path = @Path;
            word.Application.Documents.Open(path);
        }
        public static bool CloseWordDocument(string osPath) //here I pass the fully qualified path of the file
        {
            try
            {
                Microsoft.Office.Interop.Word.Application app = (Microsoft.Office.Interop.Word.Application)System.Runtime.InteropServices.Marshal.GetActiveObject("Word.Application");
                if (app == null)
                    return true;

                foreach (Microsoft.Office.Interop.Word.Document d in app.Documents)
                {
                    if (d.FullName.ToLower() == osPath.ToLower())
                    {
                        object saveOption = Microsoft.Office.Interop.Word.WdSaveOptions.wdDoNotSaveChanges;
                        object originalFormat = Microsoft.Office.Interop.Word.WdOriginalFormat.wdOriginalDocumentFormat;
                        object routeDocument = false;
                        d.Close(ref saveOption, ref originalFormat, ref routeDocument);
                        return true;
                    }
                }
                return true;
            }
            catch
            {
                return true;
            }
        }
        public static int GetNewId(String tableName, String column, int right)
        {
            int maxNumber = 0;
            try
            {
                using (var con = new SqlConnection(ConString))
                {
                    var cmd = new SqlCommand();
                    cmd.Connection = con;
                    con.Open();
                    String query = "select isNull(max(" + column + "),0) + 1  from " + tableName + ";";
                    cmd.Connection = con;
                    cmd.CommandText = query;
                    maxNumber = cmd.ExecuteScalar().ToInt();
                    return maxNumber;
                }
            }

            catch (Exception ex)
            {
                return -1;
            }

        }
        public static double FuzzySearch(string searchTerm, string keyWord)
        {

            try
            {
                var dt = new System.Data.DataTable();
                double FuzzyPercent;
                int fuzzyCounter = 0;
                
                StringBuilder KeyWord = new StringBuilder(keyWord.ToLower());
                StringBuilder searchWord = new StringBuilder(searchTerm.ToLower());

                #region get repeated chars in searchWord
                StringBuilder SearchWordRepeatChar = new StringBuilder(GetRepeatedChars(searchWord.ToString()).ToLower());
                #endregion

                #region get string without repeated chars from searchWord
                StringBuilder SearchWordResultString = new StringBuilder(SearchWordRepeatChar.ToString().ToLower() + GetUnRepeatedChar(searchWord.ToString().ToLower(), SearchWordRepeatChar.ToString().ToLower()).ToLower());
                #endregion

                #region get repeated chars in KeyWord
                StringBuilder KeyWordRepeatChar = new StringBuilder(GetRepeatedChars(KeyWord.ToString()).ToLower());
                #endregion

                #region get string without repeated chars from KeyWord
                StringBuilder KeyWordResultString = new StringBuilder(KeyWordRepeatChar.ToString().ToLower() + GetUnRepeatedChar(KeyWord.ToString().ToLower(), KeyWordRepeatChar.ToString().ToLower()).ToLower());
                #endregion

                #region calculate and return the FuzzyPercent
                for (int k = 0; k < SearchWordResultString.Length; k++)
                {
                    for (int l = 0; l < KeyWordResultString.Length; l++)
                    {
                        if (SearchWordResultString[k] == KeyWordResultString[l])
                            fuzzyCounter++;
                    }
                }
                return FuzzyPercent = (double)(fuzzyCounter) / (double)KeyWordResultString.Length;
                #endregion
            }
            catch (Exception)
            {
                return -1;
            }
        }

        public static string GetRepeatedChars(string searchWord)
        {
            string repeatChar = "";
            for (int a = 0; a < searchWord.Length; a++)
            {
                for (int b = a + 1; b < searchWord.Length; b++)
                {
                    if (searchWord[a] == searchWord[b])
                    {
                        if (!repeatChar.Contains(searchWord[a]))
                            repeatChar += searchWord[b].ToString();
                    }
                }
            }
            return repeatChar;
        }
        public static string GetUnRepeatedChar(string searchWord, string RepeatedChar)
        {
            string unRepeatChar = "";
            for (int a = 0; a < searchWord.Length; a++)
            {
                if (!RepeatedChar.ToString().Contains(searchWord[a]))
                {
                    unRepeatChar += searchWord[a].ToString();
                }
            }
            return unRepeatChar;
        }
        public static int ToInt(this object obj)
        {
            try
            {
                if (obj == null)
                {
                    return 0;
                }
                else
                {
                    return int.Parse(obj.ToString());
                }
            }
            catch (Exception)
            {
                return 0;
            }
        }
        public static bool? ToBool(this object obj)
        {
            try
            {
                if (obj == null)
                {
                    return null;
                }
                else
                {
                    return bool.Parse(obj.ToString());
                }
            }
            catch (Exception)
            {
                return null;
            }
        }
        public static double ToDouble(this object obj)
        {
            try
            {
                if (obj == null)
                {
                    return 0;
                }
                else
                {
                    return Math.Round(double.Parse(obj.ToString()), 2);
                }
            }
            catch (Exception)
            {
                return 0;
            }
        }
        
    }
}
