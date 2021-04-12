using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using RedBadgeMVC.Data;
using RedBadgeMVC.Models.ItemModels;
using RedBadgeMVC.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace RedBadgeMVCProject.Controllers
{


    public class ItemController : Controller
    {
        private ItemService CreateItemService()// we use this method to call the service methods
        {
            var userId = Guid.Parse(User.Identity.GetUserId());// grabs the current userId

            var service = new ItemService(userId);
            return service;
        }
        // GET: Item
        public async Task<ActionResult> Index()//The ActionResult is a return type.it allows us to return a View() method
        {
           ViewBag.HomeKitchenId = await GetHomeAsync();
            ViewBag.ClothingId = await GetClothingAsync();
            ViewBag.BeautyHealthId = await GetBeautygAsync();

            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new ItemService(userId);
            var model = await service.GetAllItems();

            return View(model);//That View() method will return a view that corresponds to the ItemController. view() displays all the Items for the current user.

        }

        //GET
        public async Task<ActionResult> Create()//GET method that gives a Seller a View in which they can fill in the Name, Description....for an item
        {
            var service = CreateItemService();

            ViewBag.SyncOrAsync = "Asynchronous";
            ViewBag.HomeKitchenId = await GetHomeAsync();
            ViewBag.ClothingId = await GetClothingAsync();
            ViewBag.BeautyHealthId = await GetBeautygAsync();
            return View();

        }


        [HttpPost]
        [ValidateAntiForgeryToken]//The basic purpose of ValidateAntiForgeryToken attribute is to prevent cross-site request forgery attacks
        public async Task<ActionResult> Create(ItemCreate model)//[HttpPost] method  will push the data inputted in the view through our service and into the db.
        {
            if (!ModelState.IsValid)
            {
                
                ViewBag.ClothingId = await GetClothingAsync();
                ViewBag.BeautyHealthId = await GetBeautygAsync();
                ViewBag.HomeKitchenId = await GetHomeAsync();

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
           

            ViewBag.ClothingId = await GetClothingAsync();
            ViewBag.BeautyHealthId = await GetBeautygAsync();
            ViewBag.HomeKitchenId = await GetHomeAsync();
            return View(model);
        }
        public ActionResult Details(int id)
        {
            var svc = CreateItemService();
            var model = svc.GetItemById(id);

            return View(model);
        }
        public async Task<ActionResult> Edit(int id)//GET method that gives a Seller a View in which they can update the Name, Description....for an item
        {
            var service = CreateItemService();
            var update =await service.GetItemById(id);
            var model =
                new ItemEdit
                {
                    ItemName = update.ItemName,
                    ItemDescription = update.ItemDescription,
                    ItemPrice = update.ItemPrice,
                    ItemCondition = update.ItemCondition,
                    //CategoryName=item.Categoryname
                };
            ViewBag.HomeKitchenId = await GetHomeAsync();
            ViewBag.ClothingId = await GetClothingAsync();
            ViewBag.BeautyHealthId = await GetBeautygAsync();
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, ItemEdit item)
        {
            if (!ModelState.IsValid) return View(item);

            if (item.ItemId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(item);
            }
            var service = CreateItemService();

            if (await service .UpdateItem(item))
            {
                TempData["SaveResult"] = "Your note was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your note could not be updated.");
            return View();
        }


        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateItemService();
            var model = svc.GetItemById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateItemService();

            service.DeleteItem(id);

            TempData["SaveResult"] = "Your note was deleted";

            return RedirectToAction("Index");
        }
        public async Task<IEnumerable<SelectListItem>> GetHomeAsync()
        {
             var userId = Guid.Parse(User.Identity.GetUserId());
            var catService = new HomeKitchenService(userId);
            var categoryList = await catService.GetHomeKitchen();
           
            
            var catSelectList = categoryList.Select(
                                        e =>
                                            new SelectListItem
                                            {
                                                Value = e.HomeKitchenId.ToString(),
                                                Text = e.HomeKitchenName
                                            }
                                        ).ToList();
            
                
            return catSelectList;
        }
        public async Task<IEnumerable<SelectListItem>> GetClothingAsync()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var catService = new ClothingService(userId);
            var categoryList = await catService.GetClothing();


            var catSelectList = categoryList.Select(
                                        e =>
                                            new SelectListItem
                                            {
                                                Value = e.ClothingId.ToString(),
                                                Text = e.ClothingName
                                            }
                                        ).ToList();


            return catSelectList;
        }
        public async Task<IEnumerable<SelectListItem>> GetBeautygAsync()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var catService = new BeautyHealthService(userId);
            var categoryList = await catService.GetBeautyHealth();


            var catSelectList = categoryList.Select(
                                        e =>
                                            new SelectListItem
                                            {
                                                Value = e.BeautyhealthId.ToString(),
                                                Text = e.BeautyHealthName
                                            }
                                        ).ToList();


            return catSelectList;
        }
    }
}
