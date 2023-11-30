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
            SqlConnection conexion = new SqlConnection(ClasesBase.Properties.Settings.Default.playaConnectionString);
            conexion.Open();
            string consulta = "SELECT * FROM Usuario";
            SqlCommand comando = new SqlCommand(consulta, conexion);
            SqlDataReader reader = comando.ExecuteReader();

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
            conexion.Close();
            return usuarios;
        }

        public static void eliminarUsuario(int id)
        {
            SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.playaConnectionString);
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
            SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.playaConnectionString);
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
            SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.playaConnectionString);
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
            using (SqlConnection conexion = new SqlConnection(ClasesBase.Properties.Settings.Default.playaConnectionString))
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
                    Console.WriteLine("No existe el usuario o el password es incorrecto: " + ex.Message);
                }
            }
            return usuario;
        }

        public static bool UsuarioExisteEnBaseDeDatos(string userName)
        {
            using (SqlConnection conexion = new SqlConnection(ClasesBase.Properties.Settings.Default.playaConnectionString))
            {
                conexion.Open();
                string consulta = "SELECT COUNT(*) FROM Usuario WHERE username = @userName";
                using (SqlCommand comando = new SqlCommand(consulta, conexion))
                {
                    comando.Parameters.AddWithValue("@userName", userName);
                    int cantidadUsuarios = (int)comando.ExecuteScalar();
                    return cantidadUsuarios > 0;
                }
            }
        }
    }
}

