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
    public partial class FormSignUp : Form
    {
        myDBConnection con = new myDBConnection();

        public FormSignUp()
        {
            InitializeComponent();
            con.Connect();
        }

        private void btnSignUp_Click(object sender, EventArgs e)
        {
            signUpMethod();
        }

        public void signUpMethod()
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
                            MySqlCommand command = new MySqlCommand("sp_RegistrasiAkun", con.cn);
                            command.CommandType = CommandType.StoredProcedure;
                            command.Parameters.AddWithValue("Pusername", txtUsername.Text);
                            command.Parameters.AddWithValue("Ppassword", txtPassword.Text);
                            command.Parameters.AddWithValue("PkodePerusahaan", txtKodePerusahaan.Text);
                            MySqlDataAdapter da = new MySqlDataAdapter(command);
                            da.Fill(dt);
                            con.cn.Close();

                            MessageBox.Show("Akun berhasil di buat, silahkan login !", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            FormLogin fcm = new FormLogin();
                            this.Hide();
                            fcm.Show();
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

        private void FormSignUp_Load(object sender, EventArgs e)
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
    }
}
