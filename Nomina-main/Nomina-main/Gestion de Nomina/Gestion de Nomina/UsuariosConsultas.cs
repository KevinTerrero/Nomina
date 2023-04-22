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
    public partial class UsuariosConsultas : Form
    {
        public UsuariosConsultas()
        {
            InitializeComponent();
            MostrarUsuarios();
        }

        private void FilterBtn_Click(object sender, EventArgs e)
        {
            string filterEmployee = filterTxtBox.Text;
            SqlConnection cn = new SqlConnection("Data Source= localhost; Initial Catalog = Nomina; Integrated Security = True");
            string query = "select * from Users where ID = " + filterEmployee;
            SqlDataAdapter adaptador = new SqlDataAdapter(query, cn);
            DataTable dt = new DataTable();
            adaptador.Fill(dt);
            dataGridView1.DataSource = dt;
            
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

        private void CargarBtn_Click(object sender, EventArgs e)
        {
            MostrarUsuarios();
        }
    }
}
