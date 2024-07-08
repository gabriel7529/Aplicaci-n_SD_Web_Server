using Eccomerce.MiServicio;
using Eccomerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Eccomerce.Controllers
{
    public class CategoriaController : Controller
    {
        private List<Categoria> categorias;
        public ActionResult Index()
        {
            using (Service1Client client = new Service1Client())
            {
                var categoriasDataSet = client.GetCategorias();
                categorias = categoriasDataSet.ToCategoriaList();
                return View(categorias);
            }
        }

        // GET: Categoria/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Categoria/Create
        [HttpPost]
        public ActionResult Create(Categoria categoria)
        {
            try
            {
                using (Service1Client client = new Service1Client())
                {
                    client.CreateCategoria(categoria.Nombre, DateTime.Now);
                    ViewBag.Message = "Categoría creada con éxito";
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Categoria/Edit/5
        public ActionResult Edit(int id)
        {
            using (Service1Client client = new Service1Client())
            {
                var categoriasDataSet = client.GetCategorias();
                var categorias = categoriasDataSet.ToCategoriaList();
                var categoria = categorias.Find(c => c.IdCategoria == id);
                return View(categoria);
            }
        }

        // POST: Categoria/Edit/5
        [HttpPost]
        public ActionResult Edit(Categoria categoria)
        {
            try
            {
                using (Service1Client client = new Service1Client())
                {
                    client.UpdateCategoria(categoria.IdCategoria, categoria.Nombre);
                    ViewBag.Message = "Categoría actualizada con éxito";
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Categoria/Delete/5
        public ActionResult Delete(int id)
        {
            using (Service1Client client = new Service1Client())
            {
                var categoriasDataSet = client.GetCategorias();
                var categorias = categoriasDataSet.ToCategoriaList();
                var categoria = categorias.Find(c => c.IdCategoria == id);
                return View(categoria);
            }
        }

        // POST: Categoria/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                using (Service1Client client = new Service1Client())
                {
                    client.DeleteCategoria(id);
                    ViewBag.Message = "Categoría eliminada con éxito";
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