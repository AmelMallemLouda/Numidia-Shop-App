using RedBadgeMVC.Data;
using RedBadgeMVC.Models;
using RedBadgeMVC.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RedBadgeMVCProject.Controllers
{
    public class CartController : Controller
    {
        Product product = new Product();
        public ActionResult Index()
        {
           
           
                return View();
           
        }

        public ActionResult Buy(int id)
        {
            ApplicationDbContext _db = new ApplicationDbContext();
 
            //ProductModel productModel = new ProductModel();
            if (Session["cart"] == null)
            {
                List<Item> cart = new List<Item>();
                cart.Add(new Item { Product = _db.Products.Find(id), Quantity = 1 });
                Session["cart"] = cart;
            }
            else
            {
                List<Item> cart = (List<Item>)Session["cart"];
                int index = isExist(id);
                if (index != -1)
                {
                    cart[index].Quantity++; //increments by 1
                }
                else
                {
                    cart.Add(new Item { Product = _db.Products.Find(id), Quantity = 1 });
                }
                Session["cart"] = cart;
            }
            return RedirectToAction("Index");
        }

        public ActionResult Remove(int id)
        {
            List<Item> cart = (List<Item>)Session["cart"];
            int index = isExist(id);
            cart.RemoveAt(index);
            Session["cart"] = cart;
            return RedirectToAction("Index");
        }

       //helper method item exist
        private int isExist(int id)
        {
            List<Item> cart = (List<Item>)Session["cart"];
            for (int i = 0; i < cart.Count; i++) 
                if (cart[i].Product.ProductId.Equals(id))
                    return i;
            return -1; //the quantity will decrement by 1
        }

    }
}