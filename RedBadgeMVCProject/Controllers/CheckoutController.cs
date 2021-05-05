using RedBadgeMVC.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RedBadgeMVCProject.Controllers
{
    public class CheckoutController : Controller
    {
        private ApplicationDbContext _db = new ApplicationDbContext();
      
        // GET: /Checkout/Complete
        public ActionResult Complete(int id)
        {
            bool isValid = _db.Orders.Any(
                o => o.OrderId== id &&
                o.UserName == User.Identity.Name);

            if (isValid)
            {
                return View(id);
            }
            else
            {
                return View("Error");
            }
        }
    }
}