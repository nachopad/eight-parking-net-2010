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

        public ObservableCollection<Sector> TraerSectoresOcupados()
        {
            ObservableCollection<Sector> sectores = new ObservableCollection<Sector>();

            // Conexión a la base de datos
            string conexionString = "Data Source=.\\SQLEXPRESS;AttachDbFilename=C:\\Users\\Cuno\\Documents\\LPOOII_GRUPO08\\LPOOII_GRUPO08\\playa.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True";
            SqlConnection conexion = new SqlConnection(conexionString);
            conexion.Open();

            // Consulta a la base de datos, solo trae las playas que esten habilitadas
            string consulta = "SELECT * FROM Sector WHERE habilitado=0";
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


        public List<object> ObtenerDatosDeLaBaseDeDatos()
        {
            var listaDatos = new List<object>();

            // Crear una instancia de TrabajarSector para obtener los sectores
            var trabajarSector = new ClasesBase.TrabajarSector();
            var sectores = trabajarSector.TraerSectoresOcupados();
            var trabajarTicket = new ClasesBase.TrabajarTicket();

            foreach (var sector in sectores)
            {
                if (!sector.Habilitado) // Si el sector no está habilitado (false)
                {

                    var ticket = trabajarTicket.buscarTicketPorSector(sector.SectorCodigo);
                    var datos = new
                    {
                        Zona = "A", // Agrega lógica para obtener la zona si es necesario
                        Sector = sector.SectorCodigo, // Usar el sector_codigo en el grid
                        //ApellidoYNombre = ticket.ClienteDNI,
                       // FechaHoraEntrada = DateTime.Now, // Ejemplo de fecha y hora de entrada
                       // ApellidoYNombre = "", // Agrega lógica para obtener el apellido y nombre si es necesario
                        // Agrega las otras propiedades de ser necesario
                    };

                    listaDatos.Add(datos);
                }
            }

            return listaDatos;
        }

    }
}
