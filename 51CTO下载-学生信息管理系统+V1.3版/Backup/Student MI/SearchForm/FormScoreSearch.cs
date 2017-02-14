using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Student_MI
{
    public partial class FormScoreManage : Form
    {
        public FormScoreManage()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormScoreManage_Load(object sender, EventArgs e)
        {
            FullListView("");
        }

        private void FullListView(string search)
        {
            this.lvScore.Items.Clear();
            try
            {
                DBHelper.con.Open();
                string sql = "";
                if (search == "")
                {
                    sql = "SELECT S.SNumber,S.SName,C.CName,SC.Score FROM Score as SC inner join Student as S on SC.SNumber=S.SNumber inner join Course as C on SC.CNumber=C.CNumber";
                }
                else
                {
                    sql = string .Format("SELECT S.SNumber,S.SName,C.CName,SC.Score FROM Score as SC inner join Student as S on SC.SNumber=S.SNumber inner join Course as C on SC.CNumber=C.CNumber WHERE S.SName LIKE '%{0}%' ",search);
                }
                SqlCommand cmd = new SqlCommand(sql, DBHelper.con);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    ListViewItem lviScore = new ListViewItem(dr["SNumber"].ToString());
                    lviScore.SubItems.Add(dr["SName"].ToString());
                    lviScore.SubItems.Add(dr["CName"].ToString());
                    lviScore.SubItems.Add(dr["Score"].ToString());

                    this.lvScore.Items.Add(lviScore);
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

        private void btnSearch_Click(object sender, EventArgs e)
        {
            FullListView(this.txtSearch.Text.Trim());
        }

        
    }
}
