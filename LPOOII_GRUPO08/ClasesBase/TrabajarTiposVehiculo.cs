using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace ClasesBase
{
    public class TrabajarTiposVehiculo
    {

        public DataTable TraerTiposVehiculo()
        {
            DataTable dt = new DataTable();
            string conexionString = "Data Source=.\\SQLEXPRESS;AttachDbFilename=C:\\Users\\maxi1\\OneDrive\\Documentos\\Programacion LPOO II\\TP1LPOO II\\LPOOII_GRUPO08\\playa.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True";
            using (SqlConnection connection = new SqlConnection(conexionString))
            {
                connection.Open();
                string query = "SELECT tv_codigo, descripcion, tarifa FROM TipoVehiculo";
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                adapter.Fill(dt);
            }
            return dt;
        }

    }
}
