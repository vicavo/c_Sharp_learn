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
    public partial class FormStudentSearch : Form
    {
        public FormStudentSearch()
        {
            InitializeComponent();
        }

        private void btnCha_Click(object sender, EventArgs e)
        {
            FullListView(this.txtStudent.Text.Trim());
        }

        private void btnColse_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormStudentSearch_Load(object sender, EventArgs e)
        {
            FullListView("");
        }
        private void FullListView(string search)
        {
            this.LvStudent.Items.Clear();
            try
            {
                DBHelper.con.Open();
                string sql = "";
                if (search == "")
                {
                    sql = "SELECT SNumber, SName, SSex, SAge, SEmail FROM Student";
                }
                else
                {
                    sql = string.Format("SELECT SNumber, SName, SSex, SAge, SEmail FROM Student WHERE SName LIKE '%{0}%' ", search);

                }
                SqlCommand cmd = new SqlCommand(sql, DBHelper.con);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    ListViewItem lvstu = new ListViewItem(dr["SNumber"].ToString());
                    lvstu.SubItems.Add(dr["SName"].ToString());
                    lvstu.SubItems.Add(dr["SSex"].ToString());
                    lvstu.SubItems.Add(dr["SAge"].ToString());
                    lvstu.SubItems.Add(dr["SEmail"].ToString());
                    this.LvStudent.Items.Add(lvstu);
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
