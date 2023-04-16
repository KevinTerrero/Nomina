using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agenda
{
    internal class ConnectionClass

    {

        public string ConnectionString = @"Data Source= localhost; Initial Catalog = Nomina; Integrated Security = True";
        SqlConnection con;

        #region Abrir conexion a SQL
        public void OpenConection()
        {
            con = new SqlConnection(ConnectionString);
            con.Open();
        }
        #endregion

        #region Cerrar conexion a SQL
        public void CloseConnection()
        {
            con.Close();
        }

        #endregion

        #region Para ejecutar los queries
        public void ExecuteQueries(string Query_)
        {
            SqlCommand cmd = new SqlCommand(Query_, con);
            cmd.ExecuteNonQuery();

        }

        #endregion

        #region Para leer data 
        public SqlDataReader DataReader(string Query_)
        {
            
            SqlCommand cmd = new SqlCommand(Query_, con);
            SqlDataReader dr = cmd.ExecuteReader();
            return dr;
        }

        #endregion

        #region Para mostrar en gridview
        public object ShowDataInGridView(string Query_)
        {
            SqlDataAdapter dr = new SqlDataAdapter(Query_, ConnectionString);
            DataSet ds = new DataSet();
            dr.Fill(ds);
            object dataum = ds.Tables[0];
            return dataum;
        }

        #endregion

    }
}
