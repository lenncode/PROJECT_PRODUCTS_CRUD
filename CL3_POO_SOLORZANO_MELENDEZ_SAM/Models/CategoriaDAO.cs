using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace CL3_POO_SOLORZANO_MELENDEZ_SAM.Models
{
    public class CategoriaDAO

    {
        static string cadena = ConfigurationManager.ConnectionStrings["cn"].ConnectionString;
        private SqlConnection cn = new SqlConnection(cadena);
        public List<Categoria> ObtenerCategorias()
        {
            List<Categoria> categorias = new List<Categoria>();

            string query = "SELECT idcategoria, descripcion FROM categoria";

            cn.Open();
            SqlCommand command = new SqlCommand(query, cn);
            
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Categoria categoria = new Categoria();
                    categoria.IdCategoria = Convert.ToInt32(reader["idcategoria"]);
                    categoria.Descripcion = reader["descripcion"].ToString();
                    categorias.Add(categoria);
                }

                reader.Close();
                cn.Close();

            command.Dispose();

            return categorias;
        }

        public List<Categoria> BuscarCategoriaPorDescripcion(string descripcion)
        {
            List<Categoria> categorias = new List<Categoria>();

            string query = "SELECT idcategoria, descripcion FROM categoria WHERE descripcion LIKE @descripcion";

            cn.Open();
            SqlCommand command = new SqlCommand(query, cn);
            
                command.Parameters.AddWithValue("@descripcion", "%" + descripcion + "%");

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Categoria categoria = new Categoria();
                    categoria.IdCategoria = Convert.ToInt32(reader["idcategoria"]);
                    categoria.Descripcion = reader["descripcion"].ToString();
                    categorias.Add(categoria);
                }

                reader.Close();
                cn.Close();
            
            command.Dispose();

            return categorias;
        }
        public int InsertarCategoria(Categoria categoria)
        {
            int rowsAffected = 0;

            string query = "INSERT INTO categoria (descripcion) VALUES (@descripcion)";

            cn.Open();
            SqlCommand command = new SqlCommand(query, cn);
            
                command.Parameters.AddWithValue("@descripcion", categoria.Descripcion);

                rowsAffected = command.ExecuteNonQuery();
                cn.Close();

            command.Dispose();

            return rowsAffected;
        }
        public int ActualizarCategoria(Categoria categoria)
        {
            int rowsAffected = 0;

            string query = "UPDATE categoria SET descripcion = @descripcion WHERE idcategoria = @id";

            cn.Open();
            SqlCommand command = new SqlCommand(query, cn);
            
                command.Parameters.AddWithValue("@descripcion", categoria.Descripcion);
                command.Parameters.AddWithValue("@id", categoria.IdCategoria);

                rowsAffected = command.ExecuteNonQuery();
                cn.Close();

            command.Dispose();
            return rowsAffected;
        }

        public int EliminarCategoria(int id)
        {
            int rowsAffected = 0;

            string query = "DELETE FROM categoria WHERE idcategoria = @id";

            cn.Open();
            SqlCommand command = new SqlCommand(query, cn);
            
                command.Parameters.AddWithValue("@id", id);

                rowsAffected = command.ExecuteNonQuery();
                cn.Close();
            command.Dispose();

            return rowsAffected;
        }
    }

}