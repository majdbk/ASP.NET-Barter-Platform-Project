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
   public class GoodsService : Service<goods>, IGoodsService
    {
        static IDatabaseFactory dbf = new DatabaseFactory();
        static IUnitOfWork ut = new UnitOfWork(dbf);

        public GoodsService() : base(ut)
        {



        }

        public List<goods> GoodsValid()
        {
            List<goods> list = ut.GetRepository<goods>().GetMany(c => c.validity==1)
                .OrderByDescending(c=>c.date).ToList();
            return list;

        }

        public goods GoodsDetails(int id)
        {
            goods good= ut.GetRepository<goods>().Get(c=>c.id_goods==id);
            return good;

        }

        public swapper ConsultSwaper(int id)
        {
           
            swapper swp = ut.GetRepository<swapper>().Get(c => c.id_swapper == id);
            return swp;

        }


        public List<goods> ConsultGoods(int id)
        {

            List<goods> lst = ut.GetRepository<goods>().GetMany(c => c.swapperID==id).ToList();
            
            return lst;

        }
        public IEnumerable<goods> ConsultGoods2(int id)
        {

            return ut.GetRepository<goods>().GetMany(c => c.swapperID == id).Where(c=>c.validity==1)
                .OrderBy(c=>c.date)
                .ToList();
          


        }

        public List<exchange> ConsultRequest(int id)
        {

            List<exchange> lst = ut.GetRepository<exchange>().GetMany(c => c.idgooddemande == id)
               .ToList();

            return lst;

        }
        public List<exchange> ConsultSent(int idG, int idS)
        {

            List<exchange> lst = ut.GetRepository<exchange>().GetMany(c => c.idgoodOffre == idG)
               .Where(c => c.goodOffre.swapperID == idS).ToList();

            return lst;

        }
        public static int ConsultAllRequestUserCount(int id)
        {

            List<exchange> lst = ut.GetRepository<exchange>().GetAll().ToList();
            List<goods> lst2 = ut.GetRepository<goods>().GetAll().ToList();

            int nbr = lst.Join(lst2, ech => ech.idgooddemande, gd => gd.id_goods, (ech, gd) => new { gd.swapperID })
                .Where(r => r.swapperID == id).Count();
            return nbr;


        }
         public static int ConsultAllRequestUserCountPending(int id)
        {

            List<exchange> lst = ut.GetRepository<exchange>().GetAll().ToList();
            List<goods> lst2 = ut.GetRepository<goods>().GetAll().ToList();

            int nbr = lst.Join(lst2, ech => ech.idgooddemande, gd => gd.id_goods, (ech, gd) => new { gd.swapperID,ech.status })
                .Where(r => r.swapperID == id && r.status== Domain.Entities.Statusexchange.pending).Count();
            return nbr;


        }
        public static int ConsultAllRequestUserCountAccepted(int id)
        {

            List<exchange> lst = ut.GetRepository<exchange>().GetAll().ToList();
            List<goods> lst2 = ut.GetRepository<goods>().GetAll().ToList();

            int nbr = lst.Join(lst2, ech => ech.idgooddemande, gd => gd.id_goods, (ech, gd) => new { gd.swapperID, ech.status })
                .Where(r => r.swapperID == id && r.status == Domain.Entities.Statusexchange.accepted).Count();
            return nbr;


        }
        public static int ConsultAllRequestUserCountCandeled(int id)
        {

            List<exchange> lst = ut.GetRepository<exchange>().GetAll().ToList();
            List<goods> lst2 = ut.GetRepository<goods>().GetAll().ToList();

            int nbr = lst.Join(lst2, ech => ech.idgooddemande, gd => gd.id_goods, (ech, gd) => new { gd.swapperID, ech.status })
                .Where(r => r.swapperID == id && r.status == Domain.Entities.Statusexchange.canceled).Count();
            return nbr;


        }

        public static int ConsultAllSenttUserCount(int id)
        {

            List<exchange> lst = ut.GetRepository<exchange>().GetAll().ToList();
            List<goods> lst2 = ut.GetRepository<goods>().GetAll().ToList();

            int nbr = lst.Join(lst2, ech => ech.idgoodOffre, gd => gd.id_goods, (ech, gd) => new { gd.swapperID })
                .Where(r => r.swapperID == id).Count();
            return nbr;


        }
        public static int ConsultAllSenttUserCountPending(int id)
        {

            List<exchange> lst = ut.GetRepository<exchange>().GetAll().ToList();
            List<goods> lst2 = ut.GetRepository<goods>().GetAll().ToList();

            int nbr = lst.Join(lst2, ech => ech.idgoodOffre, gd => gd.id_goods, (ech, gd) => new { gd.swapperID, ech.status })
                .Where(r => r.swapperID == id && r.status == Domain.Entities.Statusexchange.pending).Count();
            return nbr;


        }
        public static int ConsultAllSenttUserCountAccepted(int id)
        {

            List<exchange> lst = ut.GetRepository<exchange>().GetAll().ToList();
            List<goods> lst2 = ut.GetRepository<goods>().GetAll().ToList();

            int nbr = lst.Join(lst2, ech => ech.idgoodOffre, gd => gd.id_goods, (ech, gd) => new { gd.swapperID, ech.status })
                .Where(r => r.swapperID == id && r.status == Domain.Entities.Statusexchange.accepted).Count();
            return nbr;


        }
        public static int ConsultAllSenttUserCountCandeled(int id)
        {

            List<exchange> lst = ut.GetRepository<exchange>().GetAll().ToList();
            List<goods> lst2 = ut.GetRepository<goods>().GetAll().ToList();

            int nbr = lst.Join(lst2, ech => ech.idgoodOffre, gd => gd.id_goods, (ech, gd) => new { gd.swapperID, ech.status })
                .Where(r => r.swapperID == id && r.status == Domain.Entities.Statusexchange.canceled).Count();
            return nbr;


        }

        public static List<goods> chart()
        {
            List<goods> list = ut.GetRepository<goods>().GetMany(c => c.validity == 1)
                .OrderByDescending(c => c.date).ToList();
            return list;

        }


        
    }
}
