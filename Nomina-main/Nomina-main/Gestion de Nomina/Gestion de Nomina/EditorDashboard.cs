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
    public partial class EditorDashboard : Form
    {
        Login log = new Login();
        public int Id;
        public string User;
        public string Rol;
        public string Accion;
        public DateTime fecha = DateTime.Now;
        public EditorDashboard(string text, string text2, string rol, string username, int id, DateTime fecha, string accion)
        {
            InitializeComponent();
            Rol = rol;
            User = username;
            Accion = accion;
            Id = id;
            userLb.Text = text;
            RolLb.Text = text2;
        }

        private void empleadoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EmpleadosMant empMant = new EmpleadosMant(Rol, User, Id, fecha, Accion);
            empMant.Show();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            Accion = "Cerró sesión";
            log.GuardarLog(Id, User, Rol, Accion, fecha);
            log.Show();
            this.Close();
        }

        private void nominaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NominasMant nomMant = new NominasMant(Rol, User, Id, fecha, Accion);
            nomMant.Show();
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

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process calc = new System.Diagnostics.Process { StartInfo = { FileName = @"calc.exe" } };
            calc.Start();
        }
    }
}
