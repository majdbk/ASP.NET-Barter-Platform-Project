
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tntroc.Data.Infrastructure;
using tntroc.Domain.Entities;
using tntroc.ServicesPattern;

namespace tntroc.Services
{
    public class GoodService : Service<goods>, IGoodService
    {
         static IDatabaseFactory dbf = new DatabaseFactory();
         static IUnitOfWork ut = new UnitOfWork(dbf);

        public GoodService() : base(ut)
        {

        }
        public IEnumerable<goods> searchByScore()
        {
            return this.GetAll().OrderByDescending(g => g.score);

        }

        public category mostRatedCategory()
        {


            goods g = ut.GetRepository<goods>().GetAll().OrderByDescending(d => d.score).First();

            var res = from req in ut.GetRepository<subCategory>().GetAll().Where(c => c.id_subCategory == g.subCategoryID)
                      select req.category; 
                     


            return res.First();
        }

    }
}
