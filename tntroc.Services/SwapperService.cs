using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using tntroc.Domain.Entities;
using tntroc.ServicesPattern;
using tntroc.Data.Infrastructure;


namespace tntroc.Services
{
    public class SwapperService : Service<swapper>, ISwapperService
    {
        private static IDatabaseFactory dbf = new DatabaseFactory();
        private static IUnitOfWork ut = new UnitOfWork(dbf);

        public SwapperService() : base(ut)
        {
        }
    }
}
