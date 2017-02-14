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
    public partial class FormCourseSearch : Form
    {
        public FormCourseSearch()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FullListView(this.txtCourse.Text.Trim());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormCourseSearch_Load(object sender, EventArgs e)
        {
             FullListView("");
        }
        private void FullListView(string search)
        {
         this.lvCourse.Items.Clear();
            try
            {
                DBHelper.con.Open();
                string sql = "";
                if (search == "")
                {
                    sql = "SELECT   CNumber, CName FROM Course";
                }
                else
                {
                    sql = string.Format("SELECT   CNumber, CName FROM Course WHERE CName LIKE '%{0}%' ", search);
               
                }
                SqlCommand cmd = new SqlCommand(sql, DBHelper.con);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    ListViewItem lvCourse = new ListViewItem(dr["CNumber"].ToString());
                    lvCourse.SubItems.Add(dr["CName"].ToString());
                    this.lvCourse.Items.Add(lvCourse);
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
