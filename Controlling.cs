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
    public partial class Controlling : Form
    {
        string id_hardware = null;
        string nama_hardware = null;
        myDBConnection con = new myDBConnection();

        public Controlling()
        {
            InitializeComponent();
            con.Connect();
        }

        private void Controlling_Load(object sender, EventArgs e)
        {
            disconnect();
            comboBox1.Text = "-- Pilih Hardware --";
        }

        public void disconnect()
        {
            textBox1.BackColor = Color.Red;
            label1.Text = "Pilih Hardware";
            label2.Visible = false;
            label3.Visible = false;

            button1.Enabled = false;
            button2.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = false;
            button5.Enabled = false;
            button6.Enabled = false;
            button7.Enabled = false;
            button8.Enabled = false;
            button9.Enabled = false;
            button10.Enabled = false;
            button11.Enabled = false;
            button12.Enabled = false;

            btnMaju.Enabled = false;
            btnMundur.Enabled = false;
            btnKiri.Enabled = false;
            btnKanan.Enabled = false;
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
            }
            else
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

                button1.Enabled = true;
                button2.Enabled = true;
                button3.Enabled = true;
                button4.Enabled = true;
                button5.Enabled = true;
                button6.Enabled = true;
                button7.Enabled = true;
                button8.Enabled = true;
                button9.Enabled = true;
                button10.Enabled = true;
                button11.Enabled = true;
                button12.Enabled = true;

                btnMaju.Enabled = true;
                btnMundur.Enabled = true;
                btnKiri.Enabled = true;
                btnKanan.Enabled = true;
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

        private void btnMaju_Click(object sender, EventArgs e)
        {

        }

        private void btnKiri_Click(object sender, EventArgs e)
        {

        }

        private void btnKanan_Click(object sender, EventArgs e)
        {

        }

        private void btnMundur_Click(object sender, EventArgs e)
        {

        }

        private void btnMaju_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void btnMaju_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void btnMaju_MouseEnter(object sender, EventArgs e)
        {

        }

        private void btnMaju_MouseDown(object sender, MouseEventArgs e)
        {
            label2.Visible = true;
            label3.Visible = true;

            label3.Text = "Maju";
        }

        private void btnMaju_MouseUp(object sender, MouseEventArgs e)
        {
            label2.Visible = false;
            label3.Visible = false;
        }

        private void btnKiri_MouseUp(object sender, MouseEventArgs e)
        {
            label2.Visible = false;
            label3.Visible = false;
        }

        private void btnKiri_MouseDown(object sender, MouseEventArgs e)
        {
            label2.Visible = true;
            label3.Visible = true;

            label3.Text = "Kiri";
        }

        private void btnKanan_MouseDown(object sender, MouseEventArgs e)
        {
            label2.Visible = true;
            label3.Visible = true;

            label3.Text = "Kanan";
        }

        private void btnKanan_MouseUp(object sender, MouseEventArgs e)
        {
            label2.Visible = false;
            label3.Visible = false;
        }

        private void btnMundur_MouseDown(object sender, MouseEventArgs e)
        {
            label2.Visible = true;
            label3.Visible = true;

            label3.Text = "Mundur";
        }

        private void btnMundur_MouseUp(object sender, MouseEventArgs e)
        {
            label2.Visible = false;
            label3.Visible = false;
        }

        private void btnMaju_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void Controlling_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void Controlling_KeyUp(object sender, KeyEventArgs e)
        {

        }

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            
        }

        private void btnConnect_KeyDown(object sender, KeyEventArgs e)
        {
            if (textBox1.BackColor == Color.Green)
            {
                if (e.KeyCode == Keys.W)
                {
                    label2.Visible = true;
                    label3.Visible = true;

                    label3.Text = "Maju";
                }
                else if (e.KeyCode == Keys.A)
                {
                    label2.Visible = true;
                    label3.Visible = true;

                    label3.Text = "Kiri";
                }
                else if (e.KeyCode == Keys.S)
                {
                    label2.Visible = true;
                    label3.Visible = true;

                    label3.Text = "Mundur";
                }
                else if (e.KeyCode == Keys.D)
                {
                    label2.Visible = true;
                    label3.Visible = true;

                    label3.Text = "Kanan";
                }
            }
        }

        private void btnConnect_KeyUp(object sender, KeyEventArgs e)
        {
            label2.Visible = false;
            label3.Visible = false;
        }
    }
}
