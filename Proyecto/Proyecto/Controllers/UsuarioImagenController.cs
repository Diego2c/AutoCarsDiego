using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Proyecto.Models;

namespace Proyecto.Controllers
{
    public class UsuarioImagenController : Controller
    {
        DB_AUTOCARS db = new DB_AUTOCARS();
        // GET: ImagenCarro
        public ActionResult Index()
        {
            int id = Convert.ToInt32(Session["idUsuario"]); 
            var imagen = db.imangenUsuario.Find(id);
            return File(imagen.contenido, imagen.ContentType);
        }
    }
}