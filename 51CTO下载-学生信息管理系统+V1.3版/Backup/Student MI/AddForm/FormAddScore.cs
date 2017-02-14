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
    public partial class FormAddScore : Form
    {
        public FormAddScore()
        {
            InitializeComponent();
        }

        private void FormAddScore_Load(object sender, EventArgs e)
        {
            fillcmb();
        }

        private void fillcmb()
        {
            try
            {
                DBHelper.con.Open();
                SqlCommand cmd = new SqlCommand("SELECT sname FROM student", DBHelper.con);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        this.cmbStudent.Items.Add(dr["sname"].ToString());
                    }
                }
                dr.Close();
                this.cmbStudent.SelectedIndex = 0;
                //------------------------------
                cmd.CommandText = "SELECT cname FROM course";
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        this.cmbCourse.Items.Add(dr["cname"].ToString());
                    }
                }
                dr.Close();
                this.cmbCourse.SelectedIndex = 0;
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

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            double score;
            try
            {
                score = double.Parse(this.txtScore.Text);
            }
            catch (Exception)
            {
                return;
            }
            int studentId = this.GetStudentId();
            int courseId = this.GetCourseId();

            try
            {
                DBHelper.con.Open();
                string sql = string.Format("INSERT INTO score(snumber,cnumber,score) VALUES ({0},{1},{2})", studentId, courseId, score);
                SqlCommand cmd = new SqlCommand(sql, DBHelper.con);
                int result = cmd.ExecuteNonQuery();
                if (result > 0)
                {
                    this.DialogResult = DialogResult.OK;
                    MessageBox.Show("添加成功!");
                }
                else
                {
                    MessageBox.Show("添加失败!");
                }
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

        private int GetStudentId()
        {
            //获取学生编号
            int studentId = 0;
            try
            {
                DBHelper.con.Open();
                string sql = string.Format("SELECT snumber FROM student WHERE sname='{0}'", this.cmbStudent.Text);
                SqlCommand cmd = new SqlCommand(sql, DBHelper.con);
                studentId = (int)cmd.ExecuteScalar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                DBHelper.con.Close();
            }
            return studentId;
        }

        private int GetCourseId()
        {
            //获取课程编号
            int courseId = 0;
            try
            {
                DBHelper.con.Open();
                string sql = string.Format("SELECT cnumber FROM course WHERE cname='{0}'", this.cmbCourse.Text);
                SqlCommand cmd = new SqlCommand(sql, DBHelper.con);
                courseId = (int)cmd.ExecuteScalar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                DBHelper.con.Close();
            }
            return courseId;
        }
    }
}
