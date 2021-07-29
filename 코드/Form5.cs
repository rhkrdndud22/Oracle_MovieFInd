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
    public partial class Form5 : Form
    {
        string connect_info = "DATA SOURCE = 192.168.0.15/xe; User Id = MOVIE; password = 1234;";
        OracleConnection conn;
        OracleCommand comm;
        OracleDataAdapter adt;

        DataSet data;
        Form2 f2;
        Form4 f4;
        string title;
        string genre;

        public Form5()
        {
            InitializeComponent();
        }


        public Form5(Form2 form)
        {
            f2 = form;
            InitializeComponent();
        }
        public Form5(Form4 form)
        {
            f4 = form;
            InitializeComponent();
        }

        public int radioBtn()
        {
            if (radioButton1.Checked) { return 1; }
            else if (radioButton2.Checked) { return 2; }
            else if (radioButton3.Checked) { return 3; }
            else if (radioButton4.Checked) { return 4; }
            else { return 5; }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            data = new DataSet();
            string sql = "INSERT INTO MEMBERSHIP VALUES ('" + f2.textBox1.Text + "','" + title + "','"  + genre + "','" + radioBtn() + "')";
            conn = new OracleConnection(connect_info);
            conn.Open();
            comm = new OracleCommand(sql, conn);
            comm.ExecuteNonQuery();

            this.Hide();

        }

        private void Form5_Load(object sender, EventArgs e)
        {
            string sql = "SELECT * FROM (select movie from movielist order by DBMS_RANDOM.RANDOM) WHERE ROWNUM <2";

            conn = new OracleConnection(connect_info);
            conn.Open();
            comm = new OracleCommand(sql, conn);
            label1.Text = comm.ExecuteScalar().ToString();
            title = label1.Text;
            string sql2 = "SELECT GENRE FROM MOVIELIST WHERE MOVIE = '" + title + "'";
            comm = new OracleCommand(sql2, conn);
            genre = comm.ExecuteScalar().ToString();


        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
