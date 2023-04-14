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
        
        public Dashboard(string text)
        {
            InitializeComponent();
            userLb.Text = text;
        }

        private void SalirBtn(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
