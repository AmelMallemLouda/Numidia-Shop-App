using Microsoft.AspNet.Identity;
using RedBadgeMVC.Models.StoreModels;
using RedBadgeMVC.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace RedBadgeMVCProject.Controllers
{

    
    public class StoreController : Controller
    {

        public StoreService CreateStoreService()
        {
             var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new StoreService(userId);
            return service;
        }
        // GET: Store
        public async Task<ActionResult> Index()
        {
            var service = CreateStoreService();
            var model = await service.GetStoresAsync();
            return View(model);
        }

        //Helper method
        public async Task<IEnumerable<SelectListItem>> GetItemAsync()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var storeService = new ItemService(userId);
            var storeList = await storeService.GetAllItemsAsync();

            var catSelectList = storeList.Select(
                                        e =>
                                            new SelectListItem
                                            {
                                                Value = e.ProductId.ToString(),
                                                Text = e.ProductName
                                            }
                                        ).ToList();

            return catSelectList;
        }
        public async Task<ActionResult> Create()
        {
            var service = CreateStoreService();

            //ViewBag.SyncOrAsync = "Asynchronous";
            ViewBag.ItemId = await GetItemAsync();
    
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(StoreCreate model)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.AreaId = await GetItemAsync();

                return View(model);

            }

            var service = CreateStoreService();

            if (await service.CreateStoreAsync(model))
            {
                TempData["SaveResult"] = " Then Store Has Been Created.";
                return RedirectToAction("Index");

            }

            ModelState.AddModelError("", "Then Store Has not Been Created.");
            ViewBag.AreaId = await GetItemAsync();
           

            return View(model);
        }

        public async Task<ActionResult> Details(int id)
        {

            var svc = CreateStoreService();
            var model = await svc.GetStoreByIdAsync(id);

            return View(model);
        }
        public async Task<ActionResult> Edit(int id)
        {
            var service = CreateStoreService();
            var update = await service.GetStoreByIdAsync(id);
            var model =
                new StoreEdit
                {
                    StoreName=update.StoreName,
                    PhoneNumber=update.PhoneNumber,
                    Latitude = update.Latitude,
                    Longitude = update.Longitude
                };
            //ViewBag.SyncOrAsync = "Asynchronous";
            ViewBag.AreaId = await GetItemAsync();


            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, StoreEdit store)
        {
            if (!ModelState.IsValid) return View(store);
            if (store.StoreId != id)
            {
                ModelState.AddModelError("", "ID Mismatch");
                ViewBag.MenuId = await GetItemAsync();


                return View(store);
            }
            var service = CreateStoreService();
            if (await service.UpdateStoretAsync(store))
            {
                TempData["SaveResult"] = "Store Information Has Been Updated.";
                return RedirectToAction("Index");
            }
            ViewBag.MenuId = await GetItemAsync();


            ModelState.AddModelError("", "Then Store Has not Been Updated.");
            return View(store);
        }

        public async Task<ActionResult> Delete(int id)
        {
            var service = CreateStoreService();
            var details = await service.GetStoreByIdAsync(id);
            return View(details);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteStore(int id)
        {
            var service = CreateStoreService();
            await service.DeleteStoreAsync(id);
            TempData["SaveResult"] = "Restaurant Has Been successfully deleted.";

            return RedirectToAction("Index");
        }

    }
}