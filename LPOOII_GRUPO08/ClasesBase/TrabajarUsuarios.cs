using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Collections.ObjectModel;

namespace ClasesBase
{
    public class TrabajarUsuarios
    {
        public ObservableCollection<Usuario> TraerUsuario()
        {
            ObservableCollection<Usuario> usuarios = new ObservableCollection<Usuario>();

            // Conexión a la base de datos
           // string conexionString = "Data Source=.\\SQLEXPRESS;AttachDbFilename=C:\\Users\\lenovo\\Documents\\LPOOII_GRUPO08\\LPOOII_GRUPO08\\playa.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True";
            //string conexionString = "Data Source=.\\SQLEXPRESS;AttachDbFilename=C:\\Users\\maxi1\\OneDrive\\Documentos\\Programacion LPOO II\\LPOOII_GRUPO08\\LPOOII_GRUPO08\\playa.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True";
            string conexionString = "Data Source=.\\SQLEXPRESS;AttachDbFilename=C:\\Users\\admin\\lpoo\\LPOOII_GRUPO08\\LPOOII_GRUPO08\\playa.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True";

            SqlConnection conexion = new SqlConnection(conexionString);
            conexion.Open();

            // Consulta a la base de datos
            string consulta = "SELECT * FROM Usuario";
            SqlCommand comando = new SqlCommand(consulta, conexion);
            SqlDataReader reader = comando.ExecuteReader();

            // Llenado de la colección
            while (reader.Read())
            {
                Usuario usuario = new Usuario();
                usuario.IdUsuario = int.Parse(reader["id_usuario"].ToString());
                usuario.UserName = reader["username"].ToString();
                usuario.Password = reader["password"].ToString();
                usuario.Apellido = reader["apellido"].ToString();
                usuario.Nombre = reader["nombre"].ToString();
                usuario.Rol = reader["rol"].ToString();

                usuarios.Add(usuario);
            }

            // Cierre de la conexión
            conexion.Close();

            return usuarios;
        }

        public static void eliminarUsuario(int id)
        {
            string conexionString = "Data Source=.\\SQLEXPRESS;AttachDbFilename=C:\\Users\\lenovo\\Documents\\LPOOII_GRUPO08\\LPOOII_GRUPO08\\playa.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True";
            //string conexionString = "Data Source=.\\SQLEXPRESS;AttachDbFilename=C:\\Users\\maxi1\\OneDrive\\Documentos\\Programacion LPOO II\\LPOOII_GRUPO08\\LPOOII_GRUPO08\\playa.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True";
            //string conexionString = "Data Source=.\\SQLEXPRESS;AttachDbFilename=C:\\Users\\argca\\OneDrive\\Documentos\\LPOOII_GRUPO08\\LPOOII_GRUPO08\\playa.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True";
            SqlConnection cnn = new SqlConnection(conexionString);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "EliminarUsuario";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = cnn;
            cmd.Parameters.AddWithValue("@id", id );
            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();
        }


        public static void modificarUsuario(Usuario usuario)
        {
            string conexionString = "Data Source=.\\SQLEXPRESS;AttachDbFilename=C:\\Users\\lenovo\\Documents\\LPOOII_GRUPO08\\LPOOII_GRUPO08\\playa.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True";
            //string conexionString = "Data Source=.\\SQLEXPRESS;AttachDbFilename=C:\\Users\\maxi1\\OneDrive\\Documentos\\Programacion LPOO II\\LPOOII_GRUPO08\\LPOOII_GRUPO08\\playa.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True";
            //string conexionString = "Data Source=.\\SQLEXPRESS;AttachDbFilename=C:\\Users\\argca\\OneDrive\\Documentos\\LPOOII_GRUPO08\\LPOOII_GRUPO08\\playa.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True";
            SqlConnection cnn = new SqlConnection(conexionString);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "ModificarUsuario";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = cnn;
            cmd.Parameters.AddWithValue("@id", usuario.IdUsuario);
            cmd.Parameters.AddWithValue("@usu", usuario.UserName);
            cmd.Parameters.AddWithValue("@pas", usuario.Password);
            cmd.Parameters.AddWithValue("@nom", usuario.Nombre);
            cmd.Parameters.AddWithValue("@ape", usuario.Apellido);
            cmd.Parameters.AddWithValue("@rol", usuario.Rol);
            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();
        }

        public static void registrarUsuario(Usuario usuario)
        {
            string conexionString = "Data Source=.\\SQLEXPRESS;AttachDbFilename=C:\\Users\\lenovo\\Documents\\LPOOII_GRUPO08\\LPOOII_GRUPO08\\playa.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True";
            //string conexionString = "Data Source=.\\SQLEXPRESS;AttachDbFilename=C:\\Users\\maxi1\\OneDrive\\Documentos\\Programacion LPOO II\\LPOOII_GRUPO08\\LPOOII_GRUPO08\\playa.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True";
            //string conexionString = "Data Source=.\\SQLEXPRESS;AttachDbFilename=C:\\Users\\argca\\OneDrive\\Documentos\\LPOOII_GRUPO08\\LPOOII_GRUPO08\\playa.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True";
            SqlConnection cnn = new SqlConnection(conexionString);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "RegistrarUsuario";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = cnn;
            cmd.Parameters.AddWithValue("@usu", usuario.UserName);
            cmd.Parameters.AddWithValue("@pas", usuario.Password);
            cmd.Parameters.AddWithValue("@nom", usuario.Nombre);
            cmd.Parameters.AddWithValue("@ape", usuario.Apellido);
            cmd.Parameters.AddWithValue("@rol", usuario.Rol);
            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();
        }

        public Usuario obtenerUsuarioLogin(string nombreUser, string password)
        {
            Usuario usuario = null;

            // Conexión a la base de datos
            //string conexionString = "Data Source=.\\SQLEXPRESS;AttachDbFilename=C:\\Users\\maxi1\\OneDrive\\Documentos\\Programacion LPOO II\\LPOOII_GRUPO08\\LPOOII_GRUPO08\\playa.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True";
            //string conexionString = "Data Source=.\\SQLEXPRESS;AttachDbFilename=C:\\Users\\Cuno\\Documents\\LPOOII_GRUPO08\\LPOOII_GRUPO08\\playa.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True";
            string conexionString = "Data Source=.\\SQLEXPRESS;AttachDbFilename=C:\\Users\\argca\\OneDrive\\Documentos\\LPOOII_GRUPO08\\LPOOII_GRUPO08\\playa.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True";
            using (SqlConnection conexion = new SqlConnection(conexionString))
            {
                string consulta = "SELECT * FROM Usuario WHERE username=@user AND password=@pass";
                SqlCommand comando = new SqlCommand(consulta, conexion);
                comando.Parameters.AddWithValue("@user", nombreUser);
                comando.Parameters.AddWithValue("@pass", password);

                try
                {
                    conexion.Open();
                    SqlDataReader reader = comando.ExecuteReader();

                    if (reader.Read())
                    {
                        usuario = new Usuario();
                        usuario.IdUsuario = int.Parse(reader["id_usuario"].ToString());
                        usuario.UserName = reader["username"].ToString();
                        usuario.Password = reader["password"].ToString();
                        usuario.Apellido = reader["apellido"].ToString();
                        usuario.Nombre = reader["nombre"].ToString();
                        usuario.Rol = reader["rol"].ToString();
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    // Manejo de excepciones si ocurre alguna
                    Console.WriteLine("No existe el usuario o el password es incorrecto: " + ex.Message);
                }
            }

            return usuario;
        }
    }
}

