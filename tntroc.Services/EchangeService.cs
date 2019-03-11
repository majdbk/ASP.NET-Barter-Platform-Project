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
    public class EchangeService : Service<exchange>, IEchangeService
    {
        static IDatabaseFactory dbf = new DatabaseFactory();
        static IUnitOfWork ut = new UnitOfWork(dbf);

        public EchangeService() : base(ut)
        {



        }

        public exchange EchangeDetails(int id)
        {
            exchange e = ut.GetRepository<exchange>().Get(c => c.id_exchange == id);
            return e;

        }


        //public int ConsultRequestCount(int id)
        //{

        //    int nbre = ut.GetRepository<exchange>().GetMany(c => c.idgooddemande == id)
        //        .Where(c => c.status == Domain.Entities.Statusexchange.accepted)
        //       .Count();

        //    return nbre;

        //}

        public List<exchange> ConsultRequest(int id)
        {

            List<exchange> lst = ut.GetRepository<exchange>().GetMany(c => c.idgooddemande == id)
                .Where(c => c.status != Domain.Entities.Statusexchange.canceled)
               .OrderByDescending(c => c.status).ToList();

            return lst;

        }

        public static int ConsultRequestCount(int id)
        {

            int nbre = ut.GetRepository<exchange>().GetMany(c => c.idgooddemande == id)
               .Where(c => c.status == Domain.Entities.Statusexchange.pending).Count();

            return nbre;

        }

        public static int ConsultSentCount(int id)
        {

            int nbre = ut.GetRepository<exchange>().GetMany(c => c.idgoodOffre == id)
               .Where(c => c.status == Statusexchange.pending).Count();

            return nbre;

        }

        public List<exchange> ConsultSent(int id)
        {

            List<exchange> lst = ut.GetRepository<exchange>().GetMany(c => c.idgoodOffre == id)
                .OrderByDescending(c => c.status)
               .ToList();

            return lst;

        }


        public Boolean verif(int id1, int id2)
        {

            return ut.GetRepository<exchange>().GetMany(c => c.idgoodOffre == id1)
                 .Any(c => c.idgooddemande == id2);




        }
        public static int[] EchangeRequestStats(int id)
        {
            int[] opeStat = new int [] { 0, 0, 0, 0 };

            opeStat[0] = ut.GetRepository<exchange>().GetMany(c => c.status == Statusexchange.pending)
               .Where(c=>c.goodDemande.swapperID==id).Count();
            opeStat[1] = ut.GetRepository<exchange>().GetMany(c => c.status == Statusexchange.accepted)
               .Where(c => c.goodDemande.swapperID == id).Count();
            opeStat[2] = ut.GetRepository<exchange>().GetMany(c => c.status == Statusexchange.confirmed)
                .Where(c => c.goodDemande.swapperID == id).Count();
            opeStat[3] = ut.GetRepository<exchange>().GetMany(c => c.status == Statusexchange.canceled)
               .Where(c => c.goodDemande.swapperID == id).Count();



            return opeStat;

            

        }
        public static int[] EchangeSentStats(int id)
        {
            int[] opeStat = new int[] { 0, 0, 0, 0 };

            opeStat[0] = ut.GetRepository<exchange>().GetMany(c => c.status == Statusexchange.pending)
               .Where(c =>c.goodOffre.swapperID == id).Count();
            opeStat[1] = ut.GetRepository<exchange>().GetMany(c => c.status == Statusexchange.accepted)
               .Where(c => c.goodOffre.swapperID == id).Count();
            opeStat[2] = ut.GetRepository<exchange>().GetMany(c => c.status == Statusexchange.confirmed)
                .Where(c => c.goodOffre.swapperID == id).Count();
            opeStat[3] = ut.GetRepository<exchange>().GetMany(c => c.status == Statusexchange.canceled)
               .Where(c => c.goodOffre.swapperID == id).Count();



            return opeStat;



        }

        public List<exchange> teststat()
        {

            List<exchange> lst = ut.GetRepository<exchange>().GetAll()
                .OrderByDescending(c => c.status)
               .ToList();

            return lst;

        }
    } }
    