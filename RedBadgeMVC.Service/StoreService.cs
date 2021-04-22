using RedBadgeMVC.Data;
using RedBadgeMVC.Models.ItemModels;
using RedBadgeMVC.Models.StoreModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedBadgeMVC.Service
{
    public class StoreService
    {
        private readonly Guid _userId;
        public StoreService(Guid userId)
        {
            _userId = userId;
        }
        public async Task<bool> CreateStoreAsync(StoreCreate store)
        {
            var entity = new Store()
            {
                StoreName = store.StoreName,
                PhoneNumber = store.PhoneNumber,
                Latitude = store.Latitude,
                Longitude = store.Longitude

            };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Stores.Add(entity);
                return await ctx.SaveChangesAsync() == 1;
            }
        }

        public async Task<IEnumerable<StoreListItem>> GetStoresAsync()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = await
                            ctx
                            .Stores
                            .Select(

                                e =>
                                    new StoreListItem
                                    {
                                        StoreId = e.StoreId,
                                        StoreName = e.StoreName,
                                        Items = e.Products
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
                return query.OrderBy(e => e.StoreId);
            }
        }

        public async Task<StoreDetails> GetStoreByIdAsync(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = await
                    ctx
                        .Stores
                        .Where(e => e.StoreId == id).FirstOrDefaultAsync();
                return new StoreDetails
                {
                    StoreId = entity.StoreId,
                    StoreName = entity.StoreName,
                    PhoneNumber = entity.PhoneNumber,
                    Latitude = entity.Latitude,
                    Longitude = entity.Longitude,
                    Items = entity.Products.Select(z => new ProductShortList
                    {
                        ProductId = z.ProductId,
                        Name = z.ProductName,
                        Price = z.ProductPrice
                    }).ToList(),

                };

            }
        }
        public async Task<bool> UpdateStoretAsync(StoreEdit store)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = await
                    ctx
                        .Stores
                        .Where(e => e.StoreId == store.StoreId).FirstOrDefaultAsync();

                entity.StoreName = store.StoreName;
                entity.PhoneNumber = store.PhoneNumber;
                entity.Latitude = store.Latitude;
                entity.Longitude = store.Longitude;

                return await ctx.SaveChangesAsync() == 1;
            }
        }

        public async Task<bool> DeleteStoreAsync(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = await
                    ctx
                        .Stores
                        .Where(e => e.StoreId == id).FirstOrDefaultAsync();

                ctx.Stores.Remove(entity);

                return await ctx.SaveChangesAsync() == 1;
            }
        }

    }


} 

