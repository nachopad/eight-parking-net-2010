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
            //string conexionString = "Data Source=.\\SQLEXPRESS;AttachDbFilename=C:\\Users\\maxi1\\OneDrive\\Documentos\\Programacion LPOO II\\LPOOII_GRUPO08\\LPOOII_GRUPO08\\playa.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True";
            string conexionString = "Data Source=.\\SQLEXPRESS;AttachDbFilename=C:\\Users\\argca\\OneDrive\\Documentos\\LPOOII_GRUPO08\\LPOOII_GRUPO08\\playa.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True";
            using (SqlConnection connection = new SqlConnection(conexionString))
            {
                connection.Open();
                string query = "SELECT tv_codigo, descripcion, tarifa FROM TipoVehiculo";
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                adapter.Fill(dt);
            }
            return dt;
        }

        public ObservableCollection<TipoVehiculo> TraerTiposVehiculosObservable()
        {
            ObservableCollection<TipoVehiculo> vehiculos = new ObservableCollection<TipoVehiculo>();

            // Conexión a la base de datos
            //string conexionString = "Data Source=.\\SQLEXPRESS;AttachDbFilename=C:\\Users\\maxi1\\OneDrive\\Documentos\\Programacion LPOO II\\LPOOII_GRUPO08\\LPOOII_GRUPO08\\playa.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True";
            //string conexionString = "Data Source=.\\SQLEXPRESS;AttachDbFilename=C:\\Users\\argca\\OneDrive\\Documentos\\LPOOII_GRUPO08\\LPOOII_GRUPO08\\playa.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True";
            string conexionString = "Data Source=.\\SQLEXPRESS;AttachDbFilename=C:\\Users\\admin\\lpoo\\v2\\LPOOII_GRUPO08\\LPOOII_GRUPO08\\playa.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True";
            SqlConnection conexion = new SqlConnection(conexionString);
            conexion.Open();

            // Consulta a la base de datos
            string consulta = "SELECT * FROM TipoVehiculo";
            SqlCommand comando = new SqlCommand(consulta, conexion);
            SqlDataReader reader = comando.ExecuteReader();

            // Llenado de la colección
            while (reader.Read())
            {
                TipoVehiculo tipo = new TipoVehiculo();
                tipo.Descripcion = reader["descripcion"].ToString();
                tipo.Tarifa = decimal.Parse(reader["tarifa"].ToString());
                tipo.TVCodigo = int.Parse(reader["tv_codigo"].ToString());
                vehiculos.Add(tipo);
            }

            // Cierre de la conexión
            conexion.Close();
            Console.WriteLine("Aqui abajo se vera el vehiculo");
            Console.WriteLine(vehiculos[0].Descripcion);
            return vehiculos;
        }

        public static void crearTipoVehiculo(TipoVehiculo vehiculo)
        {
            string conexionString = "Data Source=.\\SQLEXPRESS;AttachDbFilename=C:\\Users\\maxi1\\OneDrive\\Documentos\\Programacion LPOO II\\LPOOII_GRUPO08\\LPOOII_GRUPO08\\playa.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True";
            SqlConnection cnn = new SqlConnection(conexionString);
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

        //editar
        //eliminar

        
        public static void eliminarVehiculo(int tvCodigo)
        {
            string conexionString = "Data Source=.\\SQLEXPRESS;AttachDbFilename=C:\\Users\\lenovo\\Documents\\LPOOII_GRUPO08\\LPOOII_GRUPO08\\playa.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True";
            //string conexionString = "Data Source=.\\SQLEXPRESS;AttachDbFilename=C:\\Users\\maxi1\\OneDrive\\Documentos\\Programacion LPOO II\\LPOOII_GRUPO08\\LPOOII_GRUPO08\\playa.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True";
            //string conexionString = "Data Source=.\\SQLEXPRESS;AttachDbFilename=C:\\Users\\argca\\OneDrive\\Documentos\\LPOOII_GRUPO08\\LPOOII_GRUPO08\\playa.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True";
            SqlConnection cnn = new SqlConnection(conexionString);
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
            string conexionString = "Data Source=.\\SQLEXPRESS;AttachDbFilename=C:\\Users\\lenovo\\Documents\\LPOOII_GRUPO08\\LPOOII_GRUPO08\\playa.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True";
            //string conexionString = "Data Source=.\\SQLEXPRESS;AttachDbFilename=C:\\Users\\maxi1\\OneDrive\\Documentos\\Programacion LPOO II\\LPOOII_GRUPO08\\LPOOII_GRUPO08\\playa.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True";
            //string conexionString = "Data Source=.\\SQLEXPRESS;AttachDbFilename=C:\\Users\\argca\\OneDrive\\Documentos\\LPOOII_GRUPO08\\LPOOII_GRUPO08\\playa.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True";
            SqlConnection cnn = new SqlConnection(conexionString);
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
            string conexionString = "Data Source=.\\SQLEXPRESS;AttachDbFilename=C:\\Users\\maxi1\\OneDrive\\Documentos\\Programacion LPOO II\\LPOOII_GRUPO08\\LPOOII_GRUPO08\\playa.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True";
            //string conexionString = "Data Source=.\\SQLEXPRESS;AttachDbFilename=C:\\Users\\Cuno\\Documents\\LPOOII_GRUPO08\\LPOOII_GRUPO08\\playa.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True";
            
            SqlConnection conexion = new SqlConnection(conexionString);
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

            // Conexión a la base de datos
            string conexionString = "Data Source=.\\SQLEXPRESS;AttachDbFilename=C:\\Users\\maxi1\\OneDrive\\Documentos\\Programacion LPOO II\\LPOOII_GRUPO08\\LPOOII_GRUPO08\\playa.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True";
            //string conexionString = "Data Source=.\\SQLEXPRESS;AttachDbFilename=C:\\Users\\Cuno\\Documents\\LPOOII_GRUPO08\\LPOOII_GRUPO08\\playa.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True";
            SqlConnection conexion = new SqlConnection(conexionString);
            conexion.Open();

            // Consulta a la base de datos
            string consulta = "SELECT descripcion FROM TipoVehiculo WHERE tarifa = @TarifaBuscada";
            SqlCommand comando = new SqlCommand(consulta, conexion);
            comando.Parameters.AddWithValue("@TarifaBuscada", tarifaBuscada);

            SqlDataReader reader = comando.ExecuteReader();

            // Verificación de existencia de resultados y obtención de la descripción
            if (reader.Read())
            {
                descripcion = reader["descripcion"].ToString();
            }

            // Cierre de la conexión
            conexion.Close();

            return descripcion;
        }


        //Obtención del tipo en base al codigo que se pasa por parametros
        //Agregado por Carlos Sanchez
        public TipoVehiculo ObtenerTipoPorCodigo(int cod)
        {
            TipoVehiculo tipo = new TipoVehiculo();

            // Conexión a la base de datos
            //string conexionString = "Data Source=.\\SQLEXPRESS;AttachDbFilename=C:\\Users\\lenovo\\Documents\\LPOOII_GRUPO08\\LPOOII_GRUPO08\\playa.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True";
            //string conexionString = "Data Source=.\\SQLEXPRESS;AttachDbFilename=C:\\Users\\maxi1\\OneDrive\\Documentos\\Programacion LPOO II\\LPOOII_GRUPO08\\LPOOII_GRUPO08\\playa.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True";
            //string conexionString = "Data Source=.\\SQLEXPRESS;AttachDbFilename=C:\\Users\\maxi1\\OneDrive\\Documentos\\Programacion LPOO II\\TP1LPOO II\\LPOOII_GRUPO08\\playa.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True";
            //string conexionString = "Data Source=.\\SQLEXPRESS;AttachDbFilename=C:\\Users\\Cuno\\Documents\\LPOOII_GRUPO08\\LPOOII_GRUPO08\\playa.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True";
            string conexionString = "Data Source=.\\SQLEXPRESS;AttachDbFilename=C:\\Users\\argca\\OneDrive\\Documentos\\LPOOII_GRUPO08\\LPOOII_GRUPO08\\playa.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True";
            SqlConnection conexion = new SqlConnection(conexionString);
            conexion.Open();

            // Consulta a la base de datos
            string consulta = "SELECT * FROM TipoVehiculo WHERE tv_codigo = @cod";
            SqlCommand comando = new SqlCommand(consulta, conexion);
            comando.Parameters.AddWithValue("@cod", cod);

            SqlDataReader reader = comando.ExecuteReader();

            // Verificación de existencia de resultados y obtención de la descripción
            if (reader.Read())
            {
                tipo.Descripcion = reader["descripcion"].ToString();
                tipo.Tarifa = decimal.Parse(reader["tarifa"].ToString());
                tipo.TVCodigo = int.Parse(reader["tv_codigo"].ToString());
            }

            // Cierre de la conexión
            conexion.Close();

            return tipo;
        }

    }
}
