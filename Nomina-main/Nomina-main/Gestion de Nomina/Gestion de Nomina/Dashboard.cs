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
    public partial class Dashboard : Form
    {

       public int Id;
       public string User;
        public string Rol;
        public string Accion;
        public DateTime fecha = DateTime.Now;
        Login log = new Login();
        
        public Dashboard(string text, string text2, string rol, string username, int id, DateTime fecha, string accion)
        {
            InitializeComponent();
            Rol = rol;
            User = username;
            Accion = accion;
            Id = id;
            userLb.Text = text;
            RolLb.Text = text2;
            MostrarLogs();
        }
        private void empleadoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EmpleadosMant empMant = new EmpleadosMant(Rol, User, Id, fecha, Accion);
            empMant.Show();
        }

        private void nominaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NominasMant nomMant = new NominasMant(Rol, User, Id, fecha, Accion);
            nomMant.Show();
        }
        private void usuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UsuariosMant usuariosMant = new UsuariosMant( Rol, User, Id, fecha, Accion);
            usuariosMant.Show();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            Accion = "Cerró sesión";
            log.GuardarLog(Id, User, Rol, Accion, fecha);
            log.Show();
            this.Close();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process calc = new System.Diagnostics.Process { StartInfo = { FileName = @"calc.exe" } };
            calc.Start();
        }

        private void MostrarLogs()
        {
            SqlConnection cn = new SqlConnection("Data Source= localhost; Initial Catalog = Nomina; Integrated Security = True");
            string query = "Select * from UserLogs";
            SqlDataAdapter adaptador = new SqlDataAdapter(query, cn);
            DataTable dt = new DataTable();
            adaptador.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void CargarBtn_Click(object sender, EventArgs e)
        {
            MostrarLogs();
        }

        private void FilterBtn_Click(object sender, EventArgs e)
        {
            string filterUser = filterTxtBox.Text;
            SqlConnection cn = new SqlConnection("Data Source= localhost; Initial Catalog = Nomina; Integrated Security = True");
            string query = "select * from UserLogs where IDUsuario = " + filterUser; ;
            SqlDataAdapter adaptador = new SqlDataAdapter(query, cn);
            DataTable dt = new DataTable();
            adaptador.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void empleadosToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            EmpleadosConsulta empCon = new EmpleadosConsulta();
            empCon.Show();
        }

        private void nominasToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            NominaConsultas nomCon = new NominaConsultas();
            nomCon.Show();
        }

        private void usuariosToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            UsuariosConsultas usuCon = new UsuariosConsultas();
            usuCon.Show();
        }

        private void toolStripLabel1_Click(object sender, EventArgs e)
        {
            Configuracion config = new Configuracion();
            config.Show();
        }
    }
}
