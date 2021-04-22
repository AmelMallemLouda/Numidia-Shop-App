using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using RedBadgeMVC.Data;
using RedBadgeMVC.Models.ItemModels;
using RedBadgeMVC.Models.ReviewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedBadgeMVC.Service
{
    public class ItemService
    {
        private readonly Guid _userId;

        public ItemService(Guid userId)
        {
            _userId = userId;
        }

        //Create an instance of Item
        public async Task<bool> CreateItem(ProductCreate item)
        {
            var entity = new Product()
            {
                OwnerID = _userId, //We want the user who creates the note to be the user who is logged in
                ProductName = item.ProductName,
                ProductDescription = item.ProductDescription,
                ProductPrice = item.ProductPrice,
                ItemCondition = item.ProductCondition,
                Quantity=item.Quantity,
               CategoryId=item.CategoryId,
              CategoryName=item.CategoryName,
              StoreId=item.StoreId,
              StoreName=item.StoreName,
                ProductImage = item.ProductImage



            };
            using (var ctx = new ApplicationDbContext())// Access database
            {
                ctx.Products.Add(entity);// access items Table and add items

                return await ctx.SaveChangesAsync() == 1;
            }
        }
        

        //See all the Items 
        public async Task<IEnumerable<ProductList>> GetAllItemsAsync()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = await ctx.Products.Where(e => e.OwnerID == _userId)
                    .Select(e => new ProductList
                    {
                        ProductId = e.ProductId,
                        ProductName = e.ProductName,
                        ProductPrice = e.ProductPrice,
                    Quantity=e.Quantity,
                   CategoryName=e.Category.CategoryName,
                        ProductImage = e.ProductImage,
                   
                  


                    }).ToListAsync();

                return query.OrderBy(e=> e.ProductId);
            }
        }

        //See Details

        public async Task<ProductDetails> GetItemByIdAsync(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =await 
                    ctx
                    .Products
                    .Where(e => e.ProductId == id && e.OwnerID == _userId).FirstOrDefaultAsync();

                return
                    new ProductDetails
                    {
                        ProductId = entity.ProductId,
                        ProductName = entity.ProductName,
                        ProductDescription = entity.ProductDescription,
                        ProductPrice = entity.ProductPrice,
                        ProductCondition = entity.ItemCondition,
                        CategoryName=entity.CategoryName,
                        CategoryId = entity.CategoryId,
                        Quantity=entity.Quantity,
                        StoreId = entity.StoreId,
                        StoreName = entity.StoreName,
                        ItemImage = entity.ProductImage,
                        Reviews = entity.Reviews
                        .Select(z => new ReviewListItem
                         {
                            ReviewId=z.ReviewId,
                            Reviews=z.Reviews
                         }).ToList(),


                    };
            }
        }
       

        public async Task<bool> UpdateItem(ProductEdit item)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = await ctx.Products.Where(e => e.ProductId == item.ProductId && e.OwnerID == _userId).FirstOrDefaultAsync();
                entity.ProductId = entity.ProductId;
                entity.ProductName = item.ProductName;
                entity.ProductDescription = item.ProductDescription;
                entity.ProductPrice = item.ProductPrice;
                entity.ItemCondition = item.ProductCondition;
                entity.CategoryId = item.CategoryId;
                entity.Quantity = item.Quantity;
                entity.StoreId = item.StoreId;
                entity.ProductImage = item.ProductImage;

                return await ctx.SaveChangesAsync() == 1;
            }
        }

        public async Task<bool> DeleteItemAsync(int itemId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity= await ctx.Products.Where(e => e.ProductId == itemId && e.OwnerID == _userId).FirstOrDefaultAsync();//to return the first element of a sequence or a default value if element isn't there.

                ctx.Products.Remove(entity);

                return await ctx.SaveChangesAsync() == 1;
            };
        }
    }
}
