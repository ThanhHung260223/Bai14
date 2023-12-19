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
using WindowsFormsApplication1;

namespace WindowsFormsApplication1
{
    public partial class ketnoi : Form
    {
        public ketnoi()
        {
            InitializeComponent();
        }

        private SqlConnection connect;
        

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //string tenmay = txtTenmay.Text;
            //string tencsdl = txtTencsdl.Text;
            string _connectectionString = "Data Source=";
            _connectectionString = _connectectionString + txtTenmay.Text + ";Initial Catalog=" + txtTencsdl.Text + ";Integrated Security=True";
            connect = new SqlConnection(_connectectionString);
            if (connect.State != ConnectionState.Open)
            {
                connect.Open();
                MessageBox.Show("Kết nối database thành công");
                Form1 f = new Form1();
                f.Show();
            }
            else
                MessageBox.Show("Kết nối database thất bại");
        }
    }
}
