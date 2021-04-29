using RedBadgeMVC.Data;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedBadgeMVC.Models.Home
{
    public class HomeIndexViewModel
    {

        private ApplicationDbContext _db = new ApplicationDbContext();

        public List<Product> ListOfProducts { get; set; }
        public HomeIndexViewModel CreateModel(string search)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@search", search??(object)DBNull.Value)
            };
            List<Product> data = _db.Database.SqlQuery<Product>("GetBySearch @search", param).ToList();

            return new HomeIndexViewModel
            {

                ListOfProducts = data
            };

        }

    }
}
