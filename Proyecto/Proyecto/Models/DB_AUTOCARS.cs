using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Proyecto.Models
{
    public class DB_AUTOCARS : DbContext
    {
        public DB_AUTOCARS() : base("name=DB_AutoCars1") { }

        public virtual DbSet<Marca> marca { get; set; }
        public virtual DbSet<Carro> carro { get; set; }
        public virtual DbSet<DetalleCarro> detalleCarro { get; set; }
        public virtual DbSet<Compra> compra { get; set; }     
    
        public virtual DbSet<Usuario> Usuario { get; set; }
        public virtual DbSet<Rol> rol { get; set; }
        public virtual DbSet<PerfilUsuario> perfilUsuario { get; set; }
        public virtual DbSet<DetalleAmigo> detalleAmigo { get; set; }
        public virtual DbSet<AmigoDetalle> amigoDetalle { get; set; }
        public virtual DbSet<ImagenCarro> imagenCarro { get; set; }
        public virtual DbSet<ImagenUsuario> imangenUsuario { get; set; }
        public virtual DbSet<ImagenMarca> imagenMarca { get; set; }

        public System.Data.Entity.DbSet<Proyecto.Models.Estado> Estadoes { get; set; }

    }
}