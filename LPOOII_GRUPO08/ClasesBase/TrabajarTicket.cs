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
    }
}
