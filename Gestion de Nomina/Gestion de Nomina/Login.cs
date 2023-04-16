﻿using Agenda;
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
        int intentos = 0;
        int intentosNeg = 3;
        int segundos = 29;
        int bloqueo = 0;
        public string LabelText
        {
            get { return this.UserTxtBox.Text; }
            set { this.UserTxtBox.Text = value; }
        }

        public Login()
        {
            InitializeComponent();
            label.Hide();
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
            string rol = "";
            string username = UserTxtBox.Text;
            string password = PasswordTxtBox.Text;
            string fullLabel2 = "";
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
                SqlDataReader dr =con.DataReader("select * from Users where usuario='" + username + "'");
                if (dr.Read())
                {
                    Password = dr.GetString(4);
                    string user = dr.GetString(3);
                    rol = dr.GetString(5);
                    fullLabel2 = "Rol: " + rol;
                    users.UserName = user;
                    Exists = true;
                }
                if (Exists)
                {
                    if (Cryptography.Decrypt(Password).Equals(PasswordTxtBox.Text))
                    {
                        MessageBox.Show("Bienvenido, " + username );
                        Dashboard dashboard = new Dashboard(fullLabel, fullLabel2);
                        dashboard.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Ha introducido datos incorrectos");
                        BlockUser();
                    }

                }
                else
                {
                    MessageBox.Show("Ha introducido datos incorrectos");
                        BlockUser();
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
        private void MostrarTodo()
        {
            TimerLb.Enabled = true;
            timer1.Start();
            label.Show();
            SubmitBtn.Enabled = false;
            TimerLb.Show();
        }
        private void BlockUser()
        {
            intentos++;
            intentosNeg--;
            label1.Show();
            label1.Text = "Intentos restantes: " + intentosNeg;

            
            if (intentos == 3)
            { //default 30seg
                if (bloqueo == 1)
                {
                    segundos = 59; //1min
                    MostrarTodo();

                }
                if (bloqueo == 2)
                {
                    segundos = 179; //3min
                    MostrarTodo();

                }
                if (bloqueo == 3)
                {
                    segundos = 299; //5min
                    MostrarTodo();

                }
                if (bloqueo > 3)
                {
                    segundos = 1999; //30min
                    MostrarTodo();
                }
                label.Show();
                TimerLb.Enabled = true;
                timer1.Start();
                SubmitBtn.Enabled = false;
                UserTxtBox.Enabled = false;
                PasswordTxtBox.Enabled = false;
                TimerLb.Show();
            }

        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            TimerLb.Text = "Intente otra vez en: " + segundos--.ToString() + " segundos";
            
            if (segundos < 0)
            {
                bloqueo++;
                intentos = 0;
                intentosNeg = 3;
                segundos = 29;
                TimerLb.Hide();
                label1.Hide();
                label.Hide();
                timer1.Stop();
                UserTxtBox.Enabled = true;
                PasswordTxtBox.Enabled = true;
                SubmitBtn.Enabled = true;
                Clear(PasswordTxtBox);
                PasswordTxtBox.PasswordChar = '*';
                PasswordTxtBox.ForeColor = Color.Black;
                Clear(UserTxtBox);
                UserTxtBox.ForeColor = Color.Black;
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
