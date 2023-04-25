using Agenda;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Gestion_de_Nomina
{
    public partial class NominasMant : Form
    {
        public int Id;
        public string User;
        public string Rol;
        public string Accion;
        public DateTime fecha = DateTime.Now;
        Login log = new Login();
        ConnectionClass con = new ConnectionClass();
        public NominasMant(string rol, string username, int id, DateTime fecha, string accion)
        {

            InitializeComponent();
            MostrarNomina();
            txtNombre.Enabled = false;
            txtApellido.Enabled = false;
            txtCargo.Enabled = false;
            txtSueldoB.Enabled = false;
            txtExtraH.Enabled = false;
            txtTotalAsig.Enabled = false;
            txtSeguro.Enabled = false;
            txtTotalDed.Enabled = false;
            txtSueldoN.Enabled = false;
            Rol = rol;
            User = username;
            Accion = accion;
            Id = id;
            string Nombre;
            string Apellidos;
            string Codigo;
            string Cargo;
            int SueldoB;
            int HorasEx;
            int PrecioXHora;
            int ExtraHours;
            int BonoT;
            int TotalAsig;
            float Seguro;
            int Adelanto;
            float TotalDec;
            float SueldoN;

        }

        private void GuardarNomBtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtNombre.Text))
            {
                MessageBox.Show("Debe completar todos los campos");
            }
            else if (string.IsNullOrEmpty(txtApellido.Text))
            {
                MessageBox.Show("Debe completar todos los campos");
            }
            else if (string.IsNullOrEmpty(txtCargo.Text))
            {
                MessageBox.Show("Debe completar todos los campos");
            }
            else if (string.IsNullOrEmpty(txtSueldoB.Text))
            {
                MessageBox.Show("Debe completar todos los campos");
            }
            else if (string.IsNullOrEmpty(txtHorasEx.Text))
            {
                MessageBox.Show("Debe completar todos los campos");
            }
            else if (string.IsNullOrEmpty(txtPrecioxHora.Text))
            {
                MessageBox.Show("Debe completar todos los campos");
            }
            else if (string.IsNullOrEmpty(txtBonoT.Text))
            {
                MessageBox.Show("Debe completar todos los campos");
            }
            else if (string.IsNullOrEmpty(txtTotalAsig.Text))
            {
                MessageBox.Show("Debe completar todos los campos");
            }
            else if (string.IsNullOrEmpty(txtAdelanto.Text))
            {
                MessageBox.Show("Debe completar todos los campos");
            }
            else if (string.IsNullOrEmpty(txtTotalDed.Text))
            {
                MessageBox.Show("Debe completar todos los campos");
            }
            else if (string.IsNullOrEmpty(txtSueldoN.Text))
            {
                MessageBox.Show("Debe completar todos los campos");
            }
            else if (string.IsNullOrEmpty(txtExtraH.Text))
            {
                MessageBox.Show("Debe completar todos los campos");
            }
            else if (string.IsNullOrEmpty(cuentatxt.Text))
            {
                MessageBox.Show("Debe completar todos los campos");
            }
            else
            {
                GuardarNomina();
                GuardarNomBtn.Enabled = false;
            }

        }

        private void GuardarNomina()
        {
            string Nombre = txtNombre.Text;
            string Apellidos = txtApellido.Text;
            string Codigo = txtSearch.Text;
            string Cargo = txtCargo.Text;
            int SueldoB = Convert.ToInt32(txtSueldoB.Text);
            int HorasEx = Convert.ToInt32(txtHorasEx.Text);
            int PrecioXHora = Convert.ToInt32(txtPrecioxHora.Text);
            int ExtraHours = Convert.ToInt32(txtExtraH.Text);
            int BonoT = Convert.ToInt32(txtBonoT.Text);
            int TotalAsig = Convert.ToInt32(txtTotalAsig.Text);
            float Seguro = float.Parse(txtSeguro.Text);
            int Adelanto = Convert.ToInt32(txtAdelanto.Text);
            float TotalDec = float.Parse(txtTotalDed.Text);
            float SueldoN = float.Parse(txtSueldoN.Text);
            int Seguro2 = Convert.ToInt32(Seguro);
            int TotalDec2 = Convert.ToInt32(TotalDec);
            int SueldoN2 = Convert.ToInt32(SueldoN);
            int cuentaBancaria = Convert.ToInt32(cuentatxt.Text);
            bool success = false;
            DateTime fecha = DateTime.Now;
            try
            {

                MailMessage mail = new MailMessage("nominassnoreply@gmail.com", txtEmail.Text);
                SmtpClient client = new SmtpClient("smtp.gmail.com");
                client.EnableSsl = true;
                client.Port = 25;
                mail.IsBodyHtml = true;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.UseDefaultCredentials = false;
                client.Credentials = new System.Net.NetworkCredential("nominassnoreply@gmail.com", "nixoofiyvnguptbo");
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                mail.Subject = "Se ha creado su nómina!";
                mail.Body = $"Volante de pago de nómina <br/> " +
                            $"Fecha {fecha} <br/>" +
                            $"Nombre del beneficiado: {Nombre + " " + Apellidos}<br/>" +
                            $"Cuenta bancaria: {cuentaBancaria}<br/>" +
                            $"Cargo: {Cargo} <br/>" +
                            $"Horas extras trabajadas: {HorasEx}<br/>" +
                            $"Pago por horas extras: {PrecioXHora + " pesos"}<br/>" +
                            $"Pago por horas extras trabajadas: {ExtraHours + " pesos"}<br/>" +
                            $"Bono de transporte: {BonoT + " pesos"}<br/>" +
                            $"Total de asignaciones: {TotalAsig + " pesos"}<br/>" +
                            $"Seguro: {Seguro2 + " pesos"}<br/>" +
                            $"Adelanto del sueldo: {Adelanto + " pesos"}<br/>" +
                            $"Total decremento: {TotalDec2 + " pesos"}<br/>" +
                            $"Suma del pago: {SueldoN2 + " pesos"}<br/>" +
                            $"Descripción del pago: pago por los servicios brindados a la empresa.";
                client.Send(mail);
                success = true; 
                MessageBox.Show("Se ha enviado el correo de forma correcta");
                if (success)
                {
                Accion = "Guardó la nómina de  " + Nombre + " " + Apellidos;
                log.GuardarLog(Id, User, Rol, Accion, fecha);
                con.OpenConection();
                con.ExecuteQueries("Insert into TableNomina (Nombre, Apellidos, CuentaBancaria, Cargo, SueldoBruto, HorasExtra, ExtraHours," +
                  " PrecioXHora, BonoTransporte, TotalAsignacion, Seguro, Adelanto, TotalDeduccion, SueldoNeto, Fecha)" +
                " values('" + Nombre + "','" + Apellidos + "' ,'" + cuentaBancaria +  "' ,'" + Cargo + "','" + SueldoB + "','" + HorasEx + "','" + ExtraHours + "','"+
                + PrecioXHora + "','" + BonoT + "','" + TotalAsig + "','" + Seguro2 + "','" + Adelanto + "','" + TotalDec2 + "','" + SueldoN2 + "','" + fecha + "')");
                con.CloseConnection();
                MessageBox.Show("Datos introducidos con éxito");
                MostrarNomina();

                }
                else
                {
                    MessageBox.Show("Ha habido un error al enviar el correo");
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show("Ha habido un error");

            }
            
        }
        private void MostrarNomina()
        {

        SqlConnection cn = new SqlConnection("Data Source= localhost; Initial Catalog = Nomina; Integrated Security = True");

            string query = "Select * from TableNomina";
            SqlDataAdapter adaptador = new SqlDataAdapter(query, cn);
            DataTable dt = new DataTable();
            adaptador.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void linklblmenu_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();

        }

        private void CalcularBtn_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(txtNombre.Text))
            {
                MessageBox.Show("Debe completar todos los campos");
            }
            else if (string.IsNullOrEmpty(txtApellido.Text))
            {
                MessageBox.Show("Debe completar todos los campos");
            }
            else if (string.IsNullOrEmpty(txtCargo.Text))
            {
                MessageBox.Show("Debe completar todos los campos");
            }
            else if (string.IsNullOrEmpty(txtSueldoB.Text))
            {
                MessageBox.Show("Debe completar todos los campos");
            }
            else if (string.IsNullOrEmpty(txtHorasEx.Text))
            {
                MessageBox.Show("Debe completar todos los campos");
            }
            else if (string.IsNullOrEmpty(txtPrecioxHora.Text))
            {
                MessageBox.Show("Debe completar todos los campos");
            }
            else if (string.IsNullOrEmpty(txtBonoT.Text))
            {
                MessageBox.Show("Debe completar todos los campos");
            }
            else if (string.IsNullOrEmpty(txtAdelanto.Text))
            {
                MessageBox.Show("Debe completar todos los campos");
            }
            else if (string.IsNullOrEmpty(cuentatxt.Text))
            {
                MessageBox.Show("Debe completar todos los campos");
            }

            else
            {

                try
                {
                    float totalAsignaciones, SeguroMed, TotalDesucciones, SueldoBruto, SueldoNeto;
                    int HorasExt, PrecioHorasExt, PagoHorasExt, BonoTransp, AdelantoSueldo;
                    HorasExt = Convert.ToInt32(txtHorasEx.Text);
                    PrecioHorasExt = Convert.ToInt32(txtPrecioxHora.Text);
                    BonoTransp = Convert.ToInt32(txtBonoT.Text);
                    SueldoBruto = float.Parse(txtSueldoB.Text);
                    AdelantoSueldo = Convert.ToInt32(txtAdelanto.Text);
                    PagoHorasExt = HorasExt * PrecioHorasExt;
                    totalAsignaciones = PagoHorasExt + BonoTransp;
                    SeguroMed = SueldoBruto * 0.0591F;
                    TotalDesucciones = SeguroMed - AdelantoSueldo;
                    SueldoNeto = SueldoBruto + totalAsignaciones - TotalDesucciones;
                    txtExtraH.Text = PagoHorasExt.ToString();
                    txtTotalAsig.Text = totalAsignaciones.ToString();
                    txtSeguro.Text = SeguroMed.ToString();
                    txtTotalDed.Text = TotalDesucciones.ToString();
                    txtSueldoN.Text = SueldoNeto.ToString();
                    GuardarNomBtn.Enabled = true;
                }
                catch (Exception)
                {

                    MessageBox.Show("Ha introducido valores incorrectos");
                }

                
            }
        }


        private void limpiarCampos() {

            txtSueldoB.Clear();
            txtHorasEx.Clear();
            txtPrecioxHora.Clear();
            txtExtraH.Clear();
            txtBonoT.Clear();
            txtTotalAsig.Clear();
            txtSeguro.Clear();
            txtAdelanto.Clear();
            txtTotalDed.Clear();
            txtSueldoN.Clear();
            txtNombre.Clear();
            txtApellido.Clear();
            txtCargo.Clear();
            cuentatxt.Clear();
        }
        private void NuevaNomBtn_Click(object sender, EventArgs e)
        {
            SearchBtn.Enabled = true;
            txtSearch.Enabled = true;
            limpiarCampos();
        }

        private void SearchBtn_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(txtSearch.Text))
            {
                MessageBox.Show("Debe completar el campo");
            }
            else
            {
                try
                {
                    SearchBtn.Enabled = false;
                    txtSearch.Enabled = false;
                    int id = Convert.ToInt32( txtSearch.Text);
                    con.OpenConection();
                    SqlDataReader dr = con.DataReader("select * from TablaEmpleados where ID='" + id + "'");
                    if (dr.Read())
                    {

                        string nombre = dr.GetString(2);
                        string apellidos = dr.GetString(3);
                        string cargo = dr.GetString(8);
                        string sueldoB = dr.GetString(10);
                        string email = dr.GetString(7);
                        int cuenta = dr.GetInt32(4);

                        txtEmail.Text = email;
                        txtNombre.Text = nombre;
                        txtApellido.Text = apellidos;
                        txtCargo.Text = cargo;
                        txtSueldoB.Text = sueldoB;
                        cuentatxt.Text = cuenta.ToString();
                    }
                    else
                    {
                        MessageBox.Show("Valor no encontrado");
                        txtSearch.Enabled = true;
                        SearchBtn.Enabled = true;
                    }
                    
                }
                catch (Exception ex)
                {
                    SearchBtn.Enabled = true;
                    txtSearch.Enabled = true;
                    MessageBox.Show("Ha habido un error");
                }
                

            }

        }
    }
}
