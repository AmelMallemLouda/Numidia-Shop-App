using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using RedBadgeMVC.Data;
using RedBadgeMVC.Models.ItemModels;
using RedBadgeMVC.Service;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace RedBadgeMVCProject.Controllers
{


    public class ProductController : Controller
    {
        private readonly ApplicationDbContext _db = new ApplicationDbContext();
        private ItemService CreateItemService()// we use this method to call the service methods
        {
            var userId = Guid.Parse(User.Identity.GetUserId());// grabs the current userId

            var service = new ItemService(userId);
            return service;
        }
        // GET: Item
        public async Task<ActionResult> Index()//The ActionResult is a return type.it allows us to return a View() method
        {

            var service = CreateItemService();
            var model = await service.GetAllItemsAsync();

            return View(model);//That View() method will return a view that corresponds to the ItemController. view() displays all the Items for the current user.

        }

        //GET
        public async Task<ActionResult> Create()//GET method that gives a Seller a View in which they can fill in the Name, Description....for an item
        {
            var service = CreateItemService();

                ViewBag.StoreId = await GetStoresAsync();
                ViewBag.CategoryId = await GetCategoriesAsync();

            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]//The basic purpose of ValidateAntiForgeryToken attribute is to prevent cross-site request forgery attacks
        public async Task<ActionResult> Create(ProductCreate model,HttpPostedFileBase file)//[HttpPost] method  will push the data inputted in the view through our service and into the db.
        {
            string pic = null;
            if (file != null) //file can't be null
            {

                //file path
                 pic = Path.GetFileName(file.FileName);
                var path = Path.Combine(Server.MapPath("~/Image/"), pic);
                string filepathToSave = "Image/" + pic;
                
                // file is uploaded
                file.SaveAs(path);
                ViewBag.ImagePath = filepathToSave;
            }
            model.ProductImage = pic;
            if (!ModelState.IsValid)
            {
                //synchronous action method that is used to display a list
                
                ViewBag.CategoryId = await GetCategoriesAsync();
                ViewBag.StoreId = await GetStoresAsync();

                return View(model);//makes sure the model is valid
            }
            var service = CreateItemService();
           
            if (await service.CreateItem(model))
            {
                //TempData removes information after it's accessed
                TempData["SaveResult"] = "Your note was created.";
                return RedirectToAction("Index"); //returns the user back to the index view
            };
            ModelState.AddModelError("", "Note could not be created.");//?

            ViewBag.CategoryId = await GetCategoriesAsync();
            ViewBag.StoreId = await GetStoresAsync();

            return View(model);
        }
        public async Task<ActionResult> Details(int id)
        {
            var svc = CreateItemService();
            var model = await svc.GetItemByIdAsync(id);

            return View(model);
        }
        public async Task<ActionResult> Edit(int id)//GET method that gives a Seller a View in which they can update the Name, Description....for an item
        {
            var service = CreateItemService();
            var update = await service.GetItemByIdAsync(id);
            var model =
                new ProductEdit
                {
                    ProductName = update.ProductName,
                    ProductDescription = update.ProductDescription,
                    ProductPrice = update.ProductPrice,
                    ProductCondition = update.ProductCondition,
                    Quantity=update.Quantity,
                    CategoryId=update.CategoryId,
                   
                };
            ViewBag.CategoryId = await GetCategoriesAsync();

            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, ProductEdit item)
        {
            if (!ModelState.IsValid) return View(item);// indicates if it was possible to bind the incoming values from the request to the model

            if (item.ProductId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                ViewBag.CategoryId = await GetCategoriesAsync();
                ViewBag.StoreId = await GetStoresAsync();

                return View(item);
            }
            var service = CreateItemService();

            if (await service .UpdateItem(item))
            {
                TempData["SaveResult"] = "Your note was updated.";
                return RedirectToAction("Index");
            }

            ViewBag.CategoryId = await GetCategoriesAsync();
            ViewBag.StoreId = await GetStoresAsync();
            ModelState.AddModelError("", "Your note could not be updated.");
            return View(item);
        }


        [ActionName("Delete")]
        public async Task<ActionResult> Delete(int id)
        {
            var service = CreateItemService();
            var delete = await service.GetItemByIdAsync(id);
            return View(delete);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeletePost(int id)
        {
            var service = CreateItemService();
            await service.DeleteItemAsync(id);
            TempData["SaveResult"] = "Your note was successfully deleted.";

            return RedirectToAction("Index");
        }

        //Helper Method to call categories

        public async Task<IEnumerable<SelectListItem>> GetCategoriesAsync()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var categoryService = new CategoryService(userId);
            var categoryList = await categoryService.GetCategoriesAsync();

            var catSelectList = categoryList.Select(
                                        e =>
                                            new SelectListItem
                                            {
                                                Value = e.CategoryId.ToString(),
                                               
                                                Text = e.CategoryName
                                            }
                                        ).ToList();

            return catSelectList;
        }

        public async Task<IEnumerable<SelectListItem>> GetStoresAsync()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var categoryService = new StoreService(userId);
            var categoryList = await categoryService.GetStoresAsync();

            var catSelectList = categoryList.Select(
                                        e =>
                                            new SelectListItem
                                            {
                                                Value = e.StoreId.ToString(),

                                                Text = e.StoreName
                                            }
                                        ).ToList();

            return catSelectList;
        }
    }
}
