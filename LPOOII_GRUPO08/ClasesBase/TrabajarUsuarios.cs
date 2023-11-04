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
            string conexionString = "Data Source=.\\SQLEXPRESS;AttachDbFilename=C:\\Users\\lenovo\\Documents\\LPOOII_GRUPO08\\LPOOII_GRUPO08\\playa.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True";
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
                usuario.UserName = reader["UserName"].ToString();
                usuario.Password = reader["Password"].ToString();
                usuario.Apellido = reader["Apellido"].ToString();
                usuario.Nombre = reader["Nombre"].ToString();
                usuario.Rol = reader["Rol"].ToString();

                usuarios.Add(usuario);
            }

            // Cierre de la conexión
            conexion.Close();

            return usuarios;
        }
    }
}

