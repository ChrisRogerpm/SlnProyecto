using SlnEccommerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace SlnEccommerce.Controllers
{
    public class AutenticacionController : Controller
    {
        // GET: Autenticacion
        Usuario usuarionegocio = new Usuario();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult UsuarioAutenticarJson(Usuario obj)
        {
            var respuesta = false;
            string mensaje;
            try
            {
                Usuario objUsuario = usuarionegocio.UsuarioDetalle(obj);

                if (objUsuario.idUsuario > 0)
                {
                    respuesta = true;
                    Session["idUsuario"] = objUsuario.idUsuario;
                    Session["email"] = objUsuario.email;
                    mensaje = "Bienvenido al sistema";
                }
                else
                {
                    mensaje = "Las credenciales ingresadas son erroneas, intente nuevamente";
                }
                
            }catch(Exception ex)
            {
                mensaje = ex.Message;
            }
            return Json(new { respuesta = respuesta,mensaje = mensaje });
        }
    }
}