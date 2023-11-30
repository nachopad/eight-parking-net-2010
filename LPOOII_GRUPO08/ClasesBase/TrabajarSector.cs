using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using System.Data.SqlClient;

namespace ClasesBase
{
    public class TrabajarSector
    {
        public ObservableCollection<Sector> TraerSectores()
        {
            ObservableCollection<Sector> sectores = new ObservableCollection<Sector>();
            SqlConnection conexion = new SqlConnection(ClasesBase.Properties.Settings.Default.playaConnectionString);
            conexion.Open();
            string consulta = "SELECT * FROM Sector WHERE habilitado=1";
            SqlCommand comando = new SqlCommand(consulta, conexion);
            SqlDataReader reader = comando.ExecuteReader();

            while (reader.Read())
            {
                Sector sector = new Sector();
                sector.Descripcion = reader["descripcion"].ToString();
                sector.Identificador = reader["identificador"].ToString();
                sector.Habilitado = bool.Parse(reader["habilitado"].ToString());
                sector.SectorCodigo = int.Parse(reader["sector_codigo"].ToString());
                sectores.Add(sector);
            }
            conexion.Close();
            return sectores;
        }

        public ObservableCollection<Sector> TraerSectoresOcupados()
        {
            ObservableCollection<Sector> sectores = new ObservableCollection<Sector>();
            SqlConnection conexion = new SqlConnection(ClasesBase.Properties.Settings.Default.playaConnectionString);
            conexion.Open();
            string consulta = "SELECT * FROM Sector WHERE habilitado=0";
            SqlCommand comando = new SqlCommand(consulta, conexion);
            SqlDataReader reader = comando.ExecuteReader();

            while (reader.Read())
            {
                Sector sector = new Sector();
                sector.Descripcion = reader["descripcion"].ToString();
                sector.Identificador = reader["identificador"].ToString();
                sector.Habilitado = bool.Parse(reader["habilitado"].ToString());
                sector.SectorCodigo = int.Parse(reader["sector_codigo"].ToString());
                sectores.Add(sector);
            }
            conexion.Close();
            return sectores;
        }

        public ObservableCollection<Sector> TraerTodosLosSectores(int codigoZona)
        {
            ObservableCollection<Sector> sectores = new ObservableCollection<Sector>();
            SqlConnection conexion = new SqlConnection(ClasesBase.Properties.Settings.Default.playaConnectionString);
            conexion.Open();
            string consulta = "SELECT * FROM Sector WHERE zona_codigo = @codigoZona";
            SqlCommand comando = new SqlCommand(consulta, conexion);
            comando.Parameters.AddWithValue("@codigoZona", codigoZona);
            SqlDataReader reader = comando.ExecuteReader();

            while (reader.Read())
            {
                Sector sector = new Sector();
                sector.Descripcion = reader["descripcion"].ToString();
                sector.Identificador = reader["identificador"].ToString();
                sector.Habilitado = bool.Parse(reader["habilitado"].ToString());
                sector.SectorCodigo = int.Parse(reader["sector_codigo"].ToString());
                sectores.Add(sector);
            }
            conexion.Close();
            return sectores;
        }

    }
}
