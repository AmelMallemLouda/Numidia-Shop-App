using RedBadgeMVC.Data;
using RedBadgeMVC.Models.CategoryModels;

using RedBadgeMVC.Models.ItemModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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

        public async Task<bool> CreateCategoryAsync(CategoryCreate model)
        {
            var entity = new Category()
            {
                OwnerID = _userId,
                CategoryName =model.CategoryName

            };
            using (var ctx = new ApplicationDbContext())// Access database
            {
                ctx.Categories.Add(entity);// access items Table and add items
                return await ctx.SaveChangesAsync() == 1;
            }
        }



        public async Task<IEnumerable<CategoryListItem>> GetCategoriesAsync()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = await ctx
                            .Categories
                            .Where(e => e.OwnerID == _userId)
                            .Select(
                                e =>
                                    new CategoryListItem
                                    {
                                        CategoryId = e.CategoryId,
                                        CategoryName = e.CategoryName,
                                        Items= e.Products
                                .Select(
                                    x => new ProductShortList
                                    {
                                        ProductId = x.ProductId,
                                        Name = x.ProductName,
                                        Price = x.ProductPrice,
                                    }
                                ).ToList()

                                    }
                    ).ToListAsync();
                return query;



            }   
            
        }
        public async Task<CategoryDetails> GetCategoryByIdAsync(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = await
                    ctx
                        .Categories
                        .Where(e => e.CategoryId == id && e.OwnerID == _userId)
                        .FirstOrDefaultAsync();
                return
                    new CategoryDetails
                    {
                        CategoryId = entity.CategoryId,
                        CategoryName = entity.CategoryName,
                        
                        Items = entity.Products
                                .Select(
                                    x => new ProductShortList
                                    {
                                        ProductId = x.ProductId,
                                        Name = x.ProductName,
                                        Price=x.ProductPrice,
                                    }
                                ).ToList()
                    };
            }
        }

        public async Task<bool> UpdateCategoryAsync(CategoryEdit category)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = await
                    ctx
                        .Categories
                        .Where(e => e.CategoryId == category.CategoryId && e.OwnerID == _userId)
                        .FirstOrDefaultAsync();
                entity.CategoryName= category.CategoryName;

                return await ctx.SaveChangesAsync() == 1;
            }
        }

        public async Task<bool> DeleteCategoryAsync(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = await
                    ctx
                        .Categories
                        .Where(e => e.CategoryId == id && e.OwnerID == _userId)
                        .FirstOrDefaultAsync();
                ctx.Categories.Remove(entity);

                return await ctx.SaveChangesAsync() == 1;
            }
        }

    }
}
