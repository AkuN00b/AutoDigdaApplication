using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace AutoDigdaApplication
{
    public partial class Speedometer : Form
    {
        string id_hardware = null;
        string nama_hardware = null;
        myDBConnection con = new myDBConnection();

        public Speedometer()
        {
            InitializeComponent();
            con.Connect();
        }

        private void Speedometer_Load(object sender, EventArgs e)
        {
            disconnect();
            comboBox1.Text = "-- Pilih Hardware --";
        }

        public void disconnect()
        {
            textBox1.BackColor = Color.Red;
            label1.Text = "Pilih Hardware";
            aGauge1.Value = 0;
            aGauge2.Value = 0;
            aGauge3.Value = 0;
            aGauge4.Value = 0;
            aGauge5.Value = 0;
            aGauge6.Value = 0;
            aGauge7.Value = 0;
        }

        public void loadComboBoxHardware()
        {
            MySqlCommand commands = new MySqlCommand("sp_GetHardware", con.cn);
            commands.CommandType = CommandType.StoredProcedure;
            MySqlDataAdapter da = new MySqlDataAdapter(commands);

            DataTable dt = new DataTable();
            da.Fill(dt);
            con.cn.Close();

            comboBox1.DataSource = dt;
            comboBox1.DisplayMember = "nama";
            comboBox1.ValueMember = "id";
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            if (id_hardware == null && nama_hardware == null)
            {
                MessageBox.Show("Pilih Hardware Terlebih Dahulu", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } else
            {
                textBox1.BackColor = Color.Green;
                label1.Text = nama_hardware;

                DataTable dts = new DataTable();
                MySqlCommand commands = new MySqlCommand("sp_GetMonitoring", con.cn);
                commands.CommandType = CommandType.StoredProcedure;
                commands.Parameters.AddWithValue("Pid_hardware", id_hardware);
                MySqlDataAdapter das = new MySqlDataAdapter(commands);
                das.Fill(dts);
                con.cn.Close();

                aGauge1.Value = float.Parse(dts.Rows[0][1].ToString());
                aGauge2.Value = float.Parse(dts.Rows[0][2].ToString());
                aGauge3.Value = float.Parse(dts.Rows[0][3].ToString());
                aGauge4.Value = float.Parse(dts.Rows[0][4].ToString());
                aGauge5.Value = float.Parse(dts.Rows[0][5].ToString());
                aGauge6.Value = float.Parse(dts.Rows[0][6].ToString());
                aGauge7.Value = float.Parse(dts.Rows[0][7].ToString());
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            id_hardware = comboBox1.SelectedValue.ToString();
            nama_hardware = comboBox1.Text;
        }

        private void btnDisconnect_Click(object sender, EventArgs e)
        {
            disconnect();
        }

        private void comboBox1_MouseClick(object sender, MouseEventArgs e)
        {
            loadComboBoxHardware();
        }
    }
}
