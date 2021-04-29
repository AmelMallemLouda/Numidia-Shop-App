using Microsoft.AspNet.Identity;
using RedBadgeMVC.Models.ReviewModels;
using RedBadgeMVC.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace RedBadgeMVCProject.Controllers
{
    public class ReviewController : Controller
    {

        private ReviewService CreateReviewService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new ReviewService(userId);
            return service;
        }
        // GET: Review
        public async Task<ActionResult> Index()
        {
            var service = CreateReviewService();
            var model = await service.GetReviewAsync();
            return View(model);
        }
        public async Task<ActionResult> Details(int id)
        {
          
            var svc = CreateReviewService();
            var model = await svc.GetReviewByIdAsync(id);

            return View(model);
        }


        public async Task<ActionResult> Create()
        {
            var service = CreateReviewService();

           
            ViewBag.ProductId = await GetItemsAsync();
            

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(ReviewCreate review)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.ProductId = await GetItemsAsync();
               

                return View(review);

            }

            var service = CreateReviewService();

            if (await service.CreateReviewAsync(review))
            {
                TempData["SaveResult"] = "Your Review was created.";
                return RedirectToAction("Index"); //returns the user back to the index view
            };
            ModelState.AddModelError("", "review could not be created.");//?
           ViewBag.ProductId = await GetItemsAsync();



            return View(review);
        }

        public async Task<ActionResult> Edit(int id)
        {
            var service = CreateReviewService();
            var detail = await service.GetReviewByIdAsync(id);
            var model =
                new ReviewEdit
                {
                    ReviewId = detail.ReviewId,
                    Reviews = detail.Reviews,
                   //ItemName=detail.ItemName

                };

            ViewBag.ProductId = await GetItemsAsync();

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, ReviewEdit note)
        {
            if (!ModelState.IsValid) return View(note);
            if (note.ReviewId != id)
            {
                ModelState.AddModelError("", "ID Mismatch");
                ViewBag.ProductId = await GetItemsAsync();

                return View(note);
            }
            var service = CreateReviewService();
            if (await service.UpdateReviewAsync(note))
            {
                TempData["SaveResult"] = "Review was successfully updated.";
                return RedirectToAction("Index");
            }
            ViewBag.ProductId = await GetItemsAsync();

            ModelState.AddModelError("", "Menu could not be updated.");
            return View(note);
        }

        public async Task<ActionResult> Delete(int id)
        {
            var service = CreateReviewService();
            var detail = await service.GetReviewByIdAsync(id);
            return View(detail);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteReview(int id)
        {
            var service = CreateReviewService();
            await service.DeleteReviewAsync(id);
            TempData["SaveResult"] = "Your review was successfully deleted.";

            return RedirectToAction("Index");
        }

       //Helper method to bring data of item
        public async Task<IEnumerable<SelectListItem>> GetItemsAsync()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var Service = new ItemService(userId);
            var List = await Service.GetAllItemsAsync();

            var catSelectList = List.Select(
                                        e =>
                                            new SelectListItem
                                            {
                                                Value = e.ProductId.ToString(),

                                                Text = e.ProductName
                                            }
                                        ).ToList();

            return catSelectList;
        }
    }
}