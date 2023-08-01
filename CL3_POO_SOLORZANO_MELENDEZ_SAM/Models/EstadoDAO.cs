using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace CL3_POO_SOLORZANO_MELENDEZ_SAM.Models
{
    public class EstadoDAO
    {
        static string cadena = ConfigurationManager.ConnectionStrings["cn"].ConnectionString;
        private SqlConnection cn = new SqlConnection(cadena);
        public int InsertarEstado(Estado estado)
        {
            int rowsAffected = 0;

            string query = "INSERT INTO Estado (Descripcion) VALUES (@descripcion)";

         
                    cn.Open();
            SqlCommand command = new SqlCommand(query, cn);
            
                    command.Parameters.AddWithValue("@descripcion", estado.Descripcion);

                    rowsAffected = command.ExecuteNonQuery();
            
            cn.Close();

            command.Dispose();

            return rowsAffected;
        }

        public List<Estado> ObtenerEstados()
        {
            List<Estado> estados = new List<Estado>();

            string query = "SELECT IdEstado, Descripcion FROM Estado";

            cn.Open();
            SqlCommand command = new SqlCommand(query, cn);
            
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        Estado estado = new Estado();
                        estado.IdEstado = Convert.ToInt32(reader["IdEstado"]);
                        estado.Descripcion = reader["Descripcion"].ToString();
                        estados.Add(estado);
                    }
                command.Dispose();
                reader.Close();
            command.Dispose();

            cn.Close ();

            return estados;
        }

        public int ActualizarEstado(Estado estado)
        {
            int rowsAffected = 0;

            string query = "UPDATE Estado SET Descripcion = @descripcion WHERE IdEstado = @idEstado";

           cn.Open ();
            SqlCommand command = new SqlCommand(query, cn);
                
                    command.Parameters.AddWithValue("@descripcion", estado.Descripcion);
                    command.Parameters.AddWithValue("@idEstado", estado.IdEstado);

                    rowsAffected = command.ExecuteNonQuery();
            command.Dispose();
                cn.Close();
            

            return rowsAffected;
        }

        public int EliminarEstado(int idEstado)
        {
            int rowsAffected = 0;

            string query = "DELETE FROM Estado WHERE IdEstado = @idEstado";
            cn.Open();
            SqlCommand command = new SqlCommand(query, cn);
                
                    command.Parameters.AddWithValue("@idEstado", idEstado);
                    rowsAffected = command.ExecuteNonQuery();
                
            cn.Close();

            command.Dispose();
            return rowsAffected;
        }
    }
}