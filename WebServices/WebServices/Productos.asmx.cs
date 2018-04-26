using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using DBProductos;
using DBProductos.DTO;

namespace WebServices
{
    /// <summary>
    /// Descripción breve de Productos
    /// </summary>
    [WebService(Namespace = "http://alecxander.somee.com/Productos")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class Productos : System.Web.Services.WebService
    {

        [WebMethod(Description = "Obtiene los productos de la base de datos")]
        public List<ProductoDTO> ObtenerProductos()
        {
            using (LoginWebServiceProductosEntities db = new LoginWebServiceProductosEntities())
            {
                List<ProductoDTO> productos = db.Productoes.Select(p => new ProductoDTO
                {
                    Nombre = p.Nombre,
                    Precio = p.Precio,
                    Id = p.ProductoID
                }).ToList();
                return productos;

                //List<Producto> productos = db.Productoes.Select(p => new Producto{
                //    ProductoID = p.ProductoID,
                //    Color = p.Color,
                //    FechaCreacion = p.FechaCreacion,
                //    Nombre = p.Nombre,
                //    Precio = p.Precio,
                //    ProductoCategoriaID = p.ProductoCategoriaID
                //}).ToList();
                //return productos;
            }
        }

        [WebMethod(Description = "Obtiene un producto de la base de datos por Id" +
            "<br/>idProducto:Int")]
        public ProductoDTO ObtenerProducto(int idProducto)
        {
            using (LoginWebServiceProductosEntities db = new LoginWebServiceProductosEntities())
            {
                ProductoDTO productoDTO = db.Productoes
                    .Where(p => p.ProductoID == idProducto)
                    .Select(p => new ProductoDTO
                    {
                        Id = p.ProductoID,
                        Nombre = p.Nombre,
                        Precio = p.Precio,
                    }).FirstOrDefault();
                return productoDTO;

                //LoginWebServiceProductosEntities db = new LoginWebServiceProductosEntities();

                //Producto producto = db.Productoes.Include()
                //    .Where(p => p.ProductoID == idProducto)
                //    .Select(p => p).FirstOrDefault();

                //return producto;
            }
        }

        [WebMethod(Description = "Obtiene los detalles del producto" +
            "<br/>idProducto:Int")]
        public ProductoDetalleDTO ObtenerProductoDetalle(int idProducto)
        {
            using (LoginWebServiceProductosEntities db = new LoginWebServiceProductosEntities())
            {
                Producto producto = db.Productoes.Where(p => p.ProductoID == idProducto)
                    .FirstOrDefault();

                ProductoCategoria productoCategoria = new ProductoCategoria();

                if (producto != null)
                {
                    productoCategoria = db.ProductoCategorias.Where(c => c.ProductoCategoriaID == producto.ProductoCategoriaID)
                        .FirstOrDefault();
                }

                ProductoDetalleDTO productoDetalleDTO = new ProductoDetalleDTO()
                {
                    Categoria = productoCategoria.Nombre,
                    Nombre = producto.Nombre,
                    Color = producto.Color,
                    FechaCreacion = producto.FechaCreacion,
                    Precio = producto.Precio,
                    Id = producto.ProductoID
                };

                return productoDetalleDTO;
            }
        }

        [WebMethod(Description = "Agrega un nuevo Producto a la base de datos enviando los siguientes datos:" +
            "<br/>nombre:String(100)" +
            "<br/>categoria:Int[1:Bebidas, 2:Granos]" +
            "<br/>color:String(50)" +
            "<br/>precio:Decimal")] 
        public bool AgregarNuevoProducto(string nombre, int categoria, string color, decimal precio)
        {
            try
            {
                var productoUsuario = new Producto()
                {
                    Nombre = nombre,
                    ProductoCategoriaID = categoria,
                    Color = color,
                    Precio = precio,
                    FechaCreacion = DateTime.Now
                };

                if (productoUsuario != null)
                {
                    using (LoginWebServiceProductosEntities db = new LoginWebServiceProductosEntities())
                    {
                        db.Productoes.Add(productoUsuario);
                        db.SaveChanges();
                        return true;
                    }
                }
                else
                {
                    return false;
                }
            }
            catch (Exception e)
            {
                throw;
                return false;
            }
        }

        [WebMethod(Description = "Actualiza un producto cambiando alguna de las siguiente propiedades:" +
            "<br/>idProducto:Int" +
            "<br/>nombre:String(100)" +
            "<br/>categoria:Int[1:Bebidas, 2:Granos]" +
            "<br/>color:String(50)" +
            "<br/>precio:Decimal")]
        public bool ActualizarProducto(int idProducto, string nombre, int categoria, string color, decimal precio)
        {
            try
            {
                var productoUsuario = new Producto()
                {
                    ProductoID = idProducto,
                    Nombre = nombre,
                    ProductoCategoriaID = categoria,
                    Color = color,
                    Precio = precio
                };

                if (productoUsuario != null)
                {
                    using (LoginWebServiceProductosEntities db = new LoginWebServiceProductosEntities())
                    {
                        var productoActual = db.Productoes.FirstOrDefault(p => p.ProductoID == idProducto);
                        
                        productoActual.Nombre = nombre;
                        productoActual.ProductoCategoriaID = categoria;
                        productoActual.Color = color;
                        productoActual.Precio = precio;

                        db.SaveChanges();
                        return true;
                    }
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }

        [WebMethod(Description = "Elimina un producto de la base de datos por Id" +
            "<br/>idProducto:Int")]
        public bool EliminarProducto(int idProducto)
        {
            try
            {
                using(LoginWebServiceProductosEntities db = new LoginWebServiceProductosEntities())
                {
                    var productoEliminar = db.Productoes.FirstOrDefault(p => p.ProductoID == idProducto);
                    db.Productoes.Remove(productoEliminar);
                    db.SaveChanges();
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }
    }
}
