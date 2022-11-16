using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace AutoDigdaApplication
{
    public partial class UjiCobaKoneksiphpMyAdmin : Form
    {
        myDBConnection con = new myDBConnection();
        MySqlCommand command;
        MySqlDataAdapter da;
        DataTable dt;

        public UjiCobaKoneksiphpMyAdmin()
        {
            InitializeComponent();
            con.Connect();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                con.cn.Open();
                command = new MySqlCommand("SELECT * FROM perusahaan", con.cn);
                command.ExecuteNonQuery();

                dt = new DataTable();
                da = new MySqlDataAdapter(command);
                da.Fill(dt);
                dataGridView1.DataSource = dt.DefaultView;

                con.cn.Close();
            } catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void UjiCobaKoneksiphpMyAdmin_Load(object sender, EventArgs e)
        {

        }
    }
}
