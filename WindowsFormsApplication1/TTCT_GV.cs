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
    public partial class TTCT_GV : Form
    {
        private SqlConnection connect;
        string _connectectionString = "Data Source=A209PC37;Initial Catalog=QL_GV;Integrated Security=True";

        private string t1, t2, t3, t4, t5;
        public TTCT_GV()
        {
            InitializeComponent();
        }
        public TTCT_GV(string txt):this()
        {
            
            connect = new SqlConnection(_connectectionString);
            connect.Open();

            string query = "SELECT * FROM gv WHERE MaGV = '" + txt + "'";

            using (SqlCommand command = new SqlCommand(query, connect))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        // Đọc giá trị từ cột và hiển thị trong TextBox
                        t1 = reader["HoTen"].ToString();
                        t2 = reader["SDT"].ToString();
                        t3 = reader["GhiChu"].ToString();
                        t4 = reader["DVDD"].ToString();
                        t5 = reader["CS"].ToString();
                    }
                    textBox1.Text = t1;
                    textBox2.Text = t2;
                    textBox3.Text = t3;
                    textBox4.Text = t4;
                    textBox5.Text = t5;
                }
            }
            
            connect.Close();
            
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            textBox1.Text = t1;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            textBox2.Text = t2;
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            textBox3.Text = t3;
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            textBox4.Text = t4;
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            textBox5.Text = t5;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
