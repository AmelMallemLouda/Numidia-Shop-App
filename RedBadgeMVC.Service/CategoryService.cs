using RedBadgeMVC.Data;
using RedBadgeMVC.Models.CategoryModels;

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
                CategoryName=category.CategoryName

            };
            using (var ctx = new ApplicationDbContext())// Access database
            {
                ctx.Categories.Add(entity);// access items Table and add items
                return ctx.SaveChanges() == 1;
            }
        }

        // Get categories
        public IEnumerable<Category> GetCategories()
        {
            using (var ctx = new ApplicationDbContext())
            {
                return ctx.Categories.ToList();
            }
        }

        public IEnumerable<CategoryListItem> GetAllCategories()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.Categories.Select(e => new CategoryListItem
                {
                    CategoryId=e.CategoryId,
                   CategoryName=e.CategoryName,
                   Items=e.Items.Select(
                       z =>new ItemList
                       {
                           ItemName=z.ItemName,
                           ItemPrice=z.ItemPrice,
                           Quantity=z.Quantity
                       }).ToList()



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
                    CategoryId = entity.CategoryId,
                    CategoryName = entity.CategoryName,
                    Items = entity.Items.Select(
                       z => new ItemList
                       {
                           ItemName = z.ItemName,
                           ItemPrice = z.ItemPrice,
                           Quantity = z.Quantity
                       }).ToList()
                };
            }
        }

        public bool UpdateCategory(CategoryEdit category)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Categories.Where(e => e.CategoryId == category.CategoryId).FirstOrDefault();

                entity.CategoryName = category.CategoryName;
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
