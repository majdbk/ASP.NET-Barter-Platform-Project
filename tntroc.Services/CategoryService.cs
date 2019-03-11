
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
    public class CategoryService : Service<category>, ICategoryService
    {
         static IDatabaseFactory dbf = new DatabaseFactory();
         static IUnitOfWork ut = new UnitOfWork(dbf);

        public CategoryService() : base(ut)
        {

        }
    }
}
