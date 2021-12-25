using GeneralStore.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GeneralStore.MVC.Controllers
{
    public class CustomerController : Controller
    {
        private ApplicationDbContext _db = new ApplicationDbContext();
        // GET: Customer
        public ActionResult Index()
        {
            return View(_db.Customers.ToList());
        }

        //get Create
        public ActionResult Create()
        {
            return View();
        }
        //Post Create
        [HttpPost]// tu restrict an action method so that the method handles only httpPost actions
        public ActionResult Create(Customer cus)
        {
            if (ModelState.IsValid)
            {
                _db.Customers.Add(cus);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cus);//this tells MVC to generate HTML to be displayed and sends it to the browser
        }
        //Get Details
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new  HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            Customer cus = _db.Customers.Find(id);
            if (cus == null)
            {
                return HttpNotFound();
            }
            return View(cus);
        }

        //GetDelete
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            Customer cus = _db.Customers.Find(id);
            if (cus == null)
            {
                return HttpNotFound();
            }
            return View(cus);
        }
        //Post Delete

        [HttpPost]

        public ActionResult Delete(int id)
        {
            Customer cus = _db.Customers.Find(id);
            _db.Customers.Remove(cus);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        //Get Edit

        public ActionResult Edit(int? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            Customer cus = _db.Customers.Find(id);
            if (cus == null)
            {
                return HttpNotFound();
            }
            return View(cus);
        }
        //Post delete
        [HttpPost]
        public ActionResult Edit(Customer cus)
        {
            if (ModelState.IsValid)
            {
                _db.Entry(cus).State = System.Data.Entity.EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cus);
        }
    }
}