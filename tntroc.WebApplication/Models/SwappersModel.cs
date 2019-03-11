using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using tntroc.Domain.Entities;
using tntroc.Services;

namespace tntroc.WebApplication.Models
{


    public class SwaperModels
    {
        public SwaperModels()
        {
            this.goods = new List<GoodsModels>();
            // this.exchangeswaps = new List<exchange>();
            //this.claims = new List<claim>();
        }

        [Key]
        [Column("id_swapper")]
        public int id_swapper { get; set; }

        [Column("firstname")]
        public string firstname { get; set; }

        [Column("lastname")]
        public string lastname { get; set; }

        [Column("dateofbirth")]
        public DateTime dateofbirth { get; set; }

        [Column("Phonenumber")]
        public int Phonenumber { get; set; }

        [Column("email")]
        public string email { get; set; }

        [Column("adress")]
        public string adress { get; set; }

        [Column("state")]
        public string state { get; set; }

        [Column("login")]
        public string login { get; set; }

        [Column("password")]
        public string password { get; set; }

        [Column("sex")]
        public Sex sex { get; set; }

        [Column("status")]
        public string status { get; set; }


        public ICollection<GoodsModels> goods { get; set; }


        public static implicit operator SwaperModels(swapper sub)
        {
            return new SwaperModels
            {
                id_swapper = sub.id_swapper,
                lastname = sub.lastname,
                adress = sub.adress,
                email = sub.email,
                Phonenumber = (int)sub.Phonenumber,
                firstname = sub.firstname

                //subCategorys=sub.subCategorys

            };
        }

        public static implicit operator swapper(SwaperModels sb)
        {
            return new swapper
            {
                id_swapper = sb.id_swapper,
                firstname = sb.firstname,
                // subCategorys = sb.subCategorys,
                lastname = sb.lastname,
                Phonenumber = sb.Phonenumber,
                email = sb.email,
                adress = sb.adress


            };


        }

    }



    public class SwapperSearch
    {
        ISwapperService service = new SwapperService();
        public string txt { get; set; }
        public string txt1 { get; set; }
        public IEnumerable<swapper> res { get; set; }
        

        public SwapperSearch()
        {
            res = service.GetAll();
        }
    }
    
}
