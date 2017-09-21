using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;
using Microsoft.Office.Interop.Word;
using AES_Algorithm;
using System.Data.SqlClient;
using PublicClass;
using Model;
using DAL;
using System.Diagnostics;

namespace SimpleCryptographer
{
    public partial class FrmDataOwner : Form
    {
        public delegate void ProgressInitHandler(object sender, ProgressInitArgs e);
        public delegate void ProgressEventHandler(object sender, ProgressEventArgs e);
        public static event ProgressEventHandler IncrementProgress;
        public static event ProgressInitHandler InitProgress;
        private List<Keyword> LstKeywords { get; set; }
        private List<Fuzzy> LstFuzzyKeywords { get; set; }

        private System.Data.DataTable dt;
        
        Cryptographer cryptographer = null;
        int elapsed = 0;

        private bool IsFile = false;
        private bool IsEncryption = false;

        #region For show just result time at once at the end of program, not continuously.
        DateTime start;
        DateTime end;
        TimeSpan result;
        #endregion

        #region For check elapsed time
        TimerCallback timerDelegate;
        AutoResetEvent autoEvent;
        System.Threading.Timer timer1;
        BackgroundWorker wkr;
        #endregion

        public FrmDataOwner()
        {
            InitializeComponent();
        }

        #region Disable/enable all buttons
        public void DisableButtons()
        {
            btnFileDecrypt.Enabled = false;
            btnFileEncrypt.Enabled = false;
            btnFileSelect.Enabled = false;
            /*btnTextDecrypt.Enabled = false;
            btnTextEncrypt.Enabled = false;*/
        }

        public void EnableButtons()
        {
            btnFileDecrypt.Enabled = true;
            btnFileEncrypt.Enabled = true;
            btnFileSelect.Enabled = true;
            /*btnTextDecrypt.Enabled = true;
            btnTextEncrypt.Enabled = true;*/
        }
        #endregion

        #region Check elasped time option before start encryption/decryption process.
        private void StartProcess()
        {
            /*if (rbContinuous.Checked == true)
            {
                timer1 = new System.Threading.Timer(timerDelegate, autoEvent, 0, 1000);
                wkr.RunWorkerAsync();
            }
            else if (rbResult.Checked == true)
            {*/
                DisableButtons();
                start = DateTime.Now;
                this.StartSelectedProcess();
                end = DateTime.Now;

                result = end - start;

                lblProgress.Text = "Elapsed Time : " + result.ToString();

                if (IsFile == true)
                {
                    MessageBox.Show(lblEncryptedFilename.Text + " File Encryption/Decryption is complete.");
                }

                EnableButtons();
            //}
        }
        #endregion

        #region Main method for start encryption and decryption
        private void StartSelectedProcess()
        {
            elapsed = 0;
            ClearProgressBar();

            if (IsEncryption == true)
            {
                if (IsFile == true)
                {
                    cryptographer = new Cryptographer(Algorithms.AES_File, IncrementProgress, InitProgress);
                    cryptographer.EncryptionStart(txtFile.Text.Replace("\\", "\\\\"), txtAlteredFile.Text.Replace("\\", "\\\\"), Module.encryptKey.ToUpper());
                }
                /*else
                {
                    txtEncrypted.Clear();
                    cryptographer = new Cryptographer((rbDES.Checked == true) ? Algorithms.DES : Algorithms.AES, IncrementProgress, InitProgress);
                    txtEncrypted.Text = cryptographer.EncryptionStart(txtPlainText.Text, txtKey.Text.ToUpper(), false);
                }*/
            }
            else
            {
                if (IsFile == true)
                {
                    cryptographer = new Cryptographer(Algorithms.AES_File, IncrementProgress, InitProgress);
                    cryptographer.DecryptionStart(txtFile.Text.Replace("\\", "\\\\"), txtAlteredFile.Text.Replace("\\", "\\\\"), Module.encryptKey.ToUpper());
                }
                /*else
                {
                    txtEncrypted.Clear();
                    cryptographer = new Cryptographer((rbDES.Checked == true) ? Algorithms.DES : Algorithms.AES, IncrementProgress, InitProgress);
                    txtEncrypted.Text = AES.BaseTransform.FromBinaryToText(cryptographer.DecryptionStart(txtPlainText.Text, txtKey.Text.ToUpper(), true));
                }*/
            }
        }
        #endregion

        #region encrypt, decrypt, file select button event method
        private void btnFileEncrypt_Click(object sender, EventArgs e)
        {
            if (!KeyCheck(Module.encryptKey) || !FileCheck())
            {
                return;
            }
            IsFile = true;
            IsEncryption = true;

            StartProcess();
        }

        private void btnFileDecrypt_Click(object sender, EventArgs e)
        {
            if (!KeyCheck(Module.encryptKey) || !FileCheck())
            {
                return;
            }
            IsFile = true;
            IsEncryption = false;

            StartProcess();            
        }

        private void btnTextEncrypt_Click(object sender, EventArgs e)
        {
            /*if (!KeyCheck(txtKey.Text))
            {
                return;
            }
            IsFile = false;
            IsEncryption = true;

            StartProcess();*/
        }

        private void btnTextDecrypt_Click(object sender, EventArgs e)
        {
            /*if (!KeyCheck(txtKey.Text))
            {
                return;
            }
            IsFile = false;
            IsEncryption = false;

            StartProcess();*/
        }

        private void btnFileSelect_Click(object sender, EventArgs e)
        {
            var file = new File();
            var AES = new AESalgorithm();
            LstKeywords = new List<Keyword>();

            file.FileIndex = Module.GetNewId("FileIndexing", "FileIndex", 3);
            file.UserName = Module.UserName;

            try
            {
                Clear();

                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    //read All text file to string
                    txtFile.Text = openFileDialog1.FileName;
                    txtAlteredFile.Text = openFileDialog1.FileName.Replace(".", "_2.");

                    file.Title = openFileDialog1.SafeFileName;
                    file.Url = openFileDialog1.FileName;

                    string Path = openFileDialog1.FileName.ToString();
                    int PathLen = Path.Length;
                    int PathLen_4 = Path.Length - 4;
                    string Ext = Path.Substring(PathLen_4, 4);
                    switch (Ext)
                    {
                        case ".pdf":
                            rchText.Text = Module.GetTextFromPDF(openFileDialog1.FileName);
                            file.Type = "pdf";
                            break;
                        case "docx":
                            bool close = Module.CloseWordDocument(openFileDialog1.FileName);
                            rchText.Text = Module.GetTextFromWord(openFileDialog1.FileName);
                            close = Module.CloseWordDocument(openFileDialog1.FileName);
                            file.Type = "docx";
                            break;
                        case ".txt":
                            rchText.Text = System.IO.File.ReadAllText(@openFileDialog1.FileName);
                            file.Type = "txt";
                            break;
                    }



                    //read text file to Array word by word
                    string[] words = rchText.Text.Split(' ');
                    file.FileContent = AES.Encrpt(rchText.Text, Module.encryptKey);
                    
                    //identify Keywords

                    for (int i = 0; i < words.Length; i++)
                    {
                        for (int j = i + 1; j < words.Length; j++)
                        {
                            if (words[i].Equals(words[j]) && words[i].Length>=3)
                            {
                                if (isNotInsertedKey(words[i]))
                                {
                                    rchKeyWords.Text += words[i];
                                    rchKeyWords.Text += " ";
                                }
                            }
                        }
                    }

                    //Get No of Keys

                    string[] KeyNo = rchKeyWords.Text.Split(' ');
                    int index = Module.GetNewId("KeywordIndexing", "Id", 4);
                    for (int i = 0; i < KeyNo.Length; i++)
                    {
                        if (KeyNo[i].Length >= 3)
                        {
                            var keyWord = new Keyword();
                            
                            int rank = GetRanking(KeyNo[i]);
                            rchKeyRepat.Text += KeyNo[i] + "=" + rank;
                            rchKeyRepat.Text += System.Environment.NewLine;

                            keyWord.Id = index++;
                            keyWord.FileIndex = file.FileIndex;
                            keyWord.KeyWord = KeyNo[i];
                            keyWord.Rank = rank;
                            LstKeywords.Add(keyWord);
                        }
                    }
                    InsertFile(file);
                    InsertKeyword(LstKeywords);
                    SearchData();
                }
                

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        
        
        private void Clear()
        {
            txtFile.Clear();
            txtAlteredFile.Clear();
            rchKeyWords.Clear();
            rchText.Clear();
            rchKeyRepat.Clear();
        }
        #endregion
        private bool isNotInsertedKey(string Key)
        {
            string[] Keys = rchKeyWords.Text.Split(' ');
            for (int i = 0; i < Keys.Length; i++)
            {
                if (Keys[i].ToUpper().Equals(Key.ToUpper()))
                       return false;
            }
            return true;
        }
        private int GetRanking(string Key)
        {
            string[] text = rchText.Text.Split(' ');
            int noOfKey = 0;
            for (int i = 0; i < text.Length; i++)
            {
                if (text[i].ToUpper().Equals(Key.ToUpper()))
                    noOfKey++;
            }
            return noOfKey;
        }
        private void InsertKeyword(List<Keyword> LstKeyword)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                using (var con = new SqlConnection(PublicClass.Module.ConString))
                {
                    var cmd = new SqlCommand();
                    cmd.Connection = con;
                    con.Open();
                    using (var transaction = con.BeginTransaction())
                    {
                        cmd.Transaction = transaction;
                        LstKeyword.InsertKeyword(cmd);
                        transaction.Commit();
                    }
                }
                Cursor = Cursors.Default;
                MessageBox.Show("Keyword Indexing Done!");
                //Clear();
            }
            
            catch (Exception ex)
            {
                this.Cursor = Cursors.Default;
                MessageBox.Show(ex.Message);
            }

        }
        private void InsertFile(File file)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                using (var con = new SqlConnection(PublicClass.Module.ConString))
                {
                    var cmd = new SqlCommand();
                    cmd.Connection = con;
                    con.Open();
                    using (var transaction = con.BeginTransaction())
                    {
                        cmd.Transaction = transaction;
                        file.InsertFile(cmd);
                        transaction.Commit();
                    }
                }
                Cursor = Cursors.Default;
                MessageBox.Show("File Indexing Done!");
                //Clear();
            }

            catch (Exception ex)
            {
                this.Cursor = Cursors.Default;
                MessageBox.Show(ex.Message);
            }

        }
        #region Checking method
        private bool FileCheck()
        {
            if (txtFile.Text == "")
            {
                MessageBox.Show("Plaese select a file for encryption/decryption");
                return false;
            }

            return true;
        }

        private bool KeyCheck(string key)
        {
            /*if (rbDES.Checked)
            {
                if (key.Length == 16)
                {
                    return true;
                }
                else
                {
                    MessageBox.Show("The key is must be 16-HexDecimal Length for DES algorithm");
                    return false;
                }
            }
            else
            {*/
                if (key.Length == 32)
                {
                    return true;
                }
                else
                {
                    MessageBox.Show("The key is must be 32-HexDecimal Length for AES algorithm");
                    return false;
                }
            //}
        }
        #endregion

        private void Form1_Load(object sender, EventArgs e)
        {
            //txtKey_File.MaxLength = 32;
            #region Initialize progressbar
            progressBar1.Maximum = 100;
            progressBar1.Step = 1;

            InitProgress += new ProgressInitHandler(Initialize);
            IncrementProgress += new ProgressEventHandler(increase);
            #endregion

            #region Initialize timer
            timerDelegate = new TimerCallback(this.timer1_Tick);
            autoEvent = new AutoResetEvent(false);
            #endregion

            #region Initialize BackgroundWorker for ecryption and decryption process
            wkr = new BackgroundWorker();
            wkr.DoWork += new DoWorkEventHandler(wkr_DoWork);
            wkr.RunWorkerCompleted += new RunWorkerCompletedEventHandler(wkr_RunWorkerCompleted);
            #endregion            
            SearchData();
        }
        private void SearchData()
        {
            var AES = new AESalgorithm();
            try
            {
                this.Cursor = Cursors.WaitCursor;
                dgv.Rows.Clear();

                using (var con = new SqlConnection(Module.ConString))
                {
                    var sda = new SqlDataAdapter("select * from FileIndexing where UserName=@UserName", con);

                    sda.SelectCommand.Parameters.AddWithValue("@UserName",Module.UserName);
                    System.Data.DataTable dt = new System.Data.DataTable();
                    sda.Fill(dt);

                    foreach (DataRow row in dt.Rows)
                    {

                        int i = dgv.Rows.Add(row["FileIndex"], row["Title"], AES.Decrpt(row["FileContent"].ToString(), Module.encryptKey), row["Date"], row["Type"], row["Url"]);

                    }

                }

                lblRowsCount.Text = "No of rows : " + dgv.Rows.Count.ToString();
                this.Cursor = Cursors.Default;
            }
            catch (Exception ex)
            {
                this.Cursor = Cursors.Default;
                MessageBox.Show(ex.Message);
            }
        }

        #region Progress bar event
        void increase(object sender, ProgressEventArgs e)
        {
            progressBar1.Increment(e.Increment);
        }

        void Initialize(object sender, ProgressInitArgs e)
        {
            progressBar1.Maximum = e.Maximum;
        }
        #endregion

        private void ClearProgressBar()
        {
            progressBar1.Value = 0;
        }

        #region BackgroundWorker Event
        void wkr_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            timer1.Dispose();

            if (IsFile == true)
            {
                MessageBox.Show(lblEncryptedFilename.Text + " File Encryption/Decryption is complete.");
            }

            EnableButtons();
        }

        void wkr_DoWork(object sender, DoWorkEventArgs e)
        {
            DisableButtons();
            this.StartSelectedProcess();
        }
        #endregion

        #region Timer Event
        public void timer1_Tick(object stateInfo)
        {
            this.Invoke(new MethodInvoker(delegate()
            {
                elapsed++;
                lblProgress.Text = "Elapsed Time : " + elapsed.ToString() + " sec.";
            }));
        }
        #endregion

        private void rbDES_CheckedChanged(object sender, EventArgs e)
        {
            //txtKey_File.MaxLength = 16;
          //txtKey.MaxLength = 16;
        }

        private void rbAES_CheckedChanged(object sender, EventArgs e)
        {
            //txtKey_File.MaxLength = 32;
            //txtKey.MaxLength = 32;
        }

        #region Check key value
        private void txtKey_File_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!IsHexaDecimal(e.KeyChar))
            {
                e.Handled = true;
            }
            else
            {
                e.Handled = false;
            }
        }

        private void txtKey_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!IsHexaDecimal(e.KeyChar))
            {
                e.Handled = true;
            }
            else
            {
                e.Handled = false;
            }
        }

        private bool IsHexaDecimal(char value)
        {
            if ((('0' <= value) && (value <= '9')) ||
                (('A' <= value) && (value <= 'F')) ||
                (('a' <= value) && (value <= 'f')) ||
                (8 == (int)value))
            {
                return true;
            }
            return false;
        }
        #endregion

        private void DGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgvColDelete.Index)
            {
                DeleteRecord(e.RowIndex);
            }
            else
                if (e.ColumnIndex == dgvcolOpen.Index)
                {
                    OpenFile(e.RowIndex);
                }
        }
        private void OpenFile(int rowIndex)
        {
            try
            {
                string path = dgv.Rows[rowIndex].Cells[dgvColUrl.Index].Value.ToString();
                Process.Start(@path);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }
        private void DeleteRecord(int rowIndex)
        {
            try
            {
                //Change the row color to red in the grid indicating a delete will occur 
                dgv.DefaultCellStyle.SelectionBackColor = Color.Red;

                dgv.Rows[rowIndex].ErrorText = "";
                #region Initialize the category object
                var file = new File();
                file.FileIndex = dgv.Rows[rowIndex].Cells[dgvColFileIndex.Index].Value.ToInt();

                #endregion

                this.Cursor = Cursors.WaitCursor;

                using (var con = new SqlConnection(Module.ConString))
                {
                    System.Data.DataTable dt = new System.Data.DataTable();
                    var sda =
                    new SqlDataAdapter(
                    "select *  from Ranking where FileId=@Id", con);
                    sda.SelectCommand.Parameters.AddWithValue("@Id", file.FileIndex);
                    sda.Fill(dt);
                    

                    var cmd = new SqlCommand();
                    cmd.Connection = con;
                    con.Open();

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        FileRepository.DeleteKeywordIndexing(dt.Rows[i]["KeyWordId"].ToInt(), cmd);
                    }


                    using (SqlTransaction transaction = con.BeginTransaction())
                    {
                        cmd.Transaction = transaction;
                        file.DeleteFile(cmd);
                        transaction.Commit();
                    }
                }
                MessageBox.Show("Record deleted!");
                dgv.DefaultCellStyle.SelectionBackColor = Color.LightGreen;
                this.Cursor = Cursors.Default;
                SearchData();
            }
            catch (Exception ex)
            {
                this.Cursor = Cursors.Default;
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            this.Close();
            var frm = new FrmDataUser();
            frm.Show();
        }
    }
}