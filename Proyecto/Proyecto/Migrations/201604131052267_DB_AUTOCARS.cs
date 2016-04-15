namespace Proyecto.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DB_AUTOCARS : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AmigoDetalles",
                c => new
                    {
                        idAmigoDetalle = c.Int(nullable: false, identity: true),
                        idDetalleAmigo = c.Int(nullable: false),
                        idUsaurio = c.Int(nullable: false),
                        detalleAmigo_idDetalleAgmigo = c.Int(),
                        usuario_IdUsuario = c.Int(),
                    })
                .PrimaryKey(t => t.idAmigoDetalle)
                .ForeignKey("dbo.DetalleAmigoes", t => t.detalleAmigo_idDetalleAgmigo)
                .ForeignKey("dbo.Usuarios", t => t.usuario_IdUsuario)
                .Index(t => t.detalleAmigo_idDetalleAgmigo)
                .Index(t => t.usuario_IdUsuario);
            
            CreateTable(
                "dbo.DetalleAmigoes",
                c => new
                    {
                        idDetalleAgmigo = c.Int(nullable: false, identity: true),
                        idUsuario = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.idDetalleAgmigo)
                .ForeignKey("dbo.Usuarios", t => t.idUsuario, cascadeDelete: true)
                .Index(t => t.idUsuario);
            
            CreateTable(
                "dbo.Usuarios",
                c => new
                    {
                        IdUsuario = c.Int(nullable: false, identity: true),
                        nombre = c.String(nullable: false),
                        carne = c.Int(nullable: false),
                        correo = c.String(nullable: false),
                        contraseña = c.String(nullable: false),
                        confirmarContraseña = c.String(nullable: false),
                        idRol = c.Int(nullable: false),
                        PerfilUsuario_idPerfilUsuario = c.Int(),
                    })
                .PrimaryKey(t => t.IdUsuario)
                .ForeignKey("dbo.Rols", t => t.idRol, cascadeDelete: true)
                .ForeignKey("dbo.PerfilUsuarios", t => t.PerfilUsuario_idPerfilUsuario)
                .Index(t => t.idRol)
                .Index(t => t.PerfilUsuario_idPerfilUsuario);
            
            CreateTable(
                "dbo.ImagenUsuarios",
                c => new
                    {
                        idImagenUsuario = c.Int(nullable: false, identity: true),
                        nombre = c.String(),
                        ContentType = c.String(),
                        tip = c.Int(nullable: false),
                        contenido = c.Binary(),
                        idUsuario = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.idImagenUsuario)
                .ForeignKey("dbo.Usuarios", t => t.idUsuario, cascadeDelete: true)
                .Index(t => t.idUsuario);
            
            CreateTable(
                "dbo.Rols",
                c => new
                    {
                        idRol = c.Int(nullable: false, identity: true),
                        nombre = c.String(),
                        descripcion = c.String(),
                    })
                .PrimaryKey(t => t.idRol);
            
            CreateTable(
                "dbo.Carroes",
                c => new
                    {
                        idCarro = c.Int(nullable: false, identity: true),
                        idMarca = c.Int(nullable: false),
                        idEstado = c.Int(nullable: false),
                        modelo = c.String(nullable: false, maxLength: 100),
                        precio = c.Decimal(nullable: false, precision: 18, scale: 2),
                        descripcion = c.String(),
                        DetalleCarro_idDetalle = c.Int(),
                    })
                .PrimaryKey(t => t.idCarro)
                .ForeignKey("dbo.Estadoes", t => t.idEstado, cascadeDelete: true)
                .ForeignKey("dbo.Marcas", t => t.idMarca, cascadeDelete: true)
                .ForeignKey("dbo.DetalleCarroes", t => t.DetalleCarro_idDetalle)
                .Index(t => t.idMarca)
                .Index(t => t.idEstado)
                .Index(t => t.DetalleCarro_idDetalle);
            
            CreateTable(
                "dbo.Estadoes",
                c => new
                    {
                        idEstado = c.Int(nullable: false, identity: true),
                        nombre = c.String(nullable: false),
                        descripcion = c.String(),
                    })
                .PrimaryKey(t => t.idEstado);
            
            CreateTable(
                "dbo.ImagenCarroes",
                c => new
                    {
                        idImagenCarro = c.Int(nullable: false, identity: true),
                        nombre = c.String(),
                        ContentType = c.String(),
                        tip = c.Int(nullable: false),
                        contenido = c.Binary(),
                        idCarro = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.idImagenCarro)
                .ForeignKey("dbo.Carroes", t => t.idCarro, cascadeDelete: true)
                .Index(t => t.idCarro);
            
            CreateTable(
                "dbo.Marcas",
                c => new
                    {
                        idMarca = c.Int(nullable: false, identity: true),
                        nombreMarca = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.idMarca);
            
            CreateTable(
                "dbo.ImagenMarcas",
                c => new
                    {
                        idImagenMarca = c.Int(nullable: false, identity: true),
                        nombre = c.String(),
                        ContentType = c.String(),
                        tip = c.Int(nullable: false),
                        contenido = c.Binary(),
                        idMarca = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.idImagenMarca)
                .ForeignKey("dbo.Marcas", t => t.idMarca, cascadeDelete: true)
                .Index(t => t.idMarca);
            
            CreateTable(
                "dbo.Compras",
                c => new
                    {
                        idCompra = c.Int(nullable: false, identity: true),
                        fecha = c.DateTime(nullable: false),
                        idUsuario = c.Int(nullable: false),
                        idCarro = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.idCompra)
                .ForeignKey("dbo.Carroes", t => t.idCarro, cascadeDelete: true)
                .ForeignKey("dbo.Usuarios", t => t.idUsuario, cascadeDelete: true)
                .Index(t => t.idUsuario)
                .Index(t => t.idCarro);
            
            CreateTable(
                "dbo.DetalleCarroes",
                c => new
                    {
                        idDetalle = c.Int(nullable: false, identity: true),
                        puertas = c.Int(nullable: false),
                        año = c.DateTime(nullable: false),
                        combustible = c.String(),
                        color = c.String(),
                        idCarro = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.idDetalle);
            
            CreateTable(
                "dbo.PerfilUsuarios",
                c => new
                    {
                        idPerfilUsuario = c.Int(nullable: false, identity: true),
                        idUsuario = c.Int(nullable: false),
                        direccion = c.String(),
                        telefono = c.Int(nullable: false),
                        fechaNacicmiento = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.idPerfilUsuario);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Usuarios", "PerfilUsuario_idPerfilUsuario", "dbo.PerfilUsuarios");
            DropForeignKey("dbo.Carroes", "DetalleCarro_idDetalle", "dbo.DetalleCarroes");
            DropForeignKey("dbo.Compras", "idUsuario", "dbo.Usuarios");
            DropForeignKey("dbo.Compras", "idCarro", "dbo.Carroes");
            DropForeignKey("dbo.Carroes", "idMarca", "dbo.Marcas");
            DropForeignKey("dbo.ImagenMarcas", "idMarca", "dbo.Marcas");
            DropForeignKey("dbo.ImagenCarroes", "idCarro", "dbo.Carroes");
            DropForeignKey("dbo.Carroes", "idEstado", "dbo.Estadoes");
            DropForeignKey("dbo.AmigoDetalles", "usuario_IdUsuario", "dbo.Usuarios");
            DropForeignKey("dbo.AmigoDetalles", "detalleAmigo_idDetalleAgmigo", "dbo.DetalleAmigoes");
            DropForeignKey("dbo.DetalleAmigoes", "idUsuario", "dbo.Usuarios");
            DropForeignKey("dbo.Usuarios", "idRol", "dbo.Rols");
            DropForeignKey("dbo.ImagenUsuarios", "idUsuario", "dbo.Usuarios");
            DropIndex("dbo.Compras", new[] { "idCarro" });
            DropIndex("dbo.Compras", new[] { "idUsuario" });
            DropIndex("dbo.ImagenMarcas", new[] { "idMarca" });
            DropIndex("dbo.ImagenCarroes", new[] { "idCarro" });
            DropIndex("dbo.Carroes", new[] { "DetalleCarro_idDetalle" });
            DropIndex("dbo.Carroes", new[] { "idEstado" });
            DropIndex("dbo.Carroes", new[] { "idMarca" });
            DropIndex("dbo.ImagenUsuarios", new[] { "idUsuario" });
            DropIndex("dbo.Usuarios", new[] { "PerfilUsuario_idPerfilUsuario" });
            DropIndex("dbo.Usuarios", new[] { "idRol" });
            DropIndex("dbo.DetalleAmigoes", new[] { "idUsuario" });
            DropIndex("dbo.AmigoDetalles", new[] { "usuario_IdUsuario" });
            DropIndex("dbo.AmigoDetalles", new[] { "detalleAmigo_idDetalleAgmigo" });
            DropTable("dbo.PerfilUsuarios");
            DropTable("dbo.DetalleCarroes");
            DropTable("dbo.Compras");
            DropTable("dbo.ImagenMarcas");
            DropTable("dbo.Marcas");
            DropTable("dbo.ImagenCarroes");
            DropTable("dbo.Estadoes");
            DropTable("dbo.Carroes");
            DropTable("dbo.Rols");
            DropTable("dbo.ImagenUsuarios");
            DropTable("dbo.Usuarios");
            DropTable("dbo.DetalleAmigoes");
            DropTable("dbo.AmigoDetalles");
        }
    }
}
