using Aplicación_SD_Web_Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Aplicación_SD_Web_Server.Controllers
{
    public class CategoriaController : Controller
    {
        private WebService1 _webService;

        public CategoriaController()
        {
            _webService = new WebService1();
        }

        public ActionResult Index()
        {
            var categoriasDataSet = _webService.GetCategorias();
            var categorias = new List<Categoria>();

            foreach (System.Data.DataRow row in categoriasDataSet.Tables[0].Rows)
            {
                categorias.Add(new Categoria
                {
                    IdCategoria = (int)row["IdCategoria"],
                    Nombre = row["Nombre"].ToString(),
                    FechaCreacion = (DateTime)row["FechaCreacion"]
                });
            }

            return View(categorias);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Categoria categoria)
        {
            categoria.FechaCreacion = DateTime.Now;
            _webService.CreateCategoria(categoria.Nombre, categoria.FechaCreacion);
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            var categoriasDataSet = _webService.GetCategorias();
            var row = categoriasDataSet.Tables[0].Select($"IdCategoria = {id}").FirstOrDefault();

            if (row != null)
            {
                var categoria = new Categoria
                {
                    IdCategoria = (int)row["IdCategoria"],
                    Nombre = row["Nombre"].ToString(),
                    FechaCreacion = (DateTime)row["FechaCreacion"]
                };

                return View(categoria);
            }

            return HttpNotFound();
        }

        [HttpPost]
        public ActionResult Edit(Categoria categoria)
        {
            _webService.UpdateCategoria(categoria.IdCategoria, categoria.Nombre);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            _webService.DeleteCategoria(id);
            return RedirectToAction("Index");
        }
    }

}