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
    public class SubCategoryService : Service<subCategory>, ISubCategoryService
    {
        static IDatabaseFactory dbf = new DatabaseFactory();
        static IUnitOfWork ut = new UnitOfWork(dbf);

        public SubCategoryService() : base(ut)
        {

        }
    }
}
