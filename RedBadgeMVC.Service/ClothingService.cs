using RedBadgeMVC.Data;
using RedBadgeMVC.Models.ClothingModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedBadgeMVC.Service
{
   public class ClothingService
    {
        private readonly Guid _userId;
        public ClothingService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateClothing(ClothingCreate model)
        {
            var entity = new Clothing()
            {
                ClothingName = model.ClothingName
            };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Clothing.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public async Task<IEnumerable<ClothingListItem>> GetClothing()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = await ctx.Clothing.Select(
                            e =>
                                new ClothingListItem
                                {
                                    ClothingId=e.ClothingId,
                                    ClothingName=e.ClothingName
                                }

                        ).ToListAsync();

                return query.OrderBy(e => e.ClothingId);
            }
        }
    }
    
}
