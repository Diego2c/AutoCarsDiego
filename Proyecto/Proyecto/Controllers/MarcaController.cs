using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Proyecto.Models;

namespace Proyecto.Controllers
{
    public class MarcaController : Controller
    {
        private DB_AUTOCARS db = new DB_AUTOCARS();

        // GET: Marca
        public ActionResult Index(string sortOrder,string currentFilter, string searchString)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            var Usuario = from s in db.marca
                          select s;

            if (searchString != null)
            {
                sortOrder = "hola";
            }
            else
            {
                searchString = currentFilter;
            }


            ViewBag.CurrentFilter = searchString;



            switch (sortOrder)
            {
                case "name_desc":
                    Usuario = Usuario.OrderByDescending(s => s.nombreMarca);
                    break;
                case "hola":
                    Usuario = Usuario.Where(s => s.nombreMarca.Contains(searchString));
                    break;
                default:  // Name ascending 
                    Usuario = from s in db.marca
                              select s;

                    break;
            }


            return View(Usuario.ToList());
        }
       
      
        // GET: Marca/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Marca marca = db.marca.Find(id);
            if (marca == null)
            {
                return HttpNotFound();
            }
            return View(marca);
        }

        // GET: Marca/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Marca/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idMarca,nombreMarca")] Marca marca, HttpPostedFileBase iMarca)
        {
            if (ModelState.IsValid)
            {
                if (iMarca != null && iMarca.ContentLength > 0)
                {
                    var imagen = new ImagenMarca
                    {
                        nombre = System.IO.Path.GetFileName(iMarca.FileName),
                        tip = FileType.Imagen,
                        ContentType = iMarca.ContentType
                    };
                    using (var reader = new System.IO.BinaryReader(iMarca.InputStream))
                    {
                        imagen.contenido = reader.ReadBytes(iMarca.ContentLength);
                    };
                    marca.ImgenMarca = new List<ImagenMarca> { imagen };
                }
                db.marca.Add(marca);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(marca);
        }

        // GET: Marca/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Marca marca = db.marca.Find(id);
            if (marca == null)
            {
                return HttpNotFound();
            }
            return View(marca);
        }

        // POST: Marca/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int? id, HttpPostedFileBase iMarca)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var marca = db.marca.Find(id);
            if (TryUpdateModel(marca, "", new string[] { "idMarca,nombreMarca" }))
            {
                try
                {
                    if (iMarca != null && iMarca.ContentLength > 0)
                    {
                        if (marca.ImgenMarca.Any(f => f.tip == FileType.Imagen))
                        {
                            db.imagenMarca.Remove(marca.ImgenMarca.First(f => f.tip == FileType.Imagen));
                        }
                        var imagen = new ImagenMarca
                        {
                            nombre = System.IO.Path.GetFileName(iMarca.FileName),
                            tip = FileType.Imagen,
                            ContentType = iMarca.ContentType
                        };
                        using (var reader = new System.IO.BinaryReader(iMarca.InputStream))
                        {
                            imagen.contenido = reader.ReadBytes(iMarca.ContentLength);
                        }
                        marca.ImgenMarca = new List<ImagenMarca> { imagen };
                    }
                    db.Entry(marca).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                catch (RetryLimitExceededException)
                {
                    ModelState.AddModelError("", "No se logro guardar los cambios. Intente de nuevo y si el problema persiste, acuda al administrador del sisteam");
                }
            }
            return View(marca);
        }

        // GET: Marca/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Marca marca = db.marca.Find(id);
            if (marca == null)
            {
                return HttpNotFound();
            }
            return View(marca);
        }

        // POST: Marca/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Marca marca = db.marca.Find(id);
            db.marca.Remove(marca);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
