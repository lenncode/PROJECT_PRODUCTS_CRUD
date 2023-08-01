
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Data;
using System.Configuration;

namespace CL3_POO_SOLORZANO_MELENDEZ_SAM.Models
{
    public class ProductoDAO
    {
        static string cadena = ConfigurationManager.ConnectionStrings["cn"].ConnectionString;
        private SqlConnection cn = new SqlConnection(cadena);

        public List<Producto> ObtenerTodosLosProductos()
        {
            List<Producto> listProductos = new List<Producto>();

            string query = "SELECT p.idproducto, p.nombre, p.precio, p.stock, c.descripcion AS categoria, e.descripcion AS estado " +
                           "FROM producto p " +
                           "INNER JOIN categoria c ON p.idcategoria = c.idcategoria " +
                           "INNER JOIN estado e ON p.idestado = e.idestado";

            cn.Open();
            SqlCommand command = new SqlCommand(query, cn);

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                Producto producto = new Producto
                {
                    IdProducto = reader.GetInt32(reader.GetOrdinal("idproducto")),
                    Nombre = reader.GetString(reader.GetOrdinal("nombre")),
                    Precio = reader.GetDecimal(reader.GetOrdinal("precio")),
                    Stock = reader.GetInt32(reader.GetOrdinal("stock")),
                    Categoria = new Categoria { Descripcion = reader.GetString(reader.GetOrdinal("categoria")) },
                    Estado = new Estado { Descripcion = reader.GetString(reader.GetOrdinal("estado")) }
                };

                listProductos.Add(producto);
            }

            reader.Close();
            command.Dispose();
            cn.Close();

            return listProductos;
        }

        public List<Producto> ObtenerProductosPorCategoria(string descripcionCategoria)
        {
            List<Producto> productos = new List<Producto>();

            string query = "SELECT p.idproducto, p.nombre, p.precio, p.stock, c.descripcion AS categoria, e.descripcion AS estado " +
                           "FROM producto p " +
                           "INNER JOIN categoria c ON p.idcategoria = c.idcategoria " +
                           "INNER JOIN estado e ON p.idestado = e.idestado " +
                           "WHERE c.descripcion LIKE '%' + @descripcionCategoria + '%'";

            cn.Open();
            SqlCommand command = new SqlCommand(query, cn);
            command.Parameters.AddWithValue("@descripcionCategoria", descripcionCategoria);
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                Producto producto = new Producto
                {
                    IdProducto = reader.GetInt32(0),
                    Nombre = reader.GetString(1),
                    Precio = reader.GetDecimal(2),
                    Stock = reader.GetInt32(3),
                    Categoria = new Categoria { Descripcion = reader.GetString(reader.GetOrdinal("categoria")) },
                    Estado = new Estado { Descripcion = reader.GetString(reader.GetOrdinal("estado")) }
                };

                productos.Add(producto);
            }

            reader.Close();
            command.Dispose();
            cn.Close();

            return productos;
        }

        public int InsertarProducto(Producto producto)
        {
            int rowsAffected = 0;

            string query = "INSERT INTO producto (nombre, precio, stock, idcategoria, idestado) " +
                           "VALUES (@nombre, @precio, @stock, @idcategoria, @idestado)";

            cn.Open();
            SqlCommand command = new SqlCommand(query, cn);
            command.Parameters.AddWithValue("@nombre", producto.Nombre);
            command.Parameters.AddWithValue("@precio", producto.Precio);
            command.Parameters.AddWithValue("@stock", producto.Stock);
            command.Parameters.AddWithValue("@idcategoria", producto.Categoria.IdCategoria);
            command.Parameters.AddWithValue("@idestado", producto.Estado.IdEstado);

            rowsAffected = command.ExecuteNonQuery();

            command.Dispose();
            cn.Close();

            return rowsAffected;
        }

        public int EliminarProducto(int idProducto)
        {
            int rowsAffected = 0;

            string query = "DELETE FROM producto WHERE idproducto = @idProducto";

            cn.Open();
            SqlCommand command = new SqlCommand(query, cn);
            command.Parameters.AddWithValue("@idProducto", idProducto);

            rowsAffected = command.ExecuteNonQuery();

            command.Dispose();
            cn.Close();

            return rowsAffected;
        }

        public int ActualizarProducto(Producto producto)
        {
            int rowsAffected = 0;

            string query = "UPDATE producto SET nombre = @nombre, precio = @precio, stock = @stock, " +
                           "idcategoria = @idcategoria, idestado = @idestado WHERE idproducto = @idProducto";

            cn.Open();
            SqlCommand command = new SqlCommand(query, cn);
            command.Parameters.AddWithValue("@nombre", producto.Nombre);
            command.Parameters.AddWithValue("@precio", producto.Precio);
            command.Parameters.AddWithValue("@stock", producto.Stock);
            command.Parameters.AddWithValue("@idcategoria", producto.Categoria.IdCategoria);
            command.Parameters.AddWithValue("@idestado", producto.Estado.IdEstado);
            command.Parameters.AddWithValue("@idProducto", producto.IdProducto);

            rowsAffected = command.ExecuteNonQuery();

            command.Dispose();
            cn.Close();

            return rowsAffected;
        }
    }

    }