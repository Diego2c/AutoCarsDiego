using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Proyecto.Models;

namespace Proyecto.Controllers
{
    public class LoginController : Controller
    {
        DB_AUTOCARS db = new DB_AUTOCARS();
        // GET: Login
        public ActionResult Index()
        {
            ViewBag.mensaje = "Bievenidos !";
            return View();
        }



        [HttpPost]
        public ActionResult Index(Usuario usuario)
        {
            var user = db.Usuario.FirstOrDefault(un => un.correo == usuario.correo && un.contraseña == usuario.contraseña);
            if (user != null)
            {
                Session["nombreUsuario"] = user.nombre;
                Session["idUsuario"] = user.IdUsuario;
                Session["idRol"] = user.idRol;
                return VerificarSecion();
            }
            else
            {
                ModelState.AddModelError("", "Verifique sus credenciales ");
            }
            return View();
        }

        public ActionResult VerificarSecion()
        {
            if (Session["idUsuario"] != null)
            {
                if (Convert.ToInt32(Session["idRol"]) == 1)
                {
                    return RedirectToAction("../Home/Index");
                }
                if (Convert.ToInt32(Session["idRol"]) == 2)
                {
                    return RedirectToAction("../Home/Inicio");
                }
                else
                {
                    return RedirectToAction("../Home/inicio");
                }

            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        public ActionResult logunt()
        {
            Session.Clear();
            return RedirectToAction("../Login/Index");
        }



    }

}