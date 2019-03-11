using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using tntroc.Domain.Entities;

namespace tntroc.WebApplication.Models
{
    public enum StatusExchange { pending, accepted, confirmed, canceled }
    public class ExchangeModels
    {
        [Key]
        public int id_exchange { get; set; }


        public int idgoodOffre { get; set; }
        [ForeignKey("idgoodOffre")]
       public virtual GoodsModels goodOffre { get; set; }
       public IEnumerable<SelectListItem> offres { get; set; }

        public int idgooddemande { get; set; }
        [ForeignKey("idgooddemande")]
        public virtual GoodsModels goodDemande { get; set; }
      public IEnumerable<SelectListItem> demandes { get; set; }

        //public int idswap { get; set; }
        // public virtual swapper swapper { get; set; }


        public Statusexchange status { get; set; }


        [Required(ErrorMessage = "You must give a date for the deal ")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Date of Echange :")]
        public System.DateTime date_exchange { get; set; }







        public static implicit operator ExchangeModels(exchange sub)
        {
            return new ExchangeModels
            {
                date_exchange= sub.date_exchange,

                status = sub.status,
                id_exchange = sub.id_exchange,
                idgooddemande = sub.idgooddemande,
                idgoodOffre = sub.idgoodOffre,
                goodDemande = sub.goodDemande,
                goodOffre = sub.goodOffre,
           

                //subCategorys=sub.subCategorys

            };
        }

        public static implicit operator exchange(ExchangeModels sb)
        {
            return new exchange
            {
                date_exchange= sb.date_exchange,
                goodDemande = sb.goodDemande,
                // subCategorys = sb.subCategorys,
                goodOffre = sb.goodOffre,
                id_exchange = sb.id_exchange,
                status = sb.status,
                idgoodOffre = sb.idgoodOffre,
                idgooddemande = sb.idgooddemande,
             

            };


        }

       




    }
}