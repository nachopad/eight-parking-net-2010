using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Collections.ObjectModel;

namespace ClasesBase
{
    public class TrabajarTiposVehiculo
    {

        public DataTable TraerTiposVehiculo()
        {
            DataTable dt = new DataTable();
            using (SqlConnection connection = new SqlConnection(ClasesBase.Properties.Settings.Default.playaConnectionString))
            {
                connection.Open();
                string query = "SELECT tv_codigo, descripcion, tarifa, imagen FROM TipoVehiculo";
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                adapter.Fill(dt);
            }
            return dt;
        }

        public ObservableCollection<TipoVehiculo> TraerTiposVehiculosObservable()
        {
            ObservableCollection<TipoVehiculo> vehiculos = new ObservableCollection<TipoVehiculo>();
            SqlConnection conexion = new SqlConnection(ClasesBase.Properties.Settings.Default.playaConnectionString);
            conexion.Open();
            string consulta = "SELECT * FROM TipoVehiculo";
            SqlCommand comando = new SqlCommand(consulta, conexion);
            SqlDataReader reader = comando.ExecuteReader();

            while (reader.Read())
            {
                TipoVehiculo tipo = new TipoVehiculo();
                tipo.Descripcion = reader["descripcion"].ToString();
                tipo.Tarifa = decimal.Parse(reader["tarifa"].ToString());
                tipo.TVCodigo = int.Parse(reader["tv_codigo"].ToString());
                tipo.Imagen = reader["imagen"].ToString();
                vehiculos.Add(tipo);
            }
            conexion.Close();
            Console.WriteLine("Aqui abajo se vera el vehiculo");
            Console.WriteLine(vehiculos[0].Descripcion);
            return vehiculos;
        }

        public static void crearTipoVehiculo(TipoVehiculo vehiculo)
        {
            SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.playaConnectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "RegistrarVehiculo";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = cnn;
            cmd.Parameters.AddWithValue("@descripcion", vehiculo.Descripcion);
            cmd.Parameters.AddWithValue("@tarifa", vehiculo.Tarifa);
            cmd.Parameters.AddWithValue("@imagen", vehiculo.Imagen);
            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();
        }

        public static void eliminarVehiculo(int tvCodigo)
        {
            SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.playaConnectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "EliminarVehiculo";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = cnn;
            cmd.Parameters.AddWithValue("@tvCodigo", tvCodigo);
            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();
        }

        public static void modificarVehiculo(TipoVehiculo vehiculo)
        {
            SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.playaConnectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "ModificarVehiculo";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = cnn;
            cmd.Parameters.AddWithValue("@tvCodigo", vehiculo.TVCodigo);
            cmd.Parameters.AddWithValue("@descripcion", vehiculo.Descripcion);
            cmd.Parameters.AddWithValue("@tarifa", vehiculo.Tarifa);
            cmd.Parameters.AddWithValue("@imagen", vehiculo.Imagen);
            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();
        }
        

        public static int obtenerCodigoMasGrande()
        {
            SqlConnection conexion = new SqlConnection(ClasesBase.Properties.Settings.Default.playaConnectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "ConsultarCodigoMasGrandeVehiculo";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = conexion;
            conexion.Open();
            int maxCodigo = (int)cmd.ExecuteScalar();
            conexion.Close();
            return maxCodigo;
        }

        public string ObtenerDescripcionPorTarifa(decimal tarifaBuscada)
        {
            string descripcion = string.Empty;
            SqlConnection conexion = new SqlConnection(ClasesBase.Properties.Settings.Default.playaConnectionString);
            conexion.Open();
            string consulta = "SELECT descripcion FROM TipoVehiculo WHERE tarifa = @TarifaBuscada";
            SqlCommand comando = new SqlCommand(consulta, conexion);
            comando.Parameters.AddWithValue("@TarifaBuscada", tarifaBuscada);
            SqlDataReader reader = comando.ExecuteReader();

            if (reader.Read())
            {
                descripcion = reader["descripcion"].ToString();
            }
            conexion.Close();
            return descripcion;
        }

        public static string ObtenerDescripcionPorCodigo(int codigo)
        {
            string descripcion = string.Empty;
            SqlConnection conexion = new SqlConnection(ClasesBase.Properties.Settings.Default.playaConnectionString);
            conexion.Open();
            string consulta = "SELECT descripcion FROM TipoVehiculo WHERE tv_codigo = @codigo";
            SqlCommand comando = new SqlCommand(consulta, conexion);
            comando.Parameters.AddWithValue("@codigo", codigo);
            SqlDataReader reader = comando.ExecuteReader();

            if (reader.Read())
            {
                descripcion = reader["descripcion"].ToString();
            }
            conexion.Close();
            return descripcion;
        }

        public TipoVehiculo ObtenerTipoPorCodigo(int cod)
        {
            TipoVehiculo tipo = new TipoVehiculo();
            SqlConnection conexion = new SqlConnection(ClasesBase.Properties.Settings.Default.playaConnectionString);
            conexion.Open();
            string consulta = "SELECT * FROM TipoVehiculo WHERE tv_codigo = @cod";
            SqlCommand comando = new SqlCommand(consulta, conexion);
            comando.Parameters.AddWithValue("@cod", cod);
            SqlDataReader reader = comando.ExecuteReader();

            if (reader.Read())
            {
                tipo.Descripcion = reader["descripcion"].ToString();
                tipo.Tarifa = decimal.Parse(reader["tarifa"].ToString());
                tipo.TVCodigo = int.Parse(reader["tv_codigo"].ToString());
            }
            conexion.Close();
            return tipo;
        }

    }
}
