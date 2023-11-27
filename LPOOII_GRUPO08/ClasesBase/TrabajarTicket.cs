using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Collections.ObjectModel;

namespace ClasesBase
{
    public class TrabajarTicket
    {
        public void registrarTicket(Ticket ticket)
        {
            //string conexionString = "Data Source=.\\SQLEXPRESS;AttachDbFilename=C:\\Users\\maxi1\\OneDrive\\Documentos\\Programacion LPOO II\\LPOOII_GRUPO08\\LPOOII_GRUPO08\\playa.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True";
            string conexionString = "Data Source=.\\SQLEXPRESS;AttachDbFilename=C:\\Users\\argca\\OneDrive\\Documentos\\LPOOII_GRUPO08\\LPOOII_GRUPO08\\playa.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True";
            SqlConnection cnn = new SqlConnection(conexionString);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "RegistrarTicket";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = cnn;
            cmd.Parameters.AddWithValue("@dni", ticket.ClienteDNI);
            cmd.Parameters.AddWithValue("@duracion", ticket.Duracion);
            cmd.Parameters.AddWithValue("@fechaEn", ticket.FechaHoraEnt);
            cmd.Parameters.AddWithValue("@fechaSa", ticket.FechaHoraSal);
            cmd.Parameters.AddWithValue("@patente", ticket.Patente);
            cmd.Parameters.AddWithValue("@sector", ticket.SectorCodigo);
            cmd.Parameters.AddWithValue("@tarifa", ticket.Tarifa);
            cmd.Parameters.AddWithValue("@total", ticket.Total);
            cmd.Parameters.AddWithValue("@tipoVehiculo", ticket.TvCodigo);
            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();
        }


        public Ticket obtenerUltimoTicket()
        {

            Ticket ticket = new Ticket();
            // Conexión a la base de datos
            string conexionString = "Data Source=.\\SQLEXPRESS;AttachDbFilename=C:\\Users\\maxi1\\OneDrive\\Documentos\\Programacion LPOO II\\LPOOII_GRUPO08\\LPOOII_GRUPO08\\playa.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True";
            //string conexionString = "Data Source=.\\SQLEXPRESS;AttachDbFilename=C:\\Users\\Lilia\\Documents\\Visual Studio 2010\\Projects\\LPOOII_GRUPO08\\LPOOII_GRUPO08\\playa.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True";
            SqlConnection conexion = new SqlConnection(conexionString);
            conexion.Open();

            // Consulta a la base de datos, solo trae ultimo registro
            string consulta = "SELECT TOP (1) nro_ticket, fecha_hora_ent, fecha_hora_sal, cliente_dni, tv_codigo, patente, sector_codigo, duracion, tarifa, total FROM Ticket ORDER BY nro_ticket DESC";
            SqlCommand comando = new SqlCommand(consulta, conexion);
            SqlDataReader reader = comando.ExecuteReader();
            reader.Read();

            // Se asignan valores
            ticket.TicketNro = int.Parse(reader["nro_ticket"].ToString());
            ticket.FechaHoraEnt = DateTime.Parse(reader["fecha_hora_ent"].ToString());
            ticket.FechaHoraSal = DateTime.Parse(reader["fecha_hora_sal"].ToString());
            ticket.ClienteDNI = reader["cliente_dni"].ToString();
            ticket.TvCodigo = int.Parse(reader["tv_codigo"].ToString());
            ticket.Patente = reader["patente"].ToString();
            ticket.SectorCodigo = int.Parse(reader["sector_codigo"].ToString());
            ticket.Duracion = double.Parse(reader["duracion"].ToString());
            ticket.Tarifa = decimal.Parse(reader["tarifa"].ToString());
            ticket.Total = decimal.Parse(reader["total"].ToString());

            // Cierre de la conexión
            conexion.Close();

            return ticket;
        }

        public Ticket buscarTicketPorSector(int sectorCodigo)
        {
            Ticket ticketEncontrado = null;

            // Conexión a la base de datos
            string conexionString = "Data Source=.\\SQLEXPRESS;AttachDbFilename=C:\\Users\\maxi1\\OneDrive\\Documentos\\Programacion LPOO II\\LPOOII_GRUPO08\\LPOOII_GRUPO08\\playa.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True";
            //string conexionString = "Data Source=.\\SQLEXPRESS;AttachDbFilename=C:\\Users\\Cuno\\Documents\\LPOOII_GRUPO08\\LPOOII_GRUPO08\\playa.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True";
            using (SqlConnection conexion = new SqlConnection(conexionString))
            {
                string consulta = "SELECT nro_ticket, fecha_hora_ent, fecha_hora_sal, cliente_dni, tv_codigo, patente, sector_codigo, duracion, tarifa, total FROM Ticket WHERE sector_codigo = @sectorCodigo";
                SqlCommand comando = new SqlCommand(consulta, conexion);
                comando.Parameters.AddWithValue("@sectorCodigo", sectorCodigo);

                try
                {
                    conexion.Open();
                    SqlDataReader reader = comando.ExecuteReader();

                    if (reader.Read())
                    {
                        ticketEncontrado = new Ticket();
                        // Asignación de valores al ticket encontrado
                        ticketEncontrado.TicketNro = int.Parse(reader["nro_ticket"].ToString());
                        ticketEncontrado.FechaHoraEnt = DateTime.Parse(reader["fecha_hora_ent"].ToString());
                        ticketEncontrado.FechaHoraSal = DateTime.Parse(reader["fecha_hora_sal"].ToString());
                        ticketEncontrado.ClienteDNI = reader["cliente_dni"].ToString();
                        ticketEncontrado.TvCodigo = int.Parse(reader["tv_codigo"].ToString());
                        ticketEncontrado.Patente = reader["patente"].ToString();
                        ticketEncontrado.SectorCodigo = int.Parse(reader["sector_codigo"].ToString());
                        ticketEncontrado.Duracion = double.Parse(reader["duracion"].ToString());
                        ticketEncontrado.Tarifa = decimal.Parse(reader["tarifa"].ToString());
                        ticketEncontrado.Total = decimal.Parse(reader["total"].ToString());
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    // Manejo de excepciones si ocurre alguna
                    Console.WriteLine("Error al buscar ticket por sector: " + ex.Message);
                }
            }

            return ticketEncontrado;
        }


        //Metodo para obtener el ultimo ticket para verficiar, si el sector esta ocupado o no.
        //La busqueda y obtencion se realiza de acuerdo el sector
        public Ticket obtenerUltimoTicketPorSector(int sectorCod)
        {

            Ticket ticketEncontrado = null;

            // Conexión a la base de datos
            string conexionString = "Data Source=.\\SQLEXPRESS;AttachDbFilename=C:\\Users\\lenovo\\Documents\\LPOOII_GRUPO08\\LPOOII_GRUPO08\\playa.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True";
            //string conexionString = "Data Source=.\\SQLEXPRESS;AttachDbFilename=C:\\Users\\maxi1\\OneDrive\\Documentos\\Programacion LPOO II\\LPOOII_GRUPO08\\LPOOII_GRUPO08\\playa.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True";
            //string conexionString = "Data Source=.\\SQLEXPRESS;AttachDbFilename=C:\\Users\\maxi1\\OneDrive\\Documentos\\Programacion LPOO II\\TP1LPOO II\\LPOOII_GRUPO08\\playa.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True";
            //string conexionString = "Data Source=.\\SQLEXPRESS;AttachDbFilename=C:\\Users\\Cuno\\Documents\\LPOOII_GRUPO08\\LPOOII_GRUPO08\\playa.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True";
            //string conexionString = "Data Source=.\\SQLEXPRESS;AttachDbFilename=C:\\Users\\argca\\OneDrive\\Documentos\\LPOOII_GRUPO08\\LPOOII_GRUPO08\\playa.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True";
            using (SqlConnection conexion = new SqlConnection(conexionString))
            {
                string consulta = "SELECT TOP 1 * FROM Ticket WHERE sector_codigo = @sectorCodigo ORDER BY fecha_hora_ent DESC";
                SqlCommand comando = new SqlCommand(consulta, conexion);
                comando.Parameters.AddWithValue("@sectorCodigo", sectorCod);

                try
                {
                    conexion.Open();
                    SqlDataReader reader = comando.ExecuteReader();

                    if (reader.Read())
                    {
                        ticketEncontrado = new Ticket();
                        // Asignación de valores al ticket encontrado
                        ticketEncontrado.TicketNro = int.Parse(reader["nro_ticket"].ToString());
                        ticketEncontrado.FechaHoraEnt = DateTime.Parse(reader["fecha_hora_ent"].ToString());

                        // Comprueba si fecha_hora_sal es null
                        if (!reader.IsDBNull(reader.GetOrdinal("fecha_hora_sal")))
                        {
                            ticketEncontrado.FechaHoraSal = DateTime.Parse(reader["fecha_hora_sal"].ToString());
                        }
                        else
                        {
                            // Asigna una fecha cualquiera cuando fecha_hora_sal es null
                            ticketEncontrado.FechaHoraSal = new DateTime(0001, 1, 1);
                        }

                        ticketEncontrado.ClienteDNI = reader["cliente_dni"].ToString();
                        ticketEncontrado.TvCodigo = int.Parse(reader["tv_codigo"].ToString());
                        ticketEncontrado.Patente = reader["patente"].ToString();
                        ticketEncontrado.SectorCodigo = int.Parse(reader["sector_codigo"].ToString());
                        ticketEncontrado.Duracion = double.Parse(reader["duracion"].ToString());
                        ticketEncontrado.Tarifa = decimal.Parse(reader["tarifa"].ToString());
                        ticketEncontrado.Total = decimal.Parse(reader["total"].ToString());
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    // Manejo de excepciones si ocurre alguna
                    Console.WriteLine("Error al buscar ticket por sector: " + sectorCod + "  " + ex.Message);

                }
            }

            return ticketEncontrado;
        }

        public ObservableCollection<Ticket> TraerTickets(out decimal montoTotal)
        {
            ObservableCollection<Ticket> tickets = new ObservableCollection<Ticket>();
            montoTotal = 0; // Inicializamos el monto total a cero

            // Conexión a la base de datos
            string conexionString = "Data Source=.\\SQLEXPRESS;AttachDbFilename=C:\\Users\\lenovo\\Documents\\LPOOII_GRUPO08\\LPOOII_GRUPO08\\playa.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True";
            //string conexionString = "Data Source=.\\SQLEXPRESS;AttachDbFilename=C:\\Users\\maxi1\\OneDrive\\Documentos\\Programacion LPOO II\\LPOOII_GRUPO08\\LPOOII_GRUPO08\\playa.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True";
            SqlConnection conexion = new SqlConnection(conexionString);
            conexion.Open();

            // Consulta a la base de datos
            string consulta = "SELECT t.nro_ticket, t.fecha_hora_ent, t.fecha_hora_sal, t.cliente_dni, t.tv_codigo, c.apellido, " +
            "c.nombre, tv.descripcion AS TipoVehiculo, s.sector_codigo AS Sector, z.zona_Codigo AS Zona, t.patente, t.sector_codigo, " +
            "t.duracion, t.tarifa, t.total " +
            "FROM Ticket t " +
            "INNER JOIN Cliente c ON t.cliente_dni = c.cliente_dni " +
            "INNER JOIN TipoVehiculo tv ON t.tv_codigo = tv.tv_codigo " +
            "INNER JOIN Sector s ON t.sector_codigo = s.sector_codigo " +
            "INNER JOIN Zona z ON s.zona_codigo = z.zona_Codigo " +
            "WHERE t.fecha_hora_sal IS NOT NULL";

            SqlCommand comando = new SqlCommand(consulta, conexion);
            SqlDataReader reader = comando.ExecuteReader();

            // Llenado de la colección
            while (reader.Read())
            {
                Ticket ticket = new Ticket();
                ticket.TicketNro = int.Parse(reader["nro_ticket"].ToString());
                ticket.FechaHoraEnt = DateTime.Parse(reader["fecha_hora_ent"].ToString());
                ticket.FechaHoraSal = DateTime.Parse(reader["fecha_hora_sal"].ToString());
                ticket.ClienteDNI = reader["cliente_dni"].ToString();
                ticket.TvCodigo = int.Parse(reader["tv_codigo"].ToString());
                ticket.Patente = reader["patente"].ToString();
                ticket.SectorCodigo = int.Parse(reader["sector_codigo"].ToString());
                ticket.Duracion = float.Parse(reader["duracion"].ToString());
                ticket.Tarifa = decimal.Parse(reader["tarifa"].ToString());
                ticket.Total = decimal.Parse(reader["total"].ToString());

                // Nuevas asignaciones para datos de otras tablas
                ticket.ClienteApellido = reader["apellido"].ToString();
                ticket.ClienteNombre = reader["nombre"].ToString();
                ticket.TipoVehiculo = reader["TipoVehiculo"].ToString();
                ticket.Sector = reader["Sector"].ToString();
                ticket.Zona = reader["Zona"].ToString();

                tickets.Add(ticket);

                // Acumular el total
                montoTotal += ticket.Total;
            }

            // Cierre de la conexión
            conexion.Close();

            return tickets;
        }


        public ObservableCollection<Ticket> TraerTicketsAbiertos(out decimal montoTotal)
        {
            ObservableCollection<Ticket> tickets = new ObservableCollection<Ticket>();
            montoTotal = 0; // Inicializamos el monto total a cero

            // Conexión a la base de datos
            string conexionString = "Data Source=.\\SQLEXPRESS;AttachDbFilename=C:\\Users\\Cuno\\Documents\\LPOOII_GRUPO08\\LPOOII_GRUPO08\\playa.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True";
            //string conexionString = "Data Source=.\\SQLEXPRESS;AttachDbFilename=C:\\Users\\maxi1\\OneDrive\\Documentos\\Programacion LPOO II\\LPOOII_GRUPO08\\LPOOII_GRUPO08\\playa.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True";
            SqlConnection conexion = new SqlConnection(conexionString);
            conexion.Open();

            // Consulta a la base de datos
            string consulta = "SELECT t.nro_ticket, t.fecha_hora_ent, t.fecha_hora_sal, t.cliente_dni, t.tv_codigo, c.apellido, " +
            "c.nombre, tv.descripcion AS TipoVehiculo, s.sector_codigo AS Sector, z.zona_Codigo AS Zona, t.patente, t.sector_codigo, " +
            "t.duracion, t.tarifa, t.total " +
            "FROM Ticket t " +
            "INNER JOIN Cliente c ON t.cliente_dni = c.cliente_dni " +
            "INNER JOIN TipoVehiculo tv ON t.tv_codigo = tv.tv_codigo " +
            "INNER JOIN Sector s ON t.sector_codigo = s.sector_codigo " +
            "INNER JOIN Zona z ON s.zona_codigo = z.zona_Codigo " +
            "WHERE t.fecha_hora_sal IS NULL"; // Filtrar por fecha_hora_sal igual a NULL


            SqlCommand comando = new SqlCommand(consulta, conexion);
            SqlDataReader reader = comando.ExecuteReader();

            // Llenado de la colección
            while (reader.Read())
            {
                Ticket ticket = new Ticket();
                ticket.TicketNro = int.Parse(reader["nro_ticket"].ToString());
                ticket.FechaHoraEnt = DateTime.Parse(reader["fecha_hora_ent"].ToString());

                if (reader["fecha_hora_sal"] != DBNull.Value)
                {
                    ticket.FechaHoraSal = DateTime.Parse(reader["fecha_hora_sal"].ToString());
                }
                else
                {
                    ticket.FechaHoraSal = DateTime.MinValue; // Usar un valor predeterminado para representar null
                }
               
                ticket.ClienteDNI = reader["cliente_dni"].ToString();
                ticket.TvCodigo = int.Parse(reader["tv_codigo"].ToString());
                ticket.Patente = reader["patente"].ToString();
                ticket.SectorCodigo = int.Parse(reader["sector_codigo"].ToString());
                ticket.Tarifa = decimal.Parse(reader["tarifa"].ToString());
                ticket.Duracion = ticket.CalcularDuracion();
                // Nuevas asignaciones para datos de otras tablas
                ticket.ClienteApellido = reader["apellido"].ToString();
                ticket.ClienteNombre = reader["nombre"].ToString();
                ticket.TipoVehiculo = reader["TipoVehiculo"].ToString();
                ticket.Sector = reader["Sector"].ToString();
                ticket.Zona = reader["Zona"].ToString();

                tickets.Add(ticket);

                // Acumular el total
                montoTotal += ticket.Total;
            }

            // Cierre de la conexión
            conexion.Close();

            return tickets;
        }


        public ObservableCollection<Ticket> TraerTicketsPorFecha(DateTime fechaInicio, DateTime fechaFin, out decimal montoTotal)
        {
            ObservableCollection<Ticket> tickets = new ObservableCollection<Ticket>();
            montoTotal = 0; // Inicializamos el monto total a cero

            string conexionString = "Data Source=.\\SQLEXPRESS;AttachDbFilename=C:\\Users\\lenovo\\Documents\\LPOOII_GRUPO08\\LPOOII_GRUPO08\\playa.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True";
            SqlConnection conexion = new SqlConnection(conexionString);
            conexion.Open();

            string consulta = "SELECT t.nro_ticket, t.fecha_hora_ent, t.fecha_hora_sal, t.cliente_dni, t.tv_codigo, c.apellido, " +
            "c.nombre, tv.descripcion AS TipoVehiculo, s.sector_codigo AS Sector, z.zona_Codigo AS Zona, t.patente, t.sector_codigo, " +
            "t.duracion, t.tarifa, t.total " +
            "FROM Ticket t " +
            "INNER JOIN Cliente c ON t.cliente_dni = c.cliente_dni " +
            "INNER JOIN TipoVehiculo tv ON t.tv_codigo = tv.tv_codigo " +
            "INNER JOIN Sector s ON t.sector_codigo = s.sector_codigo " +
            "INNER JOIN Zona z ON s.zona_codigo = z.zona_Codigo " +
            "WHERE (t.fecha_hora_ent IS NULL OR (t.fecha_hora_ent >= @FechaInicio AND t.fecha_hora_sal <= @FechaFin))";

            SqlCommand comando = new SqlCommand(consulta, conexion);
            comando.Parameters.AddWithValue("@FechaInicio", fechaInicio == DateTime.MinValue ? (object)DBNull.Value : fechaInicio);
            comando.Parameters.AddWithValue("@FechaFin", fechaFin == DateTime.MinValue ? (object)DBNull.Value : fechaFin);

            using (SqlDataReader reader = comando.ExecuteReader())
            {
                while (reader.Read())
                {
                    Ticket ticket = new Ticket();
                    ticket.TicketNro = int.Parse(reader["nro_ticket"].ToString());
                    ticket.FechaHoraEnt = DateTime.Parse(reader["fecha_hora_ent"].ToString());
                    ticket.FechaHoraSal = DateTime.Parse(reader["fecha_hora_sal"].ToString());
                    ticket.ClienteDNI = reader["cliente_dni"].ToString();
                    ticket.TvCodigo = int.Parse(reader["tv_codigo"].ToString());
                    ticket.Patente = reader["patente"].ToString();
                    ticket.SectorCodigo = int.Parse(reader["sector_codigo"].ToString());
                    ticket.Duracion = float.Parse(reader["duracion"].ToString());
                    ticket.Tarifa = decimal.Parse(reader["tarifa"].ToString());
                    ticket.Total = decimal.Parse(reader["total"].ToString());

                    // Nuevas asignaciones para datos de otras tablas
                    ticket.ClienteApellido = reader["apellido"].ToString();
                    ticket.ClienteNombre = reader["nombre"].ToString();
                    ticket.TipoVehiculo = reader["TipoVehiculo"].ToString();
                    ticket.Sector = reader["Sector"].ToString();
                    ticket.Zona = reader["Zona"].ToString();

                    tickets.Add(ticket);

                    // Acumular el total
                    montoTotal += ticket.Total;
                }
            }

            conexion.Close();

            return tickets;
        }

    }
}
