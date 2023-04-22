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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Gestion_de_Nomina
{
    public partial class UsuariosMant : Form
    {
        public int Id;
        public string User;
        public string usuario;
        public string Rol;
        public string Accion;
        public string Nombre;
        public DateTime fecha = DateTime.Now;
        Login log = new Login();
        public UsuariosMant(string rol, string username, int id, DateTime fecha, string accion)
        {

            InitializeComponent();
            Rol = rol;
            User = username;
            Accion = accion;
            Id = id;
            fecha = DateTime.Now;
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
            string Nombre = txtNombre.Text;
            string Apellido = txtApellido.Text;
            string ConfirmarPW = txtConfirmar.Text;
            string Password = txtConfirmar.Text;
            string rol  = txtRol.Text;
            string username = txtUsuario.Text;
            usuario = username;
            con.OpenConection();
            SqlDataReader dr = con.DataReader("select * from Users where usuario='" + username + "'");


            if (txtUsuario.Text == "")
            {
                MostrarError(txtUsuario);
            }
            if (txtContraseña.Text == "")
            {
                txtContraseña.PasswordChar = '\0';
                MostrarError(txtContraseña);
            }
            if (txtConfirmar.Text == "")
            {
                txtConfirmar.PasswordChar = '\0';
                MostrarError(txtConfirmar);
            }
            if (txtNombre.Text == "")
            {
                MostrarError(txtNombre);

            }
            if (txtApellido.Text == "")
            {
                MostrarError(txtApellido);

            }
            if (txtRol.SelectedIndex == -1)
            {
                MessageBox.Show("Tiene que elegir un rol");
            }
            if (txtContraseña.Text != txtConfirmar.Text)
            {
                MessageBox.Show("Las contraseñas tienen que coincidir");
            }
            
            else if (dr.Read())
            {
                MessageBox.Show("Este usuario ya está registrado en nuestro sistema, por favor, intente de nuevo");
            }
            else
            {
                 
                 string EncPassword = Cryptography.Encrypt(txtContraseña.Text.ToString());   // Passing the Password to Encrypt method and the method will return encrypted string and stored in Password variable.  

                 con.OpenConection();
                 con.ExecuteQueries("Insert into Users (Nombre,Apellido,Usuario,Contraseña,Rol)" +
                     " values('" + Nombre + "','" + Apellido + "','" + username + "','" + EncPassword + "','" + rol +"')");
                 con.CloseConnection();
                 MessageBox.Show("Usuario registrado con exito");
                    
            }

        }

        private void MostrarUsuarios()
        {
            SqlConnection cn = new SqlConnection("Data Source= localhost; Initial Catalog = Nomina; Integrated Security = True");
            string query = "Select * from Users";
            SqlDataAdapter adaptador = new SqlDataAdapter(query, cn);
            DataTable dt = new DataTable();
            adaptador.Fill(dt);
            dataGridView1.DataSource = dt;
        }
        
        private void Clear(TextBox t)
        {
            t.Clear();
        }

        private void GuardarBtn(object sender, EventArgs e)
        {
                
                UserValue();
                MostrarUsuarios();
                Accion = "Guardó al usuario " + usuario;
                log.GuardarLog(Id, User, Rol, Accion, fecha);

        }

        private void UsuariosMant_Load(object sender, EventArgs e)
        {
            MostrarUsuarios();
        }

        private void linklblmenu_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
        }

        private void EliminarUser(int id)
        {
            ConnectionClass con = new ConnectionClass();
            con.OpenConection();
            con.ExecuteQueries("DELETE FROM USERS WHERE ID ='" + txtCodigo.Text + "'");
            con.CloseConnection();
        }

        private void limpiarCampos()
        {
            txtCodigo.Clear();
            txtNombre.Clear();
            txtApellido.Clear();
            txtContraseña.Clear();
            txtConfirmar.Clear();
            txtUsuario.Clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (txtCodigo.Text == "")
            {
                MessageBox.Show("Tiene que elegir un usuario");
            }
            else
            {

                if (MessageBox.Show("¿Eliminar Registro?", "Eliminar Registro", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    if (txtCodigo.Text == "")
                    {
                        MessageBox.Show("Tiene que introducir un valor");
                    }
                    else
                    {
                        ConnectionClass con = new ConnectionClass();
                        con.OpenConection();
                        SqlDataReader dr = con.DataReader("select * from Users where ID='" + txtCodigo.Text + "'");
                        if (dr.Read())
                        {
                            usuario = dr.GetString(3);
                            Accion = "Eliminó al usuario " + usuario;
                            log.GuardarLog(Id, User, Rol, Accion, fecha);
                            EliminarUser(Convert.ToInt32(txtCodigo.Text));
                            MessageBox.Show("Registro eliminado exitosamente!");
                            MostrarUsuarios();
                        }
                        else
                        {
                            MessageBox.Show("Valor no encontrado");
                        }

                    }

                    
                }
                else
                {
                    MessageBox.Show("Registro no eliminado");
                    limpiarCampos();
                }
                

            }
        }


        private void ActualizarUsuario()
        {
            ConnectionClass con = new ConnectionClass();
            string Codigo = txtCodigo.Text;
            string Nombre = txtNombre.Text;
            string Apellidos = txtApellido.Text;
            string Usuario = txtUsuario.Text;
            usuario = Usuario;
            string EncPassword = Cryptography.Encrypt(txtContraseña.Text.ToString());   // Passing the Password to Encrypt method and the method will return encrypted string and stored in Password variable.  
            string Rol = txtRol.Text;
            

            con.OpenConection();
            con.ExecuteQueries("update Users SET Nombre='" + Nombre + "', Apellido='" + Apellidos +
                "', Usuario= '" + Usuario  + "', Rol= '" + Rol + "' WHERE ID= " + Codigo);
            MessageBox.Show("Usuario actualizado");
            Accion = "Actualizó al usuario " + usuario;
            log.GuardarLog(Id, User, Rol, Accion, fecha);
            MostrarUsuarios();
            con.CloseConnection();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            limpiarCampos();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtNombre.Text))
            {
                MessageBox.Show("Debe llenar todos los campos");
            }
            else if (string.IsNullOrEmpty(txtApellido.Text))
            {
                MessageBox.Show("Debe llenar todos los campos");
            }
            else if (string.IsNullOrEmpty(txtCodigo.Text))
            {
                MessageBox.Show("Debe llenar todos los campos");
            }
            else if (string.IsNullOrEmpty(txtUsuario.Text))
            {
                MessageBox.Show("Debe llenar todos los campos");
            }
            else if (string.IsNullOrEmpty(txtRol.Text))
            {
                MessageBox.Show("Debe llenar todos los campos");
            }
            else
            {
                try
                {
                    
                    ActualizarUsuario();
                }
                catch (Exception ex)
                {

                    throw ex;
                }
            }
        }

        private void FilterBtn_Click(object sender, EventArgs e)
        {
            string filterUser = filterTxtBox.Text;
            SqlConnection cn = new SqlConnection("Data Source= localhost; Initial Catalog = Nomina; Integrated Security = True");
            string query = "select * from Users where ID = " + filterUser; ;
            SqlDataAdapter adaptador = new SqlDataAdapter(query, cn);
            DataTable dt = new DataTable();
            adaptador.Fill(dt);
            dataGridView1.DataSource = dt;
        }
    }
}
