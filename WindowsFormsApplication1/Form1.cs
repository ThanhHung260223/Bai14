using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        private string txt;
        public Form1()
        {
            InitializeComponent();
        }

        private SqlConnection connect;
        string _connectectionString = "Data Source=A209PC37;Initial Catalog=QL_GV;Integrated Security=True";

        private void button2_Click(object sender, EventArgs e)
        {
            TTCT_GV f = new TTCT_GV(txt);
            f.Show();
        }

        private void Hienthi()
        {
            connect = new SqlConnection(_connectectionString);
            connect.Open();
            string selectString;
            selectString = "select * from gv";
            SqlDataAdapter da = new SqlDataAdapter(selectString, connect);
            DataTable dataTable = new DataTable();

            da.Fill(dataTable);
            dataGridView1.DataSource = dataTable;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public void cb(){
            string selectString1 = "SELECT  CS, DVDD FROM gv";
            SqlDataAdapter da1 = new SqlDataAdapter(selectString1, connect);
            DataTable dataTable1 = new DataTable();
            da1.Fill(dataTable1);

            // Set the DataTable as the data source for the ComboBox
            comboBox1.DataSource = dataTable1;
            comboBox2.DataSource = dataTable1;
            comboBox2.DisplayMember = "DVDD";
            comboBox1.DisplayMember = "CS";
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            Hienthi();
            cb();
        }


        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int numrow;
            numrow = e.RowIndex;
            comboBox1.Text = dataGridView1.Rows[numrow].Cells[5].Value.ToString();
            comboBox2.Text = dataGridView1.Rows[numrow].Cells[4].Value.ToString();
            textBox1.Text = dataGridView1.Rows[numrow].Cells[0].Value.ToString();
            txt = textBox1.Text;
        }

    }
}
