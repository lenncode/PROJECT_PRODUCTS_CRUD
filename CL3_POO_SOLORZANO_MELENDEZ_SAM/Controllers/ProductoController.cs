using CL3_POO_SOLORZANO_MELENDEZ_SAM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CL3_POO_SOLORZANO_MELENDEZ_SAM.Controllers
{
    public class ProductoController : Controller
    {
        // GET: Producto
        public ActionResult listadoProducto()
        {
            IEnumerable<Producto> lista = new List<Producto>();

            ProductoDAO dao = new ProductoDAO();
            lista = dao.ObtenerTodosLosProductos();
            return View(lista);


        }

        public ActionResult consultaProducto(string descripcionCategoria)
        {
            IEnumerable<Producto> lista = new List<Producto>();

            ProductoDAO dao = new ProductoDAO();
            lista = dao.ObtenerProductosPorCategoria(descripcionCategoria +"%");
            return View(lista);
        }
        public ActionResult Create(Producto producto)
        {
            if (ModelState.IsValid)
            {
                ProductoDAO dao = new ProductoDAO();
                int rowsAffected = dao.InsertarProducto(producto);

                if (rowsAffected > 0)
                {
                    // Inserción exitosa, redirigir a la página de listado de productos
                    return RedirectToAction("listadoProducto");
                }
                else
                {
                    // Ocurrió un error durante la inserción
                    ModelState.AddModelError("", "Error al insertar el producto");
                }
            }

            CategoriaDAO daoCA = new CategoriaDAO();
            EstadoDAO daoEst = new EstadoDAO();
            List<Categoria> categorias = daoCA.ObtenerCategorias();
            List<Estado> estados = daoEst.ObtenerEstados();

            ViewBag.Categorias = new SelectList(categorias, "IdCategoria", "Descripcion");
            ViewBag.Estados = new SelectList(estados, "IdEstado", "Descripcion");

            return View(producto);
        }
        [HttpPost]
        public ActionResult Update(int id, Producto producto)
        {
            if (ModelState.IsValid)
            {
                ProductoDAO dao = new ProductoDAO();
                int rowsAffected = dao.ActualizarProducto(producto);

                if (rowsAffected > 0)
                {
                    // Actualización exitosa, redirigir a la página de listado de productos
                    return RedirectToAction("listadoProducto");
                }
                else
                {
                    // Ocurrió un error durante la actualización
                    ModelState.AddModelError("", "Error al actualizar el producto");
                }
            }

            CategoriaDAO daoCA = new CategoriaDAO();
            EstadoDAO daoEst = new EstadoDAO();
            List<Categoria> categorias = daoCA.ObtenerCategorias();
            List<Estado> estados = daoEst.ObtenerEstados();

            ViewBag.Categorias = categorias;
            ViewBag.Estados = estados;

            return View(producto);
        }
    }

}