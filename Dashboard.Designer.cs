
namespace AutoDigdaApplication
{
    partial class Dashboard
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.lblIDUser = new System.Windows.Forms.Label();
            this.lblUsername = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblPassword = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblPerusahaan = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(61, 71);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "ID User";
            // 
            // lblIDUser
            // 
            this.lblIDUser.AutoSize = true;
            this.lblIDUser.Location = new System.Drawing.Point(169, 71);
            this.lblIDUser.Name = "lblIDUser";
            this.lblIDUser.Size = new System.Drawing.Size(35, 13);
            this.lblIDUser.TabIndex = 1;
            this.lblIDUser.Text = "label2";
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.Location = new System.Drawing.Point(169, 119);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(35, 13);
            this.lblUsername.TabIndex = 3;
            this.lblUsername.Text = "label3";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(61, 119);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Username";
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new System.Drawing.Point(169, 167);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(35, 13);
            this.lblPassword.TabIndex = 5;
            this.lblPassword.Text = "label5";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(61, 167);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 13);
            this.label6.TabIndex = 4;
            this.label6.Text = "Password";
            // 
            // lblPerusahaan
            // 
            this.lblPerusahaan.AutoSize = true;
            this.lblPerusahaan.Location = new System.Drawing.Point(169, 222);
            this.lblPerusahaan.Name = "lblPerusahaan";
            this.lblPerusahaan.Size = new System.Drawing.Size(35, 13);
            this.lblPerusahaan.TabIndex = 7;
            this.lblPerusahaan.Text = "label7";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(61, 222);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(64, 13);
            this.label8.TabIndex = 6;
            this.label8.Text = "Perusahaan";
            this.label8.Click += new System.EventHandler(this.label8_Click);
            // 
            // Dashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblPerusahaan);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lblUsername);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblIDUser);
            this.Controls.Add(this.label1);
            this.Name = "Dashboard";
            this.Text = "Dashboard";
            this.Load += new System.EventHandler(this.Dashboard_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblIDUser;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblPerusahaan;
        private System.Windows.Forms.Label label8;
    }
}