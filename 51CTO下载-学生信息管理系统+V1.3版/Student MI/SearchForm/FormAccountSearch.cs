using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Student_MI.SearchForm
{
    public partial class FormAccountSearch : Form
    {
        public FormAccountSearch()
        {
            InitializeComponent();
        }

        private void btnCha_Click(object sender, EventArgs e)
        {
            FullListView(this.txtAccount.Text.Trim());
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormAccountSearch_Load(object sender, EventArgs e)
        {
            FullListView("");
        }

        private void FullListView(string search)
        {
            this.LvAccount.Items.Clear();
            try
            {
                DBHelper.con.Open();
                string sql = "";
                if (search == "")
                {
                    sql = "SELECT   username, password, type FROM Admin";
                }
                else
                {
                    sql = string.Format("SELECT username, password, type FROM Admin WHERE username LIKE '%{0}%' ", search);

                }
                SqlCommand cmd = new SqlCommand(sql, DBHelper.con);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    ListViewItem lvAccount = new ListViewItem(dr["username"].ToString());
                    lvAccount.SubItems.Add(dr["password"].ToString());
                    lvAccount.SubItems.Add(dr["type"].ToString());
                    this.LvAccount.Items.Add(lvAccount);
                }
                dr.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                DBHelper.con.Close();
            }
        }
    }
}
