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
    public partial class Dashboard : Form
    {
        Login log = new Login();
        
        public Dashboard(string text, string text2)
        {
            InitializeComponent();
            userLb.Text = text;
            RolLb.Text = text2; 
        }
        private void empleadoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EmpleadosMant empMant = new EmpleadosMant();
            empMant.Show();
        }

        private void nominaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NominasMant nomMant = new NominasMant();
            nomMant.Show();
        }
        private void usuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UsuariosMant usuariosMant = new UsuariosMant();
            usuariosMant.Show();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            log.Show();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process calc = new System.Diagnostics.Process { StartInfo = { FileName = @"calc.exe" } };
            calc.Start();
        }
    }
}
