using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace ClasesBase
{
    public class TrabajarTicket
    {
        public void registrarTicket(Ticket ticket)
        {
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
            string conexionString = "Data Source=.\\SQLEXPRESS;AttachDbFilename=C:\\Users\\Lilia\\Documents\\Visual Studio 2010\\Projects\\LPOOII_GRUPO08\\LPOOII_GRUPO08\\playa.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True";
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
    }
}
