using System;
using System.Data;
using System.Data.SqlClient;
using ClasesBase; // Asegúrate de importar el espacio de nombres de tu clase Cliente

public class TrabajarClientes
{
    private string connectionString; // La cadena de conexión a tu base de datos

    public TrabajarClientes(string connectionString)
    {
        this.connectionString = connectionString;
    }

    public Cliente TraerCliente(string clienteDNI)
    {
        Cliente oCliente = new Cliente();

        using (SqlConnection connection = new SqlConnection("Data Source=.\\SQLEXPRESS;AttachDbFilename=C:\\Users\\Cuno\\Documents\\LPOOII_GRUPO08\\LPOOII_GRUPO08\\playa.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True"))
        {
            connection.Open();
            string query = "SELECT Apellido, Nombre, Telefono FROM Cliente WHERE ClienteDNI = @DNI";

            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@DNI", clienteDNI);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        oCliente.Apellido = reader["Apellido"].ToString();
                        oCliente.Nombre = reader["Nombre"].ToString();
                        oCliente.Telefono = reader["Telefono"].ToString();
                        oCliente.ClienteDNI = clienteDNI;
                    }
                }
            }
        }

        return oCliente;
    }
}
