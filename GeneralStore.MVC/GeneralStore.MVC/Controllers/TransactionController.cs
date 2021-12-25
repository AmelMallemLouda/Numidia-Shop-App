using GeneralStore.MVC.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;


namespace GeneralStore.MVC.Controllers
{
    public class TransactionController : Controller
    {
        private ApplicationDbContext _db = new ApplicationDbContext();
        // GET: Transaction Create

        [HttpGet]
        public ActionResult Create()
        {

            //Some data that you can use in your view
            ViewData["Product"] = _db.Products.Select(p => new SelectListItem
            {
                Text = p.ProductName,
                Value = p.ProductId.ToString()
            });
            ViewData["Customer"] = _db.Customers.Select(p => new SelectListItem
            {
                Text = p.FirstName + " " + p.LastName,
                Value = p.CustomerId.ToString()
            });
            return View();
        }

        //Podt Transaction/Create

        [HttpPost]
        public ActionResult Create (Transaction model)
        {
            
            model.DateOfTransaction = DateTimeOffset.Now;// set the date to right now
           /* var createdObj =*/ _db.Transactions.Add(model);// add trans to datatbase

            if (_db.SaveChanges() == 1)// as saving we check if we created the transaction
            {
                return Redirect("Index")/*("/transaction/" + createdObj.TransactionId)*/;// redirect to the transaction page to view the trans you created
            }
            //viewdata["errmessage"]
            return View(model);
        }

        public ActionResult Index()
        {
            return View(_db.Transactions.ToList());
        }

        public ActionResult Details(int id)
        {
           
            var transaction = _db.Transactions.Find(id);
            if (transaction == null)
            {
                return HttpNotFound();
            }
            return View(transaction);
        }

        public ActionResult Edit(int id)
        {
          
            // In view Edit we need to know the current prod and customer and the others existing cust and prod

            Transaction transaction = _db.Transactions.Find(id);
            if (transaction == null)
            {
                return HttpNotFound();
            }
            //If the trans exists
            ViewData["Product"] = _db.Products.Select(p => new SelectListItem
            {
                Text = p.ProductName,
                Value = p.ProductId.ToString()
            });
            ViewData["Customer"] = _db.Customers.Select(p => new SelectListItem
            {
                Text = p.FirstName + " " + p.LastName,
                Value = p.CustomerId.ToString()
            });
            return View(transaction);
        }

        [HttpPost]
        public ActionResult Edit(Transaction model)
        {
            var entity = _db.Transactions.Find(model.TransactionId);
            entity.CustomerId = model.CustomerId;
            entity.ProductId = model.ProductId;
            entity.Price = model.Price;
            entity.DateOfTransaction = model.DateOfTransaction;
            if (_db.SaveChanges() == 1)
            {
                return RedirectToAction("Index");
            }
            return View(model); //it will return the view again if the transaction was not changed. Or add an error message.
        }

       [HttpGet]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }

            var transaction = _db.Transactions.Find(id);
            if (transaction == null)
            {
                return HttpNotFound();
            }
            return View(transaction);
        }



        [HttpPost]
        public ActionResult Delete(int id)
        {
            //Access our database and use the id to delete the product we want.
            Transaction transaction = _db.Transactions.Find(id);
            _db.Transactions.Remove(transaction);

            _db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}