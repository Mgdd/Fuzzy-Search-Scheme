using AES_Algorithm;
using PublicClass;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimpleCryptographer
{
    public partial class FrmDataUser : Form
    {
        public FrmDataUser()
        {
            InitializeComponent();
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
                    var sda = new SqlDataAdapter("select Title,FileContent,Keyword,[Rank] from SearchView where FuzzyWord=@FuzzyWord"+
                        " group by Title,FileContent,Keyword,[Rank] order by [Rank] desc", con);

                    sda.SelectCommand.Parameters.AddWithValue("@FuzzyWord", AES.Encrpt(txtSearch.Text.Trim(), Module.encryptKey));
                    System.Data.DataTable dt = new System.Data.DataTable();
                    sda.Fill(dt);

                    foreach (DataRow row in dt.Rows)
                    {

                        int i = dgv.Rows.Add(row["Title"], AES.Decrpt(row["FileContent"].ToString(), Module.encryptKey), AES.Decrpt(row["KeyWord"].ToString()
                            , Module.encryptKey), row["Rank"]);

                    }

                }

                lblRowsCount.Text = "عدد السجلات : " + dgv.Rows.Count.ToString();
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
            SearchData();
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            this.Close();
            var frm = new FrmLogin();
            frm.Show();
        }
    }
}
