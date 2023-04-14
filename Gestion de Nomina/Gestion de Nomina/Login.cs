using Agenda;
using Attendance;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gestion_de_Nomina
{

    
    public partial class Login : Form
    {


        public string LabelText
        {
            get { return this.UserTxtBox.Text; }
            set { this.UserTxtBox.Text = value; }
        }

        public Login()
        {
            InitializeComponent();
            
        }

        private void Clear(TextBox t)
        {
            t.Clear();
        }

        private void MostrarError(TextBox t)
        {
            t.Text = "Tiene que llenar este campo";
            t.ForeColor = System.Drawing.Color.Red;


        }

        private void UserValue()
        {
            Users users = new Users();
            ConnectionClass con = new ConnectionClass();
            string Password = "";
            bool Exists = false;
            string username = UserTxtBox.Text;
            string password = PasswordTxtBox.Text;
            string fullLabel = "Usuario: " + username;
            if (UserTxtBox.Text == "")
            {
                MostrarError(UserTxtBox);
            }

            if (PasswordTxtBox.Text == "")
            {
                PasswordTxtBox.PasswordChar= '\0';
                MostrarError(PasswordTxtBox);
            }

            
                con.OpenConection();
                SqlDataReader dr =con.DataReader("select * from Usuarios where usuario='" + username + "'");
                if (dr.Read())
                {
                    Password = dr.GetString(2);
                    string user = dr.GetString(1);
                    users.UserName = user;
                    Exists = true;
                }
                if (Exists)
                {
                    if (Cryptography.Decrypt(Password).Equals(PasswordTxtBox.Text))
                    {
                        MessageBox.Show("Bienvenido, " + username );
                        Dashboard dashboard = new Dashboard(fullLabel);
                        dashboard.Show();
                        
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Ha introducido datos incorrectos");
                    }

                }
                else
                {
                    MessageBox.Show("Ha introducido datos incorrectos");
                }
                con.CloseConnection();

        }

        private void SubmitBtn_Click(object sender, EventArgs e)
        {

            UserValue();
        }

        private void UserTxtBox_MouseDown(object sender, MouseEventArgs e)
        {
            Clear(UserTxtBox);
            UserTxtBox.ForeColor = Color.Black;
        }

        private void PasswordTxtBox_MouseDown(object sender, MouseEventArgs e)
        {
            Clear(PasswordTxtBox);
            PasswordTxtBox.PasswordChar = '*';
            PasswordTxtBox.ForeColor = Color.Black;
        }


        private void EnterPressed(object sender, EventArgs e)
        {
            UserValue();
        }

        private void CloseProgram()
        {
            this.Close();
        }

    }
}
