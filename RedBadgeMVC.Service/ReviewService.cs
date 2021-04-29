using RedBadgeMVC.Data;
using RedBadgeMVC.Models.ReviewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedBadgeMVC.Service
{
    public class ReviewService
    {
        private readonly Guid _userId;

        public ReviewService(Guid userId)
        {
            _userId = userId;
        }

        public async Task<bool> CreateReviewAsync(ReviewCreate model)
        {
            var entity =
                new Review()
                {
        
                    Reviews = model.Reviews,
                    ProductId = model.ProductId,
                    OwnerID=_userId
                    
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Reviews.Add(entity);
                return await ctx.SaveChangesAsync() == 1;
            }
        }
        public async Task<IEnumerable<ReviewListItem>> GetReviewAsync()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = await ctx.Reviews/*.Where(e => e.OwnerID == _userId)*/
                    .Select(e => new ReviewListItem
                    {
                        ReviewId = e.ReviewId,
                        Reviews = e.Reviews,
                        ItemName = e.Product.ProductName,
                      



                    }).ToListAsync();

                return query.OrderBy(e => e.ReviewId);
            }
        }
        public async Task<ReviewDetails> GetReviewByIdAsync(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {

                var entity = await
                    ctx
                        .Reviews
                        .Where(e => e.ReviewId == id /*&& e.OwnerID == _userId*/).FirstOrDefaultAsync();
                      
                return
                    new ReviewDetails
                    {
                        ReviewId = entity.ReviewId,
                        Reviews = entity.Reviews,
                        ItemName = entity.Product.ProductName,

                    };
            }
        }

        public async Task<bool> UpdateReviewAsync(ReviewEdit note)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = await
                    ctx
                        .Reviews
                        .Where(e => e.ReviewId == note.ReviewId && e.OwnerID == _userId)
                        .FirstOrDefaultAsync();
                entity.Reviews = note.Reviews;
                //entity.ProductId = note.ItemId;

                return await ctx.SaveChangesAsync() == 1;
            }
        }
        public async Task<bool> DeleteReviewAsync(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = await
                    ctx
                        .Reviews
                        .Where(e => e.ReviewId == id && e.OwnerID == _userId)
                        .FirstOrDefaultAsync();

                ctx.Reviews.Remove(entity);

                return await ctx.SaveChangesAsync() == 1;
            }
        }


    }
}
