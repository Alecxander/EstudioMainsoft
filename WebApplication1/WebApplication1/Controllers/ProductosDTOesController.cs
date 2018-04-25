using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;
using WebApplication1.Models.DTO;

namespace WebApplication1.Controllers
{
    public class ProductosDTOesController : Controller
    {
        private WebApplication1Context db = new WebApplication1Context();

        // GET: ProductosDTOes
        public ActionResult Index()
        {
            using(ServiceReferenceSomee.ProductosSoapClient serviceReferenceSomee = new ServiceReferenceSomee.ProductosSoapClient())
            {
                var productos = serviceReferenceSomee.ObtenerProductos().Select(p => new ProductosDTO
                {
                    IdProducto = p.Id,
                    Nombre = p.Nombre,
                    Precio = p.Precio
                }).ToList();
                
                return View(productos);
                

                //return View(db.ProductosDTOes.ToList());
            }

        }

        // GET: ProductosDTOes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            using(ServiceReferenceSomee.ProductosSoapClient ProductosSoapClient = new ServiceReferenceSomee.ProductosSoapClient())
            {
                int _id = (id == null ? default(int) : (int)id);
                var producto = ProductosSoapClient.ObtenerProductoDetalle(_id);
                ProductoDetalleDTO productoDetalleDTO = new ProductoDetalleDTO()
                {
                    Id = producto.Id,
                    Categoria = producto.Categoria,
                    Color = producto.Color,
                    Nombre = producto.Nombre,
                    Precio = producto.Precio,
                    FechaCreacion = producto.FechaCreacion
                };

                if (productoDetalleDTO == null)
                {
                    return HttpNotFound();
                }
                return View(productoDetalleDTO);
            }


            //ProductosDTO productosDTO = db.ProductosDTOes.Find(id);
            //if (productosDTO == null)
            //{
            //    return HttpNotFound();
            //}
            //return View(productosDTO);
        }

        // GET: ProductosDTOes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProductosDTOes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdProducto,Nombre,Precio")] ProductosDTO productosDTO)
        {
            if (ModelState.IsValid)
            {
                db.ProductosDTOes.Add(productosDTO);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(productosDTO);
        }

        // GET: ProductosDTOes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductosDTO productosDTO = db.ProductosDTOes.Find(id);
            if (productosDTO == null)
            {
                return HttpNotFound();
            }
            return View(productosDTO);
        }

        // POST: ProductosDTOes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdProducto,Nombre,Precio")] ProductosDTO productosDTO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(productosDTO).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(productosDTO);
        }

        // GET: ProductosDTOes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductosDTO productosDTO = db.ProductosDTOes.Find(id);
            if (productosDTO == null)
            {
                return HttpNotFound();
            }
            return View(productosDTO);
        }

        // POST: ProductosDTOes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ProductosDTO productosDTO = db.ProductosDTOes.Find(id);
            db.ProductosDTOes.Remove(productosDTO);
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
