using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Proyecto.Models;
using System.Data.Entity.Infrastructure;

namespace Proyecto.Controllers
{
    public class Usuario1Controller : Controller
    {
        DB_AUTOCARS db = new DB_AUTOCARS();
        // GET: Usuario1

     
        // GET: Usuarios/Edit/5
        public ActionResult Edit()
        {
            int id = Convert.ToInt32(Session["idUsuario"]);
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Usuario usuario = db.Usuario.Find(id);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            ViewBag.idRol = new SelectList(db.rol, "idRol", "nombre", usuario.idRol);
            return View(usuario);
        }

        // POST: Usuarios/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public ActionResult Edit( HttpPostedFileBase iUsuario)
        {
             int id = Convert.ToInt32(Session["idUsuario"]);
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var usuario = db.Usuario.Find(id);
            if (TryUpdateModel(usuario, "", new string[] { "idMarca,nombreMarca" }))
            {
                try
                {
                    if (iUsuario != null && iUsuario.ContentLength > 0)
                    {
                        if (usuario.ImagenUsuario.Any(f => f.tip == FileType.Imagen))
                        {
                            db.imangenUsuario.Remove(usuario.ImagenUsuario.First(f => f.tip == FileType.Imagen));
                        }
                        var imagen = new ImagenUsuario
                        {
                            nombre = System.IO.Path.GetFileName(iUsuario.FileName),
                            tip = FileType.Imagen,
                            ContentType = iUsuario.ContentType
                        };
                        using (var reader = new System.IO.BinaryReader(iUsuario.InputStream))
                        {
                            imagen.contenido = reader.ReadBytes(iUsuario.ContentLength);
                        }
                        usuario.ImagenUsuario = new List<ImagenUsuario> { imagen };
                    }
                    db.Entry(usuario).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("../Home/Inicio");
                }
                catch (RetryLimitExceededException)
                {
                    ModelState.AddModelError("", "No se logro guardar los cambios. Intente de nuevo y si el problema persiste, acuda al administrador del sisteam");
                }
            }
            return View(usuario);
        }

    }
}