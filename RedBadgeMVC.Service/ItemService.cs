using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using RedBadgeMVC.Data;
using RedBadgeMVC.Models.ItemModels;
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
        public async Task<bool> CreateItem(ItemCreate item)
        {
            var entity = new Item()
            {
                OwnerID = _userId, //We want the user who creates the note to be the user who is logged in
                ItemName = item.ItemName,
                ItemDescription = item.ItemDescription,
                ItemPrice = item.ItemPrice,
                ItemCondition = item.ItemCondition,
                Quantity=item.Quantity,
               CategoryId=item.CategoryId,
              CategoryName=item.CategoryName,
               
                
            };
            using (var ctx = new ApplicationDbContext())// Access database
            {
                ctx.Items.Add(entity);// access items Table and add items

                return await ctx.SaveChangesAsync() == 1;
            }
        }
        

        //See all the Items 
        public async Task<IEnumerable<ItemList>> GetAllItemsAsync()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = await ctx.Items.Where(e => e.OwnerID == _userId)
                    .Select(e => new ItemList
                {
                    ItemId=e.ItemId,
                    ItemName = e.ItemName,
                    ItemPrice = e.ItemPrice,
                    Quantity=e.Quantity,
                   CategoryName=e.CategoryName,
                    
                    
                }).ToListAsync();

                return query.OrderBy(e=> e.ItemId);
            }
        }

        //See Details

        public async Task<ItemDetails> GetItemByIdAsync(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =await 
                    ctx
                    .Items
                    .Where(e => e.ItemId == id && e.OwnerID == _userId).FirstOrDefaultAsync();

                return
                    new ItemDetails
                    {
                        ItemId=entity.ItemId,
                        ItemName = entity.ItemName,
                        ItemDescription = entity.ItemDescription,
                        ItemPrice = entity.ItemPrice,
                        ItemCondition = entity.ItemCondition,
                        CategoryName=entity.CategoryName,
                        CategoryId = entity.CategoryId,
                        Quantity=entity.Quantity,


                    };
            }
        }
       

        public async Task<bool> UpdateItem(ItemEdit item)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = await ctx.Items.Where(e => e.ItemId == item.ItemId && e.OwnerID == _userId).FirstOrDefaultAsync();
                entity.ItemId = entity.ItemId;
                entity.ItemName = item.ItemName;
                entity.ItemDescription = item.ItemDescription;
                entity.ItemPrice = item.ItemPrice;
                entity.ItemCondition = item.ItemCondition;
                entity.CategoryId = item.CategoryId;
                entity.Quantity = item.Quantity;
            

                return await ctx.SaveChangesAsync() == 1;
            }
        }

        public async Task<bool> DeleteItemAsync(int itemId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity= await ctx.Items.Where(e => e.ItemId== itemId && e.OwnerID == _userId).FirstOrDefaultAsync();//to return the first element of a sequence or a default value if element isn't there.

                ctx.Items.Remove(entity);

                return await ctx.SaveChangesAsync() == 1;
            };
        }
    }
}
