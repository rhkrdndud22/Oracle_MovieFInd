using Oracle.DataAccess.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Form3 : Form
    {
        string connect_info = "DATA SOURCE = 192.168.0.15/xe; User Id = MOVIE; password = 1234;";
        OracleConnection conn;
        OracleCommand comm;
        OracleDataAdapter adt;
        DataSet data = new DataSet();
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string id = textBox1.Text;
            string password = textBox2.Text;
            string name = textBox3.Text;
            string birth = textBox4.Text;

            string sql = "SELECT * FROM MEMBER WHERE ID = '" + id + "'";
            conn = new OracleConnection(connect_info);
            conn.Open();
            adt = new OracleDataAdapter(sql, conn);
            int row = adt.Fill(data, "MEMBER");

            if (row != 0)
            {
                MessageBox.Show("이미 가입된 ID입니다.");
            }
            else
            {
                string sql2 = "INSERT INTO MEMBER values('" + id + "','" + password + "','" + name + "','" + birth + "')";
                conn = new OracleConnection(connect_info);
                adt = new OracleDataAdapter(sql2, conn);
                adt.Fill(data, "member");
                conn = new OracleConnection(connect_info);
                conn.Open();

                MessageBox.Show("회원가입 완료");
                this.Hide();
            }









            

        }


    }
}
