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
            //string conexionString = "Data Source=.\\SQLEXPRESS;AttachDbFilename=C:\\Users\\maxi1\\OneDrive\\Documentos\\Programacion LPOO II\\LPOOII_GRUPO08\\LPOOII_GRUPO08\\playa.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True";
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
            string conexionString = "Data Source=.\\SQLEXPRESS;AttachDbFilename=C:\\Users\\lenovo\\Documents\\LPOOII_GRUPO08\\LPOOII_GRUPO08\\playa.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True";
            //string conexionString = "Data Source=.\\SQLEXPRESS;AttachDbFilename=C:\\Users\\maxi1\\OneDrive\\Documentos\\Programacion LPOO II\\LPOOII_GRUPO08\\LPOOII_GRUPO08\\playa.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True";
            //string conexionString = "Data Source=.\\SQLEXPRESS;AttachDbFilename=C:\\Users\\maxi1\\OneDrive\\Documentos\\Programacion LPOO II\\LPOOII_GRUPO08\\LPOOII_GRUPO08\\playa.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True";
            //string conexionString = "Data Source=.\\SQLEXPRESS;AttachDbFilename=C:\\Users\\Cuno\\Documents\\LPOOII_GRUPO08\\LPOOII_GRUPO08\\playa.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True";
            //string conexionString = "Data Source=.\\SQLEXPRESS;AttachDbFilename=C:\\Users\\argca\\OneDrive\\Documentos\\LPOOII_GRUPO08\\LPOOII_GRUPO08\\playa.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True";
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
            var trabajarCliente = new ClasesBase.TrabajarCliente();
            var trabajarTipoVehiculo = new ClasesBase.TrabajarTiposVehiculo();

            foreach (var sector in sectores)
            {
                if (!sector.Habilitado) // Si el sector no está habilitado (false)
                {
                    
                    var ticket = trabajarTicket.buscarTicketPorSector(1);// ver en la base de datos porque no se asocia el ticket con el codigo_sector
                    var cliente = trabajarCliente.ObtenerClientePorDni(ticket.ClienteDNI);
                    var descripcion = trabajarTipoVehiculo.ObtenerDescripcionPorTarifa(ticket.Tarifa);

                    TimeSpan tiempoTranscurrido = DateTime.Now - ticket.FechaHoraEnt;
                    var datos = new
                    {
                        Zona = "A", 
                        Sector = sector.SectorCodigo, 
                        ApellidoYNombre = cliente.Nombre+" "+cliente.Apellido, 
                        FechaHoraEntrada = ticket.FechaHoraEnt,
                        TipoVehiculo = descripcion,
                        Patente = ticket.Patente,                  
                        TiempoTranscurrido = tiempoTranscurrido,
                    };

                    listaDatos.Add(datos);
                }
            }

            return listaDatos;
        }


        //Obtiene todos los sectores correspondientes a una zona.
        public ObservableCollection<Sector> TraerTodosLosSectores(int codigoZona)
        {
            ObservableCollection<Sector> sectores = new ObservableCollection<Sector>();

            // Conexión a la base de datos
            string conexionString = "Data Source=.\\SQLEXPRESS;AttachDbFilename=C:\\Users\\lenovo\\Documents\\LPOOII_GRUPO08\\LPOOII_GRUPO08\\playa.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True";
            //string conexionString = "Data Source=.\\SQLEXPRESS;AttachDbFilename=C:\\Users\\maxi1\\OneDrive\\Documentos\\Programacion LPOO II\\LPOOII_GRUPO08\\LPOOII_GRUPO08\\playa.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True";
            //string conexionString = "Data Source=.\\SQLEXPRESS;AttachDbFilename=C:\\Users\\maxi1\\OneDrive\\Documentos\\Programacion LPOO II\\TP1LPOO II\\LPOOII_GRUPO08\\playa.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True";
            //string conexionString = "Data Source=.\\SQLEXPRESS;AttachDbFilename=C:\\Users\\argca\\OneDrive\\Documentos\\LPOOII_GRUPO08\\LPOOII_GRUPO08\\playa.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True";
            SqlConnection conexion = new SqlConnection(conexionString);
            conexion.Open();

            // Consulta a la base de datos, solo trae las playas que esten habilitadas
            string consulta = "SELECT * FROM Sector WHERE zona_codigo = @codigoZona";
            SqlCommand comando = new SqlCommand(consulta, conexion);

            comando.Parameters.AddWithValue("@codigoZona", codigoZona);


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
