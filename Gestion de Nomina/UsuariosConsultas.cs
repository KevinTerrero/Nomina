using iTextSharp.text.pdf;
using iTextSharp.text;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
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

        private void reporteBtn_Click(object sender, EventArgs e)
        {

            if (dataGridView1.Rows.Count > 0)
            {
                SaveFileDialog save = new SaveFileDialog();
                save.Filter = "PDF (.pdf)|.pdf";
                save.FileName = "ReporteUsuarios";
                bool ErrorMessage = false;

                if (save.ShowDialog() == DialogResult.OK)
                {

                    if (File.Exists(save.FileName))
                    {
                        try
                        {
                            File.Delete(save.FileName);
                        }
                        catch (Exception ex)
                        {
                            ErrorMessage = true;
                            MessageBox.Show("Hubo un error al escribir los datos en el disco" + ex.Message);
                        }
                    }
                    if (!ErrorMessage)
                    {
                        try
                        {
                            PdfPTable pTable = new PdfPTable(dataGridView1.Columns.Count);
                            pTable.DefaultCell.Padding = 2;
                            pTable.WidthPercentage = 100;
                            pTable.HorizontalAlignment = Element.ALIGN_LEFT;

                            foreach (DataGridViewColumn col in dataGridView1.Columns)
                            {
                                PdfPCell pCell = new PdfPCell(new Phrase(col.HeaderText));
                                pTable.AddCell(pCell);
                            }
                            foreach (DataGridViewRow viewRow in dataGridView1.Rows)
                            {
                                foreach (DataGridViewCell dcell in viewRow.Cells)
                                {
                                    pTable.AddCell(dcell.Value?.ToString());
                                }
                            }

                            using (FileStream fileStream = new FileStream(save.FileName, FileMode.Create))
                            {
                                Document document = new Document(PageSize.A4, 8f, 16f, 16f, 8f);
                                document.Open();
                                PdfWriter writer = PdfWriter.GetInstance(document, fileStream);
                                document.Open();
                                document.Add(pTable);
                                document.Close();
                                writer.Close();
                                fileStream.Close();
                            }
                            MessageBox.Show("Se ha generado el reporte con exito", "info");

                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error al exportar datos" + ex);
                        }

                    }

                }
            }
            else
            {
                MessageBox.Show("No se encontro ningun registro", "Info");
            }

    }
    }
}
