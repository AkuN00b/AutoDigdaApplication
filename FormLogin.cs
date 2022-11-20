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
    public partial class FormLogin : Form
    {
        myDBConnection con = new myDBConnection();

        public FormLogin()
        {
            InitializeComponent();
            con.Connect();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            loginMethod();
        }

        public void loginMethod()
        {
            if (txtUsername.Text == "" || txtPassword.Text == "" || txtKodePerusahaan.Text == "")
            {
                MessageBox.Show("Username atau Password atau Kode Perusahaan tidak boleh kosong!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (!(txtPassword.Text.Length < 7))
                {
                    DataTable dts = new DataTable();
                    MySqlCommand commands = new MySqlCommand("sp_GetPerusahaanByID", con.cn);
                    commands.CommandType = CommandType.StoredProcedure;
                    commands.Parameters.AddWithValue("PkodePerusahaan", txtKodePerusahaan.Text);
                    MySqlDataAdapter das = new MySqlDataAdapter(commands);
                    das.Fill(dts);
                    con.cn.Close();

                    if (dts.Rows.Count != 0)
                    {
                        try
                        {
                            con.cn.Open();
                            DataTable dt = new DataTable();
                            MySqlCommand command = new MySqlCommand("sp_Login", con.cn);
                            command.CommandType = CommandType.StoredProcedure;
                            command.Parameters.AddWithValue("Pusername", txtUsername.Text);
                            command.Parameters.AddWithValue("Ppassword", txtPassword.Text);
                            command.Parameters.AddWithValue("PkodePerusahaan", txtKodePerusahaan.Text);
                            MySqlDataAdapter da = new MySqlDataAdapter(command);
                            da.Fill(dt);
                            con.cn.Close();

                            if (dt.Rows.Count != 0)
                            {
                                string[] detail_user = { dt.Rows[0][0].ToString(), dt.Rows[0][1].ToString(), dt.Rows[0][2].ToString(), dt.Rows[0][3].ToString(), dt.Rows[0][4].ToString() };
                                MessageBox.Show("Selamat Datang di Aplikasi AutoDigda", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                Dashboard fcm = new Dashboard(detail_user);
                                this.Hide();
                                fcm.Show();
                            }
                            else
                            {
                                MessageBox.Show("Username atau Password atau Kode Perusahaan mungkin salah!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error" + ex);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Kode Perusahaan tidak sesuai !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Password anda kurang dari 8 karakter !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void FormLogin_Load(object sender, EventArgs e)
        {
            txtPassword.PasswordChar = '*';
        }

        private void cbShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            if (cbShowPassword.Checked)
            {
                txtPassword.PasswordChar = '\0';
            }
            else
            {
                txtPassword.PasswordChar = '*';
            }
        }

        private void btnSignUp_Click(object sender, EventArgs e)
        {
            FormSignUp fcm = new FormSignUp();
            this.Hide();
            fcm.Show();
        }
    }
}
