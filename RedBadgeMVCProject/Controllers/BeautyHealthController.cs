using Microsoft.AspNet.Identity;
using RedBadgeMVC.Models.BeautyHealthModels;
using RedBadgeMVC.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RedBadgeMVCProject.Controllers
{
    public class BeautyHealthController : Controller
    {

        private BeautyHealthService CreateItemService()// we use this method to call the service methods
        {
            var userId = Guid.Parse(User.Identity.GetUserId());// grabs the current userId

            var service = new BeautyHealthService(userId);
            return service;
        }
        // GET: BeautyHealth
        public ActionResult Index()//The ActionResult is a return type.it allows us to return a View() method
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new BeautyHealthService(userId);
            var model = service.GetBeautyHealth();
            return View(model);//That View() method will return a view that corresponds to the BeautyHealthController. view() displays all the BeautyHealth .

        }

        //GET
        public ActionResult Create()//GET method that gives a Seller a View in which they can fill in the Name for BeautyHealth
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]//The basic purpose of ValidateAntiForgeryToken attribute is to prevent cross-site request forgery attacks
        public ActionResult Create(BeautyHealthCreate model)//[HttpPost] method  will push the data inputted in the view through our service and into the db.
        {
            if (!ModelState.IsValid) return View(model);//makes sure the model is valid

            var service = CreateItemService();

            if (service.CreateBeautyHealth(model))
            {
                //TempData removes information after it's accessed
                TempData["SaveResult"] = "Your Beauty&Health was created.";

                return RedirectToAction("Index"); //returns the user back to the index view
            };
            ModelState.AddModelError("", "Beauty&Health could not be created.");//?

            return View(model);
        }
    }
}