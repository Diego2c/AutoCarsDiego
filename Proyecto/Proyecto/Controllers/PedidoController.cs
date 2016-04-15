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
    public class PedidoController : Controller
    {
        DB_AUTOCARS db = new DB_AUTOCARS();
        // GET: Pedido
        public ActionResult Index()
        {
            int id = Convert.ToInt32(Session["idUsuario"]);

            var carro = db.compra.Include(c => c.usuario);
            var carroVendodos = from u in carro
                                where u.idUsuario == id  && u.carro.idEstado == 3
                                select u;

            return View(carroVendodos.ToList());
            
        }

      

    }
}