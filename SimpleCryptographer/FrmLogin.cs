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
    public partial class FrmLogin : Form
    {
        public System.Data.DataTable dt;
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;

                dt = new System.Data.DataTable();
                var cmd = new SqlCommand();
                using (var con = new SqlConnection(Module.ConString))
                {
                    con.Open();
                    var sda =
                    new SqlDataAdapter(
                    "select *  from Users where [UserName]='"+txtUserName.Text.Trim()+"' and [Password]='"+txtPassword.Text.Trim()+"'", con);
                    //sda.SelectCommand.Parameters.AddWithValue("@FileIndex", FileIndex);

                    sda.Fill(dt);
                    if (dt.Rows.Count > 0 && dt.Rows[0]["IsDataOwner"].ToString().Equals("True"))
                    {
                        Module.UserName = dt.Rows[0]["UserName"].ToString();
                        Module.IsDataOwner = true;
                        this.Hide();
                        var frmDataOwner = new FrmDataOwner();
                        frmDataOwner.Show();
                    }
                    else
                        if (dt.Rows.Count > 0 && dt.Rows[0]["IsDataOwner"].ToString().Equals("False"))
                        {
                            MessageBox.Show("under development");
                        }
                    else
                    {
                        MessageBox.Show("error user name or password");
                    }
                        
                }
                Cursor = Cursors.Default;
            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                MessageBox.Show(ex.Message, "error ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}