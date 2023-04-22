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
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Gestion_de_Nomina
{
    public partial class ReaderDashboard : Form
    {
        Login log = new Login();
        public int Id;
        public string User;
        public string Rol;
        public string Accion;
        public DateTime fecha = DateTime.Now;
        public ReaderDashboard(string text, string text2, string rol, string username, int id, DateTime fecha, string accion)
        {
            InitializeComponent();
            Rol = rol;
            User = username;
            Accion = accion;
            Id = id;
            userLb.Text = text;
            RolLb.Text = text2;
        }
        
        private void empleadosToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            EmpleadosConsulta empCon= new EmpleadosConsulta();
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
    }
}
