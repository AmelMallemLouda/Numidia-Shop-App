using Microsoft.AspNet.Identity;
using RedBadgeMVC.Models.ClothingModels;
using RedBadgeMVC.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RedBadgeMVCProject.Controllers
{
    public class ClothingController : Controller
    {

        private ClothingService CreateClothingService()// we use this method to call the service methods
        {
            var userId = Guid.Parse(User.Identity.GetUserId());// grabs the current userId

            var service = new ClothingService(userId);
            return service;
        }
        // GET: Clothing
        public ActionResult Index()//The ActionResult is a return type.it allows us to return a View() method
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new ClothingService(userId);
            var model = service.GetClothing();
            return View(model);//That View() method will return a view that corresponds to the ClothingController. view() displays all the Clothing .

        }

        //GET
        public ActionResult Create()//GET method that gives a Seller a View in which they can fill in the Name for BeautyHealth
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]//The basic purpose of ValidateAntiForgeryToken attribute is to prevent cross-site request forgery attacks
        public ActionResult Create(ClothingCreate model)//[HttpPost] method  will push the data inputted in the view through our service and into the db.
        {
            if (!ModelState.IsValid) return View(model);//makes sure the model is valid

            var service = CreateClothingService();

            if (service.CreateClothing(model))
            {
                //TempData removes information after it's accessed
                TempData["SaveResult"] = "Your Clothing category was created.";

                return RedirectToAction("Index"); //returns the user back to the index view
            };
            ModelState.AddModelError("", "Clothing category could not be created.");//?

            return View(model);
        }
    }
}