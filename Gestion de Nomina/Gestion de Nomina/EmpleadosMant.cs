using Agenda;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace Gestion_de_Nomina
{
    public partial class EmpleadosMant : Form
    {
        ConnectionClass con = new ConnectionClass();
        string text;
        string text2;
        public EmpleadosMant()
        {
            InitializeComponent();
            
        }
        private void GuardarEmpleados()
        {
            string Cedula = txtCedula.Text;
            string Nombre = txtNombre.Text;
            string Apellidos = txtApellido.Text;
            string Direccion = txtDireccion.Text;
            string Telefono = txtTelefono.Text;
            string Correo = txtCorreo.Text;
            string Cargo = txtCargo.Text ;
            string Departamento = txtDepartamento.Text;
            string Salario = txtSalario.Text;

            con.OpenConection();
            con.ExecuteQueries("Insert into Empleado (Cedula, Nombre, Apellido, Direccion, Telefono," +
              " Correo, Cargo, Departamento, Salario)" +
            " values('" + Cedula + "','" + Nombre + "' ,'" + Apellidos + "','" + Direccion + "','" + Telefono + "','"
            + Correo + "','" + Cargo + "','" + Departamento + "','" + Salario +"')");
            con.CloseConnection();
            MessageBox.Show("Datos introducidos con éxito");
            MostrarEmpleados();

        }

        private void MostrarEmpleados()
        {
            SqlConnection cn = new SqlConnection("Data Source= localhost; Initial Catalog = Nomina; Integrated Security = True");

            string query = "Select * from Empleado";
            SqlDataAdapter adaptador = new SqlDataAdapter(query, cn);
            DataTable dt = new DataTable();
            adaptador.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void ActualizarEmpleado()
        {
            string Cedula = txtCedula.Text;
            string Nombre = txtNombre.Text;
            string Apellidos = txtApellido.Text;
            string Direccion = txtDireccion.Text;
            string Telefono = txtTelefono.Text;
            string Correo = txtCorreo.Text;
            string Cargo = txtCargo.Text;
            string Departamento = txtDepartamento.Text;
            string Salario = txtSalario.Text;
            con.OpenConection();
            con.ExecuteQueries("update Empleado SET Cedula='" + Cedula + "', Nombre= '" + Nombre + "', Apellido='" + Apellidos +
                "', Direccion= '" + Direccion + "', Telefono='" + Telefono + "', Correo='" + Correo + 
                 "', Cargo='" + Cargo + "', Departamento='" + Departamento + "', Salario='" + Salario + 
                 "' where ID = '" + txtCodigoEmpleado.Text + "'");
            MessageBox.Show("Empleado actualizado");
            MostrarEmpleados();
            con.CloseConnection();
        }

        private void limpiarCampos()
        {
            btnCrearEmpleado.Enabled = true;
            txtTelefono.Clear();
            txtSalario.Clear();
            txtNombre.Clear();
            txtDireccion.Clear();
            txtDepartamento.Clear();
            txtCedula.Clear();
            txtCodigoEmpleado.Clear();
            txtCargo.Clear();
            txtApellido.Clear();
            txtCorreo.Clear();
        }

        private void btnCrearEmpleado_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(txtNombre.Text))
            {
                MessageBox.Show("Debe llenar todos los campos");
            }
            else if (string.IsNullOrEmpty(txtApellido.Text))
            {
                MessageBox.Show("Debe llenar todos los campos");
            }
            else if (string.IsNullOrEmpty(txtDireccion.Text))
            {
                MessageBox.Show("Debe llenar todos los campos");
            }
            else if (string.IsNullOrEmpty(txtCargo.Text))
            {
                MessageBox.Show("Debe llenar todos los campos");
            }
            else if (string.IsNullOrEmpty(txtCedula.Text))
            {
                MessageBox.Show("Debe llenar todos los campos");
            }
            else if (string.IsNullOrEmpty(txtDepartamento.Text))
            {
                MessageBox.Show("Debe llenar todos los campos");
            }
            else if (string.IsNullOrEmpty(txtSalario.Text))
            {
                MessageBox.Show("Debe llenar todos los campos");
            }
            else if (string.IsNullOrEmpty(txtTelefono.Text))
            {
                MessageBox.Show("Debe llenar todos los campos");
            }
            else if (string.IsNullOrEmpty(txtCorreo.Text))
            {
                MessageBox.Show("Debe llenar todos los campos");
            }
            else
            {
                try
                {
                    GuardarEmpleados();

                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

            
        }
        private void EmpleadosMant_Load(object sender, EventArgs e)
        {
            MostrarEmpleados();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtCodigoEmpleado.Text = dataGridView1.SelectedCells[0].Value.ToString();
            txtCedula.Text = dataGridView1.SelectedCells[1].Value.ToString();
            txtNombre.Text = dataGridView1.SelectedCells[2].Value.ToString();
            txtApellido.Text = dataGridView1.SelectedCells[3].Value.ToString();
            txtDireccion.Text = dataGridView1.SelectedCells[4].Value.ToString();
            txtTelefono.Text = dataGridView1.SelectedCells[5].Value.ToString();
            txtCorreo.Text = dataGridView1.SelectedCells[6].Value.ToString();
            txtCargo.Text = dataGridView1.SelectedCells[7].Value.ToString();
            txtDepartamento.Text = dataGridView1.SelectedCells[8].Value.ToString();
            txtSalario.Text = dataGridView1.SelectedCells[9].Value.ToString();
        }

        private void btbNuevo_Click(object sender, EventArgs e)
        {
            limpiarCampos();
            btnCrearEmpleado.Enabled = true;
        }

        private void EliminarEmp(int id)
        {
            con.OpenConection();
            con.ExecuteQueries("DELETE FROM EMPLEADO WHERE ID ='" + txtCodigoEmpleado.Text + "'");
            con.CloseConnection();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {

            if (dataGridView1.SelectedRows.Count > 0)
            {
                if (MessageBox.Show("¿Eliminar Registro?", "Eliminar Registro", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    EliminarEmp(Convert.ToInt32(txtCodigoEmpleado.Text));
                    MessageBox.Show("Registro eliminado exitosamente!");
                }
                else
                {
                    MessageBox.Show("Registro no eliminado");
                    limpiarCampos();
                }
            }
            else
            {
                MessageBox.Show("Por favor seleccione el registro a eliminar");
            }
            
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtNombre.Text))
            {
                MessageBox.Show("Debe llenar todos los campos");
            }
            else if (string.IsNullOrEmpty(txtApellido.Text))
            {
                MessageBox.Show("Debe llenar todos los campos");
            }
            else if (string.IsNullOrEmpty(txtDireccion.Text))
            {
                MessageBox.Show("Debe llenar todos los campos");
            }
            else if (string.IsNullOrEmpty(txtCargo.Text))
            {
                MessageBox.Show("Debe llenar todos los campos");
            }
            else if (string.IsNullOrEmpty(txtCedula.Text))
            {
                MessageBox.Show("Debe llenar todos los campos");
            }
            else if (string.IsNullOrEmpty(txtDepartamento.Text))
            {
                MessageBox.Show("Debe llenar todos los campos");
            }
            else if (string.IsNullOrEmpty(txtSalario.Text))
            {
                MessageBox.Show("Debe llenar todos los campos");
            }
            else if (string.IsNullOrEmpty(txtTelefono.Text))
            {
                MessageBox.Show("Debe llenar todos los campos");
            }
            else if (string.IsNullOrEmpty(txtCorreo.Text))
            {
                MessageBox.Show("Debe llenar todos los campos");
            }
            else
            {
                try
                {
                    ActualizarEmpleado();
                }
                catch (Exception ex)
                {

                    throw ex;
                }
            }
        }

        private void linklblmenu_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
        }
    }
}



