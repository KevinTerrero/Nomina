using Agenda;
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
    public partial class Configuracion : Form
    {
        ConnectionClass con = new ConnectionClass();
        public Configuracion()
        {
            InitializeComponent();
        }

        private void backupBtn_Click(object sender, EventArgs e)
        {
            /**con.OpenConection();
            con.ExecuteQueries("BACKUP DATABASE Nomina TO DISK = C:\\Program Files\\Microsoft SQL Server\\MSSQL15.MSSQLSERVER\\MSSQL\\Backup\\Nomina.bak");
            con.CloseConnection();
            MessageBox.Show("Backup realizado con éxito");**/
        }
    }
}
