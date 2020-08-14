using SlnEccommerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SlnEccommerce.Controllers
{
    public class CategoriaController : Controller
    {
        // GET: Categoria
        Categoria objCategoria = new Categoria();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CategoriaRegistrar()
        {
            return View();
        }

        public ActionResult CategoriaEditar(int idCategoria)
        {
            ViewBag.categoria = objCategoria.CategoriaDetalle(idCategoria);
            return View();
        }
        public ActionResult CategoriaListarJson()
        {
            string mensaje = "";
            var data = new List<Categoria>();
            try
            {
                data = objCategoria.CategoriaListar();
            }
            catch (Exception ex)
            {
                mensaje = ex.Message;
            }
            var result = new { data = data, mensaje = mensaje };
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult CategoriaRegistrarJson(Categoria obj)
        {
            bool respuesta = false;
            string mensaje = "";
            try
            {
                objCategoria.CategoriaRegistrar(obj);
                respuesta = true;
                mensaje = "Se ha registrado exitosamente";
            }catch(Exception ex)
            {
                mensaje = ex.Message;
            }
            return Json(new { respuesta = respuesta, mensaje = mensaje });
        }
        [HttpPost]
        public ActionResult CategoriaEditarJson(Categoria obj)
        {
            bool respuesta = false;
            string mensaje = "";
            try
            {
                objCategoria.CategoriaEditar(obj);
                respuesta = true;
                mensaje = "Se ha editado exitosamente";
            }
            catch (Exception ex)
            {
                mensaje = ex.Message;
            }
            return Json(new { respuesta = respuesta, mensaje = mensaje });
        }
    }
}