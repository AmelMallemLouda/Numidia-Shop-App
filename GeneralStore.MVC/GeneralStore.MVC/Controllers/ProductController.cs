using GeneralStore.MVC.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GeneralStore.MVC.Controllers
{
    public class ProductController : Controller
    {

        private ApplicationDbContext _db = new ApplicationDbContext();
        // GET: Product
        public ActionResult Index()
        {
            List<Product> productList = _db.Products.ToList();
            List<Product> orderdList = productList.OrderBy(pro => pro.ProductName).ToList();// to make the results in a list ordered by product name
            //to return an ordered list of products.
            return View(orderdList);
        }
        // Get Create Product

        public ActionResult Create()
        {
            return View();
        }

        //Post Product
        [HttpPost]
        public ActionResult Create(Product product)
        {
            if (ModelState.IsValid)
            {
                _db.Products.Add(product);
                _db.SaveChanges();
                return RedirectToAction("Index"); //RedirectToAction tells ASP.NET MVC to respond with a Browser redirect to a different action instead of rendering HTML. So, here, if we successfully add the new product, then we should return to the Index view
                                                  // If we have not successfully added the product, then we should leave it as is, and maybe the user will make modification to enable it to save.
            }

            return View(product);//this tells MVC to generate HTML to be displayed and sends it to the browser

        }
        //Get Delete
        [HttpGet]
        public ActionResult Delete(int? id)
        {
            //we look for the item by its id

            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            //Check if the product exist
            Product product = _db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }


        //Post Delete
        [HttpPost]
        public ActionResult Delete(int id)
        {
            //Access our database and use the id to delete the product we want.
            Product product = _db.Products.Find(id);
            _db.Products.Remove(product);

            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        //Get Update

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }

            //Check if the prod exist
            Product prod = _db.Products.Find(id);
            if (prod == null)
            {
                return HttpNotFound();
            }
            return View(prod);// this tells MVC to generate HTML to be displayed and sends it to the browser
        }
        //Post Edit
        [HttpPost]
        public ActionResult Edit(Product prod)
        {
            if (ModelState.IsValid)
            {

                // this says go get this entry from database and directly accessing  the state of this entity and by saying it is modified it is updating the information int the product
                _db.Entry(prod).State = EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction("Index");////RedirectToAction tells ASP.NET MVC to respond with a Browser redirect to a different action instead of rendering HTML. So, here, if we successfully add the new product, then we should return to the Index view
                                                 // If we have not successfully added the product, then we should leave it as is, and maybe the user will make modification to enable it to save.
            }

            return View(prod);//this tells MVC to generate HTML to be displayed and sends it to the browser
        }


        //Get Details
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }

            Product product = _db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }

            return View(product);
        }
    }
}