using RedBadgeMVC.Data;
using RedBadgeMVC.Models.CategoryModels;
using RedBadgeMVC.Models.ClothingModels;
using RedBadgeMVC.Models.ItemModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedBadgeMVC.Service
{
    public class CategoryService
    {
        private readonly Guid _userId;
        public CategoryService(Guid userId)
        {
            _userId = userId;
        }

        //Create an instance of Item

        public bool CreateCategory(CategoryCreate category)
        {
            var entity = new Category()
            {
                ClothingId=category.ClothingId,
                HomeId=category.HomeId,
                BeautyHealthId=category.BeautyId

            };
            using (var ctx = new ApplicationDbContext())// Access database
            {
                ctx.Categories.Add(entity);// access items Table and add items
                return ctx.SaveChanges() == 1;
            }
        }
        
        public IEnumerable<CategoryListItem> GetAllCategories()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.Categories.Select(e => new CategoryListItem
                {

                   ClothingId=e.ClothingId,
                   HomeId=e.HomeId,
                   BeautyId=e.BeautyHealthId,



                }) ;

                return query.ToArray();
            }
        }
        public CategoryDetails GetCategoryById(int categoryId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Categories.Where(e => e.CategoryId == categoryId).FirstOrDefault();
                return new CategoryDetails
                {
                    CategoryId=entity.CategoryId,
                    HomeId=entity.HomeId,
                    BeautyID=entity.BeautyHealthId

                    //Items = entity.Items.Select(x => new Models.ItemModels.ItemList //Access Item Table and the itemList Propreties
                    //{
                    //    ItemId = x.ItemId,
                    //    ItemName = x.ItemName,
                    //    ItemPrice = x.ItemPrice
                    //}).ToList()
                };
            }
        }

        public bool UpdateCategory(CategoryEdit category)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Categories.Where(e => e.CategoryId == category.CategoryId).FirstOrDefault();

                entity.HomeId = category.HomeId;
                entity.ClothingId = category.ClothingId;
                entity.BeautyHealthId = category.BeautyID;
                return ctx.SaveChanges() == 1;

            }
        }

        public bool DeleteCategory(int categoryId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Categories.Where(e => e.CategoryId == categoryId).FirstOrDefault();
                ctx.Categories.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }

    }
}
