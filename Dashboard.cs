using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutoDigdaApplication
{
    public partial class Dashboard : Form
    {
        public Dashboard(string[] informasiUser)
        {
            InitializeComponent();



            lblIDUser.Text = informasiUser[0];
            lblUsername.Text = informasiUser[1];
            lblPassword.Text = informasiUser[2];
            lblPerusahaan.Text = informasiUser[4];
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }
    }
}
