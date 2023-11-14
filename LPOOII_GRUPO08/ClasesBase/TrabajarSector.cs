using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using System.Data.SqlClient;

namespace ClasesBase
{
    public class TrabajarSector
    {
        public ObservableCollection<Sector> TraerSectores()
        {
            ObservableCollection<Sector> sectores = new ObservableCollection<Sector>();

            // Conexión a la base de datos
            string conexionString = "Data Source=.\\SQLEXPRESS;AttachDbFilename=C:\\Users\\argca\\OneDrive\\Documentos\\LPOOII_GRUPO08\\LPOOII_GRUPO08\\playa.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True";
            SqlConnection conexion = new SqlConnection(conexionString);
            conexion.Open();

            // Consulta a la base de datos, solo trae las playas que esten habilitadas
            string consulta = "SELECT * FROM Sector WHERE habilitado=1";
            SqlCommand comando = new SqlCommand(consulta, conexion);
            SqlDataReader reader = comando.ExecuteReader();

            // Llenado de la colección
            while (reader.Read())
            {

                Sector sector = new Sector();
                sector.Descripcion = reader["descripcion"].ToString();
                sector.Identificador = reader["identificador"].ToString();
                sector.Habilitado = bool.Parse(reader["habilitado"].ToString());
                sector.SectorCodigo = int.Parse(reader["sector_codigo"].ToString());
                sectores.Add(sector);

            }

            // Cierre de la conexión
            conexion.Close();

            return sectores;
        }
    }
}
