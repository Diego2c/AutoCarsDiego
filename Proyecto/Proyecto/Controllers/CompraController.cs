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
    public class CompraController : Controller
    {
        DB_AUTOCARS db = new DB_AUTOCARS();
        // GET: Compra
        public ActionResult Index()
        {
            int id = Convert.ToInt32(Session["idUsuario"]);

            var carro = db.compra.Include(c => c.usuario);
            var carroVendodos = from u in carro
                                where u.idUsuario == id
                                select u;

            return View(carroVendodos.ToList());
        }


         public ActionResult IndexUsuario(string sortOrder,string currentFilter, string searchString)
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
       

        public ActionResult IndexAutos(int? id)
        {
            var carro = db.carro.Include(c => c.marca);
            var carroVendodos = from u in carro
                                where u.idMarca == id && u.idEstado == 1 
                                select u;

            return View(carroVendodos.ToList());
        }

        // GET: Carro/Details/5
        public ActionResult Details(int? idCa)
        {
            if (idCa == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Carro carro = db.carro.Find(idCa);
            if (carro == null)
            {
                return HttpNotFound();
            }
            return View(carro);
        }

        public ActionResult Create(int idCa)
        {
          
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Compra conpra, int idCa)
        {

            if (ModelState.IsValid)
            {
                int id = Convert.ToInt32(Session["idUsuario"]);
                conpra.idUsuario = id;
                conpra.idCarro = idCa;
                Edit(idCa);
                db.compra.Add(conpra);
                db.SaveChanges();
                return RedirectToAction("../Home/Inicio");
            }
            return View();
        }

        // GET: Carroes111/Edit/5
     

        // POST: Carroes111/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.

        public ActionResult Edit(int idCa)
        {
            Carro carro = db.carro.Find(idCa);
            if (ModelState.IsValid)
            {
                carro.idEstado = 2;
                db.Entry(carro).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("../Home/Inicio");
            }
            return View(carro);
        }


    }
}