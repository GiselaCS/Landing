using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using landing.Models;
namespace landing.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Details()
        {
            MantenimientoContacto ma = new MantenimientoContacto();
            return View(ma.RecuperarTodos());

        }
        
       

        // POST: Index/Create
        [HttpPost]
        public ActionResult Index(FormCollection collection)
        {
            MantenimientoContacto ma = new MantenimientoContacto();
            Contacto usu = new Contacto
            {
                Nombre = collection["nombre"],
                Apellido = collection["apellido"],
                Correo = collection["correo"],
                Comentario = collection["comentario"]
            };
            ma.Alta(usu);
            return RedirectToAction("Confirmacion");
        }
        
        public ActionResult Confirmacion()
        {
            return View("Confirmacion");
        }
    }
}