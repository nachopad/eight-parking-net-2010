using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Collections.ObjectModel;
namespace ClasesBase
{
    public class TrabajarCliente
    {
        public ObservableCollection<Cliente> TraerClientes()
        {
            ObservableCollection<Cliente> clientes = new ObservableCollection<Cliente>();
            SqlConnection conexion = new SqlConnection(ClasesBase.Properties.Settings.Default.playaConnectionString);
            conexion.Open();
            string consulta = "SELECT * FROM Cliente";
            SqlCommand comando = new SqlCommand(consulta, conexion);
            SqlDataReader reader = comando.ExecuteReader();
            while (reader.Read())
            {
                Cliente cliente = new Cliente();
                cliente.IdCliente = int.Parse(reader["id_cliente"].ToString());
                cliente.Nombre = reader["nombre"].ToString();
                cliente.Apellido = reader["apellido"].ToString();
                cliente.ClienteDNI = reader["cliente_dni"].ToString();
                cliente.Telefono = reader["telefono"].ToString();
                clientes.Add(cliente);
            }
            conexion.Close();
            return clientes;
        }

        public Cliente ObtenerClientePorDni(string dni)
        {
            Cliente cliente = new Cliente();
            using (SqlConnection connection = new SqlConnection(ClasesBase.Properties.Settings.Default.playaConnectionString))
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

        public void registrarCliente(Cliente cliente)
        {
            SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.playaConnectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "RegistrarCliente";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = cnn;
            cmd.Parameters.AddWithValue("@apellido", cliente.Apellido);
            cmd.Parameters.AddWithValue("@dni", cliente.ClienteDNI);
            cmd.Parameters.AddWithValue("@nombre", cliente.Nombre);
            cmd.Parameters.AddWithValue("@telefono", cliente.Telefono);

            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();

        }

        public static void eliminarCliente(int id)
        {
            SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.playaConnectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "EliminarCliente";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = cnn;
            cmd.Parameters.AddWithValue("@id", id);
            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();
        }

        public static void modificarCliente(Cliente cliente)
        {
            SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.playaConnectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "ModificarCliente";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = cnn;
            cmd.Parameters.AddWithValue("@id", cliente.IdCliente);
            cmd.Parameters.AddWithValue("@nombre", cliente.Nombre);
            cmd.Parameters.AddWithValue("@apellido", cliente.Apellido);
            cmd.Parameters.AddWithValue("@telefono", cliente.Telefono);
            cmd.Parameters.AddWithValue("@dni", cliente.ClienteDNI);
            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();
        }

        public bool ClienteExisteEnBaseDeDatos(string dni)
        {
            using (SqlConnection conexion = new SqlConnection(ClasesBase.Properties.Settings.Default.playaConnectionString))
            {
                conexion.Open();
                string consulta = "SELECT COUNT(*) FROM Cliente WHERE cliente_dni = @dni";
                using (SqlCommand comando = new SqlCommand(consulta, conexion))
                {
                    comando.Parameters.AddWithValue("@dni", dni);
                    int cantidadClientes = (int)comando.ExecuteScalar();
                    return cantidadClientes > 0;
                }
            }
        }

        public Cliente ObtenerClientePorId(int id)
        {
            Cliente cliente = new Cliente();
            using (SqlConnection connection = new SqlConnection(ClasesBase.Properties.Settings.Default.playaConnectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("SELECT * FROM Cliente WHERE id_cliente = @id", connection))
                {
                    command.Parameters.AddWithValue("@id", id);
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
