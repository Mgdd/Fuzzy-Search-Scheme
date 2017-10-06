using AES_Algorithm;
using PublicClass;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimpleCryptographer
{
    public partial class FrmDataUser : Form
    {

        private System.Data.DataTable dt;
        public FrmDataUser()
        {
            InitializeComponent();
        }
        private void SearchData(int KeyWordId, double fuzzyPercent)
        {
            var AES = new AESalgorithm();
            try
            {
                this.Cursor = Cursors.WaitCursor;
                

                using (var con = new SqlConnection(Module.ConString))
                {
                    var sda = new SqlDataAdapter("select Url,Title,FileContent,Keyword,[Rank],fuzzyPercent=@fuzzyPercent from SearchView where KeyWordId=@KeyWordId " +
                        " order by [Rank] desc", con);

                    sda.SelectCommand.Parameters.AddWithValue("@KeyWordId", KeyWordId);
                    sda.SelectCommand.Parameters.AddWithValue("@fuzzyPercent", fuzzyPercent);
                    System.Data.DataTable dt = new System.Data.DataTable();
                    sda.Fill(dt);

                    foreach (DataRow row in dt.Rows)
                    {

                        int i = dgv.Rows.Add(row["Url"], row["Title"], AES.Decrpt(row["FileContent"].ToString(), Module.encryptKey), 
                            row["KeyWord"].ToString(), row["Rank"], row["fuzzyPercent"]);

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

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            //SearchData();
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            this.Close();
            var frm = new FrmLogin();
            frm.Show();
        }
        
        private void GetData()
        {
            dgv.Rows.Clear();
            var dtFuzzy = new DataTable();
            dtFuzzy.Columns.Add("id", typeof(int));
            dtFuzzy.Columns.Add("Keyword", typeof(string));
            dtFuzzy.Columns.Add("Rank", typeof(int));
            dtFuzzy.Columns.Add("FuzzyPercent", typeof(double));

            try
            {
                Cursor = Cursors.WaitCursor;

                var dt1 = new System.Data.DataTable();
                var cmd = new SqlCommand();
                using (var con = new SqlConnection(Module.ConString))
                {
                    con.Open();
                    var sda =
                    new SqlDataAdapter(
                    "select * from KeywordView ", con);

                    sda.Fill(dt1);
                    for (int i = 0; i < dt1.Rows.Count; i++)
                    {
                        string KeyWord = dt1.Rows[i]["Keyword"].ToString();
                        int Id = dt1.Rows[i]["KeyWordId"].ToInt();
                        double fuzzyPer = Module.FuzzySearch(txtSearch.Text.Trim(), KeyWord);
                        if (fuzzyPer >= lblFuzzyPercent.Text.ToDouble())
                        {
                            dtFuzzy.Rows.Add(dt1.Rows[i]["KeyWordId"].ToInt(), dt1.Rows[i]["Keyword"].ToString(), dt1.Rows[i]["Rank"].ToString(), fuzzyPer);
                        }
                    }
                }
                Cursor = Cursors.Default;

                DataView dv = new DataView(dtFuzzy);
                dv.Sort = " FuzzyPercent Desc, Rank Desc";
                dtFuzzy = dv.ToTable();

                for (int i = 0; i < dtFuzzy.Rows.Count; i++)
                {
                    double FuzzyPercent = dtFuzzy.Rows[i]["FuzzyPercent"].ToDouble();
                    SearchData(dtFuzzy.Rows[i]["id"].ToInt(), FuzzyPercent);
                }
            }

            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                MessageBox.Show(ex.Message, "UST System", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            GetData();
        }

        private void FrmDataUser_Load(object sender, EventArgs e)
        {
            trkFuzzyPercent.Minimum = 0;
            trkFuzzyPercent.Maximum = 100;
            trkFuzzyPercent.Value = 50;
            InitializeLabels();
        }

        private void trkFuzzyPercent_Scroll(object sender, EventArgs e)
        {
            InitializeLabels();
        }
        private void InitializeLabels()
        {
            lblFuzzyPercent.Text = ((trkFuzzyPercent.Value.ToDouble()) / 100).ToString();
            lblPercent.Text = trkFuzzyPercent.Value + " %";
        }

        private void dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgvColOpen.Index)
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

        private void btnBack_Click(object sender, EventArgs e)
        {
            if (Module.IsDataOwner)
            {
                this.Close();
                var frm = new FrmDataOwner();
                frm.Show();
            }
            else
            {
                this.Close();
                var frm = new FrmLogin();
                frm.Show();
            }
        }
    }
}
