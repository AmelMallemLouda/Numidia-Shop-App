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
    }
}