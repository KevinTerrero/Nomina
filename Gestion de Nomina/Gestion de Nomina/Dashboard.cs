using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.tool.xml;


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

        private void toolStripLabel1_Click(object sender, EventArgs e)
        {

        }

        private void nominasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog guardar = new SaveFileDialog();
            guardar.FileName = "Nomina " + DateTime.Now.ToString("ddMMyy")+".pdf";

            string paginahtml_html = Properties.Resources.NominaPlantilla.ToString();

            if (guardar.ShowDialog() == DialogResult.OK) {

                using (FileStream stream = new FileStream(guardar.FileName, FileMode.Create)) {
                    Document pdfDoc = new Document(PageSize.A4, 25, 25, 25, 25);
                    
                    PdfWriter writer = PdfWriter.GetInstance(pdfDoc, stream);

                    pdfDoc.Open();

                    using (StringReader sr = new StringReader(paginahtml_html)) {
                        XMLWorkerHelper.GetInstance().ParseXHtml(writer,pdfDoc, sr);
                    }


                    pdfDoc.Close();
                    stream.Close();
                }
            }
            

        }
    }
}
