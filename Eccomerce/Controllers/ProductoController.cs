using Eccomerce.MiServicio;
using Eccomerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Eccomerce.Controllers
{
    public class ProductoController : Controller
    {
        // GET: Producto
        public ActionResult Index()
        {
            using (Service1Client client = new Service1Client())
            {
                var productosDataSet = client.GetProductos();
                var productos = productosDataSet.ToProductoList();
                return View(productos);
            }
        }


        // GET: Producto/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Producto/Create
        [HttpPost]
        public ActionResult Create(Producto producto)
        {
            try
            {
                using (Service1Client client = new Service1Client())
                {
                    client.AddProducto(producto.Nombre, producto.Descripcion, producto.IdCategoria, producto.Precio, producto.PrecioOferta, producto.Cantidad, "no hay imagen");
                    ViewBag.Message = "Producto creado con éxito";
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Producto/Edit/5
        public ActionResult Edit(int id)
        {
            using (Service1Client client = new Service1Client())
            {
                var productosDataSet = client.GetProductos();
                var productos = productosDataSet.ToProductoList();
                var producto = productos.Find(p => p.IdProducto == id);
                return View(producto);
            }
        }

        // POST: Producto/Edit/5
        [HttpPost]
        public ActionResult Edit(Producto producto)
        {
            try
            {
                using (Service1Client client = new Service1Client())
                {
                    client.UpdateProducto(producto.IdProducto, producto.Nombre, producto.Descripcion, producto.IdCategoria, producto.Precio, producto.PrecioOferta, producto.Cantidad, producto.Imagen);
                    ViewBag.Message = "Producto actualizado con éxito";
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Producto/Delete/5
        public ActionResult Delete(int id)
        {
            using (Service1Client client = new Service1Client())
            {
                var productosDataSet = client.GetProductos();
                var productos = productosDataSet.ToProductoList();
                var producto = productos.Find(p => p.IdProducto == id);
                return View(producto);
            }
        }

        // POST: Producto/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                using (Service1Client client = new Service1Client())
                {
                    client.DeleteProducto(id);
                    ViewBag.Message = "Producto eliminado con éxito";
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}