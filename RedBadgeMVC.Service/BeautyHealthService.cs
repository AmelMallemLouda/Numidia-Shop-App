using RedBadgeMVC.Data;
using RedBadgeMVC.Models.BeautyHealthModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedBadgeMVC.Service
{
    public class BeautyHealthService
    {
        private readonly Guid _userId;
        public BeautyHealthService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateBeautyHealth(BeautyHealthCreate model)
        {
            var entity = new BeautyHealth()
            {
                BeautyHealthName = model.BeautyHealthName
            };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.BeautyHealths.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<BeautyHealthListItem> GetBeautyHealth()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.BeautyHealths.Select(
                            e =>
                                new BeautyHealthListItem
                                {
                                    BeautyHealthName=e.BeautyHealthName
                                }

                        );

                return query.ToArray();
            }
        }

    }
}
