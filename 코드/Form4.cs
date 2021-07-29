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
    

    public partial class Form4 : Form
    {
        string connect_info = "DATA SOURCE = 192.168.0.15/xe; User Id = MOVIE; password = 1234;";
        OracleConnection conn;
        OracleCommand comm;
        OracleDataAdapter adt;
        OracleCommand coa;
        OracleCommand coaa;
        DataSet data;
        Form2 f2;
        public static string ID2;
        public Form4()
        {
            InitializeComponent();
           
        }
        public Form4(Form2 form)
        {
            InitializeComponent();
            f2 = form;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            f1.Show();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            DataSet data = new DataSet();
            int count;

            string sql2 = "SELECT MOVIE, RATING FROM MEMBERSHIP WHERE ID = '" + f2.textBox1.Text + "'";
            string sql = "SELECT NAME FROM MEMBER WHERE ID = '" + f2.textBox1.Text + "'";
            string sql3 = "SELECT GENRE, COUNT(*) CNT FROM MEMBERSHIP WHERE ID= '" + f2.textBox1.Text + "'" +"GROUP BY GENRE ORDER BY CNT DESC";
            string sql4 = "SELECT TRUNC(AVG(RATING),1) FROM MEMBERSHIP WHERE ID ='"+f2.textBox1.Text+"'";
            
            conn = new OracleConnection(connect_info);
            coaa= new OracleCommand(sql4, conn);
            conn.Open();            
            adt = new OracleDataAdapter(sql2, conn);
            count = adt.Fill(data, "MEMBERSHIP");
            dataGridView1.DataSource = data;
            dataGridView1.DataMember = "MEMBERSHIP";
            comm = new OracleCommand(sql, conn);
            groupBox1.Text = comm.ExecuteScalar().ToString();
            coa = new OracleCommand(sql3, conn);
            label6.Text = count.ToString();
            label7.Text = coa.ExecuteScalar().ToString();
            label8.Text = coaa.ExecuteScalar().ToString();

            string sql5 = "SELECT MOVIE,RANK FROM BOX WHERE MOVIE NOT IN(SELECT MOVIE FROM MEMBERSHIP WHERE ID = '"+f2.textBox1.Text+"')";
            adt = new OracleDataAdapter(sql5, conn);
            adt.Fill(data, "BOX");
            dataGridView2.DataSource = data;
            dataGridView2.DataMember = "BOX";

            //grid();
          /*  label5.Text = dataGridView2.Rows[0].Cells[1].FormattedValue.ToString();*/

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form5 f5 = new Form5(f2);            
            f5.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {

            DataSet data = new DataSet();
            int count;

            string sql2 = "SELECT MOVIE, RATING FROM MEMBERSHIP WHERE ID = '" + f2.textBox1.Text + "'";
            
            conn = new OracleConnection(connect_info);
            conn.Open();
            adt = new OracleDataAdapter(sql2, conn);
            count = adt.Fill(data, "MEMBERSHIP");
            dataGridView1.DataSource = data;
            dataGridView1.DataMember = "MEMBERSHIP";
            
            label6.Text = count.ToString();
            string sql3 = "SELECT GENRE, COUNT(*) CNT FROM MEMBERSHIP WHERE ID= '" + f2.textBox1.Text + "'" + "GROUP BY GENRE ORDER BY CNT DESC";
            string sql4 = "SELECT TRUNC(AVG(RATING),1) FROM MEMBERSHIP WHERE ID ='" + f2.textBox1.Text + "'";
            conn = new OracleConnection(connect_info);
            coaa = new OracleCommand(sql4, conn);
            coa = new OracleCommand(sql3, conn);
            conn.Open();
            label7.Text = coa.ExecuteScalar().ToString();
            label8.Text = coaa.ExecuteScalar().ToString();
            string sql5 = "SELECT MOVIE,RANK FROM BOX WHERE MOVIE NOT IN(SELECT MOVIE FROM MEMBERSHIP WHERE ID = '" + f2.textBox1.Text + "')";
            adt = new OracleDataAdapter(sql5, conn);
            adt.Fill(data, "BOX");
            dataGridView2.DataSource = data;
            dataGridView2.DataMember = "BOX";

        }

        private void button4_Click(object sender, EventArgs e)
        {
           
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            label5.Text = dataGridView2.Rows[e.RowIndex].Cells[0].FormattedValue.ToString();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form7.ID = ID2;
            Form7.ti = label5.Text;
            Form7 f7 = new Form7(this);
            f7.Show();
        }
    }
}
