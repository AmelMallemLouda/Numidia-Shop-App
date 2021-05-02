using Microsoft.AspNet.Identity;
using RedBadgeMVC.Data;
using RedBadgeMVC.Models.CategoryModels;
using RedBadgeMVC.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace RedBadgeMVCProject.Controllers
{
    public class CategoryController : Controller
    {
        private ApplicationDbContext _db = new ApplicationDbContext();
        private CategoryService CreateCategoryService()// we use this method to call the service methods
        {
            var userId = Guid.Parse(User.Identity.GetUserId());// grabs the current userId

            var service = new CategoryService(userId);
            return service;
        }
        public async Task<ActionResult> Index()
        {
            //The ViewBag in ASP.NET MVC is used to transfer temporary data (which is not included in the model) from the controller to the view

            //ViewBag.ItemId = await GetItemsAsync();
            var service = CreateCategoryService();
            var model = await service.GetCategoriesAsync();
      
            return View(model); //That View() method will return a view that corresponds to the ItemController. view() displays all the Items for the current user.

        }
        public async Task<ActionResult> Create()
        {
            ViewBag.ItemId = await GetItemsAsync();
            return View();
        }

       

        [HttpPost]
        [ValidateAntiForgeryToken]//The basic purpose of ValidateAntiForgeryToken attribute is to prevent cross-site request forgery attacks
        public async Task<ActionResult> Create(CategoryCreate model)//[HttpPost] method  will push the data inputted in the view through our service and into the db.
        {
            if (!ModelState.IsValid) return View(model);//makes sure the model is valid

            var service = CreateCategoryService();

            if (await service.CreateCategoryAsync(model))
            {
                //TempData removes information after it's accessed
                TempData["SaveResult"] = "Your Category was created.";
                ViewBag.ItemId = await GetItemsAsync();

                return RedirectToAction("Index"); //returns the user back to the index view
            };
            ModelState.AddModelError("", "Category could not be created.");//?

            return View(model);
        }
        public async Task<ActionResult> Details(int id)
        {
            ViewBag.ItemId = await GetItemsAsync();
            var svc = CreateCategoryService();
            var model = await svc.GetCategoryByIdAsync(id);

            return View(model);
        }
      
        //Get
        public async Task<ActionResult> Edit(int id)
        {
            var service = CreateCategoryService();
            var detail = await service.GetCategoryByIdAsync(id);
            var model =
                new CategoryEdit
                {
                    CategoryId = detail.CategoryId,
                    CategoryName = detail.CategoryName
                };
            ViewBag.ItemId = await GetItemsAsync();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, CategoryEdit model)
        {
            if (!ModelState.IsValid) return View(model);
            ViewBag.ItemId = await GetItemsAsync();
            if (model.CategoryId != id)
            {
                ModelState.AddModelError("", "ID Mismatch");
                return View(model);
            }
            var service = CreateCategoryService();

            if (await service.UpdateCategoryAsync(model))
            {
                TempData["SaveResult"] = "Your Category was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your Category could not be updated.");
            return View(model);
        }

        public async Task<ActionResult> Delete(int id)
        {
            var service = CreateCategoryService();
            var detail = await service.GetCategoryByIdAsync(id);
            return View(detail);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteCategory(int id)
        {
            var service = CreateCategoryService();
            if (await service.DeleteCategoryAsync(id))
            {
                TempData["SaveResult"] = "Your category was successfully deleted.";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Your category could not be updated.");
            return View();
        }
        // Helper Method
        public async Task<IEnumerable<SelectListItem>> GetItemsAsync()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var categoryService = new ItemService(userId);
            var categoryList = await categoryService.GetAllItemsAsync();

            var catSelectList = categoryList.Select(
                                        e =>
                                            new SelectListItem
                                            {
                                                Value = e.ProductId.ToString(),

                                                Text = e.ProductName,
                                                
                                            }
                                        ).ToList();

            return catSelectList;
        }

    }
}