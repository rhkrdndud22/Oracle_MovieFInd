using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.DataAccess.Client;

namespace WindowsFormsApp2
{
    public partial class Form2 : Form
    {
        string connect_info = "DATA SOURCE = 192.168.0.15/xe; User Id = MOVIE; password = 1234;";
        OracleConnection conn;
        OracleCommand comm;
        OracleDataAdapter adt;
        DataSet data = new DataSet();
        private Form6 form5;
        
        public Form2()
        {
           

       





            InitializeComponent();
        }

        public Form2(Form6 form5)
        {
            this.form5 = form5;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataSet data = new DataSet();
            
            string id = textBox1.Text;
            string password = textBox2.Text;
            string sql = "SELECT * FROM MEMBER WHERE ID = '"+ id +"'";
            string sql2 = "SELECT PASSWORD FROM MEMBER WHERE ID = '" + id + "'";
            conn = new OracleConnection(connect_info);
            conn.Open();
            adt = new OracleDataAdapter(sql, conn);
            int row = adt.Fill(data, "MEMBER");
           
            if (row == 0)
            {
                MessageBox.Show("등록되지 않은 ID입니다.");
            }
            else
            {
                comm = new OracleCommand(sql2, conn);
                object scalarValue = comm.ExecuteScalar();
                string psword = scalarValue.ToString();
                if (psword == password)
                {
                    MessageBox.Show("로그인 성공");
                    this.Hide();
                    Form4 f4 = new Form4(this);
                    Form6 f5 = new Form6(this);
                    Form1.ID2 = id;
                    Form7.ID = id;
                    Form4.ID2 = id;
                    f4.Show();
                }
                else
                {
                    MessageBox.Show("잘못된 비밀번호입니다.");
                }
            }
            


        }
        /*public string info()
        {
            return textBox1.Text;
        }*/
        private void label1_Click(object sender, EventArgs e)
        {
            Form3 f3 = new Form3();
            f3.Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
