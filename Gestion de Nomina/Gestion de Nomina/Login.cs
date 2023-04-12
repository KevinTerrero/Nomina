using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gestion_de_Nomina
{
    public partial class Login : Form
    {

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
            string username = UserTxtBox.Text;
            string password = PasswordTxtBox.Text;
            if (UserTxtBox.Text == "")
            {
                MostrarError(UserTxtBox);
            }

            if (PasswordTxtBox.Text == "")
            {
                PasswordTxtBox.PasswordChar= '\0';
                MostrarError(PasswordTxtBox);
            }
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
    }
}
