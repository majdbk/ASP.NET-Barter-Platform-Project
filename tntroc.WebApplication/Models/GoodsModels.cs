using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using tntroc.Domain.Entities;

namespace tntroc.WebApplication.Models
{
    
    public class GoodsModels
    {
        [Key]
        public int id_goods { get; set; }

        public string brand { get; set; }
        public string description { get; set; }

        public DateTime date { get; set; }
        public int validity { get; set; }
        public int quantity { get; set; }
        public string label { get; set; }
        public string image { get; set; }
        public Accpted accepted { get; set; }

        public int subCategoryID { get; set; }

        [ForeignKey("subCategoryID")]
        public virtual SubCategoryModel subCategory { get; set; }

        public int swapperID { get; set; }

        [ForeignKey("swapperID")]
        public virtual SwaperModels swapper { get; set; }



        public ICollection<ExchangeModels> exchangesgoodsoffre { get; set; }
        public ICollection<ExchangeModels> exchangesgoodsdemande { get; set; }




        public static implicit operator GoodsModels(goods sub)
        {
            return new GoodsModels
            {
                brand = sub.brand,

                date = sub.date,
                description = sub.description,
                id_goods = sub.id_goods,
                label = sub.label,
                quantity = sub.quantity,
                swapper = sub.swapper,
                subCategoryID=sub.subCategoryID,
                subCategory=sub.subCategory,
                validity=sub.validity,
                swapperID=sub.swapperID,
                image=sub.image
                //exchangesgoodsdemande=sub.exchangesgoodsdemande,
                //exchangesgoodsoffre=sub.exchangesgoodsoffre

                //subCategorys=sub.subCategorys

            };
        }

        public static implicit operator goods(GoodsModels sb)
        {
            return new goods
            {
                brand = sb.brand,
                date = sb.date,
                // subCategorys = sb.subCategorys,
                description = sb.description,
                id_goods = sb.id_goods,
                label= sb.label,
                quantity = sb.quantity,
                subCategory=sb.subCategory,
                subCategoryID=sb.subCategoryID,
                swapper=sb.swapper,
                swapperID=sb.swapperID,
                validity=sb.validity,
                image=sb.image
                //exchangesgoodsdemande=sb.exchangesgoodsdemande,
                //exchangesgoodsoffre=sb.exchangesgoodsoffre


            };


        }



    }
}