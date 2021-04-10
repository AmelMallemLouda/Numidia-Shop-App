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
                OwnerId = _userId, //We want the user who creates the note to be the user who is logged in
                ItemName = item.ItemName,
                ItemDescription = item.ItemDescription,
                ItemPrice = item.ItemPrice,
                ItemCondition = item.ItemCondition,
                HomeId = item.HomeId,
                BautyId = item.BautyId,
                ClothingId = item.ClothingId
                //CategoryName=item.Categoryname
            };
            using (var ctx = new ApplicationDbContext())// Access database
            {
                ctx.Items.Add(entity);// access items Table and add items
                return await ctx.SaveChangesAsync() == 1;
            }
        }
      

        //See all the Items 
        public async Task<IEnumerable<ItemList>> GetAllItems()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = await ctx.Items.Select(e => new ItemList
                {
                    ItemId=e.ItemId,
                    ItemName = e.ItemName,
                    ItemPrice = e.ItemPrice,
                    HomeId=e.HomeKitchen.HomeKitchenId,
                    HomeName= e.HomeKitchen.HomeKitchenName
                    
                }).ToListAsync();

                return query.OrderBy(e=> e.ItemId);
            }
        }

        //See Details

        public async Task<ItemDetails> GetItemById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = await ctx.Items.Where(e => e.ItemId == id && e.OwnerId == _userId).FirstOrDefaultAsync();

                return
                    new ItemDetails
                    {
                        ItemId=entity.ItemId,
                        ItemName = entity.ItemName,
                        ItemDescription = entity.ItemDescription,
                        ItemPrice = entity.ItemPrice,
                        ItemCondition = entity.ItemCondition,
                        HomeId = entity.HomeId,
                        HomeName = entity.HomeKitchen.HomeKitchenName
                        //CategoryName=item.Categoryname

                    };
            }
        }


        public async Task<bool> UpdateItem(ItemEdit item)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = await ctx.Items.Where(e => e.ItemId == item.ItemId && e.OwnerId == _userId).FirstOrDefaultAsync();
                entity.ItemId = entity.ItemId;
                entity.ItemName = item.ItemName;
                entity.ItemDescription = item.ItemDescription;
                entity.ItemPrice = item.ItemPrice;
                entity.ItemCondition = item.ItemCondition;
                
                //CategoryName=item.Categoryname

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteItem(int ItemId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Items.Where(e => e.ItemId == ItemId && e.OwnerId == _userId).FirstOrDefault();

                ctx.Items.Remove(entity);

                return ctx.SaveChanges() == 1;
            };
        }
    }
}
