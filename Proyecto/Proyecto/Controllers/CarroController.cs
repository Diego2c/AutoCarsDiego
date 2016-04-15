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
    public class CarroController : Controller
    {
        private DB_AUTOCARS db = new DB_AUTOCARS();

        // GET: Carro
        public ActionResult Index()
        {

            var carro = db.carro.Include(c => c.marca);
            var carroVendodos = from u in carro
                                where u.idEstado == 1
                                select u;

            return View(carroVendodos.ToList());
        }

        
        public ActionResult Vendidos()
        {

            var carro = db.carro.Include(c => c.marca);
            var carroVendodos = from u in carro
                                where u.idEstado == 2
                                select u;

            return View(carroVendodos.ToList());
        }

        public ActionResult Apartados()
        {

            var carro = db.carro.Include(c => c.marca);
            var carroVendodos = from u in carro
                                where u.idEstado == 3
                                select u;

            return View(carroVendodos.ToList());
        }


        // GET: Carro/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Carro carro = db.carro.Find(id);
            if (carro == null)
            {
                return HttpNotFound();
            }
            return View(carro);
        }

        // GET: Carro/Create
        public ActionResult Create()
        {
            ViewBag.idEstado = new SelectList(db.Estadoes, "idEstado", "nombre");
            ViewBag.idMarca = new SelectList(db.marca, "idMarca", "nombreMarca");
            return View();
        }

        // POST: Carro/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idCarro,idMarca,idEstado,modelo,precio,descripcion")] Carro carro, HttpPostedFileBase iCarro)
        {
            if (ModelState.IsValid)
            {
                if (iCarro != null && iCarro.ContentLength > 0)
                {
                    var imagen = new ImagenCarro
                    {
                        nombre = System.IO.Path.GetFileName(iCarro.FileName),
                        tip = FileType.Imagen,
                        ContentType = iCarro.ContentType
                    };
                    using (var reader = new System.IO.BinaryReader(iCarro.InputStream))
                    {
                        imagen.contenido = reader.ReadBytes(iCarro.ContentLength);
                    };
                    carro.imgenCarrro = new List<ImagenCarro> { imagen };
                }
                db.carro.Add(carro);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idEstado = new SelectList(db.Estadoes, "idEstado", "nombre", carro.idEstado);
            ViewBag.idMarca = new SelectList(db.marca, "idMarca", "nombreMarca", carro.idMarca);
            return View(carro);
        }

        // GET: Carro/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Carro carro = db.carro.Find(id);
            if (carro == null)
            {
                return HttpNotFound();
            }
            ViewBag.idEstado = new SelectList(db.Estadoes, "idEstado", "nombre", carro.idEstado);
            ViewBag.idMarca = new SelectList(db.marca, "idMarca", "nombreMarca", carro.idMarca);
            return View(carro);
        }


        // POST: Carro/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int? id, HttpPostedFileBase iCarro)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var carro = db.carro.Find(id);
            if (TryUpdateModel(carro, "", new string[] { "idCarro,idMarca,modelo,precio,descripcion,estado" }))
            {
                try
                {
                    if (iCarro != null && iCarro.ContentLength > 0)
                    {
                        if (carro.imgenCarrro.Any(f => f.tip == FileType.Imagen))
                        {
                            db.imagenCarro.Remove(carro.imgenCarrro.First(f => f.tip == FileType.Imagen));
                        }
                        var imagen = new ImagenCarro
                        {
                            nombre = System.IO.Path.GetFileName(iCarro.FileName),
                            tip = FileType.Imagen,
                            ContentType = iCarro.ContentType
                        };
                        using (var reader = new System.IO.BinaryReader(iCarro.InputStream))
                        {
                            imagen.contenido = reader.ReadBytes(iCarro.ContentLength);
                        }
                        carro.imgenCarrro = new List<ImagenCarro> { imagen };
                    }
                    db.Entry(carro).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                catch (RetryLimitExceededException)
                {
                    ModelState.AddModelError("", "No se logro guardar los cambios. Intente de nuevo y si el problema persiste, acuda al administrador del sisteam");
                }
            }
            ViewBag.idEstado = new SelectList(db.Estadoes, "idEstado", "nombre", carro.idEstado);
            ViewBag.idMarca = new SelectList(db.marca, "idMarca", "nombreMarca", carro.idMarca);
            return View(carro);
        }

        // GET: Carro/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Carro carro = db.carro.Find(id);
            if (carro == null)
            {
                return HttpNotFound();
            }
            return View(carro);
        }

        // POST: Carro/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Carro carro = db.carro.Find(id);
            db.carro.Remove(carro);
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
