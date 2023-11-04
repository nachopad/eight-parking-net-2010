using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace ClasesBase
{
    public class TrabajarCliente
    {
        public Cliente ObtenerClientePorDni(string dni)
        {
            Cliente cliente = new Cliente();
            string connectionString = "Data Source=.\\SQLEXPRESS;AttachDbFilename=C:\\Users\\lenovo\\Documents\\LPOOII_GRUPO08\\LPOOII_GRUPO08\\playa.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("SELECT * FROM Cliente WHERE cliente_dni = @Dni", connection))
                {
                    command.Parameters.AddWithValue("@Dni", dni);

                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {

                        cliente.ClienteDNI = reader["cliente_dni"].ToString();
                        cliente.Nombre = reader["nombre"].ToString();
                        cliente.Apellido = reader["apellido"].ToString();
                        cliente.Telefono = reader["telefono"].ToString();
                    }
                }
            }

            return cliente;
        }
    }
}
