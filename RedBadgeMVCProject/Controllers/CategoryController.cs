using Microsoft.AspNet.Identity;
using RedBadgeMVC.Models.CategoryModels;
using RedBadgeMVC.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RedBadgeMVCProject.Controllers
{
    public class CategoryController : Controller
    {
        private CategoryService CreateCategoryService()// we use this method to call the service methods
        {
            var userId = Guid.Parse(User.Identity.GetUserId());// grabs the current userId

            var service = new CategoryService(userId);
            return service;
        }

        // GET: Category
        public ActionResult Index()//The ActionResult is a return type.it allows us to return a View() method
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new CategoryService(userId);
            var model = service.GetAllCategories();
            return View(model);//That View() method will return a view that corresponds to the  CategoryController. view() displays all the categories  

        }

        //GET
        //public ActionResult Create()//GET method that gives users a View in which they can fill in propreties for a new category.
        //{
        //    return View();
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]//The basic purpose of ValidateAntiForgeryToken attribute is to prevent cross-site request forgery attacks
        //public ActionResult Create(CategoryCreate model)//[HttpPost] method  will push the data inputted in the view through our service and into the db.
        //{
        //    if (!ModelState.IsValid) return View(model);//makes sure the model is valid

        //    var service = CreateCategoryService();

        //    if (service.CreateCategory(model))
        //    {
        //        //TempData removes information after it's accessed
        //        TempData["SaveResult"] = "Your Category was created.";

        //        return RedirectToAction("Index"); //returns the user back to the index view
        //    };
        //    ModelState.AddModelError("", "Category could not be created.");//?

        //    return View(model);
        //}
        //public ActionResult Details(int Id)
        //{
        //    var svc = CreateCategoryService();
        //    var model = svc.GetCategoryById(Id);

        //    return View(model);
        //}

        //public ActionResult Edit(int id)
        //{
        //    var service = CreateCategoryService();
        //    var update = service.GetCategoryById(id);
        //    var model =
        //        new CategoryEdit
        //        {
        //           Clothing=update.Clothing,
        //           Home=update.Home,
        //           Beauty=update.Beauty
        //        };
        //    return View(model);
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit(int id, CategoryEdit model)
        //{
        //    if (!ModelState.IsValid) return View(model);

        //    if (model.CategoryId != id)
        //    {
        //        ModelState.AddModelError("", "ID Mismatch");
        //        return View(model);
        //    }
        //    var service = CreateCategoryService();

        //    if (service.UpdateCategory(model))
        //    {
        //        TempData["SaveResult"] = "Your Category was updated.";
        //        return RedirectToAction("Index");
        //    }

        //    ModelState.AddModelError("", "Your Category could not be updated.");
        //    return View();
        //}

        //[ActionName("Delete")]
        //public ActionResult Delete(int id)
        //{
        //    var svc = CreateCategoryService();
        //    var model = svc.GetCategoryById(id);

        //    return View(model);
        //}

        //[HttpPost]
        //[ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeletePost(int id)
        //{
        //    var service = CreateCategoryService();

        //    service.DeleteCategory(id);

        //    TempData["SaveResult"] = "Your Category was deleted";

        //    return RedirectToAction("Index");
        //}

    }
}